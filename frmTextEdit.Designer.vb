<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextEdit
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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lblCajaTexto = New System.Windows.Forms.Label()
        Me.cajaTexto = New System.Windows.Forms.TextBox()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudAngulo = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cajaAltura = New System.Windows.Forms.TextBox()
        Me.rtbMtext = New System.Windows.Forms.RichTextBox()
        Me.btnOkMtext = New System.Windows.Forms.Button()
        CType(Me.nudAngulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Visible = False
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(45, 189)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 20)
        Me.btnOk.TabIndex = 29
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblCajaTexto
        '
        Me.lblCajaTexto.AutoSize = True
        Me.lblCajaTexto.Location = New System.Drawing.Point(10, 85)
        Me.lblCajaTexto.Name = "lblCajaTexto"
        Me.lblCajaTexto.Size = New System.Drawing.Size(34, 13)
        Me.lblCajaTexto.TabIndex = 30
        Me.lblCajaTexto.Text = "Texto"
        '
        'cajaTexto
        '
        Me.cajaTexto.Location = New System.Drawing.Point(57, 82)
        Me.cajaTexto.Name = "cajaTexto"
        Me.cajaTexto.Size = New System.Drawing.Size(100, 20)
        Me.cajaTexto.TabIndex = 31
        Me.cajaTexto.Visible = False
        '
        'btnRechazar
        '
        Me.btnRechazar.Location = New System.Drawing.Point(159, 189)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(80, 20)
        Me.btnRechazar.TabIndex = 32
        Me.btnRechazar.Text = "Cancelar"
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Angulo"
        '
        'nudAngulo
        '
        Me.nudAngulo.Location = New System.Drawing.Point(107, 143)
        Me.nudAngulo.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.nudAngulo.Name = "nudAngulo"
        Me.nudAngulo.Size = New System.Drawing.Size(50, 20)
        Me.nudAngulo.TabIndex = 34
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Altura"
        '
        'cajaAltura
        '
        Me.cajaAltura.Location = New System.Drawing.Point(107, 164)
        Me.cajaAltura.Name = "cajaAltura"
        Me.cajaAltura.Size = New System.Drawing.Size(50, 20)
        Me.cajaAltura.TabIndex = 36
        '
        'rtbMtext
        '
        Me.rtbMtext.Location = New System.Drawing.Point(43, 81)
        Me.rtbMtext.Name = "rtbMtext"
        Me.rtbMtext.Size = New System.Drawing.Size(180, 61)
        Me.rtbMtext.TabIndex = 38
        Me.rtbMtext.Text = ""
        Me.rtbMtext.Visible = False
        '
        'btnOkMtext
        '
        Me.btnOkMtext.Location = New System.Drawing.Point(224, 118)
        Me.btnOkMtext.Name = "btnOkMtext"
        Me.btnOkMtext.Size = New System.Drawing.Size(40, 24)
        Me.btnOkMtext.TabIndex = 39
        Me.btnOkMtext.Text = "ok"
        Me.btnOkMtext.UseVisualStyleBackColor = True
        Me.btnOkMtext.Visible = False
        '
        'frmTextEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 217)
        Me.Controls.Add(Me.btnOkMtext)
        Me.Controls.Add(Me.rtbMtext)
        Me.Controls.Add(Me.cajaAltura)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nudAngulo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnRechazar)
        Me.Controls.Add(Me.cajaTexto)
        Me.Controls.Add(Me.lblCajaTexto)
        Me.Controls.Add(Me.btnOk)
        Me.Name = "frmTextEdit"
        Me.Text = "Edición de textos"
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.lblCajaTexto, 0)
        Me.Controls.SetChildIndex(Me.cajaTexto, 0)
        Me.Controls.SetChildIndex(Me.lblColor, 0)
        Me.Controls.SetChildIndex(Me.lblLayer, 0)
        Me.Controls.SetChildIndex(Me.lblTipoLinea, 0)
        Me.Controls.SetChildIndex(Me.btnRechazar, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.nudAngulo, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cajaAltura, 0)
        Me.Controls.SetChildIndex(Me.rtbMtext, 0)
        Me.Controls.SetChildIndex(Me.btnOkMtext, 0)
        CType(Me.nudAngulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblCajaTexto As System.Windows.Forms.Label
    Friend WithEvents cajaTexto As System.Windows.Forms.TextBox
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudAngulo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cajaAltura As System.Windows.Forms.TextBox
    Friend WithEvents rtbMtext As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOkMtext As System.Windows.Forms.Button
End Class
