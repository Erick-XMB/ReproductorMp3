using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;

/// <summary>
/// Interfaz que define las operaciones de acceso a datos para las rolas 
/// </summary>
public interface RolaDAO
{
    /// <summary>
    /// Metodo que ingresa una rola a la base de datos
    /// </summary>
    /// <param name="rola"> es la rola que queremos ingresar </param>
    public void CreateRola(Rola rola);

    /// <summary>
    /// Metodo que recupera una rola de la base de datos
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos recuperar </param>
    /// <returns> la rola que queriamos obtener </returns>
    public Rola GetRola(int id_rola);

    /// <summary>
    /// Metood que recupera una rola de la base de datos por su ruta
    /// </summary>
    /// <param name="ruta"> es la ruta de la rola </param>
    /// <returns> la rola que queriamos recuperar </returns>
    public Rola GetRolaPorRuta(string ruta);

    /// <summary>
    /// Metood que actualiza una rola de la base de datos
    /// </summary>
    /// <param name="rola"> es la rola que queremos actualizar </param>
    public void UpdateRola(Rola rola);

    /// <summary>
    /// Metodo que elimina una rola de la base de datos
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos eliminar </param>
    public void DeleteRola(int id_rola);
    
}   