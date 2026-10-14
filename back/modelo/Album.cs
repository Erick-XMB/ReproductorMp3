namespace ReproductorMp3.modelo;

public class Album
{
    private int id_album;
    private string path;
    private string name;
    private int year;
    private List<Rola> rolas;

    public Album(int id_album, string path, string name, int year, List<Rola> rolas)
    {
        this.id_album = id_album;
        this.path = path;
        this.name = name;
        this.year = year;
        this.rolas = rolas;
    }

}