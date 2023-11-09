<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPHPoligonoDominio
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.dgvPolDomTotales = New System.Windows.Forms.DataGridView()
        Me.totales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cubiertaT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.semicubT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descubiertaT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.balconT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totPolT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totUFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPolDom = New System.Windows.Forms.DataGridView()
        Me.cubierta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.semicub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descubierta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.balcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totPol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnPegarDatosPolDom = New System.Windows.Forms.Button()
        Me.lblPoligonoDominioSeleccionado = New System.Windows.Forms.Label()
        Me.btnSeleccionarPoligono = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblUfUcOwner = New System.Windows.Forms.Label()
        Me.cmbUf = New System.Windows.Forms.ComboBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtPolDominioNombre = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPoligonosDominio = New System.Windows.Forms.ComboBox()
        Me.btnPegarDatosSuperficie = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbCubierta = New System.Windows.Forms.RadioButton()
        Me.rbSemicubierta = New System.Windows.Forms.RadioButton()
        Me.rbDescubierta = New System.Windows.Forms.RadioButton()
        Me.rbBalcon = New System.Windows.Forms.RadioButton()
        Me.lblSuperficieSeleccionado = New System.Windows.Forms.Label()
        Me.btnSeleccionarSuperficie = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvPolDomTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPolDom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(389, 421)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'dgvPolDomTotales
        '
        Me.dgvPolDomTotales.AllowUserToAddRows = False
        Me.dgvPolDomTotales.AllowUserToDeleteRows = False
        Me.dgvPolDomTotales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPolDomTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolDomTotales.ColumnHeadersVisible = False
        Me.dgvPolDomTotales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.totales, Me.cubiertaT, Me.semicubT, Me.descubiertaT, Me.balconT, Me.totPolT, Me.totUFT})
        Me.dgvPolDomTotales.Location = New System.Drawing.Point(12, 393)
        Me.dgvPolDomTotales.Name = "dgvPolDomTotales"
        Me.dgvPolDomTotales.RowHeadersVisible = False
        Me.dgvPolDomTotales.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvPolDomTotales.Size = New System.Drawing.Size(522, 26)
        Me.dgvPolDomTotales.TabIndex = 32
        '
        'totales
        '
        Me.totales.HeaderText = "totales"
        Me.totales.Name = "totales"
        Me.totales.ReadOnly = True
        '
        'cubiertaT
        '
        Me.cubiertaT.HeaderText = "cubierta"
        Me.cubiertaT.Name = "cubiertaT"
        Me.cubiertaT.ReadOnly = True
        '
        'semicubT
        '
        Me.semicubT.HeaderText = "semicub"
        Me.semicubT.Name = "semicubT"
        Me.semicubT.ReadOnly = True
        '
        'descubiertaT
        '
        Me.descubiertaT.HeaderText = "descubierta"
        Me.descubiertaT.Name = "descubiertaT"
        Me.descubiertaT.ReadOnly = True
        '
        'balconT
        '
        Me.balconT.HeaderText = "balcon"
        Me.balconT.Name = "balconT"
        Me.balconT.ReadOnly = True
        '
        'totPolT
        '
        Me.totPolT.HeaderText = "totPol"
        Me.totPolT.Name = "totPolT"
        Me.totPolT.ReadOnly = True
        '
        'totUFT
        '
        Me.totUFT.HeaderText = "totUF"
        Me.totUFT.Name = "totUFT"
        Me.totUFT.ReadOnly = True
        '
        'dgvPolDom
        '
        Me.dgvPolDom.AllowUserToAddRows = False
        Me.dgvPolDom.AllowUserToDeleteRows = False
        Me.dgvPolDom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPolDom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolDom.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cubierta, Me.semicub, Me.descubierta, Me.balcon, Me.totPol})
        Me.dgvPolDom.Location = New System.Drawing.Point(12, 285)
        Me.dgvPolDom.Name = "dgvPolDom"
        Me.dgvPolDom.RowHeadersVisible = False
        Me.dgvPolDom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPolDom.Size = New System.Drawing.Size(522, 105)
        Me.dgvPolDom.TabIndex = 31
        '
        'cubierta
        '
        Me.cubierta.HeaderText = "cubierta"
        Me.cubierta.Name = "cubierta"
        Me.cubierta.ReadOnly = True
        '
        'semicub
        '
        Me.semicub.HeaderText = "semicub"
        Me.semicub.Name = "semicub"
        Me.semicub.ReadOnly = True
        '
        'descubierta
        '
        Me.descubierta.HeaderText = "descubierta"
        Me.descubierta.Name = "descubierta"
        Me.descubierta.ReadOnly = True
        '
        'balcon
        '
        Me.balcon.HeaderText = "balcon"
        Me.balcon.Name = "balcon"
        Me.balcon.ReadOnly = True
        '
        'totPol
        '
        Me.totPol.HeaderText = "totPol"
        Me.totPol.Name = "totPol"
        Me.totPol.ReadOnly = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.btnPegarDatosPolDom)
        Me.GroupBox3.Controls.Add(Me.lblPoligonoDominioSeleccionado)
        Me.GroupBox3.Controls.Add(Me.btnSeleccionarPoligono)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.GroupBox9)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(522, 120)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "POLIGONO DE DOMINIO"
        '
        'btnPegarDatosPolDom
        '
        Me.btnPegarDatosPolDom.Location = New System.Drawing.Point(151, 95)
        Me.btnPegarDatosPolDom.Name = "btnPegarDatosPolDom"
        Me.btnPegarDatosPolDom.Size = New System.Drawing.Size(236, 23)
        Me.btnPegarDatosPolDom.TabIndex = 53
        Me.btnPegarDatosPolDom.Text = "Pegar datos en la polilinea seleccionada"
        Me.btnPegarDatosPolDom.UseVisualStyleBackColor = True
        '
        'lblPoligonoDominioSeleccionado
        '
        Me.lblPoligonoDominioSeleccionado.AutoSize = True
        Me.lblPoligonoDominioSeleccionado.Location = New System.Drawing.Point(224, 18)
        Me.lblPoligonoDominioSeleccionado.Name = "lblPoligonoDominioSeleccionado"
        Me.lblPoligonoDominioSeleccionado.Size = New System.Drawing.Size(13, 13)
        Me.lblPoligonoDominioSeleccionado.TabIndex = 51
        Me.lblPoligonoDominioSeleccionado.Text = "--"
        Me.lblPoligonoDominioSeleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSeleccionarPoligono
        '
        Me.btnSeleccionarPoligono.Location = New System.Drawing.Point(8, 13)
        Me.btnSeleccionarPoligono.Name = "btnSeleccionarPoligono"
        Me.btnSeleccionarPoligono.Size = New System.Drawing.Size(173, 23)
        Me.btnSeleccionarPoligono.TabIndex = 50
        Me.btnSeleccionarPoligono.Text = "Seleccionar Polígono de dominio"
        Me.btnSeleccionarPoligono.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblUfUcOwner)
        Me.GroupBox2.Controls.Add(Me.cmbUf)
        Me.GroupBox2.Location = New System.Drawing.Point(322, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 53)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UF/UC a la que pertenece"
        '
        'lblUfUcOwner
        '
        Me.lblUfUcOwner.AutoSize = True
        Me.lblUfUcOwner.Location = New System.Drawing.Point(105, 26)
        Me.lblUfUcOwner.Name = "lblUfUcOwner"
        Me.lblUfUcOwner.Size = New System.Drawing.Size(13, 13)
        Me.lblUfUcOwner.TabIndex = 1
        Me.lblUfUcOwner.Text = "--"
        '
        'cmbUf
        '
        Me.cmbUf.FormattingEnabled = True
        Me.cmbUf.Location = New System.Drawing.Point(31, 21)
        Me.cmbUf.Name = "cmbUf"
        Me.cmbUf.Size = New System.Drawing.Size(60, 21)
        Me.cmbUf.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtPolDominioNombre)
        Me.GroupBox9.Location = New System.Drawing.Point(133, 39)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(166, 53)
        Me.GroupBox9.TabIndex = 48
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Denominación"
        '
        'txtPolDominioNombre
        '
        Me.txtPolDominioNombre.Location = New System.Drawing.Point(18, 20)
        Me.txtPolDominioNombre.Name = "txtPolDominioNombre"
        Me.txtPolDominioNombre.Size = New System.Drawing.Size(131, 20)
        Me.txtPolDominioNombre.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.btnPegarDatosSuperficie)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.lblSuperficieSeleccionado)
        Me.GroupBox4.Controls.Add(Me.btnSeleccionarSuperficie)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 134)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(522, 145)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SUPERFICIES"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.cmbPoligonosDominio)
        Me.GroupBox5.Location = New System.Drawing.Point(334, 43)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(180, 68)
        Me.GroupBox5.TabIndex = 50
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Polig. Domin. que pertenece"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(159, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "--"
        '
        'cmbPoligonosDominio
        '
        Me.cmbPoligonosDominio.FormattingEnabled = True
        Me.cmbPoligonosDominio.Location = New System.Drawing.Point(14, 28)
        Me.cmbPoligonosDominio.Name = "cmbPoligonosDominio"
        Me.cmbPoligonosDominio.Size = New System.Drawing.Size(130, 21)
        Me.cmbPoligonosDominio.TabIndex = 0
        '
        'btnPegarDatosSuperficie
        '
        Me.btnPegarDatosSuperficie.Location = New System.Drawing.Point(151, 116)
        Me.btnPegarDatosSuperficie.Name = "btnPegarDatosSuperficie"
        Me.btnPegarDatosSuperficie.Size = New System.Drawing.Size(236, 23)
        Me.btnPegarDatosSuperficie.TabIndex = 29
        Me.btnPegarDatosSuperficie.Text = "Pegar datos en superficie"
        Me.btnPegarDatosSuperficie.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 69)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de superficie"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.92754!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.07246!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rbCubierta, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbSemicubierta, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbDescubierta, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBalcon, 1, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(7, 14)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(302, 50)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'rbCubierta
        '
        Me.rbCubierta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbCubierta.AutoSize = True
        Me.rbCubierta.Location = New System.Drawing.Point(3, 3)
        Me.rbCubierta.Name = "rbCubierta"
        Me.rbCubierta.Size = New System.Drawing.Size(96, 19)
        Me.rbCubierta.TabIndex = 0
        Me.rbCubierta.TabStop = True
        Me.rbCubierta.Text = "Cubierta"
        Me.rbCubierta.UseVisualStyleBackColor = True
        '
        'rbSemicubierta
        '
        Me.rbSemicubierta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbSemicubierta.AutoSize = True
        Me.rbSemicubierta.Location = New System.Drawing.Point(105, 3)
        Me.rbSemicubierta.Name = "rbSemicubierta"
        Me.rbSemicubierta.Size = New System.Drawing.Size(93, 19)
        Me.rbSemicubierta.TabIndex = 1
        Me.rbSemicubierta.TabStop = True
        Me.rbSemicubierta.Text = "Semicubierta"
        Me.rbSemicubierta.UseVisualStyleBackColor = True
        '
        'rbDescubierta
        '
        Me.rbDescubierta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbDescubierta.AutoSize = True
        Me.rbDescubierta.Location = New System.Drawing.Point(3, 28)
        Me.rbDescubierta.Name = "rbDescubierta"
        Me.rbDescubierta.Size = New System.Drawing.Size(96, 19)
        Me.rbDescubierta.TabIndex = 2
        Me.rbDescubierta.TabStop = True
        Me.rbDescubierta.Text = "Descubierta"
        Me.rbDescubierta.UseVisualStyleBackColor = True
        '
        'rbBalcon
        '
        Me.rbBalcon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbBalcon.AutoSize = True
        Me.rbBalcon.Location = New System.Drawing.Point(105, 28)
        Me.rbBalcon.Name = "rbBalcon"
        Me.rbBalcon.Size = New System.Drawing.Size(93, 19)
        Me.rbBalcon.TabIndex = 3
        Me.rbBalcon.TabStop = True
        Me.rbBalcon.Text = "Balcón"
        Me.rbBalcon.UseVisualStyleBackColor = True
        '
        'lblSuperficieSeleccionado
        '
        Me.lblSuperficieSeleccionado.AutoSize = True
        Me.lblSuperficieSeleccionado.Location = New System.Drawing.Point(189, 21)
        Me.lblSuperficieSeleccionado.Name = "lblSuperficieSeleccionado"
        Me.lblSuperficieSeleccionado.Size = New System.Drawing.Size(13, 13)
        Me.lblSuperficieSeleccionado.TabIndex = 26
        Me.lblSuperficieSeleccionado.Text = "--"
        Me.lblSuperficieSeleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSeleccionarSuperficie
        '
        Me.btnSeleccionarSuperficie.Location = New System.Drawing.Point(8, 17)
        Me.btnSeleccionarSuperficie.Name = "btnSeleccionarSuperficie"
        Me.btnSeleccionarSuperficie.Size = New System.Drawing.Size(173, 23)
        Me.btnSeleccionarSuperficie.TabIndex = 25
        Me.btnSeleccionarSuperficie.Text = "Seleccionar superficie"
        Me.btnSeleccionarSuperficie.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(189, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Sup. :"
        '
        'frmPHPoligonoDominio
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(547, 454)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgvPolDomTotales)
        Me.Controls.Add(Me.dgvPolDom)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPHPoligonoDominio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poligonos de Dominio"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvPolDomTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPolDom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents dgvPolDomTotales As System.Windows.Forms.DataGridView
    Friend WithEvents totales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cubiertaT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents semicubT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descubiertaT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents balconT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totPolT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totUFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvPolDom As System.Windows.Forms.DataGridView
    Friend WithEvents cubierta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents semicub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descubierta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents balcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totPol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPegarDatosPolDom As System.Windows.Forms.Button
    Friend WithEvents lblPoligonoDominioSeleccionado As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionarPoligono As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUfUcOwner As System.Windows.Forms.Label
    Friend WithEvents cmbUf As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPolDominioNombre As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbCubierta As System.Windows.Forms.RadioButton
    Friend WithEvents rbSemicubierta As System.Windows.Forms.RadioButton
    Friend WithEvents rbDescubierta As System.Windows.Forms.RadioButton
    Friend WithEvents rbBalcon As System.Windows.Forms.RadioButton
    Friend WithEvents lblSuperficieSeleccionado As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionarSuperficie As System.Windows.Forms.Button
    Friend WithEvents btnPegarDatosSuperficie As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPoligonosDominio As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
