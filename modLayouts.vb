Imports VectorDraw.Geometry
Module modLayouts

    Public Sub nuevoLayout()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim laminaNombre As String = InputBox("Ingrese el nombre de nueva lámina (Layout)", aplicacionNombre)
        If laminaNombre = "" Then
            MsgBox("Ingresar nombre de lámina", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If
        Dim laminaNueva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        laminaNueva.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        laminaNueva.setDocumentDefaults()
        'laminaNueva.DisableShowPrinterPaper = True
        laminaNueva.Name = laminaNombre
        laminaNueva.ShowUCSAxis = True
        laminaNueva.BkColorEx = Color.FromArgb(0, 0, 0)
        'laminaNueva.BkGradientColor = Color.Red
        'Dim unidades As VectorDraw.Geometry.LUnits = New VectorDraw.Geometry.LUnits
        'unidades.UType = VectorDraw.Geometry.LUnits.LUnitType.lu_windesk
        'laminaNueva.Printer.lunits = unidades
        'laminaNueva.Printer.SelectPaper("A0")
        laminaNueva.Printer.margins.Left = 0.0 '0.984251968503937    '25 mm pasados a pulgadas: 25mm / 25.4
        laminaNueva.Printer.margins.Right = 0.0 '0.19685039370078741 '5 mm
        laminaNueva.Printer.margins.Bottom = 0.0 '0.19685039370078741
        laminaNueva.Printer.margins.Top = 0.0 '0.19685039370078741

        'Dim papelito As VectorDraw.Professional.vdObjects.SIZE = New VectorDraw.Professional.vdObjects.SIZE
        'papelito.Height = 500
        'papelito.Width = 500
        'laminaNueva.Printer.SelectPaper("papelito")

        'parametros del ancho y alto de la hoja. Para calcular hacer tamaño deseado en mm * 500 / 127 ~ 
        'laminaNueva.Printer.paperSize = New System.Drawing.Rectangle(0, 0, 1967, 1967)

        frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.AddItem(laminaNueva)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Public Sub nuevoViewport()

        '--------------------------------------------
        'verificar que no exista un comando pendiente
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        '---------------------------------------
        'verificar primero que existan layouts..
        If frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.Count < 1 Then
            MsgBox("Agregar por lo menos UNA lámina.", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If
        '---------------------------------------------------------------------
        'verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            MsgBox("Seleccionar alguna lámina (layouts) para definir la ventana (viewport)", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If
        If solapaActiva.SpaceMode = 0 Then
            MsgBox("Pasar al espacio papel para definir una nueva ventana (viewport)", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If



        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdRect("User", "user")
        '-----------------------------------------
        'COMENZAR..
        'el punto uno del rectangulo..
        Dim puntoUno As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim puntoDos As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar punto uno..")
        Dim ret As VectorDraw.Actions.StatusCode
        'frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserRect()

        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(puntoUno)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar el otro vertice..")
            Dim retorno As Object = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserRect(puntoUno)
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
            If Not retorno Is Nothing Then
                Dim v As Vector
                v = retorno
                Dim angulo As Double = v.x
                Dim ancho As Double = v.y
                Dim alto As Double = v.z
                puntoDos = puntoUno.Polar(0.0, ancho)
                puntoDos = puntoDos.Polar(VectorDraw.Geometry.Globals.HALF_PI, alto)

                'agregar un rectangulo para usar de viewport
                Dim rectangulo As VectorDraw.Professional.vdFigures.vdRect = New VectorDraw.Professional.vdFigures.vdRect
                rectangulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                rectangulo.setDocumentDefaults()
                rectangulo.InsertionPoint = puntoUno
                rectangulo.Width = puntoDos.x - puntoUno.x
                rectangulo.Height = puntoDos.y - puntoUno.y
                rectangulo.PenColor.Red = 0
                rectangulo.PenColor.Blue = 0
                rectangulo.PenColor.Green = 0
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(rectangulo)

                Dim nuevoViewPort As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
                nuevoViewPort.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                nuevoViewPort.setDocumentDefaults()
                nuevoViewPort.ShowUCSAxis = True
                nuevoViewPort.ClipObj = rectangulo
                nuevoViewPort.PenColor.SystemColor = Color.Blue
                'nuevoViewPort.BkColorEx = Color.FromArgb(10, 10, 10)
                'solapaActiva.BkGradientColor = Color.Blue

                '---agregar el nuevo viewport al layer "marcos". Si el layer "marcos" no existe, crearlo.
                '---El layer "marcos" es un layer que se crea para alojar los NUEVOS viewports, y asi apagarlos si se desea
                '---no imprimirlos.
                Dim existeLayerMarcos As Boolean
                For Each elemento As ToolStripItem In frmPpal.ToolStrLayers.Items
                    If elemento.Name = "marcos" Then
                        existeLayerMarcos = True
                        Exit Sub
                    End If
                Next
                If existeLayerMarcos Then
                    existeLayerMarcos = False
                Else
                    'crear el layer "marcos"
                    frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("marcos")
                End If
                nuevoViewPort.Layer = frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("marcos")



                Dim xprop As New VectorDraw.Professional.vdObjects.vdXProperty
                xprop.Name = "DisplayBloqueado"
                xprop.PropValue = "NO"
                nuevoViewPort.XProperties.AddItem(xprop)

                Dim lay As VectorDraw.Professional.vdPrimaries.vdLayout = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
                lay.Entities.AddItem(nuevoViewPort)

                rectangulo.Deleted = True
                rectangulo = Nothing
                nuevoViewPort.ZoomExtents()
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            End If
        End If
    End Sub

    Public Sub viewportDesdeUnaEntidad()
        Dim fig1 As VectorDraw.Professional.vdPrimaries.vdFigure = Nothing
        Dim userpt1 As gPoint = Nothing

        '--------------------------------------------
        'verificar que no exista un comando pendiente
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        '---------------------------------------
        'verificar primero que existan layouts..
        If frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.Count < 1 Then
            MsgBox("Agregar por lo menos UNA lámina.", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If
        '---------------------------------------------------------------------
        'verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            MsgBox("Seleccionar alguna lámina (layouts) para definir la ventana (viewport)", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If
        If solapaActiva.SpaceMode = 0 Then
            MsgBox("Pasar al espacio papel para definir una nueva ventana (viewport)", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If



        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccione UNA entidad CERRADA...")
        Dim returnCode As VectorDraw.Actions.StatusCode = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig1, userpt1)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If (returnCode = VectorDraw.Actions.StatusCode.Success) Then
            If Not (fig1 Is Nothing) Then
                If fig1._TypeName <> "vdCircle" And fig1._TypeName <> "vdEllipse" _
                    And fig1._TypeName <> "vdPolyline" And fig1._TypeName <> "vdRect" _
                    And fig1._TypeName <> "vdCurve" Then
                    MsgBox("Entidad no vàlida")
                    Exit Sub
                End If
                Dim nuevoViewPort As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
                nuevoViewPort.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                nuevoViewPort.setDocumentDefaults()
                nuevoViewPort.ShowUCSAxis = True
                nuevoViewPort.ClipObj = fig1
                nuevoViewPort.PenColor.SystemColor = Color.Blue
                '---agregar el nuevo viewport al layer "marcos". Si el layer "marcos" no existe, crearlo.
                '---El layer "marcos" es un layer que se crea para alojar los NUEVOS viewports, y asi apagarlos si se desea
                '---no imprimirlos.
                Dim existeLayerMarcos As Boolean
                For Each elemento As ToolStripItem In frmPpal.ToolStrLayers.Items
                    If elemento.Name = "marcos" Then
                        existeLayerMarcos = True
                        Exit Sub
                    End If
                Next
                If existeLayerMarcos Then
                    existeLayerMarcos = False
                Else
                    'crear el layer "marcos"
                    frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("marcos")
                End If
                nuevoViewPort.Layer = frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("marcos")
                Dim xprop As New VectorDraw.Professional.vdObjects.vdXProperty
                xprop.Name = "DisplayBloqueado"
                xprop.PropValue = "NO"
                nuevoViewPort.XProperties.AddItem(xprop)

                Dim lay As VectorDraw.Professional.vdPrimaries.vdLayout = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
                lay.Entities.AddItem(nuevoViewPort)

                fig1.Deleted = True
                fig1 = Nothing
                nuevoViewPort.ZoomExtents()
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

            End If
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub

    Public Sub resetViewport()
        '---------------------------------------
        ' Dejar el viewport en posicion original
        '---------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        'verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            MsgBox("Seleccionar alguna lámina (layouts) y alguna ventana (viewport) para restaurar giro a posición original", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        If solapaActiva.SpaceMode = 1 Then
            MsgBox("Pasar al espacio modelo dentro de la ventana para restaurar giro a posición original", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        Dim Marco As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
        Marco = solapaActiva.ActiveViewPort
        If Not (Marco Is Nothing) Then
            Dim matriz As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix
            matriz.RotateXMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(0))
            matriz.RotateYMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(0))
            matriz.RotateZMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(0))
            frmPpal.VdF.BaseControl.ActiveDocument.World2ViewMatrix = matriz
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Else
            MsgBox("No hay ninguna ventana (viewport) activa", MsgBoxStyle.Information, aplicacionNombre)
        End If
    End Sub

    Public Function estoyEnUnViewport() As Boolean

        'verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            Return False
        End If

        If solapaActiva.SpaceMode = VectorDraw.Professional.Constants.VdConstSpaceMode.SPACEMOD_MODEL Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub salirDelViewport()
        '------------------------------------------------------------
        ' esto provoca la salida del viewport, hacia el espacio papel
        '------------------------------------------------------------
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut

        If solapaActiva.SpaceMode = VectorDraw.Professional.Constants.VdConstSpaceMode.SPACEMOD_MODEL Then
            solapaActiva.SpaceMode = VectorDraw.Professional.Constants.VdConstSpaceMode.SPACEMOD_PAPER
        End If

    End Sub

    Public Sub giroViewport()
        '--------------------------------
        ' girar un viewport
        '--------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        '..verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            MsgBox("Seleccionar alguna lámina (layouts) y alguna ventana (viewport) para establecer el giro.", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        If solapaActiva.SpaceMode = 1 Then
            MsgBox("Pasar al espacio modelo dentro de la ventana para definir puntos de giro", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        Dim puntoUno As VectorDraw.Geometry.gPoint
        Dim puntoDos As VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar punto uno..")
        Dim ret As VectorDraw.Actions.StatusCode
        puntoUno = Nothing
        puntoDos = Nothing
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(puntoUno)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar punto dos..")
            ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(puntoDos)
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
            If ret = VectorDraw.Actions.StatusCode.Success Then
                'agregar un rectangulo para usar de viewport
                'MsgBox("el punto uno, x : " & puntoUno.x.ToString & ", y : " & puntoUno.y.ToString & "el punto dos, x : " & puntoDos.x.ToString & ", y : " & puntoDos.y.ToString)
                'Dim rectangulo As VectorDraw.Professional.vdFigures.vdRect = New VectorDraw.Professional.vdFigures.vdRect
                'rectangulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                'rectangulo.setDocumentDefaults()
                'rectangulo.InsertionPoint = puntoUno
                'rectangulo.Width = puntoDos.x - puntoUno.x
                'rectangulo.Height = puntoDos.y - puntoUno.y
                'rectangulo.PenColor.Red = 255
                'rectangulo.PenColor.Blue = 0
                'rectangulo.PenColor.Green = 0
                'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(rectangulo)

                'Dim nuevoViewPort As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
                'nuevoViewPort.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                'nuevoViewPort.setDocumentDefaults()
                'nuevoViewPort.ShowUCSAxis = True
                'nuevoViewPort.ClipObj = rectangulo
                'nuevoViewPort.PenColor.SystemColor = Color.Blue
                ''nuevoLayout.BkColorEx = Color.Aqua
                ''nuevoLayout.BkGradientColor = Color.Blue

                'Dim lay As VectorDraw.Professional.vdPrimaries.vdLayout = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
                'lay.Entities.AddItem(nuevoViewPort)

                'rectangulo.Deleted = True
                'rectangulo = Nothing
                'frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

                Dim angulito As Double = VectorDraw.Geometry.Globals.GetAngle(puntoUno, puntoDos)
                Dim angulo As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(angulito)
                If angulo > 180 Then
                    'angulo = angulo - 180
                End If

                Dim Marco As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
                Marco = solapaActiva.ActiveViewPort

                If Not (Marco Is Nothing) Then
                    Dim matriz As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix
                    'Marco.Transformby(matriz)  '<----esto gira el viewport entero
                    'Dim azimut As Double = puntoUno.x
                    'Dim tilt As Double = puntoUno.y
                    'Dim twist As Double = puntoUno.z
                    'matriz.SetToViewAngles(VectorDraw.Geometry.Globals.DegreesToRadians(azimut), VectorDraw.Geometry.Globals.DegreesToRadians(tilt), VectorDraw.Geometry.Globals.DegreesToRadians(twist))

                    'Dim vectorx As VectorDraw.Geometry.Vector = New VectorDraw.Geometry.Vector
                    'Dim vectory As VectorDraw.Geometry.Vector = New VectorDraw.Geometry.Vector

                    matriz.RotateXMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(0))
                    matriz.RotateYMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(0))
                    matriz.RotateZMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(-angulo))
                    'vdFramedControl.BaseControl.ActiveDocument.Model.World2ViewMatrix = matt
                    frmPpal.VdF.BaseControl.ActiveDocument.World2ViewMatrix = matriz

                    'Marco.ViewCenter = puntoDos - puntoUno
                    'Marco.Center = puntoDos - puntoUno
                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                Else
                    MsgBox("No hay ninguna ventana (viewport) activa", MsgBoxStyle.Information, aplicacionNombre)
                End If
            End If
        End If
    End Sub

    Public Sub escalaViewport(ByVal factorEsc As Single)
        '------------------------------------------------------------------------------
        'escalear viewPort. El factor se calcula haciendo 1000/denominador de la escala 
        'deseada.Por(ejemplo) para poner la escala en 1:100 se hace 1000/100=10. 
        '10 es el factor a utilizar. El factor de escala se deberia preguntar aqui. Pero
        'se ingresa antes, junto con los factores de escala preseteados.
        '------------------------------------------------------------------------------

        'que no hay ningun comando pendiente..
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        'verificar primero que existan layouts..
        If frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.Count < 1 Then
            MsgBox("Agregar por lo menos UNA lámina (un Layout).", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        'verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            MsgBox("Seleccionar alguna lámina (layouts) para definir la ventana (viewport)", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        Dim Marco As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
        Dim alturaMarco As Integer
        Marco = solapaActiva.ActiveViewPort
        If Not (Marco Is Nothing) Then
            alturaMarco = Marco.Height
            Marco.ViewSize = alturaMarco / factorEsc
            frmPpal.ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Else
            MsgBox("No hay ninguna ventana (viewport) activa", MsgBoxStyle.Information, aplicacionNombre)
        End If
    End Sub

    Public Function verEscalaViewport() As Single

        '---------------------------------------------
        'esto es para ver que escala tiene un viewport
        '---------------------------------------------
        'que no hay ningun comando pendiente..
        'If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        'End If

        'verificar primero que existan layouts..
        If frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.Count < 1 Then
            Return 0.0
        End If

        'verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            Return 0.0
        End If

        Dim escala As Single
        Dim factor As Single
        Dim Marco As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
        Dim alturaMarco As Integer
        Marco = solapaActiva.ActiveViewPort
        If Not (Marco Is Nothing) Then
            alturaMarco = Marco.Height
            factor = alturaMarco / Marco.ViewSize
            If frmPpal.btnUnidadesPapel.Text = "Unidades Papel = mm" Then
                escala = 1000 / factor
            Else
                escala = 100 / factor
            End If

        Else
            Return 0.0
        End If
        verEscalaViewport = escala

    End Function

    Public Sub BloquearViewPort()
        '-----------------------------------------------------
        ' se ejecuta con el comando "BVP" (Bloquear View Port)
        '-----------------------------------------------------
        'que no hay ningun comando pendiente..
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        'verificar primero que existan layouts..
        If frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.Count < 1 Then
            MsgBox("Agregar por lo menos UNA lámina (un Layout).", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        'verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            MsgBox("Seleccionar alguna lámina (layouts) para definir la ventana (viewport)", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        Dim Marco As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
        Marco = solapaActiva.ActiveViewPort
        If Not (Marco Is Nothing) Then
            Dim xprop As VectorDraw.Professional.vdObjects.vdXProperty
            'Marco.FrozenLayerList.AddItem("Mensura") 'freezar un layer solo en este viewport
            '
            'si no tiene xproperties nunca fue bloqueado, o sea que el estado actual es desbl.
            'si tiene xproperties leer si esta o no bloqueado.
            Dim bloqueado As Boolean
            xprop = New VectorDraw.Professional.vdObjects.vdXProperty
            If Marco.XProperties.Count = 0 Then
                bloqueado = False
                xprop.Name = "DisplayBloqueado"
                xprop.PropValue = "NO"
                Marco.XProperties.AddItem(xprop)
            Else
                For Each xprop In Marco.XProperties
                    If xprop.Name = "DisplayBloqueado" Then
                        If xprop.PropValue = "NO" Then
                            bloqueado = False
                        ElseIf xprop.PropValue = "SI" Then
                            bloqueado = True
                        End If
                    End If
                Next
            End If

            If bloqueado = True Then
                bloqueado = False
                'MsgBox("Display desbloqueado")
                For Each xprop In Marco.XProperties
                    If xprop.Name = "DisplayBloqueado" Then
                        xprop.PropValue = "NO"
                    End If
                Next
                Marco.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Continuous")
                'Marco.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_90
                Marco.LineTypeScale = 15
                Marco.PenColor.Red = 0
                Marco.PenColor.Blue = 220
                Marco.PenColor.Green = 0
            Else
                bloqueado = True
                'MsgBox("Display bloqueado")
                For Each xprop In Marco.XProperties
                    If xprop.Name = "DisplayBloqueado" Then
                        xprop.PropValue = "SI"
                    End If
                Next
                Marco.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
                'Marco.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_90
                Marco.LineTypeScale = 15
                Marco.PenColor.Red = 220
                Marco.PenColor.Blue = 0
                Marco.PenColor.Green = 0
            End If
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Else
            MsgBox("No hay ninguna ventana (viewport) activa", MsgBoxStyle.Information, aplicacionNombre)
        End If

    End Sub

    Public Function DisplayBloqueado() As Boolean
        '-----------------------------------------------------
        ' ver si el viewport activo esta bloqueado o no
        '-----------------------------------------------------

        ' ''que no hay ningun comando pendiente..
        ''If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
        ''    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        ''End If

        'verificar primero que existan layouts..
        If frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.Count < 1 Then
            Return False
        End If

        If modeloSi() = True Then
            Return False
        End If

        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut

        Dim Marco As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
        Marco = solapaActiva.ActiveViewPort
        If Not (Marco Is Nothing) Then
            Dim xprop As VectorDraw.Professional.vdObjects.vdXProperty
            '
            'si no tiene xproperties nunca fue bloqueado, o sea que el estado actual es desbl.
            '
            'si tiene xproperties leer si esta o no bloqueado.
            '
            Dim bloqueado As Boolean
            xprop = New VectorDraw.Professional.vdObjects.vdXProperty
            If Marco.XProperties.Count = 0 Then
                bloqueado = False
            Else
                For Each xprop In Marco.XProperties
                    If xprop.Name = "DisplayBloqueado" Then
                        If xprop.PropValue = "NO" Then
                            bloqueado = False
                        ElseIf xprop.PropValue = "SI" Then
                            bloqueado = True
                        End If
                    End If
                Next
            End If
            Return bloqueado
        Else
            Return False
        End If

    End Function

    Public Sub onOffMarcoPrinter()
        '---------------------------------------------------------------------------
        ' esto apagar el marco del papel, en espacio papel y pone el color del fondo
        ' en negro.
        '---------------------------------------------------------------------------
        Dim cartel As String

        'a ver si hay algun comando pendiente...
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        'verificar primero que existan layouts..
        If frmPpal.VdF.BaseControl.ActiveDocument.LayOuts.Count < 1 Then
            cartel = "Este comando funciona en el espacio papel" & vbCrLf
            cartel = cartel & "Agregar al menos Una lámina (layout)"
            MsgBox(cartel, MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        'verificar si estoy en un layout..si estoy en el espacio modelo me voy
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        'solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActionLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            cartel = "Este comando funciona en espacio papel" & vbCrLf
            cartel = cartel & "Pasar a espacio papel para utilizar este comando"
            MsgBox(cartel, MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        If solapaActiva.SpaceMode = 0 Then
            cartel = "Este comando funciona en espacio papel" & vbCrLf
            cartel = cartel & "Pero no dentro de una ventana (viewport)" & vbCrLf
            cartel = cartel & "Salir de la ventana activa y reintentar."
            MsgBox(cartel, MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If
        solapaActiva.BkColorEx = Color.FromArgb(50, 50, 50)
        If solapaActiva.DisableShowPrinterPaper = True Then
            solapaActiva.DisableShowPrinterPaper = False
        Else
            solapaActiva.DisableShowPrinterPaper = True
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Public Function modeloSi() As Boolean
        '--------------------------------------------------------------------------------------------
        'esto devuelve true si estoy en la SOLAPA de espacio modelo..ojo
        'que si estoy en alguna SOLAPA del espacio papel siempre devuelve FALSO, 
        'por mas que este en el modelo pero dentro de un viewport, igual sigo parado en la solapa del
        'espacio papel.
        '--------------------------------------------------------------------------------------------
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        If solapaActiva.Name = "Model" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function viewPortSiNo() As Boolean
        '-----------------------------------------------------------------------
        'esto devuelve TRUE si estoy en el espacio papel y dentro de un viewport
        '-----------------------------------------------------------------------
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        Dim Marco As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport

        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        Marco = solapaActiva.ActiveViewPort
        If Marco Is Nothing Then
            Return False
        Else
            Return True
        End If

    End Function
End Module
