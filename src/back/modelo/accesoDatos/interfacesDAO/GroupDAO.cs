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
    public bool CreateGroup(Group group);

    /// <summary>
    /// Metodo para obtener un grupo de la base de datos
    /// </summary>
    /// <param name="id_group"> es el id del grupo que deseamos obtener</param>
    /// <returns> el grupo que queriamos recuperar </returns>
    public Group GetGroup(int id_group);

    /// <summary>
    /// Metodo que recupera todos los grupos que hay en la base de datos 
    /// </summary>
    /// <returns> una lista de grupo, con todos los grupos que hay en la base de datos</returns>
    public List<Group> ObtenerTodoLosGrupos();

    /// <summary>
    /// Metodo que conecta el id de una perosona, con el id de un grupo
    /// para generar la relacion entre ambas entidades
    /// </summary>
    /// <param name="id_person"> es el id de la persona que queremos agregar a un grupo </param>
    /// <param name="id_group"> es el id del grupo al cual queremos agregar un integrante </param>
    public bool AgregarIntegrante(int id_person, int id_group);

    public List<string> ObtenerIntegrantes(int id_group);

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