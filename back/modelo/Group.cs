namespace ReproductorMp3.modelo;

public class Group
{
    private int id_group;
    public int IdGroup
    {
        get { return id_group; }
        set { id_group = value; }
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string start_date;
    public string StartDate
    {
        get { return start_date; }
        set { start_date = value; }
    }

    private string end_date;
    public string EndDate
    {
        get { return end_date; }
        set { end_date = value; }
    }

    public Group(int id_group, string name, string start_date, string end_date)
    {
        this.id_group = id_group;
        this.name = name;
        this.start_date = start_date;
        this.end_date = end_date;
    }


}