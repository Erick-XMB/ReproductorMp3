using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;
public interface RolaDAO
{
    public void CreateRola(Rola rola);

    public Rola GetRola(int id_rola);

    public Rola GetRolaPorRuta(string path);

    public void UpdateRola(Rola rola);

    public void DeleteRola(int id_rola);
    
}   