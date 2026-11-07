using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.modelo.accesoDatos;

/// </sumary>
/// Interfaz que define las operaciones de acceso a datos para las rolas 
/// </summary>
public class RolaDAOImpl : RolaDAO
{
    /// <summary>
    /// Atributo que representa la conexion a la base de datos
    /// </summary>
    private ConexionBaseDeDatos conexion;

    /// <summary>
    /// Constructor de la clase RolaDAOImpl
    /// </summary>
    /// <param name="conexion"> es la conexion de la base de datos </param>
    public RolaDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    /// <summary>
    /// Metodo que ingresa una rola a la base de datos
    /// </summary>
    /// <param name="rola"> es la rola que queremos ingresar </param>
    public void CreateRola(Rola rola)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        String sql = @"INSERT INTO rolas (id_performer, id_album, path, title, track, year, genre) VALUES ($id_performer, $id_album, $path, $title, $track, $year, $genre);";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_performer", rola.Performer.IdPerformer);
        command.Parameters.AddWithValue("$id_album", rola.Album.IdAlbum);
        command.Parameters.AddWithValue("$path", rola.Path);
        command.Parameters.AddWithValue("$title", rola.Title);
        command.Parameters.AddWithValue("$track", rola.Track);
        command.Parameters.AddWithValue("$year", rola.Year);
        command.Parameters.AddWithValue("$genre", rola.Genre);

        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo que recupera una rola de la base de datos
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos recuperar </param>
    /// <returns> la rola que queriamos obtener </returns>
    public Rola GetRola(int id_rola)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM rolas WHERE id_rola = $id_rola";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_rola", id_rola);

        using SqliteDataReader lector = command.ExecuteReader();

        if (lector.Read())
        {
            int IdPerformer = Convert.ToInt32(lector["id_performer"]);
            Performer performer = new Performer(IdPerformer);

            int IdAlbum = Convert.ToInt32(lector["id_album"]);
            Album album = new Album(IdAlbum);

            Rola rola = new Rola(
                Convert.ToInt32(lector["id_rola"]),
                album,
                performer,
                lector["path"].ToString()!,
                lector["title"].ToString()!,
                Convert.ToInt32(lector["track"]),
                Convert.ToInt32(lector["year"]),
                lector["genre"].ToString()!
            );

            return rola;
        }
        return null!;
    }

    /// <summary>
    /// Metood que recupera una rola de la base de datos por su ruta
    /// </summary>
    /// <param name="ruta"> es la ruta de la rola </param>
    /// <returns> la rola que queriamos recuperar </returns>
    public Rola GetRolaPorRuta(string ruta)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM rolas WHERE path = $path";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$path", ruta);

        using SqliteDataReader lector = command.ExecuteReader();

        if (lector.Read())
        {
            int IdPerformer = Convert.ToInt32(lector["id_performer"]);
            Performer performer = new Performer(IdPerformer);

            int IdAlbum = Convert.ToInt32(lector["id_album"]);
            Album album = new Album(IdAlbum);

            Rola rola = new Rola(
                Convert.ToInt32(lector["id_rola"]),
                album,
                performer,
                lector["path"].ToString()!,
                lector["title"].ToString()!,
                Convert.ToInt32(lector["track"]),
                Convert.ToInt32(lector["year"]),
                lector["genre"].ToString()!
            );

            return rola;
        }
        return null!;
    }


    public List<Rola> GetRolasPorPalabra(string palabra)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT r.id_rola, r.id_performer, r.id_album, r.path, r.title, r.track, r.year, r.genre,
                        p.id_type, p.name AS performer_name,
                        a.path AS album_path, a.name AS album_name, a.year AS album_year
                        FROM rolas r
                        LEFT JOIN performers p ON p.id_performer = r.id_performer
                        LEFT JOIN albums a ON a.id_album = r.id_album
                        WHERE r.title LIKE $palabra";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$palabra", "%" + palabra + "%");

        using SqliteDataReader lector = command.ExecuteReader();

        List<Rola> rolas = new List<Rola>();

        while (lector.Read())
        {
            Performer performer = new Performer(
                Convert.ToInt32(lector["id_performer"]),
                lector["id_type"] is DBNull ? 2 : Convert.ToInt32(lector["id_type"]),
                lector["performer_name"] is DBNull ? "" : lector["performer_name"].ToString()!
            );

            Album album = new Album(
                Convert.ToInt32(lector["id_album"]),
                lector["album_path"] is DBNull ? "" : lector["album_path"].ToString()!,
                lector["album_name"] is DBNull ? "" : lector["album_name"].ToString()!,
                lector["album_year"] is DBNull ? 0 : Convert.ToInt32(lector["album_year"])
            );

            rolas.Add(new Rola(
            Convert.ToInt32(lector["id_rola"]),
            album,
            performer,
            lector["path"].ToString()!,
            lector["title"].ToString()!,
            Convert.ToInt32(lector["track"]),
            Convert.ToInt32(lector["year"]),
            lector["genre"].ToString()!));
        }

        return rolas;
    }

    /// <summary>
    /// Metodo que deuvelve todas las rolas de la base de datos
    /// </summary>
    /// <returns> la lista de todas las rolas </returns>
    public List<Rola> GetTodasLasRolas()
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT r.id_rola, r.id_performer, r.id_album, r.path, r.title,
                        r.track, r.year, r.genre, 
                        p.id_type, p.name AS performer_name,
                        a.path AS album_path, a.name AS album_name, a.year AS album_year
                        FROM rolas r
                        LEFT JOIN performers p ON r.id_performer = p.id_performer
                        LEFT JOIN albums a ON r.id_album = a.id_album";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        using SqliteDataReader lector = command.ExecuteReader();

        List<Rola> rolas = new List<Rola>();

        while (lector.Read())
        {
            Performer performer = new Performer(
                Convert.ToInt32(lector["id_performer"]),
                lector["id_type"] is DBNull ? 2 : Convert.ToInt32(lector["id_type"]),
                lector["performer_name"] is DBNull ? "" : lector["performer_name"].ToString()!
            );

            Album album = new Album(
                Convert.ToInt32(lector["id_album"]),
                lector["album_path"] is DBNull ? "" : lector["album_path"].ToString()!,
                lector["album_name"] is DBNull ? "" : lector["album_name"].ToString()!,
                lector["album_year"] is DBNull ? 0 : Convert.ToInt32(lector["album_year"])
            );

            rolas.Add(new Rola(
            Convert.ToInt32(lector["id_rola"]),
            album,
            performer,
            lector["path"].ToString()!,
            lector["title"].ToString()!,
            Convert.ToInt32(lector["track"]),
            Convert.ToInt32(lector["year"]),
            lector["genre"].ToString()!));
        }
        return rolas;
    }

    /// <summary>
    /// Metood que actualiza una rola de la base de datos
    /// </summary>
    /// <param name="rola"> es la rola que queremos actualizar </param>
    public void UpdateRola(Rola rola)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE rolas SET id_performer = $id_performer, id_album = $id_album, path = $path, title = $title, track = $track, year = $year, genre = $genre WHERE id_rola = $id_rola";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_rola", rola.IdRola);
        command.Parameters.AddWithValue("$id_performer", rola.Performer.IdPerformer);
        command.Parameters.AddWithValue("$id_album", rola.Album.IdAlbum);
        command.Parameters.AddWithValue("$path", rola.Path);
        command.Parameters.AddWithValue("$title", rola.Title);
        command.Parameters.AddWithValue("$track", rola.Track);
        command.Parameters.AddWithValue("$year", rola.Year);
        command.Parameters.AddWithValue("$genre", rola.Genre);

        command.ExecuteNonQuery();

    }

    /// <summary>
    /// Metodo que elimina una rola de la base de datos
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos eliminar </param>
    public void DeleteRola(int id_rola)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"DELETE FROM rolas WHERE id_rola = $id_rola";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_rola", id_rola);
        command.ExecuteNonQuery();
    }
}