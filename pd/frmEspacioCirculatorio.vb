Public Class frmEspacioCirculatorio

    Private Sub BtnAceptarEspacioCirculatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptarEspacioCirculatorio.Click
        AnchoEspacioCirculatorio = Convert.ToDecimal(TxtAnchoEspacioCirculatorio.Text)
        NombreEspacioCirculatorio = TxtNombreEspacioCirculatorio.Text
        CancelarDibujoEspacioCirculatorio = False
        Me.Close()
    End Sub

    Private Sub BtnCancelarEspacioCirculatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarEspacioCirculatorio.Click
        CancelarDibujoEspacioCirculatorio = True
        Me.Close()
    End Sub
End Class