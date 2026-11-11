using System.Text.Json;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa la vista de las rolas del reproductor de musica
/// Sirve como puente entre el controlador y la GUI hecha en QML
/// </summary>
public class RolasVista
{
    // Atributo de tipo RolasControlador para poder acceder a la logica de las rolas
    private RolasControlador controladorRolas = new RolasControlador();

    /// <summary>
    /// Metodo que recupera todas las rolas de la base de datos y las 
    /// convierte a JSON para que el QML pueda mostrarlas 
    /// </summary>
    /// <returns> una cadena JSON con la lista de las rolas </returns>
    public string ObtenerRolasJson()
    {
        List<Rola> rolas = controladorRolas.ObtenerRolas();
        var filas = new List<object>();

        foreach (Rola rola in rolas)
        {
            filas.Add(new
            {
                No = rola.IdRola,
                Nombre = rola.Title,
                Artista = rola.Performer.Name,
                Album = rola.Album.Name,
                Genero = rola.Genre,
                Anio = rola.Year,
                Ruta = rola.Path
            });
        }
        return JsonSerializer.Serialize(filas);
    }

    /// <summary>
    /// Metodo que recupera las rolas que contienen una determinada palabra de la base de datos y las 
    /// convierte a JSON para que el QML pueda mostrarlas 
    /// </summary>
    /// <param name="palabra"> es la palabra a buscar en las rolas </param>
    /// <returns> una cadena JSON con la lista de las rolas que contienen la palabra </returns>
    public string ObtenerRolasPorPalabraJson(string palabra)
    {
        List<Rola> rolas = controladorRolas.ObtenerRolasPorPalabra(palabra);
        var filas = new List<Object>();

        foreach (Rola rola in rolas)
        {
            filas.Add(new
            {
                No = rola.IdRola,
                Nombre = rola.Title,
                Artista = rola.Performer.Name,
                Album = rola.Album.Name,
                Genero = rola.Genre,
                Anio = rola.Year,
                Ruta = rola.Path
            });
        }
        return JsonSerializer.Serialize(filas);
    }

    /// <summary>
    /// Metodo que segun los datos de la busqueda avanzada, crea un objeto de tipo
    /// ParametrosBusqueda y lo convierte a una cadena de JSON
    /// </summary>
    /// <param name="titulo"> es el titulo a buscar </param>
    /// <param name="artista"> es el artista a buscar </param>
    /// <param name="album"> es el album a buscar </param>
    /// <param name="anio"> es el anio a buscar </param>
    /// <param name="genero"> es el genero a buscar </param>
    /// <returns> una cadena JSON con los parametros de busqueda </returns>
    public string CrearObjetoDeParametrosBusquedaJson(string titulo, string artista, string album, string anio, string genero)
    {
        int? anioNumerico = int.TryParse(anio, out int valor) ? valor : null;
        ParametrosBusqueda parametrosBusqueda = new ParametrosBusqueda(titulo, artista, album, anioNumerico, genero);
        return JsonSerializer.Serialize(parametrosBusqueda);
    }

    /// <summary>
    /// Metodo que  dados los parametros de busqueda recupera las rolas de la base de datos y las 
    /// convierte a JSON para que el QML pueda mostrarlas 
    /// </summary>
    /// <param name="parametrosJson"> es la cadena JSON con los parametros de busqueda </param>
    /// <returns> una cadena JSON con la lista de las rolas que cumplen los criterios </returns>
    public string ObtenerRolasPorBusquedaAvanzadaJson(string parametrosJson)
    {
        ParametrosBusqueda? parametrosBusqueda = JsonSerializer.Deserialize<ParametrosBusqueda>(parametrosJson);

        if (parametrosBusqueda == null)
        {
            return "[]";
        }

        List<Rola> rolas = controladorRolas.ObtenerRolasPorBusquedaAvanzada(parametrosBusqueda);
        var filas = new List<Object>();

        foreach (Rola rola in rolas)
        {
            filas.Add(new
            {
                No = rola.IdRola,
                Nombre = rola.Title,
                Artista = rola.Performer.Name,
                Album = rola.Album.Name,
                Genero = rola.Genre,
                Anio = rola.Year,
                Ruta = rola.Path
            });
        }
        return JsonSerializer.Serialize(filas);
    }

    /// <summary>
    /// Metodo que dada la ruta de un archivo.mp3 obtienen la portada
    /// y la convierte a base4 para que el QML pueda mostrarla
    /// </summary>
    /// <param name="ruta"></param>
    /// <returns></returns>
    public string ObtenerPortadaArchivo(string ruta)
    {
        var portada = controladorRolas.ObtenerPortada(ruta);

        if (portada == null)
        {
            return "";
        }

        string base64 = Convert.ToBase64String(portada.Value.datos);
        return $"data:{portada.Value.TipoImagen};base64,{base64}";
    }

    /// <summary>
    /// Metodo que funciona como puente entre el controlador de las rolas con la interfaz en QML
    /// Actualiza el nombre de una rola seleccionada
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos actualizar </param>
    /// <param name="title"> es el titulo que queremos asignar </param>
    public void ActualizarNombreRola(int id_rola, string title)
    {
        controladorRolas.ActualizarNombreDeLaRola(id_rola, title);
    }

    /// <summary>
    /// Metodo que funciona como puente entre el controlador de las rolas con la interfaz en QML
    /// Actualiza el genero de una rola seleccionada
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos actualizar </param>
    /// <param name="genero"> es el genero que queremos asignar </param>
    public void ActualizarGeneroRola(int id_rola, string genero)
    {
        controladorRolas.ActualizarGeneroDeLaRola(id_rola, genero);
    }

    /// <summary>
    /// Metodo que funciona como puente entre el controlador de las rolas con la interfaz en QML
    /// Actualiza el anio de una rola seleccionada
    /// </summary>
    /// <param name="id_rola"> es el id de la rola que queremos actualizar </param>
    /// <param name="anio"> es el anio que queremos asignar </param>
    public void ActualizarAnioRola(int id_rola, int anio)
    {
        controladorRolas.ActualizarAnioDeLaRola(id_rola, anio);
    }

}