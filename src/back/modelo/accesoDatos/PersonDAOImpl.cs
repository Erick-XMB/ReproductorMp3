using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;

namespace ReproductorMp3.modelo.accesoDatos;


public class PersonDAOImpl : PersonDAO
{
    private ConexionBaseDeDatos conexion;

    public PersonDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    public void CreatePerson(Person person)
    {
        SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        String sql = @"INSERT INTO persons (id_person, stage_name, real_name, birth_date, death_name) VALUES ($id_person, $stage_name, $real_name, $birth_date, $death_date);";

        SqliteCommand command = new SqliteCommand(sql, conexionAbierta);

        command.Parameters.AddWithValue("$id_person", person.IdPerson);
        command.Parameters.AddWithValue("$stage_name", person.StageName);
        command.Parameters.AddWithValue("$real_name", person.RealName);
        command.Parameters.AddWithValue("birth_date", person.BirthDate);
        command.Parameters.AddWithValue("death_date", person.DeathDate);

        command.ExecuteNonQuery();
    }

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