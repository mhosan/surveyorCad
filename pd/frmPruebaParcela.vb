
Public Class frmPruebaParcela
    Public Circ, Secc, Qta, Chac, Frac, Manz, Nomenc, Quintaletra, Chacraletra, Fracletra, Manzletra As String

    Private Sub frmPruebaParcela_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If String.IsNullOrEmpty(parce) Then
        Else
            t_parcela.Text = parce
        End If

        'Configuracion_Pantalla.ajustarResolucion(Me)

        '=====Setea las variables=====
        modFuncionesMacizo.SeteoParcela()
        '=============================

        '===========cargo nomenclatura del fomulario Inicial==============================
        Circ = nomenclatura.Circunscripcion : Secc = nomenclatura.Seccion
        Qta = nomenclatura.Quinta
        Quintaletra = nomenclatura.QuintaLetra
        Chac = nomenclatura.Chacra
        Chacraletra = nomenclatura.ChacraLetra
        Frac = nomenclatura.Fraccion
        Fracletra = nomenclatura.FraccionLetra
        Manz = nomenclatura.Manzana
        Manzletra = nomenclatura.ManzanaLetra
        Nomenc = "Circ: " & UCase(Trim(Circ))
        If Secc <> "" Then Nomenc = Nomenc & " -- Secc: " & UCase(Secc)
        If Qta <> "" Then Nomenc = Nomenc & " -- Qta: " & Trim(Qta)
        If Quintaletra <> "" Then Nomenc = Nomenc & Trim(Quintaletra)
        If Chac <> "" Then Nomenc = Nomenc & " -- Chac: " & Trim(Chac)
        If Chacraletra <> "" Then Nomenc = Nomenc & Trim(Chacraletra)
        If Frac <> "" Then Nomenc = Nomenc & " -- Frac: " & Trim(Frac)
        If Fracletra <> "" Then Nomenc = Nomenc & Trim(Fracletra)
        If Manz <> "" Then Nomenc = Nomenc & " -- Manz: " & Trim(Manz)
        If Manzletra <> "" Then Nomenc = Nomenc & Trim(Manzletra)
        t_nomenclatura.Text = Nomenc

        '==================================================================
        ' BaseControlParcela.ActiveDocument.ActionLayout.BkColorEx = Color.Green
        'DIBUJAME_LA_PARCELA()
        '=====================================================================

        'Si no es una obra nueva tengo que levantar calles......y la infraestructura



        'Dim nombre_partido As String
        'Dim datos_calles As DataTable = New DataTable
        'conectar1()

        'nombre_partido = Combo_partido.SelectedItem
        'Dim tablas As String = "select * from servicios where id_trabajo LIKE '" & identificadortrabajo & "' "
        'Dim servi = New OleDb.OleDbDataAdapter(tablas, conexionMdb1) 'agrego dos tablas al mismo adapter
        ''Dim constructor = New OleDb.OleDbCommandBuilder(partidos) 'Se interpreta la consulta
        'servi.Fill(datos_calles)
        'T_num_p.Text = numero_p.Rows(0).Item("CODIGO")
        'numero_p = Nothing

        'cerrarConexion1()


        '=====================================================
        'Para encontrar el nombre de la calle si tiene frente
        Dim arraycalle() As String
        Dim arrayPalabras() As String, i As Integer
        Dim calle As String
        For ii As Integer = 0 To rumbos.Items.Count - 1 'recorro cada elemento del listbox
            calle = ""
            ' "rumbos norte metros 25 de frente sobre Calle Pte Peron"

            Dim cadenass As String = rumbos.Items(ii)
            arrayPalabras = Strings.Split(cadenass, " ")


            For tt As Integer = 0 To arrayPalabras.Count - 1

                If arrayPalabras(tt) = "frente" Then


                    If arrayPalabras(tt + 3) = "calle" Then

                        For jj As Integer = (tt + 4) To arrayPalabras.Count - 1
                            calle = calle + " " + arrayPalabras(jj)
                        Next

                        DgCalles.Rows.Add(calle)


                    End If
                End If
            Next



        Next

        '===================================================================
        'MsgBox(calle)
    End Sub




    Private Sub t_parcela_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t_parcela.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub t_parcela_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles t_parcela.LostFocus
        NumeroParcela(t_parcela.Text)
    End Sub

    Private Sub t_parcela_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t_parcela.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If obra_nueva = True Then
            If (String.IsNullOrEmpty(t_parcela.Text) Or String.IsNullOrEmpty(t_superficie.Text)) Then
                Dim msg As String
                Dim titulo As String
                Dim estilo As MsgBoxStyle
                Dim res As MsgBoxResult
                msg = "Debe completar el campo ""Parcela"" o ""Superficie"""
                estilo = MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly
                titulo = "Atención"
                res = MsgBox(msg, estilo, titulo)
                Exit Sub
            Else
                _parcela.txParcela = t_parcela.Text 'Marcelo identifica con esa variable la denominacion
                modDatosMacizo.GuardoDatosParcela()
                modDatosDB.agregarDatosMacizoBD(t_parcela.Text, copia_lapoli, "parcela")
                'mh: 25/3/13
                bander = False
                Me.Close()
            End If
        Else
            modDatosMacizo.GuardoDatosParcela_actualizar()
            modDatosMacizo.GuardoDatosParcela()
            modDatosDB.agregarDatosMacizoBD(t_parcela.Text, copia_lapoli, "parcela")
            'mh 25/3/13
            bander = False
            Me.Close()
        End If
    End Sub

    Private Sub t_superficie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t_superficie.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub t_superficie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t_superficie.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        bander = True
        Me.Close()

    End Sub

    Private Sub rumbos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rumbos.SelectedIndexChanged

    End Sub
End Class