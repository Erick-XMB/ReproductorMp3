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
    /// guarda la informacion de cada archivo del directorio (y sus subdirectorios)en una lista de archivosMp3
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


    /// <summary>
    /// Metodo que dada la ruta de un archivo .mp3 crea un objeto de tipo
    /// DatosMp3, solamenre si tiene la etiqueta Id3v2
    /// </summary>
    /// <param name="ruta"> es la ruta del archivo .mp3 </param>
    /// <returns> un objeto de tipo DatosMp3, null en caso de no tener la etiqueta requerida </returns> <summary>
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

    /// <summary>
    /// Metodo que verifica la version de la etiqueta Id3
    /// </summary>
    /// <param name="datos"> Objeto de tipo DatosMp3 del cual verificaremos su version de etiqueta </param>
    /// <returns>true en caso de ser version 4, false en otro caso  </returns>

    public bool VerificarVersionId3(DatosMp3 datos)
    {
        return datos.VersionId3 == 4;
    }

    /// <summary>
    /// Metodo que dada una ruta, guardamos los archivos en una lista
    /// Seguido a ello, recorremos la lista creando por cada archivo un objeto de tipo DatosMp3
    /// Verificamos la version de cada objeto, y si corresponde a la requerida, lo guardamos 
    /// en una lista de datos validos, llamada datosEncontrados
    /// </summary>
    /// <param name="ruta"> es la cadena que representa la ruta del directorio </param>
    /// <returns> la lista de los objetos DatosMp3 valioos segun la especificacion </returns>

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

    /// <summary>
    /// Metodo que dada la ruta de un archivo .mp3 extrae la portada de sus metados, 
    /// esto solo si el archivo contiene una imagen en sus etiquetas
    /// </summary>
    /// <param name="ruta"> es la ruta del archivo .mp3 </param>
    /// <returns> un par ordenado con el tipo de la imagen y sus bytes, null en caso de 
    /// no tener alguna imagen asociada o un error en la lectura </returns>
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








