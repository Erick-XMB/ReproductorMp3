 import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

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
                            color: botonAgregarPersonaAGrupo.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
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