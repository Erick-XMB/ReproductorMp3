using TagLib;
using ReproductorMp3.modelo.minero;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

string rutaMp3 = "/home/killomanlinux/Documentos/modeladoyprogramacion/musica";

MineroControlador mineroControlador = new MineroControlador();
int rolasGuardadas = mineroControlador.MinarYGuardar(rutaMp3);

RolasControlador rolasControlador = new RolasControlador();
List<Rola> rolas = rolasControlador.ObtenerRolas();

Console.WriteLine("Numero de canciones guardadas: " + rolasGuardadas);

Console.WriteLine("Rolas en la base: " + rolas.Count);
foreach(Rola r in rolas.Take(5))
{
    Console.WriteLine(r.Track + "|" + r.Title + "|" + r.Performer + "|" + r.Album.Name);
}
