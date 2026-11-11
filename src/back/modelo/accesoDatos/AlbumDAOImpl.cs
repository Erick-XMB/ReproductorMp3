using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.modelo.accesoDatos;

/// <summary>
/// Clase que implementa la interfaz AlbumDAO 
/// Se encarga de la logica de la tabla Albums de la base de datos
/// </summary> 
public class AlbumDAOImpl : AlbumDAO
{
    /// <summary>
    /// Atributo que representa la conexion a la base de datos
    /// </summary>
    private ConexionBaseDeDatos conexion;

    /// <summary>
    /// Constructor de la clase AlbumDAOImpl
    /// </summary>
    /// <param name="conexion"> es la conexion de la base de datos </param>
    public AlbumDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    /// <summary>
    /// Metodo que inserta un album a la base de datos
    /// </summary>
    /// <param name="album"> es el album que se desea insertar </param>
    public void CreateAlbum(Album album)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        String sql = @"INSERT INTO albums (path, name, year) VALUES ($path, $name, $year);";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$path", album.Path);
        command.Parameters.AddWithValue("$name", album.Name);
        command.Parameters.AddWithValue("$year", album.Year);

        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo para obtener un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el identificador del album</param>
    /// <returns> el album que queriamos obtener </returns>
    public Album GetAlbum(int id_album)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM albums WHERE id_album = $id_album";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_album", id_album);

        using SqliteDataReader lector = command.ExecuteReader();

        if (lector.Read())
        {
            Album album = new Album(
                Convert.ToInt32(lector["id_album"]),
                lector["path"].ToString()!,
                lector["name"].ToString()!,
                Convert.ToInt32(lector["year"])
            );

            return album;
        }
        return null!;
    }

    /// <summary>
    /// Metodo para obtener un album de la base de datos segun su nombre y ruta
    /// </summary>
    /// <param name="name"> es el nombre del album </param>
    /// <param name="ruta"> es la ruta del album</param>
    /// <returns> el album que queriamos obtener </returns>
    public Album GetAlbumPorNombreYRuta(string name, string ruta)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM albums WHERE name = $name AND path = $path";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$path", ruta);


        using SqliteDataReader lector = command.ExecuteReader();

        if (lector.Read())
        {
            Album album = new Album(
                Convert.ToInt32(lector["id_album"]),
                lector["path"].ToString()!,
                lector["name"].ToString()!,
                Convert.ToInt32(lector["year"])
            );

            return album;
        }

        return null!;

    }

    /// <summary>
    /// Metodo que recupera a todos las albums de la base de datos
    /// </summary>
    /// <returns> Una lista con todas las albums que hay en la base de datos </returns>
    public List<Album> ObtenerTodasLosAlbums()
    {
        List<Album> albums = new List<Album>();

        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT id_album, path, name, year FROM albums";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        using SqliteDataReader lector = command.ExecuteReader();

        while (lector.Read())
        {
            Album album = new Album(
                Convert.ToInt32(lector["id_album"]),
                lector["path"].ToString()!,
                lector["name"].ToString()!,
                 Convert.ToInt32(lector["year"])
            );

            albums.Add(album);
        }

        return albums;
    }

    /// <summary>
    /// Metodo para actualizar un album de la base de datos
    /// </summary>
    /// <param name="album"> es el album que deseamos actualizar</param>
    public void UpdateAlbum(Album album)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE albums SET path = $path, name = $name, year = $year WHERE id_album = $id_album";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_album", album.IdAlbum);

        command.Parameters.AddWithValue("$path", album.Path);
        command.Parameters.AddWithValue("$name", album.Name);
        command.Parameters.AddWithValue("$year", album.Year);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo para actualizar el nombre de un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el album que deseamos actualizar</param>
    /// <param name="name"> es el nombre que queremos asignar</param>
    public void UpdateNombreDeUnAlbum(int id_album, string name)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE albums SET name = $name, name = $name WHERE id_album = $id_album";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_album", id_album);
        command.Parameters.AddWithValue("$name", name);

        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo que actualiza el anio de un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el id del album que deseamos actualizar </param>
    /// <param name="year"> es el nuevo anio que queremos asignar </param>
    public void UpdateAnioDeUnAlbum(int id_album, int year)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE albums SET year = $year WHERE id_album = $id_album";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_album", id_album);
        command.Parameters.AddWithValue("$year", year);

        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo para eliminar un album de la base de datos
    /// </summary>
    /// <param name="id_album"> es el id del album que deseamos eliminar </param>
    public void DeleteAlbum(int id_album)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"DELETE FROM albums WHERE id_album = $id_album";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_album", id_album);
        command.ExecuteNonQuery();
    }
}