namespace ReproductorMp3.modelo.accesoDatos;

using Microsoft.Data.Sqlite;

/// <summary>
/// Clase que implementa el Patron de disenio "Singleton"
/// Es la clase mediante entablaremos la conexion que tendremos a nuestra base de datos
/// </summary>
public class ConexionBaseDeDatos
{   
    //Atributo que representa la cadena de la ruta de la base de datos
    private string baseDeDatos;

    // Es la instancia unica de la clase 
    private static ConexionBaseDeDatos? conexion = null;

    /// <summary>
    /// Constructor privado de la clase, para que no se creen instancias desde
    /// otra clase 
    /// </summary>
    private ConexionBaseDeDatos()
    {
        string carpetaLocalShare = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string carpetaReproductor = Path.Combine(carpetaLocalShare, "ReproductorMp3");

        Directory.CreateDirectory(carpetaReproductor);

        this.baseDeDatos = Path.Combine(carpetaReproductor, "Reproductor.db");

        bool esNuevaLaBase = !File.Exists(this.baseDeDatos);

        if (esNuevaLaBase)
        {
            CrearTablasEnLaBaseDeDatos();
        }
    }

    /// <summary>
    /// Metodo que ejeucta rolas.sql sobre una base nueva para poder
    /// crear las tablas y los datos de inicio
    /// </summary>
    private void CrearTablasEnLaBaseDeDatos()
    {
        string rutaEsquema = Path.Combine(AppContext.BaseDirectory, "rolas.sql");
        string contenidoEsquema = File.ReadAllText(rutaEsquema);

        using SqliteConnection conexionBaseDeDatos = CrearConexion();
        conexionBaseDeDatos.Open();

        using SqliteCommand comandoCrearTablas = conexionBaseDeDatos.CreateCommand();
        comandoCrearTablas.CommandText = contenidoEsquema;
        comandoCrearTablas.ExecuteNonQuery();
    }

    /// <summary>
    /// Metodo que crea una conexion nueva hacia la base de datos
    /// </summary>
    /// <returns></returns>
    public SqliteConnection CrearConexion()
    {
        SqliteConnection? cadena = new SqliteConnection();
        try
        {
            cadena.ConnectionString = "Data Source=" + this.baseDeDatos;
        }
        catch (Exception)
        {
            cadena = null;
            throw;
        }

        return cadena;
    }

    /// <summary>
    /// Metodo que devuelve la unica instancia de la conexion, 
    /// La primera vez la crea, despues solo la devuelve.
    /// </summary>
    /// <returns></returns>
    public static ConexionBaseDeDatos GetInstancia()
    {
        if (conexion == null)
        {
            conexion = new ConexionBaseDeDatos();
        }
        return conexion;
    }
}