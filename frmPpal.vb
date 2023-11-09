#Region "Importar"
Imports vdControls
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects
Imports System.IO
Imports System.Threading
#End Region

Public Class frmPpal

#Region "Declaraciones"
    Public versionCad As String

    Public cerrarOk As Boolean
    Public hayCertifAmoj As Boolean
    Public parseador As VectorDraw.Professional.vdObjects.vdDocument.ActionParseEventHandler
    'Public trama As VectorDraw.Professional.vdFigures.vdPolyhatch
    Friend WithEvents doc As VectorDraw.Professional.vdObjects.vdDocument
    Public WithEvents baseControl As VectorDraw.Professional.Control.VectorDrawBaseControl
    Public WithEvents lineaComandos As VectorDraw.Professional.vdCommandLine.vdCommandLine
    Public tiempoDeAutosave As Integer

    '13 de agosto
    Dim layerActual As VectorDraw.Professional.vdPrimaries.vdLayer
    Dim espesorLineaActual As String
    Dim tipoLineaActual As String

    '28 de enero 2013
    Public croquis As Boolean

#End Region


#Region "frmPpal Load"
    '===============================================================================
    '
    ' --> En el modPublico estan todas las operaciones de dibujo y edicion.
    '
    '===============================================================================
    Private Sub frmPpal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ' Comienzo de la aplicación..
        ' Inicializaciones y configuraciones.
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        '------------------------------------------------------------------------------------------------------------------------
        lineaComandos = VdF.CommandLine
        doc = VdF.BaseControl.ActiveDocument  'este es el documento activo
        baseControl = VdF.BaseControl         'el control contenedor de todos los documentos
        '------------------------------------------------------------------------------------------------------------------------

        '------------------------------------------------------------------------------------------------------------------------
        versionCad = getVersion()
        versionCad = UCase(versionCad)
        seteaVersion(versionCad)
        '------------------------------------------------------------------------------------------------------------------------

        '------------------------------------------------------------------------------------------------------------------------
        modConfigura.Configurar()    'en el modulo "modConfigura" esta el procedimiento "Configurar", 
        '                             que ejecuta varias configuraciones y tambien ejecuta el proc.
        '                             "configurarInicio". Ejecutarla cuando se inicia y cuando se carga
        '                             un nuevo file.
        '------------------------------------------------------------------------------------------------------------------------


        'Esto es para parsear la linea de comandos
        AddHandler VdF.BaseControl.ActiveDocument.ActionParse, AddressOf doc_ActionParse


        'traduccion y soporte
        VectorDraw.Serialize.Activator.SetResourcesDirectory(ubicacionSoporte) 'ubicacionSoporte se define en 
        '                                                                       el modulo "modDeclaraciones", que esta 
        '                                                                       def.en("c:\cpacad2\mhcadt\")
        VectorDraw.Serialize.GlobalizedDictionary.Dictionary = New VectorDraw.Serialize.GlobalizedDictionary(ubicacionSoporte & "vdres.txt")
        VdF.CommandLine.LoadCommands(ubicacionSoporte, "Commands.txt")


        leerUltimosAbiertos()
        archivoActivo("")
        '------------------------------------------------------------------------------------------------
        ' para el help
        '------------------------------------------------------------------------------------------------
        'Para asignar la ayuda a un control se utiliza el método SetHelpNavigator
        'se le pasaran dos parametros el objeto que queremos asociar y el comportamiento
        'que tendra en nuestro archivo de ayuda.
        'Ejemplo 1: Presionando el F1 saldra la ayuda por la pestaña de tabla de contenidos
        '-->HelpProvider1.SetHelpNavigator(Me, HelpNavigator.TableOfContents)
        'Ejemplo 2: Presionando el F1 saldra la ayuda en el index
        '-->HelpProvider1.SetHelpNavigator(Me, HelpNavigator.Index)

        'Para quitar la cadena de ayuda a un control se utiliza ResetShowHelp. 
        '-->HelpProvider1.ResetShowHelp(ControlDesasociar)

        'Para especificar si se mostrará la ayuda en un control, o no, se utiliza el método
        'SetShowHelp, al cual se le pasan dos parámetro el control y un true o false.
        '-->HelpProvider1.SetShowHelp(Button1, False)

        'Para asignar una palabra clave a un control se utiliza el método SetHelpKeyword.
        'Un(ejemplo)
        '-->HelpProvider1.SetHelpKeyword(Me, "formulario")
        '-->HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
        'Cuando se presiona el F1 la ayuda muestra el help como si se hubiera ingresado
        'la palabra "formulario" en la solapa de buscar del help.

        'Tanto como se encuentran estos métodos de asignación se encuentran las que 
        'recuperan todos estos valores, pero en vez de empezar por set, empezaran por get

        'poner un string para un control:
        'HelpProvider1.SetHelpString(Button2, "I am supported by HelpProvider1")


        'ejecutar el subprg "configuracionRegional" del modulo "modConfReg" para leer el separador
        'decimal. Se guarda en "sepDecimal" (str)
        configuracionRegional()
        'forzar actu boton inf GRILLA
        If VdF.BaseControl.ActiveDocument.GridMode Then
            VdF.BaseControl.ActiveDocument.GridMode = False
            VdF.BaseControl.ActiveDocument.GridMode = True
        Else
            VdF.BaseControl.ActiveDocument.GridMode = True
            VdF.BaseControl.ActiveDocument.GridMode = False
        End If
        asignarNombre()
        VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

#End Region


#Region "baseControl actionStart"
    Private Sub baseControl_ActionStart(ByVal sender As Object, ByVal actionName As String, ByRef cancel As Boolean) Handles baseControl.ActionStart
        'valorOsnap = VdF.BaseControl.ActiveDocument.osnapMode.ToString
        If actionName = "Zoom" Then
            If modeloSi() = True Then
                Exit Sub
            End If
            If DisplayBloqueado() Then
                VdF.BaseControl.ActiveDocument.Prompt("ViewPort bloqueado..")
                cancel = True
            Else
                ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
            End If
            'ElseIf actionName = "BaseAction_ActionDimension" Then
            '    MsgBox("Se puso una cota")
        End If

    End Sub
#End Region


#Region "Evento del objeto doc.onAfterOpenDocument (se acaba de abrir un documento o sea un dibujo)"
    Private Sub doc_OnAfterOpenDocument(ByVal sender As Object) Handles doc.OnAfterOpenDocument
        '----------------------------------------------------------------------------
        ' para guardar el archivo que se acaba de abrir y agregar el ultimo abierto a
        ' la lista de los recientes.
        '----------------------------------------------------------------------------
        If sender.filename = "C:\Cpacad2\Bloques.dxf" Then
            Exit Sub
        End If
        guardarArchivoRecienAbierto()
        agregarSoloElUltimoAbierto(sender.filename)

    End Sub
    Private Sub doc_ActionEnd(ByVal sender As Object, ByVal actionName As String) Handles doc.ActionEnd
        If actionName = "CmdDim" Then
            Dim miCota As VectorDraw.Professional.vdFigures.vdDimension
            Dim indice As Integer = VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count
            Dim fig As vdFigure '= VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Item(indice)

            'For Each fig As vdFigure In VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            For i As Integer = indice - 1 To 0 Step -1
                fig = VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Item(i)
                If fig._TypeName = "vdDimension" Then
                    miCota = New VectorDraw.Professional.vdFigures.vdDimension
                    miCota.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                    miCota.setDocumentDefaults()
                    miCota = CType(fig, VectorDraw.Professional.vdFigures.vdDimension)
                    'MsgBox(Format(miCota.Measurement, "0.00")).ToString()
                    'MsgBox(miCota.UserBlock.ToString)

                    Exit For
                End If
            Next
            'Next
        End If
    End Sub

    'Private Sub doc_OnActionDraw(ByVal sender As Object, ByVal action As Object, ByVal isHideMode As Boolean, ByRef cancel As Boolean) Handles doc.OnActionDraw
    '    If TypeOf action Is VectorDraw.Actions.ActionGetRefPoint Then
    '        MsgBox("un punto")
    '    End If

    'End Sub

#End Region


#Region "Evento del objeto doc. ActionLayoutActivated (cambie del modelo al papel y viceversa)"
    Private Sub doc_ActionLayoutActivated(ByVal sender As Object, ByVal deactivated As VectorDraw.Professional.vdPrimaries.vdLayout, ByVal activated As VectorDraw.Professional.vdPrimaries.vdLayout) Handles doc.ActionLayoutActivated
        '===========================================================================================
        ' Este evento se dispara cuando cambio de un viewport al papel y viceversa
        '===========================================================================================
        '----------------------------------------------------------------
        'Estoy en una lamina..(en espacio papel) y me paso a un viewport
        '----------------------------------------------------------------
        If activated.Name = "Model" And _
        activated.SpaceMode = VectorDraw.Professional.Constants.VdConstSpaceMode.SPACEMOD_PAPER And _
        deactivated.Name <> "Model" And _
        deactivated.SpaceMode = VectorDraw.Professional.Constants.VdConstSpaceMode.SPACEMOD_MODEL Then
            'ToolStrViewports.Enabled = True
            ToolStrViewportsEscala.Enabled = True
            ToolStrEscViewpBtn.Enabled = True
            btnUnidadesPapel.Enabled = True
            btnBloquearVP.Enabled = True
            toolStripBtnPropVP.Enabled = True
            ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
        End If
        '---------------------------------------------------------------
        'Estoy en una lamina..(en espacio papel), dentro de un viewport y
        'voy a salir del viewport y pasarme a la lamina.
        '---------------------------------------------------------------
        If activated.Name <> "Model" And _
        activated.SpaceMode = VectorDraw.Professional.Constants.VdConstSpaceMode.SPACEMOD_PAPER And _
        deactivated.Name = "Model" And _
        deactivated.SpaceMode = VectorDraw.Professional.Constants.VdConstSpaceMode.SPACEMOD_PAPER Then
            'ToolStrViewports.Enabled = False
            ToolStrViewportsEscala.Enabled = False
            ToolStrEscViewpBtn.Enabled = False
            btnUnidadesPapel.Enabled = False
            btnBloquearVP.Enabled = False
            toolStripBtnPropVP.Enabled = False
        End If
    End Sub
