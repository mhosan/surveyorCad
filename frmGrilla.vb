Public Class frmGrilla
    Dim vengoDelLoad As Boolean

    Private Sub frmGrilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nuGrillaX.Value = frmPpal.VdF.BaseControl.ActiveDocument.GridSpaceX()
        nuGrillaY.Value = frmPpal.VdF.BaseControl.ActiveDocument.GridSpaceY()
        Dim xLL As Double = frmPpal.VdF.BaseControl.ActiveDocument.Limits.Left
        Dim yLL As Double = frmPpal.VdF.BaseControl.ActiveDocument.Limits.Bottom
        Dim xUR As Double = frmPpal.VdF.BaseControl.ActiveDocument.Limits.Right
        Dim yUR As Double = frmPpal.VdF.BaseControl.ActiveDocument.Limits.Top
        txtXLl.Text = xLL
        txtYLl.Text = yLL
        txtXUr.Text = xUR
        txtYUr.Text = yUR
        vengoDelLoad = True
        nuAnguloTracking.Value = VectorDraw.Geometry.Globals.RadiansToDegrees(frmPpal.VdF.BaseControl.ActiveDocument.PolarTrackAngle)


    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()

    End Sub

    Private Sub chkGrilla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGrilla.CheckedChanged
        If chkGrilla.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.GridMode = True
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.GridMode = False
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub chkSnap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSnap.CheckedChanged
        If chkSnap.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.SnapMode = True
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.SnapMode = False
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub nuGrillaX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuGrillaX.ValueChanged
        frmPpal.VdF.BaseControl.ActiveDocument.GridSpaceX = CDbl(nuGrillaX.Value)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub nuGrillaY_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuGrillaY.ValueChanged
        frmPpal.VdF.BaseControl.ActiveDocument.GridSpaceY = CDbl(nuGrillaY.Value)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub txtYLl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtYLl.Validating
        'verifico que no este vacio el valor de x de la esquina inferior izquierda
        If txtYLl.Text = Nothing Or Trim(txtYLl.Text) = "" Then
            e.Cancel = True
            ErrorProvider1.SetError(txtYLl, "Ingresar un número")
            Exit Sub
        End If
        'verifico que sea un valor numérico
        If Not IsNumeric(txtYLl.Text) Then
            e.Cancel = True
            txtYLl.Select(0, txtYLl.Text.Length)
            ErrorProvider1.SetError(txtYLl, "Ingresar un nùmero!")
            Exit Sub
        End If
        'verifico el separador decimal. Por si hay un separador de miles en lugar de un sep. dec.
        Dim haySepMiles As Integer = InStr(txtYLl.Text, sepMiles)
        If haySepMiles <> 0 Then
            txtYLl.Text = Replace(txtYLl.Text, sepMiles, sepDecimal)
        End If
        'si hay un separador decimal como primer caracter, le agrego un cero delante.
        Dim haySepDec As Integer = InStr(txtYLl.Text, sepDecimal)
        If haySepDec = 1 Then
            txtYLl.Text = "0" & txtYLl.Text
        End If
    End Sub

    Private Sub txtYLl_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYLl.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtXUr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtXUr.Validating
        'verifico que no este vacio el valor de x de la esquina inferior izquierda
        If txtXUr.Text = Nothing Or Trim(txtXUr.Text) = "" Then
            e.Cancel = True
            ErrorProvider1.SetError(txtXUr, "Ingresar un número")
            Exit Sub
        End If
        'verifico que sea un valor numérico
        If Not IsNumeric(txtXUr.Text) Then
            e.Cancel = True
            txtXUr.Select(0, txtXUr.Text.Length)
            ErrorProvider1.SetError(txtXUr, "Ingresar un nùmero!")
            Exit Sub
        End If
        'verifico el separador decimal. Por si hay un separador de miles en lugar de un sep. dec.
        Dim haySepMiles As Integer = InStr(txtXUr.Text, sepMiles)
        If haySepMiles <> 0 Then
            txtXUr.Text = Replace(txtXUr.Text, sepMiles, sepDecimal)
        End If
        'si hay un separador decimal como primer caracter, le agrego un cero delante.
        Dim haySepDec As Integer = InStr(txtXUr.Text, sepDecimal)
        If haySepDec = 1 Then
            txtXUr.Text = "0" & txtXUr.Text
        End If
    End Sub

    Private Sub txtXUr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXUr.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtYUr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtYUr.Validating
        'verifico que no este vacio el valor de x de la esquina inferior izquierda
        If txtYUr.Text = Nothing Or Trim(txtYUr.Text) = "" Then
            e.Cancel = True
            ErrorProvider1.SetError(txtYUr, "Ingresar un número")
            Exit Sub
        End If
        'verifico que sea un valor numérico
        If Not IsNumeric(txtYUr.Text) Then
            e.Cancel = True
            txtYUr.Select(0, txtYUr.Text.Length)
            ErrorProvider1.SetError(txtYUr, "Ingresar un nùmero!")
            Exit Sub
        End If
        'verifico el separador decimal. Por si hay un separador de miles en lugar de un sep. dec.
        Dim haySepMiles As Integer = InStr(txtYUr.Text, sepMiles)
        If haySepMiles <> 0 Then
            txtYUr.Text = Replace(txtYUr.Text, sepMiles, sepDecimal)
        End If
        'si hay un separador decimal como primer caracter, le agrego un cero delante.
        Dim haySepDec As Integer = InStr(txtYUr.Text, sepDecimal)
        If haySepDec = 1 Then
            txtYUr.Text = "0" & txtYUr.Text
        End If
    End Sub

    Private Sub txtYUr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYUr.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim puntoUno As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim puntoDos As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint

        puntoUno.x = CDbl(txtXLl.Text)
        puntoUno.y = CDbl(txtYLl.Text)
        puntoDos.x = CDbl(txtXUr.Text)
        puntoDos.y = CDbl(txtYUr.Text)
        Dim caja As VectorDraw.Geometry.Box = New VectorDraw.Geometry.Box(puntoUno, puntoDos)
        frmPpal.VdF.BaseControl.ActiveDocument.Limits = caja
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub


    Private Sub txtXLl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtXLl.Validating
        'verifico que no este vacio el valor de x de la esquina inferior izquierda
        If txtXLl.Text = Nothing Or Trim(txtXLl.Text) = "" Then
            e.Cancel = True
            ErrorProvider1.SetError(txtXLl, "Ingresar un número")
            Exit Sub
        End If
        'verifico que sea un valor numérico
        If Not IsNumeric(txtXLl.Text) Then
            e.Cancel = True
            txtXLl.Select(0, txtXLl.Text.Length)
            ErrorProvider1.SetError(txtXLl, "Ingresar un nùmero!")
            Exit Sub
        End If
        'verifico el separador decimal. Por si hay un separador de miles en lugar de un sep. dec.
        Dim haySepMiles As Integer = InStr(txtXLl.Text, sepMiles)
        If haySepMiles <> 0 Then
            txtXLl.Text = Replace(txtXLl.Text, sepMiles, sepDecimal)
        End If
        'si hay un separador decimal como primer caracter, le agrego un cero delante.
        Dim haySepDec As Integer = InStr(txtXLl.Text, sepDecimal)
        If haySepDec = 1 Then
            txtXLl.Text = "0" & txtXLl.Text
        End If
    End Sub
    Private Sub txtXLl_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXLl.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub chkActivarTrackingPolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivarTrackingPolar.CheckedChanged
        If chkActivarTrackingPolar.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.PolarTrack = True
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.PolarTrack = False
        End If
        actualizarGrillaPropiedades()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub nuAnguloTracking_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuAnguloTracking.ValueChanged

        If vengoDelLoad Then
            vengoDelLoad = False
        Else
            Dim valor As Object = VectorDraw.Geometry.Globals.DegreesToRadians(CDbl(nuAnguloTracking.Value))
            frmPpal.VdF.BaseControl.ActiveDocument.PolarTrackAngle = VectorDraw.Geometry.Globals.DegreesToRadians(CDbl(nuAnguloTracking.Value))
            actualizarGrillaPropiedades()
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        End If
        
    End Sub

    Private Sub chkActivarPegadoTrackingPolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivarPegadoTrackingPolar.CheckedChanged
        If chkActivarPegadoTrackingPolar.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.PolarTrackLock = True
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.PolarTrackLock = False
        End If
        actualizarGrillaPropiedades()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub
End Class