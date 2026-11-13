using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;

/// <summary>
/// Interfaz que define las operaciones de acceso a datos para los perfomers
/// </summary>
public interface PerformerDAO
{
    /// <summary>
    /// Metodo que ingresa un performer a la base de datos
    /// </summary>
    /// <param name="performer"> es el performer que queremos ingresar </param>
    public void CreatePerformer(Performer performer);

    /// <summary>
    /// Metodo que nus devuelve un performer de la base de datos
    /// </summary>
    /// <param name="id_performer"> es el id del performer que queremos obtener </param>
    /// <returns> el performer que queriamos recuperar </returns>
    public Performer GetPerformer(int id_performer);

    /// <summary>
    /// Metood que nos devuelve un performer segun su nombre
    /// </summary>
    /// <param name="name"> es el nombre del performer que queremos obtener </param>
    /// <returns> el performer que queriamos recuperar </returns>
    public Performer GetPerformerPorNombre(string name);

    /// <summary>
    /// Metodo que recupera a todas las performers de la base de datos
    /// </summary>
    /// <returns> Una lista con todas las performers que hay en la base de datos </returns>
    public List<Performer> ObtenerTodosLosPerformers();

    /// <summary>
    /// Metodo que actualiza el tipo de un performer en la base de datos
    /// </summary>
    /// <param name="id_performer"> es el id del performer que queremos actualizar </param>
    /// <param name="id_type"> es el tipo que queremos asignar </param>
    public void UpdateTipoDelPerformer(int id_performer, int id_type);

    /// <summary>
    /// Metodo que actualiza un performer en la base de datos
    /// </summary>
    /// <param name="performer"> es el performer que queremos actualizar </param>
    public void UpdatePerformer(Performer performer);

    /// <summary>
    /// Metodo que elimina un performer de la base de datos
    /// </summary>
    /// <param name="id_performer"> es el id del performer que queremos eliminar </param>
    public void DeletePerformer(int id_performer);

}