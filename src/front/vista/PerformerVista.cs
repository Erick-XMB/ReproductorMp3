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
    

    public String BuscarPerformerPorNombre(string nombre)
    {
        Performer? performer = performerControlador.BuscarPerformerPorNombre(nombre);

        string jsonPerformer = JsonSerializer.Serialize(performer);

        return jsonPerformer;
    }

    public void ActualizarTipoDelPerformer(int id_performer, int id_type)
    {
        performerControlador.ActualizarTipoDelPerformer(id_performer, id_type);
    }

    
}