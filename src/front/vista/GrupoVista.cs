using System.Text.Json;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

public class GrupoVista
{
    private GrupoControlador grupoControlador = new GrupoControlador();

    public void AgregarObjetoGrupo(string nombre, string fechaInicio, string fechaTermino)
    {
        Group group = new Group(nombre, fechaInicio, fechaTermino);
        grupoControlador.agregarGrupo(group);
    }
}