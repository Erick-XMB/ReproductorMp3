namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

public class RolasControlador
{
    private RolaDAO rolaDAO;
    private MineroMp3 minero = new MineroMp3();

    public RolasControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        rolaDAO = new RolaDAOImpl(conexionBaseDeDatos);
    }

    public List<Rola> ObtenerRolas()
    {
        return rolaDAO.GetTodasLasRolas();
    }

    public (string TipoImagen, byte[] datos)? ObtenerPortada(string ruta)
    {
        return minero.ObtenerPortada(ruta);
    }
}
