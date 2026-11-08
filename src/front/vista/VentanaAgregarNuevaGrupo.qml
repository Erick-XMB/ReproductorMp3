import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

Window {
   id: ventanaAgregarNuevaGrupo
   title: "Nuevo grupo"
   width: 450
   height: 480
   color: "#121212"

   ColumnLayout {
       id: columnLayoutNuevoGrupo
       anchors.fill: parent
       spacing: 0

       Rectangle {
           id: encabezadoAgregarGrupo
           color: "#4a9272"
           Layout.fillWidth: true
           Layout.preferredHeight: 36

           Label {
               id: labelAgregarGrupo
               anchors.centerIn: parent
               text: "Agregar nuevo grupo"
               font.bold: true
           }
       }

       Rectangle {
           id: rectangle1Grupo
           color: "#181818"
           Layout.fillHeight: true
           Layout.fillWidth: true

           ColumnLayout{
               anchors.fill:  parent
               anchors.margins: 16
               spacing: 12

               Rectangle {
                   id: rectangleGrupo
                   Layout.preferredWidth: 150
                   Layout.preferredHeight: 150
                   Layout.alignment: Qt.AlignHCenter
                   color: "#282828"
                   clip: true

                   Text{
                       text: "👥"
                       font.pixelSize: 130
                       anchors.horizontalCenter: parent.horizontalCenter
                       anchors.bottom: parent.bottom
                       anchors.bottomMargin: -20
                   }
               }


               GridLayout {
                   id: gridLayoutGrupo
                   Layout.fillWidth: true
                   columns: 2
                   columnSpacing: 16
                   rowSpacing: 8

                   Label {
                       id: labelNombreGrupo
                       text: "Nombre*"
                   }

                   TextField {
                       id: textoNombreGrupo
                       Layout.fillWidth: true
                       placeholderText: qsTr("Ingresar nombre...")
                   }

                   Label {
                       id: labelFechaInicio
                       text: "Fecha de inicio*"
                   }

                   TextField {
                       id: textoFechaInicio
                       Layout.fillWidth: true
                       placeholderText: qsTr("Ingresar fecha de inicio...")
                   }

                   Label {
                       id: labelFechaTermino
                       text: "Fecha de término"
                   }

                   TextField {
                       id: textoFechaTermino
                       Layout.fillWidth: true
                       placeholderText: qsTr("Ingresar fecha de término...")
                   }

                   RowLayout {
                       Layout.columnSpan: 2
                       Layout.alignment: Qt.AlignRight
                       spacing: 6

                       Button {
                           id: botonCancelarNuevoGrupo
                           text: "Cancelar"
                           onClicked: ventanaAgregarNuevaGrupo.close()
                       }

                       Button {
                           id: botonAceptarNuevoGrupo
                           text: "Aceptar"
                           onClicked: {
                                grupoVista.agregarObjetoGrupo(textoNombreGrupo.text, textoFechaInicio.text, textoFechaTermino.text)
                                ventanaAgregarNuevaGrupo.close()
                           }
                       }
                   }

               }
           }
       }
   }
}