    //ApplicationWindow {
    //id: window
    //width: 640
    //height: 480
    //visible: true
    //title: qsTr("Reproductor MP3")

import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

    ApplicationWindow {
    id: window
    width: 640
    height: 480
    visible: true
    title: qsTr("Reproductor MP3")
    property bool lightMode: Application.styleHints.colorScheme === Qt.Light
    property color reallyDark: "#1f1f1f"
    property color dark: "#262626"
    property color reallyLight: "#e7e7e7"
    property color light: "#e0e0e0"

    MineroVista{
        id: mineroVista
    }

    RolasVista{
        id: rolasVista
    }

    PersonaVista{
        id: personaVista
    }
    
    GrupoVista{
        id: grupoVista
    }

    MediaPlayer{
        id: reproductor
        audioOutput: AudioOutput { }
    }

    function cargarRolasAlMinar(){
        myModel.clear()
        var filas = JSON.parse(rolasVista.obtenerRolasJson())

        for(var i = 0; i < filas.length; i++){
            myModel.appendRow(filas[i])
        }
    }

    function cargarRolasPorPalabra(palabra){
        myModel.clear()
        var filas = JSON.parse(rolasVista.obtenerRolasPorPalabraJson(palabra))

        for(var i = 0; i < filas.length; i++){
            myModel.appendRow(filas[i])
        }
    }

    function cargarRolasPorBusquedaAvanzada(titulo, artista, album, anio, genero){
        myModel.clear()
        var objetoParametros =  rolasVista.crearObjetoDeParametrosBusquedaJson(titulo, artista, album, anio, genero)
        var filas = JSON.parse(rolasVista.obtenerRolasPorBusquedaAvanzadaJson(objetoParametros))

        for(var i = 0; i < filas.length; i++){
            myModel.appendRow(filas[i])
        }
    }

    Rectangle {
        id: rectangle3
        anchors.fill: parent
        anchors.leftMargin: 0
        anchors.rightMargin: 0
        anchors.topMargin: 0
        anchors.bottomMargin: 0
        color: "#121212"

        ColumnLayout {
            id: columnLayout
            anchors.fill: parent

            Rectangle {
                id: rectangle
                width: 200
                height: 200
                color: "#282828"
                Layout.fillWidth: true
                Layout.preferredHeight: 45

                TextField {
                    id: buscador
                    height: 28
                    anchors.verticalCenter: parent.verticalCenter
                    anchors.left: parent.left
                    anchors.leftMargin: 241
                    anchors.right: botonBuscar.left
                    anchors.rightMargin: 11
                    anchors.verticalCenterOffset: 0
                    placeholderText: qsTr("Buscar canciones, artistas o álbumes")

                    onAccepted: botonBuscar.clicked()
                }

                Button {
                    id: botonBuscar
                    x: 552
                    width: 70
                    height: 28
                    anchors.verticalCenter: parent.verticalCenter
                    anchors.right: parent.right
                    anchors.rightMargin: 18
                    text: "Buscar"

                    background: Rectangle {
                        radius: 6
                        color: botonBuscar.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                    }

                    onClicked: {
                        cargarRolasPorPalabra(buscador.text)
                    }
                }

                Button {
                    id: botonMinero
                    x: 8
                    y: 6
                    width: 35
                    height: 34
                    text: "\u26cf"
                    anchors.left: parent.left
                    anchors.margins: 10
                    onClicked: dialogoCarpeta.open()

                    background: Rectangle {
                        radius: 6
                        color: botonMinero.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                    }
                }

                FolderDialog{
                    id: dialogoCarpeta
                    options: FolderDialog.ReadOnly
                    title: "Seleccionar carpeta"
                    onAccepted: {
                        var ruta = decodeURIComponent(selectedFolder.toString().replace("file://", ""))
                        var rolasGuardadas = mineroVista.minarYGuardar(ruta);
                        cargarRolasAlMinar()
                    }
                }

                Button {
                    id: buscadorFiltrar
                    x: 49
                    y: 6
                    width: 35
                    height: 34
                    anchors.left: botonMinero.right
                    anchors.leftMargin: 7
                    text: "\u23da"
                    background: Rectangle {
                        color: buscadorFiltrar.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        radius: 6
                    }
                    onClicked: ventanaBuscar.show()
                }

                Button {
                    id: botonPerformer
                    x: 90
                    y: 6
                    width: 35
                    height: 34
                    anchors.left: buscadorFiltrar.right
                    anchors.leftMargin: 7
                    text: "🎙"
                    background: Rectangle {
                        color: botonPerformer.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        radius: 6
                    }

                    onClicked: ventanaNuevoInterprete.show()
                }
            }

         Rectangle {
                id: rectangle1
                width: 200
                height: 200
                color: "#121212"
                Layout.fillHeight: true
                Layout.fillWidth: true
                

                ColumnLayout{
                    anchors.fill: parent
                    spacing: 0

                    HorizontalHeaderView{
                        id: encabezadoDatos

                        Layout.fillWidth: true

                        syncView: tableview
                        clip: true
                        model: ["#", "Nombre", "Artista", "Album", "Genero", "Anio"]

                        delegate: Rectangle{
                            implicitHeight: 30
                            color: "#2f7d5b"
                            border.color: "Black"

                            Text{
                                text: modelData
                                color: "#B3B3B3"
                                anchors.centerIn: parent
                            }
                        }
                    }

                    TableView{
                        id: tableview
                        Layout.fillHeight: true
                        Layout.fillWidth: true
                        clip: true
                        columnSpacing: 1
                        rowSpacing: 1

                        selectionBehavior: TableView.SelectRows
                        selectionMode: TableView.SingleSelection
                        selectionModel: ItemSelectionModel{
                            
                            onCurrentChanged: function(current, previous){
                                if(current.valid){
                                    var fila = myModel.getRow(current.row)
                                    tituloCancion.text = fila.Nombre
                                    nombreArtista.text = fila.Artista
                                    reproductor.source = "file://" + fila.Ruta
                                    reproductor.play()
                                    imagenPortada.source = rolasVista.obtenerPortadaArchivo(fila.Ruta)
                                }
                            }
                        }

                        columnWidthProvider: function(column) {
                            let proportions = [0.05, 0.30, 0.20, 0.20, 0.15, 0.10]
                            return (width - columnSpacing * (columns - 1))
                                   * proportions[column]
                        }

                        model: TableModel{
                            id: myModel

                            TableModelColumn { display: "No" }
                            TableModelColumn { display: "Nombre" }
                            TableModelColumn { display: "Artista" }
                            TableModelColumn { display: "Album" }
                            TableModelColumn { display: "Genero" }
                            TableModelColumn { display: "Anio" }

                            rows: []
                        }

                        delegate: Rectangle {
                            required property int row

                            implicitHeight: 40
                            color: row  === tableview.selectionModel.currentIndex.row ? "#535353" : "#282828"
                            border.color: "Black"

                            Text {
                                text: display
                                color: "white"
                                anchors.centerIn: parent
                            }
                        }
                    }
                }
            }

            Rectangle {
                id: rectangle2
                width: 200
                height: 200
                color: "#181818"
                Layout.fillWidth: true
                Layout.preferredHeight: 140

                Rectangle {
                    id: portada
                    anchors.left: parent.left
                    anchors.margins: 12
                    height: parent.height - 24
                    width: height
                    color: "#282828"
                    anchors.verticalCenter: parent.verticalCenter
                    clip: true

                    Image{
                        id: imagenPortada
                        anchors.fill: parent
                        fillMode: Image.PreserveAspectCrop
                    }
                }

                Column {
                    id: informacion
                    width: 161
                    height: 49
                    anchors.left: portada.right
                    anchors.leftMargin: 12
                    anchors.verticalCenter: parent.verticalCenter
                    spacing: 4

                    Label {
                        id: tituloCancion
                        text: "Nombre de la canción"
                        font.pixelSize: 16
                        font.bold: true
                    }

                    Label {
                        id: nombreArtista
                        text: "Artista"
                        font.pixelSize: 16
                    }
                }

                ColumnLayout {
                    id: reproduccionControles
                    anchors.left: informacion.right
                    anchors.right: parent.right
                    anchors.top: parent.top
                    anchors.bottom: parent.bottom
                    anchors.leftMargin: 21
                    anchors.rightMargin: 20
                    anchors.topMargin: 15
                    anchors.bottomMargin: 16
                    spacing: 8

                    RowLayout {
                        Layout.alignment: Qt.AlignHCenter
                        spacing: 20

                        RoundButton {
                            id: roundButton
                            text: "\u23ee"
                        }

                        RoundButton {
                            id: roundButton1
                            text: reproductor.playbackState === MediaPlayer.PlayingState ? "❙❙" : "\u25b6"
                            onClicked: {
                                if(reproductor.playbackState === MediaPlayer.PlayingState){
                                    reproductor.pause()
                                } else {
                                    reproductor.play()
                                }
                            }
                        }

                        RoundButton {
                            id: roundButton2
                            text: "\u23ed"
                        }
                    }

                    Item { Layout.fillHeight: true }

                    Slider {
                        id: slider
                        value: 0
                        Layout.fillWidth: true
                    }

                }
            }
        }
    }

    Window{
        id: ventanaBuscar
        width: 400
        height: 360
        title: "Búsqueda avanzada"
        color: "#121212"
        visible: false

         ColumnLayout {
         id: columnLayoutVentanaBuscar
         anchors.fill: parent
         spacing: 0

         Rectangle {
             id: encabezado
             color: "#4a9272"
             Layout.fillWidth: true
             Layout.preferredHeight: 36

             Label {
                 id: label
                 anchors.centerIn: parent
                 text: "Busqueda avanzada"
                 font.bold: true
                }
            }

         Rectangle {
             id: rectangleVentanaBuscar
             color: "#181818"
             Layout.fillHeight: true
             Layout.fillWidth: true

             ColumnLayout{
                 anchors.fill:  parent
                 anchors.margins: 16
                 spacing: 12


                 GridLayout {
                     id: gridLayout
                     Layout.fillWidth: true
                     columns: 2
                     columnSpacing: 16
                     rowSpacing: 8

                     Switch {
                         id: switchTitulo
                         text: "Titulo"
                     }

                     TextField {
                         id: textoTitulo
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar titulo...")
                         enabled: switchTitulo.checked
                     }

                     Switch {
                         id: switchArtista
                         text: "Artista"
                     }

                     TextField {
                         id: textoArtista
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar artista...")
                         enabled: switchArtista.checked
                     }

                     Switch {
                         id: switchAlbum
                         text: "Album"
                     }

                     TextField {
                         id: textoAlbum
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar album...")
                         enabled: switchAlbum.checked
                     }

                     Switch {
                         id: switchAño
                         text: "Año"
                     }

                     TextField {
                         id: textoAño
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar año...")
                         enabled: switchAño.checked
                     }

                     Switch {
                         id: switchGenero
                         text: "Género"
                     }

                     TextField {
                         id: textoGenero
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar genero...")
                         enabled: switchGenero.checked
                     }

                     Button {
                         id: botonCancelar
                         text: "Cancelar"
                         onClicked: ventanaBuscar.close()
                     }

                     Button {
                         id: botonAceptar
                         text: "Aceptar"
                         onClicked: {
                             cargarRolasPorBusquedaAvanzada(textoTitulo.text, textoArtista.text, textoAlbum.text, textoAño.text, textoGenero.text)
                             ventanaBuscar.close()
                            }
                        }
                    }
                }
            }
        }   
    }

    Window {
    id: ventanaNuevoInterprete
    title: "Nuevo Interprete"
    width: 400
    height: 175
    color: "#121212"

    ColumnLayout {
        id: columnLayoutInterprete
        anchors.fill: parent
        spacing: 0

        Rectangle {
            id: encabezadoInterprete
            color: "#4a9272"
            Layout.fillWidth: true
            Layout.preferredHeight: 36

            Label {
                id: labelInterprete
                anchors.centerIn: parent
                text: "Agregar un nuevo interprete"
                font.bold: true
            }
        }

        Rectangle {
            id: rectangle1Interprete
            color: "#181818"
            Layout.fillHeight: true
            Layout.fillWidth: true

            ColumnLayout{
                anchors.fill:  parent
                anchors.margins: 16
                spacing: 12


                GridLayout {
                    id: gridLayoutInterprete
                    Layout.fillWidth: true
                    columns: 1
                    columnSpacing: 16
                    rowSpacing: 8

                    Button {
                        id: buttonAgregarPerson
                        text: "Agregar una nueva persona"
                        Layout.fillWidth: true

                        background: Rectangle {
                            radius: 6
                            color: buttonAgregarPerson.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        }

                        onClicked: {
                            ventanaAgregarNuevaPersona.show()
                            ventanaNuevoInterprete.close()
                            }
                    }

                    Button {
                        id: buttonAgregarGrupo
                        text: qsTr("Agregar un nuevo grupo")
                        Layout.fillWidth: true

                        background: Rectangle {
                            radius: 6
                            color: buttonAgregarGrupo.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        }

                        onClicked: {
                            ventanaAgregarNuevaGrupo.show()
                            ventanaNuevoInterprete.close()
                        }
                    }

                    Button {
                        id: botonAgregarPersonaAGrupo
                        text: "Agregar un nuevo integrante a un grupo"
                        Layout.fillWidth: true

                        background: Rectangle {
                            radius: 6
                            color: botonCancelar.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        }

                        onClicked:{
                            ventanaAgregarPersonaAGrupo.show()
                            ventanaNuevoInterprete.close()
                        }
                    }


                }
            }
        }
    }
  }

  Window {
    id: ventanaAgregarNuevaPersona
    title: "Agregar persona"
    width: 450
    height: 480
    color: "#121212"

    ColumnLayout {
        id: columnLayoutNuevaPersona
        anchors.fill: parent
        spacing: 0

        Rectangle {
            id: encabezadoAgregarPersona
            color: "#4a9272"
            Layout.fillWidth: true
            Layout.preferredHeight: 36

            Label {
                id: labelAgregarPersona
                anchors.centerIn: parent
                text: "Agregar nueva persona"
                font.bold: true
            }
        }

        Rectangle {
            id: rectangle1Persona
            color: "#181818"
            Layout.fillHeight: true
            Layout.fillWidth: true

            ColumnLayout{
                anchors.fill:  parent
                anchors.margins: 16
                spacing: 12

                Rectangle {
                    id: rectanglePersona
                    Layout.preferredWidth: 150
                    Layout.preferredHeight: 150
                    Layout.alignment: Qt.AlignHCenter
                    color: "#282828"
                    clip: true

                    Text{
                        text: "👤"
                        font.pixelSize: 130
                        anchors.horizontalCenter: parent.horizontalCenter
                        anchors.bottom: parent.bottom
                        anchors.bottomMargin: -20
                    }
                }


                GridLayout {
                    id: gridLayoutPersona
                    Layout.fillWidth: true
                    columns: 2
                    columnSpacing: 16
                    rowSpacing: 8

                    Label {
                        id: labelNombreReal
                        text: "Nombre real*"
                    }

                    TextField {
                        id: textoNombreReal
                        Layout.fillWidth: true
                        placeholderText: qsTr("Ingresar nombre real...")
                    }

                    Label {
                        id: labelNombreArtistico
                        text: "Nombre artistico*"
                    }

                    TextField {
                        id: textoNombreArtistico
                        Layout.fillWidth: true
                        placeholderText: qsTr("Ingresar nombre artistico...")
                    }

                    Label {
                        id: labelFechaNacimiento
                        text: "Fecha de Nacimiento*"
                    }

                    TextField {
                        id: textoFechaNacimiento
                        Layout.fillWidth: true
                        placeholderText: qsTr("Ingresar fecha de nacimiento...")
                    }

                    Label {
                        id: labelFechaMuerte
                        text: "Fecha de muerte"
                    }

                    TextField {
                        id: textoFechaMuerte
                        Layout.fillWidth: true
                        placeholderText: qsTr("Ingresar fecha de muerte...")
                    }

                    RowLayout {
                        Layout.columnSpan: 2            
                        Layout.alignment: Qt.AlignRight 
                        spacing: 6

                        Button {
                            id: botonCancelarNuevaPersona
                            text: "Cancelar"
                            onClicked: ventanaAgregarNuevaPersona.close()
                        }

                        Button {
                            id: botonAceptarNuevaPersona
                            text: "Aceptar"
                            onClicked: {
                                personaVista.agregarObjetoPersona(textoNombreReal.text, textoNombreArtistico.text, textoFechaNacimiento.text, textoFechaMuerte.text)
                                ventanaAgregarNuevaPersona.close()
                            }
                        }
                    }

                }
            }
        }
    }
   }

   Window {
   id: ventanaAgregarNuevaGrupo
   title: "Nuevo grupo"
   width: 450
   height: 480
   color: "#121212"

   ColumnLayout {
       id: columnLayoutNuevoGrupo
       anchors.fill: parent
       spacing: 0

       Rectangle {
           id: encabezadoAgregarGrupo
           color: "#4a9272"
           Layout.fillWidth: true
           Layout.preferredHeight: 36

           Label {
               id: labelAgregarGrupo
               anchors.centerIn: parent
               text: "Agregar nuevo grupo"
               font.bold: true
           }
       }

       Rectangle {
           id: rectangle1Grupo
           color: "#181818"
           Layout.fillHeight: true
           Layout.fillWidth: true

           ColumnLayout{
               anchors.fill:  parent
               anchors.margins: 16
               spacing: 12

               Rectangle {
                   id: rectangleGrupo
                   Layout.preferredWidth: 150
                   Layout.preferredHeight: 150
                   Layout.alignment: Qt.AlignHCenter
                   color: "#282828"
                   clip: true

                   Text{
                       text: "👥"
                       font.pixelSize: 130
                       anchors.horizontalCenter: parent.horizontalCenter
                       anchors.bottom: parent.bottom
                       anchors.bottomMargin: -20
                   }
               }


               GridLayout {
                   id: gridLayoutGrupo
                   Layout.fillWidth: true
                   columns: 2
                   columnSpacing: 16
                   rowSpacing: 8

                   Label {
                       id: labelNombreGrupo
                       text: "Nombre*"
                   }

                   TextField {
                       id: textoNombreGrupo
                       Layout.fillWidth: true
                       placeholderText: qsTr("Ingresar nombre...")
                   }

                   Label {
                       id: labelFechaInicio
                       text: "Fecha de inicio*"
                   }

                   TextField {
                       id: textoFechaInicio
                       Layout.fillWidth: true
                       placeholderText: qsTr("Ingresar fecha de inicio...")
                   }

                   Label {
                       id: labelFechaTermino
                       text: "Fecha de término"
                   }

                   TextField {
                       id: textoFechaTermino
                       Layout.fillWidth: true
                       placeholderText: qsTr("Ingresar fecha de término...")
                   }

                   RowLayout {
                       Layout.columnSpan: 2
                       Layout.alignment: Qt.AlignRight
                       spacing: 6

                       Button {
                           id: botonCancelarNuevoGrupo
                           text: "Cancelar"
                           onClicked: ventanaAgregarNuevaGrupo.close()
                       }

                       Button {
                           id: botonAceptarNuevoGrupo
                           text: "Aceptar"
                           onClicked: {
                                grupoVista.agregarObjetoGrupo(textoNombreGrupo.text, textoFechaInicio.text, textoFechaTermino.text)
                                ventanaAgregarNuevaGrupo.close()
                           }
                       }
                   }

               }
           }
       }
   }
}
}
