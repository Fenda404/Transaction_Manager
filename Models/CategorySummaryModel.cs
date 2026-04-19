using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatDat_FoodStore.Models
{
    internal class CategorySummaryModel
    {
        public string CategoryName { get; set; }
        public double TotalAmount { get; set; }
        public double Percentage { get; set; }
    }
}
