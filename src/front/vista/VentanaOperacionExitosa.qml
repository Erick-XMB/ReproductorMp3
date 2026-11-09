import QtQuick
import QtQuick.Layouts
import QtQuick.Controls.Basic
import QtQuick.Controls 2.15
import QtQuick.Dialogs
import Qt.labs.qmlmodels
import QtMultimedia

Window {
    id: ventanaOperacionExitosa
    title: "Operación exitosa"
    width: 400
    height: 80
    color: "#121212"

    ColumnLayout {
        id: columnLayoutOperacionExitosa
        anchors.fill: parent
        spacing: 0

        Rectangle {
            id: rectangle1OperacionExitosa
            color: "#181818"
            Layout.fillHeight: true
            Layout.fillWidth: true

            ColumnLayout {
                anchors.centerIn: parent
                spacing: 16

                Label {
                    id: labelOperacionExitosa
                    Layout.alignment:  Qt.AlignHCenter
                    text: "!! La operación fue exitosa !!"
                    font.bold: true
                    font.pixelSize: 15
                }

                Button {
                    id: buttonOperacionExitosa
                    Layout.alignment: Qt.AlignHCenter
                    text: "Volver"
                    onClicked: ventanaOperacionExitosa.close()

                    background: Rectangle {
                        radius: 6
                        color: buttonOperacionExitosa.down ? Qt.darker("#2f7d5b", 1.2) : "#2f7d5b"
                    }
                }
            }
        }
    }
}