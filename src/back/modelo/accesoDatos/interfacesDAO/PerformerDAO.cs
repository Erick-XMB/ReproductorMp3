using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;
public interface PerformerDAO
{
    public void CreatePerformer(Performer performer);

    public Performer GetPerformer(int id_performer);

    public Performer GetPerformerPorNombre(string name);

    public void UpdatePerformer(Performer performer);

    public void DeletePerformer(int id_performer);
    
}   