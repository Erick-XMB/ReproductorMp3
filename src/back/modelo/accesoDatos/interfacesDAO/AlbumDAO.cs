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
    /// Metodo para actualizar un album de la base de datos
    /// </summary>
    /// <param name="album"> es el album que deseamos actualizar</param>
    public void UpdateAlbum(Album album);

    /// <summary>
    /// Metodo para eliminar un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el id del album que deseamos eliminar </param>
    public void DeleteAlbum(int id_album);

}