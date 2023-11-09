
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry.gPoint


Module modParcela

    Dim lapoliPlanoDigital As VectorDraw.Professional.vdFigures.vdPolyline

    Public Sub parcelaDefinirPorPuntos()
        '---------------------------------------------------------------------------------------------------------------------
        'PARCELA. definir por puntos
        '---------------------------------------------------------------------------------------------------------------------
        Dim elOsnap As VectorDraw.Geometry.OsnapMode = New VectorDraw.Geometry.OsnapMode
        elOsnap = VectorDraw.Geometry.OsnapMode.END + VectorDraw.Geometry.OsnapMode.INTERS + VectorDraw.Geometry.OsnapMode.CEN
        frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = elOsnap
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Green)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01 '0.15

        '.....................dibujar la parcela...............................................................................
        Dim salir As Boolean
        Dim ret As VectorDraw.Actions.StatusCode
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar PUNTO DE LA PARCELA")
        Dim i As Integer = 0
        Do While salir = False
            ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
            If ret = VectorDraw.Actions.StatusCode.Success Then
                gpuntos.Add(punto)
                If i > 0 Then
                    If gpuntos(i) = gpuntos(0) Then
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

        Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        lapoli = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)

        If Not lapoli.IsClockwise Then
            lapoli.Reverse()
            copia_lapoli.reverse()
        End If
        copia_lapoli = lapoli

        '.....................numerar los vertices............................................................................
        'numerarVerticesParcela(lapoli)

        '---------------------------------------------------------------------------------------------------------------------
        ' Cargo en la estructura stParcela, con la variable _parcela, me guardo una copia en _parcela.puntosOriginales
        '---------------------------------------------------------------------------------------------------------------------
        Dim k As Integer
        For Each puntoVertice As VectorDraw.Geometry.gPoint In lapoli.VertexList
            k = k + 1
            If k = 1 Then
                ReDim _parcela.puntos(0)
                ReDim _parcela.puntosOriginales(0)
                _parcela.puntosOriginales(0) = New VectorDraw.Geometry.gPoint

                _parcela.puntos(0).X = puntoVertice.x
                _parcela.puntosOriginales(0).x = puntoVertice.x

                _parcela.puntos(0).Y = puntoVertice.y
                _parcela.puntosOriginales(0).y = puntoVertice.y

            ElseIf k < lapoli.VertexList.Count Then
                ReDim Preserve _parcela.puntos(k - 1)
                ReDim Preserve _parcela.puntosOriginales(k - 1)
                _parcela.puntosOriginales(k - 1) = New VectorDraw.Geometry.gPoint

                _parcela.puntos(k - 1).X = puntoVertice.x
                _parcela.puntosOriginales(k - 1).x = puntoVertice.x

                _parcela.puntos(k - 1).Y = puntoVertice.y
                _parcela.puntosOriginales(k - 1).y = puntoVertice.y
            End If
        Next
        _parcela.txsuperficie = Math.Round(lapoli.Area, 2)
        '-------------------------------------------------------------------------------------------------------------
        ' fin Cargo en la estructura stParcela, con la variable _parcela
        '-------------------------------------------------------------------------------------------------------------

        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)

        '-------------------------------------------------------------------------------------------------------------
        ' calcular que lado de la parcela pertenece al macizo y el rumbo de cada lado, para armar un string que se 
        ' muestre en la pantalla de medidas linderos y sup (frmPruebaParcela)
        '-------------------------------------------------------------------------------------------------------------
        medidasLinderosSuperficies(lapoli)
        'frmUbicaParcela.idPoliParcela = lapoli.Id
        'frmUbicaParcela.Show()

        frmPruebaParcela.ShowDialog()

        If bander = True Then '<---------bander se setea en el formulario frmPruebaParcela. Si se cancela, bander=true
            MsgBox("salir")
            Exit Sub
        Else
            ultimaParteDibujaParcelaPorPuntos(lapoli) '<----no se cancelò, por lo tanto se dibuja la parcela definitiva
        End If


    End Sub

    Private Sub ultimaParteDibujaParcelaPorPuntos(ByVal lapoli As VectorDraw.Professional.vdFigures.vdPolyline)
        '--------------------------------------------------------------------------------------------------------------------------------------
        ' datos de la parcela
        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim designacionParcela As String
        If IsNothing(_parcela.txParcela) Then
            designacionParcela = frmPruebaParcela.t_parcela.Text
        Else
            designacionParcela = _parcela.txParcela
        End If

        'agregarDatosMacizoBD(designacionParcela, lapoli, "parcela") 'GUARDAR EN LA BD LA INFO. Se envian dos parametros: datos y poli.
        ''                                                           en datos va la designacion de la parcela y en poli va la poli.
        ''                                                           Datos se guarda en la tabla "atributosLogicos", por ahora en el campo
        ''                                                           nomenclatura
        Dim boxing As VectorDraw.Professional.vdObjects.vdPrimary
        boxing = lapoli
        pegarDatosEntidad(boxing, idEntidad)                       'PEGAR DATOS DE ENTIDAD EN TOOLTIP. Se leen los datos guardados para esta
        ''                                                          entidad y se cargan el el tooltip de la entidad. Por ahora se estan cargando
        ''                                                          todos los datos. Resumir.
        '----------------------------------------------------------------------------------------------------------------------------------------
        ' fin datos de la parcela
        '----------------------------------------------------------------------------------------------------------------------------------------

        agregarLayersPlanoDigital()
        dibujarParcelaPlanoDigital(designacionParcela)

    End Sub

    Public Sub parcelaLinderaDefinirPorPuntos()
        '-----------------------------------------------
        'PARCELA LINDERA. Definir por puntos
        '-----------------------------------------------

        Dim elOsnap As VectorDraw.Geometry.OsnapMode = New VectorDraw.Geometry.OsnapMode
        elOsnap = VectorDraw.Geometry.OsnapMode.END + VectorDraw.Geometry.OsnapMode.INTERS + VectorDraw.Geometry.OsnapMode.CEN
        frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = elOsnap
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Yellow)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01

        '.....................dibujar la parcela......................................................
        Dim salir As Boolean
        Dim ret As VectorDraw.Actions.StatusCode
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar PUNTO DE LA PARCELA")
        Dim i As Integer = 0
        Do While salir = False
            ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
            If ret = VectorDraw.Actions.StatusCode.Success Then
                gpuntos.Add(punto)
                If i > 0 Then
                    If gpuntos(i) = gpuntos(0) Then
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

        Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        lapoli = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)
        If Not lapoli.IsClockwise Then
            lapoli.Reverse()
        End If
        '................................................................................................................................

        '.....................numerar los vertices.....................................................
        'numerarVerticesParcela(lapoli)

        '-------------------------------------------------------------------------------------------------------------
        ' Cargo en la estructura stParcela, con la variable _parcela, me guardo una copia en _parcela.puntosOriginales
        '-------------------------------------------------------------------------------------------------------------
        Dim k As Integer
        For Each puntoVertice As VectorDraw.Geometry.gPoint In lapoli.VertexList
            k = k + 1
            If k = 1 Then
                ReDim _parcela.puntos(0)
                ReDim _parcela.puntosOriginales(0)
                _parcela.puntosOriginales(0) = New VectorDraw.Geometry.gPoint

                _parcela.puntos(0).X = puntoVertice.x
                _parcela.puntosOriginales(0).x = puntoVertice.x

                _parcela.puntos(0).Y = puntoVertice.y
                _parcela.puntosOriginales(0).y = puntoVertice.y

            ElseIf k < lapoli.VertexList.Count Then
                ReDim Preserve _parcela.puntos(k - 1)
                ReDim Preserve _parcela.puntosOriginales(k - 1)
                _parcela.puntosOriginales(k - 1) = New VectorDraw.Geometry.gPoint

                _parcela.puntos(k - 1).X = puntoVertice.x
                _parcela.puntosOriginales(k - 1).x = puntoVertice.x

                _parcela.puntos(k - 1).Y = puntoVertice.y
                _parcela.puntosOriginales(k - 1).y = puntoVertice.y
            End If
        Next
        '-------------------------------------------------------------------------------------------------------------
        ' fin Cargo en la estructura stParcela, con la variable _parcela
        '-------------------------------------------------------------------------------------------------------------

        '-----------------------------------------------------------------
        ' calcular que lado de la parcela pertenece al macizo y el rumbo
        ' de cada lado, para armar un string que se muestre en la pantalla
        ' de medidas linderos y sup.
        '-----------------------------------------------------------------
        'medidasLinderosSuperficies(lapoli)


        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)

        '--------------------------------------------------------------------------------------------------------------------------------------
        ' datos de la parcela
        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim designacionParcela As String = InputBox("Ingresar denominaciòn de la parcela lindera", "Plano Digital")
        If designacionParcela = "" Then designacionParcela = "Sin designaciòn"
        agregarDatosMacizoBD(designacionParcela, lapoli, "Parcela lindera") 'GUARDAR EN BD: Se envian los parametros: datos, poli y tipo ent log.
        ''                                                           en datos va la designacion de la parcela y en poli va la poli.
        ''                                                           Datos se guarda en la tabla "atributosLogicos", por ahora en el campo
        ''                                                           nomenclatura
        Dim boxing As VectorDraw.Professional.vdObjects.vdPrimary
        boxing = lapoli
        pegarDatosEntidad(boxing, idEntidad)                       'PEGAR DATOS DE ENTIDAD EN TOOLTIP. Se leen los datos guardados para esta
        ''                                                          entidad y se cargan el el tooltip de la entidad. Por ahora se estan cargando
        ''                                                          todos los datos. Resumir.
        '----------------------------------------------------------------------------------------------------------------------------------------
        ' fin datos de la parcela
        '----------------------------------------------------------------------------------------------------------------------------------------

        agregarLayersPlanoDigital()
        dibujarParcelaLinderaPlanoDigital(designacionParcela)

    End Sub

    Private Sub medidasLinderosSuperficies(ByVal poliParcela As VectorDraw.Professional.vdFigures.vdPolyline)
        'armar un segundo bucle que tome cada pl lindera y la contraste contra la pl ppal.
        'las pl linderas sin nada solo sesignacion
        'encender con un boton lineas amarillas

        Dim poliMacizo As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        Dim alRumbos As New ArrayList
        Dim linderos(50, 3) As String

        If _macizo.puntosOriginales Is Nothing Then
            MsgBox("No esta definido el macizo", vbCritical)
            Exit Sub
        End If

        '----------------------------------------------------------------------------------------
        'armar primero una coleccion de puntos con los datos recuperados de la estructura _macizo
        '----------------------------------------------------------------------------------------
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        Dim punto As New VectorDraw.Geometry.gPoint
        For Each puntoFrmMacizo As VectorDraw.Geometry.gPoint In _macizo.puntosOriginales
            punto = New VectorDraw.Geometry.gPoint
            punto.x = Math.Round(puntoFrmMacizo.x, 2)
            punto.y = Math.Round(puntoFrmMacizo.y, 2)
            punto.z = 0.0
            gpuntos.Add(punto)
        Next
        punto = New VectorDraw.Geometry.gPoint
        punto.x = Math.Round(_macizo.puntosOriginales(0).x, 2)
        punto.y = Math.Round(_macizo.puntosOriginales(0).y, 2)
        punto.z = 0.0
        gpuntos.Add(punto)


        '----------------------------------------------------------------------------------------
        'con la coleccion de puntos armar una polilinea del macizo
        '----------------------------------------------------------------------------------------
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(gpuntos)
        poliMacizo = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)


        '----------------------------------------------------------------------------------------
        'redondear los valores de la polilinea
        '----------------------------------------------------------------------------------------
        For Each puntoV As VectorDraw.Geometry.gPoint In poliParcela.VertexList 'lapoliPlanoDigital.VertexList
            puntoV.x = Math.Round(puntoV.x, 2)
            puntoV.y = Math.Round(puntoV.y, 2)
        Next



        '----------------------------------------------------------------------------------------
        'recorrer los puntos de la parcela
        '----------------------------------------------------------------------------------------
        Dim k, indiceSegmentoMacizo As Integer
        Dim nombreCalle, cartel As String
        Dim distancia As Double
        Dim calcularLinderos As Boolean
        frmPruebaParcela.rumbos.Items.Clear() 'rumbos es un listbox

        borrarSegmentos(idTrabajo)

        '--------------------------------------------------------
        '--------------------------------------------------------
        'calcular linderos de la parcela principal con el macizo
        '--------------------------------------------------------
        '--------------------------------------------------------
        VectorDraw.Geometry.Globals.DefaultPointEquality = 0.05
        Dim polilineasParcelasMacizo As New List(Of VectorDraw.Professional.vdFigures.vdPolyline)
        Dim coinc, j, segmento, m As Integer
        'Dim linderosYaCalculados As Boolean
        Dim listaPuntos As New List(Of VectorDraw.Geometry.gPoint)
        Dim listaSegmentos As New List(Of Integer)
        Dim azimut, rumbo, ladoNro As String
        Dim puntoCercano As VectorDraw.Geometry.gPoint
        Dim coincidentes As Boolean
        Dim az As Double



        '-----------------------------------------------------
        'recorrer todos los vertices de la parcela principal
        '-----------------------------------------------------
        For Each v As VectorDraw.Geometry.gPoint In poliParcela.VertexList           '<----recorrer todos los vertices de la pl ppal.
            If poliMacizo.PointOnCurve(v, True) Then                                 '<----la poli del macizo contiene al pto de la pl?
                If k = poliParcela.VertexList.Count - 1 Then                         '<----es el ultimo punto de la parcela?
                    Exit For
                End If
                If poliMacizo.PointOnCurve(poliParcela.VertexList(k + 1), True) Then '<---ver que pasa con el pto sig de la pl.(si pertenece al mz)
                    distancia = poliParcela.GetFigureAtSegmentIndex(k).Length        '<---distancia seria la medida del frente de la parcela.
                    indiceSegmentoMacizo = poliMacizo.SegmentIndexFromPoint(poliParcela.VertexList(k + 1), 0.0)
                    
                    If IsNothing(_macizo.txMedidaNombreCalle_contenbido) Then
                        nombreCalle = "--"
                    Else
                        If _macizo.txMedidaNombreCalle_contenbido(0) = _macizo.txMedidaNombreCalle_contenbido(1) Then
                            nombreCalle = _macizo.txMedidaNombreCalle_contenbido(indiceSegmentoMacizo + 1)  'NO estoy en la primera vez
                        Else
                            nombreCalle = _macizo.txMedidaNombreCalle_contenbido(indiceSegmentoMacizo)      'SI, estoy en la primera vez
                        End If
                    End If
                    'MsgBox("El lado de la parcela que mide " & distancia.ToString & " da a un lado del macizo, hacia la calle: " & nombreCalle)
                    az = calculoAzimut(v, poliParcela.VertexList(k + 1))
                    rumbo = calculoRumbo(az)
                    cartel = "Rumbo: " & rumbo & " mide " & distancia.ToString & " mts. de frente "
                    cartel = cartel & " sobre calle " & nombreCalle & " "
                    frmPruebaParcela.rumbos.Items.Add(cartel)
                    'guardar los puntos del frente de la parcela, para cuando se dibujan las rayitas en el croquis...
                    guardarSegmento(idTrabajo, v, poliParcela.VertexList(k + 1), "frente")
                End If
            End If
            k = k + 1
        Next




        '------------------------------------------------------
        'recorrer todas las parcelas linderas del macizo
        '------------------------------------------------------
        polilineasParcelasMacizo = buscarParcelasDelMacizo()
        If polilineasParcelasMacizo.Count = 0 Then
            MsgBox("El macizo no tiene parcelas linderas")
            Exit Sub
        End If
        For Each cPLind As VectorDraw.Professional.vdFigures.vdPolyline In polilineasParcelasMacizo '<---las parcelas del macizo
            If Not cPLind.IsClockwise Then
                cPLind.Reverse()
            End If
            coinc = 0
            j = 0
            listaPuntos.Clear()
            listaSegmentos.Clear()
            For Each VerticeLn As VectorDraw.Geometry.gPoint In cPLind.VertexList                   '<--- cada vertice de cada parcela lindera
                If j = cPLind.VertexList.Count - 1 Then
                    Continue For
                Else
                    If poliParcela.PointOnCurve(New VectorDraw.Geometry.gPoint(Math.Round(VerticeLn.x, 2), Math.Round(VerticeLn.y, 2), Math.Round(VerticeLn.z, 2)), True) Then
                        coinc = coinc + 1
                        'identificar el numero de lado:
                        segmento = poliParcela.SegmentIndexFromPoint(New VectorDraw.Geometry.gPoint(Math.Round(VerticeLn.x, 2), Math.Round(VerticeLn.y, 2), Math.Round(VerticeLn.z, 2)), 0.0)
                        listaSegmentos.Add(segmento)
                        listaPuntos.Add(VerticeLn)
                        If listaSegmentos.Count = 2 Then
                            ladoNro = (listaSegmentos(0) + 1).ToString & " - " & (listaSegmentos(0) + 2).ToString
                        End If
                    Else
                        puntoCercano = New VectorDraw.Geometry.gPoint
                        puntoCercano = poliParcela.getClosestPointTo(VerticeLn)
                        coincidentes = VectorDraw.Geometry.Globals.AreEqualPoint(VerticeLn, puntoCercano)
                        If coincidentes Then
                            coinc = coinc + 1
                            segmento = poliParcela.SegmentIndexFromPoint(New VectorDraw.Geometry.gPoint(Math.Round(puntoCercano.x, 2), Math.Round(puntoCercano.y, 2), Math.Round(puntoCercano.z, 2)), 0.0)
                            listaSegmentos.Add(segmento)
                            listaPuntos.Add(VerticeLn)
                            If listaSegmentos.Count = 2 Then
                                ladoNro = (listaSegmentos(0) + 1).ToString & " - " & (listaSegmentos(0) + 2).ToString
                            End If
                            coincidentes = False
                        End If
                    End If
                End If
                j = j + 1
            Next

            If coinc = 2 Or coinc = 3 Then
                '----LINDERO COMPLETO ------
                'detectar que lado es? (de la parcela principal...)
                'verificar orden de los dos puntos que se usan para calc. azimut
                listaPuntos = verifPtosAzimut(listaPuntos, poliParcela)

                'calcular az y rumbo
                azimut = calculoAzimut(listaPuntos(0), listaPuntos(1))
                rumbo = calculoRumbo(azimut)
                distancia = Math.Round(listaPuntos(0).Distance2D(listaPuntos(1)), 2)
                cartel = "Rumbo " & rumbo & " ; mide " & distancia & " mts, linda con la parcela " & cPLind.ToolTip.ToString
                alRumbos.Add(cartel)
                linderos(m, 0) = rumbo
                linderos(m, 1) = distancia.ToString
                linderos(m, 2) = cPLind.ToolTip.ToString
                'linderosYaCalculados = True 'sh
                guardarSegmento(idTrabajo, listaPuntos.Item(0), listaPuntos.Item(1), cPLind.ToolTip)
                listaPuntos.Clear()
            Else
                If coinc = 1 Then
                    For Each VerticePlPpal As VectorDraw.Geometry.gPoint In poliParcela.VertexList
                        If cPLind.PointOnCurve(VerticePlPpal, True) Then
                            '-----LINDERO PARCIAL ------
                            listaPuntos.Add(VerticePlPpal)
                            If listaPuntos(0) = listaPuntos(1) Then
                                Continue For
                            End If
                            'calcular az y rumbo
                            azimut = calculoAzimut(listaPuntos(0), listaPuntos(1))
                            rumbo = calculoRumbo(azimut)
                            distancia = Math.Round(listaPuntos(0).Distance2D(listaPuntos(1)), 2)
                            cartel = "Rumbo " & rumbo & "; mide " & distancia.ToString & " mts, linda con la parcela " & cPLind.ToolTip.ToString
                            alRumbos.Add(cartel)
                            linderos(m, 0) = rumbo
                            linderos(m, 1) = distancia.ToString
                            linderos(m, 2) = cPLind.ToolTip.ToString
                            'linderosYaCalculados = True 'sh
                            guardarSegmento(idTrabajo, listaPuntos.Item(0), listaPuntos.Item(1), cPLind.ToolTip)
                            listaPuntos.Clear()
                            Continue For
                        End If
                    Next

                End If
            End If
            m = m + 1
        Next


        'For Each ve As VectorDraw.Geometry.gPoint In poliParcela.VertexList 'lapoliPlanoDigital '<--recorrer los vertices de la parcela
        '    calcularLinderos = False
        '    If poliMacizo.PointOnCurve(ve, True) Then
        '        If k = poliParcela.VertexList.Count - 1 Then
        '            Exit For
        '        End If
        '        'ver que pasa con el punto siguiente (si el siguiente tambien pertenece entonces el lado de la parcela pertenece al macizo.
        '        Dim az As Double
        '        Dim rumbo As String
        '        If poliMacizo.PointOnCurve(poliParcela.VertexList(k + 1), True) Then
        '            distancia = poliParcela.GetFigureAtSegmentIndex(k).Length           'distancia seria la medida del frente de la parcela.
        '            indiceSegmentoMacizo = poliMacizo.SegmentIndexFromPoint(poliParcela.VertexList(k + 1), 0.0)
        '            If Not IsNothing(_macizo.txMedidaNombreCalle_contenbido) Then
        '                nombreCalle = _macizo.txMedidaNombreCalle_contenbido(indiceSegmentoMacizo + 1)
        '            Else
        '                nombreCalle = "--"
        '            End If
        '            'calc az y rumbo:
        '            az = calculoAzimut(ve, poliParcela.VertexList(k + 1))
        '            rumbo = calculoRumbo(az)
        '            cartel = "Rumbo: " & rumbo & " mide " & distancia.ToString & " mts. de frente "
        '            cartel = cartel & " sobre calle " & nombreCalle & " "
        '            frmPruebaParcela.rumbos.Items.Add(cartel)
        '            'guardar los puntos del frente de la parcela, para cuando se dibujan las rayitas en el croquis...
        '            guardarSegmento(idTrabajo, ve, poliParcela.VertexList(k + 1), "frente")
        '        Else
        '            calcularLinderos = True
        '        End If
        '    Else
        '        calcularLinderos = True
        '    End If




        '    '---------------------------------
        '    'calcular linderos
        '    '---------------------------------
        '    VectorDraw.Geometry.Globals.DefaultPointEquality = 0.05
        '    Dim polilineasParcelasMacizo As New List(Of VectorDraw.Professional.vdFigures.vdPolyline)
        '    Dim coinc As Integer
        '    Dim linderosYaCalculados As Boolean



        '    If calcularLinderos And linderosYaCalculados = False Then
        '        'If calcularLinderos Then
        '        '------>
        '        Dim segmento, j, m As Integer
        '        Dim listaPuntos As New List(Of VectorDraw.Geometry.gPoint)
        '        Dim listaSegmentos As New List(Of Integer)
        '        Dim azimut, rumbo, ladoNro As String

        '        polilineasParcelasMacizo = buscarParcelasDelMacizo()
        '        'borrarSegmentos(idTrabajo)
        '        If polilineasParcelasMacizo.Count > 0 Then

        '            For Each Pl As VectorDraw.Professional.vdFigures.vdPolyline In polilineasParcelasMacizo  'las parcelas del macizo...

        '                If Not Pl.IsClockwise Then
        '                    Pl.Reverse()
        '                End If
        '                coinc = 0
        '                j = 0
        '                listaPuntos.Clear()
        '                listaSegmentos.Clear()
        '                Dim puntoCercano As VectorDraw.Geometry.gPoint
        '                Dim coincidentes As Boolean
        'For Each VerticePl As VectorDraw.Geometry.gPoint In Pl.VertexList
        '    If j = Pl.VertexList.Count - 1 Then
        '        Continue For
        '    Else
        '        'poliParcela es la polilinea de la parcela principal
        '        'If poliParcela.PointOnCurve(VerticePl, True) Then
        '        If poliParcela.PointOnCurve(New VectorDraw.Geometry.gPoint(Math.Round(VerticePl.x, 2), Math.Round(VerticePl.y, 2), Math.Round(VerticePl.z, 2)), True) Then
        '            coinc = coinc + 1

        '            'identificar el numero de lado..
        '            segmento = poliParcela.SegmentIndexFromPoint(New VectorDraw.Geometry.gPoint(Math.Round(VerticePl.x, 2), Math.Round(VerticePl.y, 2), Math.Round(VerticePl.z, 2)), 0.0)
        '            listaSegmentos.Add(segmento)
        '            listaPuntos.Add(VerticePl)
        '            If listaSegmentos.Count = 2 Then
        '                'If listaSegmentos(0) = 0 Then
        '                ladoNro = (listaSegmentos(0) + 1).ToString & " - " & (listaSegmentos(0) + 2).ToString
        '                'Else
        '                'ladoNro = (listaSegmentos(0) + 2).ToString & " - " & (listaSegmentos(0) + 3).ToString
        '                'End If
        '            End If
        '        Else
        '            'VectorDraw.Geometry.Globals.DefaultPointEquality = 0.01
        '            puntoCercano = New VectorDraw.Geometry.gPoint
        '            puntoCercano = poliParcela.getClosestPointTo(VerticePl)
        '            coincidentes = VectorDraw.Geometry.Globals.AreEqualPoint(VerticePl, puntoCercano)
        '            If coincidentes Then
        '                coinc = coinc + 1
        '                'aca: wrong input parameter
        '                segmento = poliParcela.SegmentIndexFromPoint(New VectorDraw.Geometry.gPoint(Math.Round(puntoCercano.x, 2), Math.Round(puntoCercano.y, 2), Math.Round(puntoCercano.z, 2)), 0.0)
        '                listaSegmentos.Add(segmento)
        '                listaPuntos.Add(VerticePl)
        '                If listaSegmentos.Count = 2 Then
        '                    'If listaSegmentos(0) = 0 Then
        '                    ladoNro = (listaSegmentos(0) + 1).ToString & " - " & (listaSegmentos(0) + 2).ToString
        '                    'Else
        '                    'ladoNro = (listaSegmentos(0) + 2).ToString & " - " & (listaSegmentos(0) + 3).ToString
        '                    'End If
        '                End If
        '                coincidentes = False
        '            End If
        '            'VectorDraw.Geometry.Globals.DefaultPointEquality = 0.00000001
        '        End If
        '    End If
        '    j = j + 1
        'Next




        '                If coinc = 2 Or coinc = 3 Then
        '                    'detectar que lado es? (de la parcela principal...)
        '                    '----LINDERO COMPLETO ------

        '                    'verificar orden de los dos puntos que se usan para calc. azimut
        '                    listaPuntos = verifPtosAzimut(listaPuntos, poliParcela)

        '                    'calcular az y rumbo
        '                    azimut = calculoAzimut(listaPuntos(0), listaPuntos(1))
        '                    rumbo = calculoRumbo(azimut)
        '                    'cartel = "El lado " & ladoNro & " tiene rumbo " & rumbo & " y es lindero a la parcela " & Pl.ToolTip.ToString

        '                    distancia = Math.Round(listaPuntos(0).Distance2D(listaPuntos(1)), 2)

        '                    cartel = "Rumbo " & rumbo & " ; mide " & distancia & " mts, linda con la parcela " & Pl.ToolTip.ToString
        '                    alRumbos.Add(cartel)

        '                    linderos(m, 0) = rumbo
        '                    linderos(m, 1) = distancia.ToString
        '                    linderos(m, 2) = Pl.ToolTip.ToString

        '                    linderosYaCalculados = True 'sh
        '                    guardarSegmento(idTrabajo, listaPuntos.Item(0), listaPuntos.Item(1), Pl.ToolTip)
        '                    listaPuntos.Clear()
        '                Else
        '                    If coinc = 1 Then
        '                        For Each VerticePlPpal As VectorDraw.Geometry.gPoint In poliParcela.VertexList
        '                            If Pl.PointOnCurve(VerticePlPpal, True) Then
        '                                '-----LINDERO PARCIAL ------
        '                                listaPuntos.Add(VerticePlPpal)
        '                                If listaPuntos(0) = listaPuntos(1) Then
        '                                    'listaPuntos.RemoveAt(1)
        '                                    Continue For
        '                                End If
        '                                'calcular az y rumbo
        '                                azimut = calculoAzimut(listaPuntos(0), listaPuntos(1))
        '                                rumbo = calculoRumbo(azimut)
        '                                'cartel = "El lado " & ladoNro & " tiene rumbo " & rumbo & "y es lindero parcial a la parcela " & Pl.ToolTip.ToString
        '                                distancia = Math.Round(listaPuntos(0).Distance2D(listaPuntos(1)), 2)
        '                                cartel = "Rumbo " & rumbo & "; mide " & distancia.ToString & " mts, linda con la parcela " & Pl.ToolTip.ToString
        '                                alRumbos.Add(cartel)

        '                                linderos(m, 0) = rumbo
        '                                linderos(m, 1) = distancia.ToString
        '                                linderos(m, 2) = Pl.ToolTip.ToString

        '                                linderosYaCalculados = True 'sh
        '                                guardarSegmento(idTrabajo, listaPuntos.Item(0), listaPuntos.Item(1), Pl.ToolTip)
        '                                listaPuntos.Clear()
        '                                Continue For
        '                            End If
        '                        Next
        '                    End If
        '                End If
        '                m = m + 1
        '            Next
        '        End If
        '    End If
        '    'sh: linderosYaCalculados = True 
        '    k = k + 1
        'Next





        Dim parcelas As String
        Dim sumatoria As Double
        Dim transitorio As String
        Dim rumbosOrdenados As New ArrayList

        'ordenar la matriz "linderos"
        '        (0)     (1)      (2)
        '       rumbo   dist    parcela
        '------------------------------
        '  (0)  norte   50.66     24
        '  (1)  este    42.04     26
        '  (2)  este    58.56     27
        '  (3)  norte   35.94     15
        '
        Dim arLiResultados As New ArrayList
        Dim textoMostrar As String
        Dim arrayListDesarmado() As String
        For i As Integer = 0 To 50
            If Not linderos(i, 0) = "" Then
                arLiResultados.Add(linderos(i, 0) & "|" & linderos(i, 1) & "|" & linderos(i, 2))
            End If
        Next
        arLiResultados.Sort()
        For Each elemento In arLiResultados
            textoMostrar = textoMostrar & elemento & vbCrLf
        Next
        ''Dim result As String() = Array.FindAll(arr, Function(s) s.StartsWith("Ra"))

        ''aqui hay que llegar con la matriz ordenada...
        ''For x As Integer = 0 To UBound(linderos)
        ''    If x = 0 Then
        ''        sumatoria = CDbl(linderos(x, 1))
        ''        parcelas = parcelas & linderos(x, 2)
        ''        transitorio = "Rumbo " & linderos(x, 0) & " mide " & sumatoria.ToString & " linda con la parcela " & parcelas
        ''    Else
        ''        If linderos(x - 1, 0) = linderos(x, 0) Then
        ''            sumatoria = sumatoria + CDbl(linderos(x, 1))
        ''            parcelas = parcelas & ", " & linderos(x, 2)
        ''            transitorio = "Rumbo " & linderos(x, 0) & " mide " & sumatoria.ToString & " linda con la parcela " & parcelas
        ''        Else
        ''            rumbosOrdenados.Add(transitorio)
        ''            sumatoria = 0.0
        ''            parcelas = ""
        ''            transitorio = ""
        ''            sumatoria = sumatoria + CDbl(linderos(x, 1))
        ''            parcelas = parcelas & linderos(x, 2)
        ''            transitorio = "Rumbo " & linderos(x, 0) & " mide " & sumatoria.ToString & " linda con la parcela " & parcelas
        ''        End If
        ''    End If
        ''Next
        For w As Integer = 0 To arLiResultados.Count - 1
            arrayListDesarmado = Split(arLiResultados(w), "|")
            If w = 0 Then
                sumatoria = sumatoria + CDbl(arrayListDesarmado(1))
                parcelas = parcelas & ", " & arrayListDesarmado(2)
                transitorio = "Rumbo " & arrayListDesarmado(0) & " mide " & sumatoria.ToString & " linda con la parcela " & parcelas
            Else
                If arLiResultados(w - 1).ToString.Substring(0, 3) = arLiResultados(w).ToString.Substring(0, 3) Then
                    sumatoria = sumatoria + CDbl(arrayListDesarmado(1))
                    parcelas = parcelas & ", " & arrayListDesarmado(2)
                    transitorio = "Rumbo " & arrayListDesarmado(0) & " mide " & sumatoria.ToString & " linda con la parcela " & parcelas
                    If w = arLiResultados.Count - 1 Then
                        rumbosOrdenados.Add(transitorio)
                    End If
                Else
                    rumbosOrdenados.Add(transitorio)
                    sumatoria = 0.0
                    parcelas = ""
                    transitorio = ""
                    sumatoria = sumatoria + CDbl(arrayListDesarmado(1))
                    parcelas = parcelas & ", " & arrayListDesarmado(2)
                    transitorio = "Rumbo " & arrayListDesarmado(0) & " mide " & sumatoria.ToString & " linda con la parcela " & parcelas
                    If w = arLiResultados.Count - 1 Then
                        rumbosOrdenados.Add(transitorio)
                    End If
                End If
            End If
        Next

        Dim rumOrdFilt As New ArrayList
        Dim mostrar As String
        rumbosOrdenados.Sort()
        For Each elemento In rumbosOrdenados
            If Not elemento.Contains("mide 0") Then
                rumOrdFilt.Add(elemento)
            End If
        Next

        For Each elemento In rumOrdFilt
            'mostrar = mostrar & vbCrLf & elemento
            frmPruebaParcela.rumbos.Items.Add(elemento)
        Next
        'MsgBox(mostrar)
        frmPruebaParcela.t_superficie.Text = Format(_parcela.txsuperficie, "#,###.00") ' m²")

        linderos = Nothing

    End Sub

    Private Function verifPtosAzimut(ByVal listaPuntos As List(Of VectorDraw.Geometry.gPoint), ByVal poliPpal As VectorDraw.Professional.vdFigures.vdPolyline) As List(Of VectorDraw.Geometry.gPoint)

        Dim angulo As Double = listaPuntos(0).GetAngle(listaPuntos(1))
        Dim puntoMedio As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint(VectorDraw.Geometry.gPoint.MidPoint(listaPuntos(0), listaPuntos(1)))
        Dim puntoVerif As VectorDraw.Geometry.gPoint = puntoMedio.Polar(angulo + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 1.0)
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        For Each puntoVertice As VectorDraw.Geometry.gPoint In poliPpal.VertexList
            gpuntos.Add(puntoVertice)
        Next

        Dim puntoAuxiliar As VectorDraw.Geometry.gPoint
        If gpuntos.IsPointInside(puntoVerif) Then
            'el punto de control cae dentro de la parcela ppal. Por lo tanto dar vuelta
            'los puntos de la lista de puntos recibida
            puntoAuxiliar = listaPuntos(0)
            listaPuntos(0) = listaPuntos(1)
            listaPuntos(1) = puntoAuxiliar
        End If

        angulo = Nothing
        puntoMedio.Dispose()
        puntoMedio = Nothing
        puntoVerif.Dispose()
        puntoVerif = Nothing
        gpuntos.Dispose()
        gpuntos = Nothing
        If Not IsNothing(puntoAuxiliar) Then
            puntoAuxiliar.Dispose()
            puntoAuxiliar = Nothing
        End If
        Return listaPuntos

    End Function

    Private Sub dibujarParcelaPlanoDigital(ByVal designacion As String)

        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.DarkOrange)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01 '0.15

        '----------------------------------------------------------------------------------------
        'armar primero una coleccion de puntos con los datos recuperados de la estructura _macizo
        '----------------------------------------------------------------------------------------
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        Dim punto As VectorDraw.Geometry.gPoint
        For Each elementoPunto As VectorDraw.Geometry.gPoint In _parcela.puntosOriginales
            punto = New VectorDraw.Geometry.gPoint
            punto.x = elementoPunto.x
            punto.y = elementoPunto.y
            punto.z = 0.0
            gpuntos.Add(punto)
        Next
        punto = New VectorDraw.Geometry.gPoint
        punto.x = _parcela.puntosOriginales(0).x
        punto.y = _parcela.puntosOriginales(0).y
        punto.z = 0.0
        gpuntos.Add(punto)

        '-------------------------------------------------------------------------------------------------------------------
        '--> esto es para cargar los puntos originales (con los que fue dibujada la parcela) en una coleccion de puntos local
        '-------------------------------------------------------------------------------------------------------------------
        'Dim coleccionPuntosOriginales As New VectorDraw.Geometry.gPoints
        'For k As Integer = 0 To puntosOriginalesParcela.Count - 1
        '    coleccionPuntosOriginales.Add(puntosOriginalesParcela(k))
        'Next
        'coleccionPuntosOriginales.Add(puntosOriginalesParcela(0).x, puntosOriginalesParcela(0).y, 0.0)


        '-------------------------------------------------------------------------
        '--> Dibujar la parcela con los datos de frmParcela 
        '-------------------------------------------------------------------------
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(gpuntos)

        '-----------------------------------------------------------------------------------
        '--> Dibujar la parcela con los datos originales (con los que fue dibujada)
        '    Cuando se reciban los puntos desde el formulario "frmParcela" en forma correcta
        '    comentar esta opcion y usar la anterior.
        '-----------------------------------------------------------------------------------
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(coleccionPuntosOriginales)
        lapoliPlanoDigital = New VectorDraw.Professional.vdFigures.vdPolyline
        lapoliPlanoDigital = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)
        If Not lapoliPlanoDigital.IsClockwise Then
            lapoliPlanoDigital.Reverse()
        End If


        '-------------------------------------------------------------------------------------------------------------
        ' numerar los vertices antes se hacia en el dibujo original de la parcela (Public Sub parcelaDefinirPorPuntos)
        '-------------------------------------------------------------------------------------------------------------
        numerarVerticesParcela(lapoliPlanoDigital)
        '-------------------------------------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------
        'agregar un bloque con un circulo y dentro la denominacion de la parcela
        '---------------------------------------------------------------------------------
        Dim centroide As VectorDraw.Geometry.gPoint = gpuntos.Centroid()
        'agregarBloqueIdParcela(CDbl(Format(_parcela.txsuperficie, "0.0000")), centroide)
        agregarBloqueIdParcela(designacion, CDbl(Format(lapoliPlanoDigital.Area, "0.0000")), centroide, False)
        '---------------------------------------------------------------------------------

        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("S", 0.8, Nothing)

    End Sub

    Private Sub dibujarParcelaLinderaPlanoDigital(ByVal designacion As String)

        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Yellow)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01

        '----------------------------------------------------------------------------------------
        'armar primero una coleccion de puntos con los datos recuperados de la estructura _macizo
        '----------------------------------------------------------------------------------------
        Dim gpuntos As New VectorDraw.Geometry.gPoints
        Dim punto As VectorDraw.Geometry.gPoint
        For Each elementoPunto As VectorDraw.Geometry.gPoint In _parcela.puntosOriginales
            punto = New VectorDraw.Geometry.gPoint
            punto.x = elementoPunto.x
            punto.y = elementoPunto.y
            punto.z = 0.0
            gpuntos.Add(punto)
        Next
        punto = New VectorDraw.Geometry.gPoint
        punto.x = _parcela.puntosOriginales(0).x
        punto.y = _parcela.puntosOriginales(0).y
        punto.z = 0.0
        gpuntos.Add(punto)

        '-------------------------------------------------------------------------
        '--> Dibujar la parcela con los datos de frmParcela 
        '-------------------------------------------------------------------------
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(gpuntos)

        '-----------------------------------------------------------------------------------
        '--> Dibujar la parcela con los datos originales (con los que fue dibujada)
        '    Cuando se reciban los puntos desde el formulario "frmParcela" en forma correcta
        '    comentar esta opcion y usar la anterior.
        '-----------------------------------------------------------------------------------
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(coleccionPuntosOriginales)
        lapoliPlanoDigital = New VectorDraw.Professional.vdFigures.vdPolyline
        lapoliPlanoDigital = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)
        If Not lapoliPlanoDigital.IsClockwise Then
            lapoliPlanoDigital.Reverse()
        End If


        '-------------------------------------------------------------------------------------------------------------
        ' numerar los vertices antes se hacia en el dibujo original de la parcela (Public Sub parcelaDefinirPorPuntos)
        '-------------------------------------------------------------------------------------------------------------
        '20/05/13
        'numerarVerticesParcela(lapoliPlanoDigital)
        '-------------------------------------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------
        'agregar un bloque con un circulo y dentro la denominacion de la parcela
        '---------------------------------------------------------------------------------
        Dim centroide As VectorDraw.Geometry.gPoint = gpuntos.Centroid()
        'agregarBloqueIdParcela(CDbl(Format(_parcela.txsuperficie, "0.0000")), centroide)
        agregarBloqueIdParcela(designacion, CDbl(Format(lapoliPlanoDigital.Area, "0.00")), centroide, True)
        '---------------------------------------------------------------------------------

        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("S", 0.8, Nothing)

    End Sub

    Public Function agregarBloqueIdParcela(ByVal txIdParcela As String, ByVal area As Double, ByVal centro As VectorDraw.Geometry.gPoint, ByVal plLindera As Boolean) As Boolean

        '-----------------------------------------------------------------------------------------
        '
        'Dibuja un circulo con la identificacion de la parcela y debajo del circulo la superficie 
        '
        '-----------------------------------------------------------------------------------------

        'Dim ret As VectorDraw.Actions.StatusCode
        'Dim pt As VectorDraw.Geometry.gPoint = Nothing
        Dim ptSup As VectorDraw.Geometry.gPoint = Nothing

        '--------------------------------------
        'borrar la inserción y borrar el bloque
        '--------------------------------------
        Dim bloqueBorrar As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("idParcela")
        'primero borrar el vdInsert
        For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If obj._TypeName = "vdInsert" Then
                Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = CType(obj, VectorDraw.Professional.vdFigures.vdInsert)
                If elVdInsert.Block.Name = "idParcela" Then
                    elVdInsert.Invalidate()
                    elVdInsert.Deleted = True
                    elVdInsert.Update()
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(elVdInsert)
                    Exit For
                End If
            End If
        Next
        'sigo ahora borrando el bloque..
        If Not bloqueBorrar Is Nothing Then
            bloqueBorrar.Deleted = True
            bloqueBorrar.Update()
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(bloqueBorrar)
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            frmPHUnidadesFuncionales.limpiarMemoria()
        End If


        Dim bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
        bloque.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloque.setDocumentDefaults()
        bloque.Name = "idParcela"

        'frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar posicion del circulo identificador de la parcela..")
        'ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(pt)
        'frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        'If ret = VectorDraw.Actions.StatusCode.Success Then
        bloque.Origin = centro
        'Else
        'Return False
        'Exit Function
        'End If

        'acata
        Dim circulo As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        circulo.setDocumentDefaults()
        circulo.Center = centro
        circulo.Radius = 2.5
        bloque.Entities.AddItem(circulo)

        Dim texto As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
        texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        texto.setDocumentDefaults()
        'texto.PenColor.ColorIndex= 3
        If txIdParcela = "" Then
            If _parcela.txParcela = "" Then
                texto.TextString = "??"
            Else
                texto.TextString = _parcela.txParcela
            End If
        Else
            texto.TextString = txIdParcela
        End If
        'frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "verdana"
        texto.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        texto.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        texto.Height = 1.4  '<--
        texto.InsertionPoint = centro
        bloque.Entities.AddItem(texto)
        texto = Nothing

        Dim textoSup As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
        textoSup.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoSup.setDocumentDefaults()
        If plLindera Then
            textoSup.TextString = ""
        Else
            textoSup.TextString = "Sup: " & Math.Round(area, 2).ToString  '& " m2"
        End If
        textoSup.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoSup.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        ptSup = New VectorDraw.Geometry.gPoint
        ptSup.x = centro.x
        ptSup.y = centro.y - (circulo.Radius * 1.5)
        textoSup.Height = 0.5   '<--
        textoSup.InsertionPoint = ptSup
        bloque.Entities.AddItem(textoSup)

        frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddItem(bloque)

        Dim insertar As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert
        insertar.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        insertar.setDocumentDefaults()

        insertar.Block = bloque
        insertar.InsertionPoint = centro
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(insertar)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Return True

    End Function

    Public Function agregarBloqueIdParcelaDesdeBd(ByVal txIdParcela As String, ByVal area As Double, ByVal centro As VectorDraw.Geometry.gPoint, ByVal plLindera As Boolean) As Boolean
        Static pasadas As Integer
        pasadas = pasadas + 1
        Dim ptSup As VectorDraw.Geometry.gPoint = Nothing

        ''--------------------------------------
        ''borrar la inserción y borrar el bloque
        ''--------------------------------------
        'Dim bloqueBorrar As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("idParcela")
        ''primero borrar el vdInsert
        'For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
        '    If obj._TypeName = "vdInsert" Then
        '        Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = CType(obj, VectorDraw.Professional.vdFigures.vdInsert)
        '        If elVdInsert.Block.Name = "idParcela" Then
        '            elVdInsert.Invalidate()
        '            elVdInsert.Deleted = True
        '            elVdInsert.Update()
        '            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(elVdInsert)
        '            Exit For
        '        End If
        '    End If
        'Next
        ''sigo ahora borrando el bloque..
        'If Not bloqueBorrar Is Nothing Then
        '    bloqueBorrar.Deleted = True
        '    bloqueBorrar.Update()
        '    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(bloqueBorrar)
        '    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        '    frmPHUnidadesFuncionales.limpiarMemoria()
        'End If


        Dim bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
        bloque.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloque.setDocumentDefaults()
        bloque.Name = "idParcela" & pasadas.ToString
        bloque.Origin = centro

        Dim circulo As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        circulo.setDocumentDefaults()
        circulo.Center = centro
        circulo.Radius = 2.5
        bloque.Entities.AddItem(circulo)

        Dim texto As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
        texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        texto.setDocumentDefaults()
        'texto.PenColor.ColorIndex= 3
        If txIdParcela = "" Then
            If _parcela.txParcela = "" Then
                texto.TextString = "??"
            Else
                texto.TextString = _parcela.txParcela
            End If
        Else
            texto.TextString = txIdParcela
        End If

        'frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "verdana"
        texto.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        texto.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        texto.Height = 1.4  '<--
        texto.InsertionPoint = centro
        bloque.Entities.AddItem(texto)
        texto = Nothing

        Dim textoSup As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
        textoSup.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoSup.setDocumentDefaults()
        If plLindera Then
            textoSup.TextString = ""
        Else
            textoSup.TextString = "Sup: " & Math.Round(area, 2).ToString '& " m²"
        End If
        textoSup.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoSup.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        ptSup = New VectorDraw.Geometry.gPoint
        ptSup.x = centro.x
        ptSup.y = centro.y - (circulo.Radius * 1.5)
        textoSup.Height = 0.5   '<--
        textoSup.InsertionPoint = ptSup
        bloque.Entities.AddItem(textoSup)

        frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddItem(bloque)

        Dim insertar As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert
        insertar.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        insertar.setDocumentDefaults()

        insertar.Block = bloque
        insertar.InsertionPoint = centro
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(insertar)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Return True

    End Function

    Private Sub agregarLayersPlanoDigital()
        '--------------------------------------------------------------
        '
        ' agregar los layers del plano digital
        '
        '--------------------------------------------------------------
        'Dim elLayer As VectorDraw.Professional.vdPrimaries.vdLayer
        'elLayer = New VectorDraw.Professional.vdPrimaries.vdLayer()

        frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("Mensura")
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayer() = frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("Mensura")

        'For Each capa As VectorDraw.Professional.vdPrimaries.vdLayer In frmPpal.VdF.BaseControl.ActiveDocument.Layers
        '    If capa.Name <> "plano digital" Then
        '        capa.Frozen = True
        '    End If
        'Next
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Public Sub numerarVerticesParcela(ByVal lapoli As VectorDraw.Professional.vdFigures.vdPolyline)

        Dim puntoExtremoUno, puntoMedio As VectorDraw.Geometry.gPoint
        Dim elTexto, medida As VectorDraw.Professional.vdFigures.vdText
        Dim k As Integer
        Dim angulo As Double

        For Each puntoVertice As VectorDraw.Geometry.gPoint In lapoli.VertexList
            k = k + 1
            If k > 1 Then
                Dim gpuntosSegmentoDividido As New VectorDraw.Geometry.gPoints              '<---Colecciòn de Gpoints
                gpuntosSegmentoDividido = lapoli.GetFigureAtSegmentIndex(k - 2).Divide(2)   '<---Segmento de la polilinea, dividido en dos partes iguales. O sea tres puntos.
                If gpuntosSegmentoDividido Is Nothing Then
                    Exit Sub
                End If
                puntoExtremoUno = gpuntosSegmentoDividido(0)
                puntoMedio = gpuntosSegmentoDividido(1)

                elTexto = New VectorDraw.Professional.vdFigures.vdText
                elTexto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                elTexto.setDocumentDefaults()
                elTexto.Style = estiloMedidaPl3
                elTexto.PenColor.ColorIndex = 2
                elTexto.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                elTexto.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                If k = lapoli.VertexList.Count Then
                    elTexto.TextString = lapoli.VertexList.Count - 1
                Else
                    elTexto.TextString = k.ToString - 1
                End If
                'elTexto.Rotation = lapoli.GetFigureAtSegmentIndex(k - 2).getStartPoint.GetAngle(lapoli.GetFigureAtSegmentIndex(k - 2).getEndPoint)
                elTexto.Rotation = 0.0 'lapoli.GetFigureAtSegmentIndex(k - 2).getStartPoint.GetAngle(lapoli.GetFigureAtSegmentIndex(k - 2).getEndPoint)
                elTexto.InsertionPoint = puntoExtremoUno.Polar(lapoli.GetFigureAtSegmentIndex(k - 2).getStartPoint.GetAngle(lapoli.GetFigureAtSegmentIndex(k - 2).getEndPoint) + VectorDraw.Geometry.Globals.DegreesToRadians(90), 0.5)
                'elTexto.Height = 0.5
                frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "Verdana"
                'elTexto.TextLine = VectorDraw.Render.grTextStyleExtra.TextLineFlags.UnderLine
                'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(elTexto)



                medida = New VectorDraw.Professional.vdFigures.vdText
                medida.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                medida.setDocumentDefaults()
                medida.Style = estiloMedidaPl3
                medida.PenColor.ColorIndex = 1
                'medida.Height = 0.5
                medida.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                medida.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                medida.TextString = Format(lapoli.GetFigureAtSegmentIndex(k - 2).Length, "##,##0.00").ToString & " m"

                angulo = VectorDraw.Geometry.Globals.RadiansToDegrees(lapoli.GetFigureAtSegmentIndex(k - 2).getStartPoint.GetAngle(lapoli.GetFigureAtSegmentIndex(k - 2).getEndPoint))
                angulo = Math.Round(angulo, 2)
                medida.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(angulo) 'lapoli.GetFigureAtSegmentIndex(k - 2).getStartPoint.GetAngle(lapoli.GetFigureAtSegmentIndex(k - 2).getEndPoint)

                If angulo > 90 And angulo <= 135 Then
                    angulo = angulo + 180
                    medida.InsertionPoint = puntoMedio.Polar(angulo + VectorDraw.Geometry.Globals.DegreesToRadians(90), -1.0)
                ElseIf angulo = 90 Then
                    medida.InsertionPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), 1.0)
                ElseIf angulo = 180 Then
                    angulo = 0.0
                    medida.InsertionPoint = puntoMedio.Polar(angulo - VectorDraw.Geometry.Globals.DegreesToRadians(90), 1.0)
                    medida.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(0.0)
                ElseIf angulo > 180 And angulo < 270 Then
                    angulo = angulo + 180
                    medida.InsertionPoint = puntoMedio.Polar(angulo + VectorDraw.Geometry.Globals.DegreesToRadians(90), -1.0)
                    medida.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(angulo)
                ElseIf angulo > 135 And angulo < 180 Then
                    angulo = angulo + 180
                    medida.InsertionPoint = puntoMedio.Polar(angulo - VectorDraw.Geometry.Globals.DegreesToRadians(90), -1.5)
                    medida.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(angulo)
                Else
                    medida.InsertionPoint = puntoMedio.Polar(medida.Rotation + VectorDraw.Geometry.Globals.DegreesToRadians(90), 1.0)
                End If
                medida.ToolTip = "txMedidaLadoPl"
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(medida)
                modDatosDB.guardarMedidaLadoParcela(medida)
            End If
        Next
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Public Sub parcelaDefinirPorPolilinea()
        '-----------------------------------------------
        'PARCELA. definir por polilinea
        '-----------------------------------------------
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
            Parray = lapoli.VertexList
            lapoli.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Green)
            lapoli.PenWidth = 0.01 '0.15

            '..................................................................................................
            Dim designacionMacizo As String = InputBox("Ingresar designacion de parcela", "Atributos de Parcela")
            If Trim(designacionMacizo) = "" Then
                MsgBox("No se ingreso designacion.")
            Else
                agregarDatosMacizoBD(designacionMacizo, lapoli, "parcela")
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
