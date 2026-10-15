using ReproductorMp3.modelo;
namespace ReproductorMp3.accesoDatos;
public interface RolaDAO
{
    public void CreateRola(Rola rola);

    public Rola GetRola(int id_rola);

    public void UpdateRola(Rola rola);

    public void DeleteRola(int id_rolas);
    
}   