using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BanknoteStorage_WcfService
{
    [ServiceContract]
    public interface IBanknoteService
    {
        [OperationContract]
        List<Banknote> GetAllBanknotes();

        [OperationContract]
        int AddBanknote(int value, int count);

        [OperationContract]
        int EditBanknote(int id, int value, int count);

        [OperationContract]
        List<Banknote> GetBanknotesByValue(int value);

        [OperationContract]
        List<Banknote> GetBanknotesByCount(int count);

        [OperationContract]
        Banknote GetBanknoteById(int id);

        [OperationContract]
        void DeleteBanknote(int id);
    }

    [DataContract]
    public class Banknote
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Value { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
