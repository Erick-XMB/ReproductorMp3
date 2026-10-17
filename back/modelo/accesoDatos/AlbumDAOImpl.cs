using ReproductorMp3.modelo;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.accesoDatos;


public class AlbumDAOImpl : AlbumDAO
{
    private ConexionBaseDeDatos conexion;

    public AlbumDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    public void CreateAlbum(Album album)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        String sql = @"INSERT INTO albums (id_album, path, name, year) VALUES ($id_album, $path, $name, $year);";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_album", album.IdAlbum);
        command.Parameters.AddWithValue("$path", album.Path);
        command.Parameters.AddWithValue("name", album.Name);
        command.Parameters.AddWithValue("year", album.Year);

        command.ExecuteNonQuery();
    }

    public Album GetAlbum(int id_album)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM albums WHERE id_album = $id_album";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_album", id_album);

        SqliteDataReader lector = command.ExecuteReader();

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

    public void UpdateAlbum(Album album)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE groups SET path = $path, name = $name, year = $year WHERE id_album = $id_album";
        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_album", album.IdAlbum);

        command.Parameters.AddWithValue("$path", album.Path);
        command.Parameters.AddWithValue("name", album.Name);
        command.Parameters.AddWithValue("year", album.Year);
        command.ExecuteNonQuery();
    }

    public void DeleteAlbum(int id_album)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"DELETE FROM albums WHERE id_album = $id_album";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_album", id_album);
        command.ExecuteNonQuery();
    }
}