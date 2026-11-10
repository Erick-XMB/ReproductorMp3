using System.Text.Json;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa la vista de los grupos del reproductor de musica
/// Sirve de puente entre el controlador de los grupos y la GUI en QML
/// </summary>
public class GrupoVista
{
    // Atributo de tipo GrupoControlador para poder acceder a la logica de los grupos
    private GrupoControlador grupoControlador = new GrupoControlador();

    /// <summary>
    /// Metodo que dados los datos un grupo, crea un objeto de tipo Group y lo manda a guardar en la base
    /// de datos
    /// </summary>
    /// <param name="nombre"> es el nombre del grupo </param>
    /// <param name="fechaInicio"> es la fecha de inicio del grupo </param>
    /// <param name="fechaTermino"> es la fehca de termino del grupo </param>
    public bool AgregarObjetoGrupo(string nombre, string fechaInicio, string fechaTermino)
    {
        Group group = new Group(nombre, fechaInicio, fechaTermino);
        return grupoControlador.agregarGrupo(group);
    }

    /// <summary>
    /// Metodo que relaciona a una persona como integrante de un grupo
    /// </summary>
    /// <param name="id_person" es el identificador de la persona ></param>
    /// <param name="id_group"> es el identificador del grupo </param>
    public bool AgregarIntegranteAGrupo(int id_person, int id_group)
    {
        return grupoControlador.AgregarIntegrante(id_person, id_group);
    }

    /// <summary>
    /// Metodo que recupera todos los grupos de la base de datos
    /// </summary>
    /// <returns> una cadena JSON con la lista de grupos, solo id y nombre </returns>
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

    public string ObtenerTodosLosGruposJson()
    {
        List<Group> grupos = grupoControlador.ObtenerTodosLosGrupos();
        var filas = new List<object>();

        foreach (Group grupo in grupos)
        {
            filas.Add(new
            {
                No = grupo.IdGroup,
                Nombre = grupo.Name,
                Integrantes = string.Join(", ", grupoControlador.ObtenerIntegrantes(grupo.IdGroup)),
                Fecha_de_inicio = grupo.StartDate,
                Fecha_de_termino = grupo.EndDate
            });
        }
        return JsonSerializer.Serialize(filas);
    }
}