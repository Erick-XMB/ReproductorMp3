import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

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

                     Label {
                         id: switchTitulo
                         text: "Titulo"
                     }

                     TextField {
                         id: textoTitulo
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar titulo...")

                     }

                     Label {
                         id: switchArtista
                         text: "Artista"
                     }

                     TextField {
                         id: textoArtista
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar artista...")
                     }

                     Label {
                         id: switchAlbum
                         text: "Album"
                     }

                     TextField {
                         id: textoAlbum
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar album...")
                     }

                     Label {
                         id: switchAño
                         text: "Año"
                     }

                     TextField {
                         id: textoAño
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar año...")
                     }

                     Label {
                         id: switchGenero
                         text: "Género"
                     }

                     TextField {
                         id: textoGenero
                         Layout.fillWidth: true
                         placeholderText: qsTr("Ingresar genero...")
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