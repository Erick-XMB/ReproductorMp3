using System.Text.Json;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

/// <summary>
/// Clase que representa la vista de las personas en el reproductor
/// Sirve de puente entre el controlador y la GUI en QML.
/// </summary>
public class PersonaVista
{   
    // Atributo de tipo PersonaControlador para poder acceder a la logica de las personas
    private PersonaControlador controladorPersona = new PersonaControlador();

    /// <summary>
    /// Metodo que dados los datos de una persona, crea un objeto
    /// de tipo Person y lo guarda en la base de datos
    /// </summary>
    /// <param name="nombreReal"> es el nombre real de la persona </param>
    /// <param name="nombreArtistico"> es el nombre artistico de la persona </param>
    /// <param name="fechaNacimiento"> es la fehca de nacimiento de la persona </param>
    /// <param name="fechaFallecimiento"> es la fecha de nacimiento de la persona </param>
    public bool AgregarObjetoPersona(string nombreReal, string nombreArtistico, string fechaNacimiento, string fechaFallecimiento)
    {
        Person persona = new Person(nombreReal, nombreArtistico, fechaNacimiento, fechaFallecimiento);
        return controladorPersona.agregarPersona(persona);
    }

    /// <summary>
    /// Metodo que recupera todas las personas de la base de datos
    /// </summary>
    /// <returns> una cadena JSON con la lista de personas, solo
    /// su id y su nombre artistico </returns>
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

    public string ObtenerTodasLasPersonasJson()
    {
        List<Person> personas = controladorPersona.ObtenerTodasLasPersonas();
        var filas = new List<object>();

        foreach (Person persona in personas)
        {
            filas.Add(new
            {
                No = persona.IdPerson,
                Nombre_real = persona.RealName,
                Nombre_artistico = persona.StageName,
                Fecha_de_nacimiento = persona.BirthDate,
                Fecha_de_muerte = persona.DeathDate
            });
        }
        return JsonSerializer.Serialize(filas);
    }
}