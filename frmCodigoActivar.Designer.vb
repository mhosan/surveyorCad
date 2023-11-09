<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodigoActivar
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
        Me.txtRecibido1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.ofd = New System.Windows.Forms.OpenFileDialog
        Me.txtRecibido2 = New System.Windows.Forms.TextBox
        Me.txtRecibido3 = New System.Windows.Forms.TextBox
        Me.txtRecibido4 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtRecibido1
        '
        Me.txtRecibido1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecibido1.Location = New System.Drawing.Point(39, 35)
        Me.txtRecibido1.Name = "txtRecibido1"
        Me.txtRecibido1.Size = New System.Drawing.Size(110, 26)
        Me.txtRecibido1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ingresar el còdigo recibido:"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(228, 86)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 20)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'txtRecibido2
        '
        Me.txtRecibido2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecibido2.Location = New System.Drawing.Point(155, 35)
        Me.txtRecibido2.Name = "txtRecibido2"
        Me.txtRecibido2.Size = New System.Drawing.Size(110, 26)
        Me.txtRecibido2.TabIndex = 1
        '
        'txtRecibido3
        '
        Me.txtRecibido3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecibido3.Location = New System.Drawing.Point(271, 35)
        Me.txtRecibido3.Name = "txtRecibido3"
        Me.txtRecibido3.Size = New System.Drawing.Size(110, 26)
        Me.txtRecibido3.TabIndex = 2
        '
        'txtRecibido4
        '
        Me.txtRecibido4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecibido4.Location = New System.Drawing.Point(387, 35)
        Me.txtRecibido4.Name = "txtRecibido4"
        Me.txtRecibido4.Size = New System.Drawing.Size(110, 26)
        Me.txtRecibido4.TabIndex = 3
        '
        'frmCodigoActivar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 124)
        Me.Controls.Add(Me.txtRecibido4)
        Me.Controls.Add(Me.txtRecibido3)
        Me.Controls.Add(Me.txtRecibido2)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRecibido1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCodigoActivar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCodigoActivar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecibido1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtRecibido2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRecibido3 As System.Windows.Forms.TextBox
    Friend WithEvents txtRecibido4 As System.Windows.Forms.TextBox
End Class
