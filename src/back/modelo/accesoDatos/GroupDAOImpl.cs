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

    public List<Group> ObtenerTodoLosGrupos()
    {
        List<Group> grupos = new List<Group>();

        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT id_group, name, start_date, end_date FROM groups ORDER BY name";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        using SqliteDataReader lector = command.ExecuteReader();

        while (lector.Read())
        {
            Group group = new Group(
                Convert.ToInt32(lector["id_group"]),
                lector["name"].ToString()!,
                lector["start_date"].ToString()!,
                lector["end_date"].ToString()!
            );

            grupos.Add(group);
        }

        return grupos;
    }

    public void AgregarIntegrante(int id_person, int id_group)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"INSERT OR IGNORE INTO in_group (id_person, id_group) VALUES ($id_person, $id_group);";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_person", id_person);
        command.Parameters.AddWithValue("$id_group", id_group);
        
        command.ExecuteNonQuery();
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