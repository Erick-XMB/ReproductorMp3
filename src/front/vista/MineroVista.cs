using ReproductorMp3.controlador;

/// <summary>
/// Clase que representa la vista del minero del reproductor de musica
/// Sirve como puente entre el controlador y la GUI en QML
/// </summary>
public class MineroVista
{   
    // Atributo de tipo MineroControlador para poder acceder a la logica del minero 
    private MineroControlador controlador = new MineroControlador();

    /// <summary>
    /// Metodo que dada la ruta de un directorio, mina
    /// los archivos .mp3 que contiene y los guarda en la base de datos 
    /// </summary>
    /// <param name="ruta"></param>
    /// <returns> un entero con el numero de rolas guardadas </returns>
    public int MinarYGuardar(string ruta)
    {
        return controlador.MinarYGuardar(ruta);
    }
}