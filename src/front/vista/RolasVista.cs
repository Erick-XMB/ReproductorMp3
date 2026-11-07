using System.Text.Json;
using ReproductorMp3.controlador;
using ReproductorMp3.modelo.entidades;

public class RolasVista
{
    private RolasControlador controladorRolas = new RolasControlador();

    public string ObtenerRolasJson()
    {
        List<Rola> rolas = controladorRolas.ObtenerRolas();
        var filas = new List<object>();

        foreach (Rola rola in rolas)
        {
            filas.Add(new
            {
                No = rola.IdRola,
                Nombre = rola.Title,
                Artista = rola.Performer.Name,
                Album = rola.Album.Name,
                Genero = rola.Genre,
                Anio = rola.Year,
                Ruta = rola.Path
            });
        }
        return JsonSerializer.Serialize(filas);
    }

    public string ObtenerPortadaArchivo(string ruta)
    {
        var portada = controladorRolas.ObtenerPortada(ruta);

        if(portada == null)
        {
            return "";
        }

        string base64 = Convert.ToBase64String(portada.Value.datos);
        return $"data:{portada.Value.TipoImagen};base64,{base64}";
    }

}