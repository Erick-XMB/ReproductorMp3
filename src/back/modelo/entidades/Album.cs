namespace ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa un album
/// </summary>
public class Album
{   
    // Atributo entero que representa el id del album
    private int id_album;

    /// <summary>
    /// Metodo que obtiene o asigna el identificador de un album
    /// </summary>
    public int IdAlbum
    {
        get { return id_album; }
        set { id_album = value; }
    }

    // Cadena que representa la ruta de un album
    private string path = string.Empty;

    /// <summary>
    /// Metodo que obtiene o asigna la ruta de un album
    /// </summary>
    public string Path
    {
        get { return path; }
        set { path = value; }
    }

    // Cadena que representa el nombre de un album
    private string name = string.Empty;

    /// <summary>
    /// Metodo que obtiene o asigna el nombre de un album
    /// </summary>
    /// <value></value>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Atributo entero que representa el anio del album
    private int year;

    /// <summary>
    /// Metodo que obtiene o asigna el anio de un album
    /// </summary>
    /// <value></value>
    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    /// <summary>
    /// Constructor de la clase Album
    /// </summary>
    /// <param name="id_album"> el identificador del album </param>
    /// <param name="path"> la ruta del album </param>
    /// <param name="name"> el nombre del album </param>
    /// <param name="year"> el anio del album </param>
    public Album(int id_album, string path, string name, int year)
    {
        this.id_album = id_album;
        this.path = path;
        this.name = name;
        this.year = year;
    }

    /// <summary>
    /// COnstructor de la clase Album
    /// </summary>
    /// <param name="id_album"> el identificador del album </param>
    public Album(int id_album)
    {
        this.id_album = id_album;

    }

}