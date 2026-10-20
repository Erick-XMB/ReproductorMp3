using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace ReproductorMp3.modelo.accesoDatos;


public class PerformerDAOImpl : PerformerDAO
{
    private ConexionBaseDeDatos conexion;

    public PerformerDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    public void CreatePerformer(Performer performer)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        String sql = @"INSERT INTO performers (id_type, name) VALUES ($id_type, $name);";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_type", performer.IdType);
        command.Parameters.AddWithValue("$name", performer.Name);

        command.ExecuteNonQuery();
    }

    public Performer GetPerformer(int id_performer)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM performers WHERE id_performer = $id_performer";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_performer", id_performer);

        using SqliteDataReader lector = command.ExecuteReader();

        if (lector.Read())
        {
            Performer performer = new Performer(
                Convert.ToInt32(lector["id_performer"]),
                Convert.ToInt32(lector["id_type"]),
                lector["name"].ToString()!
            );

            return performer;
        }
        return null!;
    }


    public Performer GetPerformerPorNombre(string name)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM performers WHERE name = $name";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$name", name);

        using SqliteDataReader lector = command.ExecuteReader();

        if (lector.Read())
        {
            Performer performer = new Performer(
                Convert.ToInt32(lector["id_performer"]),
                Convert.ToInt32(lector["id_type"]),
                lector["name"].ToString()!
            );

            return performer;
        }

        return null!;

    }



    public void UpdatePerformer(Performer performer)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE performers SET id_type = $id_type, name = $name  WHERE id_performer = $id_performer";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_performer", performer.IdPerformer);

        command.Parameters.AddWithValue("$id_type", performer.IdType);
        command.Parameters.AddWithValue("$name", performer.Name);

        command.ExecuteNonQuery();
    }

    public void DeletePerformer(int id_performer)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"DELETE FROM performers WHERE id_performer = $id_performer";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_performer", id_performer);
        command.ExecuteNonQuery();
    }
}