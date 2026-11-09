namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

/// <summary>
/// Clase que representa el controlador de los grupos
/// del reproductor de musica 
/// </summary>
public class GrupoControlador
{
    // Atributo de tipo GroupDAO para poder tener acceso a la tabla de grupos de la base de datos
    private GroupDAO groupDAO;

    // Atributo minero de tipo MineroMp3 del modelo
    private MineroMp3 minero = new MineroMp3();

    /// <summary>
    /// Constructor de la clase GrupoControlador
    /// Destacamos llamada a nuestra ConexionBaseDeDatos para
    /// poder tener siempre la misma conexion
    /// </summary> <summary>
    public GrupoControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        groupDAO = new GroupDAOImpl(conexionBaseDeDatos);
    }

    /// <summary>
    /// Metodo que inserta un grupo a la base de datos
    /// </summary>
    /// <param name="group"> es el grupo que se desea insertar </param>
    public bool agregarGrupo(Group group)
    {
        return groupDAO.CreateGroup(group);
    }

    /// <summary>
    /// Metodo que recupera todos los grupos que hay en la base de datos 
    /// </summary>
    /// <returns> una lista de grupo, con todos los grupos que hay en la base de datos</returns>
    public List<Group> ObtenerTodosLosGrupos()
    {
        return groupDAO.ObtenerTodoLosGrupos();
    }

    /// <summary>
    /// Metodo que conecta el id de una perosona, con el id de un grupo
    /// para generar la relacion entre ambas entidades
    /// </summary>
    /// <param name="id_person"> es el id de la persona que queremos agregar a un grupo </param>
    /// <param name="id_group"> es el id del grupo al cual queremos agregar un integrante </param>
    public bool AgregarIntegrante(int id_person, int id_group)
    {
        return groupDAO.AgregarIntegrante(id_person, id_group);
    }


}