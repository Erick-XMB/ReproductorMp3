using System.Text.Json;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa la vista de los grupos del reproductor de musica
/// Sirve de puente entre el controlador de los albums y la GUI en QML
/// </summary>
public class AlbumVista
{
    // Atributo de tipo AlbumControlador para poder acceder a la logica de los grupos
    private AlbumControlador albumControlador = new AlbumControlador();

    /// <summary>
    /// Metodo que recupera todas las albums de la base de datos y las 
    /// convierte a JSON para que el QML pueda mostrarlas 
    /// </summary>
    /// <returns> una cadena JSON con la lista de los albums </returns>
    public string ObtenerTodosLosAlbumsJson()
    {
        List<Album> albums = albumControlador.ObtenerTodosLosAlbums();
        var filas = new List<object>();

        foreach (Album album in albums)
        {
            filas.Add(new
            {
                No = album.IdAlbum,
                Nombre = album.Name,
                Año = album.Year
            });
        }
        return JsonSerializer.Serialize(filas);
    }
}