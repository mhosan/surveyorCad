Public Class frmConfiguraEspacioModelo

    Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor.Click

        ' mostrar cuadro de dialogo colores
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim mColor As VectorDraw.Professional.vdObjects.vdColor = New VectorDraw.Professional.vdObjects.vdColor()
        mColor.Palette = frmPpal.VdF.BaseControl.ActiveDocument.Palette

        Dim dialog As VectorDraw.Professional.Dialogs.frmColor = New VectorDraw.Professional.Dialogs.frmColor((mColor), False)
        dialog.ShowDialog()

        If (dialog.DialogResult = DialogResult.OK) Then
            frmPpal.VdF.BaseControl.ActiveDocument.Model.BkColorEx = System.Drawing.Color.FromArgb(mColor.Red, mColor.Green, mColor.Blue)
            My.Settings.ColorFondo = System.Drawing.Color.FromArgb(mColor.Red, mColor.Green, mColor.Blue)
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        End If

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Close()
    End Sub
End Class