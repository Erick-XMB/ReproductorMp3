using System.Text.Json;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

public class PersonaVista
{
    private PersonaControlador controladorPersona = new PersonaControlador();

    public void AgregarObjetoPersona(string nombreReal, string nombreArtistico, string fechaNacimiento, string fechaFallecimiento)
    {
        Person persona = new Person(nombreReal, nombreArtistico, fechaNacimiento, fechaFallecimiento);
        controladorPersona.agregarPersona(persona);
    }

    public string ObtenerPersonasJson()
    {
        List<Person> personas = controladorPersona.ObtenerTodasLasPersonas();
        var filas = new List<object>();

        foreach (Person persona in personas)
        {
            filas.Add(new
            {
                id = persona.IdPerson,
                nombre = persona.StageName
            });
        }
        return JsonSerializer.Serialize(filas);
    }
}