using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanknoteStorage_MVC.Models
{
    public class Banknote
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
    }
}