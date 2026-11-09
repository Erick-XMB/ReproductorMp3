namespace ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa una persona
/// </summary>
public class Person
{   
    // Atributo entero que representa el identificador de la persona
    private int id_person;

    /// <summary>
    /// Metodo que obtiene o asigna el identificador de una persona
    /// </summary>
    /// <value></value>
    public int IdPerson
    {
        get { return id_person; }
        set { id_person = value; }
    }

    // Atributo que representa el nombre artistico de la persona
    private string stage_name;

    /// <summary>
    /// Metodo que obtiene o asigna el nombre artistico de la persona 
    /// </summary>
    /// <value></value>
    public string StageName
    {
        get { return stage_name; }
        set { stage_name = value; }
    }

    // Atributo que representa el nombre real de la persona 
    private string real_name;

    /// <summary>
    /// Metodo que obtiene o asigna el nombre real de la persona
    /// </summary>
    /// <value></value>
    public string RealName
    {
        get { return real_name; }
        set { real_name = value; }
    }

    // Atributo que representa la fecha de nacimiento de la persona
    private string birth_date;

    /// <summary>
    /// Metodo que obtiene o asigna la fecha de nacimiento de la persona 
    /// </summary>
    /// <value></value>
    public string BirthDate
    {
        get { return birth_date; }
        set { birth_date = value; }
    }

    // Atributo que representa le fecha de muerte de la persona
    private string death_date;

    /// <summary>
    /// Metodo que obtiene o asigna la fecha de muerte de la persona
    /// </summary>
    /// <value></value>
    public string DeathDate
    {
        get { return death_date; }
        set { death_date = value; }
    }

    /// <summary>
    /// Constructor de la clase Person
    /// </summary>
    /// <param name="id_person"> representa el identificador de la persona </param>
    /// <param name="stage_name"> representa el nombre artistico de la persona </param>
    /// <param name="real_name"> representa el nombre real de la persona </param>
    /// <param name="birth_date"> representa la fecha  de nacimiento de la persona </param>
    /// <param name="death_date"> representa la fecha de muerte de la persona </param>
    public Person(int id_person, string stage_name, string real_name, string birth_date, string death_date)
    {
        this.id_person = id_person;
        this.stage_name = stage_name;
        this.real_name = real_name;
        this.birth_date = birth_date;
        this.death_date = death_date;
    }

    /// <summary>
    /// Constructor de la clase Person
    /// </summary>
    /// <param name="stage_name"> representa el nombre artistico de la persona </param>
    /// <param name="real_name"> representa el nombre real de la persona </param>
    /// <param name="birth_date"> representa la fecha  de nacimiento de la persona </param>
    /// <param name="death_date"> representa la fecha de muerte de la persona </param>
    public Person(string stage_name, string real_name, string birth_date, string death_date)
    {
        this.stage_name = stage_name;
        this.real_name = real_name;
        this.birth_date = birth_date;
        this.death_date = death_date;
    }
}