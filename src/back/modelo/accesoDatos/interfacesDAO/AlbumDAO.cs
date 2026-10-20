using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;

public interface AlbumDAO
{
    public void CreateAlbum(Album album);

    public Album GetAlbum(int id_album);

    public Album GetAlbumPorNombreYRuta(string name, string ruta);

    public void UpdateAlbum(Album album);

    public void DeleteAlbum(int id_album);

}