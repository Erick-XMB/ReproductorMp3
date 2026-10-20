using ReproductorMp3.modelo.entidades;
namespace ReproductorMp3.modelo.accesoDatos.interfacesDAO;
public interface GroupDAO
{
    public void CreateGroup(Group group);

    public Group GetGroup(int id_group);

    public void UpdateGroup(Group group);

    public void DeleteGroup(int id_group);
    
}   