using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatDat_FoodStore.Models
{
    internal class TransactionModel
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; } // Ăn uống, Nhập hàng, Lương...
        public bool IsIncome { get; set; }   // True: Thu, False: Chi
    }
}
