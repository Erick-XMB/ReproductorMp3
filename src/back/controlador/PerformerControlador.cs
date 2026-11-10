namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

/// <summary>
/// Clase que representa el controlador de los performers
/// del reproductor de musica 
/// </summary>
public class PerformerControlador
{
    // Atributo de tipo PerformerDAO para poder tener acceso a la tabla de performers de la base de datos
    private PerformerDAO performerDAO;

    // Atributo minero de tipo MineroMp3 del modelo
    private MineroMp3 minero = new MineroMp3();

    /// <summary>
    /// Constructor de la clase PerformerControlador
    /// Destacamos llamada a nuestra ConexionBaseDeDatos para
    /// poder tener siempre la misma conexion
    /// </summary> <summary>
    public PerformerControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        performerDAO = new PerformerDAOImpl(conexionBaseDeDatos);
    }

    public Performer? BuscarPerformerPorNombre(string nombre)
    {
        return performerDAO.GetPerformerPorNombre(nombre);
    }

    public void ActualizarTipoDelPerformer(int id_performer, int id_type)
    {
        performerDAO.UpdateTipoDelPerformer(id_performer, id_type);
    }



}