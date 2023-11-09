Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class frmMuros
    Dim _grMuro As Graphics
    Dim _espesor As Double
    Dim _parcelaPunto1 As PointF
    Dim _parcelaPunto2 As PointF
    Dim _punto1 As PointF
    Dim _punto2 As PointF
    Dim _x1, _y1, _x2, _y2 As Double
    Private Const _largoMuro As Integer = 10
    Private Const _anchoMuro As Integer = 3

    Private Function GenerarPunto(ByVal x As Double, ByVal y As Double) As PointF
        Return New PointF(x, y)
    End Function


    Private Sub Muro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _x1 = _muro.puntosEjeParcela(0).X
        _y1 = _muro.puntosEjeParcela(0).Y
        _x2 = _muro.puntosEjeParcela(1).X
        _y2 = _muro.puntosEjeParcela(1).Y



        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()


        'If (CInt(_x1) = CInt(_x2)) Then
        '    FormularioVertical()
        'ElseIf (CInt(_y1) = CInt(_y2)) Then
        '    FormularioHorizontal()
        'End If
    End Sub

    Private Sub FormularioVertical()
        'Button2.Height = 208
        'Button2.Width = 37
        'Button2.Location = New Point(106, 114)
        'TextBox2.Location = New Point(151, 109)
        'TextBox3.Location = New Point(151, 300)
        'TextBox4.Location = New Point(66, 109)
        'TextBox5.Location = New Point(66, 300)
    End Sub
    Private Sub FormularioHorizontal()
        'Button2.Height = 37
        'Button2.Width = 208
        'Button2.Location = New Point(25, 198)
        'TextBox2.Location = New Point(25, 170)
        'TextBox3.Location = New Point(201, 170)
        'TextBox4.Location = New Point(25, 241)
        'TextBox5.Location = New Point(201, 241)
    End Sub
    Private Sub GenerarMuroVertical(ByVal desvioX1 As Double, ByVal desvioX2 As Double, ByVal espesor As Double)
        'Dim punto1 As PointF
        'Dim punto2 As PointF
        'Dim x1 As Integer
        'Dim x2 As Integer

        'x1 = _x1 + desvioX1 - espesor
        'x2 = _x2 + desvioX2 - espesor
        'punto1 = GenerarPunto(x1, _y1)
        'punto2 = GenerarPunto(x2, _y2 * _largoMuro)

        ''//linea media
        'DibujarLinea(DashStyle.DashDot, Color.GreenYellow, punto1, punto2)

        ''Recta a la izquiera
        'punto1 = GenerarPunto(x1 - espesor, _y1)
        'punto2 = GenerarPunto(x2 - espesor, _y2 * _largoMuro)

        'DibujarLinea(DashStyle.Solid, Color.White, punto1, punto2)             

        ''Recta a la derecha
        'punto1 = GenerarPunto(x1 + espesor, _y1)
        'punto2 = GenerarPunto(x2 + espesor, _y2 * _largoMuro)

        'DibujarLinea(DashStyle.Solid, Color.White, punto1, punto2)
    End Sub
    Private Sub GenerarMuroHorizontal(ByVal desvioY1 As Double, ByVal desvioY2 As Double, ByVal espesor As Double)
        'Dim punto1 As PointF
        'Dim punto2 As PointF
        'Dim y1 As Integer
        'Dim y2 As Integer

        'y1 = _y1 + desvioY1 - espesor
        'y2 = _y2 + desvioY2 - espesor

        'punto1 = GenerarPunto(_x1, y1)
        'punto2 = GenerarPunto(_x2 * _anchoMuro, y2)

        ''//linea media
        'DibujarLinea(DashStyle.DashDot, Color.GreenYellow, punto1, punto2)

        ''Recta   arriba
        'punto1 = GenerarPunto(_x1, y1 - espesor)
        'punto2 = GenerarPunto(_x2 * _anchoMuro, y2 - espesor)

        'DibujarLinea(DashStyle.Solid, Color.White, punto1, punto2)

        ''Recta   abajo
        'punto1 = GenerarPunto(_x1, y1 + espesor)
        'punto2 = GenerarPunto(_x2 * _anchoMuro, y2 + espesor)

        'DibujarLinea(DashStyle.Solid, Color.White, punto1, punto2)
    End Sub
    Private Sub CrearMuroVertical(ByVal punto1 As PointF, ByVal punto2 As PointF, ByVal espesor As Double)

        'punto1 = GenerarPunto(_x1, _y1)
        'punto2 = GenerarPunto(_x2, _y2 * _largoMuro)

        ''//linea media
        'DibujarLinea(DashStyle.DashDot, Color.GreenYellow, punto1, punto2)

        ''Recta a la izquiera
        'punto1 = GenerarPunto(_x1 - espesor, _y1)
        'punto2 = GenerarPunto(_x2 - espesor, _y2 * _largoMuro)

        'DibujarLinea(DashStyle.Solid, Color.Red, punto1, punto2)

        ''Recta a la derecha
        'punto1 = GenerarPunto(_x1 + espesor, _y1)
        'punto2 = GenerarPunto(_x2 + espesor, _y2 * _largoMuro)

        'DibujarLinea(DashStyle.Solid, Color.Red, punto1, punto2)
    End Sub
    Private Sub CrearMuroHorizontal(ByVal punto1 As PointF, ByVal punto2 As PointF, ByVal espesor As Double)

        'punto1 = GenerarPunto(_x1, _y1)
        'punto2 = GenerarPunto(_x2 * _anchoMuro, _y2)

        ''//linea media
        'DibujarLinea(DashStyle.DashDot, Color.GreenYellow, punto1, punto2)

        ''Recta a la izquiera
        'punto1 = GenerarPunto(_x1, _y1 - espesor)
        'punto2 = GenerarPunto(_x2 * _anchoMuro, _y2 - espesor)

        'DibujarLinea(DashStyle.Solid, Color.Red, punto1, punto2)

        ''Recta a la derecha
        'punto1 = GenerarPunto(_x1, _y1 + espesor)
        'punto2 = GenerarPunto(_x2 * _anchoMuro, _y2 + espesor)

        'DibujarLinea(DashStyle.Solid, Color.Red, punto1, punto2)
    End Sub
    Private Sub DibujarLinea(ByVal dashStyle As DashStyle, ByVal color As Color, ByVal punto1 As PointF, ByVal punto2 As PointF)
        'Dim lapiz As New Pen(color)
        'lapiz.DashStyle = dashStyle
        '_grMuro.DrawLine(lapiz, punto1, punto2)
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Dim i As Integer, contador1, contador2 As Integer
        contador1 = 0

        For i = 1 To Len(TextBox2.Text)
            If IsNumeric(Mid(TextBox2.Text, i, 1)) Then
                contador1 = contador1 + 1
            End If
        Next
        For i = 1 To Len(TextBox3.Text)
            If IsNumeric(Mid(TextBox3.Text, i, 1)) Then
                contador2 = contador2 + 1
            End If
        Next

        If contador1 >= 1 And contador2 >= 1 Then
            _muro.anchoMuro = TxtAnchoMuro.Text 'Convert.ToInt32(TxtAnchoMuro.Text)
            modDatosDB.agregarDatosMacizoBD_muros(_muro.anchoMuro, copia_lapoli, "muro")

            _muro.puntosMuro = New String(3) {} ' Asi se setea los vectores de las estructuras

            _muro.puntosEjeParcela = New PointF(1) {}
            _muro.puntosMuro(0) = TextBox4.Text
            _muro.puntosMuro(1) = TextBox2.Text
            _muro.puntosMuro(2) = TextBox3.Text
            _muro.puntosMuro(3) = TextBox5.Text
            _muro.puntosEjeParcela(0) = _parcelaPunto1
            _muro.puntosEjeParcela(1) = _parcelaPunto2
        Else
            MsgBox("No se encontraron números en los textos")
            Exit Sub
        End If
        Close()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If (Not IsNumeric(TextBox2.Text) And Not String.IsNullOrEmpty(TextBox2.Text)) Then
            MsgBox("Sólo Números", , "Atención")
            TextBox2.Clear()
            TextBox2.Focus()
            Exit Sub
        End If
        If (Not String.IsNullOrEmpty(TextBox2.Text)) Then
            TextBox4.Text = TxtAnchoMuro.Text - TextBox2.Text
            diferencia1 = TextBox2.Text ' para hacer el insert en el procedure moddatosdb
        End If

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If (Not IsNumeric(TextBox3.Text) And Not String.IsNullOrEmpty(TextBox3.Text)) Then
            MsgBox("Sólo Números", , "Atención")
            TextBox3.Clear()
            TextBox3.Focus()
            Exit Sub
        End If
        If (Not String.IsNullOrEmpty(TextBox3.Text)) Then
            TextBox5.Text = TxtAnchoMuro.Text - TextBox3.Text
            diferencia2 = TextBox3.Text   'para hacer el insert en el procedure moddatosdb
        End If
    End Sub

    Private Sub TxtAnchoMuro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAnchoMuro.TextChanged


        If TxtAnchoMuro.Text.ToString = "" Then Exit Sub
        TextBox2.Text = TxtAnchoMuro.Text / 2
        TextBox3.Text = TxtAnchoMuro.Text / 2


    End Sub
End Class
