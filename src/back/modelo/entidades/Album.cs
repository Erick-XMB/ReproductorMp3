namespace ReproductorMp3.modelo.entidades;

public class Album
{
    private int id_album;
    public int IdAlbum
    {
        get { return id_album; }
        set { id_album = value; }
    }

    private string path;
    public string Path
    {
        get { return path; }
        set { path = value; }
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int year;
    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    private List<Rola> rolas;
    public List<Rola> Rolas
    {
        get { return rolas; }
        set { rolas = value; }
    }


    public Album(int id_album, string path, string name, int year, List<Rola> rolas)
    {
        this.id_album = id_album;
        this.path = path;
        this.name = name;
        this.year = year;
        this.rolas = rolas;
    }

    public Album(int id_album, string path, string name, int year)
    {
        this.id_album = id_album;
        this.path = path;
        this.name = name;
        this.year = year;
    }

    public Album(int id_album)
    {
        this.id_album = id_album;

    }

}