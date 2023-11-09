Public Class frmConfiguraCursor

    Dim cursorColorActual As String = ""
    Dim cajaColorActual As String = ""

    Private Sub frmConfiguraCursor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Static pasadas As Integer
        pasadas = pasadas + 1
        cursorColorActual = frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor.ToString
        lblColorCursor.Text = cursorColorActual
        cajaColorActual = frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor.ToString
        lblColorCaja.Text = cajaColorActual
        If pasadas = 1 Then
            rbCursor.Checked = True
            NumericUpDown1.Value = 3
            NumericUpDown2.Value = 10
        End If
    End Sub

    Private Sub color1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color1.Click
        If rbCursor.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = Color.Red
            lblColorCursor.Text = "Color 1: Rojo"
            My.Settings.ColorCursor = Color.Red
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = Color.Red
            lblColorCaja.Text = "Color 1: Rojo"
            My.Settings.ColorCaja = Color.Red
        End If

    End Sub

    Private Sub color2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color2.Click
        If rbCursor.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = Color.Yellow
            lblColorCursor.Text = "Color 2: Amarillo"
            My.Settings.ColorCursor = Color.Yellow
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = Color.Yellow
            lblColorCaja.Text = "Color 2: Amarillo"
            My.Settings.ColorCaja = Color.Yellow
        End If

    End Sub

    Private Sub color3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color3.Click
        If rbCursor.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = Color.Green
            lblColorCursor.Text = "Color 3: Verde"
            My.Settings.ColorCursor = Color.Green
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = Color.Green
            lblColorCaja.Text = "Color 3: Verde"
            My.Settings.ColorCaja = Color.Green
        End If

    End Sub

    Private Sub color4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color4.Click
        If rbCursor.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = Color.Cyan
            lblColorCursor.Text = "Color 4: Cyan"
            My.Settings.ColorCursor = Color.Cyan
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = Color.Cyan
            lblColorCaja.Text = "Color 4: Cyan"
            My.Settings.ColorCaja = Color.Cyan
        End If

    End Sub

    Private Sub color5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color5.Click
        If rbCursor.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = Color.Blue
            lblColorCursor.Text = "Color 5: Azul"
            My.Settings.ColorCursor = Color.Blue
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = Color.Blue
            lblColorCaja.Text = "Color 5: Azul"
            My.Settings.ColorCaja = Color.Blue
        End If

    End Sub

    Private Sub color6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color6.Click
        If rbCursor.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = Color.Magenta
            lblColorCursor.Text = "Color 6: Magenta"
            My.Settings.ColorCursor = Color.Magenta
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = Color.Magenta
            lblColorCaja.Text = "Color 6: Magenta"
            My.Settings.ColorCaja = Color.Blue
        End If

    End Sub

    Private Sub color7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color7.Click
        If rbCursor.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = Color.White
            lblColorCursor.Text = "Color 7: Blanco"
            My.Settings.ColorCursor = Color.White
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = Color.White
            lblColorCaja.Text = "Color 7: Blanco"
            My.Settings.ColorCaja = Color.White
        End If
    End Sub

    Private Sub color8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color8.Click
        If rbCursor.Checked Then
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = Color.Black
            lblColorCursor.Text = "Color 8: Negro"
            My.Settings.ColorCursor = Color.Black
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = Color.Black
            lblColorCaja.Text = "Color 8: Negro"
            My.Settings.ColorCaja = Color.Black
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        ultimoComando = "configuraCursor"
        Close()
        'Hide()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ultimoComando = "configuraCursor"
        Close()
        'Hide()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Dim valor As Integer = NumericUpDown1.Value
        frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.AxisSize = valor * 20
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        My.Settings.MedidaCursor = valor * 20
    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        Dim valor As Integer = NumericUpDown2.Value
        frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.PickSize = valor
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        My.Settings.MedidaCaja = valor
    End Sub
End Class