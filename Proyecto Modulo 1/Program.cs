using Proyecto_Modulo_1.Models;
using Proyecto_Modulo_1.Repositories;
using Proyecto_Modulo_1.Services;
using Proyecto_Modulo_1.UI;

class Program
{
    static void Main(string[] args)
    {
        // Usuario hardcodeado
        var usuario = new User
        {
            Id = 1,
            Username = "admin",
            Password = "1234",
            Email = "admin@mail.com",
            PhoneNumber = "123456789"
        };

        Console.Write("Usuario: ");
        string inputUser = Console.ReadLine();
        Console.Write("Contraseña: ");
        string inputPass = Console.ReadLine();

        if (!usuario.Autenticar(inputUser, inputPass))
        {
            Console.WriteLine("Usuario o contraseña incorrectos.");
            return;
        }

        Console.WriteLine("\n¡Bienvenido!");

        // Inyectar dependencias manualmente
        var passwordRepository = new PasswordRepository(); // Aquí puedes cambiar a una implementación real
        var passwordService = new PasswordStorageService(passwordRepository);

        bool salir = false;
        while (!salir)
        {
            ConsoleUI.MostrarMenuPrincipal();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    var lista = passwordService.ObtenerTodas(usuario.Id);
                    ConsoleUI.MostrarContraseñas(lista);
                    break;

                case "2":
                    var nueva = ConsoleUI.PedirNuevaPassword(usuario.Id);
                    passwordService.Crear(nueva);
                    ConsoleUI.MostrarMensaje("Contraseña agregada correctamente.");
                    break;

                case "3":
                    int idEditar = ConsoleUI.PedirId();
                    var existente = passwordService.ObtenerPorId(idEditar);
                    if (existente == null)
                    {
                        ConsoleUI.MostrarMensaje("No se encontró la contraseña.");
                        break;
                    }

                    var actualizado = ConsoleUI.PedirNuevaPassword(usuario.Id);
                    actualizado.Id = idEditar;
                    passwordService.Actualizar(actualizado);
                    ConsoleUI.MostrarMensaje("Contraseña actualizada.");
                    break;

                case "4":
                    int idEliminar = ConsoleUI.PedirId();
                    var eliminar = passwordService.ObtenerPorId(idEliminar);
                    if (eliminar == null)
                    {
                        ConsoleUI.MostrarMensaje("No se encontró la contraseña.");
                        break;
                    }

                    passwordService.Eliminar(eliminar);
                    ConsoleUI.MostrarMensaje("Contraseña eliminada.");
                    break;

                case "5":
                    ConsoleUI.MostrarMensaje("Saliendo...");
                    salir = true;
                    break;

                default:
                    ConsoleUI.MostrarMensaje("Opción inválida.");
                    break;
            }
        }
    }
}