#End Region


#Region "Evento del objeto doc. Traduccion Prompt"
    'traduccion del prompt..
    Private Sub doc_OnPrompt(ByVal sender As Object, ByRef promptStr As String) Handles doc.OnPrompt
        If promptStr = "Select a Figure" Then
            VdF.BaseControl.ActiveDocument.Prompt("Seleccionar una figura")
        End If
    End Sub
#End Region


#Region "Evento del objeto doc. OnResizeControlWindows acomodar las toolbars"
    Private Sub doc_OnResizeControlWindow(ByVal sender As Object, ByVal cx As Integer, ByVal cy As Integer, ByRef cancel As Boolean) Handles doc.OnResizeControlWindow
        posicionarToolBars()

    End Sub
#End Region


#Region "key down Enter en toolstr escala viewport"
    Private Sub ToolStrViewportsEscala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStrViewportsEscala.KeyDown
        '========================================================================================
        ' Esto es por si se oprime Enter en la toolbar de la escala del viewport
        '========================================================================================
        Dim escala As String
        If e.KeyCode = Keys.Enter Then
            escala = ToolStrViewportsEscala.Text
            If btnUnidadesPapel.Text = "Unidades Papel = mm" Then
                escalaViewport(1000 / CSng(escala))
            Else
                escalaViewport(100 / CSng(escala))
            End If

            ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
        End If
    End Sub
#End Region


#Region "click en toolstr escala viewport"
    Private Sub ToolStrViewportsEscala_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrViewportsEscala.Click
        '=========================================================================================
        ' Cuando se hace click sobre la toolbar de las escalas de viewports, para ingresar alguna 
        ' escala. Si estoy en el espacio modelo el foco salta a otro lado para impedir ingresar
        ' valores.
        '=========================================================================================
        If modeloSi() = True And estoyEnUnViewport() = False Then
            MsgBox("comando para espacio papel", MsgBoxStyle.Information, aplicacionNombre)
            VdF.Focus()
            Exit Sub
        End If
    End Sub
#End Region


#Region "linea comandos. Se escribio algo en la linea de comandos."
    'linea de comandos..
    Private Sub lineaComandos_CommandExecute(ByVal commandname As String, ByVal isDefaultImplemented As Boolean, ByRef success As Boolean) Handles lineaComandos.CommandExecute
        '----------------------------------------
        ' linea de comandos..
        '----------------------------------------
        Select Case UCase(commandname)

            Case Is = "STB", "SENDTOBACK"
                enviarAlFondo()
                Exit Sub

            Case Is = "BTF", "BRINGTOFRONT"
                traerAlFrente()
                Exit Sub

            Case Is = "SAVE", "SAVEAS", "PRINT"
                If versionCad = "Demo" Then
                    MsgBox("Versiòn de demostraciòn.", MsgBoxStyle.Information, aplicacionNombre)
                    success = True
                End If
            Case Is = "PINCELITO", "MATCHPROP"
                isDefaultImplemented = False
                copiarPropiedades()
                success = True

            Case Is = "O", "OFFSET"
                isDefaultImplemented = False
                success = True
                offset()

            Case Is = "E"
                isDefaultImplemented = False
                borrar("noTeclaSupr")
                success = True

            Case Is = "PAN", "P"
                isDefaultImplemented = False
                VdF.BaseControl.ActiveDocument.Prompt("Comando: Pan ")
                VdF.BaseControl.ActiveDocument.CommandAction.Pan()
                success = True
                VdF.BaseControl.ActiveDocument.Prompt(Nothing)

            Case Is = "UCS"
                isDefaultImplemented = False
                VdF.BaseControl.ActiveDocument.Prompt("Especifique opción [3, World] <Wordl>")
                Dim respuesta As String = VdF.BaseControl.ActiveDocument.ActionUtility.getUserString()
                If respuesta = "3" Then
                    ucsX3puntos()
                ElseIf UCase(respuesta) = "W" Or UCase(respuesta) = "WORLD" Or respuesta Is Nothing Then
                    ucsOriginal()
                End If
                success = True
                VdF.BaseControl.ActiveDocument.Prompt(Nothing)

            Case Is = "PLAN"
                Dim matrizOrigenANuevoUcs As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix
                isDefaultImplemented = False
                VdF.BaseControl.ActiveDocument.Prompt("Ingrese una opción [U = Ucs Actual /W = World] <Ucs Actual>")
                Dim respuestaPlan As String = VdF.BaseControl.ActiveDocument.ActionUtility.getUserString()

                If UCase(respuestaPlan) = "U" Or respuestaPlan Is Nothing Then
                    planUcsActual()
                ElseIf UCase(respuestaPlan) = "W" Or UCase(respuestaPlan) = "WORLD" Then
                    planOriginal()
                End If
                success = True
                VdF.BaseControl.ActiveDocument.Redraw(True)
                VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

            Case Is = "ATE"
                isDefaultImplemented = False
                attedit()
                success = True
                VdF.BaseControl.ActiveDocument.Prompt(Nothing)

            Case Is = "BVP"
                isDefaultImplemented = False
                VdF.BaseControl.ActiveDocument.Prompt("Comando Bloquear View Port")
                BloquearViewPort()
                success = True
                VdF.BaseControl.ActiveDocument.Prompt(Nothing)

            Case Is = "ID"
                isDefaultImplemented = False
                modPublico.IdPunto()
                success = True
                VdF.BaseControl.ActiveDocument.Prompt(Nothing)

            Case Is = "ALINEAR"
                isDefaultImplemented = False
                alinear()
                success = True

            Case Is = "MTEXT"
                isDefaultImplemented = False
                textoMulti()
                success = True
            Case Is = "COPY", "C", "CP"
                isDefaultImplemented = False
                copiar()
                success = True
            Case Is = "FILLETR0", "FR0"
                isDefaultImplemented = False
                filletr0()
                success = True
            Case Is = "FILLET", "F"
                isDefaultImplemented = False
                fillet()
                success = True
            Case Is = "BREAK", "BR"
                isDefaultImplemented = False
                break()
                success = True
            Case Is = "TRIM", "TR"
                isDefaultImplemented = False
                trimear()
                success = True
            Case Is = "EXTEND", "EXT", "ESTIRAR"
                isDefaultImplemented = False
                extend()
                success = True
            Case Is = "MIRROR", "MI"
                isDefaultImplemented = False
                mirror()
                success = True
            Case Is = "MOVE", "M"
                isDefaultImplemented = False
                success = True
                mover()
            Case Is = "ROTATE", "RO"
                isDefaultImplemented = False
                rotate()
                success = True
            Case Is = "SCALE", "S"
                isDefaultImplemented = False
                escala()
                success = True
            Case Is = "EXPLODE", "EX"
                isDefaultImplemented = False
                explode()
                success = True
            Case Is = "BYN"
                isDefaultImplemented = False
                cambiarColores("byn")
                success = True
            Case Is = "COLORES"
                isDefaultImplemented = False
                cambiarColores("colores")
                success = True
            Case Is = "GIRAR3D"
                isDefaultImplemented = False
                Me.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VROT")
                success = True
            Case Is = "BORRAR"
                isDefaultImplemented = False
                success = True
                modBorrarEntidades.pdBorrarEntidades()
            Case Is = "MUROS"
                isDefaultImplemented = False
                modMuros.definirMuroPorPuntos()
                success = True


        End Select

    End Sub
