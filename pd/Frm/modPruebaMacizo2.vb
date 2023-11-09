
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Render
Imports VectorDraw.Geometry


Module modPruebaMacizo2
    Public linea_macizo As New VectorDraw.Professional.vdFigures.vdLine
    Public gpuntos_macizo As New VectorDraw.Geometry.gPoints
    Public gpuntos_parcela As New VectorDraw.Geometry.gPoints
    Public centro As VectorDraw.Geometry.gPoint
    Public punto_macizo As VectorDraw.Geometry.gPoint
    Public punto_parcela As VectorDraw.Geometry.gPoint
    Public ancho_paralela, ancho_paralela1 As Double
    Dim puntosOriginalesMacizo() As VectorDraw.Geometry.gPoint
    Dim parce, medida, anchoCalle, anchoparcela, anchoMacizo, espacio_territorial As VectorDraw.Professional.vdFigures.vdText
    Dim puntoExtremoUno, puntoMedio, puntoMedioLineaLinderos As VectorDraw.Geometry.gPoint
    Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline

    Public Sub Dibujo_Macizo()
        '-------------------------------------
        'MACIZO. definir seleccionando puntos
        '-------------------------------------

        For Each puntoFrmMacizo As PointF In _macizo.puntos

            punto_macizo = New VectorDraw.Geometry.gPoint
            punto_macizo.x = puntoFrmMacizo.X
            punto_macizo.y = puntoFrmMacizo.Y
            punto_macizo.z = 0.0
            gpuntos_macizo.Add(punto_macizo)
        Next
        punto_macizo = New VectorDraw.Geometry.gPoint
        punto_macizo.x = _macizo.puntos(0).X
        punto_macizo.y = _macizo.puntos(0).Y
        punto_macizo.z = 0.0
        gpuntos_macizo.Add(punto_macizo)
        
        frmPruebaMacizo.BaseControl11.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
        frmPruebaMacizo.BaseControl11.ActiveDocument.ActivePenWidth = 0.01 '1.0
        frmPruebaMacizo.BaseControl11.ActiveDocument.CommandAction.CmdPolyLine(gpuntos_macizo)
        ' ==================================
        Dim J As Int32 = gpuntos_macizo.Count
    End Sub
    Public Sub Pinto_linea(ByVal puntoS As gPoint, ByVal puntoE As gPoint)
        'PONGO SOMBRA A LA PRIMER LINEA
        '==================================
        linea_macizo = New VectorDraw.Professional.vdFigures.vdLine
        linea_macizo.SetUnRegisterDocument(frmPruebaMacizo.BaseControl11.ActiveDocument)
        linea_macizo.setDocumentDefaults()
        linea_macizo.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.DarkRed)
        linea_macizo.StartPoint = puntoS 'gpuntos_macizo(0)
        linea_macizo.EndPoint = puntoE 'gpuntos_macizo(1)
        frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities.AddItem(linea_macizo)
        frmPruebaMacizo.BaseControl11.ActiveDocument.Redraw(True)

    End Sub

    Public Sub NumeroParcela(ByVal parcela As String)
        '=============Dibujo Numero de Parcela =================================================================================
        parce = New VectorDraw.Professional.vdFigures.vdText
        punto_parcela = New VectorDraw.Geometry.gPoint
        punto_parcela = gpuntos_parcela.Centroid

        If String.IsNullOrEmpty(parcela) Then Exit Sub


        parce.SetUnRegisterDocument(frmPruebaParcela.BaseControlParcela.ActiveDocument)
        parce.setDocumentDefaults()
        parce.PenColor.ColorIndex = 3
        parce.PenWidth = 0.01 '130
        parce.Height = 130
        parce.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        parce.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        parce.TextString = "Parce:" & " " & parcela
        parce.InsertionPoint = punto_parcela
        parce.Rotation = 0
        frmPruebaParcela.BaseControlParcela.ActiveDocument.CommandAction.Dispose()
        frmPruebaParcela.BaseControlParcela.ActiveDocument.CommandAction.CmdText(parce.TextString, parce.InsertionPoint, parce.Rotation)
        frmPruebaParcela.BaseControlParcela.ActiveDocument.Redraw(True)
        'frmPruebaParcela.BaseControlParcela.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        'frmPruebaParcela.BaseControlParcela.ActiveDocument.CommandAction.Zoom("S", 0.9, Nothing)
        '===========================================================================================================================


    End Sub

    '===========================================================
    Public Sub vertices()
        frmPruebaMacizo.BaseControl11.ActiveDocument.CommandAction.CmdPolyLine(gpuntos_macizo)
        lapoli = frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities(frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities.Count - 1)
        If Not lapoli.IsClockwise Then
            lapoli.Reverse()
        End If
        frmPruebaMacizo.BaseControl11.ActiveDocument.Redraw(True)
        frmPruebaMacizo.BaseControl11.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        frmPruebaMacizo.BaseControl11.ActiveDocument.CommandAction.Zoom("S", 0.9, Nothing)

        gpuntos_macizo.RemoveAll()

        
    End Sub
    '========================================================
    '=============Dibuja las Paralelas=====================================================================================
    Public Sub DIBUJAME_LA_PARALELA1(ByVal st1 As gPoint, ByVal et1 As gPoint, ByVal ancho As Double, ByVal nombre_calle As String, ByVal espacio As Integer)
        Static pasadas As Integer
        pasadas = pasadas + 1
        Dim fuente = New FontFamily("Arial")
        If espacio = 1 Then

            '=============Dibuja las Paralelas=====================================================================================
            frmPruebaMacizo.BaseControl11.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
            frmPruebaMacizo.BaseControl11.ActiveDocument.ActivePenWidth = 0.01 '1.3
            linea_macizo = New VectorDraw.Professional.vdFigures.vdLine
            linea_macizo.SetUnRegisterDocument(frmPruebaMacizo.BaseControl11.ActiveDocument)
            linea_macizo.setDocumentDefaults()
            linea_macizo.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
            linea_macizo.StartPoint = st1
            linea_macizo.EndPoint = et1
            Dim lineasOffseteadas As VectorDraw.Professional.vdCollections.vdCurves
            lineasOffseteadas = linea_macizo.getOffsetCurve(ancho)
            frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities.AddItem(lineasOffseteadas(0))
            '======================================================================================================================
            '======================================================================================================================

            Dim gpuntosSegmentoDividido As New VectorDraw.Geometry.gPoints
            Dim distancia As Double = VectorDraw.Geometry.gPoint.Distance2D(st1, et1)
            puntoMedio = VectorDraw.Geometry.gPoint.MidPoint(st1, et1)


            '=============Dibujo Nombre de la Calle=================================================================================
            medida = New VectorDraw.Professional.vdFigures.vdText
            medida.SetUnRegisterDocument(frmPruebaMacizo.BaseControl11.ActiveDocument)
            medida.setDocumentDefaults()
            medida.PenColor.ColorIndex = 1
            medida.PenWidth = 0.01 '2.3

            medida.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
            medida.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            medida.TextString = nombre_calle
            medida.Height = 2.5
            medida.Rotation = Math.Round(VectorDraw.Geometry.Globals.GetAngle(st1, et1), 2) '+ VectorDraw.Geometry.Globals.DegreesToRadians(90) 'mirar
            If medida.Rotation > 3.0 And medida.Rotation < 3.5 Then
                medida.Rotation = VectorDraw.Geometry.Globals.GetAngle(st1, et1) + VectorDraw.Geometry.Globals.DegreesToRadians(180) 'mirar
                medida.InsertionPoint = puntoMedio.Polar(medida.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho / 2))
            ElseIf medida.Rotation = 4.71 Then
                medida.Rotation = medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(180)
                medida.InsertionPoint = puntoMedio.Polar(medida.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho / 2))
            Else
                medida.InsertionPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho) / 2)
            End If
            ' medida.InsertionPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho) / 2)
            frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities.AddItem(medida)
            '=====================Cargo las variables para Marcelo==============================================================
            modFuncionesMacizo.CargoEstructuraMacizoNombreCalle(medida.InsertionPoint, medida.Rotation, nombre_calle, fuente)
            '===================================================================================================================

            '
            '====================== Guardo en la Base de datos==================================================================
            modDatosMacizo.Carga_EntidadesCalle(st1, et1, medida.InsertionPoint, medida.Rotation, nombre_calle, 1)
            '===================================================================================================================


            'mh: 8/4/13
            'Dim t As Object = VectorDraw.Geometry.Globals.RadiansToDegrees(medida.Rotation)

            '===========================================================================================================================
            anchoCalle = New VectorDraw.Professional.vdFigures.vdText
            anchoCalle.SetUnRegisterDocument(frmPruebaMacizo.BaseControl11.ActiveDocument)
            anchoCalle.setDocumentDefaults()
            anchoCalle.PenColor.ColorIndex = 1
            anchoCalle.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
            anchoCalle.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            anchoCalle.PenWidth = 0.01 '2.3
            anchoCalle.Height = 2.5
            'mh:<----------------------------------------------------------------------------------------8/4/13
            anchoCalle.TextString = ancho.ToString
            anchoCalle.Rotation = Math.Round(VectorDraw.Geometry.Globals.GetAngle(st1, et1), 2) '+ VectorDraw.Geometry.Globals.DegreesToRadians(90) 'mirar
            If anchoCalle.Rotation > 3.0 And anchoCalle.Rotation < 3.5 Then
                anchoCalle.InsertionPoint = st1.Polar(anchoCalle.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho / 2))
            Else
                anchoCalle.InsertionPoint = st1.Polar(anchoCalle.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho) / 2)
            End If
            Select Case anchoCalle.Rotation
                Case 0 To 1.56
                    anchoCalle.Rotation = anchoCalle.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90)
                Case 1.57 To 3.13
                    'If st1.y < et1.y Then
                    anchoCalle.Rotation = anchoCalle.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90)
                    'Else
                    '    anchoCalle.Rotation = anchoCalle.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90)
                    'End If
                Case 3.14
                    anchoCalle.Rotation = anchoCalle.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90)
                Case 3.15 To 4.7
                    anchoCalle.Rotation = anchoCalle.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90)
                Case 4.71
                    anchoCalle.Rotation = anchoCalle.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90)
                Case 4.72 To 6.28
                    anchoCalle.Rotation = anchoCalle.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90)
            End Select
            'mh:<----------------------------------------------------------------------------------------8/4/13
            'anchoCalle.InsertionPoint = st1.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho) / 2)
            frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities.AddItem(anchoCalle)
            '=====================Cargo las variables para Marcelo========================================================================
            modFuncionesMacizo.CargoEstructuraMacizoAnchoCalle(anchoCalle.InsertionPoint, anchoCalle.Rotation, ancho, fuente)
            '=============================================================================================================================
            '=============================================================================================================================
            '====================== Guardo en la Base de datos==================================================================
            modDatosMacizo.Carga_EntidadesCalle(st1, et1, anchoCalle.InsertionPoint, anchoCalle.Rotation, anchoCalle.TextString, 2)
            '===================================================================================================================






            anchoMacizo = New VectorDraw.Professional.vdFigures.vdText
            anchoMacizo.SetUnRegisterDocument(frmPruebaMacizo.BaseControl11.ActiveDocument)
            anchoMacizo.setDocumentDefaults()
            anchoMacizo.PenColor.ColorIndex = 1
            anchoMacizo.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
            anchoMacizo.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            anchoMacizo.PenWidth = 0.01 '2.3
            anchoMacizo.Height = 2.5
            anchoMacizo.TextString = "S/C " & Format(VectorDraw.Geometry.gPoint.Distance2D(st1, et1), "##,##0.00").ToString
            anchoMacizo.Rotation = VectorDraw.Geometry.Globals.GetAngle(st1, et1) '+ VectorDraw.Geometry.Globals.DegreesToRadians(0) 'mirar

            If anchoMacizo.Rotation > 3.0 And anchoMacizo.Rotation < 3.5 Then
                anchoMacizo.Rotation = VectorDraw.Geometry.Globals.GetAngle(st1, et1) + VectorDraw.Geometry.Globals.DegreesToRadians(180) 'mirar
                'anchoMacizo.InsertionPoint = puntoMedio.Polar(anchoMacizo.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho / 6))
                anchoMacizo.InsertionPoint = puntoMedio.Polar(anchoMacizo.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho / 6))
            Else
                anchoMacizo.InsertionPoint = puntoMedio.Polar(anchoMacizo.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho) / 6)
            End If





            'anchoMacizo.InsertionPoint = puntoMedio.Polar(anchoMacizo.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho) / 6)
            frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities.AddItem(anchoMacizo)
            '=============================================================================================================================

            '=====================Cargo las variables para Marcelo==============================================================
            modFuncionesMacizo.CargoEstructuraMacizoMedidaCalle(anchoMacizo.InsertionPoint, anchoMacizo.Rotation, anchoMacizo.TextString, fuente)
            '===================================================================================================================
            '====================== Guardo en la Base de datos==================================================================
            modDatosMacizo.Carga_EntidadesCalle(st1, et1, anchoMacizo.InsertionPoint, anchoMacizo.Rotation, anchoMacizo.TextString, 3)
            '===================================================================================================================


            If pasadas = 1 Then
                'mh:
                '====================== Guardo en la Base de datos el identificador del macizo (nomenclatura sin la pl)===================
                Dim textoIdMz As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
                textoIdMz.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                textoIdMz.setDocumentDefaults()

                Dim textoNomenclatura As String = "Circ: " & nomenclatura.Circunscripcion.ToString & " "
                If Not nomenclatura.Seccion = "" Then
                    textoNomenclatura = textoNomenclatura & "Sec: " & nomenclatura.Seccion & " "
                End If
                If Not nomenclatura.Chacra = "" Then
                    textoNomenclatura = textoNomenclatura & "Ch: " & nomenclatura.Chacra & " "
                End If
                If Not nomenclatura.ChacraLetra = "" Then
                    textoNomenclatura = textoNomenclatura & nomenclatura.ChacraLetra & " "
                End If
                If Not nomenclatura.Quinta = "" Then
                    textoNomenclatura = textoNomenclatura & "Qta: " & nomenclatura.Quinta & " "
                End If
                If Not nomenclatura.QuintaLetra = "" Then
                    textoNomenclatura = textoNomenclatura & nomenclatura.QuintaLetra & " "
                End If
                If Not nomenclatura.Fraccion = "" Then
                    textoNomenclatura = textoNomenclatura & "Fr: " & nomenclatura.Fraccion & " "
                End If
                If Not nomenclatura.FraccionLetra = "" Then
                    textoNomenclatura = textoNomenclatura & nomenclatura.FraccionLetra & " "
                End If
                If Not nomenclatura.Manzana = "" Then
                    textoNomenclatura = textoNomenclatura & "Mz: " & nomenclatura.Manzana & " "
                End If
                If Not nomenclatura.ManzanaLetra = "" Then
                    textoNomenclatura = textoNomenclatura & nomenclatura.ManzanaLetra & " "
                End If

                textoIdMz.TextString = textoNomenclatura
                textoIdMz.ToolTip = "Tipo Entidad: Identificador Macizo, id: .."
                textoIdMz.Style = estiloMz1
                textoIdMz.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                textoIdMz.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                Dim puntoIn = New VectorDraw.Geometry.gPoint
                puntoIn.x = _macizo.puntos(0).X + 60
                puntoIn.y = _macizo.puntos(0).Y + 55
                textoIdMz.InsertionPoint = puntoIn
                textoIdMz.Rotation = 0
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoIdMz)

                modDatosMacizo.Carga_EntidadesCalle(st1, et1, textoIdMz.InsertionPoint, textoIdMz.Rotation, textoNomenclatura, 4)
                '=========================================================================================================================

            End If


        Else
            Dim distancia As Double = VectorDraw.Geometry.gPoint.Distance2D(st1, et1)
            puntoMedio = VectorDraw.Geometry.gPoint.MidPoint(st1, et1)
            '=============Dibujo ESPACIO TERRITORIAL =================================================================================
            espacio_territorial = New VectorDraw.Professional.vdFigures.vdText
            espacio_territorial.SetUnRegisterDocument(frmPruebaMacizo.BaseControl11.ActiveDocument)
            espacio_territorial.setDocumentDefaults()
            espacio_territorial.PenColor.ColorIndex = 1
            espacio_territorial.PenWidth = 0.01 '2.3

            espacio_territorial.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
            espacio_territorial.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            espacio_territorial.TextString = nombre_calle
            espacio_territorial.Height = 2.5
            espacio_territorial.Rotation = VectorDraw.Geometry.Globals.GetAngle(st1, et1) '+ VectorDraw.Geometry.Globals.DegreesToRadians(180) 'mirar
            espacio_territorial.InsertionPoint = puntoMedio.Polar(espacio_territorial.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho) / 2)
            frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities.AddItem(espacio_territorial)
            '===========================================================================================================================

            '=====================Cargo las variables para Marcelo==============================================================
            modFuncionesMacizo.CargoEstructuraMacizoNombreCalle(espacio_territorial.InsertionPoint, espacio_territorial.Rotation, nombre_calle, fuente)
            '===================================================================================================================


            '=============================================================================================================================
            anchoMacizo = New VectorDraw.Professional.vdFigures.vdText
            anchoMacizo.SetUnRegisterDocument(frmPruebaMacizo.BaseControl11.ActiveDocument)
            anchoMacizo.setDocumentDefaults()
            anchoMacizo.PenColor.ColorIndex = 1
            anchoMacizo.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
            anchoMacizo.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            anchoMacizo.Height = 2.5
            anchoMacizo.PenWidth = 0.01 '2.3
            anchoMacizo.TextString = "S/C " & Format(VectorDraw.Geometry.gPoint.Distance2D(st1, et1), "##,##0.00").ToString
            anchoMacizo.Rotation = VectorDraw.Geometry.Globals.GetAngle(st1, et1) + VectorDraw.Geometry.Globals.DegreesToRadians(180) 'mirar
            anchoMacizo.InsertionPoint = puntoMedio.Polar(espacio_territorial.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(ancho) / 6)
            frmPruebaMacizo.BaseControl11.ActiveDocument.ActiveLayOut.Entities.AddItem(anchoMacizo)
            '=============================================================================================================================
            '=====================Cargo las variables para Marcelo==============================================================
            modFuncionesMacizo.CargoEstructuraMacizoNombreCalle(anchoMacizo.InsertionPoint, anchoMacizo.Rotation, anchoMacizo.TextString, fuente)
            '===================================================================================================================

        End If

        frmPruebaMacizo.BaseControl11.ActiveDocument.Redraw(True)
        frmPruebaMacizo.BaseControl11.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        frmPruebaMacizo.BaseControl11.ActiveDocument.CommandAction.Zoom("S", 0.9, Nothing)
    End Sub
    Public Sub DIBUJAME_LA_PARCELA()
        For Each puntoParcela As PointF In _parcela.puntos
            punto_parcela = New VectorDraw.Geometry.gPoint
            punto_parcela.x = puntoParcela.X
            punto_parcela.y = puntoParcela.Y
            punto_parcela.z = 0.0
            gpuntos_parcela.Add(punto_parcela)
        Next
        punto_parcela = New VectorDraw.Geometry.gPoint
        punto_parcela.x = _parcela.puntos(0).X
        punto_parcela.y = _parcela.puntos(0).Y
        punto_parcela.z = 0.0
        gpuntos_parcela.Add(punto_parcela)

        frmPruebaParcela.BaseControlParcela.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
        frmPruebaParcela.BaseControlParcela.ActiveDocument.ActivePenWidth = 0.01 '1.8
        frmPruebaParcela.BaseControlParcela.ActiveDocument.CommandAction.CmdPolyLine(gpuntos_parcela)

        frmPruebaParcela.t_superficie.Text = FormatNumber(gpuntos_parcela.Area, 2)
        '=============Distancia de los lados de la parcela===================================================

        Dim ii As Integer
        Dim sst1, eet1 As New VectorDraw.Geometry.gPoint
        Dim anchoo As Double = 15.0
        Dim puntoMedioo As New VectorDraw.Geometry.gPoint
        For ii = 0 To gpuntos_parcela.Count - 2
            sst1 = gpuntos_parcela.Item(ii)
            eet1 = gpuntos_parcela(ii + 1)
            puntoMedioo = VectorDraw.Geometry.gPoint.MidPoint(sst1, eet1)
            '///////////


            anchoparcela = New VectorDraw.Professional.vdFigures.vdText
            anchoparcela.SetUnRegisterDocument(frmPruebaParcela.BaseControlParcela.ActiveDocument)
            anchoparcela.setDocumentDefaults()

            '//////////


            anchoparcela.PenColor.ColorIndex = 1
            anchoparcela.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
            anchoparcela.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            anchoparcela.Height = 1.8
            anchoparcela.TextString = Format(VectorDraw.Geometry.gPoint.Distance2D(sst1, eet1), "##,##0.00").ToString
            anchoparcela.Rotation = VectorDraw.Geometry.Globals.GetAngle(sst1, eet1) '+ VectorDraw.Geometry.Globals.DegreesToRadians(180) 'mirar
            'MsgBox(anchoparcela.Rotation)


            If anchoparcela.Rotation < 0 Then
                anchoparcela.Rotation = VectorDraw.Geometry.Globals.GetAngle(sst1, eet1) + VectorDraw.Geometry.Globals.DegreesToRadians(180)
                anchoparcela.InsertionPoint = puntoMedioo.Polar(anchoparcela.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), anchoo / 4)
            Else
                anchoparcela.InsertionPoint = puntoMedioo.Polar(anchoparcela.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), anchoo / -4)

            End If

            frmPruebaParcela.BaseControlParcela.ActiveDocument.ActiveLayOut.Entities.AddItem(anchoparcela)

        Next

        '=====================================================================================================

        frmPruebaParcela.BaseControlParcela.ActiveDocument.Redraw(True)
        frmPruebaParcela.BaseControlParcela.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        frmPruebaParcela.BaseControlParcela.ActiveDocument.CommandAction.Zoom("S", 0.9, Nothing)


    End Sub

End Module
