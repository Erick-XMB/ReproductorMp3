using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.modelo.accesoDatos;


public class AlbumDAOImpl : AlbumDAO
{
    private ConexionBaseDeDatos conexion;

    public AlbumDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

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