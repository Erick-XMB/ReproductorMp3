namespace ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa un performer
/// </summary>
public class Performer
{   
    // Atributo que representa el identificador del performer
    private int id_performer;

    /// <summary>
    /// Metodo que obtiene o asigna el identificador del performer 
    /// </summary>
    public int IdPerformer
    {
        get { return id_performer; }
        set { id_performer = value; }
    }

    // Atributo que representa el identificador del tipo de performer que es
    private int id_type;

    /// <summary>
    /// Metodo que obtiene o asgigna el identificador del tipo de performer que es
    /// </summary>
    public int IdType
    {
        get { return id_type; }
        set { id_type = value; }
    }

    // Atributo cadena que representa el nombre del performer
    private string name;

    /// <summary>
    /// Metodo que obtiene o asigna el nombre del performer
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    

    /// <summary>
    /// Constructor de la clase Performer
    /// </summary>
    /// <param name="id_performer"> representa el identificador del performer </param>
    /// <param name="id_type"> representa el tipo de performer que es</param>
    /// <param name="name"> representa el nombre del performer </param>
    public Performer(int id_performer, int id_type, string name)
    {
        this.id_performer = id_performer;
        this.id_type = id_type;
        this.name = name;
    }

    /// <summary>
    /// Constructor de la clase Performer
    /// </summary>
    /// <param name="id_performer"> representa el identificador del performer </param>
    public Performer(int id_performer)
    {
        this.id_performer = id_performer;
    }
}