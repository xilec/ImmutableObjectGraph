﻿namespace ImmutableObjectGraph.CodeGeneration.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Microsoft.CodeAnalysis.MSBuild;
    using Microsoft.CodeAnalysis.Text;
    using Microsoft.ImmutableObjectGraph_SFG;
    using Xunit;

    public class CodeGenTests
    {
        protected Solution solution;
        protected ProjectId projectId;
        protected DocumentId inputDocumentId;

        public CodeGenTests()
        {
            var workspace = new CustomWorkspace();
            var project = workspace.CurrentSolution.AddProject("test", "test", "C#")
                .WithCompilationOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(string).Assembly))
                .AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(GenerateImmutableAttribute).Assembly))
                .AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(CodeGenerationAttribute).Assembly))
                .AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(Optional).Assembly))
                .AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(ImmutableArray).Assembly))
                .AddMetadataReference(MetadataReference.CreateFromAssembly(Assembly.LoadWithPartialName("System.Runtime")));
            var inputDocument = project.AddDocument("input.cs", string.Empty);
            this.inputDocumentId = inputDocument.Id;
            project = inputDocument.Project;
            this.projectId = inputDocument.Project.Id;
            this.solution = project.Solution;
        }

        [Fact]
        public async Task NoFields_HasCreateMethod()
        {
            var result = await this.GenerateFromStreamAsync("NoFields");
            Assert.True(result.DeclaredMethods.Any(m => m.Name == "Create" && m.Parameters.Length == 0 && m.IsStatic));
        }

        [Fact]
        public async Task NoFieldsAndNoFieldsDerived_HasCreateMethod()
        {
            var result = await this.GenerateFromStreamAsync("NoFieldsAndNoFieldsDerived");
            Assert.Equal(2, result.DeclaredMethods.Count(m => m.Name == "Create" && m.Parameters.Length == 0 && m.IsStatic));
        }

        [Fact]
        public async Task NoFieldsAndOneScalarFieldDerived_HasCreateMethod()
        {
            var result = await this.GenerateFromStreamAsync("NoFieldsAndOneScalarFieldDerived");
            Assert.Equal(1, result.DeclaredMethods.Count(m => m.ContainingType.Name == "Empty" && m.Name == "Create" && m.Parameters.Length == 0 && m.IsStatic));
            Assert.Equal(1, result.DeclaredMethods.Count(m => m.ContainingType.Name == "NotSoEmptyDerived" && m.Name == "Create" && m.Parameters.Length == 1 && m.IsStatic));
        }

        [Fact]
        public async Task OneScalarFieldAndEmptyDerived_HasCreateMethod()
        {
            var result = await this.GenerateFromStreamAsync("OneScalarFieldAndEmptyDerived");
            Assert.Equal(2, result.DeclaredMethods.Count(m => m.Name == "Create" && m.Parameters.Length == 1 && m.IsStatic));
        }

        [Fact]
        public async Task FamilyPersonWatch()
        {
            await this.GenerateFromStreamAsync("FamilyPersonWatch");
        }

        [Fact]
        public async Task OneScalarField_HasWithMethod()
        {
            var result = await this.GenerateFromStreamAsync("OneScalarField");
            Assert.True(result.DeclaredMethods.Any(m => m.Name == "With" && m.Parameters.Single().Name == "seeds" && !m.IsStatic));
        }

        [Fact]
        public async Task OneScalarField_HasCreateMethod()
        {
            var result = await this.GenerateFromStreamAsync("OneScalarField");
            Assert.True(result.DeclaredMethods.Any(m => m.Name == "Create" && m.Parameters.Single().Name == "seeds"));
        }

        [Fact]
        public async Task OneScalarFieldWithBuilder_HasToBuilderMethod()
        {
            var result = await this.GenerateFromStreamAsync("OneScalarFieldWithBuilder");
            Assert.True(result.DeclaredMethods.Any(m => m.Name == "ToBuilder" && m.Parameters.Length == 0 && !m.IsStatic));
        }

        [Fact]
        public async Task OneScalarFieldWithBuilder_HasCreateBuilderMethod()
        {
            var result = await this.GenerateFromStreamAsync("OneScalarFieldWithBuilder");
            Assert.True(result.DeclaredMethods.Any(m => m.Name == "CreateBuilder" && m.Parameters.Length == 0 && m.IsStatic));
        }

        [Fact]
        public async Task OneScalarFieldWithBuilder_BuilderHasMutableProperties()
        {
            var result = await this.GenerateFromStreamAsync("OneScalarFieldWithBuilder");
            Assert.True(result.DeclaredProperties.Any(p => p.ContainingType?.Name == "Builder" && p.Name == "Seeds" && p.SetMethod != null && p.GetMethod != null));
        }

        [Fact]
        public async Task OneScalarFieldWithBuilder_BuilderHasToImmutableMethod()
        {
            var result = await this.GenerateFromStreamAsync("OneScalarFieldWithBuilder");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType?.Name == "Builder" && m.Name == "ToImmutable" && m.Parameters.Length == 0 && !m.IsStatic));
        }

        [Fact]
        public async Task ClassDerivesFromAnotherWithFields_DerivedCreateParametersIncludeBaseFields()
        {
            var result = await this.GenerateFromStreamAsync("ClassDerivesFromAnotherWithFields");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType?.Name == "Fruit" && m.Name == "Create" && m.Parameters.Length == 1));
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType?.Name == "Apple" && m.Name == "Create" && m.Parameters.Length == 2));
        }

        [Fact]
        public async Task ClassDerivesFromAnotherWithFields_DerivedWithParametersIncludeBaseFields()
        {
            var result = await this.GenerateFromStreamAsync("ClassDerivesFromAnotherWithFields");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType?.Name == "Fruit" && m.Name == "With" && m.Parameters.Length == 1));
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType?.Name == "Apple" && m.Name == "With" && m.Parameters.Length == 2));
        }

        [Fact]
        public async Task ClassDerivesFromAnotherWithFields_DerivedWithCoreParametersIncludeBaseFields()
        {
            var result = await this.GenerateFromStreamAsync("ClassDerivesFromAnotherWithFields");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType?.Name == "Fruit" && m.Name == "WithCore" && m.Parameters.Length == 1 && m.IsVirtual));
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType?.Name == "Apple" && m.Name == "WithCore" && m.Parameters.Length == 1 && m.IsOverride));
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType?.Name == "Apple" && m.Name == "WithCore" && m.Parameters.Length == 2 && m.IsVirtual));
        }

        [Fact]
        public async Task ClassDerivesFromAnotherWithFieldsAndBuilder_BuildersReflectTypeRelationship()
        {
            var result = await this.GenerateFromStreamAsync("ClassDerivesFromAnotherWithFieldsAndBuilder");
            var fruitBuilder = result.DeclaredTypes.Single(t => t.Name == "Builder" && t.ContainingType.Name == "Fruit");
            Assert.Same(fruitBuilder, result.DeclaredTypes.Single(t => t.Name == "Builder" && t.ContainingType.Name == "Apple").BaseType);
        }

        [Fact]
        public async Task AbstractNonEmptyWithDerivedEmpty_HasCreateOnlyInNonAbstractClass()
        {
            var result = await this.GenerateFromStreamAsync("AbstractNonEmptyWithDerivedEmpty");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType.Name == "EmptyDerivedFromAbstract" && m.Name == "Create" && m.Parameters.Single().Name == "oneField"));
            Assert.False(result.DeclaredMethods.Any(m => m.ContainingType.Name == "AbstractNonEmpty" && m.Name == "Create"));
        }

        [Fact]
        public async Task AbstractNonEmptyWithDerivedEmpty_HasValidateMethodOnBothTypes()
        {
            var result = await this.GenerateFromStreamAsync("AbstractNonEmptyWithDerivedEmpty");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType.Name == "EmptyDerivedFromAbstract" && m.Name == "Validate"));
            Assert.False(result.DeclaredMethods.Any(m => m.ContainingType.Name == "AbstractNonEmpty" && m.Name == "Validate"));
        }

        [Fact]
        public async Task AbstractNonEmptyWithDerivedEmpty_HasWithMethodOnBothTypes()
        {
            var result = await this.GenerateFromStreamAsync("AbstractNonEmptyWithDerivedEmpty");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType.Name == "AbstractNonEmpty" && m.Name == "With" && m.Parameters.Single().Name == "oneField"));
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType.Name == "AbstractNonEmpty" && m.Name == "With" && m.Parameters.Single().Name == "oneField"));
        }

        [Fact]
        public async Task AbstractNonEmptyWithDerivedEmpty_HasWithCoreMethodOnBothTypes()
        {
            var result = await this.GenerateFromStreamAsync("AbstractNonEmptyWithDerivedEmpty");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType.Name == "EmptyDerivedFromAbstract" && m.Name == "WithCore" && m.Parameters.Single().Name == "oneField"));
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType.Name == "AbstractNonEmpty" && m.Name == "WithCore" && m.Parameters.Single().Name == "oneField"));
        }

        [Fact]
        public async Task AbstractNonEmptyWithDerivedEmpty_HasWithFactoryMethodOnConcreteTypeOnly()
        {
            var result = await this.GenerateFromStreamAsync("AbstractNonEmptyWithDerivedEmpty");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType.Name == "EmptyDerivedFromAbstract" && m.Name == "WithFactory" && m.Parameters.Length == 2));
            Assert.False(result.DeclaredMethods.Any(m => m.ContainingType.Name == "AbstractNonEmpty" && m.Name == "WithFactory" && m.Parameters.Length == 2));
        }

        [Fact]
        public async Task DeepHierarchy_HasTypeConverters()
        {
            var result = await this.GenerateFromStreamAsync("DeepHierarchy");
            Assert.True(result.DeclaredMethods.Any(m => m.ContainingType.Name == "A" && m.Name == "ToB" && m.Parameters.Length == 1 && m.Parameters[0].Name == "field2"));
        }

        [Fact]
        public async Task DeepHierarchy_DefinesInterfaces()
        {
            var result = await this.GenerateFromStreamAsync("DeepHierarchy");

            // Verify interfaces are defined.
            Assert.True(result.DeclaredTypes.Any(t => t.Name == "IA" && t.GetMembers().Any(f => f.Name == "Field1")));
            Assert.True(result.DeclaredTypes.Any(t => t.Name == "IB" && t.GetMembers().Any(f => f.Name == "Field2")));
            Assert.True(result.DeclaredTypes.Any(t => t.Name == "IC1" && t.GetMembers().Any(f => f.Name == "Field3")));
            Assert.True(result.DeclaredTypes.Any(t => t.Name == "IC2" && t.GetMembers().Any(f => f.Name == "Field3")));

            // Verify interfaces are implemented by their types.
            Assert.True(result.DeclaredTypes.Any(t => t.Name == "A" && t.Interfaces.Any(i => i.Name == "IA")));
            Assert.True(result.DeclaredTypes.Any(t => t.Name == "B" && t.Interfaces.Any(i => i.Name == "IB")));
            Assert.True(result.DeclaredTypes.Any(t => t.Name == "C1" && t.Interfaces.Any(i => i.Name == "IC1")));
            Assert.True(result.DeclaredTypes.Any(t => t.Name == "C2" && t.Interfaces.Any(i => i.Name == "IC2")));
        }

        [Fact]
        public async Task AbstractClassFamilies_Compiles()
        {
            var result = await this.GenerateFromStreamAsync("AbstractClassFamilies");
        }

        [Fact]
        public async Task OneImmutableFieldToAnotherWithOneScalarField_Compiles()
        {
            var result = await this.GenerateFromStreamAsync("OneImmutableFieldToAnotherWithOneScalarField");

        }

        [Fact]
        public async Task FileSystem_Compiles()
        {
            var result = await this.GenerateFromStreamAsync("FileSystem");
        }

        protected async Task<GenerationResult> GenerateFromStreamAsync(string testName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(this.GetType().Namespace + ".TestSources." + testName + ".cs"))
            {
                return await this.GenerateAsync(SourceText.From(stream));
            }
        }

        protected async Task<GenerationResult> GenerateAsync(SourceText inputSource)
        {
            var solution = this.solution.WithDocumentText(this.inputDocumentId, inputSource);
            var inputDocument = solution.GetDocument(this.inputDocumentId);
            var outputDocument = await DocumentTransform.TransformAsync(inputDocument, new MockProgress());

            // Make sure there are no compile errors.
            var compilation = await outputDocument.Project.GetCompilationAsync();
            var diagnostics = compilation.GetDiagnostics();
            var errors = from diagnostic in diagnostics
                         where diagnostic.Severity >= DiagnosticSeverity.Error
                         select diagnostic;
            var warnings = from diagnostic in diagnostics
                           where diagnostic.Severity >= DiagnosticSeverity.Warning
                           select diagnostic;

            Console.WriteLine(await outputDocument.GetTextAsync());

            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }

            foreach (var warning in warnings)
            {
                Console.WriteLine(warning);
            }

            Assert.Empty(errors);
            Assert.Empty(warnings);

            var semanticModel = await outputDocument.GetSemanticModelAsync();
            return new GenerationResult(outputDocument, semanticModel);
        }

        protected class GenerationResult
        {
            public GenerationResult(Document document, SemanticModel semanticModel)
            {
                this.Document = document;
                this.SemanticModel = semanticModel;
                this.Declarations = semanticModel.GetDeclarationsInSpan(TextSpan.FromBounds(0, semanticModel.SyntaxTree.Length), true, CancellationToken.None);
            }

            public Document Document { get; private set; }

            public SemanticModel SemanticModel { get; private set; }

            public ImmutableArray<DeclarationInfo> Declarations { get; private set; }

            public IEnumerable<ISymbol> DeclaredSymbols
            {
                get { return this.Declarations.Select(d => d.DeclaredSymbol); }
            }

            public IEnumerable<IMethodSymbol> DeclaredMethods
            {
                get { return this.DeclaredSymbols.OfType<IMethodSymbol>(); }
            }

            public IEnumerable<IPropertySymbol> DeclaredProperties
            {
                get { return this.DeclaredSymbols.OfType<IPropertySymbol>(); }
            }

            public IEnumerable<INamedTypeSymbol> DeclaredTypes
            {
                get { return this.DeclaredSymbols.OfType<INamedTypeSymbol>(); }
            }
        }

        private class MockProgress : IProgressAndErrors
        {
            public void Error(string message, uint line, uint column)
            {
            }

            public void Report(uint progress, uint total)
            {
            }

            public void Warning(string message, uint line, uint column)
            {
            }
        }
    }
}
