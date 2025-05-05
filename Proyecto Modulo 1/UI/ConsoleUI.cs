using Proyecto_Modulo_1.Models;

namespace Proyecto_Modulo_1.UI
{
    public static class ConsoleUI
    {
        public static void MostrarMenuPrincipal()
        {
            Console.WriteLine("\nGestor de Contraseñas:");
            Console.WriteLine("1. Ver contraseñas");
            Console.WriteLine("2. Agregar nueva contraseña");
            Console.WriteLine("3. Editar contraseña");
            Console.WriteLine("4. Eliminar contraseña");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }

        public static void MostrarContraseñas(List<PasswordStorage> passwords)
        {
            Console.WriteLine("\n== Contraseñas Guardadas ==");

            if (passwords == null || passwords.Count == 0)
            {
                Console.WriteLine("No hay contraseñas guardadas.");
                return;
            }

            foreach (var p in passwords)
            {
                Console.WriteLine($"ID: {p.Id} | Servicio: {p.ServiceName} | Usuario: {p.ServiceUsername} | Contraseña: {p.ServicePassword}");
            }
        }

        public static PasswordStorage PedirNuevaPassword(int userId)
        {
            Console.Write("Nombre del servicio: ");
            string nombre = Console.ReadLine();

            Console.Write("Usuario del servicio: ");
            string usuario = Console.ReadLine();

            Console.Write("Contraseña del servicio: ");
            string password = Console.ReadLine();

            return new PasswordStorage
            {
                UserId = userId,
                ServiceName = nombre,
                ServiceUsername = usuario,
                ServicePassword = password
            };
        }

        public static int PedirId()
        {
            Console.Write("Ingrese el ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            return id;
        }

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
