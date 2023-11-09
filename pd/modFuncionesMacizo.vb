Imports VectorDraw.Geometry
Imports System.Drawing.Drawing2D

Public Module modFuncionesMacizo

    Public Function PtoNormal(ByVal xP1, ByVal yP1, ByVal xP2, ByVal yP2, ByVal dist, ByVal signo) As PointF
        'Determina el punto normal a la recta P1 P2
        'ubicado a la distancia "dist" del punto P2
        'Que este a derecha o izquierda depende del signo (+1 ó -1)
        Dim dx As Double
        Dim dy As Double
        Dim dxx As Double
        Dim dyy As Double
        Dim distref As Double
        dx = xP2 - xP1 : dy = yP2 - yP1
        distref = ((Math.Abs(dx) ^ 2 + Math.Abs(dy) ^ 2)) ^ (1 / 2)
        dxx = (dist / distref) * dx
        dyy = (dist / distref) * dy
        Return New PointF((xP2 - dyy * signo), yP2 + dxx * signo)
    End Function

    Public Function PuntoNormal(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal dist As Single, ByVal signo As Integer) As PointF
        Dim dx As Double
        Dim dy As Double
        Dim modulo As Double
        Dim dxx As Double
        Dim dyy As Double
        'Determina el punto normal a la recta P1 P2
        'ubicado a la distancia "dist" del punto P2
        'Que este a derecha o izquierda depende del signo (+1 ó -1)

        dx = CalcularDiferencial(x1, x2) : dy = CalcularDiferencial(y1, y2)
        modulo = CalcularModuloRecta(dx, dy)
        dxx = (dist / modulo) * dx
        dyy = (dist / modulo) * dy

        Return New PointF((x2 - dyy * signo), y2 + dxx * signo)
    End Function

    Public Function PuntoNormal(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal dist As Single) As PointF
        Dim dx As Double
        Dim dy As Double
        Dim modulo As Double
        Dim dxx As Double
        Dim dyy As Double
        'Determina el punto normal a la recta P1 P2
        'ubicado a la distancia "dist" del punto P2
        'Que este a derecha o izquierda depende del signo (+1 ó -1)

        dx = CalcularDiferencial(x1, x2) : dy = CalcularDiferencial(y1, y2)
        modulo = CalcularModuloRecta(dx, dy)
        dxx = (dist / modulo) * dx
        dyy = (dist / modulo) * dy

        Return New PointF((x2 - dyy), y2 + dxx)
    End Function

    Public Function CalcularAngulo(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Double
        Dim angulo As Double
        Dim dx, dy As Double
        dx = CalcularDiferencial(x1, x2)
        dy = CalcularDiferencial(y1, y2)
        angulo = Math.Atan(dy / dx)
        Return angulo
    End Function

    Public Function CalcularDiferencial(ByVal x1 As Integer, ByVal x2 As Integer) As Double
        Return Math.Abs(x1 - x2)
    End Function

    Public Function CalcularModuloRecta(ByVal Dx As Double, ByVal Dy As Double) As Double
        Return (Dx ^ 2 + Dy ^ 2) ^ (1 / 2)
    End Function

    Public Function CalcularModuloRecta(ByVal P1 As PointF, ByVal P2 As PointF) As Double
        Return Math.Sqrt((P1.X - P2.X) ^ 2 + (P1.Y - P2.Y) ^ 2)
    End Function

    Public Function Azimut(ByVal Dx, ByVal Dy, ByVal Az)
        If Dx = 0 And Dy = 0 Then Exit Function
        If Dx = 0 Or Dy = 0 Then
            If Dx = 0 And Dy > 0 Then Az = Math.PI / 2
            If Dx = 0 And Dy < 0 Then Az = 3 * Math.PI / 2
            If Dx > 0 And Dy = 0 Then Az = 0
            If Dx < 0 And Dy = 0 Then Az = Math.PI
            Exit Function
        End If
        Az = Math.Atan(Math.Abs(Dy) / Math.Abs(Dx))
        If Dy < 0 And Dx > 0 Then Az = 2 * Math.PI - Az
        If Dy > 0 And Dx < 0 Then Az = Math.PI - Az
        If Dy < 0 And Dx < 0 Then Az = Math.PI + Az
        Return Az
    End Function

    Public Function PointInPolygon(ByVal polygon() As PointF, ByVal point As PointF) As Boolean
        ' Get the angle between the point and the
        ' first and last vertices.
        Dim X As Single = point.X
        Dim Y As Single = point.Y
        Dim max_point As Integer = polygon.Length - 1
        Dim total_angle As Single = GetAngle(polygon(max_point).X, polygon(max_point).Y, X, Y, polygon(0).X, polygon(0).Y)

        ' Add the angles from the point
        ' to each other pair of vertices.
        For i As Integer = 0 To max_point - 1
            total_angle += GetAngle(polygon(i).X, polygon(i).Y, X, Y, polygon(i + 1).X, polygon(i + 1).Y)
        Next i

        ' The total angle should be 2 * PI or -2 * PI if
        ' the point is in the polygon and close to zero
        ' if the point is outside the polygon.
        Return Math.Abs(total_angle) > 0.000001
    End Function

    Public Function GetAngle(ByVal Ax As Single, ByVal Ay As Single, ByVal Bx As Single, ByVal By As Single, ByVal Cx As Single, ByVal Cy As Single) As Single
        Dim dot_product As Single
        Dim cross_product As Single

        ' Get the dot product and cross product.
        dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy)
        cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy)

        ' Calculate the angle.
        GetAngle = ATan2(cross_product, dot_product)
    End Function

    ' Return the angle with tangent opp/hyp. The returned
    ' value is between PI and -PI.
    Public Function ATan2(ByVal opp As Single, ByVal adj As Single) As Single
        Dim angle As Single

        ' Get the basic angle.
        If Math.Abs(adj) < 0.0001 Then
            angle = Math.PI / 2
        Else
            angle = Math.Abs(Math.Atan(opp / adj))
        End If

        ' See if we are in quadrant 2 or 3.
        If adj < 0 Then
            ' angle > PI/2 or angle < -PI/2.
            angle = Math.PI - angle
        End If

        ' See if we are in quadrant 3 or 4.
        If opp < 0 Then
            angle = -angle
        End If

        ' Return the result.
        ATan2 = angle
    End Function

    Private Function DotProduct(ByVal Ax As Single, ByVal Ay As Single, ByVal Bx As Single, ByVal By As Single, ByVal Cx As Single, ByVal Cy As Single) As Single
        Dim BAx As Single
        Dim BAy As Single
        Dim BCx As Single
        Dim BCy As Single

        ' Get the vectors' coordinates.
        BAx = Ax - Bx
        BAy = Ay - By
        BCx = Cx - Bx
        BCy = Cy - By

        ' Calculate the dot product.
        DotProduct = BAx * BCx + BAy * BCy
    End Function

    Public Function CrossProductLength(ByVal Ax As Single, ByVal Ay As Single, ByVal Bx As Single, ByVal By As Single, ByVal Cx As Single, ByVal Cy As Single) As Single
        Dim BAx As Single
        Dim BAy As Single
        Dim BCx As Single
        Dim BCy As Single

        ' Get the vectors' coordinates.
        BAx = Ax - Bx
        BAy = Ay - By
        BCx = Cx - Bx
        BCy = Cy - By

        ' Calculate the Z coordinate of the cross product.
        CrossProductLength = BAx * BCy - BAy * BCx
    End Function

    Function CalcularPuntoMedio(ByVal p1 As PointF, ByVal p2 As PointF) As PointF
        Return ConvertToPointF(gPoint.MidPoint(ConvertToGPoint(p1), ConvertToGPoint(p2)))
    End Function
    Public Function ObtenerPuntosLineaParalela(ByVal p1 As PointF, ByVal p2 As PointF, ByVal Offset As Double) As PointF()
        Dim lon As Double = modFuncionesMacizo.CalcularModuloRecta(p1, p2)

        Dim x1 As Double = p1.X + Offset * (p2.Y - p1.Y) / lon
        Dim x2 As Double = p2.X + Offset * (p2.Y - p1.Y) / lon
        Dim y1 As Double = p1.Y + Offset * (p1.X - p2.X) / lon
        Dim y2 As Double = p2.Y + Offset * (p1.X - p2.X) / lon
        Return {New PointF(x1, y1), New PointF(x2, y2)}


    End Function

    Function ConvertToGPoint(ByVal p As PointF) As gPoint
        Return New gPoint(p.X, p.Y)
    End Function

    Function ConvertToPointF(ByVal p As gPoint) As PointF
        Return New PointF(p.x, p.y)
    End Function


    Public Sub CargoEstructuraMacizoNombreCalle(ByVal punto As gPoint, ByVal angulo As Object, _
                                          ByVal cadena As String, ByVal estilo As FontFamily)
        ReDim Preserve _macizo.txMedidaNombreCalle_pto(UBound(_macizo.txMedidaNombreCalle_pto) + 1)
        _macizo.txMedidaNombreCalle_pto(UBound(_macizo.txMedidaNombreCalle_pto)).X = punto.X
        _macizo.txMedidaNombreCalle_pto(UBound(_macizo.txMedidaNombreCalle_pto)).Y = punto.Y

        ReDim Preserve _macizo.txMedidaNombreCalle_angulo(UBound(_macizo.txMedidaNombreCalle_angulo) + 1)
        _macizo.txMedidaNombreCalle_angulo(UBound(_macizo.txMedidaNombreCalle_angulo)) = angulo

        ReDim Preserve _macizo.txMedidaNombreCalle_contenbido(UBound(_macizo.txMedidaNombreCalle_contenbido) + 1)
        _macizo.txMedidaNombreCalle_contenbido(UBound(_macizo.txMedidaNombreCalle_contenbido)) = cadena

        ReDim Preserve _macizo.txMedidaNombreCalle_estilo(UBound(_macizo.txMedidaNombreCalle_estilo) + 1)
        _macizo.txMedidaNombreCalle_estilo(UBound(_macizo.txMedidaNombreCalle_estilo)) = estilo



    End Sub

    Public Sub CargoEstructuraMacizoAnchoCalle(ByVal punto As gPoint, ByVal angulo As Object, _
                                          ByVal cadena As String, ByVal estilo As FontFamily)

        ReDim Preserve _macizo.txMedidaAnchoCalle_pto(UBound(_macizo.txMedidaAnchoCalle_pto) + 1)
        _macizo.txMedidaAnchoCalle_pto(UBound(_macizo.txMedidaAnchoCalle_pto)).X = punto.X
        _macizo.txMedidaAnchoCalle_pto(UBound(_macizo.txMedidaAnchoCalle_pto)).Y = punto.Y

        ReDim Preserve _macizo.txMedidaAnchoCalle_angulo(UBound(_macizo.txMedidaAnchoCalle_angulo) + 1)
        _macizo.txMedidaAnchoCalle_angulo(UBound(_macizo.txMedidaAnchoCalle_angulo)) = angulo

        ReDim Preserve _macizo.txMedidaAnchoCalle_contenbido(UBound(_macizo.txMedidaAnchoCalle_contenbido) + 1)
        _macizo.txMedidaAnchoCalle_contenbido(UBound(_macizo.txMedidaAnchoCalle_contenbido)) = cadena

        ReDim Preserve _macizo.txMedidaAnchoCalle_estilo(UBound(_macizo.txMedidaAnchoCalle_estilo) + 1)
        _macizo.txMedidaAnchoCalle_estilo(UBound(_macizo.txMedidaAnchoCalle_estilo)) = estilo



    End Sub
    Public Sub CargoEstructuraMacizoMedidaCalle(ByVal punto As gPoint, ByVal angulo As Object, _
                                              ByVal cadena As String, ByVal estilo As FontFamily)

        ReDim Preserve _macizo.txMedidaLado_pto(UBound(_macizo.txMedidaLado_pto) + 1)
        _macizo.txMedidaLado_pto(UBound(_macizo.txMedidaLado_pto)).X = punto.X
        _macizo.txMedidaLado_pto(UBound(_macizo.txMedidaLado_pto)).Y = punto.Y

        ReDim Preserve _macizo.txMedidaLado_angulo(UBound(_macizo.txMedidaLado_angulo) + 1)
        _macizo.txMedidaLado_angulo(UBound(_macizo.txMedidaLado_angulo)) = angulo

        ReDim Preserve _macizo.txMedidaLado_contenbido(UBound(_macizo.txMedidaLado_contenbido) + 1)
        _macizo.txMedidaLado_contenbido(UBound(_macizo.txMedidaLado_contenbido)) = cadena

        ReDim Preserve _macizo.txMedidaLado_estilo(UBound(_macizo.txMedidaLado_estilo) + 1)
        _macizo.txMedidaLado_estilo(UBound(_macizo.txMedidaLado_estilo)) = estilo


    End Sub

    Public Sub SeteoMazico()
        ' _macizo.puntos = New PointF() {}

        '// Nombre Calle
        _macizo.txMedidaNombreCalle_pto = New PointF() {}
        _macizo.txMedidaNombreCalle_angulo = New Double() {}
        _macizo.txMedidaNombreCalle_estilo = New FontFamily() {}
        _macizo.txMedidaNombreCalle_contenbido = New String() {}

        '// Medida Lado
        _macizo.txMedidaLado_pto = New PointF() {}
        _macizo.txMedidaLado_angulo = New Double() {}
        _macizo.txMedidaLado_estilo = New FontFamily() {}
        _macizo.txMedidaLado_contenbido = New String() {}

        '// Ancho Calle
        _macizo.txMedidaAnchoCalle_pto = New PointF() {}
        _macizo.txMedidaAnchoCalle_angulo = New Double() {}
        _macizo.txMedidaAnchoCalle_estilo = New FontFamily() {}
        _macizo.txMedidaAnchoCalle_contenbido = New String() {}

    End Sub


    '==================================
    Public Sub SeteoParcela()
        ' _macizo.puntos = New PointF() {}

        '// parcela
        _parcela.txMedidaLado_pto = New PointF() {}
        _parcela.txMedidaLado_angulo = New Double() {}
        _parcela.txMedidaLado_estilo = New FontFamily() {}
        _parcela.txMedidaLado_contenido = New String() {}

        
    End Sub
    '=========================================================

    Public Sub CargoPArcela(ByVal punto As PointF, ByVal angulo As Double, ByVal cadena As String, ByVal estilo As FontFamily)

        ReDim Preserve _parcela.txMedidaLado_pto(UBound(_parcela.txMedidaLado_pto) + 1)
        _parcela.txMedidaLado_pto(UBound(_parcela.txMedidaLado_pto)).X = punto.X
        _parcela.txMedidaLado_pto(UBound(_parcela.txMedidaLado_pto)).Y = punto.Y

        ReDim Preserve _parcela.txMedidaLado_angulo(UBound(_parcela.txMedidaLado_angulo) + 1)
        _parcela.txMedidaLado_angulo(UBound(_parcela.txMedidaLado_angulo)) = angulo

        ReDim Preserve _parcela.txMedidaLado_contenido(UBound(_parcela.txMedidaLado_contenido) + 1)
        _parcela.txMedidaLado_contenido(UBound(_parcela.txMedidaLado_contenido)) = cadena

        ReDim Preserve _parcela.txMedidaLado_estilo(UBound(_parcela.txMedidaLado_estilo) + 1)
        _parcela.txMedidaLado_estilo(UBound(_parcela.txMedidaLado_estilo)) = estilo
    End Sub


    Public Sub cargonomenclatura()
        nomenclatura.Circunscripcion = frmInicial.T_circ.Text.ToString.ToUpper
        nomenclatura.Seccion = frmInicial.T_secc.Text.ToString.ToUpper
        nomenclatura.Chacra = frmInicial.T_cha.Text.ToString.ToUpper
        nomenclatura.ChacraLetra = frmInicial.T_chacra_letra.Text.ToString.ToUpper
        nomenclatura.Quinta = frmInicial.T_quinta.Text.ToString.ToUpper
        nomenclatura.QuintaLetra = frmInicial.T_quinta_letra.Text.ToString.ToUpper
        nomenclatura.Fraccion = frmInicial.T_frac.Text.ToString.ToUpper
        nomenclatura.FraccionLetra = frmInicial.T_frac_letra.Text.ToString.ToUpper
        nomenclatura.Manzana = frmInicial.T_manzana.Text.ToString.ToUpper
        nomenclatura.ManzanaLetra = frmInicial.T_manzana_letra.Text.ToString.ToUpper
        nomenclatura.Parcela = frmInicial.t_parcela.Text.ToString.ToUpper
        nomenclatura.ParcelaLetra = frmInicial.t_parcela_letra.Text.ToString.ToUpper
        nomenclatura.SubParcela = frmInicial.t_sub_parcela.Text.ToString.ToUpper

    End Sub



End Module
