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
    /// </summary>
    public PerformerControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        performerDAO = new PerformerDAOImpl(conexionBaseDeDatos);
    }

    /// <summary>
    /// Metood que nos devuelve un performer segun su nombre
    /// </summary>
    /// <param name="name"> es el nombre del performer que queremos obtener </param>
    /// <returns> el performer que queriamos recuperar </returns>
    public Performer? BuscarPerformerPorNombre(string nombre)
    {
        return performerDAO.GetPerformerPorNombre(nombre);
    }

    /// <summary>
    /// Metodo que actualiza el tipo de un performer en la base de datos
    /// </summary>
    /// <param name="id_performer"> es el id del performer que queremos actualizar </param>
    /// <param name="id_type"> es el tipo que queremos asignar </param>
    public void ActualizarTipoDelPerformer(int id_performer, int id_type)
    {
        performerDAO.UpdateTipoDelPerformer(id_performer, id_type);
    }



}