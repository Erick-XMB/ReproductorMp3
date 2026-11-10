 import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

 Window {
    id: ventanaMostrarInformacionGrupos
    title: "Información de Grupos"
    width: 650
    height: 450
    color: "#121212"

    function cargarTodasLosGruposALaTabla(){
        myModelGrupos.clear()
        var filas = JSON.parse(grupoVista.obtenerTodosLosGruposJson())

        for(var i = 0; i < filas.length; i++){
            myModelGrupos.appendRow(filas[i])
        }
    }


    Rectangle {
        id: rectangle3Grupos
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
                id: rectangle1InfoGrupos
                width: 200
                height: 200
                color: "#121212"
                Layout.fillHeight: true
                Layout.fillWidth: true
                

                ColumnLayout{
                    anchors.fill: parent
                    spacing: 0

                    HorizontalHeaderView{
                        id: encabezadoDatosGrupos

                        Layout.fillWidth: true

                        syncView: tableviewGrupos
                        clip: true
                        model: ["#", "Nombre", "Integrantes", "Fecha de inicio", "Fecha de termino"]

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
                        id: tableviewGrupos
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
                            id: myModelGrupos

                            TableModelColumn { display: "No" }
                            TableModelColumn { display: "Nombre"}
                            TableModelColumn { display: "Integrantes" }
                            TableModelColumn { display: "Fecha_de_inicio" }
                            TableModelColumn { display: "Fecha_de_termino" }
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