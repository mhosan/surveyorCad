<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguraImpresion
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.btnPuntas = New System.Windows.Forms.Button()
        Me.btnImpresora = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAncho = New System.Windows.Forms.TextBox()
        Me.txtAlto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmbHoja = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbApaisado = New System.Windows.Forms.RadioButton()
        Me.rbVertical = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDerecha = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAbajo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIzquierda = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtArriba = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(408, 157)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'btnPuntas
        '
        Me.btnPuntas.Location = New System.Drawing.Point(12, 52)
        Me.btnPuntas.Name = "btnPuntas"
        Me.btnPuntas.Size = New System.Drawing.Size(67, 23)
        Me.btnPuntas.TabIndex = 1
        Me.btnPuntas.Text = "Puntas"
        Me.btnPuntas.UseVisualStyleBackColor = True
        '
        'btnImpresora
        '
        Me.btnImpresora.Location = New System.Drawing.Point(12, 15)
        Me.btnImpresora.Name = "btnImpresora"
        Me.btnImpresora.Size = New System.Drawing.Size(67, 23)
        Me.btnImpresora.TabIndex = 2
        Me.btnImpresora.Text = "Impresora"
        Me.btnImpresora.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtAncho)
        Me.GroupBox1.Controls.Add(Me.txtAlto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.cmbHoja)
        Me.GroupBox1.Location = New System.Drawing.Point(93, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 135)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tamaño hoja"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Alto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(96, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Ancho"
        '
        'txtAncho
        '
        Me.txtAncho.Enabled = False
        Me.txtAncho.Location = New System.Drawing.Point(134, 98)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Size = New System.Drawing.Size(47, 20)
        Me.txtAncho.TabIndex = 9
        '
        'txtAlto
        '
        Me.txtAlto.Enabled = False
        Me.txtAlto.Location = New System.Drawing.Point(34, 98)
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.Size = New System.Drawing.Size(47, 20)
        Me.txtAlto.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(184, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "(mm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Tamaño personal"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 66)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmbHoja
        '
        Me.cmbHoja.FormattingEnabled = True
        Me.cmbHoja.Items.AddRange(New Object() {"Seleccionar un tamaño de hoja..", "A: 320 x 400 mm - 32 x 40 cm", "B: 320 x 580 mm - 32 x 58 cm", "C: 320 x 760 mm - 32 x 76 cm", "D: 320 x 940 mm - 32 x 94 cm", "E: 320 x 1120 mm - 32 x 112 cm", "F: 480 x 580 mm - 48 x 58 cm", "G: 480 x 760 mm - 48 x 76 cm", "H: 480 x 940 mm - 48 x 94 cm", "I: 480 x 1120 mm - 48 x 112 cm", "J: 640 x 760 mm - 64 x 76 cm", "K: 640 x 940 mm - 64 x 94 cm", "L: 640 x 1120 mm - 64 x 112 cm", "M: 800 x 940 mm - 80 x 94 cm", "N: 800 x 1120 mm - 80 x 112 cm", "O: 960 x 1120 mm - 96 x 112 cm", "ISO A4: 210 x 297 mm ", "ISO A3: 297 x420 mm", "ISO A2: 430 x 594 mm", "ISO A1: 594 x 841 mm", "ISO A0: 841 x 1189 mm", "ISO B4: 250 x 353 mm", "ISO B3: 353 x 500 mm", "ISO B2: 500 x 707 mm", "ISO B1: 707 x 1000 mm"})
        Me.cmbHoja.Location = New System.Drawing.Point(15, 18)
        Me.cmbHoja.Name = "cmbHoja"
        Me.cmbHoja.Size = New System.Drawing.Size(171, 21)
        Me.cmbHoja.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbApaisado)
        Me.GroupBox2.Controls.Add(Me.rbVertical)
        Me.GroupBox2.Location = New System.Drawing.Point(332, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(219, 47)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Orientación"
        '
        'rbApaisado
        '
        Me.rbApaisado.AutoSize = True
        Me.rbApaisado.Checked = True
        Me.rbApaisado.Location = New System.Drawing.Point(118, 18)
        Me.rbApaisado.Name = "rbApaisado"
        Me.rbApaisado.Size = New System.Drawing.Size(69, 17)
        Me.rbApaisado.TabIndex = 1
        Me.rbApaisado.TabStop = True
        Me.rbApaisado.Text = "Apaisado"
        Me.rbApaisado.UseVisualStyleBackColor = True
        '
        'rbVertical
        '
        Me.rbVertical.AutoSize = True
        Me.rbVertical.Location = New System.Drawing.Point(32, 18)
        Me.rbVertical.Name = "rbVertical"
        Me.rbVertical.Size = New System.Drawing.Size(60, 17)
        Me.rbVertical.TabIndex = 0
        Me.rbVertical.Text = "Vertical"
        Me.rbVertical.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtDerecha)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtAbajo)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtIzquierda)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtArriba)
        Me.GroupBox3.Location = New System.Drawing.Point(332, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(219, 78)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Márgenes en mm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(110, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Derecha"
        '
        'txtDerecha
        '
        Me.txtDerecha.Location = New System.Drawing.Point(160, 42)
        Me.txtDerecha.Name = "txtDerecha"
        Me.txtDerecha.Size = New System.Drawing.Size(47, 20)
        Me.txtDerecha.TabIndex = 6
        Me.txtDerecha.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Abajo"
        '
        'txtAbajo
        '
        Me.txtAbajo.Location = New System.Drawing.Point(160, 16)
        Me.txtAbajo.Name = "txtAbajo"
        Me.txtAbajo.Size = New System.Drawing.Size(47, 20)
        Me.txtAbajo.TabIndex = 4
        Me.txtAbajo.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Izquierda"
        '
        'txtIzquierda
        '
        Me.txtIzquierda.Location = New System.Drawing.Point(59, 42)
        Me.txtIzquierda.Name = "txtIzquierda"
        Me.txtIzquierda.Size = New System.Drawing.Size(47, 20)
        Me.txtIzquierda.TabIndex = 2
        Me.txtIzquierda.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Arriba"
        '
        'txtArriba
        '
        Me.txtArriba.Location = New System.Drawing.Point(59, 16)
        Me.txtArriba.Name = "txtArriba"
        Me.txtArriba.Size = New System.Drawing.Size(47, 20)
        Me.txtArriba.TabIndex = 0
        Me.txtArriba.Text = "0"
        '
        'frmConfiguraImpresion
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(566, 198)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnImpresora)
        Me.Controls.Add(Me.btnPuntas)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfiguraImpresion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configurar impresión"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents btnPuntas As System.Windows.Forms.Button
    Friend WithEvents btnImpresora As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbHoja As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbApaisado As System.Windows.Forms.RadioButton
    Friend WithEvents rbVertical As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtArriba As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDerecha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAbajo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIzquierda As System.Windows.Forms.TextBox
    Friend WithEvents txtAlto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAncho As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
