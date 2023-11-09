
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX
Imports mhCad.BO.Nomenclatura

Public Module modPublico_pd

    Public tblEstilos As DataTable

    Public estiloMz1 As New VectorDraw.Professional.vdPrimaries.vdTextstyle
    Public estiloNombreCalle2 As New VectorDraw.Professional.vdPrimaries.vdTextstyle
    Public estiloMedidaPl3 As New VectorDraw.Professional.vdPrimaries.vdTextstyle
    Public estiloAnchoMuro4 As New VectorDraw.Professional.vdPrimaries.vdTextstyle

    Public id_macizo As String
    Public nomenclatura As New BO.Nomenclatura
    Public _macizo As stMacizo
    Public _parcela As stParcela
    Public _muro As stMuros

    Public AnchoEspacioCirculatorio As Double
    Public NombreEspacioCirculatorio As String
    Public CancelarDibujoEspacioCirculatorio As Boolean
    Public ContadorLados As Integer
    Public DistanciaCalle As Double
    Public DesignacionMacizo As String

    Public tipo_persona_1 As String
    Public tipo_persona_2 As String
    Public tipo_persona_3 As String
    Public tipo_persona_4 As String
    Public tipo_persona_5 As String
    Public ancho_muro, diferencia1, diferencia2 As Double
    Public bandera As Integer
    Public tipo_peronsa_nombre As String
    Public tipo_peronsa_apellido As String
    Public parce, sup As String

    '// Variables para el formulario de Localidades
    Public cod_partido As String
    Public localidad As String
    Public partido_1 As String
    Public cod_postal As String
    '// fin variables del fomulario de localidades
    '// variables globales del frm entrada
    Public identificadorTrabajo As Integer
    Public trabajoexistente As Boolean
    Public obra_nueva As Boolean = False
    Public id_persona As Integer
    '///
    '// var para el frmlocalidad bandera para cerrar
    Public flag As Integer = 1



    '// Variables para la nomenclatura
    Dim Circ, Sec, Chacra, ChacraLetra, Quinta, QuintaLetra, Frac, FracLetra, Manzana, ManzanaLetra As String
    Dim Parcela, ParcelaLetra, SubParcela, Partida As String
    '//


    Structure stMuros

        Dim puntosEjeParcela() As PointF
        Dim puntosMuro() As String
        Dim anchoMuro As Double
        Dim idMuro As Integer
        Dim idTxtAnchoMuro As Integer

    End Structure


    Structure stMacizo
        '---------------------------------------------------
        'estructura para macizo
        '---------------------------------------------------
        Dim puntos() As PointF
        Dim puntosOriginales() As VectorDraw.Geometry.gPoint

        Dim txMedidaLado_pto() As PointF
        Dim txMedidaLado_angulo() As Double
        Dim txMedidaLado_estilo() As System.Drawing.FontFamily
        Dim txMedidaLado_contenbido() As String

        Dim txMedidaAnchoCalle_pto() As PointF
        Dim txMedidaAnchoCalle_angulo() As Double
        Dim txMedidaAnchoCalle_estilo() As System.Drawing.FontFamily
        Dim txMedidaAnchoCalle_contenbido() As String

        Dim txMedidaNombreCalle_pto() As PointF
        Dim txMedidaNombreCalle_angulo() As Double
        Dim txMedidaNombreCalle_estilo() As System.Drawing.FontFamily
        Dim txMedidaNombreCalle_contenbido() As String

    End Structure

    Structure stParcela
        Dim puntos() As PointF
        Dim puntosOriginales() As VectorDraw.Geometry.gPoint

        Dim txMedidaLado_pto() As PointF
        Dim txMedidaLado_angulo() As Double
        Dim txMedidaLado_estilo() As System.Drawing.FontFamily
        Dim txMedidaLado_contenido() As String

        Dim txParcela As String
        Dim txdenominacion As String

        Dim txsuperficie As Double

        Dim rumbosMedidasLinderos() As String

        Dim calles() As calle

        '20/05/2013
        Dim idParcela As Integer

    End Structure

    Structure calle
        Dim nombreCalle As String
        Dim numero As String
        Dim pavimento As Boolean
        Dim alumbradoPublico As Boolean
        Dim energiaElectrica As Boolean
        Dim gas As Boolean
        Dim cloacas As Boolean
        Dim escuela As Boolean
        Dim micros As Boolean
    End Structure

    Public Function verificarNorte() As Boolean
        '---------------------------------------------
        'buscar la inserción del bloque con el norte
        '---------------------------------------------
        Dim bloqueBuscar As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("simboloNorte")
        For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If obj._TypeName = "vdInsert" Then
                Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = CType(obj, VectorDraw.Professional.vdFigures.vdInsert)
                If elVdInsert.Block.Name = "simboloNorte" Then
                    Return True
                End If
            End If
        Next
    End Function

    Public Function dibujarNorte(ByVal idEntidad As Integer, ByVal pto As VectorDraw.Geometry.gPoint, ByVal angulo As Double, ByVal medida As Integer) As Boolean
        '---------------------------------------------
        'borrar la inserción del bloque con el simbolo
        '---------------------------------------------
        Dim bloqueBorrar As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("simboloNorte")
        'primero borrar el vdInsert
        For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If Not IsNothing(obj) Then
                If obj._TypeName = "vdInsert" Then
                    Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = CType(obj, VectorDraw.Professional.vdFigures.vdInsert)
                    If elVdInsert.Block.Name = "simboloNorte" Then
                        elVdInsert.Invalidate()
                        elVdInsert.Deleted = True
                        elVdInsert.Update()
                        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(elVdInsert)
                        'Exit For
                    End If
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

        'borrar el simbolo en la base de datos:
        borrarSimbolo("norte")


        Dim bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
        bloque.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloque.setDocumentDefaults()
        bloque.Name = "simboloNorte"
        bloque.Origin = pto

        Dim circulo As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        circulo.setDocumentDefaults()
        circulo.Center = pto
        circulo.Radius = medida
        bloque.Entities.AddItem(circulo)

        Dim linea As VectorDraw.Professional.vdFigures.vdLine
        linea = New VectorDraw.Professional.vdFigures.vdLine
        linea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea.setDocumentDefaults()
        linea.StartPoint.x = pto.x - medida
        linea.StartPoint.y = pto.y
        linea.EndPoint.x = pto.x + medida
        linea.EndPoint.y = pto.y
        bloque.Entities.AddItem(linea)
        linea = New VectorDraw.Professional.vdFigures.vdLine
        linea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea.setDocumentDefaults()
        linea.StartPoint.x = pto.x - medida
        linea.StartPoint.y = pto.y
        linea.EndPoint.x = pto.x
        linea.EndPoint.y = pto.y + medida
        bloque.Entities.AddItem(linea)
        linea = New VectorDraw.Professional.vdFigures.vdLine
        linea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea.setDocumentDefaults()
        linea.StartPoint.x = pto.x
        linea.StartPoint.y = pto.y + medida
        linea.EndPoint.x = pto.x + medida
        linea.EndPoint.y = pto.y
        bloque.Entities.AddItem(linea)
        linea = New VectorDraw.Professional.vdFigures.vdLine
        linea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea.setDocumentDefaults()
        linea.StartPoint.x = pto.x
        linea.StartPoint.y = pto.y + medida
        linea.EndPoint.x = pto.x
        linea.EndPoint.y = pto.y - medida
        bloque.Entities.AddItem(linea)

        'frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddItem(bloque)

        Dim insertar As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert
        insertar.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        insertar.setDocumentDefaults()

        insertar.Block = bloque
        insertar.InsertionPoint = pto
        insertar.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(angulo)

        'guardar el simbolo del norte en la base de datos si es la primera vez que lo estoy dibujando.
        'en ese caso idEntidad es 0.
        'Si lo estoy levantando de la base de datos tengo idEntidad <> 0 y no guardo nada.
        If idEntidad = 0 Then
            idEntidad = guardarSimboloBD(bloque.Handle.Value, "norte", pto, angulo, medida)
        Else
            idEntidad = guardarSimboloBD(idEntidad, "norte", pto, angulo, medida)
        End If

        If Not insertar.ToolTip = "" Then
            insertar.ToolTip = ""
        End If
        insertar.ToolTip = "Simbolo: Norte, id:" & idEntidad.ToString

        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(insertar)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

        Return True

    End Function

    Public Function calculoAzimut(ByVal puntoUno As VectorDraw.Geometry.gPoint, ByVal puntoDos As VectorDraw.Geometry.gPoint) As Double

        Dim Deltax = puntoDos.x - puntoUno.x
        Dim Deltay = puntoDos.y - puntoUno.y
        Dim angulo As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(Math.Round(Math.Atan(Deltay / Deltax), 2))

        If Deltax = 0 And Deltay = 0 Then
            Return 0
        End If
        If Deltax = 0 Or Deltay = 0 Then
            If Deltax > 0 And Deltay = 0 Then
                calculoAzimut = 90
            ElseIf Deltax < 0 And Deltay = 0 Then
                calculoAzimut = 270
            ElseIf Deltax = 0 And Deltay > 0 Then
                calculoAzimut = 0
            ElseIf Deltax = 0 And Deltay < 0 Then
                calculoAzimut = 180
            End If
        Else
            If Deltax < 0 And Deltay > 0 Then
                'Caso 1), segundo cuadrante.
                calculoAzimut = 270 + Math.Abs(angulo)
            ElseIf Deltax > 0 And Deltay < 0 Then
                'Caso 2), cuarto cuad.
                calculoAzimut = 90 + Math.Abs(angulo)
            ElseIf Deltax < 0 And Deltay < 0 Then
                'Caso 3), tercer cuad.
                calculoAzimut = 270 - Math.Abs(angulo)
            ElseIf Deltax > 0 And Deltay > 0 Then
                'Caso 4), primer cuad.
                calculoAzimut = 90 - Math.Abs(angulo)
            End If
        End If
        Return Math.Round(calculoAzimut, 2)
    End Function

    Public Function calculoRumbo(ByVal azimut As Double) As String

        Dim contraAZ As Double = azimut

        If contraAZ > (180 * 2) Then
            contraAZ = azimut - (180 * 2)

        End If
        contraAZ = contraAZ - (180 / 2)

        If contraAZ < 0 Then
            contraAZ = (180 * 2) + contraAZ
        End If

        Select Case contraAZ
            Case Is < 180 / 8
                calculoRumbo = "Norte"
            Case Is < 180 * 3 / 8
                calculoRumbo = "NorEste"
            Case Is < 180 * 5 / 8
                calculoRumbo = "Este"
            Case Is < 180 * 7 / 8
                calculoRumbo = "SudEste"
            Case Is < 180 * 9 / 8
                calculoRumbo = "Sur"
            Case Is < 180 * 11 / 8
                calculoRumbo = "SudOeste"
            Case Is < 180 * 13 / 8
                calculoRumbo = "Oeste"
            Case Is < 180 * 15 / 8
                calculoRumbo = "NorOeste"
            Case Is <= 180 * 2
                calculoRumbo = "Norte"
        End Select
        Return calculoRumbo
    End Function

End Module
