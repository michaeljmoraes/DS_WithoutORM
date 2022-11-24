using Core.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DocumentStorageContext : DbContext, IUnityOfWork
    {

        public DocumentStorageContext(DbContextOptions<DocumentStorageContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //    property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentStorageContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }


        //public async Task<bool> Commit()
        //{
        //    //TODO - Desactive to run Intial Data Seed
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("CreatedAt").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("CreatedAt").IsModified = false;
        //        }
        //    }

        //    return await base.SaveChangesAsync() > 0;

        //}
    }
}
