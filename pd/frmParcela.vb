Imports System.Drawing.Drawing2D
Imports System
Imports System.Drawing.Text
Imports System.Drawing
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Public Class frmParcela
    Public Circ, Secc, Qta, Chac, Frac, Manz, Nomenc, Quintaletra, Chacraletra, Fracletra, Manzletra As String
    Dim frmNuevo As New Form()
    Dim area As Double
    Dim myString As String '= myDouble.ToString("   #,###.00 m²")
    '===========================================================
    '===========================================================
    Dim CantidadPuntos As Integer
    Dim LapizParcela As New Pen(Brushes.Red, 1)
    Dim LapizLinea As New Pen(Brushes.Yellow, 2)
    Dim ladosA, ladosB As Integer
    Dim ver_lados As String
    Dim GrParcela As Graphics
    'Public area As Decimal
    Dim escala As Integer = 5
    Dim lados_p(3) As Double

    Private Sub InicializarGrafico()
        GrParcela = PB.CreateGraphics()
        GrParcela.Clear(Color.Olive)
        'Hace una escalada
        ' GrMacizo.ScaleTransform(PbxMacizo.Width / 300.0F, PbxMacizo.Height / 300.0F)
        'Seteo el  SmoothingMode para ajustar la calidad del dibujo
        GrParcela.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        '// Se escalan los puntos
        
    End Sub
    Sub CargaPuntosParcela()
        'SeteoMazico()

        '_parcela = New stParcela
        ' _parcela.puntos = {New PointF(91.64, 64.66), New PointF(111.39, 64.23), New PointF(111.39, 25), New PointF(91.64, 25)}
        
        lados_p(0) = Math.Round(modFuncionesMacizo.CalcularModuloRecta(_parcela.puntos(0), _parcela.puntos(1)), 2)
        lados_p(1) = Math.Round(modFuncionesMacizo.CalcularModuloRecta(_parcela.puntos(1), _parcela.puntos(2)), 2)
        lados_p(2) = Math.Round(modFuncionesMacizo.CalcularModuloRecta(_parcela.puntos(2), _parcela.puntos(3)), 2)
        lados_p(3) = Math.Round(modFuncionesMacizo.CalcularModuloRecta(_parcela.puntos(3), _parcela.puntos(0)), 2)
        
        For p = 0 To _parcela.puntos.Length - 1
            _parcela.puntos(p).X = _parcela.puntos(p).X * escala * 2
            _parcela.puntos(p).Y = _parcela.puntos(p).Y * escala * 2
        Next

        'For p = 0 To _parcela.puntos.Length - 1
        '    _parcela.puntos(p).Y = (500 - _parcela.puntos(p).Y)
        'Next

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaPuntosParcela()
        SeteoParcela()
        Circ = nomenclatura.Circunscripcion : Secc = nomenclatura.Seccion
        Qta = nomenclatura.Quinta
        Quintaletra = nomenclatura.QuintaLetra
        Chac = nomenclatura.Chacra
        Chacraletra = nomenclatura.ChacraLetra
        Frac = nomenclatura.Fraccion
        Fracletra = nomenclatura.FraccionLetra
        Manz = nomenclatura.Manzana
        Manzletra = nomenclatura.ManzanaLetra
        Nomenc = "Circ. " & UCase(Trim(Circ))
        If Secc <> "" Then Nomenc = Nomenc & " - Secc. " & UCase(Secc)
        If Qta <> "" Then Nomenc = Nomenc & " - Qta. " & Trim(Qta)
        If Quintaletra <> "" Then Nomenc = Nomenc & Trim(Quintaletra)
        If Chac <> "" Then Nomenc = Nomenc & " - Chac. " & Trim(Chac)
        If Chacraletra <> "" Then Nomenc = Nomenc & Trim(Chacraletra)
        If Frac <> "" Then Nomenc = Nomenc & " - Frac. " & Trim(Frac)
        If Fracletra <> "" Then Nomenc = Nomenc & Trim(Fracletra)
        If Manz <> "" Then Nomenc = Nomenc & " - Manz. " & Trim(Manz)
        If Manzletra <> "" Then Nomenc = Nomenc & Trim(Manzletra)
        LabNomenc.Text = Nomenc
       

        'ListBox1.Items = "Lado 1-2; Rumbo: Noreste - Mide: 32.20 mts, de frente sobre Calle Leandro N. Alem"
      

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        frmNuevo = FormServicios
        frmNuevo.Show()

    End Sub


    Private Sub LabCalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabCalle.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmNuevo = FormServicios
        frmNuevo.Show()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        _parcela.txparcela = tparcela.Text
        _parcela.txsuperficie = area
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        End

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoParcela.Click
        InicializarGrafico()
        area = Math.Round(lados_p(0) * lados_p(1), 2)
        myString = area.ToString("   #,###.00 m²")
        LabSup.Text = myString

        GrParcela.TranslateTransform(-750, -200)
        GrParcela.DrawPolygon(LapizParcela, _parcela.puntos)

        '==============================================================================
        Dim j As Integer
        For k = 0 To _parcela.puntos.Count - 1

            If k = 3 Then
                j = 0
            Else
                j = k + 1
            End If


            '//Se divide por 4 porque 4 es el escalar de los puntos
            'Dim lon As Double = Math.Round(VectorDraw.Geometry.gPoint.Distance2D(punt(0), punt(1)), 2)
            Dim medida As PointF
            Dim fuente = New FontFamily("Arial")
            Dim x1 As Double = _parcela.puntos(k).X - 10 * (_parcela.puntos(j).Y - _parcela.puntos(k).Y) / (lados_p(k) * 8)
            Dim x2 As Double = _parcela.puntos(j).X - 10 * (_parcela.puntos(j).Y - _parcela.puntos(k).Y) / (lados_p(k) * 8)
            Dim y1 As Double = _parcela.puntos(k).Y - 10 * (_parcela.puntos(k).X - (_parcela.puntos(j).X)) / (lados_p(k) * 8)
            Dim y2 As Double = _parcela.puntos(j).Y - 10 * (_parcela.puntos(k).X - _parcela.puntos(k).X) / (lados_p(k) * 8)
            Dim pp = {New PointF(x1, y1), New PointF(x2, y2)}
            'Dim stringFormat As New StringFormat()
            '' DIBUJA EL NOMBRE DE LA CALLE EN
            '' EL PUNTO p1lp y EL ANGULO
            Dim p1lp As PointF
            Dim p2lp As PointF
            Dim EspacioNombreCalle = AnchoEspacioCirculatorio / 1.5
            Dim newPoints = {New PointF(pp(0).X, pp(0).Y), New PointF(pp(1).X, pp(1).Y)}
            Dim angulo As Double = Globals.GetAngle(modFuncionesMacizo.ConvertToGPoint(_parcela.puntos(k)), modFuncionesMacizo.ConvertToGPoint(_parcela.puntos(j)))
            angulo = Convert.ToInt32(Globals.RadiansToDegrees(angulo))
            p1lp = newPoints.ElementAt(0)
            p2lp = newPoints.ElementAt(1)
            Dim PuntosParaCentrar As PointF() = {p1lp, p2lp}


            If (angulo = 180) Then
                angulo = 0

                p1lp.X = p2lp.X
                p1lp.Y = _parcela.puntos(k).Y + (p1lp.Y - _parcela.puntos(k).Y) / 2 - 25 '(VALOR MEDIO PARA TEXTO CENTRADO )
                PuntosParaCentrar(0).X = (_parcela.puntos(k).X + _parcela.puntos(j).X) / 2 '(VALOR MEDIO PARA TEXTO CENTRADO )
                PuntosParaCentrar(0).Y = ((p1lp.Y + p2lp.Y) / 2) '1.8)  ' por 2 es solo para ver mejor la grafica
            Else

                PuntosParaCentrar(0).X = 0
                PuntosParaCentrar(0).Y = 0
                PuntosParaCentrar(0).X = ((p1lp.X + p2lp.X) / 2)  ' por 2 es solo para ver mejor la grafica
                PuntosParaCentrar(0).Y = ((p1lp.Y + p2lp.Y) / 2) ' 2.1)  ' por 2 es solo para ver mejor la grafica
            End If


            'End If


            ' Center each line of text.
            Dim stringFormat As New StringFormat

            stringFormat.Alignment = StringAlignment.Center

            Dim graphics_path As New GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
            graphics_path.AddString("S/M=" & " " & lados_p(k) & " " & "mt", _
                                    fuente, 1, 12, _
                                        PuntosParaCentrar(0), stringFormat)
            Dim rotation_matrix As New Drawing2D.Matrix()
            rotation_matrix.RotateAt(angulo, PuntosParaCentrar(0))
            graphics_path.Transform(rotation_matrix)
            GrParcela.FillPath(Brushes.Black, graphics_path)

            '//Llamo al Sub en el modFuncionesMacizo 
            modFuncionesMacizo.CargoPArcela(PuntosParaCentrar(0), angulo, lados_p(k), fuente)
            '//
            graphics_path.Reset()
            
            tparcela.Enabled = True

        Next
        '==============================================================================
    End Sub

   
    Private Sub PB_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB.Paint

    End Sub

    Private Sub TextBoxParc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tparcela.KeyUp
        'PRUEBA PARA ESCIBIR EL MACIZO
        '//////////////////////
        '///////////////////
        Dim centro As New gPoints
        Dim value As gPoint
        Dim PuntoMacizo1, PuntoMacizo2 As PointF
        For Each pepe As PointF In _parcela.puntos
            centro.Add(pepe.X, pepe.Y, 0.0)
        Next
        value = centro.Centroid()
        PuntoMacizo1 = ConvertToPointF(value)
        PuntoMacizo2 = ConvertToPointF(value)
        PuntoMacizo1.X = PuntoMacizo1.X - 40
        PuntoMacizo1.Y = PuntoMacizo2.Y - 30
        PuntoMacizo2.X = PuntoMacizo2.X - 35
        PuntoMacizo2.Y = PuntoMacizo2.Y + 20

        '//////////////////

        Dim myFont As Font = New Font("Bodoni MT", 1, FontStyle.Strikeout, GraphicsUnit.Pixel, 1)
        Dim myFontFamily As FontFamily = myFont.FontFamily '  FontFamily.GenericMonospace
        Dim graphics_patho As New GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
        'agregamos una cadena al trazado
        graphics_patho.AddString("Sup= " + Trim(myString), myFontFamily, FontStyle.Regular, 11, PuntoMacizo1, StringFormat.GenericDefault)
        graphics_patho.AddString("Parc." + tparcela.Text, myFontFamily, FontStyle.Regular, 15, PuntoMacizo2, StringFormat.GenericDefault)

        'dibujamos el trazado.
        Me.tparcela.CreateGraphics.DrawPath(New Pen(Color.YellowGreen, 2), graphics_patho)
        GrParcela.FillPath(Brushes.White, graphics_patho)
        ' //
        graphics_patho.Reset()

    End Sub

    Private Sub TextBoxParc_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tparcela.MouseClick
        tparcela.Text = ""

    End Sub


    Private Sub TextBoxParc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tparcela.TextChanged

    End Sub
End Class
