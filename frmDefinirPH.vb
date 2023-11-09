Imports System.Windows.Forms

Public Class frmDefinirPH
    Public bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
    Dim punto2 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    Dim punto3 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    Dim linea1 As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmDefinirPH_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            Me.Hide()
            seleccionarPunto()
        End If
    End Sub

    Private Sub seleccionarPunto()
        Dim ret As VectorDraw.Actions.StatusCode
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar posicion vertice superior izquierdo de la planilla..")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

        If ret = VectorDraw.Actions.StatusCode.Success Then
            dibujarPlanillaUF(punto)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub dibujarPlanillaUF(ByVal punto1 As VectorDraw.Geometry.gPoint)
        '---------------------------------
        ' dibujar la planilla
        '---------------------------------
        dibujarEncabezadoUF(punto1)

        If Not nudCantUF Is Nothing Or nudCantUF.Value > 0 Then
            dibujarUF(punto1)
        End If


        '---------------------------------------------------------------------------------------------
        'luego de dibujar la planilla, con o sin renglones, agregar un bloque con la planilla dibujada
        frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddItem(bloque)

        Dim insertar As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert
        insertar.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        insertar.setDocumentDefaults()
        insertar.Block = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("Planilla")
        insertar.InsertionPoint = punto1
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(insertar)

        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub dibujarUF(ByVal punto1 As VectorDraw.Geometry.gPoint)
        'Si llegue hasta aca es porque hay uf
        'revisar cada uf, ver si tiene poligonos asignados.
        'si no tiene poligonos asignados, dibujar un renglon simple y rellenar valores con rayitas
        'si tiene poligonos asignados, leer los valores de las superficies y ponerlos en los casilleros correspondientes
        'si tiene mas de un poligono asignado, agregar los renglones que correspondan.

        Dim moduloAltura As Integer = 10, modulo As Integer = 0
        For i As Integer = 1 To CInt(nudCantUF.Value)
            If i = 1 Then
                modulo = 0
            Else
                modulo = i * moduloAltura - moduloAltura
            End If

            'izq columna uno
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto1.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30.0 + modulo)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'derecha columna uno
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 30.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'derecha. columna dos
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 30.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'derecha. columna tres
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'derecha. columna cuatro
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'derecha. columna cinco
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'derecha. columna seis
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'derecha. columna siete
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'derecha. columna ocho
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'linea de cierre 
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto1.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30 + modulo + moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)
        Next

    End Sub

    Private Sub dibujarEncabezadoUF(ByVal punto1 As VectorDraw.Geometry.gPoint)
        '90  = VectorDraw.Geometry.Globals.HALF_PI
        '180 = VectorDraw.Geometry.Globals.PI
        '270 = VectorDraw.Geometry.Globals.VD_270PI
        '360 = VectorDraw.Geometry .Globals .VD_TWOPI

        bloque.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloque.setDocumentDefaults()
        bloque.Name = "Planilla"
        bloque.Origin = punto1

        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()

        Dim polilinea As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        polilinea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        polilinea.setDocumentDefaults()
        polilinea.VertexList.Add(punto1)
        '------
        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto1.Polar(0.0, 180.0)
        polilinea.VertexList.Add(New VectorDraw.Geometry.gPoint(punto2))
        '------
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30.0)
        polilinea.VertexList.Add(New VectorDraw.Geometry.gPoint(punto3))
        '------
        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(VectorDraw.Geometry.Globals.PI, 180)
        polilinea.VertexList.Add(New VectorDraw.Geometry.gPoint(punto2))
        '------
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, 30)
        polilinea.VertexList.Add(New VectorDraw.Geometry.gPoint(punto3))
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(polilinea)
        bloque.Entities.AddItem(polilinea)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto1.Polar(0.0, 30.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30.0)
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto1.Polar(0.0, 60.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(VectorDraw.Geometry.Globals.HALF_PI, 15.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(0, 120.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(VectorDraw.Geometry.Globals.PI, 100.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)

        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(0.0, 20.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(0.0, 20.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(0.0, 20.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(0.0, 20.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        Dim textoM As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 15.0, punto1.y - 15.0)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 25.0
        textoM.TextString = "UNIDAD FUNCIONAL (Desig)"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 45.0, punto1.y - 15.0)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 25.0
        textoM.TextString = "POLIGONOS QUE LA INTEGRAN"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 120.0, punto1.y - 7.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 120.0
        textoM.TextString = "SUPERFICIES"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 70.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "CUBIERTA"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 90.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "\W0.70;SEMICUBIERTA"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 110.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "\W0.70;DESCUBIERTA"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 130.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "BALCON"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 150.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "TOTAL POLIGONO"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 170.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "TOTAL UNIDAD FUNCIONAL"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)

        'frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub
End Class
