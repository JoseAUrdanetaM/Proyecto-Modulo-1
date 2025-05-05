using Proyecto_Modulo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Modulo_1.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {

        private List<PasswordStorage> _passwords = new List<PasswordStorage>();
        private int _nextId = 1;
        public List<PasswordStorage> GetAll()
        {
            return _passwords;
        }
        public PasswordStorage GetById(int id)
        {
            return _passwords.FirstOrDefault(x => x.Id == id);
        }
        public void Add(PasswordStorage entity)
        {
            entity.Id = _nextId++;
            _passwords.Add(entity);
        }
        public void Update(PasswordStorage entity)
        {
            var index = _passwords.FindIndex(x => x.Id == entity.Id);

            if (index != -1)
            {
                _passwords[index] = entity;
            }
        }
        public void Delete(PasswordStorage entity)
        {
            _passwords.Remove(entity);
        }
        public List<PasswordStorage> BuscarPorServicio(string serviceName)
        {
            return _passwords.Where(p => p.ServiceName.Contains(serviceName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
