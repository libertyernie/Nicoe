<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportMetaxmlForAutobootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportMetaxmlForAutobootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportBannerImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialogXml = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialogXml = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialogPng = New System.Windows.Forms.SaveFileDialog()
        Me.btnGamePathBrowse = New System.Windows.Forms.Button()
        Me.OpenFileDialogIso = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(384, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.OpenToolStripMenuItem.Text = "&Open..."
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.SaveAsToolStripMenuItem.Text = "&Save As..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportMetaxmlForAutobootToolStripMenuItem, Me.ExportMetaxmlForAutobootToolStripMenuItem, Me.ExportBannerImageToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'ImportMetaxmlForAutobootToolStripMenuItem
        '
        Me.ImportMetaxmlForAutobootToolStripMenuItem.Name = "ImportMetaxmlForAutobootToolStripMenuItem"
        Me.ImportMetaxmlForAutobootToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ImportMetaxmlForAutobootToolStripMenuItem.Text = "Import meta.xml for autoboot"
        '
        'ExportMetaxmlForAutobootToolStripMenuItem
        '
        Me.ExportMetaxmlForAutobootToolStripMenuItem.Name = "ExportMetaxmlForAutobootToolStripMenuItem"
        Me.ExportMetaxmlForAutobootToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ExportMetaxmlForAutobootToolStripMenuItem.Text = "Export meta.xml for autoboot"
        '
        'ExportBannerImageToolStripMenuItem
        '
        Me.ExportBannerImageToolStripMenuItem.Name = "ExportBannerImageToolStripMenuItem"
        Me.ExportBannerImageToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ExportBannerImageToolStripMenuItem.Text = "Export banner image"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 27)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(384, 492)
        Me.PropertyGrid1.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "bin"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "bin"
        '
        'OpenFileDialogXml
        '
        Me.OpenFileDialogXml.DefaultExt = "xml"
        Me.OpenFileDialogXml.Filter = "Homebrew Channel meta.xml files (*.xml)|*.xml"
        '
        'SaveFileDialogXml
        '
        Me.SaveFileDialogXml.DefaultExt = "xml"
        Me.SaveFileDialogXml.Filter = "Homebrew Channel meta.xml files (*.xml)|*.xml"
        '
        'SaveFileDialogPng
        '
        Me.SaveFileDialogPng.DefaultExt = "png"
        Me.SaveFileDialogPng.Filter = "Portable Network Graphics (*.png)|*.png"
        '
        'btnGamePathBrowse
        '
        Me.btnGamePathBrowse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGamePathBrowse.Location = New System.Drawing.Point(12, 525)
        Me.btnGamePathBrowse.Name = "btnGamePathBrowse"
        Me.btnGamePathBrowse.Size = New System.Drawing.Size(360, 24)
        Me.btnGamePathBrowse.TabIndex = 1
        Me.btnGamePathBrowse.Text = "Browse for game path (for autoboot)..."
        Me.btnGamePathBrowse.UseVisualStyleBackColor = True
        '
        'OpenFileDialogIso
        '
        Me.OpenFileDialogIso.Filter = "GameCube disc images (*.iso, *.gcm)|*.iso;*.gcm"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 561)
        Me.Controls.Add(Me.btnGamePathBrowse)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Nicoe"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportBannerImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportMetaxmlForAutobootToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialogXml As OpenFileDialog
    Friend WithEvents SaveFileDialogXml As SaveFileDialog
    Friend WithEvents SaveFileDialogPng As SaveFileDialog
    Friend WithEvents ImportMetaxmlForAutobootToolStripMenuItem As ToolStripMenuItem
    Private WithEvents btnGamePathBrowse As Button
    Friend WithEvents OpenFileDialogIso As OpenFileDialog
End Class
