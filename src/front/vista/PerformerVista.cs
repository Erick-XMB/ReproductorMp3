using System.Text.Json;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa la vista de los performers del reproductor de musica
/// Sirve de puente entre el controlador de los grupos y la GUI en QML
/// </summary>
public class PerformerVista
{
    // Atributo de tipo PerformerControlador para poder acceder a la logica de los grupos
    private PerformerControlador performerControlador = new PerformerControlador();

    /// <summary>
    /// Metodo que dado una cadena que representa el nombre de un performer recupera al performer de la base de datos y lo
    /// convierte a JSON para que el QML pueda mostrarlo
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns></returns>
    public String BuscarPerformerPorNombre(string nombre)
    {
        Performer? performer = performerControlador.BuscarPerformerPorNombre(nombre);

        string jsonPerformer = JsonSerializer.Serialize(performer);

        return jsonPerformer;
    }

    /// <summary>
    /// Metodo que recupera todas las albums de la base de datos y las 
    /// convierte a JSON para que el QML pueda mostrarlas 
    /// </summary>
    /// <returns> una cadena JSON con la lista de los albums </returns>
    public string ObtenerTodosLosPerformersJson()
    {
        List<Performer> performers = performerControlador.ObtenerTodosLosPerformers();
        var filas = new List<object>();

        foreach (Performer performer in performers)
        {
            filas.Add(new
            {
                No = performer.IdPerformer,
                Tipo = performer.IdType switch
                {
                    0 => "Persona",
                    1 => "Grupo",
                    _ => "Desconocido"
                },
                Nombre = performer.Name
            });
        }
        return JsonSerializer.Serialize(filas);
    }

    /// <summary>
    /// Metodo que funciona como puente entre el controlador y la vista en qml
    ///  que actualiza el tipo de un performer en la base de datos
    /// </summary>
    /// <param name="id_performer"> es el id del performer que queremos actualizar </param>
    /// <param name="id_type"> es el tipo que queremos asignar </param>
    public void ActualizarTipoDelPerformer(int id_performer, int id_type)
    {
        performerControlador.ActualizarTipoDelPerformer(id_performer, id_type);
    }
}