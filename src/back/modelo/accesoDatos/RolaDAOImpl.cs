using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.modelo.accesoDatos;


public class RolaDAOImpl : RolaDAO
{
    private ConexionBaseDeDatos conexion;

    public RolaDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    public void CreateRola(Rola rola)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        String sql = @"INSERT INTO rolas (id_performer, id_album, path, title, track, year, genre) VALUES ($id_performer, $id_album, $path, $title, $track, $year, $genre);";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_performer", rola.Performer.IdPerformer);
        command.Parameters.AddWithValue("$id_album", rola.Album.IdAlbum);
        command.Parameters.AddWithValue("$path", rola.Path);
        command.Parameters.AddWithValue("$title", rola.Title);
        command.Parameters.AddWithValue("$track", rola.Track);
        command.Parameters.AddWithValue("$year", rola.Year);
        command.Parameters.AddWithValue("$genre", rola.Genre);

        command.ExecuteNonQuery();
    }

    public Rola GetRola(int id_rola)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM rolas WHERE id_rola = $id_rola";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_rola", id_rola);

        SqliteDataReader lector = command.ExecuteReader();

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

    public Rola GetRolaPorRuta(string path)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM rolas WHERE path = $path";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$path", path);

        SqliteDataReader lector = command.ExecuteReader();

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

    public void UpdateRola(Rola rola)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE rolas SET id_performer = $id_performer, id_album = $id_album, path = $path, title = $title, track = $track, year = $year, genre = $genre WHERE id_rola = $id_rola";
        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

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

    public void DeleteRola(int id_rola)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"DELETE FROM rolas WHERE id_rola = $id_rola";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_rola", id_rola);
        command.ExecuteNonQuery();
    }
}