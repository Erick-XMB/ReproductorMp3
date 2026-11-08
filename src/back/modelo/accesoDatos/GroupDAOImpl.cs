using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.modelo.accesoDatos;

/// <summary>
/// Interfaz que define las operaciones de acceso a datos para los grupos 
/// </summary>
public class GroupDAOImpl : GroupDAO
{
    /// <summary>
    /// Atributo que representa la conexion a la base de datos
    /// </summary>
    private ConexionBaseDeDatos conexion;

    /// <summary>
    /// Constructor de la clase GroupDAOImpl
    /// </summary>
    /// <param name="conexion"> es la conexion de la base de datos </param>
    public GroupDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    /// <summary>
    /// Metodo que inserta un grupo a la base de datos
    /// </summary>
    /// <param name="group"> es el grupo que se desea insertar </param>
    public void CreateGroup(Group group)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        String sql = @"INSERT INTO groups (name, start_date, end_date) VALUES ($name, $start_date, $end_date);";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_group", group.IdGroup);
        command.Parameters.AddWithValue("$name", group.Name);
        command.Parameters.AddWithValue("$start_date", group.StartDate);
        command.Parameters.AddWithValue("end_date", group.EndDate);

        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo para obtener un grupo de la base de datos
    /// </summary>
    /// <param name="id_group"> es el id del grupo que deseamos obtener</param>
    /// <returns> el grupo que queriamos recuperar </returns>
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

    /// <summary>
    /// Metodo para actualizar un grupo de la base de datos
    /// </summary>
    /// <param name="group"> es el grupo que queremos actualizar</param>
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

    /// <summary>
    /// Metodo para elimnar un grupo de la base de datos
    /// </summary>
    /// <param name="id_group"> es el id del grupo que deseamos eliminar </param>
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