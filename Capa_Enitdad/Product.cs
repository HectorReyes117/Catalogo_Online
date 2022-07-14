using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Enitdad
{
    public class Product
    {
        public int productId { get; set; }
        
        public string productName { get; set; }
        
        public int productPrice { get; set; }
        
        public int categoryId { get; set; }
    }
}
