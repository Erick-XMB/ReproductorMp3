namespace ReproductorMp3.modelo;

public class Rola
{
    private int id_rola;
    private Album album;
    private Performer performer;
    private string path;
    private string title;
    private int track;
    private int year;
    private string genre;

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