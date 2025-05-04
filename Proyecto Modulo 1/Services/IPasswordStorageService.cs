using Proyecto_Modulo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Modulo_1.Services
{
    public interface IPasswordStorageService
    {
        List<PasswordStorage> ObtenerTodas(int userId);
        PasswordStorage ObtenerPorId(int id);
        void Crear(PasswordStorage password);
        void Actualizar(PasswordStorage password);
        void Eliminar(PasswordStorage password);
    }
}