#End Region


    Public Sub cambiarColores(ByVal tipoCambio As String)
        If tipoCambio = "byn" Then
            blancoNegro()
        End If
    End Sub

    Public Sub blancoNegro()

        'ver si estoy en espacio papel.
        'si estoy en espacio papel, primero ejecutar rutina de pasar a byn en espacio modelo y luego en espacio papel
        Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout
        solapaActiva = Me.VdF.BaseControl.ActiveDocument.ActiveLayOut
        Dim pasadasTotal As Integer
        Dim nombreSolapaEspacioPapel As String
        If solapaActiva.Name <> "Model" Then
            nombreSolapaEspacioPapel = solapaActiva.Name.ToString
            pasadasTotal = 2
        Else
            pasadasTotal = 1
        End If
        'If solapaActiva.SpaceMode = 1 Then
        '    MsgBox("estoy en espacio papel pero fuera del vp")
        'End If
        'If solapaActiva.SpaceMode = 0 Then
        '    MsgBox("estoy en espacio papel pero dentro del vp")
        'End If

        For pasadas As Integer = 1 To pasadasTotal
            If pasadasTotal = 2 Then
                If pasadas = 1 Then
                    'pasar a modelo...
                    Dim layModelo As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout()
                    layModelo.SetUnRegisterDocument(Me.VdF.BaseControl.ActiveDocument)
                    layModelo.setDocumentDefaults()
                    layModelo.Name = "model"
                    layModelo = Me.VdF.BaseControl.ActiveDocument.LayOuts.FindName("model")
                    Me.VdF.BaseControl.ActiveDocument.ActiveLayOut = layModelo
                ElseIf pasadas = 2 Then
                    'pasar o volver al papel
                    Dim layPapel As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout()
                    layPapel.SetUnRegisterDocument(Me.VdF.BaseControl.ActiveDocument)
                    layPapel.setDocumentDefaults()
                    layPapel.Name = nombreSolapaEspacioPapel
                    layPapel = Me.VdF.BaseControl.ActiveDocument.LayOuts.FindName(nombreSolapaEspacioPapel)
                    Me.VdF.BaseControl.ActiveDocument.ActiveLayOut = layPapel
                End If
                ejecutarPasarABlancoYNegro()
                Me.VdF.BaseControl.ActiveDocument.Redraw(True)
            ElseIf pasadasTotal = 1 Then
                ejecutarPasarABlancoYNegro()
            End If
        Next

    End Sub

    Private Sub ejecutarPasarABlancoYNegro()

        'procesar primero solo las cotas
        Dim indiceCotas As Integer = VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count
        Dim figura As vdFigure
        For k As Integer = indiceCotas - 1 To 0 Step -1
            figura = VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Item(k)
            If figura._TypeName = "vdDimension" Then
                VdF.BaseControl.ActiveDocument.CommandAction.CmdExplode(figura)
            End If
        Next

        Dim indice As Integer = VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count
        Dim fig As vdFigure
        'Dim mColor As VectorDraw.Professional.vdObjects.vdColor = New VectorDraw.Professional.vdObjects.vdColor()
        Dim indiceColor As Integer
        For i As Integer = indice - 1 To 0 Step -1
            fig = VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Item(i)
            'el color de la entidad es bylayer, por lo tanto leer el color del layer correspondiente
            'y guardarlo en "indiceColor" para asignar luego el espesor correspondiente
            If fig.PenColor.ByLayer Then
                Dim capa As New VectorDraw.Professional.vdPrimaries.vdLayer
                capa.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                capa.setDocumentDefaults()
                capa = VdF.BaseControl.ActiveDocument.Layers.FindName(fig.Layer.ToString)
                indiceColor = capa.PenColor.ColorIndex
            Else
                indiceColor = fig.PenColor.ColorIndex
            End If


            '=====================================================================================
            'el color:
            '=====================================================================================
            '-------------------------------------------------------------------------------------
            'es una cota
            'primero explotarla para evitar que se muevan (por haber sido colocadas en un lugar
            'y luego "desplazada" a otro. Cuando se convierten a byn vuelven a su lugar original
            'y aparecen como movidas.
            '-------------------------------------------------------------------------------------
            'Dim puntoAntes As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
            'Dim puntoDespues As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
            'If fig._TypeName = "vdDimension" Then
            '    Dim miCota As New VectorDraw.Professional.vdFigures.vdDimension
            '    miCota.SetUnRegisterDocument(frmPpal.vdf.BaseControl.ActiveDocument)
            '    miCota.setDocumentDefaults()
            '    miCota = CType(fig, VectorDraw.Professional.vdFigures.vdDimension)
            '    'frmPpal.vdf.BaseControl.ActiveDocument.CommandAction.CmdExplode(miCota)
            '    'puntoAntes = miCota.GetMtextPosition()
            '    miCota.TextColor.FromInt32(6)
            '    'puntoDespues = miCota.GetMtextPosition()
            '    'miCota.setDocumentDefaults()
            'End If

            '--------------
            'es un mtext
            '--------------
            If fig._TypeName = "vdMText" Then
                Dim textoMultiple As New vdMText
                textoMultiple.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                textoMultiple.setDocumentDefaults()
                textoMultiple = CType(fig, vdMText)
                textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C1", "C0")
                textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C2", "C0")
                textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C3", "C0")
                textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C4", "C0")
                textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C5", "C0")
                textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C7", "C0")
                textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C8", "C0")
                textoMultiple.Update()
            End If


            '----------------
            'es un hatch..
            '----------------
            If fig._TypeName = "vdPolyhatch" Then
                Dim tramado As New vdPolyhatch
                tramado.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                tramado.setDocumentDefaults()
                tramado = CType(fig, vdPolyhatch)
                indiceColor = tramado.HatchProperties.FillColor.ColorIndex
                tramado.HatchProperties.FillColor.FromInt32(6)
            End If

            '---------------------------------------------------------------------------------
            'es una polilinea: Revisarlas porque hay algunas polilineas que vienen de autocad
            'con la propiedad vdFillModePattern y esto le agrega un tramado
            '---------------------------------------------------------------------------------
            If fig._TypeName = "vdPolyline" Then
                Dim poliLinea As New vdPolyline
                poliLinea.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                poliLinea.setDocumentDefaults()
                poliLinea = CType(fig, vdPolyline)
                If Not poliLinea.HatchProperties Is Nothing Then
                    indiceColor = poliLinea.HatchProperties.FillColor.ColorIndex
                    poliLinea.HatchProperties.FillColor.FromInt32(6)
                End If
            End If


            '---------------
            'es un bloque
            '---------------
            If fig._TypeName = "vdInsert" Then
                Dim elBloque As New vdInsert
                elBloque.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                elBloque.setDocumentDefaults()
                elBloque = CType(fig, vdInsert)

                If elBloque.Attributes.Count > 0 Then
                    For Each atributo As vdAttrib In elBloque.Attributes
                        atributo.PenColor.FromInt32(6)
                    Next
                End If

                For Each entidad As vdFigure In elBloque.Block.Entities
                    If entidad._TypeName = "vdPolyhatch" Then
                        Dim tramado As New vdPolyhatch
                        tramado.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                        tramado.setDocumentDefaults()
                        tramado = CType(entidad, vdPolyhatch)
                        indiceColor = tramado.HatchProperties.FillColor.ColorIndex
                        tramado.HatchProperties.FillColor.FromInt32(6)
                        tramado.PenColor.FromInt32(6)
                    ElseIf entidad._TypeName = "vdMText" Then
                        Dim textoMultiple As New vdMText
                        textoMultiple.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                        textoMultiple.setDocumentDefaults()
                        textoMultiple = CType(entidad, vdMText)
                        textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C1", "C7")
                        textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C2", "C7")
                        textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C3", "C7")
                        textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C4", "C7")
                        textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C5", "C7")
                        textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C7", "C7")
                        textoMultiple.TextString = textoMultiple.TextString.ToString.Replace("C8", "C7")
                        textoMultiple.Update()
                    ElseIf entidad._TypeName = "vdDimension" Then
                        If entidad.PenColor.ByLayer Then
                            Dim capa As New VectorDraw.Professional.vdPrimaries.vdLayer
                            capa.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                            capa.setDocumentDefaults()
                            capa = VdF.BaseControl.ActiveDocument.Layers.FindName(fig.Layer.ToString)
                            capa.PenColor.ColorIndex = 6
                            capa.Update()
                            capa.Invalidate()
                        Else
                            Dim miCota As New VectorDraw.Professional.vdFigures.vdDimension
                            miCota.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                            miCota.setDocumentDefaults()
                            miCota = CType(entidad, VectorDraw.Professional.vdFigures.vdDimension)
                            '    'frmPpal.vdf.BaseControl.ActiveDocument.CommandAction.CmdExplode(miCota)
                            miCota.TextColor.FromInt32(6)
                            miCota.Update()
                            miCota.Invalidate()
                        End If
                        'ElseIf entidad._TypeName = "vdAttribDef" Then
                        '    'Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))
                        '    Dim textoAtributo As New vdAttribDef
                        '    textoAtributo.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                        '    textoAtributo.setDocumentDefaults()
                        '    textoAtributo = CType(entidad, vdAttribDef)
                        '    If textoAtributo.PenColor.ByLayer Then
                        '        Dim capa As New VectorDraw.Professional.vdPrimaries.vdLayer
                        '        capa.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
                        '        capa.setDocumentDefaults()
                        '        capa = VdF.BaseControl.ActiveDocument.Layers.FindName(textoAtributo.Layer.ToString)
                        '        indiceColor = capa.PenColor.ColorIndex
                        '        textoAtributo.PenColor.ByLayer = False
                        '        textoAtributo.PenColor.ByColorIndex = True
                        '        textoAtributo.PenColor.FromInt32(6)
                        '        textoAtributo.Update()
                        '        textoAtributo.Invalidate()
                        '    Else
                        '        textoAtributo.PenColor.FromInt32(6)
                        '        textoAtributo.Update()
                        '        textoAtributo.Invalidate()
                        '    End If
                        '    textoAtributo.Update()
                    Else
                        entidad.PenColor.FromInt32(6)
                    End If
                Next
            End If

            fig.PenColor.FromInt32(6)


            '=======================================================================================
            'el espesor:
            '=======================================================================================
            Select Case indiceColor
                Case Is = 0 'rojo, 01 ó 018
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_18
                Case Is = 1 'amarillo, 02 ó 025
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_20
                Case Is = 2 'verde, 03 
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_30
                Case Is = 3 'cyan, o 04
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_40
                Case Is = 4 'azul o 05
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_50
                Case Is = 5 'magenta ó 07
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_70
                Case Is = 6 'negro o blanco.. 08
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_80
                Case Is = 7
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_18
                Case Else
                    fig.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_18
            End Select


            fig = Nothing
        Next

        VdF.BaseControl.ActiveDocument.Redraw(True)
        VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

    End Sub


