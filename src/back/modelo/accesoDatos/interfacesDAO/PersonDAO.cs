using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;

/// <summary>
/// Interfaz que define las operaciones de acceso a datos para las personas
/// </summary>
public interface PersonDAO
{
    /// <summary>
    /// Metodo que ingresa una persona a la base de datos
    /// </summary>
    /// <param name="person">< es la persona que queremos ingresar /param>
    public void CreatePerson(Person person);

    /// <summary>
    /// Metodo que devuelve una persona de la base de datos
    /// </summary>
    /// <param name="id_person"> es el id de la persona que queremos recuperar </param>
    /// <returns> La Persona que queramos devolver </returns>
    public Person GetPerson(int id_person);

    /// <summary>
    /// Metodo que actualiza una persona de la base de datos
    /// </summary>
    /// <param name="person"> la persona que queremos actualizar </param>
    public void UpdatePerson(Person person);

    /// <summary>
    /// Metodo que elimina a una persona de la base de datos
    /// </summary>
    /// <param name="id_person"></param>
    public void DeletePerson(int id_person);
    
}   