using TagLib;
using ReproductorMp3.modelo.minero;
using ReproductorMp3.controlador;

string rutaMp3 = "/home/killomanlinux/Documentos/modelado&programacion/musica";

MineroControlador mineroControlador = new MineroControlador();
int rolasGuardadas = mineroControlador.MinarYGuardar(rutaMp3);
Console.WriteLine("Numero de canciones guardadas: " + rolasGuardadas);
