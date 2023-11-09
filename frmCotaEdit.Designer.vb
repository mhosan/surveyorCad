<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotaEdit
    Inherits frmPropiedades 'System.Windows.Forms.Form

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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cajaTexto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cajaPrefijo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cajaSufijo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cajaAlturaTexto = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtNinguno = New System.Windows.Forms.RadioButton()
        Me.rbtSobrerayado = New System.Windows.Forms.RadioButton()
        Me.rbtSubrayado = New System.Windows.Forms.RadioButton()
        Me.btnCambiarCota = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(155, 240)
        Me.btnCancelar.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(50, 240)
        Me.btnAceptar.Visible = False
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(49, 265)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 20)
        Me.btnOk.TabIndex = 31
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnRechazar
        '
        Me.btnRechazar.Location = New System.Drawing.Point(156, 265)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(80, 20)
        Me.btnRechazar.TabIndex = 32
        Me.btnRechazar.Text = "Cancelar"
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Texto"
        '
        'cajaTexto
        '
        Me.cajaTexto.Enabled = False
        Me.cajaTexto.Location = New System.Drawing.Point(71, 134)
        Me.cajaTexto.Name = "cajaTexto"
        Me.cajaTexto.Size = New System.Drawing.Size(69, 20)
        Me.cajaTexto.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Prefijo"
        '
        'cajaPrefijo
        '
        Me.cajaPrefijo.Location = New System.Drawing.Point(71, 159)
        Me.cajaPrefijo.Name = "cajaPrefijo"
        Me.cajaPrefijo.Size = New System.Drawing.Size(69, 20)
        Me.cajaPrefijo.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Sufijo"
        '
        'cajaSufijo
        '
        Me.cajaSufijo.Location = New System.Drawing.Point(71, 184)
        Me.cajaSufijo.Name = "cajaSufijo"
        Me.cajaSufijo.Size = New System.Drawing.Size(69, 20)
        Me.cajaSufijo.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Altura texto"
        '
        'cajaAlturaTexto
        '
        Me.cajaAlturaTexto.Location = New System.Drawing.Point(71, 209)
        Me.cajaAlturaTexto.Name = "cajaAlturaTexto"
        Me.cajaAlturaTexto.Size = New System.Drawing.Size(69, 20)
        Me.cajaAlturaTexto.TabIndex = 40
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtNinguno)
        Me.GroupBox1.Controls.Add(Me.rbtSobrerayado)
        Me.GroupBox1.Controls.Add(Me.rbtSubrayado)
        Me.GroupBox1.Location = New System.Drawing.Point(170, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(95, 71)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'rbtNinguno
        '
        Me.rbtNinguno.AutoSize = True
        Me.rbtNinguno.Location = New System.Drawing.Point(7, 49)
        Me.rbtNinguno.Name = "rbtNinguno"
        Me.rbtNinguno.Size = New System.Drawing.Size(65, 17)
        Me.rbtNinguno.TabIndex = 2
        Me.rbtNinguno.TabStop = True
        Me.rbtNinguno.Text = "Ninguno"
        Me.rbtNinguno.UseVisualStyleBackColor = True
        '
        'rbtSobrerayado
        '
        Me.rbtSobrerayado.AutoSize = True
        Me.rbtSobrerayado.Location = New System.Drawing.Point(7, 30)
        Me.rbtSobrerayado.Name = "rbtSobrerayado"
        Me.rbtSobrerayado.Size = New System.Drawing.Size(85, 17)
        Me.rbtSobrerayado.TabIndex = 1
        Me.rbtSobrerayado.TabStop = True
        Me.rbtSobrerayado.Text = "Sobrerayado"
        Me.rbtSobrerayado.UseVisualStyleBackColor = True
        '
        'rbtSubrayado
        '
        Me.rbtSubrayado.AutoSize = True
        Me.rbtSubrayado.Location = New System.Drawing.Point(7, 11)
        Me.rbtSubrayado.Name = "rbtSubrayado"
        Me.rbtSubrayado.Size = New System.Drawing.Size(76, 17)
        Me.rbtSubrayado.TabIndex = 0
        Me.rbtSubrayado.TabStop = True
        Me.rbtSubrayado.Text = "Subrayado"
        Me.rbtSubrayado.UseVisualStyleBackColor = True
        '
        'btnCambiarCota
        '
        Me.btnCambiarCota.Location = New System.Drawing.Point(143, 131)
        Me.btnCambiarCota.Name = "btnCambiarCota"
        Me.btnCambiarCota.Size = New System.Drawing.Size(24, 24)
        Me.btnCambiarCota.TabIndex = 42
        Me.btnCambiarCota.Text = "..."
        Me.btnCambiarCota.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'frmCotaEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 289)
        Me.Controls.Add(Me.btnCambiarCota)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cajaAlturaTexto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cajaSufijo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cajaPrefijo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cajaTexto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnRechazar)
        Me.Controls.Add(Me.btnOk)
        Me.Name = "frmCotaEdit"
        Me.Text = "frmCotaEdit"
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.btnRechazar, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cajaTexto, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cajaPrefijo, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.cajaSufijo, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cajaAlturaTexto, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.lblColor, 0)
        Me.Controls.SetChildIndex(Me.lblLayer, 0)
        Me.Controls.SetChildIndex(Me.lblTipoLinea, 0)
        Me.Controls.SetChildIndex(Me.btnCambiarCota, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cajaTexto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cajaPrefijo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cajaSufijo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cajaAlturaTexto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtSobrerayado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSubrayado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNinguno As System.Windows.Forms.RadioButton
    Friend WithEvents btnCambiarCota As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
