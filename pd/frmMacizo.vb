Imports System.Drawing.Drawing2D
Imports System
Imports System.Drawing.Text
Imports System.Drawing
Imports VectorDraw.Geometry
Imports VectorDraw.Render


Public Class frmMacizo
    Dim CantidadPuntos As Integer
    Dim LapizMacizo As New Pen(Brushes.Red, 1)
    Dim LapizLinea As New Pen(Brushes.Yellow, 2)
    Dim LapizNombreCalle As New Pen(Color.White, 1)
    Dim ladosA, ladosB As Integer
    Dim ver_lados As String
    Dim GrMacizo As Graphics
    Dim linea As Graphics
    Dim Escalar As Integer = 3
    Dim EscalarAnchoCalle As Integer = 2


    
#Region "BORRAR"
    'Dim _macizo As stMacizo

    Sub CargaPuntosAlMacizo()

        ' _macizo = New stMacizo()
        '_macizo.puntos = {New PointF(25, 111.7), New PointF(111.76, 111.7), New PointF(111.76, 25), New PointF(25, 25)}

        '// Se escalan los puntos
        For p = 0 To _macizo.puntos.Length - 1
            _macizo.puntos(p).X = _macizo.puntos(p).X * Escalar
            _macizo.puntos(p).Y = _macizo.puntos(p).Y * Escalar
        Next
        For p = 0 To _macizo.puntos.Length - 1
            _macizo.puntos(p).Y = (550 - _macizo.puntos(p).Y)
        Next
        '//






    End Sub



