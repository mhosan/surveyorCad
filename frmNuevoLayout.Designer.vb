<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoLayout
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
        Me.btnColor = New System.Windows.Forms.Button()
        Me.btnGirar = New System.Windows.Forms.Button()
        Me.cmbHoja = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbLaminas = New System.Windows.Forms.ComboBox()
        Me.txtAlto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAncho = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnColor
        '
        Me.btnColor.Image = Global.mhCad.My.Resources.Resources.color_wheel
        Me.btnColor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnColor.Location = New System.Drawing.Point(224, 147)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(44, 44)
        Me.btnColor.TabIndex = 43
        Me.btnColor.Text = "Color"
        Me.btnColor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnColor.UseVisualStyleBackColor = True
        Me.btnColor.Visible = False
        '
        'btnGirar
        '
        Me.btnGirar.Image = Global.mhCad.My.Resources.Resources.acad_rotar
        Me.btnGirar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGirar.Location = New System.Drawing.Point(170, 147)
        Me.btnGirar.Name = "btnGirar"
        Me.btnGirar.Size = New System.Drawing.Size(44, 44)
        Me.btnGirar.TabIndex = 42
        Me.btnGirar.Text = "Girar"
        Me.btnGirar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGirar.UseVisualStyleBackColor = True
        Me.btnGirar.Visible = False
        '
        'cmbHoja
        '
        Me.cmbHoja.FormattingEnabled = True
        Me.cmbHoja.Items.AddRange(New Object() {"Seleccionar un tamaño de hoja..", "A: 320 x 400 mm - 32 x 40 cm", "B: 320 x 580 mm - 32 x 58 cm", "C: 320 x 760 mm - 32 x 76 cm", "D: 320 x 940 mm - 32 x 94 cm", "E: 320 x 1120 mm - 32 x 112 cm", "F: 480 x 580 mm - 48 x 58 cm", "G: 480 x 760 mm - 48 x 76 cm", "H: 480 x 940 mm - 48 x 94 cm", "I: 480 x 1120 mm - 48 x 112 cm", "J: 640 x 760 mm - 64 x 76 cm", "K: 640 x 940 mm - 64 x 94 cm", "L: 640 x 1120 mm - 64 x 112 cm", "M: 800 x 940 mm - 80 x 94 cm", "N: 800 x 1120 mm - 80 x 112 cm", "O: 960 x 1120 mm - 96 x 112 cm", "ISO A4: 210 x 297 mm ", "ISO A3: 420 x 297 mm", "ISO A2: 430 x 594 mm", "ISO A1: 841 x 594 mm", "ISO A0: 841 x 1189 mm", "ISO B4: 250 x 353 mm", "ISO B3: 353 x 500 mm", "ISO B2: 500 x 707 mm", "ISO B1: 707 x 1000 mm", "Tamaño personal.."})
        Me.cmbHoja.Location = New System.Drawing.Point(96, 80)
        Me.cmbHoja.Name = "cmbHoja"
        Me.cmbHoja.Size = New System.Drawing.Size(173, 21)
        Me.cmbHoja.TabIndex = 41
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(136, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "mm"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "mm"
        Me.Label5.Visible = False
        '
        'cmbLaminas
        '
        Me.cmbLaminas.FormattingEnabled = True
        Me.cmbLaminas.Location = New System.Drawing.Point(148, 52)
        Me.cmbLaminas.Name = "cmbLaminas"
        Me.cmbLaminas.Size = New System.Drawing.Size(121, 21)
        Me.cmbLaminas.TabIndex = 38
        Me.cmbLaminas.Visible = False
        '
        'txtAlto
        '
        Me.txtAlto.Location = New System.Drawing.Point(80, 170)
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.Size = New System.Drawing.Size(54, 20)
        Me.txtAlto.TabIndex = 37
        Me.txtAlto.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Alto:"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Ancho:"
        Me.Label3.Visible = False
        '
        'txtAncho
        '
        Me.txtAncho.Location = New System.Drawing.Point(80, 147)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Size = New System.Drawing.Size(54, 20)
        Me.txtAncho.TabIndex = 34
        Me.txtAncho.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Tamaño lámina:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(18, 52)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(121, 20)
        Me.txtNombre.TabIndex = 32
        Me.txtNombre.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Nombre de la lámina:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(161, 207)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 20)
        Me.btnCancelar.TabIndex = 30
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(56, 207)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 20)
        Me.btnOk.TabIndex = 29
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmNuevoLayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.btnGirar)
        Me.Controls.Add(Me.cmbHoja)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbLaminas)
        Me.Controls.Add(Me.txtAlto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAncho)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNuevoLayout"
        Me.Text = "Láminas (layout)"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents btnGirar As System.Windows.Forms.Button
    Friend WithEvents cmbHoja As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbLaminas As System.Windows.Forms.ComboBox
    Friend WithEvents txtAlto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAncho As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
