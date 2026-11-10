 import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

 Window {
    id: ventanaMostrarInformacionPersonas
    title: "Información de Personas"
    width: 650
    height: 450
    color: "#121212"

    function cargarTodasLasPersonasALaTabla(){
        myModelPersonas.clear()
        var filas = JSON.parse(personaVista.obtenerTodasLasPersonasJson())

        for(var i = 0; i < filas.length; i++){
            myModelPersonas.appendRow(filas[i])
        }
    }

    Rectangle {
        id: rectangle3Personas
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
                id: rectangle1InforPersonas
                width: 200
                height: 200
                color: "#121212"
                Layout.fillHeight: true
                Layout.fillWidth: true
                

                ColumnLayout{
                    anchors.fill: parent
                    spacing: 0

                    HorizontalHeaderView{
                        id: encabezadoDatosPersona

                        Layout.fillWidth: true

                        syncView: tableviewPersonas
                        clip: true
                        model: ["#", "Nombre real", "Nombre artistico", "Fecha de Nacimiento", "Fecha de muerte"]

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
                        id: tableviewPersonas
                        Layout.fillHeight: true
                        Layout.fillWidth: true
                        clip: true
                        columnSpacing: 1
                        rowSpacing: 1

                        columnWidthProvider: function(column) {
                            let proportions = [0.08, 0.23, 0.23, 0.23, 0.23]
                            return (width - columnSpacing * (columns - 1))
                                   * proportions[column]
                        }

                        model: TableModel{
                            id: myModelPersonas

                            TableModelColumn { display: "No" }
                            TableModelColumn { display: "Nombre_real"}
                            TableModelColumn { display: "Nombre_artistico" }
                            TableModelColumn { display: "Fecha_de_nacimiento" }
                            TableModelColumn { display: "Fecha_de_muerte" }
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