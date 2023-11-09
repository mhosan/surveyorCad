<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPHUnidadesComplementarias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPHUnidadesComplementarias))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.btnSacaDeGrilla = New System.Windows.Forms.Button()
        Me.btnAgregaAGrilla = New System.Windows.Forms.Button()
        Me.dgvPH = New System.Windows.Forms.DataGridView()
        Me.uc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.poligonos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cubierta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.semicub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descubierta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.balcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totPol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totUF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.defUf = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.nudCantUC = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.poligono = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancelaAttPolDom = New System.Windows.Forms.Button()
        Me.lblPoligonoDominioSeleccionado = New System.Windows.Forms.Label()
        Me.btnSeleccionarPoligono = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblUfUcOwner = New System.Windows.Forms.Label()
        Me.cmbUfUc = New System.Windows.Forms.ComboBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtPolDominioNombre = New System.Windows.Forms.TextBox()
        Me.superficies = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblPolDomOwner = New System.Windows.Forms.Label()
        Me.cmbPoligonosDominio = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAceptarAtributos = New System.Windows.Forms.Button()
        Me.btnCancelarAtributos = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbCubierta = New System.Windows.Forms.RadioButton()
        Me.rbSemicubierta = New System.Windows.Forms.RadioButton()
        Me.rbDescubierta = New System.Windows.Forms.RadioButton()
        Me.rbBalcon = New System.Windows.Forms.RadioButton()
        Me.rbSuperpuesta = New System.Windows.Forms.RadioButton()
        Me.lblSuperficieSeleccionado = New System.Windows.Forms.Label()
        Me.btnSeleccionarSuperficie = New System.Windows.Forms.Button()
        Me.dibujar = New System.Windows.Forms.TabPage()
        Me.btnDibujarPlanilla = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvPH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.defUf.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.nudCantUC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.poligono.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.superficies.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.dibujar.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(356, 437)
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
        'btnSacaDeGrilla
        '
        Me.btnSacaDeGrilla.Image = CType(resources.GetObject("btnSacaDeGrilla.Image"), System.Drawing.Image)
        Me.btnSacaDeGrilla.Location = New System.Drawing.Point(267, 213)
        Me.btnSacaDeGrilla.Name = "btnSacaDeGrilla"
        Me.btnSacaDeGrilla.Size = New System.Drawing.Size(27, 23)
        Me.btnSacaDeGrilla.TabIndex = 33
        Me.btnSacaDeGrilla.UseVisualStyleBackColor = True
        '
        'btnAgregaAGrilla
        '
        Me.btnAgregaAGrilla.Image = CType(resources.GetObject("btnAgregaAGrilla.Image"), System.Drawing.Image)
        Me.btnAgregaAGrilla.Location = New System.Drawing.Point(226, 213)
        Me.btnAgregaAGrilla.Name = "btnAgregaAGrilla"
        Me.btnAgregaAGrilla.Size = New System.Drawing.Size(27, 23)
        Me.btnAgregaAGrilla.TabIndex = 32
        Me.btnAgregaAGrilla.UseVisualStyleBackColor = True
        '
        'dgvPH
        '
        Me.dgvPH.AllowUserToAddRows = False
        Me.dgvPH.AllowUserToDeleteRows = False
        Me.dgvPH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPH.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.uc, Me.poligonos, Me.cubierta, Me.semicub, Me.descubierta, Me.balcon, Me.totPol, Me.totUF})
        Me.dgvPH.Location = New System.Drawing.Point(12, 245)
        Me.dgvPH.Name = "dgvPH"
        Me.dgvPH.RowHeadersVisible = False
        Me.dgvPH.Size = New System.Drawing.Size(490, 182)
        Me.dgvPH.TabIndex = 31
        '
        'uc
        '
        Me.uc.HeaderText = "uc"
        Me.uc.Name = "uc"
        Me.uc.ReadOnly = True
        '
        'poligonos
        '
        Me.poligonos.HeaderText = "poligonos"
        Me.poligonos.Name = "poligonos"
        Me.poligonos.ReadOnly = True
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
        'totUF
        '
        Me.totUF.HeaderText = "totUF"
        Me.totUF.Name = "totUF"
        Me.totUF.ReadOnly = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.defUf)
        Me.TabControl1.Controls.Add(Me.poligono)
        Me.TabControl1.Controls.Add(Me.superficies)
        Me.TabControl1.Controls.Add(Me.dibujar)
        Me.TabControl1.Location = New System.Drawing.Point(74, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(366, 207)
        Me.TabControl1.TabIndex = 30
        '
        'defUf
        '
        Me.defUf.Controls.Add(Me.GroupBox7)
        Me.defUf.Location = New System.Drawing.Point(4, 22)
        Me.defUf.Name = "defUf"
        Me.defUf.Padding = New System.Windows.Forms.Padding(3)
        Me.defUf.Size = New System.Drawing.Size(358, 181)
        Me.defUf.TabIndex = 0
        Me.defUf.Text = "Definición Uc"
        Me.defUf.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.nudCantUC)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Location = New System.Drawing.Point(30, 54)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(298, 40)
        Me.GroupBox7.TabIndex = 8
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Unidades Complementarias"
        '
        'nudCantUC
        '
        Me.nudCantUC.Location = New System.Drawing.Point(169, 14)
        Me.nudCantUC.Name = "nudCantUC"
        Me.nudCantUC.Size = New System.Drawing.Size(56, 20)
        Me.nudCantUC.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cantidad unidades:"
        '
        'poligono
        '
        Me.poligono.Controls.Add(Me.Label1)
        Me.poligono.Controls.Add(Me.TableLayoutPanel4)
        Me.poligono.Controls.Add(Me.lblPoligonoDominioSeleccionado)
        Me.poligono.Controls.Add(Me.btnSeleccionarPoligono)
        Me.poligono.Controls.Add(Me.GroupBox2)
        Me.poligono.Controls.Add(Me.GroupBox9)
        Me.poligono.Location = New System.Drawing.Point(4, 22)
        Me.poligono.Name = "poligono"
        Me.poligono.Padding = New System.Windows.Forms.Padding(3)
        Me.poligono.Size = New System.Drawing.Size(358, 181)
        Me.poligono.TabIndex = 1
        Me.poligono.Text = "Polígono Dominio"
        Me.poligono.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(157, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Area:"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnCancelaAttPolDom, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(41, 144)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(276, 29)
        Me.TableLayoutPanel4.TabIndex = 13
        '
        'btnCancelaAttPolDom
        '
        Me.btnCancelaAttPolDom.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelaAttPolDom.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelaAttPolDom.Location = New System.Drawing.Point(141, 3)
        Me.btnCancelaAttPolDom.Name = "btnCancelaAttPolDom"
        Me.btnCancelaAttPolDom.Size = New System.Drawing.Size(132, 23)
        Me.btnCancelaAttPolDom.TabIndex = 1
        Me.btnCancelaAttPolDom.Text = "Cancelar Atributos"
        '
        'lblPoligonoDominioSeleccionado
        '
        Me.lblPoligonoDominioSeleccionado.AutoSize = True
        Me.lblPoligonoDominioSeleccionado.Location = New System.Drawing.Point(198, 14)
        Me.lblPoligonoDominioSeleccionado.Name = "lblPoligonoDominioSeleccionado"
        Me.lblPoligonoDominioSeleccionado.Size = New System.Drawing.Size(13, 13)
        Me.lblPoligonoDominioSeleccionado.TabIndex = 12
        Me.lblPoligonoDominioSeleccionado.Text = "--"
        '
        'btnSeleccionarPoligono
        '
        Me.btnSeleccionarPoligono.Location = New System.Drawing.Point(5, 8)
        Me.btnSeleccionarPoligono.Name = "btnSeleccionarPoligono"
        Me.btnSeleccionarPoligono.Size = New System.Drawing.Size(132, 23)
        Me.btnSeleccionarPoligono.TabIndex = 11
        Me.btnSeleccionarPoligono.Text = "Seleccionar Polígono"
        Me.btnSeleccionarPoligono.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblUfUcOwner)
        Me.GroupBox2.Controls.Add(Me.cmbUfUc)
        Me.GroupBox2.Location = New System.Drawing.Point(47, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 53)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UF/UC a la que pertenece"
        '
        'lblUfUcOwner
        '
        Me.lblUfUcOwner.AutoSize = True
        Me.lblUfUcOwner.Location = New System.Drawing.Point(144, 26)
        Me.lblUfUcOwner.Name = "lblUfUcOwner"
        Me.lblUfUcOwner.Size = New System.Drawing.Size(13, 13)
        Me.lblUfUcOwner.TabIndex = 1
        Me.lblUfUcOwner.Text = "--"
        '
        'cmbUfUc
        '
        Me.cmbUfUc.FormattingEnabled = True
        Me.cmbUfUc.Location = New System.Drawing.Point(10, 21)
        Me.cmbUfUc.Name = "cmbUfUc"
        Me.cmbUfUc.Size = New System.Drawing.Size(128, 21)
        Me.cmbUfUc.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtPolDominioNombre)
        Me.GroupBox9.Location = New System.Drawing.Point(47, 34)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(264, 53)
        Me.GroupBox9.TabIndex = 9
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Denominación"
        '
        'txtPolDominioNombre
        '
        Me.txtPolDominioNombre.Location = New System.Drawing.Point(24, 20)
        Me.txtPolDominioNombre.Name = "txtPolDominioNombre"
        Me.txtPolDominioNombre.Size = New System.Drawing.Size(217, 20)
        Me.txtPolDominioNombre.TabIndex = 0
        '
        'superficies
        '
        Me.superficies.Controls.Add(Me.GroupBox3)
        Me.superficies.Controls.Add(Me.TableLayoutPanel3)
        Me.superficies.Controls.Add(Me.GroupBox1)
        Me.superficies.Controls.Add(Me.lblSuperficieSeleccionado)
        Me.superficies.Controls.Add(Me.btnSeleccionarSuperficie)
        Me.superficies.Location = New System.Drawing.Point(4, 22)
        Me.superficies.Name = "superficies"
        Me.superficies.Size = New System.Drawing.Size(358, 181)
        Me.superficies.TabIndex = 2
        Me.superficies.Text = "Superficies"
        Me.superficies.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblPolDomOwner)
        Me.GroupBox3.Controls.Add(Me.cmbPoligonosDominio)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(317, 43)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Polígono de Dominio al que pertenece"
        '
        'lblPolDomOwner
        '
        Me.lblPolDomOwner.AutoSize = True
        Me.lblPolDomOwner.Location = New System.Drawing.Point(125, 21)
        Me.lblPolDomOwner.Name = "lblPolDomOwner"
        Me.lblPolDomOwner.Size = New System.Drawing.Size(13, 13)
        Me.lblPolDomOwner.TabIndex = 1
        Me.lblPolDomOwner.Text = "--"
        '
        'cmbPoligonosDominio
        '
        Me.cmbPoligonosDominio.FormattingEnabled = True
        Me.cmbPoligonosDominio.Location = New System.Drawing.Point(10, 16)
        Me.cmbPoligonosDominio.Name = "cmbPoligonosDominio"
        Me.cmbPoligonosDominio.Size = New System.Drawing.Size(107, 21)
        Me.cmbPoligonosDominio.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnAceptarAtributos, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnCancelarAtributos, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(41, 148)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(276, 29)
        Me.TableLayoutPanel3.TabIndex = 11
        '
        'btnAceptarAtributos
        '
        Me.btnAceptarAtributos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAceptarAtributos.Location = New System.Drawing.Point(3, 3)
        Me.btnAceptarAtributos.Name = "btnAceptarAtributos"
        Me.btnAceptarAtributos.Size = New System.Drawing.Size(132, 23)
        Me.btnAceptarAtributos.TabIndex = 0
        Me.btnAceptarAtributos.Text = "Aceptar Atributos"
        '
        'btnCancelarAtributos
        '
        Me.btnCancelarAtributos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelarAtributos.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarAtributos.Location = New System.Drawing.Point(141, 3)
        Me.btnCancelarAtributos.Name = "btnCancelarAtributos"
        Me.btnCancelarAtributos.Size = New System.Drawing.Size(132, 23)
        Me.btnCancelarAtributos.TabIndex = 1
        Me.btnCancelarAtributos.Text = "Cancelar Atributos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 71)
        Me.GroupBox1.TabIndex = 10
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
        Me.TableLayoutPanel2.Controls.Add(Me.rbSuperpuesta, 2, 0)
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
        'rbSuperpuesta
        '
        Me.rbSuperpuesta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbSuperpuesta.AutoSize = True
        Me.rbSuperpuesta.Location = New System.Drawing.Point(204, 3)
        Me.rbSuperpuesta.Name = "rbSuperpuesta"
        Me.rbSuperpuesta.Size = New System.Drawing.Size(95, 19)
        Me.rbSuperpuesta.TabIndex = 4
        Me.rbSuperpuesta.TabStop = True
        Me.rbSuperpuesta.Text = "Superpuesta"
        Me.rbSuperpuesta.UseVisualStyleBackColor = True
        '
        'lblSuperficieSeleccionado
        '
        Me.lblSuperficieSeleccionado.AutoSize = True
        Me.lblSuperficieSeleccionado.Location = New System.Drawing.Point(144, 11)
        Me.lblSuperficieSeleccionado.Name = "lblSuperficieSeleccionado"
        Me.lblSuperficieSeleccionado.Size = New System.Drawing.Size(13, 13)
        Me.lblSuperficieSeleccionado.TabIndex = 8
        Me.lblSuperficieSeleccionado.Text = "--"
        '
        'btnSeleccionarSuperficie
        '
        Me.btnSeleccionarSuperficie.Location = New System.Drawing.Point(8, 5)
        Me.btnSeleccionarSuperficie.Name = "btnSeleccionarSuperficie"
        Me.btnSeleccionarSuperficie.Size = New System.Drawing.Size(132, 23)
        Me.btnSeleccionarSuperficie.TabIndex = 7
        Me.btnSeleccionarSuperficie.Text = "Seleccionar superficie"
        Me.btnSeleccionarSuperficie.UseVisualStyleBackColor = True
        '
        'dibujar
        '
        Me.dibujar.Controls.Add(Me.btnDibujarPlanilla)
        Me.dibujar.Location = New System.Drawing.Point(4, 22)
        Me.dibujar.Name = "dibujar"
        Me.dibujar.Padding = New System.Windows.Forms.Padding(3)
        Me.dibujar.Size = New System.Drawing.Size(358, 181)
        Me.dibujar.TabIndex = 3
        Me.dibujar.Text = "Dibujar Planilla"
        Me.dibujar.UseVisualStyleBackColor = True
        '
        'btnDibujarPlanilla
        '
        Me.btnDibujarPlanilla.Location = New System.Drawing.Point(113, 102)
        Me.btnDibujarPlanilla.Name = "btnDibujarPlanilla"
        Me.btnDibujarPlanilla.Size = New System.Drawing.Size(132, 23)
        Me.btnDibujarPlanilla.TabIndex = 8
        Me.btnDibujarPlanilla.Text = "Seleccionar punto"
        Me.btnDibujarPlanilla.UseVisualStyleBackColor = True
        '
        'frmUnidadesComplementarias
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(514, 478)
        Me.Controls.Add(Me.btnSacaDeGrilla)
        Me.Controls.Add(Me.btnAgregaAGrilla)
        Me.Controls.Add(Me.dgvPH)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUnidadesComplementarias"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unidades complementarias"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvPH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.defUf.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.nudCantUC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.poligono.ResumeLayout(False)
        Me.poligono.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.superficies.ResumeLayout(False)
        Me.superficies.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.dibujar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents btnSacaDeGrilla As System.Windows.Forms.Button
    Friend WithEvents btnAgregaAGrilla As System.Windows.Forms.Button
    Friend WithEvents dgvPH As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents defUf As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents nudCantUC As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents poligono As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCancelaAttPolDom As System.Windows.Forms.Button
    Friend WithEvents lblPoligonoDominioSeleccionado As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionarPoligono As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUfUcOwner As System.Windows.Forms.Label
    Friend WithEvents cmbUfUc As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPolDominioNombre As System.Windows.Forms.TextBox
    Friend WithEvents superficies As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPolDomOwner As System.Windows.Forms.Label
    Friend WithEvents cmbPoligonosDominio As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAceptarAtributos As System.Windows.Forms.Button
    Friend WithEvents btnCancelarAtributos As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbCubierta As System.Windows.Forms.RadioButton
    Friend WithEvents rbSemicubierta As System.Windows.Forms.RadioButton
    Friend WithEvents rbDescubierta As System.Windows.Forms.RadioButton
    Friend WithEvents rbBalcon As System.Windows.Forms.RadioButton
    Friend WithEvents rbSuperpuesta As System.Windows.Forms.RadioButton
    Friend WithEvents lblSuperficieSeleccionado As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionarSuperficie As System.Windows.Forms.Button
    Friend WithEvents dibujar As System.Windows.Forms.TabPage
    Friend WithEvents btnDibujarPlanilla As System.Windows.Forms.Button
    Friend WithEvents uc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents poligonos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cubierta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents semicub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descubierta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents balcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totPol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totUF As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
