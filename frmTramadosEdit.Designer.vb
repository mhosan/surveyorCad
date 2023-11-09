<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTramadosEdit
    Inherits frmPropiedades  'System.Windows.Forms.Form

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
        Me.grpBxTrama = New System.Windows.Forms.GroupBox()
        Me.lblTrama = New System.Windows.Forms.Label()
        Me.txtAngulo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEscala = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpBxTrama.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnOk.Location = New System.Drawing.Point(52, 210)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 20)
        Me.btnOk.TabIndex = 31
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnRechazar
        '
        Me.btnRechazar.Location = New System.Drawing.Point(153, 210)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(80, 20)
        Me.btnRechazar.TabIndex = 32
        Me.btnRechazar.Text = "Cancelar"
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'grpBxTrama
        '
        Me.grpBxTrama.Controls.Add(Me.lblTrama)
        Me.grpBxTrama.Location = New System.Drawing.Point(17, 93)
        Me.grpBxTrama.Name = "grpBxTrama"
        Me.grpBxTrama.Size = New System.Drawing.Size(250, 35)
        Me.grpBxTrama.TabIndex = 37
        Me.grpBxTrama.TabStop = False
        Me.grpBxTrama.Text = "Propiedades de la trama:"
        '
        'lblTrama
        '
        Me.lblTrama.AutoSize = True
        Me.lblTrama.Location = New System.Drawing.Point(18, 15)
        Me.lblTrama.Name = "lblTrama"
        Me.lblTrama.Size = New System.Drawing.Size(33, 13)
        Me.lblTrama.TabIndex = 0
        Me.lblTrama.Text = "trama"
        '
        'txtAngulo
        '
        Me.txtAngulo.Location = New System.Drawing.Point(108, 156)
        Me.txtAngulo.Name = "txtAngulo"
        Me.txtAngulo.Size = New System.Drawing.Size(118, 20)
        Me.txtAngulo.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Angulo:"
        '
        'txtEscala
        '
        Me.txtEscala.Location = New System.Drawing.Point(107, 132)
        Me.txtEscala.Name = "txtEscala"
        Me.txtEscala.Size = New System.Drawing.Size(118, 20)
        Me.txtEscala.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Escala:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmTramadosEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 232)
        Me.Controls.Add(Me.grpBxTrama)
        Me.Controls.Add(Me.txtAngulo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEscala)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnRechazar)
        Me.Controls.Add(Me.btnOk)
        Me.Name = "frmTramadosEdit"
        Me.Text = "frmTramadosEdit"
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.btnRechazar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.lblColor, 0)
        Me.Controls.SetChildIndex(Me.lblLayer, 0)
        Me.Controls.SetChildIndex(Me.lblTipoLinea, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtEscala, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtAngulo, 0)
        Me.Controls.SetChildIndex(Me.grpBxTrama, 0)
        Me.grpBxTrama.ResumeLayout(False)
        Me.grpBxTrama.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents grpBxTrama As System.Windows.Forms.GroupBox
    Friend WithEvents lblTrama As System.Windows.Forms.Label
    Friend WithEvents txtAngulo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEscala As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
