﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ilac_etkilesimleri.Models;

namespace ilac_etkilesimleri.DAL
{
    public abstract class EFContextSettings : IdentityDbContext<ApplicationUser>
    {
        static EFContextSettings()
        {
            //using (var context = new EFContext())
            //{
            //    context.Database.Delete();
            //    context.Database.Create();
            //}
        }
        //public EFContextSettings() : base("name=" + DatabaseConnection.Name())
        //{
        //    // Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFContext>());
        //    Database.SetInitializer(new DatabaseInitializer());
        //}
        public EFContextSettings() : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TingoonDbContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TingoonDbContext>());
            Database.SetInitializer(new EFDatabaseInitializer());
        }
        public static TingoonDbContext Create() { return new TingoonDbContext(); }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //veri tabanında oluşturulan tabloların sonuna otomatik gelen "s" takısının eklenmesini engeller
        //  protected override void OnModelCreating(DbModelBuilder modelBuilder) { modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>(); }
        public override int SaveChanges()
        {
            return base.SaveChanges();
            //    try
            //    {
            //        return base.SaveChanges();
            //    }
            //    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            //    {
            //        // Retrieve the error messages as a list of strings.
            //        var errorMessages = ex.EntityValidationErrors
            //        .SelectMany(x => x.ValidationErrors)
            //        .Select(x => x.ErrorMessage);

            //        // Join the list to a single string.
            //        var fullErrorMessage = string.Join("; ", errorMessages);

            //        // Combine the original exception message with the new one.
            //        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

            //        // Throw a new DbEntityValidationException with the improved exception message.
            //        throw new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            //    }
        }
    }
}