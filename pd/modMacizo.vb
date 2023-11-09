
Imports VectorDraw.Professional.vdCollections


Module modMacizo

    Public copia_lapoli = New VectorDraw.Professional.vdFigures.vdPolyline
    'Dim puntosOriginalesMacizo() As VectorDraw.Geometry.gPoint
    Public bander As Boolean ' veo si cancela en frmpruebamacizo y frmpruebaparcela


    Public Sub definirMacizoPorPuntos()
        '-------------------------------------
        'MACIZO. definir seleccionando puntos
        '-------------------------------------

        'preparar entorno para dibujar........................................................................................
        Dim elOsnap As VectorDraw.Geometry.OsnapMode = New VectorDraw.Geometry.OsnapMode
        elOsnap = VectorDraw.Geometry.OsnapMode.END + VectorDraw.Geometry.OsnapMode.INTERS + VectorDraw.Geometry.OsnapMode.CEN
        frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = elOsnap
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Red)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01 '0.25

        'dibujar la polilinea.................................................................................................
        Dim salir As Boolean
        Dim ret As VectorDraw.Actions.StatusCode
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar PUNTO DEL MACIZO")
        Dim i As Integer = 0
        Do While salir = False
            ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
            If ret = VectorDraw.Actions.StatusCode.Success Then
                gpuntos.Add(punto)
                If i > 0 Then
                    If gpuntos(i) = gpuntos(0) Then '<---------------------------------estoy de nuevo en el primer punto: salir
                        salir = True
                        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(gpuntos)
                        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                    End If
                End If
                i = i + 1
            Else
                salir = True
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
                Exit Sub
            End If
        Loop

        'guardar la polilinea dibujada en una variable de tipo polilinea........................................................
        Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        lapoli = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)

        If Not lapoli.IsClockwise Then
            lapoli.Reverse()
            copia_lapoli.reverse()
        End If
        'lapoli.VertexList.RemoveAll()
        copia_lapoli = lapoli

        'numerar los vertices de la polilinea.................................................................................................................
        'numerarVerticesMacizo(lapoli)

        '------------------------------------------------------------------------------------
        ' guardar los puntos de la polilinea dibujada (el macizo) en la estructura stMacizo. 
        'La estructura stMacizo esta representada por la variable globlal
        '_macizo(). Guardar tambien una copia de los puntos de la polilinea dibujada, 
        'en la estructura, en el vector de tipo punto "puntosOriginalesMacizo()"
        '------------------------------------------------------------------------------------
        Dim k As Integer
        For Each puntoVertice As VectorDraw.Geometry.gPoint In lapoli.VertexList
            k = k + 1
            If k = 1 Then
                ReDim _macizo.puntos(0)
                ReDim _macizo.puntosOriginales(0)
                'ReDim puntosOriginalesMacizo(0)
                _macizo.puntosOriginales(0) = New VectorDraw.Geometry.gPoint
                'puntosOriginalesMacizo(0) = New VectorDraw.Geometry.gPoint

                _macizo.puntos(0).X = puntoVertice.x
                _macizo.puntosOriginales(0).x = puntoVertice.x
                'puntosOriginalesMacizo(0).x = puntoVertice.x

                _macizo.puntos(0).Y = puntoVertice.y
                _macizo.puntosOriginales(0).y = puntoVertice.y
                'puntosOriginalesMacizo(0).y = puntoVertice.y

            ElseIf k < lapoli.VertexList.Count Then
                ReDim Preserve _macizo.puntos(k - 1)
                ReDim Preserve _macizo.puntosOriginales(k - 1)
                'ReDim Preserve puntosOriginalesMacizo(k - 1)
                _macizo.puntosOriginales(k - 1) = New VectorDraw.Geometry.gPoint
                'puntosOriginalesMacizo(k - 1) = New VectorDraw.Geometry.gPoint

                _macizo.puntos(k - 1).X = puntoVertice.x
                _macizo.puntosOriginales(k - 1).x = puntoVertice.x
                'puntosOriginalesMacizo(k - 1).x = puntoVertice.x

                _macizo.puntos(k - 1).Y = puntoVertice.y
                _macizo.puntosOriginales(k - 1).y = puntoVertice.y
                'puntosOriginalesMacizo(k - 1).y = puntoVertice.y
            End If
        Next

        '-------------------------------------------------------
        ' Uso de la estructura stMacizo, con la variable _macizo
        '-------------------------------------------------------
        'Dim aviso As String = ""
        'For i = 0 To _macizo.puntos.Count - 1
        '    aviso = aviso & String.Format("Punto {0} --> X: {1}, Y: {2}", i, _macizo.puntosOriginales(i).x, _macizo.puntosOriginales(i).y & vbCrLf)
        'Next
        'MsgBox("Puntos enviados: " & aviso)
        '------------------------------------------------------------
        ' fin Uso de la estructura stMacizo, con la variable _macizo
        '------------------------------------------------------------

        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)

        'llamar pantalla para cargar los nombres y anchos de calle
        'cuando vuelve, si bander es true es porque se cancelo en la pantalla de los nombres de calle
        frmPruebaMacizo.ShowDialog()
        If bander = True Then
            Exit Sub
        End If

      
        '-------------------------------------------------------------------------------------------------------------------------------------
        ' guardar los datos de la polilinea (o sea del macizo)
        '-------------------------------------------------------------------------------------------------------------------------------------
        Dim designacionMacizo As String = "nomenclatura" 'InputBox("Ingresar designacion de macizo", "Atributos de Macizo")
        'If Trim(designacionMacizo) = "" Then
        '    MsgBox("No se ingreso designacion.")
        '    designacionMacizo = "No se ingresó información"
        'End If

        '-------------------------------------------------------------------
        '15 de diciembre de 2012
        'Ojo!!, los datos del macizo se dan de alta en la pantalla
        'de los nombres de calle, pero el macizo se da de alta aqui!!, ojo!!
        '-------------------------------------------------------------------

        'ACA COMENTE LA FUNCION PARA PROBAR
        ' agregarDatosMacizoBD(designacionMacizo, lapoli, "macizo")  'GUARDAR EN LA BD LA INFO. Se envian dos parametros: datos y poli.


        ''                                                          en datos va la designacion del macizo (la nomenc.) y en poli va la poli.
        ''                                                          Datos se guarda en la tabla "atributosLogicos", por ahora en el campo
        ''                                                          nomenclatura
        Dim boxing As VectorDraw.Professional.vdObjects.vdPrimary
        boxing = lapoli
        pegarDatosEntidad(boxing, idEntidad)                       'PEGAR DATOS DE ENTIDAD EN TOOLTIP. Se leen los datos guardados para esta
        ''                                                          entidad y se cargan el el tooltip de la entidad. Por ahora se estan cargando
        '                                                           todos los datos. Resumir.
        '---------------------------------------------------------------------------------------------------------------------------------------
        ' fin guardar los datos de la polilinea (o sea del macizo)
        '---------------------------------------------------------------------------------------------------------------------------------------

        '-------------------------------------------------------
        ' Uso de la estructura stMacizo, con la variable _macizo
        '-------------------------------------------------------
        'aviso = ""
        'For i = 0 To _macizo.puntos.Count - 1
        '    aviso = aviso & String.Format("Punto {0} --> X: {1}, Y: {2}, Calle {3}, Ancho de calle {4}, Ancho macizo {5}", i, _macizo.puntosOriginales(i).x, _macizo.puntosOriginales(i).y, _macizo.txMedidaNombreCalle_contenbido(i), _macizo.txMedidaAnchoCalle_contenbido(i), _macizo.txMedidaLado_contenbido(i) & vbCrLf)
        'Next
        'MsgBox("Puntos recibidos: " & aviso)
        'Dim aviso2 As String = ""
        'For i = 0 To _macizo.puntos.Count - 1
        '    aviso2 = aviso2 & String.Format("Punto (original) {0} --> X: {1}, Y: {2}, Calle {3}, Ancho de calle {4}, Ancho macizo {5}", i, puntosOriginalesMacizo(i).x, puntosOriginalesMacizo(i).y, _macizo.txMedidaNombreCalle_contenbido(i), _macizo.txMedidaAnchoCalle_contenbido(i), _macizo.txMedidaLado_contenbido(i) & vbCrLf)
        'Next
        'MsgBox("Puntos copiados de los originales" & aviso2)
        ''------------------------------------------------------------
        ' fin Uso de la estructura stMacizo, con la variable _macizo
        '------------------------------------------------------------

        agregarLayersPlanoDigital()

        'coloca nombre de calle, anchos..etc
        dibujarMacizoPlanoDigital()


    End Sub

    Private Sub dibujarMacizoPlanoDigital()

        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Green)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01 '1.5

        '----------------------------------------------------------------------------------------
        'armar primero una coleccion de puntos con los datos recuperados de la estructura _macizo
        '----------------------------------------------------------------------------------------
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        Dim punto As VectorDraw.Geometry.gPoint
        For Each puntoFrmMacizo As VectorDraw.Geometry.gPoint In _macizo.puntosOriginales
            punto = New VectorDraw.Geometry.gPoint
            punto.x = puntoFrmMacizo.x
            punto.y = puntoFrmMacizo.y
            punto.z = 0.0
            gpuntos.Add(punto)
        Next
        punto = New VectorDraw.Geometry.gPoint
        punto.x = _macizo.puntosOriginales(0).x
        punto.y = _macizo.puntosOriginales(0).y
        punto.z = 0.0
        gpuntos.Add(punto)

        '-------------------------------------------------------------------------------------------------------------------
        '--> esto es para cargar los puntos originales (con los que fue dibujado el macizo) en una coleccion de puntos local
        '-------------------------------------------------------------------------------------------------------------------
        'Dim coleccionPuntosOriginales As New VectorDraw.Geometry.gPoints
        'For j As Integer = 0 To puntosOriginalesMacizo.Count - 1
        '    coleccionPuntosOriginales.Add(puntosOriginalesMacizo(j))
        'Next
        'coleccionPuntosOriginales.Add(puntosOriginalesMacizo(0).x, puntosOriginalesMacizo(0).y, 0.0)


        '------------------------------------------------------------------------------------------------------------------------------------------
        '--> dibujar una polilinea
        '------------------------------------------------------------------------------------------------------------------------------------------
        ' con los datos de frmMacizo, o sea con la estructura _macizo:
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(gpuntos)
        '
        ' con los datos originales de los puntos:
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(coleccionPuntosOriginales)
        '
        Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        lapoli = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)
        If Not lapoli.IsClockwise Then
            lapoli.Reverse()
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------------


        '------------------------------------------------------------------------------------------------------------------------------------------
        '--> dibujar la informacion del macizo
        '------------------------------------------------------------------------------------------------------------------------------------------
        Dim puntoExtremoUno, puntoMedio, puntoMedioLineaLinderos As VectorDraw.Geometry.gPoint
        Dim medida, anchoCalle, anchoMacizo As VectorDraw.Professional.vdFigures.vdText
        Dim k As Integer

        '----------------------------------------------------------------------------------------------
        'lineasOffseteadas son las que marcan el ancho de calle, haciendo offset de las lineas que 
        'pasan por la linea municipal del macizo.
        '9/10/2013: La calculo pero no la dibujo. La defino porque despues la uso para sacar datos.
        '----------------------------------------------------------------------------------------------
        Dim lineasOffseteadas As VectorDraw.Professional.vdCollections.vdCurves

        '----------------------------------------------------------------------------------------------
        'lineaLinderosEnfrente es la linea auxiliar offseteada al ancho de calle
        'lineaLinderosSobreMacizo es la linea auxiliar que pasa por la linea municipal del macizo
        'las dos se utilizan como ayuda para dibujar los macizos linderos.
        '----------------------------------------------------------------------------------------------
        Dim lineaLinderosEnfrente, lineaLinderosSobreMacizo As VectorDraw.Professional.vdFigures.vdLine

        For Each puntoVertice As VectorDraw.Geometry.gPoint In lapoli.VertexList
            k = k + 1
            puntoMedio = New VectorDraw.Geometry.gPoint
            puntoExtremoUno = New VectorDraw.Geometry.gPoint
            If k > 1 Then
                'offset linea:
                lineasOffseteadas = lapoli.GetFigureAtSegmentIndex(k - 2).getOffsetCurve(CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)))
                'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineasOffseteadas.Item(0))

                Dim gpuntosSegmentoDividido As New VectorDraw.Geometry.gPoints
                gpuntosSegmentoDividido = lapoli.GetFigureAtSegmentIndex(k - 2).Divide(2)
                puntoExtremoUno = gpuntosSegmentoDividido(0)
                puntoMedio = gpuntosSegmentoDividido(1)

                medida = New VectorDraw.Professional.vdFigures.vdText
                medida.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                medida.setDocumentDefaults()
                medida.PenColor.ColorIndex = 1
                medida.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                medida.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                'medida.TextString = Format(lapoli.GetFigureAtSegmentIndex(k - 2).Length, "##,##0.00").ToString
                medida.TextString = _macizo.txMedidaNombreCalle_contenbido(k - 2)
                medida.Rotation = lapoli.GetFigureAtSegmentIndex(k - 2).getStartPoint.GetAngle(lapoli.GetFigureAtSegmentIndex(k - 2).getEndPoint)
                medida.InsertionPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)) / 2)
                medida.ToolTip = "Nombre de calle"
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(medida)

                anchoCalle = New VectorDraw.Professional.vdFigures.vdText
                anchoCalle.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                anchoCalle.setDocumentDefaults()
                anchoCalle.PenColor.ColorIndex = 1
                anchoCalle.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                anchoCalle.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                anchoCalle.TextString = _macizo.txMedidaAnchoCalle_contenbido(k - 2)
                'anchoCalle.Rotation = lapoli.GetFigureAtSegmentIndex(k - 2).getStartPoint.GetAngle(lapoli.GetFigureAtSegmentIndex(k - 2).getEndPoint) + VectorDraw.Geometry.Globals.DegreesToRadians(90)
                anchoCalle.Rotation = _macizo.txMedidaAnchoCalle_angulo(k - 2)
                anchoCalle.ToolTip = "Ancho de calle"
                anchoCalle.InsertionPoint = puntoExtremoUno.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)) / 2)
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(anchoCalle)

                anchoMacizo = New VectorDraw.Professional.vdFigures.vdText
                anchoMacizo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                anchoMacizo.setDocumentDefaults()
                anchoMacizo.PenColor.ColorIndex = 1
                anchoMacizo.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                anchoMacizo.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                anchoMacizo.TextString = "S/C " & Format(lapoli.GetFigureAtSegmentIndex(k - 2).Length, "##,##0.00").ToString
                anchoMacizo.Rotation = lapoli.GetFigureAtSegmentIndex(k - 2).getStartPoint.GetAngle(lapoli.GetFigureAtSegmentIndex(k - 2).getEndPoint)
                anchoMacizo.InsertionPoint = puntoMedio.Polar(medida.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90), CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)) / 6)
                anchoMacizo.ToolTip = "Medida lado macizo"
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(anchoMacizo)

                lineaLinderosEnfrente = New VectorDraw.Professional.vdFigures.vdLine()
                lineaLinderosEnfrente.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                lineaLinderosEnfrente.setDocumentDefaults()
                lineaLinderosEnfrente.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
                lineaLinderosEnfrente.LineTypeScale = 8.0
                lineaLinderosEnfrente.PenColor.ColorIndex = 1
                lineaLinderosEnfrente.PenWidth = 0.8 '0.01 '0.15
                Dim gpuntosBaseLineaLinderosEnfrente As New VectorDraw.Geometry.gPoints
                gpuntosBaseLineaLinderosEnfrente = lineasOffseteadas.Item(0).Divide(2)
                puntoMedioLineaLinderos = gpuntosBaseLineaLinderosEnfrente(1)
                '(lapoli.GetFigureAtSegmentIndex(k - 2).Length) / 2) + CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)) + 3.5: Es el ancho del macizo sobre dos, 
                'mas el ancho de calle mas un plus
                lineaLinderosEnfrente.StartPoint = puntoMedioLineaLinderos.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(0), ((lapoli.GetFigureAtSegmentIndex(k - 2).Length) / 2) + CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)) + 3.5)
                lineaLinderosEnfrente.EndPoint = puntoMedioLineaLinderos.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(180), ((lapoli.GetFigureAtSegmentIndex(k - 2).Length) / 2) + CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)) + 3.5)
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineaLinderosEnfrente)

                lineaLinderosSobreMacizo = New VectorDraw.Professional.vdFigures.vdLine()
                lineaLinderosSobreMacizo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                lineaLinderosSobreMacizo.setDocumentDefaults()
                lineaLinderosSobreMacizo.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
                lineaLinderosSobreMacizo.LineTypeScale = 10.0
                lineaLinderosSobreMacizo.PenColor.ColorIndex = 1
                lineaLinderosSobreMacizo.PenWidth = 0.8 '0.01 '0.15
                lineaLinderosSobreMacizo.StartPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(0), ((lapoli.GetFigureAtSegmentIndex(k - 2).Length) / 2) + CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)) + 3.5)
                lineaLinderosSobreMacizo.EndPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(180), ((lapoli.GetFigureAtSegmentIndex(k - 2).Length) / 2) + CDbl(_macizo.txMedidaAnchoCalle_contenbido(k - 2)) + 3.5)
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineaLinderosSobreMacizo)

            End If
        Next

        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("S", 0.8, Nothing)

    End Sub

    Public Sub agregarLayersPlanoDigital()
        '--------------------------------------------------------------
        '
        ' agregar los layers del plano digital
        '
        '--------------------------------------------------------------
        'Dim elLayer As VectorDraw.Professional.vdPrimaries.vdLayer
        'elLayer = New VectorDraw.Professional.vdPrimaries.vdLayer()

        frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("plano digital")
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayer() = frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("Plano digital")

        '---------------------------------------------------
        ' apagar todos los layers menos el de plano digital
        '---------------------------------------------------
        'For Each capa As VectorDraw.Professional.vdPrimaries.vdLayer In frmPpal.VdF.BaseControl.ActiveDocument.Layers
        '    If capa.Name <> "plano digital" Then
        '        capa.Frozen = True
        '    End If
        'Next
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Public Sub numerarVerticesMacizo(ByVal lapoli As VectorDraw.Professional.vdFigures.vdPolyline)
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
                    nuevoPunto = New VectorDraw.Geometry.gPoint(VectorDraw.Geometry.gPoint.MidPoint(lapoli.VertexList(k - 2), lapoli.VertexList(0)))
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

    Public Sub definirMacizoPorPolilinea()
        '------------------------------------------
        'MACIZO. definir por seleccion de polilinea
        '------------------------------------------
        Dim Parray As Object

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar POLILINEA (boton derecho del mouse para finalizar)")
        Dim seleccion As vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

        If seleccion Is Nothing Then
            MsgBox("No hay seleccion")
            Exit Sub
        End If
        If seleccion.Count = 0 Then
            MsgBox("No hay seleccion")
            Exit Sub
        End If
        If seleccion.Count > 1 Then
            MsgBox("Hay mas de una entidad seleccionada...")
            Exit Sub
        End If

        If seleccion.Item(0)._TypeName = "vdPolyline" Then
            Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
            lapoli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            lapoli.setDocumentDefaults()
            lapoli = CType(seleccion.Item(0), VectorDraw.Professional.vdFigures.vdPolyline)
            MsgBox("Sentido horario: " & lapoli.IsClockwise.ToString, vbInformation, "prueba")
            If Not lapoli.IsClockwise Then
                lapoli.Reverse()
            End If
            Parray = lapoli.VertexList
            'Dim PolAbiertaCerrada As VectorDraw.Professional.Constants.VdConstPlineFlag = lapoli.Flag
            'If PolAbiertaCerrada = 0 Then 'abierta
            '    acotarPolilineas(i, Arriba, Abajo, Parray, True, Lados, Angulos)
            'Else
            '    acotarPolilineas(i, Arriba, Abajo, Parray, False, Lados, Angulos)
            'End If
            lapoli.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Red)
            lapoli.PenWidth = 0.01 '0.25
            'vdf.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lapoli)


            '..................................................................................................
            Dim designacionMacizo As String = InputBox("Ingresar designacion de macizo", "Atributos de Macizo")
            If Trim(designacionMacizo) = "" Then
                MsgBox("No se ingreso designacion.")
            Else
                agregarDatosMacizoBD(designacionMacizo, lapoli, "macizo")
                Dim boxing As VectorDraw.Professional.vdObjects.vdPrimary
                boxing = lapoli
                pegarDatosEntidad(boxing, idEntidad)
            End If
            '..................................................................................................


            lapoli.Dispose()
            frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        End If

    End Sub

End Module