#End Region


    Private Sub BtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiguiente.Click
        If Not IsNumeric(TxtAnchoEspacioCirculatorio.Text) Then

            MsgBox("Completar Ancho de Calle", , "Atención")
            TxtAnchoEspacioCirculatorio.Clear()
            TxtAnchoEspacioCirculatorio.Focus()
            Exit Sub
        End If

        AnchoEspacioCirculatorio = Replace(TxtAnchoEspacioCirculatorio.Text, ",", ".") * EscalarAnchoCalle
        NombreEspacioCirculatorio = TxtNombreEspacioCirculatorio.Text


        Dim p1 As PointF
        Dim p2 As PointF
        Dim p1LineaMarcada As PointF
        Dim p2LineaMarcada As PointF

        'For i As Integer = 0 To CantidadPuntos - 1


        '    If (i = CantidadPuntos - 1) Then
        '        p1 =  _macizo.puntos.ElementAt(i)
        '        p2 =  _macizo.puntos.ElementAt(0)
        '    Else
        '        p1 =  _macizo.puntos.ElementAt(i)
        '        p2 =  _macizo.puntos.ElementAt(i + 1)

        '    End If
        '    DibujarLineaIndicadora(p1, p2)
        '    Dim frmPopUp = New frmEspacioCirculatorio()
        '    frmPopUp.LblLado.Text = "Lado " + (i + 1).ToString()
        '    frmPopUp.ShowDialog()
        '    If (modVariables.CancelarDibujoEspacioCirculatorio) Then
        '        GrMacizo.Clear(BackColor)
        '        Return
        '    Else
        '        DibujarEspacioCirculatorio(p1, p2)
        '    End If
        'Next

        ' Nuevo para ver el boton siguiente 06/08/2012


        If ContadorLados < CantidadPuntos Then
            '/// Muestra Los LADOS en la LdelosLados
            If ContadorLados + 1 = CantidadPuntos Then
                ladosA = CantidadPuntos
                ladosB = 1
                'ver_lados = ladosA & " >>> " & ladosB
                LdelosLados.Text = ladosA
                LdelosLados2.Text = ladosB
            Else
                If ContadorLados + 2 < CantidadPuntos Then
                    ladosA = ContadorLados + 2
                    ladosB = ladosA + 1
                    LdelosLados.Text = ladosA
                    LdelosLados2.Text = ladosB

                End If
            End If
            '//////////////////////////////////////////////

            '///Etiqueta donde se muestran los metros
            Lmt.Text = Math.Round(DistanciaCalle / Escalar, 2) & "  " & "mts"
            '///

            If ContadorLados = 0 Then
                p1 = _macizo.puntos.ElementAt(0)
                p2 = _macizo.puntos.ElementAt(ContadorLados + 1)
                '///Pinta la linea del siguiente
                p1LineaMarcada = _macizo.puntos.ElementAt(0 + 1)
                p2LineaMarcada = _macizo.puntos.ElementAt(ContadorLados + 2)
                BorraLinidaIndicadora(_macizo.puntos.ElementAt(0), _macizo.puntos.ElementAt(ContadorLados + 1))
                DibujarLineaIndicadora(p1LineaMarcada, p2LineaMarcada)
                '//Saca la distancia de cada Lado
                DistanciaCalle = Math.Round(VectorDraw.Geometry.gPoint.Distance2D(ConvertToGPoint(_macizo.puntos.ElementAt(0 + 1)), _
                                                              ConvertToGPoint(_macizo.puntos.ElementAt(ContadorLados + 2))), 2)

                '///


            ElseIf (ContadorLados = CantidadPuntos - 1) Then
                p1 = _macizo.puntos.ElementAt(ContadorLados)
                p2 = _macizo.puntos.ElementAt(0)


                '///Pinta la linea del siguiente
                p1LineaMarcada = _macizo.puntos.ElementAt(ContadorLados)
                p2LineaMarcada = _macizo.puntos.ElementAt(0)

                DibujarLineaIndicadora(p1LineaMarcada, p2LineaMarcada)
                BorraLinidaIndicadora(_macizo.puntos.ElementAt(ContadorLados), _macizo.puntos.ElementAt(0))
                '//Saca la distancia de cada Lado
                DistanciaCalle = Math.Round(VectorDraw.Geometry.gPoint.Distance2D(ConvertToGPoint(_macizo.puntos.ElementAt(ContadorLados)), _
                                                              ConvertToGPoint(_macizo.puntos.ElementAt(0))), 2)
                '///


            Else

                p1 = _macizo.puntos.ElementAt(ContadorLados)
                p2 = _macizo.puntos.ElementAt(ContadorLados + 1)

                '///Pinta la linea del siguiente

                p1LineaMarcada = _macizo.puntos.ElementAt(ContadorLados + 1)

                If ContadorLados = _macizo.puntos.Count - 2 Then
                    p2LineaMarcada = _macizo.puntos.ElementAt(0)
                    BorraLinidaIndicadora(_macizo.puntos.ElementAt(ContadorLados), _macizo.puntos.ElementAt(ContadorLados + 1))
                    DibujarLineaIndicadora(p1LineaMarcada, p2LineaMarcada)
                    '//Saca la distancia de cada Lado
                    DistanciaCalle = Math.Round(VectorDraw.Geometry.gPoint.Distance2D(ConvertToGPoint(_macizo.puntos.ElementAt(ContadorLados + 1)), _
                                                              ConvertToGPoint(_macizo.puntos.ElementAt(0))), 2)


                Else
                    p2LineaMarcada = _macizo.puntos.ElementAt(ContadorLados + 2)
                    DistanciaCalle = Math.Round(VectorDraw.Geometry.gPoint.Distance2D(ConvertToGPoint(_macizo.puntos.ElementAt(ContadorLados + 1)), _
                                                              ConvertToGPoint(_macizo.puntos.ElementAt(ContadorLados + 2))), 2)

                End If

                BorraLinidaIndicadora(_macizo.puntos.ElementAt(ContadorLados), _macizo.puntos.ElementAt(ContadorLados + 1))
                DibujarLineaIndicadora(p1LineaMarcada, p2LineaMarcada)

                '///
            End If
           
            DibujarEspacioCirculatorio(p1, p2)
            ContadorLados += 1
        End If
        If ContadorLados = CantidadPuntos Then BtnSiguiente.Enabled = False

    End Sub

    Private Sub macizo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaPuntosAlMacizo()
        CantidadPuntos = _macizo.puntos.Length
        InicializarGrafico()
        CbxTipoEspacioCirculatorio.SelectedIndex = 0

        'Levanto de la clase la Nomenclatura
        '===================================
        If IsNothing(nomenclatura.Circunscripcion) Then
        Else : Tcir.Text = nomenclatura.Circunscripcion
        End If

        If IsNothing(nomenclatura.Seccion) Then
        Else : Tsec.Text = nomenclatura.Seccion
        End If

        If IsNothing(nomenclatura.Chacra) Then
        Else : Tch_numero.Text = nomenclatura.Chacra
        End If

        If IsNothing(nomenclatura.ChacraLetra) Then
        Else : Tch_letra.Text = nomenclatura.ChacraLetra
        End If

        If IsNothing(nomenclatura.Quinta) Then
        Else : Tqui.Text = nomenclatura.Quinta
        End If

        If IsNothing(nomenclatura.QuintaLetra) Then
        Else : Tqui_letra.Text = nomenclatura.QuintaLetra
        End If

        If IsNothing(nomenclatura.Fraccion) Then
        Else : Tfrac.Text = nomenclatura.Fraccion
        End If

        If IsNothing(nomenclatura.FraccionLetra) Then
        Else : Tfrac_letra.Text = nomenclatura.FraccionLetra
        End If

        If IsNothing(nomenclatura.Manzana) Then
        Else : Tmanz.Text = nomenclatura.Manzana
        End If
        If IsNothing(nomenclatura.ManzanaLetra) Then
        Else : Tmanz_letra.Text = nomenclatura.ManzanaLetra
        End If
        ' Se carga hasta manzana en el Macizo
        '================================================



    End Sub

    Private Sub InicializarGrafico()
        GrMacizo = PbxMacizo.CreateGraphics()
        GrMacizo.Clear(Color.Olive)
        'Hace una escalada
        'GrMacizo.ScaleTransform(PbxMacizo.Width / 10, PbxMacizo.Height / 10)
        'Seteo el  SmoothingMode para ajustar la calidad del dibujo
        GrMacizo.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        GrMacizo.TranslateTransform(100, -50)

    End Sub


    Private Sub BtnCargarMacizo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargarMacizo.Click
        Dim st As StringFormat
        Dim p1 As PointF
        Dim p2 As PointF
        Dim cargo_nome As String

        If Not Tch_numero.Text Is Nothing Then
            cargo_nome = "Ch" & " " & Tch_numero.Text & " " & Tch_letra.Text & " "
        End If

        If Not Tqui.Text Is Nothing Then
            cargo_nome = cargo_nome & "Quinta " & Tqui.Text & "" & Tqui_letra.Text & " "
        End If
        If Not Tfrac.Text Is Nothing Then
            cargo_nome = cargo_nome & "Fracc " & Tfrac.Text & "" & Tfrac_letra.Text & " "
        End If
        If Not Tmanz.Text Is Nothing Then
            cargo_nome = cargo_nome & "Mza " & Tmanz.Text & "" & Tmanz_letra.Text & " "
        End If



        SeteoMazico()
        BtnSiguiente.Enabled = True
        InicializarGrafico()
        GrMacizo.DrawPolygon(LapizMacizo, _macizo.puntos)
        st = StringFormat.GenericTypographic

        For i = 0 To _macizo.puntos.Length - 1
            GrMacizo.DrawString(i + 1, Me.Font, Brushes.White, New PointF(_macizo.puntos(i).X, _macizo.puntos(i).Y), st)
        Next
        CantidadPuntos = _macizo.puntos.Length
        ContadorLados = 0
        p1 = _macizo.puntos.ElementAt(0)
        p2 = _macizo.puntos.ElementAt(1)
        DibujarLineaIndicadora(p1, p2)
        LdelosLados.Text = ""
        ladosA = 1
        ladosB = ladosA + 1
        LdelosLados.Text = ladosA
        LdelosLados2.Text = ladosB
        DistanciaCalle = VectorDraw.Geometry.gPoint.Distance2D(ConvertToGPoint(_macizo.puntos.ElementAt(0)), _
                                                                        ConvertToGPoint(_macizo.puntos.ElementAt(1)))
        Lmt.Text = Math.Round(DistanciaCalle, 2) / Escalar & " " & "mts"



        '//LEVANTO LOS PUNTOS, SACO EL CONTROIDE DEL POLIGONO
        Dim centro As New gPoints
        Dim value As gPoint
        Dim PuntoMacizo As PointF
        For Each pepe As PointF In _macizo.puntos
            centro.Add(pepe.X, pepe.Y, 0.0)
        Next
        value = centro.Centroid()
        PuntoMacizo = ConvertToPointF(value)
        PuntoMacizo.X = PuntoMacizo.X - (PuntoMacizo.X / 2)
        'PRUEBA PARA ESCIBIR EL MACIZO
        '//////////////////////
        Dim myFont As Font = New Font("Bodoni MT", 1, FontStyle.Strikeout, GraphicsUnit.Pixel, 1)
        Dim myFontFamily As FontFamily = myFont.FontFamily '  FontFamily.GenericMonospace
        Dim graphics_path As New GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
        'agregamos una cadena al trazado
        graphics_path.AddString(cargo_nome, myFontFamily, FontStyle.Underline, 10, PuntoMacizo, StringFormat.GenericTypographic)
        'dibujamos el trazado.
        Me.Tsec.CreateGraphics.DrawPath(New Pen(Color.YellowGreen, 2), graphics_path)
        GrMacizo.FillPath(Brushes.White, graphics_path)
        ' //
        graphics_path.Reset()




    End Sub

    Private Sub DibujarLineaIndicadora(ByVal p1 As PointF, ByVal p2 As PointF)

        GrMacizo.DrawLine(LapizLinea, p1, p2)

    End Sub

    Private Function DibujarEspacioCirculatorio(ByVal p1 As PointF, ByVal p2 As PointF) As Integer
        DibujarParalela(p1, p2, AnchoEspacioCirculatorio)
        DibujarNombreCalle(p1, p2, NombreEspacioCirculatorio)
        DibujarAnchoCalle(p1, p2, AnchoEspacioCirculatorio)
        DibujarMedidaCalle(p1, p2, 5)
    End Function

    Private Sub DibujarParalela(ByVal p1 As PointF, ByVal p2 As PointF, ByVal AnchoEspacioCirculatorio As Double)
        Dim p1lp As PointF
        Dim p2lp As PointF
        ''//Escalo lo resultados
        'p1.X = p1.X * 1.5
        'p1.Y = p1.Y * 1.5
        'p2.X = p1.X * 1.5
        'p2.Y = p1.Y * 1.5


        Dim newPoints As PointF() = ObtenerPuntosLineaParalela(p1, p2, AnchoEspacioCirculatorio)
        p1lp = newPoints.ElementAt(0)
        p2lp = newPoints.ElementAt(1)
       
        GrMacizo.DrawLine(LapizMacizo, p1lp, p2lp)
    End Sub

    Private Sub DibujarNombreCalle(ByVal p1 As PointF, ByVal p2 As PointF, ByVal NombreEspacioCirculatorio As String)

        Dim stringFormat As New StringFormat()
        ' DIBUJA EL NOMBRE DE LA CALLE EN
        ' EL PUNTO p1lp y EL ANGULO
        Dim p1lp As PointF
        Dim p2lp As PointF
        Dim EspacioNombreCalle = AnchoEspacioCirculatorio / 1.5
        Dim newPoints As PointF() = ObtenerPuntosLineaParalela(p1, p2, EspacioNombreCalle)
        Dim angulo As Double = Globals.GetAngle(modFuncionesMacizo.ConvertToGPoint(p1), modFuncionesMacizo.ConvertToGPoint(p2))
        angulo = Convert.ToInt32(Globals.RadiansToDegrees(angulo))
        p1lp = newPoints.ElementAt(0)
        p2lp = newPoints.ElementAt(1)
        Dim PuntosParaCentrar As PointF() = {p1lp, p2lp}


        If (angulo = 180) Then
            angulo = 0

            p1lp.X = p2lp.X
            p1lp.Y = p1.Y + (p1lp.Y - p1.Y) / 2
            PuntosParaCentrar(0).X = (p1.X + p2.X) / 2 '(VALOR MEDIO PARA TEXTO CENTRADO )
            PuntosParaCentrar(0).Y = ((p1lp.Y + p2lp.Y) / 2)  ' por 2 es solo para ver mejor la grafica
        Else

            PuntosParaCentrar(0).X = 0
            PuntosParaCentrar(0).Y = 0
            PuntosParaCentrar(0).X = ((p1lp.X + p2lp.X) / 2)  ' por 2 es solo para ver mejor la grafica
            PuntosParaCentrar(0).Y = ((p1lp.Y + p2lp.Y) / 2)  ' por 2 es solo para ver mejor la grafica
        End If

        'If (angulo = 0.0) Then
        '    angulo = 0
        '    p1lp.X = p2lp.X
        '    p1lp.Y = p1.Y + (p1lp.Y - p1.Y) / 2
        '    PuntosParaCentrar(0).X = (p1lp.X + p2lp.X) / 2
        '    PuntosParaCentrar(0).Y = (p1lp.Y + p2lp.Y) / 2
        'End If


        ' Center each line of text.
        Dim myfontStyle As Integer = CInt(FontStyle.Regular)

        stringFormat.Alignment = StringAlignment.Center


        Dim graphics_path As New GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
        Dim fuente = New FontFamily("Arial")


        graphics_path.AddString(NombreEspacioCirculatorio, _
                                fuente, 0, 12, _
                                     PuntosParaCentrar(0), stringFormat)


        Dim rotation_matrix As New Drawing2D.Matrix()
        rotation_matrix.RotateAt(angulo, PuntosParaCentrar(0))
        graphics_path.Transform(rotation_matrix)
        GrMacizo.FillPath(Brushes.Black, graphics_path)
        '//Llamo al Sub en el modFuncionesMacizo 
        '   modFuncionesMacizo.CargoEstructuraMacizoNombreCalle(PuntosParaCentrar(0), angulo, NombreEspacioCirculatorio, fuente)
        '//
        graphics_path.Reset()
    End Sub

    'Private Function ObtenerPuntosLineaParalela(ByVal p1 As PointF, ByVal p2 As PointF, ByVal Offset As Double) As PointF()
    '    Dim lon As Double = modFuncionesMacizo.CalcularModuloRecta(p1, p2)

    '    Dim x1 As Double = p1.X + Offset * (p2.Y - p1.Y) / lon
    '    Dim x2 As Double = p2.X + Offset * (p2.Y - p1.Y) / lon
    '    Dim y1 As Double = p1.Y + Offset * (p1.X - p2.X) / lon
    '    Dim y2 As Double = p2.Y + Offset * (p1.X - p2.X) / lon
    '    Return {New PointF(x1, y1), New PointF(x2, y2)}


    'End Function


    Private Sub DibujarAnchoCalle(ByVal p1 As PointF, ByVal p2 As PointF, ByVal ancho As Double)
        ' DIBUJA EL NOMBRE DE LA CALLE EN  EL PUNTO p1lp y EL ANGULO
        Dim stringFormat As New StringFormat()
        Dim p1lp As PointF
        Dim p2lp As PointF
        Dim EspacioNombreCalle = AnchoEspacioCirculatorio / 1.5
        Dim newPoints As PointF() = ObtenerPuntosLineaParalela(p1, p2, EspacioNombreCalle)
        Dim angulo As Double = Globals.GetAngle(modFuncionesMacizo.ConvertToGPoint(p1), modFuncionesMacizo.ConvertToGPoint(p2))
        Dim PuntosParaCentrar As PointF() = {p1lp, p2lp}
        Dim anchos As String = Math.Round(AnchoEspacioCirculatorio, 2)
        Dim graphics_path As New GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
        Dim rotation_matrix As New Drawing2D.Matrix()
        Dim fuente = New FontFamily("Arial")
        angulo = Convert.ToInt32(Globals.RadiansToDegrees(angulo))
        p1lp = newPoints.ElementAt(0)
        p2lp = newPoints.ElementAt(1)

        If (angulo = 180) Then
            angulo = 0

            p1lp.X = p2lp.X
            p1lp.Y = p1.Y + (p1lp.Y - p1.Y) / 2
            PuntosParaCentrar(0).X = p1lp.X * 1.7 '(VALOR MEDIO PARA TEXTO CENTRADO )
            PuntosParaCentrar(0).Y = (p1lp.Y + p2lp.Y) / 2
        Else

            PuntosParaCentrar(0).X = (p1lp.X + p2lp.X) / 2
            PuntosParaCentrar(0).Y = (p1lp.Y + p2lp.Y) / 2

        End If

        'If (angulo = 0.0) Then
        '    angulo = 0
        '    p1lp.X = p2lp.X
        '    p1lp.Y = p1.Y + (p1lp.Y - p1.Y) / 2
        '    PuntosParaCentrar(0).X = (p1lp.X + p2lp.X) / 2
        '    PuntosParaCentrar(0).Y = (p1lp.Y + p2lp.Y) / 2
        'End If

        If anchos.Length >= 4 Then

            stringFormat.Alignment = StringAlignment.Center
        Else

            stringFormat.Alignment = StringAlignment.Far
        End If


        graphics_path.AddString(anchos / EscalarAnchoCalle, _
                                fuente, 3, 9, _
                                    p1lp, stringFormat)


        If angulo = 270 Then
            angulo = 270 - 180

            rotation_matrix.RotateAt(angulo + 270, p1lp)

        Else
            rotation_matrix.RotateAt(angulo + 270, p1lp)
        End If
        
        graphics_path.Transform(rotation_matrix)
        GrMacizo.FillPath(Brushes.Black, graphics_path)
        '//Llamo al Sub en el modFuncionesMacizo 
        ' modFuncionesMacizo.CargoEstructuraMacizoAnchoCalle(p1lp, angulo + 270, anchos / EscalarAnchoCalle, fuente)
        '//
        graphics_path.Reset()
    End Sub

    Private Sub BorraLinidaIndicadora(ByVal p1 As PointF, ByVal p2 As PointF)
        GrMacizo.DrawLine(LapizMacizo, p1, p2)
    End Sub

    Private Sub DibujarMedidaCalle(ByVal p1 As PointF, ByVal p2 As PointF, ByVal m As Integer)

        '//Se divide por 4 porque 4 es el escalar de los puntos
        Dim lon As Double = Math.Round(modFuncionesMacizo.CalcularModuloRecta(p1, p2), 2) / Escalar
        ' Dim medida As PointF
        Dim fuente = New FontFamily("Arial")
        Dim x1 As Double = p1.X - 10 * (p2.Y - p1.Y) / (lon * 8)
        Dim x2 As Double = p2.X - 10 * (p2.Y - p1.Y) / (lon * 8)
        Dim y1 As Double = p1.Y - 10 * (p1.X - p2.X) / (lon * 8)
        Dim y2 As Double = p2.Y - 10 * (p1.X - p2.X) / (lon * 8)
        ' Return {New PointF(x1, y1), New PointF(x2, y2)}
        Dim pp = {New PointF(x1, y1), New PointF(x2, y2)}

        ' medida = ConvertToPointF(VectorDraw.Geometry.gPoint.MidPoint(ConvertToGPoint(pp(0)), ConvertToGPoint(pp(1))))

        '//////////////////////
        Dim stringFormat As New StringFormat()
        ' DIBUJA EL NOMBRE DE LA CALLE EN
        ' EL PUNTO p1lp y EL ANGULO
        Dim p1lp As PointF
        Dim p2lp As PointF
        Dim EspacioNombreCalle = AnchoEspacioCirculatorio / 1.5
        Dim newPoints = {New PointF(pp(0).X, pp(0).Y), New PointF(pp(1).X, pp(1).Y)}

        'newPoints.ElementAt(0) = p1
        'newPoints.ElementAt(1) = p2

        Dim angulo As Double = Globals.GetAngle(modFuncionesMacizo.ConvertToGPoint(p1), modFuncionesMacizo.ConvertToGPoint(p2))
        angulo = Convert.ToInt32(Globals.RadiansToDegrees(angulo))
        p1lp = newPoints.ElementAt(0)
        p2lp = newPoints.ElementAt(1)
        Dim PuntosParaCentrar As PointF() = {p1lp, p2lp}


        If (angulo = 180) Then
            angulo = 0

            p1lp.X = p2lp.X
            p1lp.Y = p1.Y + (p1lp.Y - p1.Y) / 2 - 25 '(VALOR MEDIO PARA TEXTO CENTRADO )
            PuntosParaCentrar(0).X = (p1.X + p2.X) / 2 '(VALOR MEDIO PARA TEXTO CENTRADO )
            PuntosParaCentrar(0).Y = ((p1lp.Y + p2lp.Y) / 2)  ' por 2 es solo para ver mejor la grafica
        Else

            PuntosParaCentrar(0).X = 0
            PuntosParaCentrar(0).Y = 0
            PuntosParaCentrar(0).X = ((p1lp.X + p2lp.X) / 2)  ' por 2 es solo para ver mejor la grafica
            PuntosParaCentrar(0).Y = ((p1lp.Y + p2lp.Y) / 2)  ' por 2 es solo para ver mejor la grafica
        End If

        'If (angulo = 0.0) Then
        '    angulo = 0
        '    p1lp.X = p2lp.X
        '    p1lp.Y = p1.Y + (p1lp.Y - p1.Y) / 2
        '    PuntosParaCentrar(0).X = (p1lp.X + p2lp.X) / 2
        '    PuntosParaCentrar(0).Y = (p1lp.Y + p2lp.Y) / 2
        'End If


        ' Center each line of text.
        stringFormat.Alignment = StringAlignment.Center
        Dim graphics_path As New GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
        graphics_path.AddString("S/C=" & " " & lon & " " & "mt", _
                                fuente, 1, 12, _
                                    PuntosParaCentrar(0), stringFormat)
        Dim rotation_matrix As New Drawing2D.Matrix()
        rotation_matrix.RotateAt(angulo, PuntosParaCentrar(0))
        graphics_path.Transform(rotation_matrix)
        GrMacizo.FillPath(Brushes.Black, graphics_path)

        '//Llamo al Sub en el modFuncionesMacizo 
        ' modFuncionesMacizo.CargoEstructuraMacizoMedidaCalle(PuntosParaCentrar(0), angulo, lon, fuente)
        '//
        graphics_path.Reset()



    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        For p = 0 To _macizo.puntos.Length - 1
            _macizo.puntos(p).Y = (550 - _macizo.puntos(p).Y)
        Next
        

        Me.Close()


    End Sub
End Class
