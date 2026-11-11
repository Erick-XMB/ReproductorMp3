 import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

 Window {
    id: ventanaMostrarInformacionAlbums
    title: "Información de Albums"
    width: 800
    height: 450
    color: "#121212"

    function cargarTodasLosAlbumsALaTabla(){
        myModelAlbums.clear()
        var filas = JSON.parse(albumVista.obtenerTodosLosAlbumsJson())

        for(var i = 0; i < filas.length; i++){
            myModelAlbums.appendRow(filas[i])
        }
    }



    Rectangle {
        id: rectangle3Albums
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
                id: rectangle1InfoAlbums
                width: 200
                height: 200
                color: "#121212"
                Layout.fillHeight: true
                Layout.fillWidth: true
                

                ColumnLayout{
                    anchors.fill: parent
                    spacing: 0

                    HorizontalHeaderView{
                        id: encabezadoDatosAlbums

                        Layout.fillWidth: true

                        syncView: tableviewAlbums
                        clip: true
                        model: ["#", "Nombre", "Año"]

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
                        id: tableviewAlbums
                        Layout.fillHeight: true
                        Layout.fillWidth: true
                        clip: true
                        columnSpacing: 1
                        rowSpacing: 1

                        columnWidthProvider: function(column) {
                            let proportions = [0.10, 0.70, 0.20]
                            return (width - columnSpacing * (columns - 1))
                                   * proportions[column]
                        }

                        model: TableModel{
                            id: myModelAlbums

                            TableModelColumn { display: "No" }
                            TableModelColumn { display: "Nombre"}
                            TableModelColumn { display: "Año" }
                        }

                        delegate: Rectangle {
                            implicitHeight: 40
                            color: "#282828"
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
        }
    }
}