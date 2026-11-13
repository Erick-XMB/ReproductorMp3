Proyecto Reproductor MP3 MYP
========================
Proyecto número 2 de la materia modelado y programación, que implementa unreproductor mp3 donde principalmente se involucrá el tema de bases de datos.

Comandos sistemas de construccion
-------------

Los comandos para compilar y ejecutar el backend son:

* make back
* make runBack 

Los comandos para compilar y ejecutar el frontend son:

* make front
* make runFront

Los comando para generar la documentación y para verla como página web respectivamente son:

* make docs
* make servidorDocs

Comandos extra para la limpieza de archivos
* make limpiarBack
* make limpiarFront
* make limpiarDocs
* make clean


Teconologias utilizadas en el proyecto
-------------------
Desarrollado y probado en Ubuntu 24.04 con version de glibc 2.39

- El proyecto se desarrollo principalmente en el lenguaje C#
- sqlite3 3.45.1
- .NET SDK 10.0.114
- cmake version 3.28.3
- g++ (Ubuntu 13.3.0-6ubuntu2~24.04.1) 13.3.0
- ninja --version 1.11.1

- Qt 6.12.0 
Por defecto el proyecto busca Qt en (HOME)/Qt/6.12.0/gcc_64, si se tiene instalado en otra ruta, la modificación se hace sobre el archivo vista.csproj

Para identiicar la ubicación ejecutar:

```bash
find ~/Qt -name Qt6Config.cmake
``` 

Obtendremos algo simliar a:
```bash
/home/killomanlinux/Qt/6.12.0/gcc_64/lib/cmake/Qt6/Qt6Config.cmake
```
Quitamos la parte de la instalación, por ejemplo: 

```bash
/lib/cmake/Qt6/Qt6Config.cmake
``` 

y quedarnos con el restante, por ejemplo: 

```bash
/home/killomanlinux/Qt/6.12.0/gcc_64.
```

Es dicho directorio el cual se deberá de sustituir en QtDir condition en el archivo vista.csproj

- DocFX 2.80.1 para la documentacion
- libgl1-mesa-dev  
- libxkbcommon-dev
- libxcb-cursor0

En caso de requerir instalar las librerias usar el comando: 
```bash
sudo apt install libgl1-mesa-dev libxkbcommon-dev libxcb-cursor0
```



Desarrollador
---------
* Erick Xavier Martinez Briones
* No cuenta = 426007742
* Correo electronico = erick.martinezkmn@ciencias.unam.mx

