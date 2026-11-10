using TagLib;
using ReproductorMp3.modelo.minero;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

public class Program
{
    public static void Main()
    {
        MineroControlador mineroControlador = new MineroControlador();
        Console.WriteLine("Ingresa la ruta que quieres minar:");
        string rutaMp3 = Console.ReadLine()!;

        try
        {
            int rolasGuardadas = mineroControlador.MinarYGuardar(rutaMp3);
            Console.WriteLine("Minaste un total de: " + rolasGuardadas + " canciones");
        }
        catch (Exception)
        {
            Console.WriteLine("Ruta no valida");
        }
    }
}




