import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia
 
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
                        placeholderText: qsTr("dd/mm/yyyy")
                    }

                    Label {
                        id: labelFechaMuerte
                        text: "Fecha de muerte"
                    }

                    TextField {
                        id: textoFechaMuerte
                        Layout.fillWidth: true
                        placeholderText: qsTr("dd/mm/yyyy")
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
                                var operacionExitosa = personaVista.agregarObjetoPersona(textoNombreReal.text, textoNombreArtistico.text, textoFechaNacimiento.text, textoFechaMuerte.text)
                                ventanaAgregarNuevaPersona.close()

                                if(operacionExitosa){
                                    ventanaOperacionExitosa.show()
                                    textoNombreReal.clear()
                                    textoNombreArtistico.clear()
                                    textoFechaNacimiento.clear()
                                    textoFechaMuerte.clear()
                                } else{
                                    ventanaOperacionFallida.show()
                                    textoNombreReal.clear()
                                    textoNombreArtistico.clear()
                                    textoFechaNacimiento.clear()
                                    textoFechaMuerte.clear()
                                }
                            }
                        }
                    }
                }
            }
        }
    }
   }