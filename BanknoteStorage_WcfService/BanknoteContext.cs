using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BanknoteStorage_WcfService
{
    class BanknoteContextInitializer : DropCreateDatabaseIfModelChanges<BanknoteContext>
    {
        protected override void Seed(BanknoteContext database)
        {
            database.BanknoteStorage.Add(new Banknote { Id = 1, Value = 1, Count = 10 });
            database.BanknoteStorage.Add(new Banknote { Id = 2, Value = 2, Count = 10 });
            database.BanknoteStorage.Add(new Banknote { Id = 3, Value = 5, Count = 10 });
            database.BanknoteStorage.Add(new Banknote { Id = 4, Value = 10, Count = 10 });
            database.BanknoteStorage.Add(new Banknote { Id = 5, Value = 20, Count = 10 });
            database.BanknoteStorage.Add(new Banknote { Id = 6, Value = 50, Count = 10 });
            database.BanknoteStorage.Add(new Banknote { Id = 7, Value = 100, Count = 10 });
            database.BanknoteStorage.Add(new Banknote { Id = 8, Value = 200, Count = 10 });
            database.BanknoteStorage.Add(new Banknote { Id = 9, Value = 500, Count = 10 });

            base.Seed(database);
        }
    }

    public class BanknoteContext : DbContext
    {
        static BanknoteContext()
        {
            Database.SetInitializer(new BanknoteContextInitializer());
        }
        
        public BanknoteContext() : base("BanknoteStorageDatabase")
        { }
        
        public DbSet<Banknote> BanknoteStorage { get; set; }
    }
}