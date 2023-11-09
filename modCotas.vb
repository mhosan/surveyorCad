Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects

Module modCotas

    Dim Mydim As VectorDraw.Professional.vdFigures.vdDimension
    Dim seleccion As vdSelection

    Public Sub Acotar(ByVal Arriba As Boolean, ByVal Abajo As Boolean, ByVal Lados As Boolean, ByVal Angulos As Boolean)
        '===========================================
        'la cota comun, normal que se usa en el E.P.
        '===========================================

        Dim Parray As Object

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar entidades a acotar...")
        seleccion = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

        If seleccion Is Nothing Then
            Exit Sub
        End If

        If seleccion.Count = 0 Then
            Exit Sub
        End If

        For i As Integer = 0 To seleccion.Count - 1
            'para lineas..
            If seleccion.Item(i)._TypeName = "vdLine" Then
                Mydim = New VectorDraw.Professional.vdFigures.vdDimension
                Mydim.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                Mydim.setDocumentDefaults()
                Parray = seleccion.Item(i).GetGripPoints()
                Mydim.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(Parray(0).x.ToString), CDbl(Parray(0).y.ToString))
                Mydim.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(Parray(1).x.ToString), CDbl(Parray(1).y.ToString))

                Dim puntoMedio As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
                puntoMedio = VectorDraw.Geometry.gPoint.MidPoint(Mydim.DefPoint1, Mydim.DefPoint2)
                Mydim.LinePosition = VectorDraw.Geometry.gPoint.Polar(puntoMedio, -VectorDraw.Geometry.Globals.HALF_PI / 2.0, 0)

                If Arriba Then
                    Mydim.dimText = "\O<>"
                    ultimoComando = "acotarAgrimensuraArriba"
                End If
                If Abajo Then
                    Mydim.dimText = "\L<>"
                    ultimoComando = "acotarAgrimensuraAbajo"
                End If
                If Arriba = False And Abajo = False Then
                    ultimoComando = "acotarAgrimensura"
                End If
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(Mydim)
                Mydim = Nothing

            ElseIf seleccion.Item(i)._TypeName = "vdRect" Then
                Dim ExRectpoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
                'Dim poliMalla As VectorDraw.Professional.vdFigures.vdPolyface
                Dim elRectangulo As VectorDraw.Professional.vdFigures.vdRect
                Dim coleccionPolilineas As VectorDraw.Professional.vdCollections.vdEntities = New VectorDraw.Professional.vdCollections.vdEntities

                'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdExplode(seleccion.Item(i))
                elRectangulo = New VectorDraw.Professional.vdFigures.vdRect
                elRectangulo = seleccion.Item(i)
                'poliMalla = New VectorDraw.Professional.vdFigures.vdPolyface
                'poliMalla = elRectangulo.ToMesh(1)

                'Parray = poliMalla.VertexList
                coleccionPolilineas = elRectangulo.Explode

                'getprymary y primarycount
                'Dim a As Integer = frmPpal.VdF.BaseControl.ActiveDocument.PrimaryCount
                'Dim b As Object = frmPpal.VdF.BaseControl.ActiveDocument.GetPrimaries(True)
                'seleccion = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.g
                Parray = coleccionPolilineas.Item(0).GetGripPoints

                acotarRectangulos(i, Arriba, Abajo, Parray)

            ElseIf seleccion.Item(i)._TypeName = "vdPolyline" Then
                Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
                lapoli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                lapoli.setDocumentDefaults()
                lapoli = CType(seleccion.Item(i), VectorDraw.Professional.vdFigures.vdPolyline)
                Parray = lapoli.VertexList
                Dim PolAbiertaCerrada As VectorDraw.Professional.Constants.VdConstPlineFlag = lapoli.Flag
                If PolAbiertaCerrada = 0 Then 'abierta
                    acotarPolilineas(i, Arriba, Abajo, Parray, True, Lados, Angulos)
                Else
                    acotarPolilineas(i, Arriba, Abajo, Parray, False, Lados, Angulos)
                End If

                lapoli.Dispose()

            End If
        Next
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)


    End Sub

    Private Sub definir_estilo_transitorio(ByVal altura_actual As Single)
        Dim estilo_transitorio As vdDimstyle = New vdDimstyle
        estilo_transitorio.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        estilo_transitorio.setDocumentDefaults()
        estilo_transitorio.Name = "estilo transitorio"
        estilo_transitorio.ArrowSize = 0
        estilo_transitorio.DecimalPrecision = 2
        estilo_transitorio.ExtLineVisible = False
        estilo_transitorio.LineIsInvisible = True
        estilo_transitorio.TextHeight = altura_actual * 0.85
        'mens_chico.ExtLineDist1 = 0.0001
        'mens_chico.ExtLineDist2 = 0.0001
        frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.AddItem(estilo_transitorio)
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveDimStyle = estilo_transitorio

    End Sub

    Public Sub Agregar_Estilos_Cotas()
        '======================================================================
        'agregar tres estilos de cotas, chico mediano y grande.
        'Estos estilos de cotas son los utilizados en agrimensura, o sea tienen
        'ocultas las flechas de las puntas de las lineas de cota, la linea de 
        'cota y las lineas de referencia.
        '=======================================================================
        Dim mens_chico As vdDimstyle = New vdDimstyle
        Dim mens_medio As vdDimstyle = New vdDimstyle
        Dim mens_grande As vdDimstyle = New vdDimstyle

        If frmPpal.versionCad = "DEMO" Or frmPpal.versionCad = "MHCAD" Then
            Exit Sub
        End If

        mens_chico.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        mens_chico.setDocumentDefaults()
        mens_chico.Name = "Mensura Chico"
        mens_chico.ArrowSize = 0
        mens_chico.DecimalPrecision = 2
        mens_chico.ExtLineVisible = False
        mens_chico.LineIsInvisible = True
        mens_chico.TextHeight = 0.25
        'mens_chico.ExtLineDist1 = 0.0001
        'mens_chico.ExtLineDist2 = 0.0001
        frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.AddItem(mens_chico)

        mens_medio.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        mens_medio.setDocumentDefaults()
        mens_medio.Name = "Mensura Medio"
        mens_medio.ArrowSize = 0
        mens_medio.DecimalPrecision = 2
        mens_medio.ExtLineVisible = False
        mens_medio.LineIsInvisible = True
        mens_medio.TextHeight = 0.5
        frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.AddItem(mens_medio)

        mens_grande.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        mens_grande.setDocumentDefaults()
        mens_grande.Name = "Mensura Grande"
        mens_grande.ArrowSize = 0
        mens_grande.DecimalPrecision = 2
        mens_grande.ExtLineVisible = False
        mens_grande.LineIsInvisible = True
        mens_grande.TextHeight = 1.5
        frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.AddItem(mens_grande)

        frmPpal.VdF.BaseControl.ActiveDocument.ActiveDimStyle = mens_grande

    End Sub

    Private Sub acotarRectangulos(ByVal i As Integer, ByVal Arriba As Boolean, ByVal Abajo As Boolean, ByVal parray As Object)
        Dim puntoTexto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim puntoUno As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim puntoN As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        Dim tipo As Object = "E"

        For j As Integer = 0 To parray.count - 1
            Mydim = New VectorDraw.Professional.vdFigures.vdDimension
            Mydim.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            Mydim.setDocumentDefaults()

            Mydim.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
            If j = 0 Then
                puntoUno = Mydim.DefPoint1
            End If

            If j = parray.count - 1 Then
                Mydim.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(puntoUno.x.ToString), CDbl(puntoUno.y.ToString))
            Else
                Mydim.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
            End If

            puntoN = Mydim.DefPoint2

            Dim puntoMedio As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
            puntoMedio = VectorDraw.Geometry.gPoint.MidPoint(Mydim.DefPoint1, Mydim.DefPoint2)
            Mydim.LinePosition = VectorDraw.Geometry.gPoint.Polar(puntoMedio, -VectorDraw.Geometry.Globals.HALF_PI / 2.0, 0)

            If Arriba Then
                Mydim.dimText = "\O<>"
                ultimoComando = "acotarAgrimensuraArriba"
            End If
            If Abajo Then
                Mydim.dimText = "\L<>"
                ultimoComando = "acotarAgrimensuraAbajo"
            End If
            If Arriba = False And Abajo = False Then
                ultimoComando = "acotarAgrimensura"
            End If
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(Mydim)

            puntoTexto = Mydim.DefPoint2
            Mydim = Nothing
        Next

    End Sub

    Private Sub acotarPolilineas(ByVal i As Integer, ByVal Arriba As Boolean, ByVal Abajo As Boolean, ByVal parray As Object, ByVal abierta As Boolean, ByVal lados As Boolean, ByVal angulos As Boolean)
        Dim puntoTexto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim puntoUno As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim puntoN As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        Dim tipo As Object = "E"
        Dim value As Boolean
        Dim area As Double
        Dim perimetro As Double
        Dim cotaAngulo As VectorDraw.Professional.vdFigures.vdDimension
        Dim cotaAngulo2 As VectorDraw.Professional.vdFigures.vdDimension
        Dim cotaAnguloExtra As VectorDraw.Professional.vdFigures.vdDimension
        Dim cotaAnguloExtra2 As VectorDraw.Professional.vdFigures.vdDimension
        Dim estiloActual As String
        Dim existe As Object

        If lados Then
            'esta recorrida del parray es para poner las cotas lineales..
            For j As Integer = 0 To parray.count - 1
                Mydim = New VectorDraw.Professional.vdFigures.vdDimension
                Mydim.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                Mydim.setDocumentDefaults()

                Mydim.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                If j = 0 Then
                    puntoUno = Mydim.DefPoint1
                End If

                If j = parray.count - 1 Then
                    If abierta = False Then
                        Mydim.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(puntoUno.x.ToString), CDbl(puntoUno.y.ToString))
                    Else
                        Exit For
                    End If
                Else
                    Mydim.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                End If

                puntoN = Mydim.DefPoint2

                Dim puntoMedio As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
                puntoMedio = VectorDraw.Geometry.gPoint.MidPoint(Mydim.DefPoint1, Mydim.DefPoint2)
                Mydim.LinePosition = VectorDraw.Geometry.gPoint.Polar(puntoMedio, -VectorDraw.Geometry.Globals.HALF_PI / 2.0, 0)

                If Arriba Then
                    Mydim.dimText = "\O<>"
                    ultimoComando = "acotarAgrimensuraArriba"
                End If
                If Abajo Then
                    Mydim.dimText = "\L<>"
                    ultimoComando = "acotarAgrimensuraAbajo"
                End If
                If Arriba = False And Abajo = False Then
                    ultimoComando = "acotarAgrimensura"
                End If
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(Mydim)

                puntoTexto = Mydim.DefPoint2
                Mydim = Nothing
            Next
        End If

        If angulos Then
            'esta recorrida es para poner los angulos. Se recorren todos los vertices de la polilinea.
            For j As Integer = 0 To parray.count - 2
                'procedimiento para definir y activar un nuevo estilo, transitorio, igual que el activo 
                'pero con la letra un toque mas chica
                If frmPpal.VdF.BaseControl.ActiveDocument.ActiveDimStyle.Name <> "estilo transitorio" Then
                    estiloActual = frmPpal.VdF.BaseControl.ActiveDocument.ActiveDimStyle.Name
                    existe = frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.FindName("estilo transitorio")
                    If Not existe Is Nothing Then
                        frmPpal.VdF.BaseControl.ActiveDocument.ActiveDimStyle = frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.FindName("estilo transitorio")
                    Else
                        definir_estilo_transitorio(frmPpal.VdF.BaseControl.ActiveDocument.ActiveDimStyle.TextHeight)
                    End If
                End If

                cotaAngulo = New VectorDraw.Professional.vdFigures.vdDimension
                cotaAngulo2 = New VectorDraw.Professional.vdFigures.vdDimension
                cotaAnguloExtra = New VectorDraw.Professional.vdFigures.vdDimension
                cotaAnguloExtra2 = New VectorDraw.Professional.vdFigures.vdDimension
                cotaAngulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                cotaAngulo2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                cotaAnguloExtra.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                cotaAnguloExtra2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                cotaAngulo.setDocumentDefaults()
                cotaAngulo2.setDocumentDefaults()
                cotaAnguloExtra.setDocumentDefaults()
                cotaAnguloExtra2.setDocumentDefaults()
                cotaAngulo.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Angular
                cotaAngulo2.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Angular
                cotaAnguloExtra.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Angular
                cotaAnguloExtra2.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Angular

                If j = parray.count - 2 Then
                    If abierta = False Then
                        'poligono cerrado..
                        cotaAngulo.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAngulo2.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))

                        cotaAngulo.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                        cotaAngulo2.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                        cotaAngulo.DefPoint3 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                        cotaAngulo2.DefPoint3 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))

                        cotaAngulo.DefPoint4 = New VectorDraw.Geometry.gPoint(CDbl(parray(0).x.ToString), CDbl(parray(0).y.ToString))
                        cotaAngulo2.DefPoint4 = New VectorDraw.Geometry.gPoint(CDbl(parray(0).x.ToString), CDbl(parray(0).y.ToString))

                        cotaAnguloExtra.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(0).x.ToString), CDbl(parray(0).y.ToString))
                        cotaAnguloExtra2.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(0).x.ToString), CDbl(parray(0).y.ToString))
                        cotaAnguloExtra.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAnguloExtra2.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAnguloExtra.DefPoint3 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAnguloExtra2.DefPoint3 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAnguloExtra.DefPoint4 = New VectorDraw.Geometry.gPoint(CDbl(parray(1).x.ToString), CDbl(parray(1).y.ToString))
                        cotaAnguloExtra2.DefPoint4 = New VectorDraw.Geometry.gPoint(CDbl(parray(1).x.ToString), CDbl(parray(1).y.ToString))

                    Else
                        'polilinea abierta..
                        cotaAngulo.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                        cotaAngulo2.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                        cotaAngulo.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAngulo2.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAngulo.DefPoint3 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAngulo2.DefPoint3 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                        cotaAngulo.DefPoint4 = New VectorDraw.Geometry.gPoint(CDbl(parray(j - 1).x.ToString), CDbl(parray(j - 1).y.ToString))
                        cotaAngulo2.DefPoint4 = New VectorDraw.Geometry.gPoint(CDbl(parray(j - 1).x.ToString), CDbl(parray(j - 1).y.ToString))
                    End If
                Else
                    cotaAngulo.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))
                    cotaAngulo2.DefPoint1 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 1).x.ToString), CDbl(parray(j + 1).y.ToString))

                    cotaAngulo.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                    cotaAngulo2.DefPoint2 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                    cotaAngulo.DefPoint3 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))
                    cotaAngulo2.DefPoint3 = New VectorDraw.Geometry.gPoint(CDbl(parray(j).x.ToString), CDbl(parray(j).y.ToString))

                    cotaAngulo.DefPoint4 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 2).x.ToString), CDbl(parray(j + 2).y.ToString))
                    cotaAngulo2.DefPoint4 = New VectorDraw.Geometry.gPoint(CDbl(parray(j + 2).x.ToString), CDbl(parray(j + 2).y.ToString))
                End If

                'medir al angulo para ver como se posicionan las dos cotas
                'entre 90 y 180 y entre 270 y 360 mover segun el eje x
                'entre 0 y 90 y entre 180 y 270 mover segun el eje y

                'getAngleDir: toma el angulo entre dx, dy y el origen. Y getAngle toma el angulo entre dos puntos
                'y el origen. El origen en el primer punto.
                'Dim angulote As Double = VectorDraw.Geometry.Globals.getAngleDir(Mydim.DefPoint4.x, Mydim.DefPoint4.y)
                Dim angulote As Double = VectorDraw.Geometry.Globals.GetAngle(cotaAngulo.DefPoint1, cotaAngulo.DefPoint4)
                Dim angulote2 As Double = VectorDraw.Geometry.Globals.GetAngle(cotaAngulo.DefPoint1, cotaAngulo.DefPoint2)

                Dim anguloteExtra As Double
                Dim anguloteExtra2 As Double
                If j = parray.count - 2 Then
                    anguloteExtra = VectorDraw.Geometry.Globals.GetAngle(cotaAnguloExtra.DefPoint1, cotaAnguloExtra.DefPoint4)
                    anguloteExtra2 = VectorDraw.Geometry.Globals.GetAngle(cotaAnguloExtra.DefPoint1, cotaAnguloExtra.DefPoint2)
                End If

                Dim anguloP1P4 As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(angulote)
                Dim anguloP1P2 As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(angulote2)
                Dim anguloDiferenciaP4P2 As Double = (anguloP1P4 - anguloP1P2) / 2
                Dim anguloOpuesto As Double = anguloDiferenciaP4P2 + 180

                Dim anguloP1P4Extra As Double
                Dim anguloP1P2Extra As Double
                Dim anguloDiferenciaP4P2Extra As Double
                Dim anguloOpuestoExtra As Double
                If j = parray.count - 2 Then
                    anguloP1P4Extra = VectorDraw.Geometry.Globals.RadiansToDegrees(anguloteExtra)
                    anguloP1P2Extra = VectorDraw.Geometry.Globals.RadiansToDegrees(anguloteExtra2)
                    anguloDiferenciaP4P2Extra = (anguloP1P4Extra - anguloP1P2Extra) / 2
                    anguloOpuestoExtra = anguloDiferenciaP4P2Extra + 180
                End If

                Dim delta As Single = 0.2

                If j = parray.count - 2 Then
                    '---------------
                    'mover segun "y"
                    If (anguloP1P4Extra > 90 And anguloP1P4Extra < 180) And (anguloP1P2Extra > 0 And anguloP1P2Extra < 90) Then
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x, cotaAnguloExtra.DefPoint1.y + delta)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x, cotaAnguloExtra.DefPoint1.y - delta)
                    ElseIf (anguloP1P4Extra > 90 And anguloP1P4Extra < 180) And (anguloP1P2Extra > 90 And anguloP1P2Extra < 180) Then
                        'en diagonal..
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x - delta, cotaAnguloExtra.DefPoint1.y + delta)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x + delta, cotaAnguloExtra.DefPoint1.y - delta)

                    ElseIf (anguloP1P4Extra > 180 And anguloP1P4Extra < 270) And (anguloP1P2Extra > 270 And anguloP1P2Extra < 360) Then
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x, cotaAnguloExtra.DefPoint1.y + delta)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x, cotaAnguloExtra.DefPoint1.y - delta)
                    ElseIf (anguloP1P4Extra > 180 And anguloP1P4Extra < 270) And (anguloP1P2Extra > 180 And anguloP1P2Extra < 270) Then
                        'en diagonal..
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x + delta, cotaAnguloExtra.DefPoint1.y + delta)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x - delta, cotaAnguloExtra.DefPoint1.y - delta)

                    ElseIf (anguloP1P4Extra > 270 And anguloP1P4Extra < 360) And (anguloP1P2Extra > 180 And anguloP1P2Extra < 270) Then
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x, cotaAnguloExtra.DefPoint1.y + delta)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x, cotaAnguloExtra.DefPoint1.y - delta)
                    ElseIf (anguloP1P4Extra > 270 And anguloP1P4Extra < 360) And (anguloP1P2Extra > 270 And anguloP1P2Extra < 360) Then
                        'en diagonal..
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x - delta, cotaAnguloExtra.DefPoint1.y + delta)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x + delta, cotaAnguloExtra.DefPoint1.y - delta)

                    ElseIf (anguloP1P4Extra > 0 And anguloP1P4Extra < 90) And (anguloP1P2Extra > 90 And anguloP1P2Extra < 180) Then
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x, cotaAnguloExtra.DefPoint1.y + delta)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x, cotaAnguloExtra.DefPoint1.y - delta)
                    ElseIf (anguloP1P4Extra > 0 And anguloP1P4Extra < 90) And (anguloP1P2Extra > 0 And anguloP1P2Extra < 90) Then
                        'en diagonal..
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x + delta, cotaAnguloExtra.DefPoint1.y + delta)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x - delta, cotaAnguloExtra.DefPoint1.y - delta)
                    Else
                        'mover segun "x"
                        cotaAnguloExtra.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x + delta, cotaAnguloExtra.DefPoint1.y)
                        cotaAnguloExtra2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAnguloExtra.DefPoint1.x - delta, cotaAnguloExtra.DefPoint1.y)
                    End If
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(cotaAnguloExtra)
                    Dim anguloOriginalExtra As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(cotaAnguloExtra.Measurement)
                    Dim anguloDiferenciaExtra As Double = anguloOriginalExtra - 360
                    cotaAnguloExtra2.Measurement = anguloDiferenciaExtra
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(cotaAnguloExtra2)
                End If

                '---------------
                'mover segun "y"
                If (anguloP1P4 > 90 And anguloP1P4 < 180) And (anguloP1P2 > 0 And anguloP1P2 < 90) Then
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x, cotaAngulo.DefPoint1.y + delta)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x, cotaAngulo.DefPoint1.y - delta)
                ElseIf (anguloP1P4 > 90 And anguloP1P4 < 180) And (anguloP1P2 > 90 And anguloP1P2 < 180) Then
                    'en diagonal..
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x - delta, cotaAngulo.DefPoint1.y + delta)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x + delta, cotaAngulo.DefPoint1.y - delta)

                ElseIf (anguloP1P4 > 180 And anguloP1P4 < 270) And (anguloP1P2 > 270 And anguloP1P2 < 360) Then
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x, cotaAngulo.DefPoint1.y + delta)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x, cotaAngulo.DefPoint1.y - delta)
                ElseIf (anguloP1P4 > 180 And anguloP1P4 < 270) And (anguloP1P2 > 180 And anguloP1P2 < 270) Then
                    'en diagonal..
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x + delta, cotaAngulo.DefPoint1.y + delta)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x - delta, cotaAngulo.DefPoint1.y - delta)

                ElseIf (anguloP1P4 > 270 And anguloP1P4 < 360) And (anguloP1P2 > 180 And anguloP1P2 < 270) Then
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x, cotaAngulo.DefPoint1.y + delta)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x, cotaAngulo.DefPoint1.y - delta)
                ElseIf (anguloP1P4 > 270 And anguloP1P4 < 360) And (anguloP1P2 > 270 And anguloP1P2 < 360) Then
                    'en diagonal..
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x - delta, cotaAngulo.DefPoint1.y + delta)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x + delta, cotaAngulo.DefPoint1.y - delta)

                ElseIf (anguloP1P4 > 0 And anguloP1P4 < 90) And (anguloP1P2 > 90 And anguloP1P2 < 180) Then
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x, cotaAngulo.DefPoint1.y + delta)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x, cotaAngulo.DefPoint1.y - delta)
                ElseIf (anguloP1P4 > 0 And anguloP1P4 < 90) And (anguloP1P2 > 0 And anguloP1P2 < 90) Then
                    'en diagonal..
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x + delta, cotaAngulo.DefPoint1.y + delta)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x - delta, cotaAngulo.DefPoint1.y - delta)
                Else
                    'mover segun "x"
                    cotaAngulo.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x + delta, cotaAngulo.DefPoint1.y)
                    cotaAngulo2.LinePosition = New VectorDraw.Geometry.gPoint(cotaAngulo.DefPoint1.x - delta, cotaAngulo.DefPoint1.y)
                End If
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(cotaAngulo)

                Dim anguloOriginal As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(cotaAngulo.Measurement)
                Dim anguloDiferencia As Double = anguloOriginal - 360
                cotaAngulo2.Measurement = anguloDiferencia

                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(cotaAngulo2)
            Next
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveDimStyle = frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.FindName(estiloActual)
            'cuando termina de recorrer todos los vertices de la polilinea, borra el estilo transitorio
            frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.RemoveItem(frmPpal.VdF.BaseControl.ActiveDocument.DimStyles.FindName("estilo transitorio"))
        End If

    End Sub

End Module
