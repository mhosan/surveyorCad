<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropiedades
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
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblLayer = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTipoLinea = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lstLayers = New System.Windows.Forms.ListBox()
        Me.lstTipoLinea = New System.Windows.Forms.ListBox()
        Me.lblLargoEntidad = New System.Windows.Forms.Label()
        Me.lblAreaEntidad = New System.Windows.Forms.Label()
        Me.lblAlturaEntidad = New System.Windows.Forms.Label()
        Me.lblAnchoEntidad = New System.Windows.Forms.Label()
        Me.lblOtro = New System.Windows.Forms.Label()
        Me.trvAltura = New System.Windows.Forms.TreeView()
        Me.btnAltura = New System.Windows.Forms.Button()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(158, 207)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 20)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(50, 207)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 20)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "Ok"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblLayer
        '
        Me.lblLayer.AutoSize = True
        Me.lblLayer.Location = New System.Drawing.Point(83, 37)
        Me.lblLayer.Name = "lblLayer"
        Me.lblLayer.Size = New System.Drawing.Size(39, 13)
        Me.lblLayer.TabIndex = 24
        Me.lblLayer.Text = "Label6"
        Me.lblLayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Layer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Tipo de linea"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(83, 13)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(39, 13)
        Me.lblColor.TabIndex = 23
        Me.lblColor.Text = "Label5"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Color"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoLinea
        '
        Me.lblTipoLinea.AutoSize = True
        Me.lblTipoLinea.Location = New System.Drawing.Point(83, 62)
        Me.lblTipoLinea.Name = "lblTipoLinea"
        Me.lblTipoLinea.Size = New System.Drawing.Size(39, 13)
        Me.lblTipoLinea.TabIndex = 25
        Me.lblTipoLinea.Text = "Label7"
        Me.lblTipoLinea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(240, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(240, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 24)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(240, 55)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(24, 24)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lstLayers
        '
        Me.lstLayers.FormattingEnabled = True
        Me.lstLayers.Location = New System.Drawing.Point(54, 32)
        Me.lstLayers.Name = "lstLayers"
        Me.lstLayers.Size = New System.Drawing.Size(184, 95)
        Me.lstLayers.TabIndex = 29
        Me.lstLayers.Visible = False
        '
        'lstTipoLinea
        '
        Me.lstTipoLinea.FormattingEnabled = True
        Me.lstTipoLinea.Location = New System.Drawing.Point(54, 55)
        Me.lstTipoLinea.Name = "lstTipoLinea"
        Me.lstTipoLinea.Size = New System.Drawing.Size(184, 95)
        Me.lstTipoLinea.TabIndex = 30
        Me.lstTipoLinea.Visible = False
        '
        'lblLargoEntidad
        '
        Me.lblLargoEntidad.AutoSize = True
        Me.lblLargoEntidad.Location = New System.Drawing.Point(12, 87)
        Me.lblLargoEntidad.Name = "lblLargoEntidad"
        Me.lblLargoEntidad.Size = New System.Drawing.Size(48, 13)
        Me.lblLargoEntidad.TabIndex = 31
        Me.lblLargoEntidad.Text = "Longitud"
        '
        'lblAreaEntidad
        '
        Me.lblAreaEntidad.AutoSize = True
        Me.lblAreaEntidad.Location = New System.Drawing.Point(12, 102)
        Me.lblAreaEntidad.Name = "lblAreaEntidad"
        Me.lblAreaEntidad.Size = New System.Drawing.Size(29, 13)
        Me.lblAreaEntidad.TabIndex = 32
        Me.lblAreaEntidad.Text = "Area"
        Me.lblAreaEntidad.Visible = False
        '
        'lblAlturaEntidad
        '
        Me.lblAlturaEntidad.AutoSize = True
        Me.lblAlturaEntidad.Location = New System.Drawing.Point(12, 117)
        Me.lblAlturaEntidad.Name = "lblAlturaEntidad"
        Me.lblAlturaEntidad.Size = New System.Drawing.Size(34, 13)
        Me.lblAlturaEntidad.TabIndex = 33
        Me.lblAlturaEntidad.Text = "Altura"
        Me.lblAlturaEntidad.Visible = False
        '
        'lblAnchoEntidad
        '
        Me.lblAnchoEntidad.AutoSize = True
        Me.lblAnchoEntidad.Location = New System.Drawing.Point(12, 132)
        Me.lblAnchoEntidad.Name = "lblAnchoEntidad"
        Me.lblAnchoEntidad.Size = New System.Drawing.Size(38, 13)
        Me.lblAnchoEntidad.TabIndex = 34
        Me.lblAnchoEntidad.Text = "Ancho"
        Me.lblAnchoEntidad.Visible = False
        '
        'lblOtro
        '
        Me.lblOtro.AutoSize = True
        Me.lblOtro.Location = New System.Drawing.Point(12, 148)
        Me.lblOtro.Name = "lblOtro"
        Me.lblOtro.Size = New System.Drawing.Size(27, 13)
        Me.lblOtro.TabIndex = 35
        Me.lblOtro.Text = "Otro"
        Me.lblOtro.Visible = False
        '
        'trvAltura
        '
        Me.trvAltura.Location = New System.Drawing.Point(126, 111)
        Me.trvAltura.Name = "trvAltura"
        Me.trvAltura.Size = New System.Drawing.Size(112, 50)
        Me.trvAltura.TabIndex = 36
        '
        'btnAltura
        '
        Me.btnAltura.Location = New System.Drawing.Point(240, 111)
        Me.btnAltura.Name = "btnAltura"
        Me.btnAltura.Size = New System.Drawing.Size(24, 24)
        Me.btnAltura.TabIndex = 37
        Me.btnAltura.Text = "..."
        Me.btnAltura.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DecimalPlaces = 2
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NumericUpDown1.Location = New System.Drawing.Point(191, 183)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(47, 20)
        Me.NumericUpDown1.TabIndex = 38
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Tamaño circulo en vertices: "
        Me.Label4.Visible = False
        '
        'frmPropiedades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 232)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.btnAltura)
        Me.Controls.Add(Me.trvAltura)
        Me.Controls.Add(Me.lblOtro)
        Me.Controls.Add(Me.lblAnchoEntidad)
        Me.Controls.Add(Me.lblAlturaEntidad)
        Me.Controls.Add(Me.lblAreaEntidad)
        Me.Controls.Add(Me.lblLargoEntidad)
        Me.Controls.Add(Me.lstTipoLinea)
        Me.Controls.Add(Me.lstLayers)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblTipoLinea)
        Me.Controls.Add(Me.lblLayer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPropiedades"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "mhCad - Propiedades"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Protected WithEvents lblLayer As System.Windows.Forms.Label
    Protected WithEvents lblColor As System.Windows.Forms.Label
    Protected WithEvents lblTipoLinea As System.Windows.Forms.Label
    Friend WithEvents lstLayers As System.Windows.Forms.ListBox
    Friend WithEvents lstTipoLinea As System.Windows.Forms.ListBox
    Protected WithEvents btnCancelar As System.Windows.Forms.Button
    Protected WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblLargoEntidad As System.Windows.Forms.Label
    Friend WithEvents lblAreaEntidad As System.Windows.Forms.Label
    Friend WithEvents lblAlturaEntidad As System.Windows.Forms.Label
    Friend WithEvents lblAnchoEntidad As System.Windows.Forms.Label
    Friend WithEvents lblOtro As System.Windows.Forms.Label
    Friend WithEvents trvAltura As System.Windows.Forms.TreeView
    Friend WithEvents btnAltura As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
