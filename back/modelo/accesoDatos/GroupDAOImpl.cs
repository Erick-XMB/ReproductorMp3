using ReproductorMp3.modelo;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.accesoDatos;


public class GroupDAOImpl : GroupDAO
{
    private ConexionBaseDeDatos conexion;

    public GroupDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    public void CreateGroup(Group group)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        String sql = @"INSERT INTO groups (id_group, name, start_date, end_date) VALUES ($id_group, $name, $start_date, $end_date);";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_group", group.IdGroup);
        command.Parameters.AddWithValue("$name", group.Name);
        command.Parameters.AddWithValue("$start_date", group.StartDate);
        command.Parameters.AddWithValue("end_date", group.EndDate);

        command.ExecuteNonQuery();
    }

    public Group GetGroup(int id_group)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM groups WHERE id_group = $id_group";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_group", id_group);

        SqliteDataReader lector = command.ExecuteReader();

        if (lector.Read())
        {
            Group group = new Group(
                Convert.ToInt32(lector["id_group"]),
                lector["name"].ToString()!,
                lector["start_date"].ToString()!,
                lector["end_date"].ToString()!
            );

            return group;
        }
        return null!;
    }

    public void UpdateGroup(Group group)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE groups SET name = $name, start_date = $start_date, end_date = $end_date WHERE id_group = $id_group";
        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_group", group.IdGroup);

        command.Parameters.AddWithValue("$name", group.Name);
        command.Parameters.AddWithValue("$start_date", group.StartDate);
        command.Parameters.AddWithValue("end_date", group.EndDate);

        command.ExecuteNonQuery();
    }

    public void DeleteGroup(int id_group)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"DELETE FROM groups WHERE id_group = $id_group";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_group", id_group);
        command.ExecuteNonQuery();
    }
}