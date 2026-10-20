namespace ReproductorMp3.modelo.entidades;

public class DatosMp3
{
    private string? titulo;
    public string? Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    private string? artista;
    public string? Artista
    {
        get { return artista; }
        set { artista = value; }
    }

    private string? album;
    public string? Album
    {
        get { return album; }
        set { album = value; }
    }

    private uint track;
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