#Region "Evento del objeto doc. Parsear linea de comandos"
    Private Sub doc_ActionParse(ByVal sender As Object, ByVal actionName As String, ByVal parseString As String, ByRef cancel As Boolean) Handles doc.ActionParse
        '===============================================================
        ' parsear (capturar) lo que se escribe en la linea de comandos
        '===============================================================
        If parseString.StartsWith("'") Then
            lineaComandos.ExecuteCommand(parseString.TrimStart("'\"))
            lineaComandos.ExecuteCommand(actionName)
            cancel = True

        End If

    End Sub
#End Region


#Region "Mouse. (Doble click, Mouse down (boton derecho), Mouse weel, Mouse click)"
    Private Sub baseControl_vdMouseDoubleClick(ByVal e As System.Windows.Forms.MouseEventArgs, ByRef cancel As Boolean) Handles baseControl.vdMouseDoubleClick
        '-------------------------------------
        ' doble click del mouse
        '-------------------------------------
        'si es el boton derecho me voy..
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Exit Sub
        End If
        'si es el boton del medio (si lo hubiera) me voy..
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            Exit Sub
        End If
        'si hay un comando pendiente me voy..
        If Me.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            Exit Sub
        End If
        'si se esta dibujando un rectangulo de seleccion me voy...
        If (TypeOf VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveAction Is VectorDraw.Actions.ActionGetRectFromPointSelectDCS) Then
            Exit Sub
        End If
        'si voy a mover un grip me  voy...
        If (TypeOf VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveAction Is VectorDraw.Professional.ActionUtilities.CmdMoveGripPoints) Then
            Exit Sub
        End If

        Dim seleccionDeGrips As vdSelection = obtenerSeleccion()
        If seleccionDeGrips.Count > 1 Then
            MsgBox("Seleccionar solo UNA entidad (para editar)")
            Exit Sub
        End If

        '13 de agosto
        manejarPropiedadesLeer()

        Dim elBloque As vdInsert, elMtext As vdMText

        For Each fig As vdFigure In seleccionDeGrips

            '----------------------------------------------------------
            'en caso que sea un texto..
            If fig._TypeName = "vdText" Then
                frmPropiedades.tipoObjeto = "Texto"
                If InStr(fig.ToolTip.ToString, "Identificador Macizo") > 0 Then
                    MsgBox("Para editar la nomenclatura ir a la pantalla ""Inicial""", vbInformation, "Plano Digital")
                    Exit Sub
                End If
                If InStr(fig.ToolTip.ToString, "Medida lado parcela") > 0 Then
                    MsgBox("Las medidas de la parcela no son editables", vbInformation, "Plano Digital")
                    Exit Sub
                End If
                entidad = fig
                frmTextEdit.ShowDialog()
                Exit Sub
            End If
            '-----------------------------------------------------------


            'en caso que sea un Mtext..
            If fig._TypeName = "vdMText" Then
                entidad = fig
                frmTextEdit.ShowDialog()
                Exit Sub
            End If


            '--------------------------
            'es un bloque..
            If fig._TypeName = "vdInsert" Then

                elBloque = New vdInsert
                elBloque = fig
                If elBloque.Attributes.Count > 0 Then
                    frmAte.cargarDatos(elBloque)
                    frmAte.ShowDialog()
                End If
                Exit Sub
            End If


            '--------------------------------
            'es un hatch..
            If fig._TypeName = "vdPolyhatch" Then
                frmPropiedades.tipoObjeto = "Trama"
                entidad = fig
                'frmHatchEdit.ShowDialog()
                frmTramadosEdit.ShowDialog()
                Exit Sub
            End If


            '----------------------------------
            'es una cota..
            If fig._TypeName = "vdDimension" Then
                frmPropiedades.tipoObjeto = "Cota"
                entidad = fig
                'frmPropiedades.ShowDialog()
                frmCotaEdit.ShowDialog()
                Exit Sub
            End If


            '----------------------------------
            'es un arco
            If fig._TypeName = "vdArc" Then
                frmPropiedades.tipoObjeto = "Arco"
                entidad = fig
                frmPropiedades.ShowDialog()
                Exit Sub
            End If


            '----------------------------------
            'es un circulo
            If fig._TypeName = "vdCircle" Then
                frmPropiedades.tipoObjeto = "Circulo"
                entidad = fig
                frmPropiedades.ShowDialog()
                Exit Sub
            End If


            '----------------------------------
            'es una elipse 
            If fig._TypeName = "vdEllipse" Then
                frmPropiedades.tipoObjeto = "Elipse"
                entidad = fig
                frmPropiedades.ShowDialog()
                Exit Sub
            End If


            '----------------------------------
            'es un leader
            If fig._TypeName = "vdLeader" Then
                frmPropiedades.tipoObjeto = "Leader"
                entidad = fig
                frmPropiedades.ShowDialog()
                Exit Sub

            End If


            '----------------------------------
            'es una linea 
            If fig._TypeName = "vdLine" Then
                frmPropiedades.tipoObjeto = "Linea"
                entidad = fig
                frmPropiedades.ShowDialog()
                Exit Sub

            End If

            '-----------------------------------
            'es una polilinea 
            If fig._TypeName = "vdPolyline" Then
                If InStr(fig.ToolTip.ToString, "Parcela principal") > 0 Then
                    frmPruebaParcela.Show()
                Else
                    frmPropiedades.tipoObjeto = "Polilinea"
                    entidad = fig
                    frmPropiedades.ShowDialog()
                End If
                Exit Sub
            End If

            '----------------------------------
            'es un punto
            If fig._TypeName = "vdPoint" Then
                frmPropiedades.tipoObjeto = "Punto"

                entidad = fig
                frmPropiedades.ShowDialog()
                Exit Sub

            End If


            '-----------------------------------
            'es un rectangulo
            If fig._TypeName = "vdRect" Then
                frmPropiedades.tipoObjeto = "Rectangulo"
                entidad = fig
                frmPropiedades.ShowDialog()
                Exit Sub

            End If
        Next fig
        LimpiarSeleccion(obtenerSeleccion)

        Me.VdF.BaseControl.ActiveDocument.Redraw(True)
        Me.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

    End Sub
    Private Sub baseControl_vdMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs, ByRef cancel As Boolean) Handles baseControl.vdMouseDown
        Dim tipo As Object, value As Boolean, area As Double, perimetro As Double

        '--------------------------------------------------------------------------------------
        ' Boton derecho del mouse
        '--------------------------------------------------------------------------------------
        'If obtenerSeleccion.Count > 0 And e.Button = Windows.Forms.MouseButtons.Left Then
        '    For Each elemento As vdFigure In obtenerSeleccion()
        '        elemento.HighLight = True
        '    Next
        'End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            Exit Sub
        End If
        If Me.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            Exit Sub
        End If
        If obtenerSeleccion.Count > 0 And e.Button = Windows.Forms.MouseButtons.Right Then
            LimpiarSeleccion(obtenerSeleccion)
            Exit Sub
        End If

        'ultimo comando:
        Select Case UCase(ultimoComando)
            Case "ALINEAR"
                alinear()
            Case "IMPORTARANTECEDENTE"
                importarAntecedente()
            Case "GUARDARANTECEDENTE"
                Guarda_Antecedente()
            Case "CERTIFICADOAMOJONAMIENTO"
                certificadoAmojonamiento()
            Case "PLANTILLAGEODESIA"
                plantillaGeodesia()


            Case "NUEVOARCHIVO"
                NuevoArchivo()
            Case "ABRIRDWT"
                AbrirDwt()
            Case "ABRIRARCHIVO"
                AbrirArchivo()
            Case "CERRARARCHIVO"
                cerrarArchivo()
            Case "IMPRIMIR"
                imprimir()
            Case "GUARDARARCHIVO"
                GuardarArchivo()
            Case "GUARDARARCHIVOCOMO"
                GuardarArchivoComo()


            Case "INSERT"
                Agregar_Bloques()
            Case "DIALOGOCOLORES"
                colores()
            Case "ACOTARAGRIMENSURA"
                Acotar(False, False, True, True)
            Case "ACOTARAGRIMENSURAARRIBA"
                Acotar(True, False, True, True)
            Case "ACOTARAGRIMENSURAABAJO"
                Acotar(False, True, True, True)
            Case "ESPESORES"
                espesores()
            Case "PRENDEAPAGAGRILLA"
                propertyGrid()
            Case "LAYERS"
                layers()

            Case "CORTARCLIP"
                cortarClip()
            Case "COPIARCLIP"
                copiarClip()
            Case "PEGARCLIP"
                pegarClip()

            Case "COPIAR"
                copiar()
            Case "MIRROR"
                mirror()
            Case "MOVER"
                modPublico.mover()
            Case "ROTAR"
                rotate()
            Case "ESCALEAR"
                modPublico.escala()
            Case "TRIM"
                trimear()
            Case "EXTENDER"
                extend()
            Case "EXPLODE"
                explode()
            Case "FILLETR0"
                filletr0()
            Case "FILLET"
                fillet()
            Case "OFFSET"
                offset()
            Case "BREAK"
                break()

            Case "LINEA"
                linea()
            Case "XLINEA"
                xlinea()
            Case "XRAY"
                modPublico.xray()
            Case "POLILINEA"
                polilinea()
            Case "ARCO"
                arco()
            Case "RECTANGULO"
                rectangulo()
            Case "CIRCULO"
                circulo()
            Case "ELIPSE"
                elipse()
            Case "PUNTO"
                punto()
            Case "ESTILOPUNTO"
                VdF.BaseControl.ActiveDocument.CommandAction.CmdPointStyleDlg()
            Case "HATCH"
                hatch()
            Case "BORRAR"
                borrar("noTeclaSupr")
            Case "DESHACER"
                deshacer()
            Case "REHACER"
                rehacer()


            Case "PAN"
                pan()

            Case "ZE"
                ze()
            Case "ZW"
                zw()
            Case "ZP"
                zp()
            Case "ZR"
                zr()
            Case "ZA"
                za()


            Case "ATTEDIT"
                attedit()
            Case "IDPUNTO"
                modPublico.IdPunto()


            Case "LEADER"
                AcotarDibujo("Leader")
            Case "COTAALINEADA"
                AcotarDibujo("Alineada")
            Case "COTARADIAL"
                AcotarDibujo("Radial")
            Case "COTADIAMETRAL"
                AcotarDibujo("Diametral")
            Case "COTAANGULAR"
                AcotarDibujo("Angular")
            Case "COTAESTILO"
                AcotarDibujo("Estilo")


            Case "COPIARPROPIEDADES"
                VdF.CommandLine.PostExecuteCommand("pincelito")
            Case "TEXTOSINGLE"
                VdF.CommandLine.PostExecuteCommand("text")
            Case "ESCVP"
                modPublico.ingresaEscalaVp()
            Case "CUADRODIALOGOTIPOLINEA"
                tipoLinea()

            Case "ENVIARALFONDO"
                lineaComandos.ExecuteCommand("stb")
            Case "TRAERALFRENTE"
                lineaComandos.ExecuteCommand("btf")

            Case "NUEVOLAYOUT"
                frmNuevoLayout.EdicionLamina = False
                frmNuevoLayout.ShowDialog()
            Case "NUEVOVIEWPORT"
                nuevoViewport()
            Case "ESCALA_10"
                escalaViewport(10)
            Case "ESCALA_50"
                escalaViewport(50)
            Case "ESCALA_1"
                escalaViewport(1)
            Case "INGRESAESCALA"
                ingresaEscalaVp()
            Case "GIROVP"
                giroViewport()
            Case "RESETVP"
                resetViewport()
            Case "BLOQUEARVP"
                BloquearViewPort()
            Case "UNIDADESESPACIOPAPEL"
                btnUnidadesPapel_Click(Nothing, Nothing)
            Case "TEXTOUNALINEA"
                textoSingle()
            Case "TEXTOMULTILINEA"
                textoMulti()
            Case "ESTILOTEXTO"
                estiloTextos()
            Case "BLOQUECREAR"
                VdF.BaseControl.ActiveDocument.CommandAction.CmdMakeBlock(Nothing, Nothing, Nothing)
            Case "INSERTARBLOQUE"
                insertarBloque()
            Case "CREARATRIBUTO"
                frmAte.atributosCrear()
            Case "DISTANCIA"
                VdF.BaseControl.ActiveDocument.CommandAction.cmdDistance()
            Case "AREAXVERTICES"
                tipo = "P"
                value = VdF.BaseControl.ActiveDocument.CommandAction.CmdArea(tipo, Nothing, area, perimetro)
                If value Then
                    MsgBox("Area: " & CStr(area) & ", Perímetro: " & CStr(perimetro), MsgBoxStyle.Information, aplicacionNombre)
                End If
            Case "AREAXENTIDAD"
                tipo = "E"
                value = VdF.BaseControl.ActiveDocument.CommandAction.CmdArea(tipo, Nothing, area, perimetro)
                If value Then
                    MsgBox("Area: " & CStr(area) & ", Perímetro: " & CStr(perimetro), MsgBoxStyle.Information, aplicacionNombre)
                End If
            Case "OSNAP"
                VectorDraw.Professional.Dialogs.OSnapDialog.Show(doc, VdF.BaseControl.ActiveDocument.ActionControl)
            Case "PROPIEDADES"
                propertyGrid()
            Case "LAYERS"
                layers()

            Case "CONFIGURACURSOR"
                frmConfiguraCursor.ShowDialog()

            Case "CHPROPIEDADES"
                frmPropiedades.ShowDialog()
            Case "CONFIGURALAMINAS"
                frmNuevoLayout.EdicionLamina = True
                frmNuevoLayout.ShowDialog()
            Case "CONFIGURAGRILLA"
                frmGrilla.ShowDialog()
            Case "IMAGEN"
                insertaImagen()
            Case "AUTOSAVE"
                configuraAutosave()
            Case "CONFMODELSPACE"
                frmConfiguraEspacioModelo.ShowDialog()

        End Select

    End Sub
    Private Sub baseControl_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles baseControl.MouseWheel

        If modeloSi() = True Then
            Exit Sub
        End If

        If DisplayBloqueado() Then
            VdF.BaseControl.ActiveDocument.MouseWheelZoomScale = 1.0
        Else
            VdF.BaseControl.ActiveDocument.MouseWheelZoomScale = 1.2
        End If

        ToolStrViewportsEscala.Text = CStr(verEscalaViewport())

    End Sub
    'al hacer click con el boton izquierdo del mouse y no haber ningun comando activo
    'restituye el prompt "Comando:"
    Private Sub baseControl_vdMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs, ByRef cancel As Boolean) Handles baseControl.vdMouseClick
        If e.Button = Windows.Forms.MouseButtons.Left And VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops = 0 Then
            VdF.BaseControl.ActiveDocument.Prompt("Comando:")
        End If
        '13 de agosto
        manejarPropiedadesLeer()
    End Sub
