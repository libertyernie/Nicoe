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
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportMetaxmlForAutobootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportMetaxmlForAutobootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportBannerImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportBannerImagepadTo128x48ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NINCFGV10ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NINCFGv9ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NINCFGV8ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 24)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(384, 511)
        Me.PropertyGrid1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button3, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 535)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(384, 26)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Location = New System.Drawing.Point(131, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 20)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Browse for CheatPath"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 20)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Browse for GamePath"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.Location = New System.Drawing.Point(259, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 20)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Set to read from disc"
        Me.Button3.UseVisualStyleBackColor = True
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
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NINCFGV10ToolStripMenuItem, Me.NINCFGv9ToolStripMenuItem, Me.NINCFGV8ToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenToolStripMenuItem.Text = "&Open..."
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveAsToolStripMenuItem.Text = "&Save As..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportMetaxmlForAutobootToolStripMenuItem, Me.ExportMetaxmlForAutobootToolStripMenuItem, Me.ExportBannerImageToolStripMenuItem, Me.ExportBannerImagepadTo128x48ToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'ImportMetaxmlForAutobootToolStripMenuItem
        '
        Me.ImportMetaxmlForAutobootToolStripMenuItem.Name = "ImportMetaxmlForAutobootToolStripMenuItem"
        Me.ImportMetaxmlForAutobootToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.ImportMetaxmlForAutobootToolStripMenuItem.Text = "Import meta.xml for autoboot"
        '
        'ExportMetaxmlForAutobootToolStripMenuItem
        '
        Me.ExportMetaxmlForAutobootToolStripMenuItem.Name = "ExportMetaxmlForAutobootToolStripMenuItem"
        Me.ExportMetaxmlForAutobootToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.ExportMetaxmlForAutobootToolStripMenuItem.Text = "Export meta.xml for autoboot"
        '
        'ExportBannerImageToolStripMenuItem
        '
        Me.ExportBannerImageToolStripMenuItem.Name = "ExportBannerImageToolStripMenuItem"
        Me.ExportBannerImageToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.ExportBannerImageToolStripMenuItem.Text = "Export banner image"
        '
        'ExportBannerImagepadTo128x48ToolStripMenuItem
        '
        Me.ExportBannerImagepadTo128x48ToolStripMenuItem.Name = "ExportBannerImagepadTo128x48ToolStripMenuItem"
        Me.ExportBannerImagepadTo128x48ToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.ExportBannerImagepadTo128x48ToolStripMenuItem.Text = "Export banner image (pad to 128x48)"
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
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
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
        'NINCFGV10ToolStripMenuItem
        '
        Me.NINCFGV10ToolStripMenuItem.Name = "NINCFGV10ToolStripMenuItem"
        Me.NINCFGV10ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NINCFGV10ToolStripMenuItem.Text = "&NIN_CFG v10"
        '
        'NINCFGv9ToolStripMenuItem
        '
        Me.NINCFGv9ToolStripMenuItem.Name = "NINCFGv9ToolStripMenuItem"
        Me.NINCFGv9ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NINCFGv9ToolStripMenuItem.Text = "NIN_CFG v&9"
        '
        'NINCFGV8ToolStripMenuItem
        '
        Me.NINCFGV8ToolStripMenuItem.Name = "NINCFGV8ToolStripMenuItem"
        Me.NINCFGV8ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NINCFGV8ToolStripMenuItem.Text = "NIN_CFG v&8"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 561)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Nicoe"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportMetaxmlForAutobootToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportMetaxmlForAutobootToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportBannerImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Button2 As Button
    Friend WithEvents ExportBannerImagepadTo128x48ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button3 As Button
    Friend WithEvents NINCFGV10ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NINCFGv9ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NINCFGV8ToolStripMenuItem As ToolStripMenuItem
End Class
