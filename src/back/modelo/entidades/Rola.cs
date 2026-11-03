namespace ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa una rola
/// </summary>
public class Rola
{
    // Atributo entero que representa el identificador de la rola 
    private int id_rola;

    /// <summary>
    /// Metodo para obtener o asignar el identificador de una rola
    /// </summary>
    public int IdRola
    {
        get { return id_rola; }
        set { id_rola = value; }
    }

    // Atributo que representa el album de una rola 
    private Album album;

    /// <summary>
    /// Metodo para obtener o asignar el album de una rola
    /// </summary>
    /// <value></value>
    public Album Album
    {
        get { return album; }
        set { album = value; }
    }

    // Atributo que reprsenta el performer de la rola
    private Performer performer;

    /// <summary>
    /// Metodo para obtener o asignar el performer de la rola
    /// </summary>
    /// <value></value>
    public Performer Performer
    {
        get { return performer; }
        set { performer = value; }
    }

    // Atributo que representa la ruta de la rola 
    private string path;

    /// <summary>
    /// Metodo para obtener o asignar la ruta de la rola
    /// </summary>
    /// <value></value>
    public string Path
    {
        get { return path; }
        set { path = value; }
    }

    // Atributo que representa el titulo de la rola
    private string title;

    /// <summary>
    /// Metodo para obtener o asignar el titulo de la rola
    /// </summary>
    /// <value></value>
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    // Atributo que representa el numero de pista de la rola
    private int track;

    /// <summary>
    /// Metodo para obtener o asignar el numero de pista de la rola
    /// </summary>
    /// <value></value>
    public int Track
    {
        get { return track; }
        set { track = value; }
    }

    // Atributo entero que representa el anio de la rola
    private int year;

    /// <summary>
    /// Metodo para obtener o asignar el anio de la rola
    /// </summary>
    /// <value></value>
    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    // Cadena que representa el genero de la rola
    private string genre;

    /// <summary>
    /// Metodo para obtener o asignar el genero de la rola
    /// </summary>
    /// <value></value>
    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    /// <summary>
    /// Constructor de la clase Rola
    /// </summary>
    /// <param name="id_rola"> representa el identificador de la rola </param>
    /// <param name="album"> representa el album de la rola </param>
    /// <param name="performer"> representa el performer de la rola </param>
    /// <param name="path"> representa la ruta de la rola </param>
    /// <param name="title"> representa el titulo de la rola </param>
    /// <param name="track"> representa el numero de pista de la rola </param>
    /// <param name="year"> representa el anio de la rola </param>
    /// <param name="genre"> representa el genero de la rola </param>
    public Rola(int id_rola, Album album, Performer performer, string path, string title, int track, int year, string genre)
    {
        this.id_rola = id_rola;
        this.album = album;
        this.performer = performer;
        this.path = path;
        this.title = title;
        this.track = track;
        this.year = year;
        this.genre = genre;
    }
}