using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Telefon.Models
{
    public class ListaProdus
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ProductList))]
        public int ShopListID { get; set; }
        public int ProductID { get; set; }
       
    }
}
