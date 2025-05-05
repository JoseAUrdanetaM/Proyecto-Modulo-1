using Proyecto_Modulo_1.Models;
using Proyecto_Modulo_1.Services;

namespace Proyecto_Modulo_1.UI
{

    public class ConsoleUI
    {
        private readonly IPasswordStorageService _passwordService;
        private readonly User _usuario;

        public ConsoleUI(IPasswordStorageService passwordService, User usuario)
        {
            _passwordService = passwordService;
            _usuario = usuario;
        }

        public void Run()
        {
            bool salir = false;

            while (!salir)
            {
                MostrarMenuPrincipal();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        var lista = _passwordService.ObtenerTodas(_usuario.Id);
                        MostrarContraseñas(lista);
                        break;

                    case "2":
                        var nueva = PedirNuevaPassword(_usuario.Id);
                        _passwordService.Crear(nueva);
                        MostrarMensaje("Contraseña agregada correctamente.");
                        break;

                    case "3":
                        int idEditar = PedirId();
                        var existente = _passwordService.ObtenerPorId(idEditar);
                        if (existente == null)
                        {
                            MostrarMensaje("No se encontró la contraseña.");
                            break;
                        }

                        var actualizado = PedirNuevaPassword(_usuario.Id);
                        actualizado.Id = idEditar;
                        _passwordService.Actualizar(actualizado);
                        MostrarMensaje("Contraseña actualizada.");
                        break;

                    case "4":
                        int idEliminar = PedirId();
                        var eliminar = _passwordService.ObtenerPorId(idEliminar);
                        if (eliminar == null)
                        {
                            MostrarMensaje("No se encontró la contraseña.");
                            break;
                        }

                        _passwordService.Eliminar(eliminar);
                        MostrarMensaje("Contraseña eliminada.");
                        break;

                    case "5":
                        Console.Write("Ingrese el nombre del servicio a buscar: ");
                        string servicio = Console.ReadLine();
                        var resultados = _passwordService.BuscarPorServicio(servicio, _usuario.Id);
                        MostrarContraseñas(resultados);
                        break;

                    case "6":
                        MostrarMensaje("Saliendo del sistema...");
                        salir = true;
                        break;

                    default:
                        MostrarMensaje("Opción inválida.");
                        break;
                }
            }
        }
        private void MostrarMenuPrincipal()
        {
            Console.WriteLine("\nGestor de Contraseñas:");
            Console.WriteLine("1. Ver contraseñas");
            Console.WriteLine("2. Agregar nueva contraseña");
            Console.WriteLine("3. Editar contraseña");
            Console.WriteLine("5. Buscar por servicio");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private void MostrarContraseñas(List<PasswordStorage> passwords)
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

        private PasswordStorage PedirNuevaPassword(int userId)
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

        private int PedirId()
        {
            Console.Write("Ingrese el ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            return id;
        }

        private void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
