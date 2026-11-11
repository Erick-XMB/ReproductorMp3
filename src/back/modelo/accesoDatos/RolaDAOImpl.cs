using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.modelo.accesoDatos;

/// <summary>
/// Clase que implement la interfaz que define las operaciones de acceso a datos para las rolas 
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

    /// <summary>
    /// Metodo que recupera de la base de datos las rolas que cumplan
    /// con los criterios indicados en los parametros
    /// </summary>
    /// <param name="parametrosBusqueda"> es el objeto que contiene los 
    /// criterios de busqueda a aplicar </param>
    /// <returns> una lista de las rolas que cumplen los criterios de busqueda </returns>
    public List<Rola> GetRolasPorBusquedaAvanzada(ParametrosBusqueda parametrosBusqueda)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT r.id_rola, r.id_performer, r.id_album, r.path, r.title,
                        r.track, r.year, r.genre, 
                        p.id_type, p.name AS performer_name,
                        a.path AS album_path, a.name AS album_name, a.year AS album_year
                        FROM rolas r
                        LEFT JOIN performers p ON r.id_performer = p.id_performer
                        LEFT JOIN albums a ON r.id_album = a.id_album WHERE 1=1";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Titulo))
        {
            sql += " AND r.title LIKE $titulo";
            command.Parameters.AddWithValue("$titulo", "%" + parametrosBusqueda.Titulo + "%");
        }

        if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Artista))
        {
            sql += " AND p.name LIKE $artista";
            command.Parameters.AddWithValue("$artista", "%" + parametrosBusqueda.Artista + "%");
        }

        if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Album))
        {
            sql += " AND a.name LIKE $album";
            command.Parameters.AddWithValue("$album", "%" + parametrosBusqueda.Album + "%");
        }

        if (parametrosBusqueda.Anio.HasValue && parametrosBusqueda.Anio.Value > 0)
        {
            sql += " AND r.year LIKE $anio";
            command.Parameters.AddWithValue("$anio", "%" + parametrosBusqueda.Anio + "%");
        }

        if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Genero))
        {
            sql += " AND r.genre LIKE $genero";
            command.Parameters.AddWithValue("$genero", "%" + parametrosBusqueda.Genero + "%");
        }

        command.CommandText = sql;

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
        Console.WriteLine(sql);
        return rolas;
    }

    /// <summary>
    /// Metodo que recupera las rolas de la base de datos, que contengan
    /// la palabra indicada como parametro
    /// </summary>
    /// <param name="palabra"> es la palabra a buscar en las rolas </param>
    /// <returns> Una lista de las rolas que coinciden con la palabra dada </returns>
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
                        WHERE r.title LIKE $palabra OR a.name LIKE $palabra OR p.name LIKE $palabra OR r.genre LIKE $palabra OR r.year LIKE $palabra
                        OR EXISTS( SELECT 17 FROM groups g JOIN in_group ig ON ig.id_group = g.id_group
                        JOIN persons pe ON pe.id_person = ig.id_person
                        WHERE p.id_type = 1
                            AND g.name = p.name
                            AND(pe.stage_name LIKE $palabra OR pe.real_name LIKE $palabra))";

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
    /// Metodo que actualiza el nombre de una rola en la base de datos
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos actualizar </param>
    /// <param name="title"> es el nuevo nombre que queremos asignar a la rola</param> 
    public void UpdateNombreDeLaRola(int id_rola, string title)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE rolas SET title = $title  WHERE id_rola = $id_rola";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_rola", id_rola);
        command.Parameters.AddWithValue("$title", title);

        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo que actualiza el anio de una rola en la base de datos
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos actualizar </param>
    /// <param name="year"> es el nuevo anio que queremos asignar </param>
    public void UpdateAnioDeLaRola(int id_rola, int year)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE rolas SET year = $year  WHERE id_rola = $id_rola";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_rola", id_rola);
        command.Parameters.AddWithValue("$year", year);

        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo que actualiza el genero de una rola en la base de datos
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos actualizar </param>
    /// <param name="genre"> es el nuevo genero que queremos asignar</param>
    public void UpdateGeneroDeLaRola(int id_rola, string genre)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE rolas SET genre = $genre  WHERE id_rola = $id_rola";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_rola", id_rola);
        command.Parameters.AddWithValue("$genre", genre);

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