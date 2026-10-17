using TagLib;

string rutaMp3 = "/home/killomanlinux/Documentos/modelado&programacion/musica/Ven Aqui.mp3";
var archivo = TagLib.File.Create(rutaMp3);

Console.WriteLine(archivo.Tag.Title);
Console.WriteLine(archivo.Tag.FirstPerformer);
Console.WriteLine(archivo.Tag.Album);
Console.WriteLine(archivo.Tag.Year);
Console.WriteLine(archivo.Tag.Genres);