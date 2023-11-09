<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatosCroquis
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lblMacizo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBorrarCroquis = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudEscalaPl = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDeshacer = New System.Windows.Forms.Button()
        Me.btnPlMover = New System.Windows.Forms.Button()
        Me.btnPlEscala = New System.Windows.Forms.Button()
        Me.lblParcela = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.nudEscalaPl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.ForeColor = System.Drawing.Color.Maroon
        Me.OK_Button.Location = New System.Drawing.Point(14, 203)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(80, 30)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Guardar"
        Me.ToolTip1.SetToolTip(Me.OK_Button, "Guardar croquis en la base de datos.")
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.ForeColor = System.Drawing.Color.Maroon
        Me.Cancel_Button.Location = New System.Drawing.Point(100, 203)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(80, 30)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'lblMacizo
        '
        Me.lblMacizo.Location = New System.Drawing.Point(13, 193)
        Me.lblMacizo.Name = "lblMacizo"
        Me.lblMacizo.Size = New System.Drawing.Size(169, 16)
        Me.lblMacizo.TabIndex = 19
        Me.lblMacizo.Text = "--"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnBorrarCroquis)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.nudEscalaPl)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnDeshacer)
        Me.Panel1.Controls.Add(Me.btnPlMover)
        Me.Panel1.Controls.Add(Me.btnPlEscala)
        Me.Panel1.Controls.Add(Me.lblParcela)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(187, 186)
        Me.Panel1.TabIndex = 34
        '
        'btnBorrarCroquis
        '
        Me.btnBorrarCroquis.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnBorrarCroquis.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrarCroquis.Image = Global.mhCad.My.Resources.Resources.MergeAnim_16i
        Me.btnBorrarCroquis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBorrarCroquis.Location = New System.Drawing.Point(10, 137)
        Me.btnBorrarCroquis.Name = "btnBorrarCroquis"
        Me.btnBorrarCroquis.Size = New System.Drawing.Size(100, 35)
        Me.btnBorrarCroquis.TabIndex = 42
        Me.btnBorrarCroquis.Tag = ""
        Me.btnBorrarCroquis.Text = "Actualizar Croquis"
        Me.btnBorrarCroquis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBorrarCroquis.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 21)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Parcela"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nudEscalaPl
        '
        Me.nudEscalaPl.DecimalPlaces = 2
        Me.nudEscalaPl.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudEscalaPl.Location = New System.Drawing.Point(59, 60)
        Me.nudEscalaPl.Name = "nudEscalaPl"
        Me.nudEscalaPl.Size = New System.Drawing.Size(51, 20)
        Me.nudEscalaPl.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Escala:"
        '
        'btnDeshacer
        '
        Me.btnDeshacer.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnDeshacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeshacer.Image = Global.mhCad.My.Resources.Resources.acad_undo
        Me.btnDeshacer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDeshacer.Location = New System.Drawing.Point(116, 137)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(60, 35)
        Me.btnDeshacer.TabIndex = 37
        Me.btnDeshacer.Tag = ""
        Me.btnDeshacer.Text = "Deshacer"
        Me.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDeshacer.UseVisualStyleBackColor = False
        '
        'btnPlMover
        '
        Me.btnPlMover.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnPlMover.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlMover.Image = Global.mhCad.My.Resources.Resources.acad_mover
        Me.btnPlMover.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPlMover.Location = New System.Drawing.Point(116, 91)
        Me.btnPlMover.Name = "btnPlMover"
        Me.btnPlMover.Size = New System.Drawing.Size(60, 35)
        Me.btnPlMover.TabIndex = 36
        Me.btnPlMover.Tag = ""
        Me.btnPlMover.Text = "Mover"
        Me.btnPlMover.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPlMover.UseVisualStyleBackColor = False
        '
        'btnPlEscala
        '
        Me.btnPlEscala.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnPlEscala.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlEscala.Image = Global.mhCad.My.Resources.Resources.acad_scale
        Me.btnPlEscala.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPlEscala.Location = New System.Drawing.Point(116, 45)
        Me.btnPlEscala.Name = "btnPlEscala"
        Me.btnPlEscala.Size = New System.Drawing.Size(60, 35)
        Me.btnPlEscala.TabIndex = 35
        Me.btnPlEscala.Tag = ""
        Me.btnPlEscala.Text = "Aplicar"
        Me.btnPlEscala.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPlEscala.UseVisualStyleBackColor = False
        '
        'lblParcela
        '
        Me.lblParcela.Location = New System.Drawing.Point(7, 29)
        Me.lblParcela.Name = "lblParcela"
        Me.lblParcela.Size = New System.Drawing.Size(173, 16)
        Me.lblParcela.TabIndex = 34
        Me.lblParcela.Text = "--"
        '
        'frmDatosCroquis
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(195, 243)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblMacizo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(70, 200)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDatosCroquis"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Datos Croquis"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudEscalaPl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblMacizo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudEscalaPl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDeshacer As System.Windows.Forms.Button
    Friend WithEvents btnPlMover As System.Windows.Forms.Button
    Friend WithEvents btnPlEscala As System.Windows.Forms.Button
    Friend WithEvents lblParcela As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnBorrarCroquis As System.Windows.Forms.Button

End Class
