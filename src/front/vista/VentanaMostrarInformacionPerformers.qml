 import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

 Window {
    id: ventanaMostrarInformacionPerformers
    title: "Información de intérpretes"
    width: 800
    height: 450
    color: "#121212"

    function cargarTodasLosPerformersALaTabla(){
        myModelPerformers.clear()
        var filas = JSON.parse(performerVista.obtenerTodosLosPerformersJson())

        for(var i = 0; i < filas.length; i++){
            myModelPerformers.appendRow(filas[i])
        }
    }


    Rectangle {
        id: rectangle3Performer
        anchors.fill: parent
        anchors.leftMargin: 0
        anchors.rightMargin: 0
        anchors.topMargin: 0
        anchors.bottomMargin: 0
        color: "#121212"

        ColumnLayout {
            id: columnLayoutPerformer
            anchors.fill: parent

            Rectangle {
                id: rectangle1InfoPerformer
                width: 200
                height: 200
                color: "#121212"
                Layout.fillHeight: true
                Layout.fillWidth: true
                

                ColumnLayout{
                    anchors.fill: parent
                    spacing: 0

                    HorizontalHeaderView{
                        id: encabezadoDatosPerformer

                        Layout.fillWidth: true

                        syncView: tableviewPerformers
                        clip: true
                        model: ["#", "Nombre", "Tipo"]

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
                        id: tableviewPerformers
                        Layout.fillHeight: true
                        Layout.fillWidth: true
                        clip: true
                        columnSpacing: 1
                        rowSpacing: 1

                        selectionModel: ItemSelectionModel {}   

                        columnWidthProvider: function(column) {
                            let proportions = [0.10, 0.70, 0.20]
                            return (width - columnSpacing * (columns - 1))
                                   * proportions[column]
                        }

                        model: TableModel{
                            id: myModelPerformers

                            TableModelColumn { display: "No" }
                            TableModelColumn { display: "Nombre"}
                            TableModelColumn { display: "Tipo" }
                        }

                        delegate: Rectangle {
                            required property int row
                            required property int column

                            implicitHeight: 40
                            color: row  === tableviewPerformers.selectionModel.currentIndex.row ? "#535353" : "#282828"
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