#End Region


    Private Sub manejarPropiedadesLeer() '13 de agosto

        Dim seleccionGrip As vdSelection = VdF.BaseControl.ActiveDocument.GetGripSelection
        If seleccionGrip.Count = 1 Then
            'se selecciono una sola entidad...

            'el tema del layer...
            layerActual = comboLayers.LayersDocument.ActiveLayer
            comboLayers.LayersDocument.ActiveLayer = seleccionGrip.Item(0).Layer

            'el tipo de linea
            If Not IsNothing(doc.ActiveLineType) Then
                tipoLineaActual = doc.ActiveLineType.Name  'ToolStrLayersCmbTipoLinea.Text
                ToolStrLayersCmbTipoLinea.Text = seleccionGrip.Item(0).LineType.Name
            End If

            'espesorLineaActual = ToolStrLayersCmbEspesor.Text
            espesorLineaActual = doc.ActiveLineWeight
            Select Case doc.ActiveLineWeight
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_BYBLOCK
                    espesorLineaActual = "LW_BYBLOCK"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_BYLAYER
                    espesorLineaActual = "LW_BYLAYER"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_DOCUMENTDEFAULT
                    espesorLineaActual = "LW_DOCUMENTDEFAULT"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_0
                    espesorLineaActual = "LW_0"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_100
                    espesorLineaActual = "LW_100"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_106
                    espesorLineaActual = "LW_106"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_120
                    espesorLineaActual = "LW_120"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_13
                    espesorLineaActual = "LW_13"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_140
                    espesorLineaActual = "LW_140"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_15
                    espesorLineaActual = "LW_15"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_158
                    espesorLineaActual = "LW_158"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_18
                    espesorLineaActual = "LW_18"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_20
                    espesorLineaActual = "LW_20"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_200
                    espesorLineaActual = "LW_200"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_211
                    espesorLineaActual = "LW_211"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_25
                    espesorLineaActual = "LW_25"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_30
                    espesorLineaActual = "LW_30"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_35
                    espesorLineaActual = "LW_35"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_40
                    espesorLineaActual = "LW_40"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_5
                    espesorLineaActual = "LW_5"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_50
                    espesorLineaActual = "LW_50"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_53
                    espesorLineaActual = "LW_53"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_60
                    espesorLineaActual = "LW_60"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_70
                    espesorLineaActual = "LW_70"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_80
                    espesorLineaActual = "LW_80"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_9
                    espesorLineaActual = "LW_9"
                Case Is = VectorDraw.Professional.Constants.VdConstLineWeight.LW_90
                    espesorLineaActual = "LW_90"
            End Select
            ToolStrLayersCmbEspesor.Text = seleccionGrip.Item(0).LineWeight.ToString
        End If

    End Sub


#Region "encenderApagarToolbars"
    ' rutinas para encender y apagar las toolbars...
    Private Sub DibujarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DibujarToolStripMenuItem1.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' Dibujar
        '-----------------------------------------------
        If sender.checked = True Then
            ToolStrDibujar.Visible = True
        Else
            ToolStrDibujar.Visible = False
        End If
    End Sub
    Private Sub EdiciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdiciónToolStripMenuItem.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' Editar
        '-----------------------------------------------
        If sender.checked = True Then
            ToolStrEditar.Visible = True
        Else
            ToolStrEditar.Visible = False
        End If

    End Sub
    Private Sub OsnapToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OsnapToolStripMenuItem1.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' Osnap
        '-----------------------------------------------
        If sender.checked = True Then
            ToolStrOsnap.Visible = True
        Else
            ToolStrOsnap.Visible = False
        End If

    End Sub
    Private Sub LayersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayersToolStripMenuItem1.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' Layers
        '-----------------------------------------------
        If sender.checked = True Then
            ToolStrLayers.Visible = True
        Else
            ToolStrLayers.Visible = False
        End If

    End Sub
    Private Sub EstandarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstandarToolStripMenuItem.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' General
        '-----------------------------------------------
        If sender.checked = True Then
            toolStrGeneral.Visible = True
        Else
            toolStrGeneral.Visible = False
        End If

    End Sub
    Private Sub Edición2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edición2ToolStripMenuItem.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' Editar2
        '-----------------------------------------------
        If sender.checked = True Then
            ToolStrEditar2.Visible = True
        Else
            ToolStrEditar2.Visible = False
        End If
    End Sub
    Private Sub VistasPanYZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VistasPanYZoomToolStripMenuItem.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' Vistas (zoom, pan etc)
        '-----------------------------------------------
        If sender.checked = True Then
            ToolStrVistas.Visible = True
        Else
            ToolStrVistas.Visible = False
        End If

    End Sub
    Private Sub ViewPortsescalasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewPortsescalasToolStripMenuItem.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' ViewPorts Escalas
        '-----------------------------------------------
        If sender.checked = True Then
            ToolStrViewports.Visible = True
        Else
            ToolStrViewports.Visible = False
        End If

    End Sub
    Private Sub CotasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CotasToolStripMenuItem.Click
        '-----------------------------------------------
        ' Menu Herramientas, encender y apagar toolbars.
        ' Cotas
        '-----------------------------------------------
        If sender.checked = True Then
            ToolStrCotas.Visible = True
        Else
            ToolStrCotas.Visible = False
        End If

    End Sub
