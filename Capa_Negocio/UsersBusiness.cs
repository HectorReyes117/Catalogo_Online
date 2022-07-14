using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Enitdad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class UsersBusiness
    {
        UsersDB run = new UsersDB();

        public List<Users> show()
        {
            return run.show();
        } 

        public void Insert(Users users)
        {
            run.Insert(users);
        }

        public void Update(Users users)
        {
            run.Update(users);
        }

        public Users Edit(int? id)
        {
            return run.Edit(id);
        }

        public Users Compare(string email,string _password)
        {
            return run.compare(email, _password);
        }


    }
}
