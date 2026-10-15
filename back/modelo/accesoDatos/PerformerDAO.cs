using ReproductorMp3.modelo;
namespace ReproductorMp3.accesoDatos;
public interface PerformerDAO
{
    public void CreatePerformer(Performer performer);

    public Performer GetPerformer(int id_performer);

    public void UpdatePerformer(Performer performer);

    public void DeletePerformer(int id_performer);
    
}   