#End Region


#Region "frmPpal formClosing"
    Private Sub frmPpal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-----------------------------------------------------------------------------------------------
        ' para que funcione bien lo de preguntar de guardar al cerrar con la cruz de arriba a la derecha
        '-----------------------------------------------------------------------------------------------

        If frmDatosCroquis.Visible Then
            frmDatosCroquis.Close()
        End If

        Exit Sub
        Static pasadas As Integer = 0
        pasadas = pasadas + 1

        My.Settings.estadoVentanaAplicacion = WindowState
        My.Settings.nuncaSeGuardo = False

        If WindowState <> FormWindowState.Normal Then
            My.Settings.Left = Me.RestoreBounds.Left
            My.Settings.top = Me.RestoreBounds.Top
            My.Settings.heigth = Me.RestoreBounds.Height
            My.Settings.width = Me.RestoreBounds.Width
        Else
            My.Settings.Left = Me.Left
            My.Settings.top = Me.Top
            My.Settings.heigth = Me.Height
            My.Settings.width = Me.Width

        End If
        My.Settings.Save()

        guardarConfiguracionOsnap()

        If pasadas = 1 And cerrarOk = False Then
            cerrar()
        End If

        modConn.cerrarConexion()

    End Sub
#End Region


#Region "cerrar"
    Public Sub cerrar()
        '---------------------------------------------------------------------------------------
        ' se ejecuta cuando se cierra, tanto por el menu como por la cruz de arriba a la derecha
        '---------------------------------------------------------------------------------------
        If Me.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            Me.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        If huboCambios() And versionCad <> "Demo" Then
            GuardarArchivoComo()
        End If

        cerrarOk = True
        Me.Close()

    End Sub
#End Region


#Region "btn toolstr apagar layers"
    Private Sub toolStrBtnApagarLayersPapel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStrBtnApagarLayersPapel.Click
        'esto devuelve true si estoy en la SOLAPA de espacio modelo..ojo
        'que si estoy en alguna SOLAPA del espacio papel siempre devuelve FALSO, 
        'por mas que este en el modelo pero dentro de un viewport, igual sigo parado en la solapa del
        'espacio papel.
        If modeloSi() = False And viewPortSiNo() = True Then
            frmEncenderApagarLayers.ShowDialog()
        End If
    End Sub
#End Region


