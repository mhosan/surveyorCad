<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPruebaParcela
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPruebaParcela))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.rumbos = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabNomenc = New System.Windows.Forms.Label()
        Me.LabSup = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BaseControlParcela = New VectorDraw.Professional.Control.VectorDrawBaseControl()
        Me.DgCalles = New System.Windows.Forms.DataGridView()
        Me.calle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pavimento = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.alumbrado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.energia = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gas = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cloacas = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.escuela = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.micros = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.domi = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.t_nomenclatura = New System.Windows.Forms.TextBox()
        Me.t_parcela = New System.Windows.Forms.TextBox()
        Me.t_superficie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgCalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Maroon
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(149, 482)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 30)
        Me.Button4.TabIndex = 49
        Me.Button4.Text = "Cerrar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Maroon
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(304, 482)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 30)
        Me.Button3.TabIndex = 48
        Me.Button3.Text = "Aceptar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'rumbos
        '
        Me.rumbos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rumbos.FormattingEnabled = True
        Me.rumbos.HorizontalScrollbar = True
        Me.rumbos.ItemHeight = 16
        Me.rumbos.Location = New System.Drawing.Point(8, 25)
        Me.rumbos.Name = "rumbos"
        Me.rumbos.Size = New System.Drawing.Size(497, 148)
        Me.rumbos.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(194, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 18)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Superficie: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 18)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Parcela:"
        '
        'LabNomenc
        '
        Me.LabNomenc.AutoSize = True
        Me.LabNomenc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabNomenc.Location = New System.Drawing.Point(11, 41)
        Me.LabNomenc.Name = "LabNomenc"
        Me.LabNomenc.Size = New System.Drawing.Size(108, 18)
        Me.LabNomenc.TabIndex = 52
        Me.LabNomenc.Text = "Nomenclatura:"
        '
        'LabSup
        '
        Me.LabSup.AutoSize = True
        Me.LabSup.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabSup.Location = New System.Drawing.Point(117, 79)
        Me.LabSup.Name = "LabSup"
        Me.LabSup.Size = New System.Drawing.Size(9, 20)
        Me.LabSup.TabIndex = 56
        Me.LabSup.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LabSup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rumbos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(522, 187)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rumbos | Medidas | Linderos|"
        '
        'BaseControlParcela
        '
        Me.BaseControlParcela.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.BaseControlParcela.AllowDrop = True
        Me.BaseControlParcela.Cursor = System.Windows.Forms.Cursors.Default
        Me.BaseControlParcela.DisableVdrawDxf = False
        Me.BaseControlParcela.EnableAutoGripOn = True
        Me.BaseControlParcela.Location = New System.Drawing.Point(697, 12)
        Me.BaseControlParcela.Name = "BaseControlParcela"
        Me.BaseControlParcela.Size = New System.Drawing.Size(10, 382)
        Me.BaseControlParcela.TabIndex = 60
        '
        'DgCalles
        '
        Me.DgCalles.CausesValidation = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgCalles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgCalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgCalles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.calle, Me.numero, Me.pavimento, Me.alumbrado, Me.energia, Me.gas, Me.cloacas, Me.escuela, Me.micros, Me.domi})
        Me.DgCalles.Location = New System.Drawing.Point(-1, 304)
        Me.DgCalles.Name = "DgCalles"
        Me.DgCalles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgCalles.RowHeadersVisible = False
        Me.DgCalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgCalles.Size = New System.Drawing.Size(531, 163)
        Me.DgCalles.TabIndex = 65
        '
        'calle
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.calle.DefaultCellStyle = DataGridViewCellStyle2
        Me.calle.HeaderText = "Calle"
        Me.calle.Name = "calle"
        Me.calle.Width = 107
        '
        'numero
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.numero.DefaultCellStyle = DataGridViewCellStyle3
        Me.numero.HeaderText = "Número"
        Me.numero.Name = "numero"
        Me.numero.Width = 50
        '
        'pavimento
        '
        Me.pavimento.HeaderText = "Pavi."
        Me.pavimento.Name = "pavimento"
        Me.pavimento.Width = 40
        '
        'alumbrado
        '
        Me.alumbrado.HeaderText = "Alum. P"
        Me.alumbrado.Name = "alumbrado"
        Me.alumbrado.Width = 40
        '
        'energia
        '
        Me.energia.HeaderText = "E. Eléctrica"
        Me.energia.Name = "energia"
        Me.energia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.energia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.energia.Width = 50
        '
        'gas
        '
        Me.gas.HeaderText = "Scio. Gas"
        Me.gas.Name = "gas"
        Me.gas.Width = 40
        '
        'cloacas
        '
        Me.cloacas.HeaderText = "Cloacas"
        Me.cloacas.Name = "cloacas"
        Me.cloacas.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cloacas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cloacas.Width = 50
        '
        'escuela
        '
        Me.escuela.HeaderText = "Escuela"
        Me.escuela.Name = "escuela"
        Me.escuela.Width = 50
        '
        'micros
        '
        Me.micros.HeaderText = "Micros"
        Me.micros.Name = "micros"
        Me.micros.Width = 50
        '
        'domi
        '
        Me.domi.HeaderText = "D.Fiscal"
        Me.domi.Name = "domi"
        Me.domi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.domi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.domi.Width = 50
        '
        't_nomenclatura
        '
        Me.t_nomenclatura.BackColor = System.Drawing.Color.Maroon
        Me.t_nomenclatura.ForeColor = System.Drawing.Color.White
        Me.t_nomenclatura.Location = New System.Drawing.Point(116, 40)
        Me.t_nomenclatura.Multiline = True
        Me.t_nomenclatura.Name = "t_nomenclatura"
        Me.t_nomenclatura.Size = New System.Drawing.Size(397, 24)
        Me.t_nomenclatura.TabIndex = 62
        Me.t_nomenclatura.Text = " "
        '
        't_parcela
        '
        Me.t_parcela.BackColor = System.Drawing.Color.Maroon
        Me.t_parcela.ForeColor = System.Drawing.Color.White
        Me.t_parcela.Location = New System.Drawing.Point(116, 80)
        Me.t_parcela.Name = "t_parcela"
        Me.t_parcela.Size = New System.Drawing.Size(72, 20)
        Me.t_parcela.TabIndex = 63
        '
        't_superficie
        '
        Me.t_superficie.BackColor = System.Drawing.Color.Maroon
        Me.t_superficie.ForeColor = System.Drawing.Color.White
        Me.t_superficie.Location = New System.Drawing.Point(276, 82)
        Me.t_superficie.Name = "t_superficie"
        Me.t_superficie.Size = New System.Drawing.Size(98, 20)
        Me.t_superficie.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(380, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 18)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "mts²"
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(522, 100)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Catastrales"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(751, 163)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(176, 21)
        Me.ComboBox1.TabIndex = 69
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Pavimento", "Alumbrado", "Energía Eléctrica", "Servicio Gas", "Cloacas", "Escuela", "Micros", "Domicilio Fiscal"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(765, 204)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(162, 124)
        Me.CheckedListBox1.TabIndex = 70
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(675, 391)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(233, 21)
        Me.ComboBox2.TabIndex = 71
        '
        'frmPruebaParcela
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(532, 524)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgCalles)
        Me.Controls.Add(Me.t_superficie)
        Me.Controls.Add(Me.t_parcela)
        Me.Controls.Add(Me.t_nomenclatura)
        Me.Controls.Add(Me.BaseControlParcela)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabNomenc)
        Me.Controls.Add(Me.LabSup)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPruebaParcela"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CPA"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgCalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents rumbos As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabNomenc As System.Windows.Forms.Label
    Friend WithEvents LabSup As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BaseControlParcela As VectorDraw.Professional.Control.VectorDrawBaseControl
    Friend WithEvents DgCalles As System.Windows.Forms.DataGridView
    Friend WithEvents t_nomenclatura As System.Windows.Forms.TextBox
    Friend WithEvents t_parcela As System.Windows.Forms.TextBox
    Friend WithEvents t_superficie As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents calle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pavimento As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents alumbrado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents energia As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents gas As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cloacas As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents escuela As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents micros As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents domi As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
