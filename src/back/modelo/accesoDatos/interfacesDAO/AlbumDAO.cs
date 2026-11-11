using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;

/// <summary>
/// Interfaz que define las operaciones de acceso a datos para los albumnes
/// </summary>
public interface AlbumDAO
{
    /// <summary>
    /// Metodo que inserta un album a la base de datos
    /// </summary>
    /// <param name="album"> es el album que se desea insertar </param>
    public void CreateAlbum(Album album);

    /// <summary>
    /// Metodo para obtener un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el identificador del album</param>
    /// <returns> el album que queriamos obtener </returns>
    public Album GetAlbum(int id_album);

    /// <summary>
    /// Metodo para obtener un album de la base de datos segun su nombre y ruta
    /// </summary>
    /// <param name="name"> es el nombre del album </param>
    /// <param name="ruta"> es la ruta del album</param>
    /// <returns> el album que queriamos obtener </returns>
    public Album GetAlbumPorNombreYRuta(string name, string ruta);

    /// <summary>
    /// Metodo que recupera a todos las albums de la base de datos
    /// </summary>
    /// <returns> Una lista con todas las albums que hay en la base de datos </returns>
    public List<Album> ObtenerTodasLosAlbums();

    /// <summary>
    /// Metodo para actualizar un album de la base de datos
    /// </summary>
    /// <param name="album"> es el album que deseamos actualizar</param>
    public void UpdateAlbum(Album album);

    /// <summary>
    /// Metodo que actualiza el anio de un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el id del album que deseamos actualizar </param>
    /// <param name="year"> es el nuevo anio que queremos asignar </param>
    public void UpdateAnioDeUnAlbum(int id_album, int year);

    /// <summary>
    /// Metodo para actualizar el nombre de un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el album que deseamos actualizar</param>
    /// <param name="name"> es el nombre que queremos asignar</param>
    public void UpdateNombreDeUnAlbum(int id_album, string name);

    /// <summary>
    /// Metodo para eliminar un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el id del album que deseamos eliminar </param>
    public void DeleteAlbum(int id_album);

}