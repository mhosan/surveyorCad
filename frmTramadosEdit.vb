Imports VectorDraw.Professional.vdFigures
Public Class frmTramadosEdit

    Dim trama As vdPolyhatch = New vdPolyhatch

    Private Sub frmTramadosEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Edición de tramados"
        trama.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        trama.setDocumentDefaults()
        trama = entidad
        txtEscala.Text = trama.HatchProperties.HatchScale.ToString
        txtAngulo.Text = trama.HatchProperties.HatchAngle.ToString
        lblTrama.Text = trama.HatchProperties.FillMode.ToString

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        cargarCambios()
        LimpiarSeleccion(obtenerSeleccion)
        Close()

    End Sub

    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        LimpiarSeleccion(obtenerSeleccion)
        Close()

    End Sub

    Private Sub cargarCambios()
        If IsNumeric(txtEscala.Text) Then
            trama.HatchProperties.HatchScale = CDbl(txtEscala.Text)
        End If
        If IsNumeric(txtAngulo.Text) Then
            trama.HatchProperties.HatchAngle = CDbl(txtAngulo.Text)
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
    End Sub

    Private Sub txtEscala_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEscala.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtEscala_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEscala.Validating
        Dim haySepMiles As Integer = InStr(txtEscala.Text, sepMiles)
        If haySepMiles <> 0 Then
            txtEscala.Text = Replace(txtEscala.Text, sepMiles, sepDecimal)
        End If

        Dim haySepDec As Integer = InStr(txtEscala.Text, sepDecimal)
        If haySepDec = 1 Then
            txtEscala.Text = "0" & txtEscala.Text
        End If

        If Not IsNumeric(txtEscala.Text) Then
            e.Cancel = True
            txtEscala.Select(0, txtEscala.Text.Length)
            ErrorProvider1.SetError(txtEscala, "Ingresar un nùmero!")
        End If
    End Sub

    Private Sub txtAngulo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAngulo.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtAngulo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAngulo.Validating
        Dim haySepMiles As Integer = InStr(txtAngulo.Text, sepMiles)
        If haySepMiles <> 0 Then
            txtAngulo.Text = Replace(txtAngulo.Text, sepMiles, sepDecimal)
        End If

        Dim haySepDec As Integer = InStr(txtAngulo.Text, sepDecimal)
        If haySepDec = 1 Then
            txtAngulo.Text = "0" & txtAngulo.Text
        End If

        If Not IsNumeric(txtAngulo.Text) Then
            e.Cancel = True
            txtAngulo.Select(0, txtAngulo.Text.Length)
            ErrorProvider1.SetError(txtAngulo, "Ingresar un nùmero!")
        End If
    End Sub
End Class