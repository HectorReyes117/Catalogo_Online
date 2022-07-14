using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Enitdad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CategoriesBusiness:InterfaceCRU<Categories>,InterfaceDelete
    {
        CategoriesDB run = new CategoriesDB();
        public List<Categories> show()
        {
            return run.show();
        }
        public void Insert(Categories categories)
        {
            run.Insert(categories);
        }

        public void Update(Categories categories)
        {
            run.Update(categories); 
        }

        public Categories Edit(int? id)
        {
            return run.Edit(id);
        }
        public void Delete(int? id)
        {
            run.Delete(id);  
        }

        public Categories deleteId(int? id)
        {
            return run.Edit(id);
        }     
    }
}
