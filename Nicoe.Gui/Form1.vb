Imports System.IO
Imports System.Xml.Serialization
Imports Nicoe.HBC
Imports Nicoe.BannerExtraction
Imports Nicoe.Configuration

Public Class Form1
    Private LastDataLoaded As Byte() = {}

    Private Property ConfigurationWrapper As INintendontConfiguration
        Get
            Return TryCast(PropertyGrid1.SelectedObject, INintendontConfiguration)
        End Get
        Set(value As INintendontConfiguration)
            PropertyGrid1.SelectedObject = value
            LastDataLoaded = value.Export()
        End Set
    End Property

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        PropertyGrid1.SelectedObject = ConfigurationWrapper

        If My.Application.CommandLineArgs.Count = 1 Then
            LoadFile(File.ReadAllBytes(My.Application.CommandLineArgs.Single()))
        End If
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        PropertyGrid1.Refresh()
    End Sub

    Private Sub NINCFGV10ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NINCFGV10ToolStripMenuItem.Click
        ConfigurationWrapper = New V10.NintendontConfiguration()
        PropertyGrid1.Refresh()
    End Sub

    Private Sub NINCFGv9ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NINCFGv9ToolStripMenuItem.Click
        ConfigurationWrapper = New V9.NintendontConfiguration()
        PropertyGrid1.Refresh()
    End Sub

    Private Sub NINCFGV8ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NINCFGV8ToolStripMenuItem.Click
        ConfigurationWrapper = New V8.NintendontConfiguration()
        PropertyGrid1.Refresh()
    End Sub

    Private Sub LoadFile(data As Byte())
        Dim readAs = data(4) << 24 Or data(5) << 16 Or data(6) << 8 Or data(7)

        If readAs < 10 Then
            If MsgBox($"This is a version {readAs} nincfg.bin file. Would you like to update it to version 10 (used by newer builds of Nintendont)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                readAs = 10
            End If
        End If

        If readAs <= 8 Then
            ConfigurationWrapper = New V8.NintendontConfiguration()
        ElseIf readAs <= 9 Then
            ConfigurationWrapper = New V9.NintendontConfiguration()
        Else
            ConfigurationWrapper = New V10.NintendontConfiguration()
        End If
        ConfigurationWrapper.Load(data)
        LastDataLoaded = ConfigurationWrapper.Export()
        PropertyGrid1.Refresh()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Using dialog As New OpenFileDialog
            dialog.Filter = "Nintendont configuration files (*.bin)|*.bin"
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                LoadFile(File.ReadAllBytes(dialog.FileName))
            End If
        End Using
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If ConfigurationWrapper Is Nothing Then
            Return
        End If
        Using dialog As New SaveFileDialog
            dialog.Filter = "Nintendont configuration files (*.bin)|*.bin"
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                File.WriteAllBytes(dialog.FileName, ConfigurationWrapper.Export())
            End If
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Nicoe (Nintendont Configuration Editor) 10.3
© 2017-2021 libertyernie
https://github.com/libertyernie/nicoe

Includes code from Nintendont
© 2014-2021 Nintendont contributors
https://github.com/FIX94/Nintendont")
    End Sub

    Private Sub ImportMetaxmlForAutobootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportMetaxmlForAutobootToolStripMenuItem.Click
        Using dialog As New OpenFileDialog
            dialog.Filter = "Homebrew Channel meta.xml (*.xml)|*.xml"
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                Using fs As New FileStream(dialog.FileName, FileMode.Open, FileAccess.Read)
                    Dim xml = CType(New XmlSerializer(GetType(MetaXml)).Deserialize(fs), MetaXml)
                    Dim base64 = xml?.Arguments?.FirstOrDefault()
                    If base64 Is Nothing Then
                        MsgBox("Could not find a base-64-encoded nincfg.dat in the first argument in meta.xml.")
                    Else
                        Dim data = Convert.FromBase64String(base64)
                        LoadFile(data)
                    End If
                End Using
            End If
        End Using
    End Sub

    Private Async Function GetBanner() As Task(Of BNR?)
        Dim o = (ConfigurationWrapper.GamePath)

        If String.IsNullOrEmpty(ConfigurationWrapper.GamePath) Then
            Return Nothing
        ElseIf ConfigurationWrapper.GamePath = "di" Then
            Return Nothing
        End If

        Try
            Return Await Banner.ExportGameCubeBanner(ConfigurationWrapper.GamePath)
        Catch ex As Exception
            MsgBox($"Could not export GameCube banner data due to an unknown error. ({ex.GetType().Name}: {ex.Message})")
            Return Nothing
        End Try
    End Function

    Private Async Sub ExportMetaxmlForAutobootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportMetaxmlForAutobootToolStripMenuItem.Click
        If ConfigurationWrapper Is Nothing Then
            Return
        End If
        Try
            MsgBox("This feature requires a modified build of Nintendont that can read the base64-encoded contents of a nincfg.bin file from a command-line argument.")
            Dim bnr = Await GetBanner()
            Using dialog As New SaveFileDialog
                dialog.Filter = "Homebrew Channel meta.xml (*.xml)|*.xml"
                If dialog.ShowDialog(Me) = DialogResult.OK Then
                    If Not ConfigurationWrapper.AUTO_BOOT Then
                        Dim result = MsgBox("Auto boot is off. Would you like to turn it on?", MsgBoxStyle.YesNoCancel)
                        If result = MsgBoxResult.Cancel Then
                            Return
                        ElseIf result = MsgBoxResult.Yes Then
                            ConfigurationWrapper.AUTO_BOOT = True
                            PropertyGrid1.Refresh()
                        End If
                    End If

                    Dim meta As New MetaXml With {
                        .Version = 1,
                        .Name = bnr?.GameLong,
                        .Coder = bnr?.DeveloperLong,
                        .ShortDescription = "",
                        .LongDescription = bnr?.DescriptionString,
                        .NoIosReload = True,
                        .AhbAccess = True,
                        .Arguments = New String() {Convert.ToBase64String(ConfigurationWrapper.Export())}
                    }

                    Using ms As New MemoryStream()
                        Dim serializer As New XmlSerializer(GetType(MetaXml))
                        serializer.Serialize(ms, meta)
                        File.WriteAllBytes(dialog.FileName, ms.ToArray())
                    End Using
                End If
            End Using
        Catch ex As Exception
            MsgBox($"Could not export GameCube banner data due to an unknown error. ({ex.GetType().Name}: {ex.Message})")
        End Try
    End Sub

    Private Async Sub ExportBannerImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportBannerImageToolStripMenuItem.Click
        If ConfigurationWrapper Is Nothing Then
            Return
        End If
        Try
            Dim bnr = Await Banner.ExportGameCubeBanner(ConfigurationWrapper.GamePath)
            Dim image = bnr.GetImage()
            Using dialog As New SaveFileDialog
                dialog.Filter = "PNG images (*.png)|*.png"
                If dialog.ShowDialog() = DialogResult.OK Then
                    image.Save(dialog.FileName)
                End If
            End Using
        Catch ex As Exception
            MsgBox($"Could not export GameCube banner data due to an unknown error. ({ex.GetType().Name}: {ex.Message})")
        End Try
    End Sub

    Private Async Sub ExportBannerImagepadTo128x48ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportBannerImagepadTo128x48ToolStripMenuItem.Click
        If ConfigurationWrapper Is Nothing Then
            Return
        End If
        Try
            Dim bnr = Await Banner.ExportGameCubeBanner(ConfigurationWrapper.GamePath)
            Dim image1 = bnr.GetImage()
            Dim image2 As New Bitmap(128, 48)
            Using graphics = Drawing.Graphics.FromImage(image2)
                graphics.DrawImage(image1, 16, 8)
            End Using
            Using dialog As New SaveFileDialog
                dialog.Filter = "PNG images (*.png)|*.png"
                If dialog.ShowDialog() = DialogResult.OK Then
                    image2.Save(dialog.FileName)
                End If
            End Using
        Catch ex As Exception
            MsgBox($"Could not export GameCube banner data due to an unknown error. ({ex.GetType().Name}: {ex.Message})")
        End Try
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ConfigurationWrapper Is Nothing Then
            Return
        End If
        Using dialog As New OpenFileDialog
            dialog.Filter = "GameCube disc images (*.iso, *.gcm)|*.iso;*.gcm"
            If dialog.ShowDialog() = DialogResult.OK Then
                Dim path = dialog.FileName.Replace("\", "/")
                While path.Length > 0 And path(0) <> "/"c
                    path = path.Substring(1)
                End While

                ConfigurationWrapper.GamePath = path
                ConfigurationWrapper.GameID = Await Banner.ReadGameId(path)
                PropertyGrid1.Refresh()
            End If
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ConfigurationWrapper Is Nothing Then
            Return
        End If
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() = DialogResult.OK Then
                Dim path = dialog.FileName.Replace("\", "/")
                While path.Length > 0 And path(0) <> "/"c
                    path = path.Substring(1)
                End While

                ConfigurationWrapper.CheatPath = path
                PropertyGrid1.Refresh()
            End If
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ConfigurationWrapper Is Nothing Then
            Return
        End If
        ConfigurationWrapper.GamePath = "di"
        PropertyGrid1.Refresh()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ConfigurationWrapper IsNot Nothing AndAlso Not ConfigurationWrapper.Export().SequenceEqual(LastDataLoaded) Then
            Dim result = MsgBox("Save changes to this file before closing?", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Cancel Then
                e.Cancel = True
            ElseIf result = MsgBoxResult.Yes Then
                Using dialog As New SaveFileDialog
                    dialog.Filter = "Nintendont configuration files (*.bin)|*.bin"
                    If dialog.ShowDialog(Me) = DialogResult.OK Then
                        File.WriteAllBytes(dialog.FileName, ConfigurationWrapper.Export())
                    Else
                        e.Cancel = True
                    End If
                End Using
            End If
        End If
    End Sub
End Class
