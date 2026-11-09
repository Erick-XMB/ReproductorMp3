namespace ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que permite asignar parametros
/// al momento de realizar una busqueda
/// </summary>
public class ParametrosBusqueda
{

    // Atributo de tipo cadena que representa el titulo de los parametros de la busqueda
    private string? tiutlo;

    /// <summary>
    /// Metodo que obtiene o asigna el titulo en los parametros de la busqueda
    /// </summary>
    public string? Titulo
    {
        get { return tiutlo; }
        set { tiutlo = value; }
    }

    // Atributo de tipo cadena que representa el nombre del artista en los parametros de la busqueda
    private string? artista;

    /// <summary>
    /// Metodo que obtiene o asigna el nombre del artista en los parametros de la busqueda 
    /// </summary>
    public string? Artista
    {
        get { return artista; }
        set { artista = value; }
    }

    // Atributo de tipo cadena que representa el nombre del album en los parametros de la busqueda
    private string? album;

    /// <summary>
    /// Metodo que obtiene o asigna el nombre del album en los parametros de la busqueda 
    /// </summary>
    public string? Album
    {
        get { return album; }
        set { album = value; }
    }

    // Atributo de tipo entero que representa el anio en los parametros de la busqueda
    private int? anio;

    /// <summary>
    /// Metodo que obtiene o asigna el anio en los parametros de la busqueda 
    /// </summary>
    public int? Anio
    {
        get { return anio; }
        set { anio = value; }
    }

    // Atributo de tipo cadena que representa el genero en los parametros de la busqueda
    private string? genero;

    /// <summary>
    /// Metodo que obtiene o asigna el genero en los parametros de la busqueda 
    /// </summary>
    public string? Genero
    {
        get { return genero; }
        set { genero = value; }
    }

    /// <summary>
    /// Constructor de la clase ParametrosBusqueda
    /// </summary>
    /// <param name="titulo"> cadena que representa el titulo </param>
    /// <param name="artista"> cadena que representa el nombre del artista </param>
    /// <param name="album"> cadena que representa el nombre del album </param>
    /// <param name="anio"> entero que representa el anio </param>
    /// <param name="genero"> cadena que representa el genero </param>
    public ParametrosBusqueda(string? titulo, string? artista, string? album, int? anio, string? genero)
    {
        this.tiutlo = titulo;
        this.artista = artista;
        this.album = album;
        this.anio = anio;
        this.genero = genero;
    }
}