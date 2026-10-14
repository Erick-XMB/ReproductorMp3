namespace ReproductorMp3.modelo;

public class Group
{
    private int id_group;
    private string name;
    private string start_date;
    private string end_date;

    public Group(int id_group, string name, string start_name, string end_date)
    {
        this.id_group = id_group;
        this.name = name;
        this.start_date = start_date;
        this.end_date = end_date;
    }


}