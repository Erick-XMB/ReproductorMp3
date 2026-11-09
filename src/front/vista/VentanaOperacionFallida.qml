import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

Window {
    id: ventanaOperacionFallida
    title: "Operación Fallida"
    width: 400
    height: 80
    color: "#121212"

    ColumnLayout {
        id: columnLayoutOperacionFallida
        anchors.fill: parent
        spacing: 0

        Rectangle {
            id: rectangle1OperacionFallida
            color: "#181818"
            Layout.fillHeight: true
            Layout.fillWidth: true

            ColumnLayout {
                anchors.centerIn: parent
                spacing: 16

                Label {
                    id: labelOperacionFallida
                    Layout.alignment:  Qt.AlignHCenter
                    text: "!! Hubo un error en la operación !!"
                    font.bold: true
                    font.pixelSize: 15
                }

                Button {
                    id: buttonOperacionFallida
                    Layout.alignment: Qt.AlignHCenter
                    text: "Volver"
                    onClicked: ventanaOperacionFallida.close()

                    background: Rectangle {
                        radius: 6
                        color: buttonOperacionFallida.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                    }
                }
            }
        }
    }
}