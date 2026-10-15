using ReproductorMp3.modelo;
namespace ReproductorMp3.accesoDatos;
public interface PersonDAO
{
    public void CreatePerson(Person person);

    public Person GetPerson(int id_person);

    public void UpdatePerson(Person person);

    public void DeletePerson(int id_person);
    
}   