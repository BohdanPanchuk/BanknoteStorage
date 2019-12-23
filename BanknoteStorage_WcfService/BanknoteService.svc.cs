using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;

namespace BanknoteStorage_WcfService
{
    public class Service1 : IBanknoteService
    {
        private BanknoteContext database = new BanknoteContext();

        public void DoWork()
        { }

        public List<Banknote> GetAllBanknotes()
        {
            List<Banknote> banknotesList = new List<Banknote>();
            var banknotesInDatabase = database.BanknoteStorage;

            foreach (Banknote item in banknotesInDatabase)
            {
                Banknote banknote = new Banknote();

                banknote.Id = item.Id;
                banknote.Value = item.Value;
                banknote.Count = item.Count;

                banknotesList.Add(banknote);
            }

            return banknotesList;
        }

        public int AddBanknote(int value, int count)
        {
            Banknote banknote = new Banknote();

            banknote.Value = value;
            banknote.Count = count;

            database.BanknoteStorage.Add(banknote);

            int resultValue = database.SaveChanges();
            return resultValue;
        }

        public int EditBanknote(int id, int value, int count)
        {
            Banknote banknote = new Banknote();

            banknote = database.BanknoteStorage.Where(c => c.Id == id).First();

            banknote.Value = value;
            banknote.Count = count;

            database.Entry(banknote).State = EntityState.Modified;

            int resultValue = database.SaveChanges();

            return resultValue;
        }

        public List<Banknote> GetBanknotesByValue(int value)
        {
            List<Banknote> banknotesList = new List<Banknote>();

            IQueryable<Banknote> banknotesInDatabase = database.BanknoteStorage.Where(c => c.Value == value);

            foreach (Banknote item in banknotesInDatabase)
            {
                Banknote banknote = new Banknote();

                banknote.Id = item.Id;
                banknote.Value = item.Value;
                banknote.Count = item.Count;

                banknotesList.Add(banknote);
            }

            return banknotesList;
        }

        public List<Banknote> GetBanknotesByCount(int count)
        {
            List<Banknote> banknotesList = new List<Banknote>();

            IQueryable<Banknote> banknotesInDatabase = database.BanknoteStorage.Where(c => c.Count == count);

            foreach (Banknote item in banknotesInDatabase)
            {
                Banknote banknote = new Banknote();

                banknote.Id = item.Id;
                banknote.Value = item.Value;
                banknote.Count = item.Count;

                banknotesList.Add(banknote);
            }

            return banknotesList;
        }

        public Banknote GetBanknoteById(int id)
        {
            Banknote banknote = new Banknote();

            banknote = database.BanknoteStorage.Where(c => c.Id == id).First();

            return banknote;
        }

        public void DeleteBanknote(int id)
        {
            Banknote banknote = new Banknote();

            banknote = database.BanknoteStorage.Where(c => c.Id == id).First();

            database.BanknoteStorage.Remove(banknote);

            database.SaveChanges();
        }
    }
}
