namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

/// <summary>
/// Clase que representa el controlador de los albums
/// del reproductor de musica 
/// </summary>
public class AlbumControlador
{
    // Atributo de tipo ALbumDAO para poder tener acceso a la tabla de grupos de la base de datos
    private AlbumDAO albumDAO;

    // Atributo minero de tipo MineroMp3 del modelo
    private MineroMp3 minero = new MineroMp3();

    /// <summary>
    /// Constructor de la clase AlbumControlador
    /// Destacamos llamada a nuestra ConexionBaseDeDatos para
    /// poder tener siempre la misma conexion
    /// </summary>
    public AlbumControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        albumDAO = new AlbumDAOImpl(conexionBaseDeDatos);
    }

    /// <summary>
    /// Metodo que recupera a todos las albums de la base de datos
    /// </summary>
    /// <returns> Una lista con todas las albums que hay en la base de datos </returns>
    public List<Album> ObtenerTodosLosAlbums()
    {
        return albumDAO.ObtenerTodasLosAlbums();
    }

}