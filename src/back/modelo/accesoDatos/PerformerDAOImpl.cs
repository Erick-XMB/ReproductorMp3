using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace ReproductorMp3.modelo.accesoDatos;

/// <summary>
/// Interfaz que define las operaciones de acceso a datos para los performers 
/// </summary>
public class PerformerDAOImpl : PerformerDAO
{
    /// <summary>
    /// Atributo que representa la conexion a la base de datos
    /// </summary>
    private ConexionBaseDeDatos conexion;

    /// <summary>
    /// Constructor de la clase PerformerDAOImpl
    /// </summary>
    /// <param name="conexion"> es la conexion de la base de datos </param>
    public PerformerDAOImpl(ConexionBaseDeDatos conexion)
    {
        this.conexion = conexion;
    }

    /// <summary>
    /// Metodo que ingresa un performer a la base de datos
    /// </summary>
    /// <param name="performer"> es el performer que queremos ingresar </param>
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

    /// <summary>
    /// Metodo que nus devuelve un performer de la base de datos
    /// </summary>
    /// <param name="id_performer"> es el id del performer que queremos obtener </param>
    /// <returns> el performer que queriamos recuperar </returns>
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


    /// <summary>
    /// Metood que nos devuelve un performer segun su nombre
    /// </summary>
    /// <param name="name"> es el nombre del performer que queremos obtener </param>
    /// <returns> el performer que queriamos recuperar </returns>
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

    public void UpdateTipoDelPerformer(int id_performer, int id_type)
    {
        using SqliteConnection conexionAbierta = conexion.CrearConexion();
        conexionAbierta.Open();

        string sql = @"UPDATE performers SET id_type = $id_type WHERE id_performer = $id_performer";
        using SqliteCommand command = new SqliteCommand(sql, conexionAbierta);
        command.Parameters.AddWithValue("$id_performer", id_performer);
        command.Parameters.AddWithValue("$id_type", id_type);

        command.ExecuteNonQuery();
    }


    /// <summary>
    /// Metodo que actualiza un performer en la base de datos
    /// </summary>
    /// <param name="performer"> es el performer que queremos actualizar </param>
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

    /// <summary>
    /// Metodo que elimina un performer de la base de datos
    /// </summary>
    /// <param name="id_performer"> es el id del performer que queremos eliminar </param>
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