Imports System.IO
Imports System.Xml.Serialization
Imports Nicoe.AutoBootFork
Imports Nicoe.BannerExtraction

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

    Private Sub ImportMetaxmlForAutobootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportMetaxmlForAutobootToolStripMenuItem.Click
        If OpenFileDialogXml.ShowDialog(Me) = DialogResult.OK Then
            Using fs As New FileStream(OpenFileDialogXml.FileName, FileMode.Open, FileAccess.Read)
                Dim xml = CType(New XmlSerializer(GetType(MetaXml)).Deserialize(fs), MetaXml)
                Dim base64 = xml?.Arguments?.FirstOrDefault()
                If base64 Is Nothing Then
                    MsgBox("Could not find a base-64-encoded nincfg.dat in the first argument in meta.xml.")
                Else
                    Dim data = Convert.FromBase64String(base64)
                    ConfigurationWrapper.Load(data)
                    PropertyGrid1.Refresh()
                End If
            End Using
        End If
    End Sub

    Private Async Sub ExportMetaxmlForAutobootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportMetaxmlForAutobootToolStripMenuItem.Click
        Try
            MsgBox("This feature requires a modified build of Nintendont that can read the base64-encoded contents of a nincfg.bin file from a command-line argument.")
            Dim bnr = Await Banner.ExportGameCubeBanner(ConfigurationWrapper.GamePath)
            If SaveFileDialogXml.ShowDialog(Me) = DialogResult.OK Then
                If Not ConfigurationWrapper.AUTO_BOOT Then
                    Dim result = MsgBox("Auto boot is off. Would you like to turn it on?", MsgBoxStyle.YesNoCancel)
                    If result = MsgBoxResult.Cancel Then
                        Return
                    ElseIf result = MsgBoxResult.Ok Then
                        ConfigurationWrapper.AUTO_BOOT = True
                        PropertyGrid1.Refresh()
                    End If
                End If

                Dim meta As New MetaXml With {
                    .Version = 1,
                    .Name = bnr.GameLong,
                    .Coder = bnr.DeveloperLong,
                    .ShortDescription = "",
                    .LongDescription = bnr.DescriptionString,
                    .NoIosReload = True,
                    .AhbAccess = True,
                    .Arguments = New String() {Convert.ToBase64String(ConfigurationWrapper.Export())}
                }

                Using sw As New StringWriter()
                    Dim serializer As New XmlSerializer(GetType(MetaXml))
                    serializer.Serialize(sw, meta)
                    File.WriteAllText(SaveFileDialogXml.FileName, sw.ToString())
                End Using
            End If
        Catch ex As Exception
            MsgBox($"Could not export GameCube banner data due to an unknown error. ({ex.GetType().Name}: {ex.Message})")
        End Try
    End Sub

    Private Async Sub ExportBannerImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportBannerImageToolStripMenuItem.Click
        Try
            Dim bnr = Await Banner.ExportGameCubeBanner(ConfigurationWrapper.GamePath)
            Dim image = bnr.GetImage()
            If SaveFileDialogPng.ShowDialog() = DialogResult.OK Then
                image.Save(SaveFileDialogPng.FileName)
            End If
        Catch ex As Exception
            MsgBox($"Could not export GameCube banner data due to an unknown error. ({ex.GetType().Name}: {ex.Message})")
        End Try
    End Sub
End Class
