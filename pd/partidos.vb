Public Class partidos

    Private Sub partidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox("es a :" & Inicial.a)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmInicial.Visible = True
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bandera = 1

        tipo_persona_1 = String.Empty
        tipo_persona_2 = String.Empty
        tipo_persona_3 = String.Empty
        tipo_persona_4 = String.Empty

        If CheckBox1.Checked Then tipo_persona_1 = "Cliente"
        If CheckBox2.Checked Then tipo_persona_2 = "Contribuyente"
        If CheckBox3.Checked Then tipo_persona_3 = "Titular"
        If CheckBox4.Checked Then tipo_persona_3 = "Comitente"
        tipo_peronsa_apellido = Tsurname.Text
        tipo_peronsa_nombre = Tname.Text
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim d As Integer
        Dim total_ca As String = Len(TextBox2.Text)

        Dim Cadena = TextBox2.Text
        Dim Caracteres(total_ca) As Integer
        ' Caracteres.AddRange(Cadena)


        d = Caracteres(0)

        If total_ca = 8 Then

            If hombre.Checked Then
                d = 20

            ElseIf mujer.Checked Then
                d = 27
            ElseIf empresa.Checked Then
                d = 30
            Else
                MessageBox.Show("Seleccione alguna opción:" & Environment.NewLine & _
                                "M= Masculino " & Environment.NewLine & _
                                 "F= Femenino" & Environment.NewLine & _
                                  "E=Empresa")
            End If

        Else

            If total_ca = 7 Then
            End If
        End If




    End Sub
End Class