#Region "Toolbar ViewPorts"
#Region "btn unidades papel"
    Public Sub btnUnidadesPapel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnidadesPapel.Click
        '--------------------------------------------------------------------
        'se hizo click en el boton de cambiar las unidades del espacio papel.
        '--------------------------------------------------------------------
        If viewPortSiNo() = False Then
            MsgBox("Comando para espacio papel (dentro de un ViewPort)", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        If btnUnidadesPapel.Text = "Unidades Papel = mm" Then
            btnUnidadesPapel.Text = "Unidades Papel = cm"
        Else
            btnUnidadesPapel.Text = "Unidades Papel = mm"
        End If
        ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
    End Sub
#End Region

#Region "btn bloquear vp"
    Private Sub btnBloquearVP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBloquearVP.Click
        '-------------------------------------------------------------------------
        ' este es el botoncito de la toolbar de los viewports. Sirve para bloquear
        ' desbloquear un viewport.
        '-------------------------------------------------------------------------

        BloquearViewPort()

    End Sub
#End Region

#Region "btn escala viewport"
    Private Sub ToolStrEscViewpBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrEscViewpBtn.Click
        '======================================================================================
        ' botoncito de la toolbar de la escala del viewport. Se hace le hace click para aceptar
        ' la escala ingresada. Tambien se puede oprimir la tecla enter.
        '=======================================================================================
        Dim escala As String

        If modeloSi() = True And estoyEnUnViewport() = False Then
            MsgBox("comando para espacio papel", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        escala = ToolStrViewportsEscala.Text
        If btnUnidadesPapel.Text = "Unidades Papel = mm" Then
            escalaViewport(1000 / CSng(escala))
        Else
            escalaViewport(100 / CSng(escala))
        End If


    End Sub
#End Region
#End Region


#Region "baseControl keyDown"
    Private Sub baseControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles baseControl.KeyDown
        '------------------------------------------------
        ' se esta oprimiendo una tecla..
        '------------------------------------------------

        Select Case e.KeyCode

            Case Keys.Delete
                modPublico.borrar("TeclaSupr")
                If Me.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
                    Me.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
                End If
            Case Keys.Escape
                LimpiarSeleccion(obtenerSeleccion)
                VdF.BaseControl.ActiveDocument.Prompt("Comando:")
                '13 de agosto
                lineaComandos.UserText.Clear()
                'el layer activo:
                If Not IsNothing(layerActual) Then
                    comboLayers.LayersDocument.ActiveLayer = layerActual
                End If
                'el tipo de linea:
                ToolStrLayersCmbTipoLinea.Text = tipoLineaActual
                'el espesor de linea actual:
                ToolStrLayersCmbEspesor.Text = espesorLineaActual
                If Me.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
                    Me.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
                End If
            Case Keys.F8
                If VdF.BaseControl.ActiveDocument.OrthoMode Then
                    VdF.BaseControl.ActiveDocument.OrthoMode = False
                Else
                    VdF.BaseControl.ActiveDocument.OrthoMode = True
                End If
            Case Keys.F7
                If VdF.BaseControl.ActiveDocument.GridMode Then
                    VdF.BaseControl.ActiveDocument.GridMode = False
                Else
                    VdF.BaseControl.ActiveDocument.GridMode = True
                End If
                VdF.BaseControl.ActiveDocument.Redraw(True)
            Case Keys.F9
                If VdF.BaseControl.ActiveDocument.SnapMode Then
                    VdF.BaseControl.ActiveDocument.SnapMode = False
                Else
                    VdF.BaseControl.ActiveDocument.SnapMode = True
                End If
                'Case Keys.F3
                'MsgBox("Temporariamente apagar o enceder Osnap desde la barra de herramientas (toolbar) correspondiente.", MsgBoxStyle.Information, aplicacionNombre)
                'Exit Sub

            Case Keys.F3
                If VdF.BaseControl.ActiveDocument.osnapMode = OsnapMode.DISABLE Then
                    recargarOsnap(valorOsnap)
                    'solapaOsnapActivada = True
                    'ToolStrOsnapActivado.Text = "SI"
                    'ToolStrOsnapActivado.ToolTipText = "Osnap Activado"
                Else
                    valorOsnap = VdF.BaseControl.ActiveDocument.osnapMode.ToString
                    VdF.BaseControl.ActiveDocument.osnapMode = OsnapMode.DISABLE
                    'solapaOsnapActivada = False
                    'ToolStrOsnapActivado.Text = "NO"
                    'ToolStrOsnapActivado.ToolTipText = "Osnap Desactivado"
                End If
            Case Else
                'If VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
                '    'VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
                '    Exit Sub
                'Else
                '    VdF.CommandLine.Focus()
                'End If
                ''If obtenerSeleccion.Count > 0 Then
                ''    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdCopy(obtenerSeleccion, "USER", "USER")
                ''Else
                ''    'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdCopy("USER", "USER", "USER")
                ''    frmPpal.VdF.CommandLine.PostExecuteCommand("copy")
                ''End If
                ''LimpiarSeleccion(obtenerSeleccion)

        End Select
    End Sub
#End Region


#Region "Click item de menu: Cargar datos en archivo de activacion e Ingresar codigo activacion"
    Private Sub CargarDatosEnArchivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarDatosEnArchivoToolStripMenuItem.Click
        frmDatosActivar.ShowDialog()
    End Sub

    Private Sub IngresarElCodigoDeActivaciònToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarElCodigoDeActivaciònToolStripMenuItem.Click
        frmCodigoActivar.ShowDialog()
    End Sub
#End Region


    Private Sub toolStripBtnPropVP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripBtnPropVP.Click
        frmPropiedades.tipoObjeto = "ViewPort"
        entidad = VdF.BaseControl.ActiveDocument.ActiveLayOut.ActiveViewPort
        frmPropiedades.ShowDialog()
    End Sub

    Private Sub botonApagarViewports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonApagarViewports.Click
        Try
            If VdF.BaseControl.ActiveDocument.Layers.FindName("marcos").Frozen Then
                VdF.BaseControl.ActiveDocument.Layers.FindName("marcos").Frozen = False
            Else
                VdF.BaseControl.ActiveDocument.Layers.FindName("marcos").Frozen = True
            End If
            VdF.BaseControl.ActiveDocument.Redraw(True)
            VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        Catch ex As Exception
            MsgBox("Comando para espacio papel", vbCritical, aplicacionNombre)
            Err.Clear()
            Exit Sub
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '-------------------------------
        ' este timer es para el autosave
        '-------------------------------
        autoSave()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        '---------------------------------------------------------------------------------------------
        ' este timer es para limpiar la linea de comandos de los carteles de guardado ok y de copia de 
        ' seguridad hecha ok
        '---------------------------------------------------------------------------------------------
        'If InStr(lineaComandos.UserText.Text, "Archivo ") <> 0 Or _
        '    InStr(lineaComandos.UserText.Text, "Copia") <> 0 Then
        '    lineaComandos.UserText.Text = ""
        'End If
        'If Not IsNothing(lineaComandos.UserText.Text) Then
        '    If InStr(lineaComandos.UserText.Text, "Archivo ") <> 0 Or InStr(lineaComandos.UserText.Text, "Copia") <> 0 Then
        '        lineaComandos.UserText.Text = ""
        '    End If
        'End If

    End Sub

    'Private Sub doc_OnGetGripPoints(ByVal sender As Object, ByVal gripPoints As VectorDraw.Geometry.gPoints, ByRef cancel As Boolean) Handles doc.OnGetGripPoints



    '    Dim linea As VectorDraw.Professional.vdFigures.vdLine = TryCast(sender, VectorDraw.Professional.vdFigures.vdLine)

    '    If Not linea Is Nothing Then
    '        linea.HighLight = True
    '    End If

    '    'cancel = True
    '    VdF.BaseControl.ActiveDocument.Redraw(True)
    '    'VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
    'End Sub


    'Private Sub doc_OnFilterFigure(ByVal sender As Object, ByVal JobId As VectorDraw.Professional.Constants.VdConstFilterFig, ByVal fig As VectorDraw.Professional.vdPrimaries.vdFigure, ByRef cancel As Boolean) Handles doc.OnFilterFigure
    '    Dim linea As VectorDraw.Professional.vdFigures.vdLine = TryCast(fig, VectorDraw.Professional.vdFigures.vdLine)
    '    If Not linea Is Nothing Then
    '        If linea.HighLight = True Then
    '            linea.HighLight = False
    '        Else
    '            linea.HighLight = True
    '        End If
    '    End If
    '    VdF.BaseControl.ActiveDocument.Redraw(True)

    'End Sub
    'Private Sub baseControl_GetGripPoints(ByVal sender As Object, ByVal gripPoints As VectorDraw.Geometry.gPoints, ByRef cancel As Boolean) Handles baseControl.GetGripPoints
    '    Dim linea As VectorDraw.Professional.vdFigures.vdLine = TryCast(sender, VectorDraw.Professional.vdFigures.vdLine)

    '    If Not linea Is Nothing Then
    '        linea.HighLight = True
    '    End If

    '    cancel = True
    '    VdF.BaseControl.ActiveDocument.Redraw(True)
    'End Sub
    'Private Sub baseControl_GripSelectionModified(ByVal sender As Object, ByVal layout As VectorDraw.Professional.vdPrimaries.vdLayout, ByVal gripSelection As VectorDraw.Professional.vdCollections.vdSelection) Handles baseControl.GripSelectionModified
    '    For Each elementoSeleccionado As VectorDraw.Professional.vdObjects.vdObject In gripSelection
    '        Dim linea As VectorDraw.Professional.vdFigures.vdLine = TryCast(elementoSeleccionado, VectorDraw.Professional.vdFigures.vdLine)
    '        If Not linea Is Nothing Then
    '            linea.HighLight = True
    '        End If
    '    Next


    'End Sub
    'Private Sub baseControl_ActionEnd(ByVal sender As Object, ByVal actionName As String) Handles baseControl.ActionEnd

    '    ''me guardo el cursor original
    '    'Dim elCursorOriginal As System.Windows.Forms.Cursor
    '    'elCursorOriginal = VdF.BaseControl.GetCustomMousePointer
    '    ''activo el cursor de seleccionar, el cuadradito:
    '    'Dim cursorDeSeleccionar As Cursor
    '    'cursorDeSeleccionar = New Cursor(ubicacionSoporte & "\selecciona1.cur")
    '    'VdF.BaseControl.SetCustomMousePointer(cursorDeSeleccionar)

    '    If actionName.ToString = "CmdCopy" Then
    '        VdF.BaseControl.ActiveDocument.CommandAction.CmdCopy(VdF.BaseControl.ActiveDocument.Selections.Item(0), "USER", "USER")
    '        'VdF.BaseControl.ActiveDocument.CommandAction.CmdCopy(VdF.BaseControl.ActiveDocument.Selections.Item(0), VdF.BaseControl.ActiveDocument.LastPoint, "USER")
    '        'VdF.BaseControl.ActiveDocument.CommandAction.CmdCopy(VdF.BaseControl.ActiveDocument.Selections.Item(0), puntoEdicion, "USER")
    '    End If
    '    If actionName.ToString = "CmdOffset" Then
    '        VdF.BaseControl.ActiveDocument.CommandAction.CmdOffset("user", distanciaOffset, "user")
    '    End If

    '    ''activo el cursor original nuevamente
    '    'VdF.BaseControl.SetCustomMousePointer(elCursorOriginal)
    '    'ponerCursorOriginal()

    'End Sub

    'Private Sub doc_OnActionDrawOsnap(ByVal sender As Object, ByVal mode As VectorDraw.Geometry.OsnapMode, ByVal render As VectorDraw.Render.vdRender, ByRef cancel As Boolean) Handles doc.OnActionDrawOsnap
    '    'frmPpal.VdF.SetStatusBarOption(vdControls.vdFramedControl.StatusBarOptions.OsnapButton, False)

    'End Sub



    'Private Sub baseControl_AfterModifyObject(ByVal sender As Object, ByVal propertyname As String) Handles baseControl.AfterModifyObject
    '    If propertyname.ToString = "osnapMode" Then
    '        'If VdF.BaseControl.ActiveDocument.osnapMode = OsnapMode.DISABLE Then
    '        '    'recargarOsnap(valorOsnap)
    '        '    MsgBox(VdF.BaseControl.ActiveDocument.osnapMode.ToString & "osnap desactivado")
    '        'Else
    '        '    'valorOsnap = VdF.BaseControl.ActiveDocument.osnapMode.ToString
    '        '    'VdF.BaseControl.ActiveDocument.osnapMode = OsnapMode.DISABLE
    '        '    MsgBox(VdF.BaseControl.ActiveDocument.osnapMode.ToString & "osnap activado")
    '        'End If

    '        If VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
    '            If InStr(VdF.BaseControl.ActiveDocument.osnapMode.ToString, "DISABLE") <> 0 Then
    '                'MsgBox("osnap desactivado mientras hay un comando pendiente")
    '                'valorOsnap = VdF.BaseControl.ActiveDocument.osnapMode.ToString
    '                solapaOsnapActivada = False
    '            Else
    '                'MsgBox("osnap activado mientras hay un comando pendiente")
    '                'recargarOsnap(valorActualOsnap)
    '                solapaOsnapActivada = True
    '            End If
    '        Else
    '            If InStr(VdF.BaseControl.ActiveDocument.osnapMode.ToString, "DISABLE") <> 0 Then
    '                'MsgBox("osnap desactivado. No hay ningun comando pendiente")
    '                'valorOsnap = VdF.BaseControl.ActiveDocument.osnapMode.ToString
    '                solapaOsnapActivada = False
    '            Else
    '                'MsgBox("osnap activado. No hay ningun comando pendiente")
    '                solapaOsnapActivada = True
    '            End If
    '        End If
    '    End If
    'End Sub




    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
    '        If InStr(VdF.BaseControl.ActiveDocument.osnapMode.ToString, "DISABLE") <> 0 Then
    '            MsgBox("osnap desactivado mientras hay un comando pendiente")
    '        Else
    '            MsgBox("osnap activado mientras hay un comando pendiente")
    '        End If
    '    Else
    '        If InStr(VdF.BaseControl.ActiveDocument.osnapMode.ToString, "DISABLE") <> 0 Then
    '            MsgBox("osnap desactivado. No hay ningun comando pendiente")
    '        Else
    '            MsgBox("osnap activado. No hay ningun comando pendiente")
    '        End If
    '    End If
    'End Sub

    'Private Sub doc_OnActionDraw(ByVal sender As Object, ByVal action As Object, ByVal isHideMode As Boolean, ByRef cancel As Boolean) Handles doc.OnActionDraw
    '    If Not (TypeOf action Is VectorDraw.Actions.ActionGetRefPoint) Then Return
    '    Dim act As VectorDraw.Actions.BaseAction = action
    '    Dim refpoint As VectorDraw.Geometry.gPoint = act.ReferencePoint
    '    Dim currentpoint As VectorDraw.Geometry.gPoint = act.OrthoPoint
    '    Dim circle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
    '    circle.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
    '    circle.setDocumentDefaults()
    '    circle.Center = VectorDraw.Geometry.gPoint.MidPoint(refpoint, currentpoint)
    '    circle.Radius = circle.Center.Distance3D(refpoint)
    '    circle.Draw(act.Render)
    'End Sub


    'Private Sub baseControl_ActionEnd(ByVal sender As Object, ByVal actionName As String) Handles baseControl.ActionEnd
    '    If actionName = "CmdLine" Or _
    '        actionName = "CmdPolyLine" Or _
    '        actionName = "CmdXLine" Or _
    '        actionName = "CmdRay" Or _
    '        actionName = "CmdBreak" Or _
    '        actionName = "CmdFilletRadius" Or _
    '        actionName = "CmdFillet" Or _
    '        actionName = "CmdExplode" Or _
    '        actionName = "CmdClipPaste" Or _
    '        actionName = "CmdClipCopy" Or _
    '        actionName = "CmdClipCut" Or _
    '        actionName = "CmdCopy" Or _
    '        actionName = "CmdMove" Or _
    '        actionName = "CmdOffset" Or _
    '        actionName = "CmdMirror" Or _
    '        actionName = "CmdRotate" Or _
    '        actionName = "CmdScale" Or _
    '        actionName = "CmdTrim" Or _
    '        actionName = "CmdExtend" Or _
    '        actionName = "CmdArc" Or _
    '        actionName = "CmdRect" Or _
    '        actionName = "CmdCircle" Or _
    '        actionName = "CmdEllipse" Or _
    '        actionName = "CmdPoint" Or _
    '        actionName = "bHatch" Or _
    '        actionName = "CmdErase" Or _
    '        actionName = "" Then

    '        If InStr(VdF.BaseControl.ActiveDocument.osnapMode.ToString, "DISABLE") <> 0 Then
    '            MsgBox("El osnap esta desactivado")
    '        Else
    '            MsgBox("El osnap esta activado")
    '        End If

    '    End If
    'End Sub

    'Eventos sugeridos por vectordraw support>
    'Private Sub doc_OnAfterAddItem(ByVal obj As Object) Handles doc.OnAfterAddItem
    'End Sub
    'Private Sub doc_OnAfterModifyObject(ByVal sender As Object, ByVal propertyname As String) Handles doc.OnAfterModifyObject
    'End Sub









    'Private Sub baseControl_SaveUnknownFileName(ByVal sender As Object, ByVal fileName As String, ByRef success As Boolean) Handles baseControl.SaveUnknownFileName
    '    MsgBox("ok, " & fileName)
    '    'If versionVisadores Then
    '    '    MsgBox("version visadores")
    '    'Else
    '    '    MsgBox("version normal")
    '    'End If
    'End Sub

    'Private Sub doc_OnSaveUnknownFileName(ByVal sender As Object, ByVal fileName As String, ByRef success As Boolean) Handles doc.OnSaveUnknownFileName
    '    MsgBox("ok, " & fileName)
    '    'If versionVisadores Then
    '    '    MsgBox("version visadores")
    '    'Else
    '    '    MsgBox("version normal")
    '    'End If
    'End Sub
 
    'Private Sub baseControl_vdPaint(ByVal e As System.Windows.Forms.PaintEventArgs) Handles baseControl.vdPaint
    '    MsgBox("ok")
    'End Sub

    'Private Sub baseControl_GetSaveFileFilterFormat(ByRef saveFilter As String) Handles baseControl.GetSaveFileFilterFormat
    '    MsgBox("ok, " & saveFilter)
    'End Sub

    'Private Sub VdF_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles VdF.MouseClick
    '    MsgBox("ok")
    'End Sub

  
    Private Sub tsNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNuevo.Click
        '-----------------------------
        ' plano digital, nuevo trabajo
        '-----------------------------
        frmNuevo.ShowDialog()
    End Sub

    Private Sub definirMacizoPorPuntos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles definirMacizoPorPuntos.Click
        '------------------------------------------
        ' plano digital, definir macizo por puntos
        '------------------------------------------
        modMacizo.definirMacizoPorPuntos()
    End Sub

    Private Sub definirMacizoPorPolilinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles definirMacizoPorPolilinea.Click
        '--------------------------------------------------------------------
        ' plano digital, definir macizo seleccionando una polilinea existente
        '--------------------------------------------------------------------
        modMacizo.definirMacizoPorPolilinea()
    End Sub

    Private Sub DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem.Click
        '------------------------------------------------------------
        ' plano digital, definir macizo linderos seleccionando puntos
        '------------------------------------------------------------
        modMacizoLinderos.DefinirMacizoLinderosSeleccionandoPuntos()
    End Sub

    Private Sub DefinirMacizoSeleccionandoPolilineaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefinirMacizoSeleccionandoPolilineaToolStripMenuItem.Click
        '---------------------------------------------------------------------
        ' plano digital, macizo linderos seleccionando una polilinea existente
        '---------------------------------------------------------------------
        modMacizoLinderos.DefinirMacizoSeleccionandoPolilinea()
    End Sub

    Private Sub tsdDefinirPorPuntos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdDefinirPorPuntos.Click
        '--------------------------------------------------------
        ' plano digital, distancia a esquina seleccionando puntos
        '--------------------------------------------------------
        modDistanciaEsquina.distanciaEsquinaPorPuntos()
    End Sub

    Private Sub tsdDefinirPorPolilinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdDefinirPorPolilinea.Click
        '-------------------------------------------------------------------------
        ' plano digital, distancia a esquina seleccionando una polilinea existente
        '-------------------------------------------------------------------------
        modDistanciaEsquina.distanciaEsquinaPorPolilinea()
    End Sub

    Private Sub tsdDefinirPlPorPuntos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdDefinirPlPorPuntos.Click
        '--------------------------------------------
        ' plano digital
        ' Parcela PRINCIPAL
        ' plano digital, parcela seleccionando puntos
        '--------------------------------------------
        If verificarNorte() Then
            modParcela.parcelaDefinirPorPuntos()
        Else
            MsgBox("Insertar norte antes de definir parcela", vbInformation)
        End If

    End Sub

    Private Sub DefinirParcelaLinderaPorPuntosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefinirParcelaLinderaPorPuntosToolStripMenuItem.Click
        '--------------------------------------------
        ' Plano digital
        ' Parcela LINDERA
        ' plano digital, parcela seleccionando puntos
        '--------------------------------------------
        If verificarNorte() Then
            modParcela.parcelaLinderaDefinirPorPuntos()
        Else
            MsgBox("Insertar norte antes de definir parcela", vbInformation)
        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        '-------------------------------------------------------------
        ' Plano digital
        ' Parcela:
        ' plano digital, parcela seleccionando una polilinea existente
        '-------------------------------------------------------------
        If verificarNorte() Then
            modParcela.parcelaDefinirPorPolilinea()
        Else
            MsgBox("Insertar norte antes de definir parcela", vbInformation)
        End If

    End Sub

    Private Sub tsBorrarEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBorrarEntidad.Click
        '------------------------------------------
        ' plano digital, borrar
        '------------------------------------------
        VdF.CommandLine.PostExecuteCommand("borrar")
    End Sub

    Private Sub tsMoverParcela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMoverParcela.Click
        '--------------------------------------------------------
        ' Plano digital, Mostrar la pantalla de mover la parcela hacia el macizo
        '--------------------------------------------------------
        frmUbicaParcela.Show()
    End Sub

    Private Sub tsMuros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMuros.Click
        '--------------------------------------------------------
        ' Plano digital, Muros
        '--------------------------------------------------------
        'definirMuroPorPuntos()
        VdF.CommandLine.PostExecuteCommand("muros")
    End Sub

    Private Sub tsdNorteUno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdNorteUno.Click
        '--------------------------------------------------------
        ' Plano digital, Insertar un simbolo. El norte
        '--------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing
        Dim angulo As Double
        Dim medida As Integer

        VdF.BaseControl.ActiveDocument.Prompt("Seleccionar posicion del simbolo..")
        ret = VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(pt)
        VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            VdF.BaseControl.ActiveDocument.Prompt("Angulo? (antihorario desde la vertical)..")
            ret = VdF.BaseControl.ActiveDocument.ActionUtility.getUserDouble(angulo)
            VdF.BaseControl.ActiveDocument.Prompt(Nothing)
            If ret = VectorDraw.Actions.StatusCode.Success Then
                VdF.BaseControl.ActiveDocument.Prompt("Tamaño en metros? (sin decimales)..")
                ret = VdF.BaseControl.ActiveDocument.ActionUtility.getUserDouble(medida)
                VdF.BaseControl.ActiveDocument.Prompt(Nothing)
                If ret = VectorDraw.Actions.StatusCode.Success Then
                    dibujarNorte(0, pt, angulo, medida)
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub tsCroquis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCroquis.Click
        '----------------------------------
        ' plano digital, generar imagen
        '----------------------------------
        If croquis Then
            modGeneraJpg.generarImagen()
        Else
            MsgBox("Generar imàgen esta disponible solo para el croquis.", vbInformation, "Plano Digital")
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '------------------------------------------------------------
        ' Plano digital, boton azimut y rumbos
        '------------------------------------------------------------
        VdF.BaseControl.ActiveDocument.Prompt("Seleccionar LINEA (boton derecho del mouse para finalizar)")
        Dim seleccion As vdSelection = VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection
        VdF.BaseControl.ActiveDocument.Prompt(Nothing)

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

        If seleccion.Item(0)._TypeName = "vdLine" Then
            Dim laLinea As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine
            laLinea.SetUnRegisterDocument(VdF.BaseControl.ActiveDocument)
            laLinea.setDocumentDefaults()
            laLinea = CType(seleccion.Item(0), VectorDraw.Professional.vdFigures.vdLine)
            Dim puntoUno As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
            puntoUno = laLinea.StartPoint
            Dim puntoDos As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
            puntoDos = laLinea.EndPoint
            Dim azimutCalculado As Double
            Dim rumboCalculado As String
            azimutCalculado = calculoAzimut(puntoUno, puntoDos)
            rumboCalculado = calculoRumbo(azimutCalculado)
            MsgBox("El azimut es: " & azimutCalculado.ToString & ", y el rumbo es: " & rumboCalculado)
        End If

    End Sub

    Private Sub DefinirParcelaLinderaPorPolilineaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefinirParcelaLinderaPorPolilineaToolStripMenuItem.Click
        '---------------------------------------------------------
        ' plano digital
        '---------------------------------------------------------
        MsgBox("No operativo aùn", vbInformation, "Plano Digital")

    End Sub

    'Private Sub CroquisDatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CroquisDatosToolStripMenuItem.Click
    '    '---------------------------------------------------------
    '    ' plano digital
    '    '---------------------------------------------------------
    '    frmDatosCroquis.Show()
    'End Sub

    Private Sub tsGuardarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGuardarCambios.Click
        '---------------------------------------------------------
        ' plano digital
        '---------------------------------------------------------
        guardarCambios()

    End Sub

    Private Sub tsEstilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEstilos.Click
        '-------------------------------------------------------------
        ' Plano digital
        ' Estilos, editar
        '-------------------------------------------------------------
        frmEstilos.ShowDialog()
    End Sub

    Private Sub ConfiguraciónCursor_Click(sender As Object, e As EventArgs) Handles ConfiguraciónCursor.Click

    End Sub
End Class
