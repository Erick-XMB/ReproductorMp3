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

    public void AgregarIntegranteAGrupo(int id_person, int id_group)
    {
        grupoControlador.AgregarIntegrante(id_person, id_group);
    }

    public string ObtenerGruposJson()
    {
        List<Group> grupos = grupoControlador.ObtenerTodosLosGrupos();
        var filas = new List<object>();

        foreach (Group grupo in grupos)
        {
            filas.Add(new
            {
                id = grupo.IdGroup,
                nombre = grupo.Name
            });
        }
        return JsonSerializer.Serialize(filas);
    }
}