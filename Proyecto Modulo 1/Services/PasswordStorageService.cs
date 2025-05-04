using Proyecto_Modulo_1.Models;
using Proyecto_Modulo_1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Modulo_1.Services
{
    public class PasswordStorageService : IPasswordStorageService
    {
        private readonly IPasswordRepository _passwordRepository;

        public PasswordStorageService(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        public List<PasswordStorage> ObtenerTodas(int userId)
        {
            return _passwordRepository.GetAll().Where(p => p.UserId == userId).ToList();
        }

        public PasswordStorage ObtenerPorId(int id)
        {
            return _passwordRepository.GetById(id);
        }

        public void Crear(PasswordStorage password)
        {
            if (string.IsNullOrWhiteSpace(password.ServiceName) ||
                string.IsNullOrWhiteSpace(password.ServiceUsername) ||
                string.IsNullOrWhiteSpace(password.ServicePassword))
            {
                throw new ArgumentException("Los campos no pueden estar vacíos.");
            }

            _passwordRepository.Add(password);
        }

        public void Actualizar(PasswordStorage password)
        {
            _passwordRepository.Update(password);
        }

        public void Eliminar(PasswordStorage password)
        {
            _passwordRepository.Delete(password);
        }
    }
}
