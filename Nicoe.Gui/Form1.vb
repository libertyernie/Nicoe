Imports System.IO

Public Class Form1
    Private ReadOnly ConfigurationWrapper As New NintendontConfiguration()

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        PropertyGrid1.SelectedObject = ConfigurationWrapper
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        PropertyGrid1.Refresh()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        ConfigurationWrapper.Reset()
        PropertyGrid1.Refresh()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            Using fs As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
                ConfigurationWrapper.Load(fs)
                PropertyGrid1.Refresh()
            End Using
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            File.WriteAllBytes(SaveFileDialog1.FileName, ConfigurationWrapper.Export())
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Nicoe (Nintendont Configuration Editor)
© 2017-2021 libertyernie
https://github.com/libertyernie/nicoe

Includes code from Nintendont
© 2014-2021 Nintendont contributors
https://github.com/FIX94/Nintendont")
    End Sub
End Class
