Module modUcs

    Public Sub planOriginal()
        '-----------------------------------------------------------------
        ' Girar el origen de coord. para que quede en su posicion original
        '-----------------------------------------------------------------
        Dim matrizNuevoUcsAorigen As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix
        matrizNuevoUcsAorigen.RotateZMatrix(frmPpal.VdF.BaseControl.ActiveDocument.User2WorldMatrix.Properties.Zangle)
        frmPpal.VdF.BaseControl.ActiveDocument.World2ViewMatrix = matrizNuevoUcsAorigen

        frmPpal.VdF.BaseControl.ActiveDocument.ZoomExtents()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        matrizNuevoUcsAorigen = Nothing

    End Sub

    Public Sub planUcsActual()
        '------------------------------------------------------------
        'girar el sistema de coord para que quede horizontal el eje x
        '------------------------------------------------------------
        Dim matrizOrigenANuevoUcs As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix
        Dim angulor As Double, angulod As Double

        angulor = frmPpal.VdF.BaseControl.ActiveDocument.User2WorldMatrix.Properties.Zangle
        angulod = VectorDraw.Geometry.Globals.RadiansToDegrees(angulor)
        matrizOrigenANuevoUcs.RotateZMatrix(-frmPpal.VdF.BaseControl.ActiveDocument.User2WorldMatrix.Properties.Zangle)
        'MsgBox(VectorDraw.Geometry.Globals.RadiansToDegrees(frmppal.VdF.BaseControl.ActiveDocument.User2WorldMatrix.Properties.Zangle))

        frmPpal.VdF.BaseControl.ActiveDocument.World2ViewMatrix = matrizOrigenANuevoUcs
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        frmPpal.VdF.BaseControl.ActiveDocument.ZoomExtents()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

        matrizOrigenANuevoUcs = Nothing

    End Sub

    Public Sub ucsOriginal()
        '------------------------------------------------------------------
        'Volver a ubicar el origen de coord. en su posicion y giro original
        '------------------------------------------------------------------
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.UCS("WORLD", Nothing, Nothing)
        'frmPpal.VdF.BaseControl.ActiveDocument.ZoomExtents()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)


    End Sub

    Public Sub ucsX3puntos()
        '----------------------------------------------------
        'Reubicar el origen de coord de acuerdo a tres puntos
        '----------------------------------------------------
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar punto origen")
        Dim origen As VectorDraw.Geometry.gPoint
        Dim ret As VectorDraw.Actions.StatusCode
        origen = Nothing

        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(origen)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.UCS(origen, Nothing, Nothing)
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

End Module
