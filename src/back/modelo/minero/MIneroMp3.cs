namespace ReproductorMp3.modelo.minero;

using ReproductorMp3.modelo.entidades;
using TagLib;

/// <summary>
/// Clase que representa el Minero del sistema
/// Contiene la logica por la cual accedemos y guardamos
/// los metadatos de cada archivo
/// </summary>
public class MineroMp3
{
    /// <summary>
    /// Metodo que dada una cadena que reprsenta la ruta de un directorio
    /// guarda la informacion de cada archivo del directorio en una lista de archivosMp3
    /// </summary>
    /// <param name="ruta"> representa el directorio del cual queremos 
    /// guardar sus archivos mp3 </param>
    /// <returns> regresa una lista con la informacion en cadena
    /// de los archivos con  terminacion .mp3 </returns>
    public List<string> GuardarArchivosMp3(string ruta)
    {
        List<string> archivosMp3 = new List<string>();

        foreach (string archivo in Directory.GetFiles(ruta, "*.mp3", SearchOption.AllDirectories))
        {
            archivosMp3.Add(archivo);
        }
        return archivosMp3;
    }

    public DatosMp3? AnalizarArchivoMp3(string ruta)
    {
        var archivo = TagLib.File.Create(ruta);
        var etiquetaId3 = archivo.GetTag(TagLib.TagTypes.Id3v2, false) as TagLib.Id3v2.Tag;

        if (etiquetaId3 == null)
        {
            return null;
        }

        return new DatosMp3(archivo.Tag.Track, archivo.Tag.Title, archivo.Tag.FirstPerformer, archivo.Tag.Album, archivo.Tag.Year, archivo.Tag.Genres, ruta, etiquetaId3.Version);
    }

    public bool VerificarVersionId3(DatosMp3 datos)
    {
        return datos.VersionId3 == 4;
    }

    public List<DatosMp3> MinarDirectorio(string ruta)
    {
        List<DatosMp3> datosEncontrados = new List<DatosMp3>();

        List<string> archivosMp3 = GuardarArchivosMp3(ruta);

        foreach (string archivo in archivosMp3)
        {
            DatosMp3? datosMp3 = AnalizarArchivoMp3(archivo);

            if (datosMp3 == null)
            {
                continue;
            }

            datosEncontrados.Add(datosMp3);
        }
        return datosEncontrados;
    }

    public (string TipoImagen, byte[] Datos)? ObtenerPortada(string ruta)
    {
        try
        {
            using var archivo = TagLib.File.Create(ruta);

            if(archivo.Tag.Pictures.Length == 0)
            {
                return null;
            }

            TagLib.IPicture portada = archivo.Tag.Pictures[0];

            string tipoImagen = string.IsNullOrEmpty(portada.MimeType) ? "image/jpeg" : portada.MimeType;
            return (tipoImagen, portada.Data.Data);

        } catch (Exception)
        {
            return null;
        }
    }
}








