namespace ReproductorMp3.modelo;

public class Rola
{
    private int id_rola;
    public int IdRola
    {
        get { return id_rola; }
        set { id_rola = value; }
    }
    
    private Album album;
    public Album Album
    {
        get { return album; }
        set { album = value; }
    }
    
    private Performer performer;
    public Performer Performer
    {
        get { return performer; }
        set { performer = value; }
    }
    
    private string path;
    public string Path
    {
        get { return path; }
        set { path = value; }
    }
    
    private string title;
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    
    private int track;
    public int Track
    {
        get { return track; }
        set { track = value; }
    }
    
    private int year;
    public int Year
    {
        get { return year; }
        set { year = value; }
    }
    
    private string genre;
    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }
    

    public Rola(int id_rola, Album album, Performer performer, string path, string title, int track, int year, string genre)
    {
        this.id_rola = id_rola;
        this.album = album;
        this.performer = performer;
        this.path = path;
        this.title = title;
        this.track = track;
        this.year = year;
        this.genre = genre;
    }
}