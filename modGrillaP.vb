Module modGrillaP

    Public Sub actualizarGrillaPropiedades()

        Dim laGrilla As vdPropertyGrid.vdPropertyGrid
        laGrilla = frmPpal.VdF.vdGrid
        laGrilla.SelectedObject = frmPpal.VdF.BaseControl.ActiveDocument

    End Sub

    Public Sub propertyGrid()
        '------------------------------------
        ' mostrar/ocultar 
        '------------------------------------

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        If estoyEnUnViewport() Then
            'MsgBox("estoy en un viewport. Salgo")
            salirDelViewport()
        End If

        If frmPpal.VdF.GetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.PropertyGrid) Then
            frmPpal.VdF.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.PropertyGrid, False)
        Else
            frmPpal.VdF.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.PropertyGrid, True)
            frmPpal.VdF.vdGrid.SelectedObject = frmPpal.VdF.BaseControl.ActiveDocument
            'frmPpal.VdF.vdGrid.Width = frmPpal.VdF.vdGrid.Width - (frmPpal.VdF.vdGrid.Width / 4)
            'frmPpal.VdF.vdGrid.Width = 100
        End If
        ultimoComando = "prendeApagaGrilla"

    End Sub
    Public Sub apagaGrilla()
        '------------------------------------
        ' ocultar grilla 
        '------------------------------------

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        If estoyEnUnViewport() Then
            'MsgBox("estoy en un viewport. Salgo")
            salirDelViewport()
        End If

        frmPpal.VdF.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.PropertyGrid, False)

    End Sub
End Module
