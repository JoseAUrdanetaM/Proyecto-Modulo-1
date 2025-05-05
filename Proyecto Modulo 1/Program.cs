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

        // Autenticación básica
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

        // Inyección de dependencias
        var passwordService = new PasswordStorageService(new PasswordRepository());

        // Iniciar UI
        var ui = new ConsoleUI(passwordService, usuario);
        ui.Run();
    }
}
