namespace ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa una entidad de un archivo mp3
/// </summary>
public class DatosMp3
{
    // cadena que representa el titulo del mp3
    private string? titulo;

    /// <summary>
    /// Metodo que obitiene o asigna el titulo del mp3
    /// </summary>
    public string? Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    // cadena que representa el artista del mp3
    private string? artista;

    /// <summary>
    /// Metodo que obtiene o asigna el artista del mp3
    /// </summary>
    public string? Artista
    {
        get { return artista; }
        set { artista = value; }
    }

    // cadena que representa el album del mp3
    private string? album;

    /// <summary>
    /// Metodo que obtiene o asigna el album del mp3
    /// </summary>
    public string? Album
    {
        get { return album; }
        set { album = value; }
    }

    // entero que representa el track del mp3
    private uint track;
    /// <summary>
    /// Metodo que obtiene o asigna el track del mp3
    /// </summary>
    public uint Track
    {
        get { return track; }
        set { track = value; }
    }

    // entero positivo que representa el anio del mp3
    private uint anio;

    /// <summary>
    /// Metodo que obtiene o asigna el anio del mp3
    /// </summary>
    public uint Anio
    {
        get { return anio; }
        set { anio = value; }
    }

    /// arreglo de cadena que representa los generos del mp3
    private string[]? generos;

    /// <summary>
    /// Metodo que obtiene o asigna los generos del mp3 
    /// </summary>
    public string[] Generos
    {
        get { return generos!; }
        set { generos = value; }
    }

    // Atributo cadena que representa la ruta del mp3
    private string ruta;

    /// <summary>
    /// Metodo que obtiene o asigna la ruta del mp3
    /// </summary>
    public string Ruta
    {
        get { return ruta; }
        set { ruta = value; }
    }

    //  Atributo que representa la version de la etiqueta del mp3
    private byte versionId3;

    /// <summary>
    /// Metodo que obtiene o asigna la version de la etiqueta del mp3
    /// </summary> 
    public byte VersionId3
    {
        get { return versionId3; }
        set { versionId3 = value; }
    }

    /// <summary>
    /// Constructor de la clase DatosMP3
    /// </summary>
    /// <param name="track"> es el track del mp3</param>
    /// <param name="titulo">< representa el titulo del mp3 /param>
    /// <param name="artista"> representa el artista del mp3 </param>
    /// <param name="album"> representa el album del mp3 </param>
    /// <param name="anio"> representa el anio del mp3 </param>
    /// <param name="generos"> representa los generos del mp3 </param>
    /// <param name="ruta"> representa la ruta del mp3 </param>
    /// <param name="versionId3"> representa la version de la etiqueta del mp3 </param>
    public DatosMp3(uint track, string? titulo, string? artista, string? album, uint anio, string[] generos, string ruta, byte versionId3)
    {
        this.track = track;
        this.titulo = titulo;
        this.artista = artista;
        this.album = album;
        this.anio = anio;
        this.generos = generos;
        this.ruta = ruta;
        this.versionId3 = versionId3;
    }
}