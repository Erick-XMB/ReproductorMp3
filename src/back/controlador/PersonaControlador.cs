namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

/// <summary>
/// Clase que represneta el controlador de las personas
/// del reproductor de musica
/// </summary> <summary>
public class PersonaControlador
{
    // Atirbuto de tipo PersonDAO para poder tener acceso a la tabla de personas de la base de datos
    private PersonDAO personDAO;

    // Atribuo minero de tipo MineroMp3 del modelo
    private MineroMp3 minero = new MineroMp3();

    /// <summary>
    /// Constructor de la clase PersonaControlador
    /// Destacamos la llamada a nuestra ConexionBaseDeDatos para poder
    /// tener siempre la misma conexion
    /// </summary>
    public PersonaControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        personDAO = new PersonDAOImpl(conexionBaseDeDatos);
    }

    /// <summary>
    /// Metodo que ingresa una persona a la base de datos
    /// </summary>
    /// <param name="person">< es la persona que queremos ingresar /param>
    public bool agregarPersona(Person person)
    {
        return personDAO.CreatePerson(person);
    }

        /// <summary>
    /// Metodo que recupera a todas las personas de la base de datos
    /// </summary>
    /// <returns> Una lista con todas las personas que hay en la base de datos </returns>
    public List<Person> ObtenerTodasLasPersonas()
    {
        return personDAO.ObtenerTodasLasPersonas();
    }

}