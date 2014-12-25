﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWordDictionary.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WordManagerEntities : DbContext
    {
        public WordManagerEntities()
            : base("name=WordManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public virtual DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public virtual DbSet<aspnet_Paths> aspnet_Paths { get; set; }
        public virtual DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }
        public virtual DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        public virtual DbSet<aspnet_Profile> aspnet_Profile { get; set; }
        public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public virtual DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
        public virtual DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonDetail> LessonDetail { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
    
        public virtual ObjectResult<Nullable<System.Guid>> aspnet_Membership_CreateUser(string applicationName, string userName, string password, string passwordSalt, string email, string passwordQuestion, string passwordAnswer, Nullable<bool> isApproved, Nullable<System.DateTime> currentTimeUtc, Nullable<System.DateTime> createDate, Nullable<int> uniqueEmail, Nullable<int> passwordFormat, ObjectParameter userId)
        {
            var applicationNameParameter = applicationName != null ?
                new ObjectParameter("ApplicationName", applicationName) :
                new ObjectParameter("ApplicationName", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var passwordSaltParameter = passwordSalt != null ?
                new ObjectParameter("PasswordSalt", passwordSalt) :
                new ObjectParameter("PasswordSalt", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordQuestionParameter = passwordQuestion != null ?
                new ObjectParameter("PasswordQuestion", passwordQuestion) :
                new ObjectParameter("PasswordQuestion", typeof(string));
    
            var passwordAnswerParameter = passwordAnswer != null ?
                new ObjectParameter("PasswordAnswer", passwordAnswer) :
                new ObjectParameter("PasswordAnswer", typeof(string));
    
            var isApprovedParameter = isApproved.HasValue ?
                new ObjectParameter("IsApproved", isApproved) :
                new ObjectParameter("IsApproved", typeof(bool));
    
            var currentTimeUtcParameter = currentTimeUtc.HasValue ?
                new ObjectParameter("CurrentTimeUtc", currentTimeUtc) :
                new ObjectParameter("CurrentTimeUtc", typeof(System.DateTime));
    
            var createDateParameter = createDate.HasValue ?
                new ObjectParameter("CreateDate", createDate) :
                new ObjectParameter("CreateDate", typeof(System.DateTime));
    
            var uniqueEmailParameter = uniqueEmail.HasValue ?
                new ObjectParameter("UniqueEmail", uniqueEmail) :
                new ObjectParameter("UniqueEmail", typeof(int));
    
            var passwordFormatParameter = passwordFormat.HasValue ?
                new ObjectParameter("PasswordFormat", passwordFormat) :
                new ObjectParameter("PasswordFormat", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("aspnet_Membership_CreateUser", applicationNameParameter, userNameParameter, passwordParameter, passwordSaltParameter, emailParameter, passwordQuestionParameter, passwordAnswerParameter, isApprovedParameter, currentTimeUtcParameter, createDateParameter, uniqueEmailParameter, passwordFormatParameter, userId);
        }
    }
}