Public Class frmPuntas

    Private Sub frmPuntas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim espesor As Double = 0.0
 
        For a As Integer = 1 To 255
            espesor = matrizEspesores(a - 1)
            Select Case a
                Case 1 To 9
                    listaPuntas.Items.Add(a.ToString.PadRight(14) & Format(espesor, "#,0.0000"))
                Case 10 To 99
                    listaPuntas.Items.Add(a.ToString.PadRight(13) & Format(espesor, "#,0.0000"))
                Case 100 To 255
                    listaPuntas.Items.Add(a.ToString.PadRight(10) & Format(espesor, "#,0.0000"))
            End Select
        Next
        listaPuntas.SelectedIndex = 0

    End Sub

    Private Sub listaPuntas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaPuntas.SelectedIndexChanged

        If sender.selectedItem Is Nothing Then
            Exit Sub
        End If

        Dim seleccion() As String = Split(sender.selecteditem.ToString)
        Dim indiceColor As Integer = CInt(seleccion(0))
        Dim espesor As Double = seleccion(seleccion.Count - 1)

        Select Case indiceColor
            Case Is = 1
                PictureBox1.BackColor = Color.Red
            Case Is = 2
                PictureBox1.BackColor = Color.Yellow
            Case Is = 3
                PictureBox1.BackColor = Color.GreenYellow
            Case Is = 4
                PictureBox1.BackColor = Color.Cyan
            Case Is = 5
                PictureBox1.BackColor = Color.Blue
            Case Is = 6
                PictureBox1.BackColor = Color.Magenta
            Case Is = 7
                PictureBox1.BackColor = Color.White
            Case Is = 8
                PictureBox1.BackColor = Color.FromArgb(128, 128, 128)
            Case Is = 9
                PictureBox1.BackColor = Color.FromArgb(192, 192, 192)
            Case Is = 10
                PictureBox1.BackColor = Color.FromArgb(255, 0, 0)
            Case Is = 11
                PictureBox1.BackColor = Color.FromArgb(255, 127, 127)
            Case Is = 12
                PictureBox1.BackColor = Color.FromArgb(204, 0, 0)
            Case Is = 13
                PictureBox1.BackColor = Color.FromArgb(204, 102, 102)
            Case Else
                PictureBox1.BackColor = Color.FromArgb(0, 0, 0)
        End Select
        TextBox1.Text = espesor
        lblPunta.Text = indiceColor
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        For a As Integer = 0 To 254
            My.Settings.espesores(a) = matrizEspesores(a)
        Next
        Me.Close()

    End Sub

    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Me.Close()

    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        matrizEspesores(CInt(lblPunta.Text) - 1) = CDbl(TextBox1.Text)

        Select Case CInt(lblPunta.Text)
            Case 1 To 9
                listaPuntas.Items.Item(CInt(lblPunta.Text) - 1) = (lblPunta.Text.ToString.PadRight(14) & Format(CDbl(TextBox1.Text), "#,0.0000"))
            Case 10 To 99
                listaPuntas.Items.Item(CInt(lblPunta.Text) - 1) = (lblPunta.Text.ToString.PadRight(13) & Format(CDbl(TextBox1.Text), "#,0.0000"))
            Case 100 To 255
                listaPuntas.Items.Item(CInt(lblPunta.Text) - 1) = (lblPunta.Text.ToString.PadRight(10) & Format(CDbl(TextBox1.Text), "#,0.0000"))
        End Select

    End Sub
End Class