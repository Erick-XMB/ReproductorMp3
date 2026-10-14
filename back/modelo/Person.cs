namespace ReproductorMp3.modelo;

public class Person : Performer
{   
    private int id_person;
    private string stage_name;
    private string real_name;
    private string birth_date;
    private string death_date;
    public Person(int id_person, string stage_name, string real_name, string birth_date, string death_date)
    {
        this.id_person = id_person;
        this.stage_name = stage_name;
        this.real_name = real_name;
        this.birth_date = birth_date;
        this.death_date = death_date;   
    }
}