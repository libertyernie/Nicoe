﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.OpenFileDialogIso = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 24)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(384, 511)
        Me.PropertyGrid1.TabIndex = 1
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
        'OpenFileDialogIso
        '
        Me.OpenFileDialogIso.Filter = "GameCube disc images (*.iso, *.gcm)|*.iso;*.gcm"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 535)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(384, 26)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 20)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Browse for GamePath"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
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
    Friend WithEvents OpenFileDialogIso As OpenFileDialog
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Button1 As Button
End Class
