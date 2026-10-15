using ReproductorMp3.modelo;
namespace ReproductorMp3.accesoDatos;
public interface GroupDAO
{
    public void CreateGroup(Group group);

    public Group GetGroup(int id_group);

    public void UpdateGroup(Group group);

    public void DeleteGroup(int id_group);
    
}   