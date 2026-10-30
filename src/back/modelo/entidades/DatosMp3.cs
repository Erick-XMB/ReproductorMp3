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


    private uint anio;
    public uint Anio
    {
        get { return anio; }
        set { anio = value; }
    }

    private string[]? generos;
    public string[] Generos
    {
        get { return generos!; }
        set { generos = value; }
    }

    private string ruta;
    public string Ruta
    {
        get { return ruta; }
        set { ruta = value; }
    }

    private byte versionId3;
    public byte VersionId3
    {
        get { return versionId3; }
        set { versionId3 = value; }
    }

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