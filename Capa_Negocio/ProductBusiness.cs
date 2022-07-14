using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Enitdad;

namespace Capa_Negocio
{
    public class ProductBusiness:InterfaceCRU<Product>,InterfaceDelete
    {
        ProductDB run = new ProductDB();
        public List<Product> show()
        {
            return run.show();
        }

        public void Insert(Product product)
        {
            run.Insert(product);
        }

        public void Update(Product product)
        {
            run.Update(product);
        }

        public Product Edit(int? id)
        {
            return run.Edit(id);
        }

        public void Delete(int? id)
        {
            run.Delete(id);
        }

        public Product Detail(int? id)
        {
            return run.Edit(id);
        }

        public Product deleteId(int? id)
        {
            return run.Edit(id);
        }
    }
}
