Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports System.Windows.Controls
Imports mhCad.BO.Persona

Public Class frmInicial
    Private mKeyAscii As Integer
    Public modifico As Boolean
    Public row As DataRow
    Public Titu As New BO.Persona
    Dim partido As DataTable = New DataTable
    Dim obra_exis As DataTable = New DataTable


    Function VerValor(ByVal Simbolo As String) As String
        Select Case Simbolo
            Case "1"
                VerValor = "I"
            Case "2"
                VerValor = "II"
            Case "3"
                VerValor = "III"
            Case "4"
                VerValor = "IV"
            Case "5"
                VerValor = "V"
            Case "6"
                VerValor = "VI"
            Case "7"
                VerValor = "VII"
            Case "8"
                VerValor = "VIII"
            Case "9"
                VerValor = "IX"
            Case "10"
                VerValor = "X"
            Case "11"
                VerValor = "XI"
            Case "12"
                VerValor = "XII"
            Case "13"
                VerValor = "XIII"
            Case "14"
                VerValor = "XIV"
            Case "15"
                VerValor = "XV"
            Case "16"
                VerValor = "XVI"
            Case "17"
                VerValor = "XVII"
            Case "18"
                VerValor = "XVIII"
            Case "19"
                VerValor = "XIX"
            Case "20"
                VerValor = "XX"
        End Select


    End Function
    Private Function lF_iSoloLetras(ByVal KeyAscii As Integer) As Integer
        KeyAscii = Asc(UCase(Chr(KeyAscii))) 'Transformar letras minusculas a Masyusculas
        ' Intercepta un codigo ASCII recibido admitiendo solamente letras, además deja pasar sin afectar si recibe tecla de Backspace o enter
        If InStr("IVX0123456789", Chr(KeyAscii)) = 0 Then
            ' teclas adicionales permitidas
            If KeyAscii = 8 Then    ' Backspace
                Return KeyAscii
            ElseIf KeyAscii = 13 Then   ' Enter
                Return KeyAscii
            Else
                Return 0
            End If
        Else
            Return KeyAscii
        End If
    End Function
    Private Function lF_iSolonumeros(ByVal KeyAscii As Integer) As Integer
        KeyAscii = Asc(UCase(Chr(KeyAscii))) 'Transformar letras minusculas a Masyusculas
        ' Intercepta un codigo ASCII recibido admitiendo solamente letras, además deja pasar sin afectar si recibe tecla de Backspace o enter
        If InStr("0123456789", Chr(KeyAscii)) = 0 Then
            ' teclas adicionales permitidas
            If KeyAscii = 8 Then    ' Backspace
                Return KeyAscii
            ElseIf KeyAscii = 13 Then   ' Enter
                Return KeyAscii
            Else
                Return 0
            End If
        Else
            Return KeyAscii
        End If
    End Function
    Private Sub Limpiar_Cajas(ByVal f As Form)
        '/// Recorrer todos los controles del formulario indicado  
        For Each c As Control In f.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
    End Sub
    Private Sub Cambio_Color(ByVal f As Form)
        ' ///Recorre todos los controles del formulario indicado  
        For Each c As Control In f.Controls
            If TypeOf c Is ComboBox Then
            End If
        Next
    End Sub
    '/// Procedimento para volcar los datos en los campos del fomulario Inicial
    Sub cargo_datos_persona()
        If bandera = 1 Then '// Bandera queda en uno si el llamado, y entro al fomulario partido para traer los datos personales
            If Not String.IsNullOrEmpty(tipo_persona_1) Then Tcliente.Text = tipo_peronsa_apellido & "," & " " & tipo_peronsa_nombre
            If Not String.IsNullOrEmpty(tipo_persona_2) Then Tcontribuyene.Text = tipo_peronsa_apellido & "," & " " & tipo_peronsa_nombre
            If Not String.IsNullOrEmpty(tipo_persona_3) Then Ttitular.Text = tipo_peronsa_apellido & "," & " " & tipo_peronsa_nombre
            If Not String.IsNullOrEmpty(tipo_persona_4) Then Tcomitente.Text = tipo_peronsa_apellido & "," & " " & tipo_peronsa_nombre
            If Not String.IsNullOrEmpty(tipo_persona_5) Then T_propietario.Text = tipo_peronsa_apellido & "," & " " & tipo_peronsa_nombre
        End If
        '/// Fin del prodecimiento para volcar los datos en el fomulario Inicial 

    End Sub

    Sub ObraExistente()
        'Dim tabla As New DataTable
        Dim sqlId As String = "SELECT * FROM inmueble WHERE id_trabajo =" & identificadorTrabajo
        Dim cmdId As New OleDbCommand(sqlId, conexionMdb1)
        Dim da As New OleDbDataAdapter(cmdId)
        da.Fill(obra_exis)
    End Sub
    Sub cargo_los_campos()
        If Not obra_exis.Rows.Count > 0 Then
            MsgBox("no hay datos en la tabla obra exist.")
            Exit Sub
        End If
        If Not IsDBNull(obra_exis.Rows(0).Item("pdo_num")) Then
            T_num_p.Text = obra_exis.Rows(0).Item("pdo_num")
        Else
            T_num_p.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("pdo")) Then
            Combo_partido.Text = obra_exis.Rows(0).Item("pdo")
        Else
            Combo_partido.Text = "-"
        End If
        If Not IsDBNull(obra_exis.Rows(0).Item("localidad")) Then
            T_lugar.Text = obra_exis.Rows(0).Item("localidad")
        Else
            T_lugar.Text = "-"
        End If
        If Not IsDBNull(obra_exis.Rows(0).Item("circ")) Then
            T_circ.Text = obra_exis.Rows(0).Item("circ")
        Else
            T_circ.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("secc")) Then
            T_secc.Text = obra_exis.Rows(0).Item("secc")
        Else
            T_secc.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("chacra")) Then
            T_cha.Text = obra_exis.Rows(0).Item("chacra")
        Else
            T_cha.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("chacra_letra")) Then
            T_chacra_letra.Text = obra_exis.Rows(0).Item("chacra_letra")
        Else
            T_chacra_letra.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("quinta")) Then
            T_quinta.Text = obra_exis.Rows(0).Item("quinta")
        Else
            T_quinta.Text = "-"
        End If


        If Not IsDBNull(obra_exis.Rows(0).Item("quinta_letra")) Then
            T_quinta_letra.Text = obra_exis.Rows(0).Item("quinta_letra")
        Else
            T_quinta_letra.Text = "-"
        End If


        If Not IsDBNull(obra_exis.Rows(0).Item("fraccion")) Then
            T_frac.Text = obra_exis.Rows(0).Item("fraccion")
        Else
            T_frac.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("fraccion_letra")) Then
            T_frac_letra.Text = obra_exis.Rows(0).Item("fraccion_letra")
        Else
            T_frac_letra.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("mza")) Then
            T_manzana.Text = obra_exis.Rows(0).Item("mza")
        Else
            T_manzana.Text = "-"
        End If
        If Not IsDBNull(obra_exis.Rows(0).Item("mza_letra")) Then
            T_manzana_letra.Text = obra_exis.Rows(0).Item("mza_letra")
        Else
            T_manzana_letra.Text = "-"
        End If
        If Not IsDBNull(obra_exis.Rows(0).Item("parcela")) Then
            t_parcela.Text = obra_exis.Rows(0).Item("parcela")
        Else
            t_parcela.Text = "-"
        End If
        If Not IsDBNull(obra_exis.Rows(0).Item("parcela_letra")) Then
            t_parcela_letra.Text = obra_exis.Rows(0).Item("parcela_letra")
        Else
            t_parcela_letra.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("subparcela")) Then
            t_sub_parcela.Text = obra_exis.Rows(0).Item("subparcela")
        Else
            t_sub_parcela.Text = "-"
        End If
        If Not IsDBNull(obra_exis.Rows(0).Item("pda")) Then
            t_partida.Text = obra_exis.Rows(0).Item("pda")
        Else
            t_partida.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("calle_inmueble")) Then
            T_calle_i.Text = obra_exis.Rows(0).Item("calle_inmueble")
        Else
            T_propietario.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("num_inmueble")) Then
            T_num_i.Text = obra_exis.Rows(0).Item("num_inmueble")
        Else
            T_num_i.Text = "-"
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("piso_inmueble")) Then
            T_piso_i.Text = obra_exis.Rows(0).Item("piso_inmueble")
        Else
            T_piso_i.Text = "-"
        End If
        If Not IsDBNull(obra_exis.Rows(0).Item("dpto_inmueble")) Then
            T_dpto_i.Text = obra_exis.Rows(0).Item("dpto_inmueble")
        Else
            T_dpto_i.Text = "-"
        End If

        conectar1() 'Pido conexion

        '======Traigo el Id de las personas p/ despues  con eso traerlos de la tabla Personas===========
        If Not IsDBNull(obra_exis.Rows(0).Item("id_persona_comitente")) Then

            id_comi.Text = obra_exis.Rows(0).Item("id_persona_comitente")
            If id_comi.Text <> "" Then
                '==========================================================================================
                Dim comitente As String = "SELECT * FROM persona WHERE id_persona =" & obra_exis.Rows(0).Item("id_persona_comitente")
                Dim cmdId As New OleDbCommand(comitente, conexionMdb1)
                Dim da1 As New OleDbDataAdapter(cmdId)
                Dim tab1 As New Data.DataTable
                da1.Fill(tab1)
                'mh: Tcomitente.Text = tab.Rows(0).Item("nombre") & "," & "" & tab.Rows(0).Item("apellido")
                If tab1.Rows.Count = 0 Then

                    id_comi.Text = "0000"
                Else
                    Tcomitente.Text = tab1.Rows(0).Item("apellido") & "" & " " & tab1.Rows(0).Item("nombre")

                End If
            End If
        End If


        If Not IsDBNull(obra_exis.Rows(0).Item("id_persona_titular")) Then

            id_titu.Text = obra_exis.Rows(0).Item("id_persona_titular")
            '====================================================================================
            If id_titu.Text <> "" Then
                Dim titular As String = "SELECT * FROM persona WHERE id_persona =" & obra_exis.Rows(0).Item("id_persona_titular")
                Dim cmdId As New OleDbCommand(titular, conexionMdb1)
                Dim da2 As New OleDbDataAdapter(cmdId)
                Dim tab2 As New Data.DataTable

                da2.Fill(tab2)

                If tab2.Rows.Count = 0 Then
                    id_titu.Text = "0"
                    If tab2.Rows.Count = 0 Then
                        Exit Sub
                    End If
                    row = tab2.Rows(tab2.Rows.Count - 1)

                    Dim tt As Integer = 0
                    For Each item As Object In row.ItemArray

                        If IsDBNull(row(tt)) Or row(tt).ToString.Length = 0 Then
                            row(tt) = "---"
                        End If
                        tt = tt + 1

                    Next
                Else
                    Ttitular.Text = tab2.Rows(0).Item("apellido") & "" & " " & tab2.Rows(0).Item("nombre")
                    row = tab2.Rows(tab2.Rows.Count - 1)

                    Dim tt As Integer = 0
                    For Each item As Object In row.ItemArray

                        If IsDBNull(row(tt)) Or row(tt).ToString.Length = 0 Then
                            row(tt) = "---"
                        End If
                        tt = tt + 1

                    Next
                End If



            End If


        End If


        If Not IsDBNull(obra_exis.Rows(0).Item("id_persona_contribuyente")) Then
            id_contri.Text = obra_exis.Rows(0).Item("id_persona_contribuyente")
            '====================================================================================
            If id_contri.Text <> "" Then


                Dim contribuyente As String = "SELECT * FROM persona WHERE id_persona =" & obra_exis.Rows(0).Item("id_persona_contribuyente")
                Dim cmdId As New OleDbCommand(contribuyente, conexionMdb1)
                Dim da3 As New OleDbDataAdapter(cmdId)
                Dim tab3 As New Data.DataTable
                da3.Fill(tab3)
                'mh: Tcontribuyene.Text = tab.Rows(0).Item("nombre") & "," & "" & tab.Rows(0).Item("apellido")

                If tab3.Rows.Count = 0 Then

                    id_contri.Text = "0000"
                Else

                    Tcontribuyene.Text = tab3.Rows(0).Item("apellido") & "" & " " & tab3.Rows(0).Item("nombre")
                End If

            End If
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("id_persona_cliente")) Then
            id_cli.Text = obra_exis.Rows(0).Item("id_persona_cliente")

            If id_cli.Text <> "" Then
                '====================================================================================
                Dim cliente As String = "SELECT * FROM persona WHERE id_persona =" & obra_exis.Rows(0).Item("id_persona_cliente")
                Dim cmdId As New OleDbCommand(cliente, conexionMdb1)
                Dim da4 As New OleDbDataAdapter(cmdId)
                Dim tab4 As New Data.DataTable
                da4.Fill(tab4)

                If tab4.Rows.Count = 0 Then
                    id_cli.Text = "0000"
                Else

                    Tcliente.Text = tab4.Rows(0).Item("apellido") & "" & " " & tab4.Rows(0).Item("nombre")

                End If
            End If
        End If

        If Not IsDBNull(obra_exis.Rows(0).Item("id_persona_propietario")) Then
            id_propietario.Text = obra_exis.Rows(0).Item("id_persona_propietario")
            If id_propietario.Text <> "" Then
                '====================================================================================
                Dim propietario As String = "SELECT * FROM persona WHERE id_persona =" & obra_exis.Rows(0).Item("id_persona_propietario")
                Dim cmdId As New OleDbCommand(propietario, conexionMdb1)
                Dim da5 As New OleDbDataAdapter(cmdId)
                Dim tab5 As New Data.DataTable
                da5.Fill(tab5)

                If tab5.Rows.Count = 0 Then
                    id_propietario.Text = "0000"
                Else

                    T_propietario.Text = tab5.Rows(0).Item("apellido") & "" & " " & tab5.Rows(0).Item("nombre")

                End If
            End If
        End If





        '================cierro las consultas a la tabla personas=====
        conexionMdb1.Close()
        '=============================================================

    End Sub
    Sub PongoNoLectura()
        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox2.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = False
                        CType(controlText, TextBox).BackColor = Color.LightGray
                        CType(controlText, TextBox).ForeColor = Color.MediumVioletRed
                    End If
                Next
            End If
        Next

        Combo_partido.DropDownStyle = ComboBoxStyle.DropDown
        Combo_partido.BackColor = Color.Gray
        Combo_partido.ForeColor = Color.White


        '============================================================================
        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox3.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = False
                        CType(controlText, TextBox).BackColor = Color.LightGray
                        CType(controlText, TextBox).ForeColor = Color.MediumVioletRed
                    End If
                Next
            End If
        Next
        '================================================================================
        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox5.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = False
                        CType(controlText, TextBox).BackColor = Color.LightGray
                        CType(controlText, TextBox).ForeColor = Color.MediumVioletRed
                    End If
                Next
            End If
        Next
        '================================================================================

        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox6.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = False
                        CType(controlText, TextBox).BackColor = Color.LightGray
                        CType(controlText, TextBox).ForeColor = Color.MediumVioletRed
                    End If
                Next
            End If
        Next
        '================================================================================

        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox7.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = True
                        CType(controlText, TextBox).BackColor = Color.LightGray
                        CType(controlText, TextBox).ForeColor = Color.MediumVioletRed
                    End If
                Next
            End If
        Next
        '================================================================================

        'For Each control As Windows.Forms.Control In Me.Controls
        '    If TypeOf control Is GroupBox Then
        '        For Each controlText As Windows.Forms.Control In Me.GroupBox9.Controls
        '            If TypeOf controlText Is TextBox Then
        '                CType(controlText, TextBox).ReadOnly = False

        '                CType(controlText, TextBox).BackColor = Color.LightGray
        '                CType(controlText, TextBox).ForeColor = Color.lime
        '            End If
        '        Next
        '    End If
        'Next
        '================================================================================




    End Sub


    Sub pongoSoloLectura()

        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox2.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = True
                        CType(controlText, TextBox).BackColor = Color.White
                        CType(controlText, TextBox).ForeColor = Color.Maroon

                    End If
                Next
            End If
        Next

        Combo_partido.DropDownStyle = ComboBoxStyle.Simple
        Combo_partido.BackColor = Color.White
        Combo_partido.ForeColor = Color.Maroon

        '============================================================================
        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox3.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = True
                        CType(controlText, TextBox).BackColor = Color.White
                        CType(controlText, TextBox).ForeColor = Color.Maroon

                    End If
                Next
            End If
        Next

        '================================================================================

        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox5.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = True
                        CType(controlText, TextBox).BackColor = Color.White
                        CType(controlText, TextBox).ForeColor = Color.Maroon

                    End If
                Next
            End If
        Next

        '================================================================================

        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox6.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = True
                        CType(controlText, TextBox).BackColor = Color.White
                        CType(controlText, TextBox).ForeColor = Color.Maroon
                    End If
                Next
            End If
        Next
        '================================================================================

        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox7.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = True
                        CType(controlText, TextBox).BackColor = Color.White
                        CType(controlText, TextBox).ForeColor = Color.Maroon
                    End If
                Next
            End If
        Next
        '================================================================================

        For Each control As Windows.Forms.Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each controlText As Windows.Forms.Control In Me.GroupBox6.Controls
                    If TypeOf controlText Is TextBox Then
                        CType(controlText, TextBox).ReadOnly = True
                        CType(controlText, TextBox).BackColor = Color.White
                        CType(controlText, TextBox).ForeColor = Color.Maroon
                    End If
                Next
            End If
        Next
        '================================================================================

    End Sub
    Private Sub Inicial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then

            frmPersonas.ShowDialog()
            cargo_datos_persona() '//bllamo al procedure done los vuelca en el fommulario que lo llamo(Inicial)
        End If

        If e.KeyCode = Keys.F1 Then
            frmLocalidades.ShowDialog()
            cargo_datos_persona() '// llamo al procedure done los vuelca en el fommulario que lo llamo(Inicial)
        End If

        'If e.KeyCode = Keys.Enter Then

        '    If Me.ActiveControl.GetType Is GetType(TextBox) Or Me.ActiveControl.GetType Is GetType(ComboBox) Then
        '        e.SuppressKeyPress = True
        '        If e.Shift Then
        '            Me.ProcessTabKey(False)
        '        Else
        '            Me.ProcessTabKey(True)

        '        End If

        '    End If
        'End If

    End Sub
    Private Sub Inicial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conectar1()


        Cambio_Color(Me)
        Dim tablas As String = "select * from partidos"
        Dim partidos = New OleDb.OleDbDataAdapter(tablas, conexionMdb1) 'agrego dos tablas al mismo adapter
        'Dim constructor = New OleDb.OleDbCommandBuilder(partidos) 'Se interpreta la consulta
        partidos.Fill(partido)
        For Each renglon As DataRow In partido.Rows
            Combo_partido.Items.Add(renglon("descrip"))
        Next

        If obra_nueva = False Then
            btnParcelaVectorial.Enabled = True
            btnAceptar.Enabled = False

            pongoSoloLectura()

            ObraExistente()
            cargo_los_campos()

        Else
            btnParcelaVectorial.Enabled = False
            btnModificar.Enabled = False
        End If

        conexionMdb1.Close()
        T_num_p.TabIndex = 0



    End Sub

    Private Sub T_num_p_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_num_p.Enter
    End Sub

    Private Sub T_num_p_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_num_p.GotFocus

    End Sub

    Private Sub T_num_p_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_num_p.KeyPress


        If e.KeyChar = ChrW(Keys.Enter) And T_num_p.Text = "" Then

            T_num_p.Focus()
            Exit Sub

        End If


        Dim numero_partido As String
        Dim numero_p As DataTable = New DataTable
        Dim liKeyAscii As Integer = CInt(Asc(e.KeyChar))
        mKeyAscii = lF_iSolonumeros(liKeyAscii)
        If mKeyAscii = 0 Then
            e.Handled = True
        End If


        If mKeyAscii = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")

            conectar1()
            Cambio_Color(Me)
            numero_partido = T_num_p.Text

           

            If numero_partido.Length = 1 Then
                T_num_p.Text = "00" & numero_partido
                numero_partido = "00" & numero_partido
            Else
                If numero_partido.Length = 2 Then
                    T_num_p.Text = "0" & numero_partido
                    numero_partido = "0" & numero_partido

                End If

            End If
            Dim tablas As String = "select * from partidos where CODIGO='" & numero_partido & "' "
            Dim partidos = New OleDb.OleDbDataAdapter(tablas, conexionMdb1) 'agrego dos tablas al mismo adapter
            ' Dim constructor = New OleDb.OleDbCommandBuilder(partidos) 'Se interpreta la consulta
            partidos.Fill(numero_p)
            Combo_partido.Text = numero_p.Rows(0).Item("DESCRIP")
            numero_p = Nothing
            cerrarConexion1()

        End If




    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub B_localidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_localidad.Click
        frmLocalidades.ShowDialog()
        If flag = 0 Then
            flag = 1
            Exit Sub
        Else
            T_lugar.Text = localidad
            T_num_p.Text = cod_partido
            Combo_partido.Text = partido_1
        End If
    End Sub

    Private Sub btnParcelaVectorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParcelaVectorial.Click
        parce = t_parcela.Text & "  " & t_parcela_letra.Text
        btnModificar.Enabled = True
        frmPpal.Show()
        cargonomenclatura()
        modAbrirTrabajo.abrirTrabajo()


    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.Dispose()
        frmEntrada.Visible = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click


        If modifico = False Then
            cargonomenclatura()
            conectar1()
            Dim msg As String
            Dim titulo As String
            Dim estilo As MsgBoxStyle
            Dim res As MsgBoxResult
            msg = "Desea Guardar los Datos?"
            estilo = MsgBoxStyle.DefaultButton2 Or _
             MsgBoxStyle.Question Or MsgBoxStyle.YesNo
            titulo = "Atención"
            res = MsgBox(msg, estilo, titulo)
            If res = MsgBoxResult.Yes Then
                If id_cli.Text = String.Empty Then
                    id_cli.Text = "0000"
                End If

                If id_comi.Text = String.Empty Then
                    id_comi.Text = "0000"
                End If
                If id_contri.Text = String.Empty Then
                    id_contri.Text = "0000"
                End If

                If id_titu.Text = String.Empty Then
                    id_titu.Text = "0000"
                End If


                Dim sentencia As String = "INSERT into inmueble (pdo_num,pdo,pda,localidad,calle_inmueble,num_inmueble,piso_inmueble,dpto_inmueble," &
               "circ,secc,chacra,chacra_letra,quinta,quinta_letra,fraccion,fraccion_letra,mza,mza_letra,parcela,parcela_letra,subparcela," &
               "id_persona_propietario,id_persona_titular,id_persona_comitente,id_persona_contribuyente,id_persona_cliente, id_trabajo)" &
                " values" &
               " ('" & T_num_p.Text & "','" & Combo_partido.Text & "','" & t_partida.Text & "','" & T_lugar.Text & "','" & T_calle_i.Text & "', " &
               " '" & T_num_i.Text & "','" & T_piso_i.Text & "','" & T_dpto_i.Text & "','" & T_circ.Text & "','" & T_secc.Text & "', " &
               " '" & T_cha.Text & "','" & T_chacra_letra.Text & "','" & T_quinta.Text & "','" & T_quinta_letra.Text & "'," &
               " '" & T_frac.Text & "','" & T_frac_letra.Text & "','" & T_manzana.Text & "', " &
               " '" & T_manzana_letra.Text & "','" & t_parcela.Text & "','" & t_parcela_letra.Text & "','" & t_sub_parcela.Text & "'," &
               " '" & id_propietario.Text & "'," & id_titu.Text & ", " & id_comi.Text & " ," & id_contri.Text & "," & id_cli.Text & "," & identificadorTrabajo & ")"



                Dim Cmd As OleDbCommand = New OleDbCommand(sentencia, conexionMdb1)
                Cmd.ExecuteNonQuery()
                cerrarConexion1()
                btnAceptar.Enabled = False
                btnModificar.Enabled = True

                btnParcelaVectorial.Enabled = True
            Else

                Exit Sub
            End If
        Else

            Dim sql As String
            Dim Cmd As OleDbCommand = New OleDbCommand()
            cargonomenclatura()
            conectar1()

            Dim msg As String
            Dim titulo As String
            Dim estilo As MsgBoxStyle
            Dim res As MsgBoxResult
            msg = "Desea Modificar los Datos?"
            estilo = MsgBoxStyle.DefaultButton2 Or _
             MsgBoxStyle.Question Or MsgBoxStyle.YesNo
            titulo = "Atención"
            res = MsgBox(msg, estilo, titulo)
            If res = MsgBoxResult.Yes Then
                modifico = False

                sql = "UPDATE inmueble SET pdo_num='" & T_num_p.Text & "'," & _
                 "pdo ='" & Combo_partido.Text & "'," & _
                 "pda ='" & t_partida.Text & "'," & _
                 "localidad ='" & T_lugar.Text & "'," & _
                 "calle_inmueble ='" & T_calle_i.Text & "'," & _
                 "num_inmueble ='" & T_num_i.Text & "'," & _
                 "piso_inmueble ='" & T_piso_i.Text & "'," & _
                 "dpto_inmueble ='" & T_dpto_i.Text & "'," & _
                 "circ ='" & T_circ.Text & "'," & _
                 "secc ='" & T_secc.Text & "'," & _
                 "chacra ='" & T_cha.Text & "'," & _
                 "chacra_letra ='" & T_chacra_letra.Text & "'," & _
                 "quinta ='" & T_quinta.Text & "'," & _
                 "quinta_letra ='" & T_quinta_letra.Text & "'," & _
                 "fraccion ='" & T_frac.Text & "'," & _
                 "fraccion_letra ='" & T_frac_letra.Text & "'," & _
                 "mza ='" & T_manzana.Text & "'," & _
                 "mza_letra ='" & T_manzana_letra.Text & "'," & _
                 "parcela ='" & t_parcela.Text & "'," & _
                 "parcela_letra ='" & t_parcela_letra.Text & "'," & _
                 "subparcela ='" & t_sub_parcela.Text & "'," & _
                 "id_persona_propietario ='" & T_propietario.Text & "'," & _
                 "id_persona_titular ='" & id_titu.Text & "'," & _
                 "id_persona_comitente ='" & id_comi.Text & "'," & _
                 "id_persona_contribuyente ='" & id_contri.Text & "'," & _
                 "id_persona_cliente ='" & id_cli.Text & "'" & _
                 "WHERE id_trabajo =" & identificadorTrabajo



                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()
                cerrarConexion1()
                pongoSoloLectura()
                btnModificar.Enabled = True
            Else

                Exit Sub
            End If

            btnAceptar.Enabled = False
            ' btnModificar.Enabled = True


        End If
        

    End Sub

    Private Sub Combo_partido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_partido.SelectedIndexChanged
        If flag = 0 Then Exit Sub
        Dim nombre_partido As String
        Dim numero_p As DataTable = New DataTable
        conectar1()
        Cambio_Color(Me)
        nombre_partido = Combo_partido.SelectedItem

        Dim tablas As String = "select * from partidos where DESCRIP LIKE '" & nombre_partido & "' "
        Dim partidos = New OleDb.OleDbDataAdapter(tablas, conexionMdb1) 'agrego dos tablas al mismo adapter
        'Dim constructor = New OleDb.OleDbCommandBuilder(partidos) 'Se interpreta la consulta
        partidos.Fill(numero_p)

        If (numero_p.Rows.Count = 0) Then
            Exit Sub
        End If
        T_num_p.Text = numero_p.Rows(0).Item("CODIGO")
        numero_p = Nothing
        cerrarConexion1()

    End Sub

    Private Sub T_num_p_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_num_p.LostFocus
        Dim numero_partido As String
        Dim numero_p As DataTable = New DataTable
        conectar1()
        Cambio_Color(Me)
        numero_partido = T_num_p.Text
        If numero_partido.Length = 1 Then
            T_num_p.Text = "00" & numero_partido
            numero_partido = "00" & numero_partido
        Else
            If numero_partido.Length = 2 Then
                T_num_p.Text = "0" & numero_partido
                numero_partido = "0" & numero_partido

            End If

        End If
        Dim tablas As String = "select * from partidos where CODIGO='" & numero_partido & "' "
        Dim partidos = New OleDb.OleDbDataAdapter(tablas, conexionMdb1) 'agrego dos tablas al mismo adapter
        ' Dim constructor = New OleDb.OleDbCommandBuilder(partidos) 'Se interpreta la consulta
        partidos.Fill(numero_p)
        Combo_partido.Text = numero_p.Rows(0).Item("DESCRIP")
        numero_p = Nothing
        cerrarConexion1()
    End Sub
    Private Sub T_num_p_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_num_p.TextChanged




    End Sub


    Private Sub AgregarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarToolStripMenuItem.Click
        frmPersonas.ShowDialog() '// Abro el formulario para cargar los datos de tipo de persona
        cargo_datos_persona() '// llamo al procedure done los vuelca en el fommulario que lo llamo(Inicial)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        modifico = True
        btnModificar.Enabled = False
        btnAceptar.Enabled = True
        PongoNoLectura()

    End Sub


    Private Sub BuscarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem.Click
        frmBuscaPersonas.ShowDialog()
    End Sub

    Private Sub T_circ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_circ.KeyPress

        Dim liKeyAscii As Integer = CInt(Asc(e.KeyChar))
        mKeyAscii = lF_iSoloLetras(liKeyAscii)
        If mKeyAscii = 0 Then
            e.Handled = True
        End If


        If mKeyAscii = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


        'Anda(bien)

        'If e.KeyChar = ChrW(Keys.Enter) Then

        '    e.Handled = True

        '    SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub T_circ_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_circ.LostFocus


        If IsNumeric(T_circ.Text) Then
            If (IsNumeric((CInt(T_circ.Text))) And (CInt(T_circ.Text) < 21)) Then
                T_circ.Text = VerValor(T_circ.Text)
            Else
                T_circ.Focus()
            End If
        End If
    End Sub

    Private Sub T_circ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_circ.TextChanged

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim _titular As DataTable = New DataTable

        conectar1()
        _titular.Clear()

        Dim id_ti As String = id_titu.Text
        If id_ti = "0" Or id_ti = "" Then
            Rep.Show()

        Else

            Dim adaptador = New OleDb.OleDbDataAdapter("SELECT * FROM persona where id_persona LIKE '" & id_ti & "' ", conexionMdb1)
            Dim constructor = New OleDb.OleDbCommandBuilder(adaptador) 'Se interpreta la consulta
            adaptador.Fill(_titular)
            ' Dim row As DataRow = _titular.Rows(_titular.Rows.Count - 1)
            row = _titular.Rows(_titular.Rows.Count - 1)
            '=================================
            Dim tt As Integer = 0
            For Each item As Object In row.ItemArray

                If IsDBNull(row(tt)) Or row(tt).ToString.Length = 0 Then
                    row(tt) = "---"
                End If
                tt = tt + 1

            Next
            dueño = Var_Cedula.Titulares(row)
            conexionMdb1.Close()
        End If

        Rep.Show()

    End Sub

    Private Sub T_frac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_frac.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_frac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_frac.LostFocus
        If IsNumeric(T_frac.Text) Then
            If (IsNumeric((CInt(T_frac.Text))) And (CInt(T_frac.Text) < 21)) Then
                T_frac.Text = VerValor(T_frac.Text)
            Else
                T_frac.Text = ""

            End If
        End If
    End Sub

    Private Sub T_frac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_frac.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmBuscaPersonas.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmBuscaPersonas.ShowDialog()
        Dim _titular As DataTable = New DataTable

        conectar1()
        _titular.Clear()

        Dim id_ti As String = id_titu.Text
        If (id_ti = "0" Or id_ti = "") Then Exit Sub
        Dim adaptador = New OleDb.OleDbDataAdapter("SELECT * FROM persona where id_persona LIKE '" & id_ti & "' ", conexionMdb1)
        Dim constructor = New OleDb.OleDbCommandBuilder(adaptador) 'Se interpreta la consulta
        adaptador.Fill(_titular)
        ' Dim row As DataRow = _titular.Rows(_titular.Rows.Count - 1)
        row = _titular.Rows(_titular.Rows.Count - 1)
        '=================================
        Dim tt As Integer = 0
        For Each item As Object In row.ItemArray

            If IsDBNull(row(tt)) Or row(tt).ToString.Length = 0 Then
                row(tt) = "---"
            End If
            tt = tt + 1

        Next
        dueño = Var_Cedula.Titulares(row)
        conexionMdb1.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmBuscaPersonas.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmBuscaPersonas.ShowDialog()
    End Sub

    Private Sub PersonasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonasToolStripMenuItem.Click

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        frmPpal.croquis = True
        frmPpal.Show()
        modAbrirTrabajo.abrirTrabajo()
    End Sub

    Private Sub Propietario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Propietario.Click
        frmBuscaPersonas.ShowDialog()
    End Sub

    Private Sub T_secc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_secc.KeyPress
        If (Not Char.IsLetter(e.KeyChar) And e.KeyChar <> Microsoft.VisualBasic.ChrW(8)) Then
            e.Handled = True
        End If


        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_secc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_secc.TextChanged

    End Sub

    Private Sub T_cha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_cha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_cha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_cha.TextChanged

    End Sub

    Private Sub T_chacra_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_chacra_letra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_chacra_letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_chacra_letra.TextChanged

    End Sub

    Private Sub T_quinta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_quinta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_quinta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_quinta.TextChanged

    End Sub

    Private Sub T_quinta_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_quinta_letra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_quinta_letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_quinta_letra.TextChanged

    End Sub

    Private Sub T_manzana_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_manzana.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_manzana_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_manzana.TextChanged

    End Sub

    Private Sub T_manzana_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_manzana_letra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_manzana_letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_manzana_letra.TextChanged

    End Sub

    Private Sub t_parcela_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t_parcela.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub t_parcela_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t_parcela.TextChanged

    End Sub

    Private Sub t_parcela_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t_parcela_letra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub t_sub_parcela_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t_sub_parcela.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub t_sub_parcela_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t_sub_parcela.TextChanged

    End Sub

    Private Sub t_partida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t_partida.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub t_partida_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t_partida.TextChanged

    End Sub

    Private Sub T_frac_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_frac_letra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_frac_letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_frac_letra.TextChanged

    End Sub

    Private Sub T_calle_i_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_calle_i.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_calle_i_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_calle_i.TextChanged

    End Sub

    Private Sub T_num_i_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_num_i.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_num_i_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_num_i.TextChanged

    End Sub

    Private Sub T_piso_i_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_piso_i.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_piso_i_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_piso_i.TextChanged

    End Sub

    Private Sub T_dpto_i_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_dpto_i.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub T_dpto_i_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_dpto_i.TextChanged

    End Sub
End Class
