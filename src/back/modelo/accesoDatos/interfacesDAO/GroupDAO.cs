using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;

/// <summary>
/// Interfaz que define las operaciones de acceso a datos para los grupos
/// </summary>
public interface GroupDAO
{
    /// <summary>
    /// Metodo que inserta un grupo a la base de datos
    /// </summary>
    /// <param name="group"> es el grupo que se desea insertar </param>
    public void CreateGroup(Group group);

    /// <summary>
    /// Metodo para obtener un grupo de la base de datos
    /// </summary>
    /// <param name="id_group"> es el id del grupo que deseamos obtener</param>
    /// <returns> el grupo que queriamos recuperar </returns>
    public Group GetGroup(int id_group);

    /// <summary>
    /// Metodo para actualizar un grupo de la base de datos
    /// </summary>
    /// <param name="group"> es el grupo que queremos actualizar</param>
    public void UpdateGroup(Group group);

    /// <summary>
    /// Metodo para elimnar un grupo de la base de datos
    /// </summary>
    /// <param name="id_group"> es el id del grupo que deseamos eliminar </param>
    public void DeleteGroup(int id_group);
    
}   