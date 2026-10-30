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
                }

                Button {
                    id: botonMenu
                    x: 8
                    y: 6
                    width: 35
                    height: 34
                    text: "\u26cf"
                    onClicked: menu.open()

                    background: Rectangle {
                        radius: 6
                        color: botonMenu.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                    }
                }

                Button {
                    id: buscadorFiltrar
                    x: 49
                    y: 6
                    width: 35
                    height: 34
                    text: "\u23da"
                    background: Rectangle {
                        color: buscadorFiltrar.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        radius: 6
                    }
                    onClicked: ventanaBuscar.show()
                }
            }

            Rectangle {
                id: rectangle1
                width: 200
                height: 200
                color: "#121212"
                Layout.fillHeight: true
                Layout.fillWidth: true
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
                            text: "\u25b6"
                        }

                        RoundButton {
                            id: roundButton2
                            text: "\u23ed"
                        }
                    }

                    Item { Layout.fillHeight: true }

                    Slider {
                        id: slider
                        value: 0.5
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
                    }

                    Button {
                        id: botonAceptar
                        text: "Aceptar"
                    }

                }
            }
        }
    }

    }

}
