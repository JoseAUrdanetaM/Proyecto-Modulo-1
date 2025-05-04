using Proyecto_Modulo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Modulo_1.Repositories
{
    public interface IPasswordRepository : IRepository<PasswordStorage>
    {
        List<PasswordStorage> BuscarPorServicio(string serviceName);
        List<PasswordStorage> ObtenerPorUsuario(int userId); 
    } 
}
