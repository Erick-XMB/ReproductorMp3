namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

public class GrupoControlador
{
    private GroupDAO groupDAO;

    private MineroMp3 minero = new MineroMp3();

    public GrupoControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        groupDAO = new GroupDAOImpl(conexionBaseDeDatos);
    }

    public void agregarGrupo(Group group)
    {
        groupDAO.CreateGroup(group);
    }

}