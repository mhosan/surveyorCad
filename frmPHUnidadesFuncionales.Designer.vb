<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPHUnidadesFuncionales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPHUnidadesFuncionales))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.dgvPH = New System.Windows.Forms.DataGridView()
        Me.uf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.poligonos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cubierta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.semicub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descubierta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.balcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totPol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totUF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAgregaAGrilla = New System.Windows.Forms.Button()
        Me.btnSacaDeGrilla = New System.Windows.Forms.Button()
        Me.dgvPhTotales = New System.Windows.Forms.DataGridView()
        Me.totales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cubiertaT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.semicubT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descubiertaT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.balconT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totPolT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totUFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.nudCantUF = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPhTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nudCantUF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(673, 294)
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
        'dgvPH
        '
        Me.dgvPH.AllowUserToAddRows = False
        Me.dgvPH.AllowUserToDeleteRows = False
        Me.dgvPH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPH.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.uf, Me.poligonos, Me.cubierta, Me.semicub, Me.descubierta, Me.balcon, Me.totPol, Me.totUF})
        Me.dgvPH.Location = New System.Drawing.Point(12, 104)
        Me.dgvPH.Name = "dgvPH"
        Me.dgvPH.RowHeadersVisible = False
        Me.dgvPH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPH.Size = New System.Drawing.Size(803, 149)
        Me.dgvPH.TabIndex = 7
        '
        'uf
        '
        Me.uf.HeaderText = "uf"
        Me.uf.Name = "uf"
        Me.uf.ReadOnly = True
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
        'btnAgregaAGrilla
        '
        Me.btnAgregaAGrilla.Image = CType(resources.GetObject("btnAgregaAGrilla.Image"), System.Drawing.Image)
        Me.btnAgregaAGrilla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregaAGrilla.Location = New System.Drawing.Point(9, 54)
        Me.btnAgregaAGrilla.Name = "btnAgregaAGrilla"
        Me.btnAgregaAGrilla.Size = New System.Drawing.Size(121, 23)
        Me.btnAgregaAGrilla.TabIndex = 29
        Me.btnAgregaAGrilla.Text = "Agregar a la planilla"
        Me.btnAgregaAGrilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnAgregaAGrilla, "Agregar a la planilla")
        Me.btnAgregaAGrilla.UseVisualStyleBackColor = True
        '
        'btnSacaDeGrilla
        '
        Me.btnSacaDeGrilla.Image = CType(resources.GetObject("btnSacaDeGrilla.Image"), System.Drawing.Image)
        Me.btnSacaDeGrilla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSacaDeGrilla.Location = New System.Drawing.Point(138, 54)
        Me.btnSacaDeGrilla.Name = "btnSacaDeGrilla"
        Me.btnSacaDeGrilla.Size = New System.Drawing.Size(120, 23)
        Me.btnSacaDeGrilla.TabIndex = 30
        Me.btnSacaDeGrilla.Text = "Sacar de la planilla"
        Me.btnSacaDeGrilla.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSacaDeGrilla, "Sacar de la planilla")
        Me.btnSacaDeGrilla.UseVisualStyleBackColor = True
        '
        'dgvPhTotales
        '
        Me.dgvPhTotales.AllowUserToAddRows = False
        Me.dgvPhTotales.AllowUserToDeleteRows = False
        Me.dgvPhTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPhTotales.ColumnHeadersVisible = False
        Me.dgvPhTotales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.totales, Me.cubiertaT, Me.semicubT, Me.descubiertaT, Me.balconT, Me.totPolT, Me.totUFT})
        Me.dgvPhTotales.Location = New System.Drawing.Point(12, 258)
        Me.dgvPhTotales.Name = "dgvPhTotales"
        Me.dgvPhTotales.RowHeadersVisible = False
        Me.dgvPhTotales.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvPhTotales.Size = New System.Drawing.Size(803, 26)
        Me.dgvPhTotales.TabIndex = 30
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnSacaDeGrilla)
        Me.GroupBox5.Controls.Add(Me.btnAgregaAGrilla)
        Me.GroupBox5.Controls.Add(Me.nudCantUF)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(267, 86)
        Me.GroupBox5.TabIndex = 31
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Unidades Funcionales"
        '
        'nudCantUF
        '
        Me.nudCantUF.Location = New System.Drawing.Point(144, 21)
        Me.nudCantUF.Name = "nudCantUF"
        Me.nudCantUF.Size = New System.Drawing.Size(56, 20)
        Me.nudCantUF.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cantidad unidades:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButton2)
        Me.GroupBox4.Controls.Add(Me.RadioButton1)
        Me.GroupBox4.Location = New System.Drawing.Point(293, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(209, 51)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Superpuestas"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(91, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(41, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "NO"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(46, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(35, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "SI"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'frmPHUnidadesFuncionales
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(825, 331)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.dgvPhTotales)
        Me.Controls.Add(Me.dgvPH)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPHUnidadesFuncionales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unidades funcionales"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPhTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nudCantUF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents dgvPH As System.Windows.Forms.DataGridView
    Friend WithEvents uf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents poligonos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cubierta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents semicub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descubierta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents balcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totPol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totUF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents dgvPhTotales As System.Windows.Forms.DataGridView
    Friend WithEvents totales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cubiertaT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents semicubT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descubiertaT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents balconT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totPolT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totUFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents nudCantUF As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnSacaDeGrilla As System.Windows.Forms.Button
    Friend WithEvents btnAgregaAGrilla As System.Windows.Forms.Button

End Class
