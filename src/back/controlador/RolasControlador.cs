namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

/// <summary>
/// Clase que representa el controlador de las rolas
/// del reprouctor de musica 
/// </summary>
public class RolasControlador
{
    //Atributo de tipo RolaDAO para poder tener a la tabla de rolas de la base de datos
    private RolaDAO rolaDAO;

    // Atributo minero de tipo MineroMp3 del modelo
    private MineroMp3 minero = new MineroMp3();

    /// <summary>
    /// Constructor de la clase RolasControlador
    /// Destacamos la llamada a nuestra ConexionBaseDeDatos para poder
    /// tener siempre la misma conexion
    /// </summary>
    public RolasControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        rolaDAO = new RolaDAOImpl(conexionBaseDeDatos);
    }

    /// <summary>
    /// Metodo que recupera todas las rolas guardadas en la base de datos
    /// </summary>
    /// <returns> una lista con todas las rolas de la base de datos </returns>
    public List<Rola> ObtenerRolas()
    {
        return rolaDAO.GetTodasLasRolas();
    }

    /// <summary>
    /// Metodo que recupera las rolas de la base de datos, que contengan
    /// la palabra indicada como parametro
    /// </summary>
    /// <param name="palabra"> es la palabra a buscar en las rolas </param>
    /// <returns> Una lista de las rolas que coinciden con la palabra dada </returns>
    public List<Rola> ObtenerRolasPorPalabra(string palabra)
    {
        return rolaDAO.GetRolasPorPalabra(palabra);
    }

    /// <summary>
    /// Metodo que dada la ruta de un archivo .mp3 extrae la portada de sus metados, 
    /// esto solo si el archivo contiene una imagen en sus etiquetas
    /// </summary>
    /// <param name="ruta"> es la ruta del archivo .mp3 </param>
    /// <returns> un par ordenado con el tipo de la imagen y sus bytes, null en caso de 
    /// no tener alguna imagen asociada o un error en la lectura </returns>
    public (string TipoImagen, byte[] datos)? ObtenerPortada(string ruta)
    {
        return minero.ObtenerPortada(ruta);
    }

    /// <summary>
    /// Metodo que recupera de la base de datos las rolas que cumplan
    /// con los criterios indicados en los parametros
    /// </summary>
    /// <param name="parametrosBusqueda"> es el objeto que contiene los 
    /// criterios de busqueda a aplicar </param>
    /// <returns> una lista de las rolas que cumplen los criterios de busqueda </returns>
    public List<Rola> ObtenerRolasPorBusquedaAvanzada(ParametrosBusqueda parametrosBusqueda)
    {
        return rolaDAO.GetRolasPorBusquedaAvanzada(parametrosBusqueda);
    }

    public void ActualizarNombreDeLaRola(int id_rola, string title)
    {
        rolaDAO.UpdateNombreDeLaRola(id_rola, title);
    }

    public void ActualizarGeneroDeLaRola(int id_rola, string genre)
    {
        rolaDAO.UpdateGeneroDeLaRola(id_rola, genre);
    }

    public void ActualizarAnioDeLaRola(int id_rola, int year)
    {
        rolaDAO.UpdateAnioDeLaRola(id_rola, year);
    }
}
