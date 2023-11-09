<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguraCursor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.color1 = New System.Windows.Forms.PictureBox()
        Me.color2 = New System.Windows.Forms.PictureBox()
        Me.color3 = New System.Windows.Forms.PictureBox()
        Me.color4 = New System.Windows.Forms.PictureBox()
        Me.color5 = New System.Windows.Forms.PictureBox()
        Me.color6 = New System.Windows.Forms.PictureBox()
        Me.color7 = New System.Windows.Forms.PictureBox()
        Me.color8 = New System.Windows.Forms.PictureBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblColorCaja = New System.Windows.Forms.Label()
        Me.rbCursor = New System.Windows.Forms.RadioButton()
        Me.rbCaja = New System.Windows.Forms.RadioButton()
        Me.lblColorCursor = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.color1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.color2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.color3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.color4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.color5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.color6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.color7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.color8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tamaño del cursor:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(242, 10)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(52, 20)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'color1
        '
        Me.color1.Image = Global.mhCad.My.Resources.Resources.color_1
        Me.color1.Location = New System.Drawing.Point(7, 175)
        Me.color1.Name = "color1"
        Me.color1.Size = New System.Drawing.Size(16, 16)
        Me.color1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.color1.TabIndex = 4
        Me.color1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.color1, "Color 1 - Rojo")
        '
        'color2
        '
        Me.color2.Image = Global.mhCad.My.Resources.Resources.color_2
        Me.color2.Location = New System.Drawing.Point(46, 175)
        Me.color2.Name = "color2"
        Me.color2.Size = New System.Drawing.Size(16, 16)
        Me.color2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.color2.TabIndex = 5
        Me.color2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.color2, "Color 2 - Amarillo")
        '
        'color3
        '
        Me.color3.Image = Global.mhCad.My.Resources.Resources.color_3
        Me.color3.Location = New System.Drawing.Point(85, 175)
        Me.color3.Name = "color3"
        Me.color3.Size = New System.Drawing.Size(16, 16)
        Me.color3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.color3.TabIndex = 6
        Me.color3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.color3, "Color 3 - Verde")
        '
        'color4
        '
        Me.color4.Image = Global.mhCad.My.Resources.Resources.color_4
        Me.color4.Location = New System.Drawing.Point(124, 175)
        Me.color4.Name = "color4"
        Me.color4.Size = New System.Drawing.Size(16, 16)
        Me.color4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.color4.TabIndex = 7
        Me.color4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.color4, "Color 4 - Cyan")
        '
        'color5
        '
        Me.color5.Image = Global.mhCad.My.Resources.Resources.color_5
        Me.color5.Location = New System.Drawing.Point(163, 175)
        Me.color5.Name = "color5"
        Me.color5.Size = New System.Drawing.Size(16, 16)
        Me.color5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.color5.TabIndex = 8
        Me.color5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.color5, "Color 5 - Azul")
        '
        'color6
        '
        Me.color6.Image = Global.mhCad.My.Resources.Resources.color_6
        Me.color6.Location = New System.Drawing.Point(202, 175)
        Me.color6.Name = "color6"
        Me.color6.Size = New System.Drawing.Size(16, 16)
        Me.color6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.color6.TabIndex = 9
        Me.color6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.color6, "Color 6 - Magenta")
        '
        'color7
        '
        Me.color7.Image = Global.mhCad.My.Resources.Resources.color_7
        Me.color7.Location = New System.Drawing.Point(241, 175)
        Me.color7.Name = "color7"
        Me.color7.Size = New System.Drawing.Size(16, 16)
        Me.color7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.color7.TabIndex = 10
        Me.color7.TabStop = False
        Me.ToolTip1.SetToolTip(Me.color7, "Color 7 - Blanco")
        '
        'color8
        '
        Me.color8.Image = Global.mhCad.My.Resources.Resources.color_8
        Me.color8.Location = New System.Drawing.Point(280, 175)
        Me.color8.Name = "color8"
        Me.color8.Size = New System.Drawing.Size(16, 16)
        Me.color8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.color8.TabIndex = 11
        Me.color8.TabStop = False
        Me.ToolTip1.SetToolTip(Me.color8, "Color 8 - Negro")
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(165, 206)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 20)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(60, 206)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 20)
        Me.btnOk.TabIndex = 12
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblColorCaja, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.rbCursor, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbCaja, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblColorCursor, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(7, 112)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(289, 57)
        Me.TableLayoutPanel1.TabIndex = 25
        '
        'lblColorCaja
        '
        Me.lblColorCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblColorCaja.Location = New System.Drawing.Point(147, 29)
        Me.lblColorCaja.Name = "lblColorCaja"
        Me.lblColorCaja.Size = New System.Drawing.Size(139, 28)
        Me.lblColorCaja.TabIndex = 16
        Me.lblColorCaja.Text = ".."
        Me.lblColorCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbCursor
        '
        Me.rbCursor.AutoSize = True
        Me.rbCursor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbCursor.Location = New System.Drawing.Point(3, 3)
        Me.rbCursor.Name = "rbCursor"
        Me.rbCursor.Size = New System.Drawing.Size(138, 23)
        Me.rbCursor.TabIndex = 0
        Me.rbCursor.TabStop = True
        Me.rbCursor.Text = "Color cursor"
        Me.rbCursor.UseVisualStyleBackColor = True
        '
        'rbCaja
        '
        Me.rbCaja.AutoSize = True
        Me.rbCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbCaja.Location = New System.Drawing.Point(147, 3)
        Me.rbCaja.Name = "rbCaja"
        Me.rbCaja.Size = New System.Drawing.Size(139, 23)
        Me.rbCaja.TabIndex = 1
        Me.rbCaja.TabStop = True
        Me.rbCaja.Text = "Color caja"
        Me.rbCaja.UseVisualStyleBackColor = True
        '
        'lblColorCursor
        '
        Me.lblColorCursor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblColorCursor.Location = New System.Drawing.Point(3, 29)
        Me.lblColorCursor.Name = "lblColorCursor"
        Me.lblColorCursor.Size = New System.Drawing.Size(138, 28)
        Me.lblColorCursor.TabIndex = 15
        Me.lblColorCursor.Text = ".."
        Me.lblColorCursor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(243, 53)
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(52, 20)
        Me.NumericUpDown2.TabIndex = 27
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Tamaño de la caja (Mínimo = 1, máximo = 100) :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 12)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Mínimo: 1, máximo: 100, valor inicial: 3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 12)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Mínimo: 1, máximo: 100, valor inicial: 10"
        '
        'frmConfiguraCursor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 234)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.color8)
        Me.Controls.Add(Me.color7)
        Me.Controls.Add(Me.color6)
        Me.Controls.Add(Me.color5)
        Me.Controls.Add(Me.color4)
        Me.Controls.Add(Me.color3)
        Me.Controls.Add(Me.color2)
        Me.Controls.Add(Me.color1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConfiguraCursor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurar cursor"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.color1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.color2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.color3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.color4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.color5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.color6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.color7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.color8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents color1 As System.Windows.Forms.PictureBox
    Friend WithEvents color2 As System.Windows.Forms.PictureBox
    Friend WithEvents color3 As System.Windows.Forms.PictureBox
    Friend WithEvents color4 As System.Windows.Forms.PictureBox
    Friend WithEvents color5 As System.Windows.Forms.PictureBox
    Friend WithEvents color6 As System.Windows.Forms.PictureBox
    Friend WithEvents color7 As System.Windows.Forms.PictureBox
    Friend WithEvents color8 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbCursor As System.Windows.Forms.RadioButton
    Friend WithEvents rbCaja As System.Windows.Forms.RadioButton
    Friend WithEvents lblColorCaja As System.Windows.Forms.Label
    Friend WithEvents lblColorCursor As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
