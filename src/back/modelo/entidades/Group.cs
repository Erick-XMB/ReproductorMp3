namespace ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa un grupo 
/// </summary>
public class Group
{
    // Atributo entero que representa el id del grupo 
    private int id_group;

    /// <summary>
    /// Metodo que obtiene o asigna el identificador de un grupo
    /// </summary>
    public int IdGroup
    {
        get { return id_group; }
        set { id_group = value; }
    }

    // Atributo cadena que represneta el nombre del grupo 
    private string name;

    /// <summary>
    /// Metodo que obtiene o asigna el name de un grupo
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Atributo cadena que representa la fecha en que inicio el grupo
    private string start_date;

    /// <summary>
    /// Metodo que obtiene o asigna la fecha de inicio de un grupo
    /// </summary>
    public string StartDate
    {
        get { return start_date; }
        set { start_date = value; }
    }

    // Atributo cadena que representa la fecha en que termino el grupo
    private string end_date;

    /// <summary>
    /// Metodo que obtiene o asigna la fecha de termino de un grupo
    /// </summary>I
    public string EndDate
    {
        get { return end_date; }
        set { end_date = value; }
    }

    /// <summary>
    /// Constructor de la clase grupo
    /// </summary>
    /// <param name="id_group"> representa el identificador del grupo </param>
    /// <param name="name"> representa el nombre del grupo </param>
    /// <param name="start_date"> representa la fecha de inicio del grupo </param>
    /// <param name="end_date"> representa la fecha de termino del grupo </param>
    public Group(int id_group, string name, string start_date, string end_date)
    {
        this.id_group = id_group;
        this.name = name;
        this.start_date = start_date;
        this.end_date = end_date;
    }

    /// <summary>
    /// Constructor de la clase grupo
    /// </summary>
    /// <param name="name"> representa el nombre del grupo </param>
    /// <param name="start_date"> representa la fecha de inicio del grupo </param>
    /// <param name="end_date"> representa la fecha de termino del grupo </param>
    public Group(string name, string start_date, string end_date)
    {
        this.name = name;
        this.start_date = start_date;
        this.end_date = end_date;
    }


}