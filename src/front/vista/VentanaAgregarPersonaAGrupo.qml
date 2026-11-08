import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

Window {
   id: ventanaAgregarPersonaAGrupo
   title: "Agregar persona a grupo"
   width: 500
   height: 450
   color: "#121212"

   onVisibleChanged: {
       if (visible) cargarTodasPersonas()
       if (visible) cargarTodosGrupos()
   }

   ColumnLayout {
       id: columnLayoutNuevoPersonaGrupo
       anchors.fill: parent
       spacing: 0

       Rectangle {
           id: encabezadoAgregarPersonaGrupo
           color: "#4a9272"
           Layout.fillWidth: true
           Layout.preferredHeight: 36

           Label {
               id: labelAgregarGrupo
               anchors.centerIn: parent
               text: "Agregar nueva persona a grupo"
               font.bold: true
           }
       }

       Rectangle {
           id: rectangle1PersonaGrupo
           color: "#181818"
           Layout.fillHeight: true
           Layout.fillWidth: true

           ColumnLayout{
               anchors.fill:  parent
               anchors.margins: 16
               spacing: 12

               RowLayout {
                   id: rowLayoutPersonaGrupo 
                    Layout.fillWidth: true
                    Layout.fillHeight: true
                    spacing: 12


                   ColumnLayout {
                        spacing: 8
                        Layout.alignment: Qt.AlignVCenter

                   Label {
                       id: labelNombreDePersona
                       text: "Persona"
                       font.bold: true
                       Layout.alignment: Qt.AlignHCenter
                   }

                   Rectangle {
                       id: rectanglePersonaGrupo
                       Layout.fillWidth: true
                       Layout.preferredWidth: 150
                       Layout.preferredHeight: 150
                       color: "#282828"
                       clip: true

                       Text {
                           text: "👤"
                           font.pixelSize: 130
                           anchors.horizontalCenter: parent.horizontalCenter
                           anchors.bottom: parent.bottom
                           anchors.bottomMargin: -20
                       }
                   }

                   ComboBox {
                       id: comboNombreDePersona
                       textRole: "nombre"
                       valueRole: "id" 
                       model: []            
                       Layout.preferredWidth: 150
                       Layout.fillWidth: true
                   }
               }

               Label {
                   id: labelFlecha
                   text: "\u2794"
                   font.pixelSize: 58
                   color: "white"
                   Layout.alignment: Qt.AlignVCenter
               }

               ColumnLayout {
                   spacing: 8
                   Layout.alignment: Qt.AlignVCenter
                   Layout.fillWidth: true

                   Label {
                       id: labelNombrDeGrupo
                       text: "Grupo"
                       font.bold: true
                       Layout.alignment: Qt.AlignHCenter
                   }

                   Rectangle {
                       id: rectanglePersonaGrupo1
                       Layout.fillWidth: true
                       Layout.preferredWidth: 150
                       Layout.preferredHeight: 150
                       color: "#282828"
                       clip: true

                       Text {
                           text: "👥"
                           font.pixelSize: 130
                           anchors.horizontalCenter: parent.horizontalCenter
                           anchors.bottom: parent.bottom
                           anchors.bottomMargin: -20
                       }
                   }

                   ComboBox {
                       id: comboNombreDeGrupo
                       textRole: "nombre"
                       valueRole: "id" 
                       model: []            
                       Layout.preferredWidth: 150
                       Layout.fillWidth: true
                   }
               }
               }

               RowLayout {
                    Layout.fillWidth: true
                    Layout.alignment: Qt.AlignRight
                   spacing: 12

                   Button {
                       id: botonCancelarPersonaGrupo
                       text: qsTr("Cancelar")
                       onClicked: ventanaAgregarPersonaAGrupo.close()
                   }

                   Button {
                       id: botonAceptarPersonaGrupo
                       text: qsTr("Aceptar")
                       onClicked: {
                            grupoVista.agregarIntegranteAGrupo(comboNombreDePersona.currentValue, comboNombreDeGrupo.currentValue)
                            ventanaAgregarPersonaAGrupo.close()
                       }
                   }
               }
           }
       }
   }
}