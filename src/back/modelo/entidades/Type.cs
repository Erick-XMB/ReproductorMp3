namespace ReproductorMp3.modelo.entidades;

public class Type
{
    private int id_type;
    public int IdType
    {
        get { return id_type; }
        set { id_type = value; }
    }
    
    private string description;
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    

    public Type(int id_type, string description)
    {
        this.id_type = id_type;
        this.description = description;
    }
}