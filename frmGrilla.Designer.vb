<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrilla
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
        Me.chkGrilla = New System.Windows.Forms.CheckBox()
        Me.chkSnap = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nuGrillaY = New System.Windows.Forms.NumericUpDown()
        Me.nuGrillaX = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.nuSnapY = New System.Windows.Forms.NumericUpDown()
        Me.nuSnapX = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtYUr = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtXUr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtYLl = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtXLl = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkActivarPegadoTrackingPolar = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nuAnguloTracking = New System.Windows.Forms.NumericUpDown()
        Me.chkActivarTrackingPolar = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nuGrillaY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuGrillaX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nuSnapY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuSnapX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nuAnguloTracking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkGrilla
        '
        Me.chkGrilla.AutoSize = True
        Me.chkGrilla.Location = New System.Drawing.Point(13, 13)
        Me.chkGrilla.Name = "chkGrilla"
        Me.chkGrilla.Size = New System.Drawing.Size(106, 17)
        Me.chkGrilla.TabIndex = 0
        Me.chkGrilla.Text = "Activar Grilla (F7)"
        Me.chkGrilla.UseVisualStyleBackColor = True
        '
        'chkSnap
        '
        Me.chkSnap.AutoSize = True
        Me.chkSnap.Location = New System.Drawing.Point(230, 13)
        Me.chkSnap.Name = "chkSnap"
        Me.chkSnap.Size = New System.Drawing.Size(108, 17)
        Me.chkSnap.TabIndex = 1
        Me.chkSnap.Text = "Activar Snap (F9)"
        Me.chkSnap.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nuGrillaY)
        Me.GroupBox1.Controls.Add(Me.nuGrillaX)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 87)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Espaciado grilla"
        '
        'nuGrillaY
        '
        Me.nuGrillaY.DecimalPlaces = 2
        Me.nuGrillaY.Location = New System.Drawing.Point(96, 50)
        Me.nuGrillaY.Name = "nuGrillaY"
        Me.nuGrillaY.Size = New System.Drawing.Size(55, 20)
        Me.nuGrillaY.TabIndex = 3
        '
        'nuGrillaX
        '
        Me.nuGrillaX.DecimalPlaces = 2
        Me.nuGrillaX.Location = New System.Drawing.Point(96, 26)
        Me.nuGrillaX.Name = "nuGrillaX"
        Me.nuGrillaX.Size = New System.Drawing.Size(55, 20)
        Me.nuGrillaX.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Espacio Y"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Espacio X"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nuSnapY)
        Me.GroupBox2.Controls.Add(Me.nuSnapX)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(248, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(187, 87)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Espaciado Snap"
        '
        'nuSnapY
        '
        Me.nuSnapY.DecimalPlaces = 2
        Me.nuSnapY.Location = New System.Drawing.Point(111, 50)
        Me.nuSnapY.Name = "nuSnapY"
        Me.nuSnapY.Size = New System.Drawing.Size(53, 20)
        Me.nuSnapY.TabIndex = 3
        '
        'nuSnapX
        '
        Me.nuSnapX.DecimalPlaces = 2
        Me.nuSnapX.Location = New System.Drawing.Point(111, 26)
        Me.nuSnapX.Name = "nuSnapX"
        Me.nuSnapX.Size = New System.Drawing.Size(53, 20)
        Me.nuSnapX.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Espacio Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Espacio X"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(238, 378)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 20)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(133, 378)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 20)
        Me.btnOk.TabIndex = 16
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.txtYUr)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtXUr)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtYLl)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtXLl)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 148)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(420, 105)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ubicación grilla"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(128, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 20)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Aceptar valores mostrados"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtYUr
        '
        Me.txtYUr.Location = New System.Drawing.Point(357, 42)
        Me.txtYUr.Name = "txtYUr"
        Me.txtYUr.Size = New System.Drawing.Size(55, 20)
        Me.txtYUr.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(222, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Y esquina superior derecha"
        '
        'txtXUr
        '
        Me.txtXUr.Location = New System.Drawing.Point(357, 15)
        Me.txtXUr.Name = "txtXUr"
        Me.txtXUr.Size = New System.Drawing.Size(55, 20)
        Me.txtXUr.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(222, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "X esquina superior derecha"
        '
        'txtYLl
        '
        Me.txtYLl.Location = New System.Drawing.Point(145, 42)
        Me.txtYLl.Name = "txtYLl"
        Me.txtYLl.Size = New System.Drawing.Size(55, 20)
        Me.txtYLl.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Y esquina inferior izquierda"
        '
        'txtXLl
        '
        Me.txtXLl.Location = New System.Drawing.Point(145, 15)
        Me.txtXLl.Name = "txtXLl"
        Me.txtXLl.Size = New System.Drawing.Size(55, 20)
        Me.txtXLl.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "X esquina inferior izquierda"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkActivarPegadoTrackingPolar)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.nuAnguloTracking)
        Me.GroupBox4.Controls.Add(Me.chkActivarTrackingPolar)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 265)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(420, 100)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tracking polar"
        '
        'chkActivarPegadoTrackingPolar
        '
        Me.chkActivarPegadoTrackingPolar.AutoSize = True
        Me.chkActivarPegadoTrackingPolar.Location = New System.Drawing.Point(13, 60)
        Me.chkActivarPegadoTrackingPolar.Name = "chkActivarPegadoTrackingPolar"
        Me.chkActivarPegadoTrackingPolar.Size = New System.Drawing.Size(174, 17)
        Me.chkActivarPegadoTrackingPolar.TabIndex = 5
        Me.chkActivarPegadoTrackingPolar.Text = "Activar pegado a tracking polar"
        Me.chkActivarPegadoTrackingPolar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(254, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Angulo de tracking"
        '
        'nuAnguloTracking
        '
        Me.nuAnguloTracking.DecimalPlaces = 2
        Me.nuAnguloTracking.Location = New System.Drawing.Point(357, 26)
        Me.nuAnguloTracking.Name = "nuAnguloTracking"
        Me.nuAnguloTracking.Size = New System.Drawing.Size(55, 20)
        Me.nuAnguloTracking.TabIndex = 3
        '
        'chkActivarTrackingPolar
        '
        Me.chkActivarTrackingPolar.AutoSize = True
        Me.chkActivarTrackingPolar.Location = New System.Drawing.Point(13, 29)
        Me.chkActivarTrackingPolar.Name = "chkActivarTrackingPolar"
        Me.chkActivarTrackingPolar.Size = New System.Drawing.Size(131, 17)
        Me.chkActivarTrackingPolar.TabIndex = 1
        Me.chkActivarTrackingPolar.Text = "Activar Tracking Polar"
        Me.chkActivarTrackingPolar.UseVisualStyleBackColor = True
        '
        'frmGrilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 410)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkSnap)
        Me.Controls.Add(Me.chkGrilla)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmGrilla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propiedades Grilla - Snap"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nuGrillaY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuGrillaX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nuSnapY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuSnapX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.nuAnguloTracking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkGrilla As System.Windows.Forms.CheckBox
    Friend WithEvents chkSnap As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents nuGrillaY As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuGrillaX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nuSnapY As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuSnapX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtYUr As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtXUr As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtYLl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtXLl As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkActivarTrackingPolar As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nuAnguloTracking As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkActivarPegadoTrackingPolar As System.Windows.Forms.CheckBox
End Class
