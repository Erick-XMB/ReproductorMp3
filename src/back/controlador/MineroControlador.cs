namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

/// <summary>
/// Clase que representa el controlador del minero 
/// del reproductor de musica
/// </summary>
public class MineroControlador
{
    // Atributo minero de tipo MineroMp3 del modelo
    private MineroMp3 minero;

    // Atributo de tipo PerformerDAO para poder tener acceso a la tabla performers de la bd
    private PerformerDAO performerDAO;

    // Atributo de tipo AlbumDAO para poder tener acceso a la tabla de albums de la base de datos
    private AlbumDAO albumDAO;

    // Atributo de tipo rolaDAO para poder tener acceso a la tabla de rolas de la base de datos
    private RolaDAO rolaDAO;

    /// <summary>
    /// Constructor de la clase MineroControlador
    /// Se destaca la llamada a nuestra ConexionBaseDeDatos para poder tener
    /// siempre la misma conexion
    /// </summary>
    public MineroControlador()
    {
        minero = new MineroMp3();
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        performerDAO = new PerformerDAOImpl(conexionBaseDeDatos);
        albumDAO = new AlbumDAOImpl(conexionBaseDeDatos);
        rolaDAO = new RolaDAOImpl(conexionBaseDeDatos);
    }

    /// <summary>
    /// Metodo privado que dado una ruta nos devuelve una lista
    /// de objetos DatosMp3 con los datos de los mp3 con version valida
    /// </summary>
    /// <param name="ruta"> cadena de la ruta que queremos minar</param>
    /// <returns> Una lista de DatosMp3 con los datos de las rolas validas </returns> 
    private List<DatosMp3> MinarDirectorio(string ruta)
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

    /// <summary>
    /// Metodo que mina y guarda las rolas dada una cadena ruta.
    /// Guardamos datos validos en una lista, y esa lista recorremos cada elemento
    /// para ver si guardamos sus datos
    /// </summary>
    /// <param name="ruta"> es la cadena que representa la ruta que queremos minar </param>
    /// <returns> un entero con el numero de rolas guardadas </returns>
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

    /// <summary>
    /// Metodo privado que dada una cadena "nombre" , revisa si se encuentra
    /// en la base de datos como performer, si lo esta lo devuelve, sino lo crea dento de la db
    /// </summary>
    /// <param name="nombre"> cadena que representa el nombre del performer </param>
    /// <returns> El performer con el nombre de la cadena dada </returns>
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

    /// <summary>
    /// Metodo privado que dada un nombre, ruta y anio, revisa si se encuentra
    /// en la base de datos como album, si lo esta lo devuelve, sino lo crea dento de la db
    /// </summary>
    /// <param name="nombre"> cadena que representa el nombre del album </param>
    /// <param name="ruta"> cadena que representa la ruta del album </param>
    /// <param name="anio">< entero que representa el anio del album /param>
    /// <returns> El album con los datos dados como atributos </returns>
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

    /// <summary>
    /// Metodo provado que dado un objeto de tipo DatosMp3 crea una rola con los atributos
    /// del objeto, esto solo si 
    /// esta rola no se encuentra en la base de datos
    /// </summary>
    /// <param name="datos"> Objeto de tipo Datosmp3 de donde rescataremos la informacion para crear 
    /// la rola </param>
    /// <returns> true si se crea la nueva rola, false si esta ya se encontraba </returns>
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