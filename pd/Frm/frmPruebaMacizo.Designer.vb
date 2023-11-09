<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPruebaMacizo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPruebaMacizo))
        Me.BaseControl11 = New VectorDraw.Professional.Control.VectorDrawBaseControl()
        Me.GBox2 = New System.Windows.Forms.GroupBox()
        Me.Tmanz_letra = New System.Windows.Forms.TextBox()
        Me.Tmanz = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Tfrac = New System.Windows.Forms.TextBox()
        Me.Tqui = New System.Windows.Forms.TextBox()
        Me.Tfrac_letra = New System.Windows.Forms.TextBox()
        Me.Tch_numero = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Tqui_letra = New System.Windows.Forms.TextBox()
        Me.Tsec = New System.Windows.Forms.TextBox()
        Me.Tch_letra = New System.Windows.Forms.TextBox()
        Me.Tcir = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.T_espacio_territorial = New System.Windows.Forms.TextBox()
        Me.TxtAnchoEspacioCirculatorio = New System.Windows.Forms.TextBox()
        Me.TxtNombreEspacioCirculatorio = New System.Windows.Forms.TextBox()
        Me.Combo_espacio_territorial = New System.Windows.Forms.ComboBox()
        Me.BtnSiguiente = New System.Windows.Forms.Button()
        Me.CbxTipoEspacioCirculatorio = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Radio_territorial = New System.Windows.Forms.RadioButton()
        Me.Radio_espacio_circulatorio = New System.Windows.Forms.RadioButton()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lmt = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LdelosLados = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'BaseControl11
        '
        Me.BaseControl11.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.BaseControl11.AllowDrop = True
        Me.BaseControl11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BaseControl11.Cursor = System.Windows.Forms.Cursors.No
        Me.BaseControl11.DisableVdrawDxf = False
        Me.BaseControl11.EnableAutoGripOn = True
        Me.BaseControl11.Location = New System.Drawing.Point(361, 12)
        Me.BaseControl11.Name = "BaseControl11"
        Me.BaseControl11.Size = New System.Drawing.Size(739, 551)
        Me.BaseControl11.TabIndex = 0
        '
        'GBox2
        '
        Me.GBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GBox2.Controls.Add(Me.Tmanz_letra)
        Me.GBox2.Controls.Add(Me.Tmanz)
        Me.GBox2.Controls.Add(Me.Label14)
        Me.GBox2.Controls.Add(Me.Tfrac)
        Me.GBox2.Controls.Add(Me.Tqui)
        Me.GBox2.Controls.Add(Me.Tfrac_letra)
        Me.GBox2.Controls.Add(Me.Tch_numero)
        Me.GBox2.Controls.Add(Me.Label13)
        Me.GBox2.Controls.Add(Me.Tqui_letra)
        Me.GBox2.Controls.Add(Me.Tsec)
        Me.GBox2.Controls.Add(Me.Tch_letra)
        Me.GBox2.Controls.Add(Me.Tcir)
        Me.GBox2.Controls.Add(Me.Label12)
        Me.GBox2.Controls.Add(Me.Label11)
        Me.GBox2.Controls.Add(Me.Label10)
        Me.GBox2.Controls.Add(Me.Label9)
        Me.GBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBox2.Location = New System.Drawing.Point(10, 15)
        Me.GBox2.Name = "GBox2"
        Me.GBox2.Size = New System.Drawing.Size(341, 71)
        Me.GBox2.TabIndex = 33
        Me.GBox2.TabStop = False
        Me.GBox2.Text = "Designación del Macizo"
        '
        'Tmanz_letra
        '
        Me.Tmanz_letra.BackColor = System.Drawing.Color.Green
        Me.Tmanz_letra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tmanz_letra.ForeColor = System.Drawing.Color.White
        Me.Tmanz_letra.Location = New System.Drawing.Point(308, 38)
        Me.Tmanz_letra.Name = "Tmanz_letra"
        Me.Tmanz_letra.Size = New System.Drawing.Size(25, 24)
        Me.Tmanz_letra.TabIndex = 39
        Me.Tmanz_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tmanz
        '
        Me.Tmanz.BackColor = System.Drawing.Color.Green
        Me.Tmanz.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tmanz.ForeColor = System.Drawing.Color.White
        Me.Tmanz.Location = New System.Drawing.Point(274, 38)
        Me.Tmanz.Name = "Tmanz"
        Me.Tmanz.Size = New System.Drawing.Size(34, 24)
        Me.Tmanz.TabIndex = 38
        Me.Tmanz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(271, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 16)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Manzana"
        '
        'Tfrac
        '
        Me.Tfrac.BackColor = System.Drawing.Color.Green
        Me.Tfrac.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tfrac.ForeColor = System.Drawing.Color.White
        Me.Tfrac.Location = New System.Drawing.Point(208, 38)
        Me.Tfrac.Name = "Tfrac"
        Me.Tfrac.Size = New System.Drawing.Size(35, 24)
        Me.Tfrac.TabIndex = 31
        Me.Tfrac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tqui
        '
        Me.Tqui.BackColor = System.Drawing.Color.Green
        Me.Tqui.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tqui.ForeColor = System.Drawing.Color.White
        Me.Tqui.Location = New System.Drawing.Point(145, 38)
        Me.Tqui.Name = "Tqui"
        Me.Tqui.Size = New System.Drawing.Size(34, 24)
        Me.Tqui.TabIndex = 30
        Me.Tqui.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tfrac_letra
        '
        Me.Tfrac_letra.BackColor = System.Drawing.Color.Green
        Me.Tfrac_letra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tfrac_letra.ForeColor = System.Drawing.Color.White
        Me.Tfrac_letra.Location = New System.Drawing.Point(240, 38)
        Me.Tfrac_letra.Name = "Tfrac_letra"
        Me.Tfrac_letra.Size = New System.Drawing.Size(25, 24)
        Me.Tfrac_letra.TabIndex = 35
        Me.Tfrac_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tch_numero
        '
        Me.Tch_numero.BackColor = System.Drawing.Color.Green
        Me.Tch_numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tch_numero.ForeColor = System.Drawing.Color.White
        Me.Tch_numero.Location = New System.Drawing.Point(83, 38)
        Me.Tch_numero.Name = "Tch_numero"
        Me.Tch_numero.Size = New System.Drawing.Size(34, 24)
        Me.Tch_numero.TabIndex = 29
        Me.Tch_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(208, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 16)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Fracción"
        '
        'Tqui_letra
        '
        Me.Tqui_letra.BackColor = System.Drawing.Color.Green
        Me.Tqui_letra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tqui_letra.ForeColor = System.Drawing.Color.White
        Me.Tqui_letra.Location = New System.Drawing.Point(177, 38)
        Me.Tqui_letra.Name = "Tqui_letra"
        Me.Tqui_letra.Size = New System.Drawing.Size(25, 24)
        Me.Tqui_letra.TabIndex = 34
        Me.Tqui_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tsec
        '
        Me.Tsec.BackColor = System.Drawing.Color.Green
        Me.Tsec.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsec.ForeColor = System.Drawing.Color.White
        Me.Tsec.Location = New System.Drawing.Point(45, 38)
        Me.Tsec.Name = "Tsec"
        Me.Tsec.Size = New System.Drawing.Size(34, 24)
        Me.Tsec.TabIndex = 28
        Me.Tsec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tch_letra
        '
        Me.Tch_letra.BackColor = System.Drawing.Color.Green
        Me.Tch_letra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tch_letra.ForeColor = System.Drawing.Color.White
        Me.Tch_letra.Location = New System.Drawing.Point(115, 38)
        Me.Tch_letra.Name = "Tch_letra"
        Me.Tch_letra.Size = New System.Drawing.Size(25, 24)
        Me.Tch_letra.TabIndex = 33
        Me.Tch_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tcir
        '
        Me.Tcir.BackColor = System.Drawing.Color.Green
        Me.Tcir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tcir.ForeColor = System.Drawing.Color.White
        Me.Tcir.Location = New System.Drawing.Point(12, 38)
        Me.Tcir.Name = "Tcir"
        Me.Tcir.Size = New System.Drawing.Size(30, 24)
        Me.Tcir.TabIndex = 27
        Me.Tcir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(151, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Quinta"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(86, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 16)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Chacra"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(44, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 16)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Secc"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 16)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Circ"
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.T_espacio_territorial)
        Me.GroupBox1.Controls.Add(Me.TxtAnchoEspacioCirculatorio)
        Me.GroupBox1.Controls.Add(Me.TxtNombreEspacioCirculatorio)
        Me.GroupBox1.Controls.Add(Me.Combo_espacio_territorial)
        Me.GroupBox1.Controls.Add(Me.BtnSiguiente)
        Me.GroupBox1.Controls.Add(Me.CbxTipoEspacioCirculatorio)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Radio_territorial)
        Me.GroupBox1.Controls.Add(Me.Radio_espacio_circulatorio)
        Me.GroupBox1.Controls.Add(Me.ShapeContainer1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(10, 130)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 328)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Linda con"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(176, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "mts"
        '
        'T_espacio_territorial
        '
        Me.T_espacio_territorial.Location = New System.Drawing.Point(79, 216)
        Me.T_espacio_territorial.Name = "T_espacio_territorial"
        Me.T_espacio_territorial.Size = New System.Drawing.Size(245, 22)
        Me.T_espacio_territorial.TabIndex = 12
        '
        'TxtAnchoEspacioCirculatorio
        '
        Me.TxtAnchoEspacioCirculatorio.Location = New System.Drawing.Point(81, 116)
        Me.TxtAnchoEspacioCirculatorio.Name = "TxtAnchoEspacioCirculatorio"
        Me.TxtAnchoEspacioCirculatorio.Size = New System.Drawing.Size(89, 22)
        Me.TxtAnchoEspacioCirculatorio.TabIndex = 11
        Me.TxtAnchoEspacioCirculatorio.Text = "15"
        Me.TxtAnchoEspacioCirculatorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNombreEspacioCirculatorio
        '
        Me.TxtNombreEspacioCirculatorio.Location = New System.Drawing.Point(81, 88)
        Me.TxtNombreEspacioCirculatorio.Name = "TxtNombreEspacioCirculatorio"
        Me.TxtNombreEspacioCirculatorio.Size = New System.Drawing.Size(243, 22)
        Me.TxtNombreEspacioCirculatorio.TabIndex = 10
        Me.TxtNombreEspacioCirculatorio.Text = "Presidente Peron"
        '
        'Combo_espacio_territorial
        '
        Me.Combo_espacio_territorial.FormattingEnabled = True
        Me.Combo_espacio_territorial.Items.AddRange(New Object() {"Macizo", "Mar", "Laguna", "Río", "Campo"})
        Me.Combo_espacio_territorial.Location = New System.Drawing.Point(79, 184)
        Me.Combo_espacio_territorial.Name = "Combo_espacio_territorial"
        Me.Combo_espacio_territorial.Size = New System.Drawing.Size(89, 24)
        Me.Combo_espacio_territorial.TabIndex = 9
        '
        'BtnSiguiente
        '
        Me.BtnSiguiente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSiguiente.ForeColor = System.Drawing.Color.Maroon
        Me.BtnSiguiente.Location = New System.Drawing.Point(5, 271)
        Me.BtnSiguiente.Name = "BtnSiguiente"
        Me.BtnSiguiente.Size = New System.Drawing.Size(331, 35)
        Me.BtnSiguiente.TabIndex = 2
        Me.BtnSiguiente.Text = "Siguiente >>"
        Me.BtnSiguiente.UseVisualStyleBackColor = False
        '
        'CbxTipoEspacioCirculatorio
        '
        Me.CbxTipoEspacioCirculatorio.FormattingEnabled = True
        Me.CbxTipoEspacioCirculatorio.Items.AddRange(New Object() {"Calle", "Avenida"})
        Me.CbxTipoEspacioCirculatorio.Location = New System.Drawing.Point(81, 58)
        Me.CbxTipoEspacioCirculatorio.Name = "CbxTipoEspacioCirculatorio"
        Me.CbxTipoEspacioCirculatorio.Size = New System.Drawing.Size(89, 24)
        Me.CbxTipoEspacioCirculatorio.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nombre"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ancho"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo"
        '
        'Radio_territorial
        '
        Me.Radio_territorial.AutoSize = True
        Me.Radio_territorial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_territorial.Location = New System.Drawing.Point(24, 155)
        Me.Radio_territorial.Name = "Radio_territorial"
        Me.Radio_territorial.Size = New System.Drawing.Size(153, 24)
        Me.Radio_territorial.TabIndex = 1
        Me.Radio_territorial.TabStop = True
        Me.Radio_territorial.Text = "Espacio Territorial"
        Me.Radio_territorial.UseVisualStyleBackColor = True
        '
        'Radio_espacio_circulatorio
        '
        Me.Radio_espacio_circulatorio.AutoSize = True
        Me.Radio_espacio_circulatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_espacio_circulatorio.Location = New System.Drawing.Point(24, 30)
        Me.Radio_espacio_circulatorio.Name = "Radio_espacio_circulatorio"
        Me.Radio_espacio_circulatorio.Size = New System.Drawing.Size(167, 24)
        Me.Radio_espacio_circulatorio.TabIndex = 0
        Me.Radio_espacio_circulatorio.TabStop = True
        Me.Radio_espacio_circulatorio.Text = "Espacio Circulatorio"
        Me.Radio_espacio_circulatorio.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 18)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(336, 307)
        Me.ShapeContainer1.TabIndex = 13
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.BorderWidth = 3
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = -2
        Me.LineShape2.X2 = 333
        Me.LineShape2.Y1 = 243
        Me.LineShape2.Y2 = 245
        '
        'LineShape1
        '
        Me.LineShape1.BorderWidth = 3
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = -1
        Me.LineShape1.X2 = 330
        Me.LineShape1.Y1 = 130
        Me.LineShape1.Y2 = 130
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Controls.Add(Me.Lmt)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.LdelosLados)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(10, 92)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(340, 32)
        Me.Panel1.TabIndex = 35
        '
        'Lmt
        '
        Me.Lmt.AutoSize = True
        Me.Lmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lmt.ForeColor = System.Drawing.Color.White
        Me.Lmt.Location = New System.Drawing.Point(218, 5)
        Me.Lmt.Name = "Lmt"
        Me.Lmt.Size = New System.Drawing.Size(0, 24)
        Me.Lmt.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(149, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 25)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Mide:"
        '
        'LdelosLados
        '
        Me.LdelosLados.AutoSize = True
        Me.LdelosLados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LdelosLados.ForeColor = System.Drawing.Color.White
        Me.LdelosLados.Location = New System.Drawing.Point(90, 4)
        Me.LdelosLados.Name = "LdelosLados"
        Me.LdelosLados.Size = New System.Drawing.Size(0, 24)
        Me.LdelosLados.TabIndex = 1
        Me.LdelosLados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Lado:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Controls.Add(Me.BtnAceptar)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Location = New System.Drawing.Point(2, 497)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(360, 59)
        Me.GroupBox4.TabIndex = 51
        Me.GroupBox4.TabStop = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Maroon
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAceptar.Location = New System.Drawing.Point(211, 19)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(112, 31)
        Me.BtnAceptar.TabIndex = 17
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(47, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 31)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmPruebaMacizo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1103, 557)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GBox2)
        Me.Controls.Add(Me.BaseControl11)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPruebaMacizo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Consejo Profesional de Agrimensores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GBox2.ResumeLayout(False)
        Me.GBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BaseControl11 As VectorDraw.Professional.Control.VectorDrawBaseControl
    Friend WithEvents GBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Tmanz_letra As System.Windows.Forms.TextBox
    Friend WithEvents Tmanz As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Tfrac As System.Windows.Forms.TextBox
    Friend WithEvents Tqui As System.Windows.Forms.TextBox
    Friend WithEvents Tfrac_letra As System.Windows.Forms.TextBox
    Friend WithEvents Tch_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Tqui_letra As System.Windows.Forms.TextBox
    Friend WithEvents Tsec As System.Windows.Forms.TextBox
    Friend WithEvents Tch_letra As System.Windows.Forms.TextBox
    Friend WithEvents Tcir As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents T_espacio_territorial As System.Windows.Forms.TextBox
    Friend WithEvents TxtAnchoEspacioCirculatorio As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombreEspacioCirculatorio As System.Windows.Forms.TextBox
    Friend WithEvents Combo_espacio_territorial As System.Windows.Forms.ComboBox
    Friend WithEvents BtnSiguiente As System.Windows.Forms.Button
    Friend WithEvents CbxTipoEspacioCirculatorio As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Radio_territorial As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_espacio_circulatorio As System.Windows.Forms.RadioButton
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lmt As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LdelosLados As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
