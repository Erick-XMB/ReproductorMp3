namespace ReproductorMp3.controlador;

using ReproductorMp3.modelo.accesoDatos;
using ReproductorMp3.modelo.accesoDatos.interfacesDAO;
using ReproductorMp3.modelo.entidades;
using ReproductorMp3.modelo.minero;

public class PersonaControlador
{
    private PersonDAO personDAO;

    private MineroMp3 minero = new MineroMp3();

    public PersonaControlador()
    {
        ConexionBaseDeDatos conexionBaseDeDatos = ConexionBaseDeDatos.GetInstancia();
        personDAO = new PersonDAOImpl(conexionBaseDeDatos);
    }

    public void agregarPersona(Person person)
    {
        personDAO.CreatePerson(person);
    }

}