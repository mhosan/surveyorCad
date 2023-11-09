Imports System.Windows.Forms

Public Class frmConfiguraImpresion

    Private Sub frmConfiguraImpresion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If frmPpal.VdF.GetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine) Then
            'la linea de comandos esta visible: version normal
            btnImpresora.Visible = True
        Else
            'la linea de comandos no esta visible: version reducida
            btnImpresora.Visible = False
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If validarAnchoAlto() And validarMargenes() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Exit Sub
        End If

    End Sub
    Private Function validarMargenes() As Boolean

        If Trim(txtArriba.Text) = "" Then
            txtArriba.Text = "0"
        End If

        If Trim(txtAbajo.Text) = "" Then
            txtAbajo.Text = "0"
        End If

        If Trim(txtIzquierda.Text) = "" Then
            txtIzquierda.Text = "0"
        End If

        If Trim(txtDerecha.Text) = "" Then
            txtDerecha.Text = "0"
        End If

        If Not IsNumeric(txtArriba.Text) Or Not IsNumeric(txtAbajo.Text) _
            Or Not IsNumeric(txtIzquierda.Text) Or Not IsNumeric(txtDerecha.Text) Then
            MsgBox("Ingresar valores númericos.", MsgBoxStyle.Critical, aplicacionNombre)
            Return False
        ElseIf InStr(txtArriba.Text, ",") <> 0 Or InStr(txtArriba.Text, ".") <> 0 _
            Or InStr(txtAbajo.Text, ",") <> 0 Or InStr(txtAbajo.Text, ".") <> 0 _
            Or InStr(txtIzquierda.Text, ",") <> 0 Or InStr(txtIzquierda.Text, ".") <> 0 _
            Or InStr(txtDerecha.Text, ",") <> 0 Or InStr(txtDerecha.Text, ".") <> 0 Then
            MsgBox("Ingresar valores númericos enteros.", MsgBoxStyle.Critical, aplicacionNombre)
            Return False
        Else
            Return True
        End If

    End Function
    Private Function validarAnchoAlto() As Boolean

        If Trim(txtAncho.Text) = "" Or Trim(txtAlto.Text) = "" Then
            MsgBox("Tamaño de hoja inválido.", MsgBoxStyle.Critical, aplicacionNombre)
            Return False
        ElseIf Not IsNumeric(txtAncho.Text) Or Not IsNumeric(txtAlto.Text) Then
            MsgBox("Ingresar valores númericos enteros.", MsgBoxStyle.Critical, aplicacionNombre)
            Return False
        ElseIf InStr(txtAncho.Text, ",") <> 0 Or InStr(txtAncho.Text, ".") <> 0 Or InStr(txtAlto.Text, ",") <> 0 Or InStr(txtAlto.Text, ".") <> 0 Then
            MsgBox("Ingresar valores númericos enteros.", MsgBoxStyle.Critical, aplicacionNombre)
            Return False
        Else
            Return True
        End If

    End Function
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnPuntas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPuntas.Click
        frmPuntas.ShowDialog()
    End Sub

    Private Sub btnImpresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresora.Click

        Dim Impresoras As New PrintDialog
        Dim impresora As New System.Drawing.Printing.PrinterSettings
        Dim prtSettings As New Printing.PrinterSettings

        If Not My.Settings.impresora Is Nothing Then
            impresora.PrinterName = My.Settings.impresora.PrinterName
            impresora.Copies = My.Settings.impresora.Copies
        Else
            My.Settings.impresora = New System.Drawing.Printing.PrinterSettings
        End If

        With Impresoras
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True

            If .ShowDialog() = DialogResult.OK Then
                prtSettings = .PrinterSettings
            End If

        End With
        'MsgBox("Impresora seleccionada: " & prtSettings.PrinterName.ToString & ", cantidad de copias: " & prtSettings.Copies.ToString)

        My.Settings.impresora.PrinterName = prtSettings.PrinterName.ToString
        My.Settings.impresora.Copies = prtSettings.Copies

        'Dim impresora As New System.Drawing.Printing.PrinterSettings
        'obtiene o establece la impresora: impresora.PrinterName, as string
        'MsgBox(impresora.PrinterName.ToString)
    End Sub

    Private Sub cmbHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHoja.SelectedIndexChanged
        If cmbHoja.Text.Contains(":") = False Then
            txtAlto.Text = ""
            txtAncho.Text = ""
            Exit Sub
        Else
            Dim arrayStr() As String = cmbHoja.Text.Split(":")
            arrayStr(1) = Trim(arrayStr(1).Remove(InStr(arrayStr(1), "mm") - 1))
            arrayStr = arrayStr(1).Split("x")
            txtAlto.Text = Trim(arrayStr(0))
            txtAncho.Text = Trim(arrayStr(1))
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtAlto.Enabled = True
            txtAncho.Enabled = True
        Else
            txtAlto.Enabled = False
            txtAncho.Enabled = False
        End If
    End Sub

    Private Sub rbVertical_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVertical.CheckedChanged


        'If Trim(txtAncho.Text) = "" Or Trim(txtAlto.Text) = "" Then
        '    MsgBox("Tamaño de hoja inválido.", MsgBoxStyle.Critical, aplicacionNombre)
        '    Exit Sub
        'ElseIf Not IsNumeric(txtAncho.Text) Or Not IsNumeric(txtAlto.Text) Then
        '    MsgBox("Ingresar valores númericos enteros.", MsgBoxStyle.Critical, aplicacionNombre)
        '    Exit Sub
        'ElseIf InStr(txtAncho.Text, ",") <> 0 Or InStr(txtAncho.Text, ".") <> 0 Or InStr(txtAlto.Text, ",") <> 0 Or InStr(txtAlto.Text, ".") <> 0 Then
        '    MsgBox("Ingresar valores númericos enteros.", MsgBoxStyle.Critical, aplicacionNombre)
        '    Exit Sub
        'Else
        '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
        '    Return True
        'End If



        If validarAnchoAlto() Then
            Dim temporario As String
            temporario = txtAlto.Text
            txtAlto.Text = txtAncho.Text
            txtAncho.Text = temporario
        End If

    End Sub

End Class
