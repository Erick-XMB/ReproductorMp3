namespace ReproductorMp3.modelo;

public class Performer
{
    private int id_performer;
    public int IdPerformer
    {
        get { return id_performer; }
        set { id_performer = value; }
    }

    private int id_type;
    public int IdType
    {
        get { return id_type; }
        set { id_type = value; }
    }
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    

    public Performer(int id_performer, int id_type, string name)
    {
        this.id_performer = id_performer;
        this.id_type = id_type;
        this.name = name;
    }

    public Performer(int id_performer)
    {
        this.id_performer = id_performer;
    }
}