<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEspacioCirculatorio
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtAnchoEspacioCirculatorio = New System.Windows.Forms.TextBox()
        Me.TxtNombreEspacioCirculatorio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnAceptarEspacioCirculatorio = New System.Windows.Forms.Button()
        Me.BtnCancelarEspacioCirculatorio = New System.Windows.Forms.Button()
        Me.LblLado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(118, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "mts"
        '
        'TxtAnchoEspacioCirculatorio
        '
        Me.TxtAnchoEspacioCirculatorio.Location = New System.Drawing.Point(54, 78)
        Me.TxtAnchoEspacioCirculatorio.Name = "TxtAnchoEspacioCirculatorio"
        Me.TxtAnchoEspacioCirculatorio.Size = New System.Drawing.Size(58, 20)
        Me.TxtAnchoEspacioCirculatorio.TabIndex = 19
        Me.TxtAnchoEspacioCirculatorio.Text = "30"
        Me.TxtAnchoEspacioCirculatorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNombreEspacioCirculatorio
        '
        Me.TxtNombreEspacioCirculatorio.Location = New System.Drawing.Point(54, 45)
        Me.TxtNombreEspacioCirculatorio.Name = "TxtNombreEspacioCirculatorio"
        Me.TxtNombreEspacioCirculatorio.Size = New System.Drawing.Size(223, 20)
        Me.TxtNombreEspacioCirculatorio.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Ancho"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Calle"
        '
        'BtnAceptarEspacioCirculatorio
        '
        Me.BtnAceptarEspacioCirculatorio.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BtnAceptarEspacioCirculatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptarEspacioCirculatorio.Location = New System.Drawing.Point(154, 113)
        Me.BtnAceptarEspacioCirculatorio.Name = "BtnAceptarEspacioCirculatorio"
        Me.BtnAceptarEspacioCirculatorio.Size = New System.Drawing.Size(80, 30)
        Me.BtnAceptarEspacioCirculatorio.TabIndex = 21
        Me.BtnAceptarEspacioCirculatorio.Text = "Aceptar"
        Me.BtnAceptarEspacioCirculatorio.UseVisualStyleBackColor = False
        '
        'BtnCancelarEspacioCirculatorio
        '
        Me.BtnCancelarEspacioCirculatorio.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BtnCancelarEspacioCirculatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarEspacioCirculatorio.Location = New System.Drawing.Point(56, 113)
        Me.BtnCancelarEspacioCirculatorio.Name = "BtnCancelarEspacioCirculatorio"
        Me.BtnCancelarEspacioCirculatorio.Size = New System.Drawing.Size(80, 30)
        Me.BtnCancelarEspacioCirculatorio.TabIndex = 22
        Me.BtnCancelarEspacioCirculatorio.Text = "Cancelar"
        Me.BtnCancelarEspacioCirculatorio.UseVisualStyleBackColor = False
        '
        'LblLado
        '
        Me.LblLado.AutoSize = True
        Me.LblLado.Location = New System.Drawing.Point(51, 13)
        Me.LblLado.Name = "LblLado"
        Me.LblLado.Size = New System.Drawing.Size(0, 13)
        Me.LblLado.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Lado: "
        '
        'frmEspacioCirculatorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(290, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblLado)
        Me.Controls.Add(Me.BtnCancelarEspacioCirculatorio)
        Me.Controls.Add(Me.BtnAceptarEspacioCirculatorio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtAnchoEspacioCirculatorio)
        Me.Controls.Add(Me.TxtNombreEspacioCirculatorio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEspacioCirculatorio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingrese datos del espacio circulatorio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtAnchoEspacioCirculatorio As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombreEspacioCirculatorio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnAceptarEspacioCirculatorio As System.Windows.Forms.Button
    Friend WithEvents BtnCancelarEspacioCirculatorio As System.Windows.Forms.Button
    Friend WithEvents LblLado As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
