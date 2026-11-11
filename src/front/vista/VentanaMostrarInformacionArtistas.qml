import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia


Window {
    id: ventanaMostrarInformacionArtistas
    title: "Seleccionar para mostrar información"
    width: 500
    height: 150
    color: "#121212"

    ColumnLayout {
        id: columnLayoutMostrarInfo
        anchors.fill: parent
        spacing: 0

        Rectangle {
            id: rectangle1MostrarInfo
            color: "#181818"
            Layout.fillHeight: true
            Layout.fillWidth: true

            ColumnLayout{
                anchors.fill:  parent
                anchors.margins: 16
                spacing: 12


                GridLayout {
                    id: gridLayoutMostrarInfo
                    Layout.fillWidth: true
                    columns: 1
                    columnSpacing: 16
                    rowSpacing: 8

                    Button {
                        id: buttonMostrarAlbumnes
                        text: "Albums"
                        Layout.fillWidth: true

                        background: Rectangle {
                            radius: 6
                            color: buttonMostrarAlbumnes.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        }

                        onClicked: {
                            ventanaMostarInformacionAlbums.show()
                            ventanaMostarInformacionAlbums.cargarTodasLosAlbumsALaTabla()
                            ventanaMostrarInformacionArtistas.close()
                        }
                    }

                    Button {
                        id: buttonMostrarPersonas
                        text: "Personas"
                        Layout.fillWidth: true

                        background: Rectangle {
                            radius: 6
                            color: buttonMostrarPersonas.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        }

                        onClicked: {
                            ventanaMostrarInformacionPersonas.show()
                            ventanaMostrarInformacionPersonas.cargarTodasLasPersonasALaTabla()
                            ventanaMostrarInformacionArtistas.close()
                        }
                    }

                    Button {
                        id: buttonMostrarGrupos
                        text: "Grupos"
                        Layout.fillWidth: true

                        background: Rectangle {
                            radius: 6
                            color: buttonMostrarGrupos.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                        }

                        onClicked: {
                            ventanaMostrarInformacionGrupos.show()
                            ventanaMostrarInformacionGrupos.cargarTodasLosGruposALaTabla()
                            ventanaMostrarInformacionArtistas.close()
                        }
                    }


                }
            }
        }
    }
}