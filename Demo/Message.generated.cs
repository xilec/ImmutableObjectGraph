﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ImmutableTree Version: 0.0.0.1
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

namespace Demo {
	using System.Diagnostics;
	using ImmutableObjectGraph;

	
	public partial class Message {
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly Message DefaultInstance = GetDefaultTemplate();
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Contact author;
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.Collections.Immutable.ImmutableList<Contact> to;
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.Collections.Immutable.ImmutableList<Contact> cc;
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.Collections.Immutable.ImmutableList<Contact> bcc;
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String subject;
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String body;
	
		/// <summary>Initializes a new instance of the Message class.</summary>
		private Message()
		{
		}
	
		/// <summary>Initializes a new instance of the Message class.</summary>
		private Message(Contact author, System.Collections.Immutable.ImmutableList<Contact> to, System.Collections.Immutable.ImmutableList<Contact> cc, System.Collections.Immutable.ImmutableList<Contact> bcc, System.String subject, System.String body)
		{
			this.author = author;
			this.to = to;
			this.cc = cc;
			this.bcc = bcc;
			this.subject = subject;
			this.body = body;
			this.Validate();
		}
	
		public static Message Create(
			ImmutableObjectGraph.Optional<Contact> author = default(ImmutableObjectGraph.Optional<Contact>), 
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>> to = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>>), 
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>> cc = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>>), 
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>> bcc = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>>), 
			ImmutableObjectGraph.Optional<System.String> subject = default(ImmutableObjectGraph.Optional<System.String>), 
			ImmutableObjectGraph.Optional<System.String> body = default(ImmutableObjectGraph.Optional<System.String>)) {
			return DefaultInstance.With(
				author.IsDefined ? author : ImmutableObjectGraph.Optional.For(DefaultInstance.author), 
				to.IsDefined ? to : ImmutableObjectGraph.Optional.For(DefaultInstance.to), 
				cc.IsDefined ? cc : ImmutableObjectGraph.Optional.For(DefaultInstance.cc), 
				bcc.IsDefined ? bcc : ImmutableObjectGraph.Optional.For(DefaultInstance.bcc), 
				subject.IsDefined ? subject : ImmutableObjectGraph.Optional.For(DefaultInstance.subject), 
				body.IsDefined ? body : ImmutableObjectGraph.Optional.For(DefaultInstance.body));
		}
	
		public Contact Author {
			get { return this.author; }
		}
	
		public Message WithAuthor(Contact value) {
			if (value == this.Author) {
				return this;
			}
	
			return new Message(value, this.To, this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public System.Collections.Immutable.ImmutableList<Contact> To {
			get { return this.to; }
		}
	
		public Message WithTo(System.Collections.Immutable.ImmutableList<Contact> value) {
			if (value == this.To) {
				return this;
			}
	
			return new Message(this.Author, value, this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message WithTo(params Contact[] values) {
			return new Message(this.Author, this.To.ResetContents(values), this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message WithTo(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To.ResetContents(values), this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message AddTo(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To.AddRange(values), this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message AddTo(params Contact[] values) {
			return new Message(this.Author, this.To.AddRange(values), this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message AddTo(Contact value) {
			return new Message(this.Author, this.To.Add(value), this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message RemoveTo(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To.RemoveRange(values), this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message RemoveTo(params Contact[] values) {
			return new Message(this.Author, this.To.RemoveRange(values), this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message RemoveTo(Contact value) {
			return new Message(this.Author, this.To.Remove(value), this.Cc, this.Bcc, this.Subject, this.Body);
		}
	
		public Message ClearTo() {
			return new Message(this.Author, this.To.Clear(), this.Cc, this.Bcc, this.Subject, this.Body);
		}
		
		public System.Collections.Immutable.ImmutableList<Contact> Cc {
			get { return this.cc; }
		}
	
		public Message WithCc(System.Collections.Immutable.ImmutableList<Contact> value) {
			if (value == this.Cc) {
				return this;
			}
	
			return new Message(this.Author, this.To, value, this.Bcc, this.Subject, this.Body);
		}
	
		public Message WithCc(params Contact[] values) {
			return new Message(this.Author, this.To, this.Cc.ResetContents(values), this.Bcc, this.Subject, this.Body);
		}
	
		public Message WithCc(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To, this.Cc.ResetContents(values), this.Bcc, this.Subject, this.Body);
		}
	
		public Message AddCc(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To, this.Cc.AddRange(values), this.Bcc, this.Subject, this.Body);
		}
	
		public Message AddCc(params Contact[] values) {
			return new Message(this.Author, this.To, this.Cc.AddRange(values), this.Bcc, this.Subject, this.Body);
		}
	
		public Message AddCc(Contact value) {
			return new Message(this.Author, this.To, this.Cc.Add(value), this.Bcc, this.Subject, this.Body);
		}
	
		public Message RemoveCc(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To, this.Cc.RemoveRange(values), this.Bcc, this.Subject, this.Body);
		}
	
		public Message RemoveCc(params Contact[] values) {
			return new Message(this.Author, this.To, this.Cc.RemoveRange(values), this.Bcc, this.Subject, this.Body);
		}
	
		public Message RemoveCc(Contact value) {
			return new Message(this.Author, this.To, this.Cc.Remove(value), this.Bcc, this.Subject, this.Body);
		}
	
		public Message ClearCc() {
			return new Message(this.Author, this.To, this.Cc.Clear(), this.Bcc, this.Subject, this.Body);
		}
		
		public System.Collections.Immutable.ImmutableList<Contact> Bcc {
			get { return this.bcc; }
		}
	
		public Message WithBcc(System.Collections.Immutable.ImmutableList<Contact> value) {
			if (value == this.Bcc) {
				return this;
			}
	
			return new Message(this.Author, this.To, this.Cc, value, this.Subject, this.Body);
		}
	
		public Message WithBcc(params Contact[] values) {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.ResetContents(values), this.Subject, this.Body);
		}
	
		public Message WithBcc(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.ResetContents(values), this.Subject, this.Body);
		}
	
		public Message AddBcc(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.AddRange(values), this.Subject, this.Body);
		}
	
		public Message AddBcc(params Contact[] values) {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.AddRange(values), this.Subject, this.Body);
		}
	
		public Message AddBcc(Contact value) {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.Add(value), this.Subject, this.Body);
		}
	
		public Message RemoveBcc(System.Collections.Generic.IEnumerable<Contact> values) {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.RemoveRange(values), this.Subject, this.Body);
		}
	
		public Message RemoveBcc(params Contact[] values) {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.RemoveRange(values), this.Subject, this.Body);
		}
	
		public Message RemoveBcc(Contact value) {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.Remove(value), this.Subject, this.Body);
		}
	
		public Message ClearBcc() {
			return new Message(this.Author, this.To, this.Cc, this.Bcc.Clear(), this.Subject, this.Body);
		}
		
		public System.String Subject {
			get { return this.subject; }
		}
	
		public Message WithSubject(System.String value) {
			if (value == this.Subject) {
				return this;
			}
	
			return new Message(this.Author, this.To, this.Cc, this.Bcc, value, this.Body);
		}
	
		public System.String Body {
			get { return this.body; }
		}
	
		public Message WithBody(System.String value) {
			if (value == this.Body) {
				return this;
			}
	
			return new Message(this.Author, this.To, this.Cc, this.Bcc, this.Subject, value);
		}
	
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public Message With(
			ImmutableObjectGraph.Optional<Contact> author = default(ImmutableObjectGraph.Optional<Contact>), 
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>> to = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>>), 
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>> cc = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>>), 
			ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>> bcc = default(ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>>), 
			ImmutableObjectGraph.Optional<System.String> subject = default(ImmutableObjectGraph.Optional<System.String>), 
			ImmutableObjectGraph.Optional<System.String> body = default(ImmutableObjectGraph.Optional<System.String>)) {
			if (
				(author.IsDefined && author.Value != this.Author) || 
				(to.IsDefined && to.Value != this.To) || 
				(cc.IsDefined && cc.Value != this.Cc) || 
				(bcc.IsDefined && bcc.Value != this.Bcc) || 
				(subject.IsDefined && subject.Value != this.Subject) || 
				(body.IsDefined && body.Value != this.Body)) {
				return new Message(
					author.IsDefined ? author.Value : this.Author,
					to.IsDefined ? to.Value : this.To,
					cc.IsDefined ? cc.Value : this.Cc,
					bcc.IsDefined ? bcc.Value : this.Bcc,
					subject.IsDefined ? subject.Value : this.Subject,
					body.IsDefined ? body.Value : this.Body);
			} else {
				return this;
			}
		}
	
		public Builder ToBuilder() {
			return new Builder(this);
		}
	
		/// <summary>Normalizes and/or validates all properties on this object.</summary>
		/// <exception type="ArgumentException">Thrown if any properties have disallowed values.</exception>
		partial void Validate();
	
		/// <summary>Provides defaults for fields.</summary>
		/// <param name="template">The struct to set default values on.</param>
		static partial void CreateDefaultTemplate(ref Template template);
	
		/// <summary>Returns a newly instantiated Message whose fields are initialized with default values.</summary>
		private static Message GetDefaultTemplate() {
			var template = new Template();
			CreateDefaultTemplate(ref template);
			return new Message(
				template.Author, 
				template.To, 
				template.Cc, 
				template.Bcc, 
				template.Subject, 
				template.Body);
		}
	
		public partial class Builder {
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private Message immutable;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private ImmutableObjectGraph.Optional<Contact.Builder> author;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>.Builder> to;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>.Builder> cc;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private ImmutableObjectGraph.Optional<System.Collections.Immutable.ImmutableList<Contact>.Builder> bcc;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private System.String subject;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private System.String body;
	
			internal Builder(Message immutable) {
				this.immutable = immutable;
	
				this.subject = immutable.Subject;
				this.body = immutable.Body;
			}
	
			public Contact.Builder Author {
				get {
					if (!this.author.IsDefined) {
						this.author = this.immutable.author != null ? this.immutable.author.ToBuilder() : null;
					}
	
					return this.author.Value;
				}
	
				set {
					this.author = value;
				}
			}
	
			public System.Collections.Immutable.ImmutableList<Contact>.Builder To {
				get {
					if (!this.to.IsDefined) {
						this.to = this.immutable.to != null ? this.immutable.to.ToBuilder() : null;
					}
	
					return this.to.Value;
				}
	
				set {
					this.to = value;
				}
			}
	
			public System.Collections.Immutable.ImmutableList<Contact>.Builder Cc {
				get {
					if (!this.cc.IsDefined) {
						this.cc = this.immutable.cc != null ? this.immutable.cc.ToBuilder() : null;
					}
	
					return this.cc.Value;
				}
	
				set {
					this.cc = value;
				}
			}
	
			public System.Collections.Immutable.ImmutableList<Contact>.Builder Bcc {
				get {
					if (!this.bcc.IsDefined) {
						this.bcc = this.immutable.bcc != null ? this.immutable.bcc.ToBuilder() : null;
					}
	
					return this.bcc.Value;
				}
	
				set {
					this.bcc = value;
				}
			}
	
			public System.String Subject {
				get {
					return this.subject;
				}
	
				set {
					this.subject = value;
				}
			}
	
			public System.String Body {
				get {
					return this.body;
				}
	
				set {
					this.body = value;
				}
			}
	
			public Message ToImmutable() {
				var author = this.author.IsDefined ? (this.author.Value != null ? this.author.Value.ToImmutable() : null) : this.immutable.author;
				var to = this.to.IsDefined ? (this.to.Value != null ? this.to.Value.ToImmutable() : null) : this.immutable.to;
				var cc = this.cc.IsDefined ? (this.cc.Value != null ? this.cc.Value.ToImmutable() : null) : this.immutable.cc;
				var bcc = this.bcc.IsDefined ? (this.bcc.Value != null ? this.bcc.Value.ToImmutable() : null) : this.immutable.bcc;
				return this.immutable = this.immutable.With(
					ImmutableObjectGraph.Optional.For(author),
					ImmutableObjectGraph.Optional.For(to),
					ImmutableObjectGraph.Optional.For(cc),
					ImmutableObjectGraph.Optional.For(bcc),
					ImmutableObjectGraph.Optional.For(this.subject),
					ImmutableObjectGraph.Optional.For(this.body));
			}
		}
	
		/// <summary>A struct with all the same fields as the containing type for use in describing default values for new instances of the class.</summary>
		private struct Template {
			internal Contact Author { get; set; }
	
			internal System.Collections.Immutable.ImmutableList<Contact> To { get; set; }
	
			internal System.Collections.Immutable.ImmutableList<Contact> Cc { get; set; }
	
			internal System.Collections.Immutable.ImmutableList<Contact> Bcc { get; set; }
	
			internal System.String Subject { get; set; }
	
			internal System.String Body { get; set; }
		}
	}
	
	public partial class Contact {
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly Contact DefaultInstance = GetDefaultTemplate();
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String name;
	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly System.String email;
	
		/// <summary>Initializes a new instance of the Contact class.</summary>
		private Contact()
		{
		}
	
		/// <summary>Initializes a new instance of the Contact class.</summary>
		private Contact(System.String name, System.String email)
		{
			this.name = name;
			this.email = email;
			this.Validate();
		}
	
		public static Contact Create(
			ImmutableObjectGraph.Optional<System.String> name = default(ImmutableObjectGraph.Optional<System.String>), 
			ImmutableObjectGraph.Optional<System.String> email = default(ImmutableObjectGraph.Optional<System.String>)) {
			return DefaultInstance.With(
				name.IsDefined ? name : ImmutableObjectGraph.Optional.For(DefaultInstance.name), 
				email.IsDefined ? email : ImmutableObjectGraph.Optional.For(DefaultInstance.email));
		}
	
		public System.String Name {
			get { return this.name; }
		}
	
		public Contact WithName(System.String value) {
			if (value == this.Name) {
				return this;
			}
	
			return new Contact(value, this.Email);
		}
	
		public System.String Email {
			get { return this.email; }
		}
	
		public Contact WithEmail(System.String value) {
			if (value == this.Email) {
				return this;
			}
	
			return new Contact(this.Name, value);
		}
	
		/// <summary>Returns a new instance of this object with any number of properties changed.</summary>
		public Contact With(
			ImmutableObjectGraph.Optional<System.String> name = default(ImmutableObjectGraph.Optional<System.String>), 
			ImmutableObjectGraph.Optional<System.String> email = default(ImmutableObjectGraph.Optional<System.String>)) {
			if (
				(name.IsDefined && name.Value != this.Name) || 
				(email.IsDefined && email.Value != this.Email)) {
				return new Contact(
					name.IsDefined ? name.Value : this.Name,
					email.IsDefined ? email.Value : this.Email);
			} else {
				return this;
			}
		}
	
		public Builder ToBuilder() {
			return new Builder(this);
		}
	
		/// <summary>Normalizes and/or validates all properties on this object.</summary>
		/// <exception type="ArgumentException">Thrown if any properties have disallowed values.</exception>
		partial void Validate();
	
		/// <summary>Provides defaults for fields.</summary>
		/// <param name="template">The struct to set default values on.</param>
		static partial void CreateDefaultTemplate(ref Template template);
	
		/// <summary>Returns a newly instantiated Contact whose fields are initialized with default values.</summary>
		private static Contact GetDefaultTemplate() {
			var template = new Template();
			CreateDefaultTemplate(ref template);
			return new Contact(
				template.Name, 
				template.Email);
		}
	
		public partial class Builder {
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private Contact immutable;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private System.String name;
	
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private System.String email;
	
			internal Builder(Contact immutable) {
				this.immutable = immutable;
	
				this.name = immutable.Name;
				this.email = immutable.Email;
			}
	
			public System.String Name {
				get {
					return this.name;
				}
	
				set {
					this.name = value;
				}
			}
	
			public System.String Email {
				get {
					return this.email;
				}
	
				set {
					this.email = value;
				}
			}
	
			public Contact ToImmutable() {
				return this.immutable = this.immutable.With(
					ImmutableObjectGraph.Optional.For(this.name),
					ImmutableObjectGraph.Optional.For(this.email));
			}
		}
	
		/// <summary>A struct with all the same fields as the containing type for use in describing default values for new instances of the class.</summary>
		private struct Template {
			internal System.String Name { get; set; }
	
			internal System.String Email { get; set; }
		}
	}
}

