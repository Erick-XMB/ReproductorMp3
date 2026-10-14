namespace ReproductorMp3.modelo;

public class Performer
{
    private int id_performer;
    private int id_type;
    private string name;

    public Performer(int id_performer, int id_type, string name)
    {   
        this.id_performer = id_performer;
        this.id_type = id_type;
        this.name = name;
        
    }
}