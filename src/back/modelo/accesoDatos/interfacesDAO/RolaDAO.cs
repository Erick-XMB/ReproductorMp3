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
    /// Metodo que recupera las rolas de la base de datos, que contengan
    /// la palabra indicada como parametro
    /// </summary>
    /// <param name="palabra"> es la palabra a buscar en las rolas </param>
    /// <returns> Una lista de las rolas que coinciden con la palabra dada </returns>
    public List<Rola> GetRolasPorPalabra(string palabra);

    /// <summary>
    /// Metodo que recupera de la base de datos las rolas que cumplan
    /// con los criterios indicados en los parametros
    /// </summary>
    /// <param name="parametrosBusqueda"> es el objeto que contiene los 
    /// criterios de busqueda a aplicar </param>
    /// <returns> una lista de las rolas que cumplen los criterios de busqueda </returns>
    public List<Rola> GetRolasPorBusquedaAvanzada(ParametrosBusqueda parametrosBusqueda);

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

    /// <summary>
    /// Metodo que deuvelve todas las rolas de la base de datos
    /// </summary>
    /// <returns> la lista de todas las rolas </returns>
    public List<Rola> GetTodasLasRolas();
    
}   