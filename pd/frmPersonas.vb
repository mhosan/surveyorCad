Imports System.Data
Imports System.Data.OleDb

Public Class frmPersonas

    Function Cuit(ByVal pDoc As Long, ByVal pSexo As String) As String
        Dim mDoc As String
        Dim mNum As Integer
        Dim mZ As Integer
        Dim mPRefijo As String
        Select Case pSexo
            Case "Masculino"
                mPRefijo = "20"
                mNum = 2 * 5 + 0 * 4
            Case "Femenino"
                mPRefijo = "27"
                mNum = 2 * 5 + 7 * 4
            Case "Empresa"
                mPRefijo = "30"
                mNum = 3 * 5 + 0 * 4
            Case "X"
                mPrefijo = "23"
                mNum = 2 * 5 + 3 * 4
        End Select

        mDoc = Strings.Right("00000000" & LTrim(Format(pDoc, "########")), 8)

        mNum = mNum + Val(Mid(mDoc, 1, 1)) * 3
        mNum = mNum + val(mid(mDoc, 2, 1)) * 2
        mNum = mNum + val(mid(mDoc, 3, 1)) * 7
        mNum = mNum + val(mid(mDoc, 4, 1)) * 6
        mNum = mNum + val(mid(mDoc, 5, 1)) * 5
        mNum = mNum + val(mid(mDoc, 6, 1)) * 4
        mNum = mNum + val(mid(mDoc, 7, 1)) * 3
        mNum = mNum + val(mid(mDoc, 8, 1)) * 2
        Dim mResto = mNum Mod 11
        mZ = 11 - mResto
        If Mz = 11 Then
            Cuit = mPrefijo & mdoc & "0"
        ElseIf mResto = 1 Then
            Cuit = Cuit(pDoc, "X")
        Else
            Cuit = mPrefijo & mdoc & trim(format(mZ, "#"))
        End If
    End Function

    Private Sub partidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox("es a :" & Inicial.a)
        Tsurname.Clear()
        Tname.Clear()
        Tnumdoc.Clear()
        Tcuit.Clear()
        Tloca.Clear()
        tpartido.Clear()
        Tcalle.Clear()
        Tnumero_calle.Clear()
        Tdpto.Clear()
        Tpiso.Clear()
        Ttel1.Clear()
        Ttel2.Clear()
        Tcodigop.Clear()



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmInicial.Visible = True
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        conectar1()

        Dim sentencia As String = "INSERT into persona (nombre,apellido,tipo_doc,doc,cuit_L,localidad,calle,num_calle,piso,dpto,tel1,tel2 ) values ('" & Tname.Text & "','" & Tsurname.Text & "','" & ComboBox1.Text & "','" & Tnumdoc.Text & "','" & Tcuit.Text & "','" & Tloca.Text & "','" & Tcalle.Text & "','" & Tnumero_calle.Text & "','" & Tpiso.Text & "','" & Tdpto.Text & "','" & Ttel1.Text & "','" & Ttel2.Text & "')"
        Dim Cmd As OleDbCommand = New OleDbCommand(sentencia, conexionMdb1)

        Cmd.ExecuteNonQuery()
        bandera = 1
        tipo_persona_1 = String.Empty
        tipo_persona_2 = String.Empty
        tipo_persona_3 = String.Empty
        tipo_persona_4 = String.Empty
        tipo_persona_5 = String.Empty

        If CheckBox1.Checked Then tipo_persona_1 = "Cliente"
        If CheckBox2.Checked Then tipo_persona_2 = "Contribuyente"
        If CheckBox3.Checked Then tipo_persona_3 = "Titular"
        If CheckBox4.Checked Then tipo_persona_4 = "Comitente"
        If CheckBox5.Checked Then tipo_persona_4 = "Propietario"
        tipo_peronsa_apellido = Tsurname.Text
        tipo_peronsa_nombre = Tname.Text

        '=========Tomo el útimo id insetado en la tabla personas===============
        Dim tabla As New DataTable
        Dim sqlId As String = "SELECT @@IDENTITY as ID_persona"
        Dim cmdId As New OleDbCommand(sqlId, conexionMdb1)
        Dim da As New OleDbDataAdapter(cmdId)
        da.Fill(tabla)
        id_persona = tabla.Rows(0).Item(0)
        MsgBox(id_persona)

        '=================Me guardo el id de c/persona asi lo guardo en el inicial==========
        If CheckBox1.Checked = True Then
            frmInicial.id_cli.Text = id_persona
            frmInicial.Tcliente.Text = Tsurname.Text & "   " & Tname.Text
        End If

        If CheckBox2.Checked = True Then

            frmInicial.id_contri.Text = id_persona
            frmInicial.Tcontribuyene.Text = Tsurname.Text & "   " & Tname.Text
        End If

        If CheckBox3.Checked = True Then
            frmInicial.id_titu.Text = id_persona
            frmInicial.Ttitular.Text = Tsurname.Text & "   " & Tname.Text
        End If


        If CheckBox4.Checked = True Then
            frmInicial.id_comi.Text = id_persona
            frmInicial.Tcomitente.Text = Tsurname.Text & "   " & Tname.Text
        End If

        If CheckBox5.Checked = True Then
            frmInicial.id_propietario.Text = id_persona
            frmInicial.T_propietario.Text = Tsurname.Text & "   " & Tname.Text
        End If




        '========================================================================


        cerrarConexion1()

        Me.Close()
    End Sub

    Private Sub generacuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generacuit.Click
        Dim Cadena As Long = Convert.ToInt32(Tnumdoc.Text)
        If hombre.Checked Then
            Tcuit.Text = Cuit(Cadena, "Masculino")

        ElseIf mujer.Checked Then

            Tcuit.Text = Cuit(Cadena, "Femenino")
        ElseIf empresa.Checked Then

            Tcuit.Text = Cuit(Cadena, "Empresa")
        Else
            MessageBox.Show("Seleccione alguna opción:" & Environment.NewLine & _
                            " Masculino " & Environment.NewLine & _
                             " Femenino" & Environment.NewLine & _
                              "Empresa")
        End If

    End Sub

    Private Sub B_localidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_localidad.Click
        frmLocalidades.ShowDialog()
        Tloca.Text = localidad
        tpartido.Text = partido_1


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class