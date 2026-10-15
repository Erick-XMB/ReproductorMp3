namespace ReproductorMp3.accesoDatos;

using Microsoft.Data.Sqlite;

public class ConexionBaseDeDatos
{
    private string baseDeDatos;
    private static ConexionBaseDeDatos? conexion = null;

    private ConexionBaseDeDatos()
    {
        this.baseDeDatos = "../BaseDeDatos/Reproductor.db";
    }

    public SqliteConnection CrearConexion()
    {
        SqliteConnection? cadena = new SqliteConnection();
        try
        {
            cadena.ConnectionString = "Data Source=" + this.baseDeDatos;
        }
        catch (Exception ex)
        {
            cadena = null;
            throw ex;
        }

        return cadena;
    }

    public static ConexionBaseDeDatos GetInstancia()
    {
        if (conexion == null)
        {
            conexion = new ConexionBaseDeDatos();
        }
        return conexion;
    }
}