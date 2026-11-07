namespace ReproductorMp3.modelo.entidades;

public class ParametrosBusqueda
{
    private string? tiutlo;
    public string? Titulo
    {
        get { return tiutlo; }
        set { tiutlo = value; }
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

    private int? anio;
    public int? Anio
    {
        get { return anio; }
        set { anio = value; }
    }

    private string? genero;
    public string? Genero
    {
        get { return genero; }
        set { genero = value; }
    }

    public ParametrosBusqueda(string? titulo, string? artista, string? album, int? anio, string? genero)
    {
        this.tiutlo = titulo;
        this.artista = artista;
        this.album = album;
        this.anio = anio;
        this.genero = genero;
    }
}