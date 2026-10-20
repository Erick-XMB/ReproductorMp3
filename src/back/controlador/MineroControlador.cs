namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

public class MineroControlador
{
    private MineroMp3 minero;

    private PerformerDAO performerDAO;

    private AlbumDAO albumDAO;

    private RolaDAO rolaDAO;

    public MineroControlador()
    {
        minero = new MineroMp3();
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        performerDAO = new PerformerDAOImpl(conexionBaseDeDatos);
        albumDAO = new AlbumDAOImpl(conexionBaseDeDatos);
        rolaDAO = new RolaDAOImpl(conexionBaseDeDatos);
    }

    public List<DatosMp3> MinarDirectorio(string ruta)
    {
        List<DatosMp3> datosEncontrados = minero.MinarDirectorio(ruta);
        List<DatosMp3> datosValidos = new List<DatosMp3>();

        foreach (DatosMp3 datos in datosEncontrados)
        {
            if (minero.VerificarVersionId3(datos))
            {
                datosValidos.Add(datos);
            }
        }
        return datosValidos;
    }

    public int MinarYGuardar(string ruta)
    {
        List<DatosMp3> datosValidos = MinarDirectorio(ruta);
        int guardados = 0;

        foreach (DatosMp3 datos in datosValidos)
        {
            try
            {
                if (GuardarDatos(datos))
                {
                    guardados++;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        return guardados;
    }

    private Performer ObtenerOCrearPerformer(string nombre)
    {
        Performer performer = performerDAO.GetPerformerPorNombre(nombre);

        if (performer == null)
        {
            performerDAO.CreatePerformer(new Performer(0, 2, nombre));
            performer = performerDAO.GetPerformerPorNombre(nombre);
        }

        return performer;
    }

    private Album ObtenerOCrearAlbum(string nombre, string ruta, int anio)
    {
        string rutaAlbum = Path.GetDirectoryName(ruta)!;
        Album album = albumDAO.GetAlbumPorNombreYRuta(nombre, rutaAlbum);

        if (album == null)
        {
            albumDAO.CreateAlbum(new Album(0, rutaAlbum, nombre, anio));
            album = albumDAO.GetAlbumPorNombreYRuta(nombre, rutaAlbum);
        }
        return album;
    }

    private bool GuardarDatos(DatosMp3 datos)
    {
        if (rolaDAO.GetRolaPorRuta(datos.Ruta) != null)
        {
            return false;
        }

        Performer performer = ObtenerOCrearPerformer(datos.Artista ?? "Unknown");

        Album album;

        if (string.IsNullOrWhiteSpace(datos.Album))
        {
            album = albumDAO.GetAlbum(0);
        }
        else
        {
            album = ObtenerOCrearAlbum(datos.Album, datos.Ruta, (int)datos.Anio);
        }

        string titulo = datos.Titulo ?? "Unknown";
        string genero = datos.Generos[0];

        Rola rola = new Rola(0, album, performer, datos.Ruta, titulo!, (int)datos.Track, (int)datos.Anio, genero);
        rolaDAO.CreateRola(rola);
        return true;
    }
}