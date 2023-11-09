<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAte
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
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblAtributo = New System.Windows.Forms.Label()
        Me.txtValorAtt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvAte = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtAnguloLetra = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFactorAncho = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRotacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAltura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbJustificacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEstiloTexto = New System.Windows.Forms.ComboBox()
        Me.lblAttFormatTexto = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cmbTipoLinea = New System.Windows.Forms.ComboBox()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        Me.lblAttPropiedades = New System.Windows.Forms.Label()
        Me.cmbLayer = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(135, 322)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(80, 20)
        Me.btnAplicar.TabIndex = 3
        Me.btnAplicar.Text = "Aplicar"
        Me.ToolTip1.SetToolTip(Me.btnAplicar, "Aceptar el texto de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """Valor"" y ubicarlo en" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " la grilla de esta pantalla" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "en el r" & _
                "englon donde " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "fue seleccionado.")
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(240, 322)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 20)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "Ok"
        Me.ToolTip1.SetToolTip(Me.btnOk, "Aceptar los valores de los atributos que se muestran en pantalla, en la grilla, y" & _
                " actualizar el dibujo.")
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(345, 322)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 20)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage3)
        Me.TabControl.Location = New System.Drawing.Point(12, 4)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(536, 310)
        Me.TabControl.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblAtributo)
        Me.TabPage1.Controls.Add(Me.txtValorAtt)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lvAte)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(528, 284)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Atributo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblAtributo
        '
        Me.lblAtributo.AutoSize = True
        Me.lblAtributo.Location = New System.Drawing.Point(12, 10)
        Me.lblAtributo.Name = "lblAtributo"
        Me.lblAtributo.Size = New System.Drawing.Size(13, 13)
        Me.lblAtributo.TabIndex = 6
        Me.lblAtributo.Text = "--"
        '
        'txtValorAtt
        '
        Me.txtValorAtt.Location = New System.Drawing.Point(53, 252)
        Me.txtValorAtt.Name = "txtValorAtt"
        Me.txtValorAtt.Size = New System.Drawing.Size(462, 20)
        Me.txtValorAtt.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Valor:"
        '
        'lvAte
        '
        Me.lvAte.Location = New System.Drawing.Point(13, 32)
        Me.lvAte.Name = "lvAte"
        Me.lvAte.Size = New System.Drawing.Size(503, 208)
        Me.lvAte.TabIndex = 3
        Me.lvAte.UseCompatibleStateImageBehavior = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtAnguloLetra)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtFactorAncho)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txtRotacion)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtAltura)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.cmbJustificacion)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.cmbEstiloTexto)
        Me.TabPage2.Controls.Add(Me.lblAttFormatTexto)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(528, 284)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Opciones de texto"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtAnguloLetra
        '
        Me.txtAnguloLetra.Location = New System.Drawing.Point(388, 90)
        Me.txtAnguloLetra.Name = "txtAnguloLetra"
        Me.txtAnguloLetra.Size = New System.Drawing.Size(121, 20)
        Me.txtAnguloLetra.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(260, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Angulo de la tipografia:"
        '
        'txtFactorAncho
        '
        Me.txtFactorAncho.Location = New System.Drawing.Point(388, 44)
        Me.txtFactorAncho.Name = "txtFactorAncho"
        Me.txtFactorAncho.Size = New System.Drawing.Size(121, 20)
        Me.txtFactorAncho.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(260, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Factor de ancho:"
        '
        'txtRotacion
        '
        Me.txtRotacion.Location = New System.Drawing.Point(388, 131)
        Me.txtRotacion.Name = "txtRotacion"
        Me.txtRotacion.Size = New System.Drawing.Size(121, 20)
        Me.txtRotacion.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Rotación:"
        '
        'txtAltura
        '
        Me.txtAltura.Location = New System.Drawing.Point(94, 131)
        Me.txtAltura.Name = "txtAltura"
        Me.txtAltura.Size = New System.Drawing.Size(121, 20)
        Me.txtAltura.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Altura:"
        '
        'cmbJustificacion
        '
        Me.cmbJustificacion.FormattingEnabled = True
        Me.cmbJustificacion.Items.AddRange(New Object() {"Alineado", "Centrado", "Justificado", "Izquierda", "Derecha"})
        Me.cmbJustificacion.Location = New System.Drawing.Point(94, 90)
        Me.cmbJustificacion.Name = "cmbJustificacion"
        Me.cmbJustificacion.Size = New System.Drawing.Size(121, 21)
        Me.cmbJustificacion.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Justificación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Estilo de texto:"
        '
        'cmbEstiloTexto
        '
        Me.cmbEstiloTexto.FormattingEnabled = True
        Me.cmbEstiloTexto.Location = New System.Drawing.Point(94, 49)
        Me.cmbEstiloTexto.Name = "cmbEstiloTexto"
        Me.cmbEstiloTexto.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstiloTexto.TabIndex = 8
        '
        'lblAttFormatTexto
        '
        Me.lblAttFormatTexto.AutoSize = True
        Me.lblAttFormatTexto.Location = New System.Drawing.Point(12, 10)
        Me.lblAttFormatTexto.Name = "lblAttFormatTexto"
        Me.lblAttFormatTexto.Size = New System.Drawing.Size(13, 13)
        Me.lblAttFormatTexto.TabIndex = 7
        Me.lblAttFormatTexto.Text = "--"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cmbTipoLinea)
        Me.TabPage3.Controls.Add(Me.cmbColor)
        Me.TabPage3.Controls.Add(Me.lblAttPropiedades)
        Me.TabPage3.Controls.Add(Me.cmbLayer)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(528, 284)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Propiedades"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cmbTipoLinea
        '
        Me.cmbTipoLinea.FormattingEnabled = True
        Me.cmbTipoLinea.Location = New System.Drawing.Point(102, 126)
        Me.cmbTipoLinea.Name = "cmbTipoLinea"
        Me.cmbTipoLinea.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoLinea.TabIndex = 10
        '
        'cmbColor
        '
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Items.AddRange(New Object() {"Por layer", "Rojo", "Amarillo", "Verde", "Cian", "Azul", "Magenta", "Negro", "Seleccionar color..."})
        Me.cmbColor.Location = New System.Drawing.Point(101, 86)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(121, 21)
        Me.cmbColor.TabIndex = 9
        '
        'lblAttPropiedades
        '
        Me.lblAttPropiedades.AutoSize = True
        Me.lblAttPropiedades.Location = New System.Drawing.Point(12, 10)
        Me.lblAttPropiedades.Name = "lblAttPropiedades"
        Me.lblAttPropiedades.Size = New System.Drawing.Size(13, 13)
        Me.lblAttPropiedades.TabIndex = 8
        Me.lblAttPropiedades.Text = "--"
        '
        'cmbLayer
        '
        Me.cmbLayer.FormattingEnabled = True
        Me.cmbLayer.Location = New System.Drawing.Point(100, 44)
        Me.cmbLayer.Name = "cmbLayer"
        Me.cmbLayer.Size = New System.Drawing.Size(121, 21)
        Me.cmbLayer.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Tipo de linea"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Color"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Capa (Layer)"
        '
        'frmAte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 352)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnAplicar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAte"
        Me.Text = "mhCad Ediciòn de atributos"
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtValorAtt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvAte As System.Windows.Forms.ListView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblAtributo As System.Windows.Forms.Label
    Friend WithEvents lblAttFormatTexto As System.Windows.Forms.Label
    Friend WithEvents txtAnguloLetra As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFactorAncho As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRotacion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAltura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbJustificacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEstiloTexto As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbLayer As System.Windows.Forms.ComboBox
    Friend WithEvents lblAttPropiedades As System.Windows.Forms.Label
    Friend WithEvents cmbColor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoLinea As System.Windows.Forms.ComboBox
End Class
