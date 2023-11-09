Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects

Module modGrips

    'Dim elCursorOriginal As System.Windows.Forms.Cursor
    Public Sub LimpiarSeleccion(ByVal GripSelection As vdSelection) 'ojo era Public Sub ClearAllGrips
        For Each fig As vdFigure In GripSelection
            If fig.HighLight = True Then
                fig.HighLight = False
            End If
            fig.ShowGrips = False
        Next fig
        If (GripSelection.Count > 0) Then
            GripSelection.RemoveAll()
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control)
        End If
        'activo el cursor original nuevamente
        'frmPpal.VdF.BaseControl.SetCustomMousePointer(elCursorOriginal)
    End Sub

    Public Function obtenerSeleccion() As vdSelection
        Dim selsetname As String


        ''me guardo el cursor original
        'elCursorOriginal = frmPpal.VdF.BaseControl.GetCustomMousePointer
        ''activo el cursor de seleccionar, el cuadradito:
        'Dim cursorDeSeleccionar As Cursor
        'cursorDeSeleccionar = New Cursor(ubicacionSoporte & "\selecciona1.cur")
        'frmPpal.VdF.BaseControl.SetCustomMousePointer(cursorDeSeleccionar)

        If (Not frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveViewPort Is Nothing) Then
            selsetname = "VDGRIPSET_" + frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Handle.ToStringValue() + frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveViewPort.Handle.ToStringValue()
        Else
            selsetname = "VDGRIPSET_" + frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Handle.ToStringValue()
        End If

        'selsetname = "VDGRIPSET_"
        Dim gripset As vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Document.Selections.FindName(selsetname)
        If (gripset Is Nothing) Then gripset = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Document.Selections.Add(selsetname)
        'For Each figurita As vdFigure In gripset
        '    figurita.HighLight = True
        'Next
        obtenerSeleccion = gripset


        'Dim cantidadDeSelecciones As Integer = frmPpal.VdF.BaseControl.ActiveDocument.Selections.Count
        'Dim selecciones As vdSelections = frmPpal.VdF.BaseControl.ActiveDocument.Selections
        'Dim primerSeleccion As vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.Selections.Item(0)



    End Function

    Private Sub DrawGrips(ByVal GripSelection As vdSelection)

        If (GripSelection.Count = 0) Then Exit Sub

        Dim isstarted As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.Started
        If (Not isstarted) Then frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.StartDraw(True)

        Dim islock As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.IsLock
        If (islock) Then frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.UnLock()

        Dim mixmode As VectorDraw.Render.GDIDraw.drawingMode = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetMixMode(VectorDraw.Render.GDIDraw.drawingMode.R2_COPYPEN)
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PushPenstyle(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripColor, 0D, Nothing)
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PushClipPerigram(New Matrix(), Nothing, VectorDraw.Geometry.GpcWrapper.ClippingOperation.Union)
        Dim i As Integer = 0
        For Each fig As vdFigure In GripSelection
            fig.DrawGrips(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender)
            i = i + 1
            'If (Not VectorDraw.WinMessages.MessageManager.IsMessageQueEmpty(IntPtr.Zero, VectorDraw.WinMessages.MessageManager.BreakMessageMethod.All)) Then Exit For
        Next fig
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PopClipPerigram()
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PopPenstyle()
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetMixMode(mixmode)
        If (islock) Then frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.Lock()
        If (Not isstarted) Then frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.EndDraw()
    End Sub

End Module
