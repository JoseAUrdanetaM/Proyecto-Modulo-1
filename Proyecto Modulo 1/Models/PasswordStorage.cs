using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Modulo_1.Models
{
    public class PasswordStorage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceUsername { get; set; }
        public string ServicePassword { get; set; }

    }
}
