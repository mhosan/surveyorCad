Imports System.Drawing.Color

Public Class frmNuevoLayout

    Public EdicionLamina As Boolean

    Private Sub frmNuevoLayout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        If EdicionLamina Then
            cmbLaminas.Items.Clear()
            For Each lamina As VectorDraw.Professional.vdPrimaries.vdLayout In frmPpal.VdF.BaseControl.ActiveDocument.LayOuts
                cmbLaminas.Items.Add(lamina.Name)
            Next
            cmbLaminas.Visible = True
            cmbLaminas.Text = ""

            txtNombre.Visible = False
            txtAlto.Visible = True
            txtAncho.Visible = True

            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            txtAlto.Text = ""
            txtAncho.Text = ""
            cmbHoja.Visible = True
            btnGirar.Visible = True
            btnColor.Visible = True
        Else
            txtNombre.Visible = True
            txtNombre.Text = ""

            cmbHoja.SelectedIndex = 0

            cmbLaminas.Visible = False
            txtAncho.Visible = True
            txtAlto.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            btnGirar.Visible = False
            btnColor.Visible = False
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If EdicionLamina Then
            If Not cmbLaminas Is Nothing And _
                IsNumeric(txtAlto.Text) And _
                IsNumeric(txtAncho.Text) Then
                modificar(cmbLaminas.Text)
                Close()
            Else
                MsgBox("Datos faltantes o erróneos")
            End If

        Else
            'lamina nueva..
            If Not txtNombre Is Nothing And _
                IsNumeric(txtAlto.Text) And _
                IsNumeric(txtAncho.Text) Then
                guardar()
                Close()
            Else
                MsgBox("Datos faltantes o erróneos")
            End If
        End If

    End Sub

    Private Sub guardar()

        Dim laminaNombre As String
        If EdicionLamina Then
            laminaNombre = cmbLaminas.Text
        Else
            laminaNombre = txtNombre.Text
        End If

        If laminaNombre = "" Then
            MsgBox("Ingresar nombre de lámina", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        Dim laminaNueva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        laminaNueva.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        laminaNueva.setDocumentDefaults()
        'laminaNueva.DisableShowPrinterPaper = True
        laminaNueva.Name = laminaNombre
        laminaNueva.ShowUCSAxis = True
        laminaNueva.BkColorEx = Color.FromArgb(0, 0, 0)
        'laminaNueva.BkGradientColor = Color.Red
        'Dim unidades As VectorDraw.Geometry.LUnits = New VectorDraw.Geometry.LUnits
        'unidades.UType = VectorDraw.Geometry.LUnits.LUnitType.lu_windesk
        'laminaNueva.Printer.lunits = unidades
        'laminaNueva.Printer.SelectPaper("A0")
        laminaNueva.Printer.margins.Left = 0.0 '0.984251968503937    '25 mm pasados a pulgadas: 25mm / 25.4
        laminaNueva.Printer.margins.Right = 0.0 '0.19685039370078741 '5 mm
        laminaNueva.Printer.margins.Bottom = 0.0 '0.19685039370078741
        laminaNueva.Printer.margins.Top = 0.0 '0.19685039370078741

        'Dim papelito As VectorDraw.Professional.vdObjects.SIZE = New VectorDraw.Professional.vdObjects.SIZE
        'papelito.Height = 500
        'papelito.Width = 500
        'laminaNueva.Printer.SelectPaper("papelito")


        'parametros del ancho y alto de la hoja. Para calcular hacer tamaño deseado en mm * 500 / 127 ~
        Dim mAncho As Integer = CInt(CInt(txtAncho.Text) * 500 / 127)
        Dim mAlto As Integer = CInt(CInt(txtAlto.Text) * 500 / 127)
        laminaNueva.Printer.paperSize = New System.Drawing.Rectangle(0, 0, mAncho, mAlto)



        frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.AddItem(laminaNueva)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Private Sub txtNombre_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtNombre_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating
        If Trim(txtNombre.Text) = "" Then
            e.Cancel = True
            ErrorProvider1.SetError(txtNombre, "Ingresar un nombre para la nueva lámina")
        End If
    End Sub

    Private Sub txtAncho_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAncho.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtAncho_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAncho.Validating
        Dim haySepMiles As Integer = InStr(txtAncho.Text, sepMiles)
        If haySepMiles <> 0 Then
            txtAncho.Text = Replace(txtAncho.Text, sepMiles, sepDecimal)
        End If

        Dim haySepDec As Integer = InStr(txtAncho.Text, sepDecimal)
        If haySepDec = 1 Then
            txtAncho.Text = "0" & txtAncho.Text
        End If

        If Not IsNumeric(txtAncho.Text) Then
            e.Cancel = True
            txtAncho.Select(0, txtAncho.Text.Length)
            ErrorProvider1.SetError(txtAncho, "Ingresar un nùmero")
        End If
    End Sub

    Private Sub txtAlto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlto.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtAlto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAlto.Validating
        Dim haySepMiles As Integer = InStr(txtAlto.Text, sepMiles)
        If haySepMiles <> 0 Then
            txtAlto.Text = Replace(txtAlto.Text, sepMiles, sepDecimal)
        End If

        Dim haySepDec As Integer = InStr(txtAlto.Text, sepDecimal)
        If haySepDec = 1 Then
            txtAlto.Text = "0" & txtAlto.Text
        End If

        If Not IsNumeric(txtAlto.Text) Then
            e.Cancel = True
            txtAlto.Select(0, txtAlto.Text.Length)
            ErrorProvider1.SetError(txtAlto, "Ingresar un nùmero")
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub cmbLaminas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLaminas.SelectedIndexChanged
        For Each lamina As VectorDraw.Professional.vdPrimaries.vdLayout In frmPpal.VdF.BaseControl.ActiveDocument.LayOuts
            If lamina.Name = cmbLaminas.Text Then
                Dim ancho As Integer = lamina.Printer.paperSize.Width * 127 / 500
                Dim alto As Integer = lamina.Printer.paperSize.Height * 127 / 500
                txtAncho.Visible = True
                txtAncho.Text = ancho
                txtAlto.Visible = True
                txtAlto.Text = alto
                cmbHoja.Visible = True
                cmbHoja.SelectedIndex = 0
                Label2.Visible = True
                Label3.Visible = True
                Label4.Visible = True
                Label5.Visible = True
                Label6.Visible = True
                btnGirar.Visible = True
                btnColor.Visible = True
            End If
        Next
    End Sub

    Private Sub modificar(ByVal nombreLaminaAmodificar As String)
        For Each lamina As VectorDraw.Professional.vdPrimaries.vdLayout In frmPpal.VdF.BaseControl.ActiveDocument.LayOuts
            If lamina.Name = nombreLaminaAmodificar Then
                Dim mAncho As Integer = CInt(CInt(txtAncho.Text) * 500 / 127)
                Dim mAlto As Integer = CInt(CInt(txtAlto.Text) * 500 / 127)
                lamina.Printer.paperSize = New System.Drawing.Rectangle(0, 0, mAncho, mAlto)
            End If
        Next
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    'Private Sub aPartirDeCurvaCerrada()
    '    'vp.ClipObj = poly1 as VectorDraw.Professional.vdFigures.vdCurve;
    '    '--------------------------------
    '    ' seleccion de una curva cerrada
    '    '--------------------------------
    '    Me.Hide()
    '    Dim ret As VectorDraw.Actions.StatusCode
    '    frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar entidad de referencia")
    '    Dim figura As VectorDraw.Professional.vdPrimaries.vdFigure
    '    'figura = New VectorDraw.Professional.vdPrimaries.vdFigure

    '    Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '    ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntityIgnoreLockLayers(figura, punto)
    '    If ret = VectorDraw.Actions.StatusCode.Success Then
    '        MsgBox("si")
    '    Else
    '        Exit Sub
    '    End If
    '    frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

    'End Sub
    Private Sub cmbHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHoja.SelectedIndexChanged

        If cmbHoja.Text.Contains(":") = False Then
            If cmbHoja.Text.Contains("Tamaño personal") Then
                txtAlto.Visible = True
                txtAlto.Text = ""
                txtAncho.Visible = True
                txtAncho.Text = ""
                Label3.Visible = True
                Label4.Visible = True
                Label5.Visible = True
                Label6.Visible = True
            End If
        Else
            Dim arrayStr() As String = cmbHoja.Text.Split(":")
            arrayStr(1) = Trim(arrayStr(1).Remove(InStr(arrayStr(1), "mm") - 1))
            arrayStr = arrayStr(1).Split("x")
            txtAlto.Text = Trim(arrayStr(0))
            txtAncho.Text = Trim(arrayStr(1))
        End If


    End Sub

    Private Sub btnGirar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGirar.Click
        If cmbLaminas.Text <> "" And txtAlto.Text <> "" And txtAncho.Text <> "" Then
            Dim tempo As String = txtAlto.Text
            txtAlto.Text = txtAncho.Text
            txtAncho.Text = tempo
            modificar(cmbLaminas.Text)
        End If
    End Sub

    Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor.Click
        If cmbLaminas.Text = "" Then
            MsgBox("Seleccionar una làmina")
            Exit Sub
        End If

        ' mostrar cuadro de dialogo colores
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim mColor As VectorDraw.Professional.vdObjects.vdColor = New VectorDraw.Professional.vdObjects.vdColor()
        mColor.Palette = frmPpal.VdF.BaseControl.ActiveDocument.Palette

        Dim dialog As VectorDraw.Professional.Dialogs.frmColor = New VectorDraw.Professional.Dialogs.frmColor((mColor), False)
        dialog.ShowDialog()

        If (dialog.DialogResult = DialogResult.OK) Then
            'frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = mColor
            For Each lamina As VectorDraw.Professional.vdPrimaries.vdLayout In frmPpal.VdF.BaseControl.ActiveDocument.LayOuts
                If lamina.Name = cmbLaminas.Text Then
                    If mColor.Red = 255 And mColor.Green = 255 And mColor.Blue = 255 Then
                        lamina.DisableShowPrinterPaper = False
                    Else
                        lamina.DisableShowPrinterPaper = True
                    End If
                    lamina.BkColorEx = System.Drawing.Color.FromArgb(mColor.Red, mColor.Green, mColor.Blue)
                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                End If
            Next
        End If

    End Sub
    'Public EdicionLamina As Boolean

    'Private Sub frmNewLayout_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
    '        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
    '    End If
    '    If EdicionLamina Then
    '        cmbLaminas.Items.Clear()
    '        For Each lamina As VectorDraw.Professional.vdPrimaries.vdLayout In frmPpal.VdF.BaseControl.ActiveDocument.LayOuts
    '            cmbLaminas.Items.Add(lamina.Name)
    '        Next
    '        cmbLaminas.Visible = True
    '        cmbLaminas.Text = ""
    '        txtNombre.Visible = False
    '        txtAlto.Visible = False
    '        txtAncho.Visible = False
    '        Label2.Visible = False
    '        Label3.Visible = False
    '        Label4.Visible = False
    '        Label5.Visible = False
    '        Label6.Visible = False
    '        txtAlto.Text = ""
    '        txtAncho.Text = ""
    '        cmbHoja.Visible = False
    '        btnGirar.Visible = False
    '        btnColor.Visible = False
    '    Else
    '        txtNombre.Visible = True
    '        txtNombre.Text = ""
    '        cmbHoja.SelectedIndex = 0
    '        cmbLaminas.Visible = False
    '        txtAncho.Visible = False
    '        txtAlto.Visible = False
    '        Label3.Visible = False
    '        Label4.Visible = False
    '        Label5.Visible = False
    '        Label6.Visible = False
    '        btnGirar.Visible = False
    '        btnColor.Visible = False
    '    End If
    'End Sub

    'Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
    '    If EdicionLamina Then
    '        If Not cmbLaminas Is Nothing And _
    '            IsNumeric(txtAlto.Text) And _
    '            IsNumeric(txtAncho.Text) Then
    '            modificar(cmbLaminas.Text)
    '            Close()
    '        Else
    '            MsgBox("Datos faltantes o erróneos")
    '        End If

    '    Else
    '        'lamina nueva..
    '        If Not txtNombre Is Nothing And _
    '            IsNumeric(txtAlto.Text) And _
    '            IsNumeric(txtAncho.Text) Then
    '            guardar()
    '            Close()
    '        Else
    '            MsgBox("Datos faltantes o erróneos")
    '        End If
    '    End If

    'End Sub

    'Private Sub guardar()

    '    Dim laminaNombre As String
    '    If EdicionLamina Then
    '        laminaNombre = cmbLaminas.Text
    '    Else
    '        laminaNombre = txtNombre.Text
    '    End If

    '    If laminaNombre = "" Then
    '        MsgBox("Ingresar nombre de lámina", MsgBoxStyle.Information, aplicacionNombre)
    '        Exit Sub
    '    End If

    '    Dim laminaNueva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
    '    laminaNueva.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
    '    laminaNueva.setDocumentDefaults()
    '    'laminaNueva.DisableShowPrinterPaper = True
    '    laminaNueva.Name = laminaNombre
    '    laminaNueva.ShowUCSAxis = True
    '    laminaNueva.BkColorEx = Color.FromArgb(0, 0, 0)
    '    'laminaNueva.BkGradientColor = Color.Red
    '    'Dim unidades As VectorDraw.Geometry.LUnits = New VectorDraw.Geometry.LUnits
    '    'unidades.UType = VectorDraw.Geometry.LUnits.LUnitType.lu_windesk
    '    'laminaNueva.Printer.lunits = unidades
    '    'laminaNueva.Printer.SelectPaper("A0")
    '    laminaNueva.Printer.margins.Left = 0.0 '0.984251968503937    '25 mm pasados a pulgadas: 25mm / 25.4
    '    laminaNueva.Printer.margins.Right = 0.0 '0.19685039370078741 '5 mm
    '    laminaNueva.Printer.margins.Bottom = 0.0 '0.19685039370078741
    '    laminaNueva.Printer.margins.Top = 0.0 '0.19685039370078741

    '    'Dim papelito As VectorDraw.Professional.vdObjects.SIZE = New VectorDraw.Professional.vdObjects.SIZE
    '    'papelito.Height = 500
    '    'papelito.Width = 500
    '    'laminaNueva.Printer.SelectPaper("papelito")


    '    'parametros del ancho y alto de la hoja. Para calcular hacer tamaño deseado en mm * 500 / 127 ~
    '    Dim mAncho As Integer = CInt(CInt(txtAncho.Text) * 500 / 127)
    '    Dim mAlto As Integer = CInt(CInt(txtAlto.Text) * 500 / 127)
    '    laminaNueva.Printer.paperSize = New System.Drawing.Rectangle(0, 0, mAncho, mAlto)



    '    frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.AddItem(laminaNueva)
    '    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    'End Sub

    'Private Sub txtNombre_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.Validated

    'End Sub

    'Private Sub txtNombre_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating

    'End Sub

    'Private Sub txtAncho_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAncho.Validated

    'End Sub

    'Private Sub txtAncho_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAncho.Validating

    'End Sub

    'Private Sub txtAlto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlto.Validated

    'End Sub

    'Private Sub txtAlto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAlto.Validating

    'End Sub

    'Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    '    Close()
    'End Sub

    'Private Sub cmbLaminas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLaminas.SelectedIndexChanged

    'End Sub

    'Private Sub modificar(ByVal nombreLaminaAmodificar As String)
    '    For Each lamina As VectorDraw.Professional.vdPrimaries.vdLayout In frmPpal.VdF.BaseControl.ActiveDocument.LayOuts
    '        If lamina.Name = nombreLaminaAmodificar Then
    '            Dim mAncho As Integer = CInt(CInt(txtAncho.Text) * 500 / 127)
    '            Dim mAlto As Integer = CInt(CInt(txtAlto.Text) * 500 / 127)
    '            lamina.Printer.paperSize = New System.Drawing.Rectangle(0, 0, mAncho, mAlto)
    '        End If
    '    Next
    '    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    'End Sub

    ''Private Sub aPartirDeCurvaCerrada()
    ''    'vp.ClipObj = poly1 as VectorDraw.Professional.vdFigures.vdCurve;
    ''    '--------------------------------
    ''    ' seleccion de una curva cerrada
    ''    '--------------------------------
    ''    Me.Hide()
    ''    Dim ret As VectorDraw.Actions.StatusCode
    ''    frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar entidad de referencia")
    ''    Dim figura As VectorDraw.Professional.vdPrimaries.vdFigure
    ''    'figura = New VectorDraw.Professional.vdPrimaries.vdFigure

    ''    Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    ''    ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntityIgnoreLockLayers(figura, punto)
    ''    If ret = VectorDraw.Actions.StatusCode.Success Then
    ''        MsgBox("si")
    ''    Else
    ''        Exit Sub
    ''    End If
    ''    frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

    ''End Sub
    'Private Sub cmbHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHoja.SelectedIndexChanged

    'End Sub

    'Private Sub btnGirar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGirar.Click

    'End Sub

    'Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor.Click

    'End Sub

End Class