using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.modelo.accesoDatos;

/// <summary>
/// Clase que implementa interfaz que define las operaciones de acceso a datos para las persons 
/// </summary>
public class PersonDAOImpl : PersonDAO
{
    /// <summary>
    /// Atributo que representa la conexion a la base de datos
    /// </summary>
    private ConexionBaseDeDatos conexion;

    /// <summary>
    /// Constructor de la clase PersonDAOImpl
    /// </summary>
    /// <param name="conexion"> es la conexion de la base de datos </param>
    public PersonDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    /// <summary>
    /// Metodo que ingresa una persona a la base de datos
    /// </summary>
    /// <param name="person"> es la persona que queremos ingresar </param>
    public bool CreatePerson(Person person)
    {
        if (string.IsNullOrWhiteSpace(person.RealName) || string.IsNullOrWhiteSpace(person.BirthDate) || string.IsNullOrWhiteSpace(person.StageName))
        {
            return false;
        }

        try
        {
            using SqliteConnection conexionAbierta = conexion.CrearConexion();
            conexionAbierta.Open();

            String sql = @"INSERT INTO persons (stage_name, real_name, birth_date, death_date) VALUES ($stage_name, $real_name, $birth_date, $death_date);";

            using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

            command.Parameters.AddWithValue("$stage_name", person.StageName);
            command.Parameters.AddWithValue("$real_name", person.RealName);
            command.Parameters.AddWithValue("$birth_date", person.BirthDate);
            command.Parameters.AddWithValue("$death_date", person.DeathDate);

            command.ExecuteNonQuery();
            return true;
        }
        catch (SqliteException)
        {
            return false;
        }
    }

    /// <summary>
    /// Metodo que devuelve una persona de la base de datos
    /// </summary>
    /// <param name="id_person"> es el id de la persona que queremos recuperar </param>
    /// <returns> La Persona que queramos devolver </returns>
    public Person GetPerson(int id_person)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT * FROM persons WHERE id_person = $id_person";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_person", id_person);

        SqliteDataReader lector = command.ExecuteReader();

        if (lector.Read())
        {
            Person person = new Person(
                Convert.ToInt32(lector["id_person"]),
                lector["stage_name"].ToString()!,
                lector["real_name"].ToString()!,
                lector["birth_date"].ToString()!,
                lector["death_date"].ToString()!
            );

            return person;
        }
        return null!;
    }

    /// <summary>
    /// Metodo que recupera a todas las personas de la base de datos
    /// </summary>
    /// <returns> Una lista con todas las personas que hay en la base de datos </returns>
    public List<Person> ObtenerTodasLasPersonas()
    {
        List<Person> personas = new List<Person>();

        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"SELECT id_person, stage_name, real_name, birth_date, death_date FROM persons ORDER BY stage_name";

        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        using SqliteDataReader lector = command.ExecuteReader();

        while (lector.Read())
        {
            Person person = new Person(
                Convert.ToInt32(lector["id_person"]),
                lector["stage_name"].ToString()!,
                lector["real_name"].ToString()!,
                lector["birth_date"].ToString()!,
                lector["death_date"].ToString()!
            );

            personas.Add(person);
        }

        return personas;
    }

    /// <summary>
    /// Metodo que actualiza una persona de la base de datos
    /// </summary>
    /// <param name="person"> la persona que queremos actualizar </param>
    public void UpdatePerson(Person person)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE persons SET stage_name = $stage_name, real_name = $real_name, birth_date = $birth_date, death_date = $death_date WHERE id_person = $id_person";
        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_person", person.IdPerson);

        command.Parameters.AddWithValue("$stage_name", person.StageName);
        command.Parameters.AddWithValue("$real_name", person.RealName);
        command.Parameters.AddWithValue("birth_date", person.BirthDate);
        command.Parameters.AddWithValue("death_date", person.DeathDate);

        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo que elimina a una persona de la base de datos
    /// </summary>
    /// <param name="id_person"></param>
    public void DeletePerson(int id_person)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"DELETE FROM persons WHERE id_person = $id_person";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_person", id_person);
        command.ExecuteNonQuery();
    }
}