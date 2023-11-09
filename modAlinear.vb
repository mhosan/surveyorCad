Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects

Module modAlinear

    Public Sub alinear()
        '=========================================================================
        ' comando alinear
        '=========================================================================
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        'MsgBox("Seleccionar entidades a alinear. Botón derecho = finalizar selección y continuar con el comando.")
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar entidades a alinear, botón derecho = finalizar...")
        Dim seleccion As vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

        If seleccion Is Nothing Then
            Exit Sub
        End If

        If seleccion.Count = 0 Then
            Exit Sub
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccione punto origen y destino UNO...")
        Dim linea1 As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint()
        If linea1.StartPoint.x = 0.0 And linea1.StartPoint.y = 0.0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
            Exit Sub
        End If
        linea1.EndPoint = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint()
        If linea1.EndPoint.x = 0.0 And linea1.EndPoint.x = 0.0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
            Exit Sub
        End If
        linea1.PenColor.ColorIndex = 2
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccione punto origen y destino DOS...")
        Dim linea2 As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        linea2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea2.setDocumentDefaults()
        linea2.StartPoint = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint()
        linea2.EndPoint = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint()
        linea2.PenColor.ColorIndex = 2
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea2)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

        frmPpal.VdF.BaseControl.ActiveDocument.PointStyleMode = 36
        frmPpal.VdF.BaseControl.ActiveDocument.PointStyleSize = 5.2

        Dim pOri1 As VectorDraw.Professional.vdFigures.vdPoint = New VectorDraw.Professional.vdFigures.vdPoint
        pOri1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        pOri1.setDocumentDefaults()
        pOri1.InsertionPoint = linea1.StartPoint
        Dim pO1 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        pO1.x = pOri1.InsertionPoint.x
        pO1.y = pOri1.InsertionPoint.y
        pO1.z = pOri1.InsertionPoint.z
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(pO1)


        Dim pDes1 As VectorDraw.Professional.vdFigures.vdPoint = New VectorDraw.Professional.vdFigures.vdPoint
        pDes1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        pDes1.setDocumentDefaults()
        pDes1.InsertionPoint = linea1.EndPoint
        Dim pD1 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        pD1.x = pDes1.InsertionPoint.x
        pD1.y = pDes1.InsertionPoint.y
        pD1.z = pDes1.InsertionPoint.z
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(pD1)


        Dim pOri2 As VectorDraw.Professional.vdFigures.vdPoint = New VectorDraw.Professional.vdFigures.vdPoint
        pOri2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        pOri2.setDocumentDefaults()
        pOri2.InsertionPoint = linea2.StartPoint
        Dim pO2 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        pO2.x = pOri2.InsertionPoint.x
        pO2.y = pOri2.InsertionPoint.y
        pO2.z = pOri2.InsertionPoint.z
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(pO2)


        Dim pDes2 As VectorDraw.Professional.vdFigures.vdPoint = New VectorDraw.Professional.vdFigures.vdPoint
        pDes2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        pDes2.setDocumentDefaults()
        pDes2.InsertionPoint = linea2.EndPoint
        Dim pD2 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        pD2.x = pDes2.InsertionPoint.x
        pD2.y = pDes2.InsertionPoint.y
        pD2.z = pDes2.InsertionPoint.z
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(pD2)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)


        Dim anguloDestinoR As Double = VectorDraw.Geometry.Globals.GetAngle(pD2, pD1)
        Dim anguloDestinoD As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(anguloDestinoR)
        If anguloDestinoD >= 180 Then
            anguloDestinoD = anguloDestinoD - 180
        End If
        anguloDestinoR = VectorDraw.Geometry.Globals.DegreesToRadians(anguloDestinoD)


        Dim anguloOrigenR As Double = VectorDraw.Geometry.Globals.GetAngle(pO2, pO1)
        Dim anguloOrigenD As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(anguloOrigenR)
        If anguloOrigenD >= 180 Then
            anguloOrigenD = anguloOrigenD - 180
        End If
        anguloOrigenR = VectorDraw.Geometry.Globals.DegreesToRadians(anguloOrigenD)


        Dim anguloDeGiroR As Double = anguloDestinoR - anguloOrigenR
        'Dim anguloDeGiroD As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(anguloDeGiroR)
        'If anguloDeGiroD > 180 Then
        '    anguloDeGiroD = anguloDeGiroD - 180
        'End If
        'anguloDeGiroR = VectorDraw.Geometry.Globals.DegreesToRadians(anguloDeGiroD)

        For i As Integer = 0 To seleccion.Count - 1
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMove(seleccion.Item(i), pO1, pD1)
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdRotate(seleccion.Item(i), pD1, anguloDeGiroR)
        Next

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdErase(linea1)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdErase(linea2)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        ultimoComando = "Alinear"
    End Sub

End Module
