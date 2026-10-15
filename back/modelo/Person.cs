namespace ReproductorMp3.modelo;

public class Person
{
    private int id_person;
    public int IdPerson
    {
        get { return id_person; }
        set { id_person = value; }
    }

    private string stage_name;
    public string StageName
    {
        get { return stage_name; }
        set { stage_name = value; }
    }

    private string real_name;
    public string RealName
    {
        get { return real_name; }
        set { real_name = value; }
    }

    private string birth_date;
    public string BirthDate
    {
        get { return birth_date; }
        set { birth_date = value; }
    }

    private string death_date;
    public string DeathDate
    {
        get { return death_date; }
        set { death_date = value; }
    }
    public Person(int id_person, string stage_name, string real_name, string birth_date, string death_date)
    {
        this.id_person = id_person;
        this.stage_name = stage_name;
        this.real_name = real_name;
        this.birth_date = birth_date;
        this.death_date = death_date;
    }
}