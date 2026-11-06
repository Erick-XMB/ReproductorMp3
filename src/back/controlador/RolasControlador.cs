namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;

public class RolasControlador
{
    private RolaDAO rolaDAO;

    public RolasControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        rolaDAO = new RolaDAOImpl(conexionBaseDeDatos);
    }

    public List<Rola> ObtenerRolas()
    {
        return rolaDAO.GetTodasLasRolas();
    }




}