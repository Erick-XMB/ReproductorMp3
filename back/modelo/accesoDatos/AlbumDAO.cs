using ReproductorMp3.modelo;
namespace ReproductorMp3.accesoDatos;
public interface AlbumDAO
{
    public void CreateAlbum(Album album);

    public Album GetAlbum(int id_album);

    public void UpdateAlbum(Album album);

    public void DeleteAlbum(int id_album);
    
}   