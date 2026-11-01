using ReproductorMp3.controlador;

public class MineroVista
{
    private MineroControlador controlador = new MineroControlador();

    public int MinarYGuardar(string ruta)
    {
        return controlador.MinarYGuardar(ruta);
    }
}