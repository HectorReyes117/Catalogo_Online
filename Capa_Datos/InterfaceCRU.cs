using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public interface InterfaceCRU<TEntidad>
    {
        List<TEntidad> show();
        void Insert(TEntidad entidad);
        void Update(TEntidad entidad);
        TEntidad Edit(int? id);
    }
}
