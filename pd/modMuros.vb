
Imports VectorDraw.Professional.vdCollections


Module modMuros

    Dim puntosOriginalesMuro() As VectorDraw.Geometry.gPoint

    Public Sub definirMuroPorPuntos()
        '-------------------------------------
        'MURO. definir seleccionando puntos
        '-------------------------------------
        Dim elOsnap As VectorDraw.Geometry.OsnapMode = New VectorDraw.Geometry.OsnapMode
        elOsnap = VectorDraw.Geometry.OsnapMode.END + VectorDraw.Geometry.OsnapMode.INTERS + VectorDraw.Geometry.OsnapMode.CEN
        frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = elOsnap
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Red)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01 '0.15


        'DIBUJAR LA POLILINEA.......................................................................................................................
        Dim salir As Boolean, ret As VectorDraw.Actions.StatusCode
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar PUNTO DEL MURO")
        Dim i As Integer = 0
        Do While salir = False
            ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
            If ret = VectorDraw.Actions.StatusCode.Success Then
                gpuntos.Add(punto)
                If i > 0 Then
                    If i = 1 Then
                        'If gpuntos(i) = gpuntos(0) Then
                        salir = True
                        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
                        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(gpuntos)
                        'frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                    End If
                End If
                i = i + 1
            Else
                salir = True
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
                Exit Sub
            End If
        Loop

        'NUMERAR LOS VERTICES DE LA POLILINEA..................................................................................................................
        'numerarVerticesMuro(lapoli)
        'FIN DE NUMERAR LOS VERTICES..........................................................................................................................

        '-------------------------------------------------------
        ' Uso de la estructura stMuros, con la variable _muro
        '-------------------------------------------------------
        Dim k As Integer
        For Each puntoVertice As VectorDraw.Geometry.gPoint In gpuntos 'lapoli.VertexList
            k = k + 1

            If k = 1 Then
                ReDim _muro.puntosEjeParcela(0)
                ReDim puntosOriginalesMuro(0)
                puntosOriginalesMuro(0) = New VectorDraw.Geometry.gPoint
                _muro.puntosEjeParcela(0).X = puntoVertice.x
                puntosOriginalesMuro(0).x = puntoVertice.x
                _muro.puntosEjeParcela(0).Y = puntoVertice.y
                puntosOriginalesMuro(0).y = puntoVertice.y
            ElseIf k <= gpuntos.Count Then
                ReDim Preserve _muro.puntosEjeParcela(k - 1)
                ReDim Preserve puntosOriginalesMuro(k - 1)
                puntosOriginalesMuro(k - 1) = New VectorDraw.Geometry.gPoint
                _muro.puntosEjeParcela(k - 1).X = puntoVertice.x
                puntosOriginalesMuro(k - 1).x = puntoVertice.x
                _muro.puntosEjeParcela(k - 1).Y = puntoVertice.y
                puntosOriginalesMuro(k - 1).y = puntoVertice.y
            End If
        Next

        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)

        '-------------------------------------------------------
        ' Uso de la estructura stMuros, con la variable _muro
        '-------------------------------------------------------
        'Dim aviso As String = ""
        'For i = 0 To _muro.puntosEjeParcela.Count - 1
        '    aviso = aviso & String.Format("Punto {0} --> X: {1}, Y: {2}", i, _muro.puntosEjeParcela(i).X, _muro.puntosEjeParcela(i).Y) & vbCrLf
        'Next
        'MsgBox(aviso, MsgBoxStyle.Information, "Puntos guardados en la estructura stMuros")
        '------------------------------------------------------------
        ' fin Uso de la estructura stMacizo, con la variable _macizo
        '------------------------------------------------------------

        frmMuros.ShowDialog() 'agregar que pasa si cancela...

        '-------------------------------------------------------
        ' vuelve la estructura _muro cargada...
        '-------------------------------------------------------
        'For i = 0 To _muro.puntosMuro.Count - 1
        '    aviso = aviso & String.Format("Espesor {0} --> {1}", i, _muro.puntosMuro(i) & vbCrLf)
        'Next
        'MsgBox(aviso)

        modMacizo.agregarLayersPlanoDigital()
        dibujarMuroPlanoDigital()

    End Sub

    Private Sub dibujarMuroPlanoDigital()
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Green)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01 '0.15

        Dim linea1, linea2, lineaCierre1, lineaCierre2, lineaCota, lineaEje As VectorDraw.Professional.vdFigures.vdLine
        Dim anguloEje As Double = Math.Round(puntosOriginalesMuro(0).GetAngle(puntosOriginalesMuro(1)), 2)
        Dim puntoExtremoUno, puntoExtremoDos, puntoextremoTres, puntoMedio1, puntoMedio2, puntoMedio3, ptoCota As VectorDraw.Geometry.gPoint
        Dim txMedida As VectorDraw.Professional.vdFigures.vdText

        linea1 = New VectorDraw.Professional.vdFigures.vdLine()
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        'linea1.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
        'linea1.LineTypeScale = 4.0
        linea1.PenColor.ColorIndex = 1
        linea1.PenWidth = 0.0001
        linea1.StartPoint = puntosOriginalesMuro(0).Polar(anguloEje + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), CDbl(_muro.puntosMuro(1)) / 1)
        linea1.EndPoint = puntosOriginalesMuro(1).Polar(anguloEje + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), CDbl(_muro.puntosMuro(2)) / 1)
        linea1.ToolTip = "Tipo Entidad: muro, id: " & idEntidad.ToString
        'Tipo Entidad: Macizo, id: " & idEntidadBuscar.ToString
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)

        linea2 = New VectorDraw.Professional.vdFigures.vdLine()
        linea2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea2.setDocumentDefaults()
        'linea2.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
        'linea2.LineTypeScale = 4.0
        linea2.PenColor.ColorIndex = 1
        linea2.PenWidth = 0.0001
        linea2.StartPoint = puntosOriginalesMuro(0).Polar(anguloEje - VectorDraw.Geometry.Globals.DegreesToRadians(90.0), CDbl(_muro.puntosMuro(0)) / 1)
        linea2.EndPoint = puntosOriginalesMuro(1).Polar(anguloEje - VectorDraw.Geometry.Globals.DegreesToRadians(90.0), CDbl(_muro.puntosMuro(3)) / 1)
        linea2.ToolTip = "Tipo Entidad: muro, id: " & idEntidad.ToString
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea2)

        lineaCierre1 = New VectorDraw.Professional.vdFigures.vdLine()
        lineaCierre1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        lineaCierre1.setDocumentDefaults()
        'linea2.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
        'linea2.LineTypeScale = 4.0
        lineaCierre1.PenColor.ColorIndex = 1
        lineaCierre1.PenWidth = 0.0001
        lineaCierre1.StartPoint = linea1.StartPoint
        lineaCierre1.EndPoint = linea2.StartPoint
        lineaCierre1.ToolTip = "Tipo Entidad: muro, id: " & idEntidad.ToString
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineaCierre1)

        lineaCierre2 = New VectorDraw.Professional.vdFigures.vdLine()
        lineaCierre2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        lineaCierre2.setDocumentDefaults()
        'linea2.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
        'linea2.LineTypeScale = 4.0
        lineaCierre2.PenColor.ColorIndex = 1
        lineaCierre2.PenWidth = 0.0001
        lineaCierre2.StartPoint = linea1.EndPoint
        lineaCierre2.EndPoint = linea2.EndPoint
        lineaCierre2.ToolTip = "Tipo Entidad: muro, id: " & idEntidad.ToString
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineaCierre2)

        Dim gpuntosSegmentoDividido As New VectorDraw.Geometry.gPoints
        gpuntosSegmentoDividido = lineaCierre1.Divide(2)
        puntoExtremoUno = gpuntosSegmentoDividido(0)
        puntoMedio1 = gpuntosSegmentoDividido(1)

        Dim gpuntosSegmentoDividido2 As New VectorDraw.Geometry.gPoints
        gpuntosSegmentoDividido2 = lineaCierre2.Divide(2)
        puntoExtremoDos = gpuntosSegmentoDividido2(0)
        puntoMedio2 = gpuntosSegmentoDividido2(1)

        lineaEje = New VectorDraw.Professional.vdFigures.vdLine()
        lineaEje.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        lineaEje.setDocumentDefaults()
        lineaEje.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
        'linea2.LineTypeScale = 4.0
        lineaEje.PenColor.ColorIndex = 1
        lineaEje.PenWidth = 0.0001
        lineaEje.StartPoint = puntoMedio1
        lineaEje.EndPoint = puntoMedio2
        lineaEje.ToolTip = "Tipo Entidad: muro, id: " & idEntidad.ToString
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineaEje)

        Dim gpuntosSegmentoDividido3 As New VectorDraw.Geometry.gPoints
        gpuntosSegmentoDividido3 = lineaEje.Divide(2)
        puntoextremoTres = gpuntosSegmentoDividido3(0)
        puntoMedio3 = gpuntosSegmentoDividido3(1)

        lineaCota = New VectorDraw.Professional.vdFigures.vdLine()
        lineaCota.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        lineaCota.setDocumentDefaults()
        'linea2.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
        'linea2.LineTypeScale = 4.0
        lineaCota.PenColor.ColorIndex = 1
        lineaCota.PenWidth = 0.0001
        lineaCota.StartPoint = puntoMedio3.Polar(anguloEje - VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 1.0)
        lineaCota.EndPoint = puntoMedio3.Polar(anguloEje + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 2.5)
        'lineaCota.ToolTip = "Tipo Entidad: ancho muro, id: " & idEntidad.ToString
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineaCota)

        txMedida = New VectorDraw.Professional.vdFigures.vdText
        txMedida.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        txMedida.setDocumentDefaults()
        txMedida.PenColor.ColorIndex = 2
        txMedida.TextString = Format(Math.Round(_muro.anchoMuro, 2), "##,##0.00").ToString 'Format (distancia, "##,##0.00").ToString
        txMedida.Rotation = anguloEje - VectorDraw.Geometry.Globals.DegreesToRadians(90.0)
        txMedida.InsertionPoint = lineaCota.EndPoint.Polar(VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 1.0)
        txMedida.Style = estiloAnchoMuro4
        'txMedida.ToolTip = "Tipo Entidad: Ancho muro, id: " & idEntidad.ToString

        'txMedida.Rotation = anguloEje
        'anguloEje = VectorDraw.Geometry.Globals.RadiansToDegrees(anguloEje)
        'If anguloEje > 90 And anguloEje <= 135 Then
        '    anguloEje = anguloEje + 180
        '    'medida.InsertionPoint = puntoMedio.Polar(angulo + VectorDraw.Geometry.Globals.DegreesToRadians(90), -1.0)
        'ElseIf anguloEje = 90 Then
        '    'medida.InsertionPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), 1.0)
        'ElseIf anguloEje = 180 Then
        '    anguloEje = 0.0
        '    'medida.InsertionPoint = puntoMedio.Polar(angulo - VectorDraw.Geometry.Globals.DegreesToRadians(90), 1.0)
        '    txMedida.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(0.0)
        'ElseIf anguloEje > 180 And anguloEje < 270 Then
        '    anguloEje = anguloEje + 180
        '    'medida.InsertionPoint = puntoMedio.Polar(angulo + VectorDraw.Geometry.Globals.DegreesToRadians(90), -1.0)
        '    txMedida.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(anguloEje)
        'ElseIf anguloEje > 135 And anguloEje < 180 Then
        '    anguloEje = anguloEje + 180
        '    'medida.InsertionPoint = puntoMedio.Polar(angulo - VectorDraw.Geometry.Globals.DegreesToRadians(90), -1.5)
        '    txMedida.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(anguloEje)
        'Else
        '    'medida.InsertionPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), 1.0)
        'End If

        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(txMedida)

        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("S", 0.8, Nothing)

        modDatosDB.agregarDatosMacizoBD_anchoMuro(txMedida)
        txMedida.ToolTip = "Tipo Entidad: Ancho muro, id: " & _muro.idTxtAnchoMuro
        lineaCota.ToolTip = "Tipo Entidad: ancho muro, id: " & _muro.idTxtAnchoMuro

    End Sub

    Public Sub numerarVerticesMuro(ByVal lapoli As VectorDraw.Professional.vdFigures.vdPolyline)
        Dim nuevoPunto As VectorDraw.Geometry.gPoint
        Dim elTexto, medida As VectorDraw.Professional.vdFigures.vdText
        Dim k, indice As Integer
        Dim distancia As Double

        For Each puntoVertice As VectorDraw.Geometry.gPoint In lapoli.VertexList
            k = k + 1

            nuevoPunto = New VectorDraw.Geometry.gPoint
            nuevoPunto = puntoVertice.Polar(VectorDraw.Geometry.Globals.DegreesToRadians(45.0), 0.75)

            elTexto = New VectorDraw.Professional.vdFigures.vdText
            elTexto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            elTexto.setDocumentDefaults()
            elTexto.PenColor.ColorIndex = 2
            elTexto.TextString = "Vertice: " & k.ToString
            If k = lapoli.VertexList.Count Then
                elTexto.InsertionPoint = New VectorDraw.Geometry.gPoint(nuevoPunto.x - 5, nuevoPunto.y, nuevoPunto.z)
            Else
                elTexto.InsertionPoint = New VectorDraw.Geometry.gPoint(nuevoPunto)
            End If
            elTexto.Height = 0.5
            frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "Verdana"

            'elTexto.TextLine = VectorDraw.Render.grTextStyleExtra.TextLineFlags.UnderLine
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(elTexto)
            'nudAngulo.Value = VectorDraw.Geometry.Globals.RadiansToDegrees(elTexto.Rotation)
            indice = lapoli.SegmentIndexFromPoint(puntoVertice, 0.0)
            If k > 1 Then
                distancia = lapoli.GetFigureAtSegmentIndex(k - 2).Length
                medida = New VectorDraw.Professional.vdFigures.vdText
                medida.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                medida.setDocumentDefaults()
                medida.PenColor.ColorIndex = 2
                medida.TextString = Format(distancia, "##,##0.00").ToString

                If k = lapoli.VertexList.Count Then
                    'ultimo punto
                    nuevoPunto = New VectorDraw.Geometry.gPoint(VectorDraw.Geometry.gPoint.MidPoint(lapoli.VertexList(k - 2), lapoli.VertexList(lapoli.VertexList.Count - 1)))
                Else
                    'un punto cualquiera, por lo tanto existe el punto anterior.
                    nuevoPunto = New VectorDraw.Geometry.gPoint(VectorDraw.Geometry.gPoint.MidPoint(lapoli.VertexList(k - 1), lapoli.VertexList(k - 2)))
                End If

                medida.InsertionPoint = nuevoPunto
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(medida)
            End If
        Next
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    'Public Sub definirMacizoPorPolilinea()
    '    '------------------------------------------
    '    'MACIZO. definir por seleccion de polilinea
    '    '------------------------------------------
    '    Dim Parray As Object

    '    frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar POLILINEA (boton derecho del mouse para finalizar)")
    '    Dim seleccion As vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection

    '    frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

    '    If seleccion Is Nothing Then
    '        MsgBox("No hay seleccion")
    '        Exit Sub
    '    End If
    '    If seleccion.Count = 0 Then
    '        MsgBox("No hay seleccion")
    '        Exit Sub
    '    End If
    '    If seleccion.Count > 1 Then
    '        MsgBox("Hay mas de una entidad seleccionada...")
    '        Exit Sub
    '    End If

    '    If seleccion.Item(0)._TypeName = "vdPolyline" Then
    '        Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
    '        lapoli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
    '        lapoli.setDocumentDefaults()
    '        lapoli = CType(seleccion.Item(0), VectorDraw.Professional.vdFigures.vdPolyline)
    '        MsgBox("Sentido horario: " & lapoli.IsClockwise.ToString, vbInformation, "prueba")
    '        If Not lapoli.IsClockwise Then
    '            lapoli.Reverse()
    '        End If
    '        Parray = lapoli.VertexList
    '        'Dim PolAbiertaCerrada As VectorDraw.Professional.Constants.VdConstPlineFlag = lapoli.Flag
    '        'If PolAbiertaCerrada = 0 Then 'abierta
    '        '    acotarPolilineas(i, Arriba, Abajo, Parray, True, Lados, Angulos)
    '        'Else
    '        '    acotarPolilineas(i, Arriba, Abajo, Parray, False, Lados, Angulos)
    '        'End If
    '        lapoli.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Red)
    '        lapoli.PenWidth = 0.25
    '        'vdf.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lapoli)


    '        '..................................................................................................
    '        Dim designacionMacizo As String = InputBox("Ingresar designacion de macizo", "Atributos de Macizo")
    '        If Trim(designacionMacizo) = "" Then
    '            MsgBox("No se ingreso designacion.")
    '        Else
    '            agregarDatosMacizoBD(designacionMacizo, lapoli, "macizo")
    '            Dim boxing As VectorDraw.Professional.vdObjects.vdPrimary
    '            boxing = lapoli
    '            pegarDatosEntidad(boxing, idEntidad)
    '        End If
    '        '..................................................................................................


    '        lapoli.Dispose()
    '        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
    '        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    '    End If

    'End Sub

End Module
