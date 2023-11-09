Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects
Imports System.IO
Imports System.Globalization

Module modPublico

#Region "Maneja eventos del menu principal y todas las Toolbars.."

    Public Sub ManejaEventosMenuPpal(ByVal sender As Object, ByVal e As System.EventArgs)
        ' el menu superior...
        '================================
        'Manejador de eventos
        '================================
        Dim tipo As Object
        Dim area As Double
        Dim perimetro As Double
        Dim value As Boolean

        Dim Key As String = sender.Tag
        Select Case Key

            '.....................................................................
            '   primer menu: File...
            '.....................................................................
            Case "Nuevo"
                NuevoArchivo()
                ultimoComando = "nuevoArchivo"
            Case "Abrir"
                AbrirArchivo()
                ultimoComando = "abrirArchivo"
            Case "abrirDwt"
                AbrirDwt()
                ultimoComando = "abrirDwt"
            Case "Cerrar"
                cerrarArchivo()
                ultimoComando = "cerrarAarchivo"
            Case "Guardar"
                GuardarArchivo()
                ultimoComando = "guardarArchivo"
            Case "GuardarComo"
                GuardarArchivoComo()
                ultimoComando = "guardarArchivoComo"
            Case "puntas"
                puntas()
            Case "Imprimir"
                imprimir()
                ultimoComando = "imprimir"
            Case "Salir"
                frmPpal.cerrar()

                '..............................................................
                'segundo menu: Edit...
                '..............................................................
            Case "Deshacer"
                deshacer()
                ultimoComando = "deshacer"
            Case "Rehacer"
                rehacer()
                ultimoComando = "rehacer"
            Case "Cortar"
                cortarClip()
                ultimoComando = "cortarClip"
            Case "CopiarClip"
                copiarClip()
                ultimoComando = "copiarClip"
            Case "Pegar"
                pegarClip()
                ultimoComando = "pegarClip"

                '..............................................................
                'tercer menu: Vistas...
                '..............................................................
            Case "Ze"
                ze()
                ultimoComando = "ze"
            Case "Zw"
                zw()
                ultimoComando = "zw"
            Case "Zp"
                zp()
                ultimoComando = "zp"
            Case "ZDisminuir"
                zr()
                ultimoComando = "zr"
            Case "ZAumentar"
                za()
                ultimoComando = "za"
            Case "Pan"
                pan()
                ultimoComando = "pan"
            Case "sendtoback"
                frmPpal.lineaComandos.ExecuteCommand("stb")
                ultimoComando = "enviarAlFondo"
            Case "bringtofront"
                frmPpal.lineaComandos.ExecuteCommand("btf")
                ultimoComando = "traerAlFrente"
            Case "NewLayout"
                frmNuevoLayout.EdicionLamina = False
                frmNuevoLayout.ShowDialog()
                ultimoComando = "nuevoLayout"
            Case "aPartirDeEntidad"
                viewportDesdeUnaEntidad()
                ultimoComando = "nuevoViewPort"
            Case "NewViewPort"
                nuevoViewport()
                ultimoComando = "nuevoViewPort"
            Case "100"
                escalaViewport(10)
                ultimoComando = "escala_10"
            Case "50"
                escalaViewport(20)
                ultimoComando = "escala_50"
            Case "1000"
                escalaViewport(1)
                ultimoComando = "escala_1"
            Case "IngresaEscala"
                ingresaEscalaVp()
                ultimoComando = "ingresaEscala"
            Case "girovp"
                giroViewport()
                ultimoComando = "giroVp"
            Case "resetvp"
                resetViewport()
                ultimoComando = "resetVp"
            Case "bvp"
                BloquearViewPort()
                ultimoComando = "bloquearVp"
            Case "unidadesEspacioPapel"
                frmPpal.btnUnidadesPapel_Click(Nothing, Nothing)
                ultimoComando = "unidadesEspacioPapel"


                '..............................................................
                'cuarto menu: Dibujar...
                '..............................................................
            Case "Linea"
                linea()
                ultimoComando = "linea"
            Case "xlinea"
                xlinea()
                ultimoComando = "xlinea"
            Case "xray"
                xray()
                ultimoComando = "xray"
            Case "Polilinea"
                polilinea()
            Case "Arco"
                arco()
            Case "Circulo"
                circulo()
            Case "Elipse"
                elipse()
            Case "Rectangulo"
                rectangulo()
            Case "Punto"
                punto()
            Case "EstiloPunto"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPointStyleDlg()
                ultimoComando = "estiloPunto"
            Case "UnaLinea" 'texto de una linea..
                textoSingle()
                ultimoComando = "textoUnaLinea"
            Case "Multilinea" 'texto multilinea..
                textoMulti()
                ultimoComando = "textoMultiLinea"
            Case "EstiloTexto"
                estiloTextos()
                ultimoComando = "estiloTexto"
            Case "Hatch"
                hatch()
                ultimoComando = "hatch"
                ' bloques
            Case "Crear"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMakeBlock(Nothing, Nothing, Nothing)
                ultimoComando = "BloqueCrear"
            Case "Insertar"
                insertarBloque()
                ultimoComando = "insertarBloque"
            Case "editarAtributos"
                attedit()
                ultimoComando = "attedit"
            Case "crearatributo"
                frmAte.atributosCrear()
                ultimoComando = "crearatributo"
            Case "exportarBloque"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdWriteBlock("User", "User", "User")
            Case "Imagenes"
                insertaImagen()


                '..............................................................
                'quinto menu: Modificar...
                '..............................................................
            Case "Borrar"
                borrar("noTeclaSupr")
            Case "Copiar"
                copiar()
            Case "Simetria"
                mirror()
            Case "Equidistancia"
                offset()
            Case "Mover"
                mover()
            Case "Rotar"
                rotate()
            Case "Escala"
                escala()
            Case "Recortar"
                trimear()
            Case "Estirar"
                extend()
            Case "Empalme"
                fillet()
            Case "filletRadioCero"
                filletr0()
            Case "Explotar"
                explode()
            Case "Alinear"
                'alinear()
                frmPpal.VdF.CommandLine.PostExecuteCommand("alinear")
            Case "Break"
                break()
            Case "tagCopiarPropiedades"
                frmPpal.VdF.CommandLine.PostExecuteCommand("pincelito")
            Case "bpoly"
                modPublico.bpoly()
            Case "arrayRectangular"
                frmPpal.VdF.CommandLine.PostExecuteCommand("arrayRectangular")
            Case "arrayPolar"
                frmPpal.VdF.CommandLine.PostExecuteCommand("arrayPolar")
            Case "deformar"
                frmPpal.VdF.CommandLine.PostExecuteCommand("stretch")

                '..............................................................
                'sexto menu: Cotas...
                '..............................................................
            Case "Alineada"
                AcotarDibujo("Alineada")
            Case "Diametral"
                AcotarDibujo("Diametral")
            Case "Angular"
                AcotarDibujo("Angular")
            Case "leader"
                AcotarDibujo("Leader")
            Case "EstiloCota"
                AcotarDibujo("Estilo")
            Case "Radial"
                AcotarDibujo("Radial")


                '..............................................................
                'septimo menu: Herramientas...
                '..............................................................
            Case "Distancia"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.cmdDistance()
                ultimoComando = "distancia"
            Case "AreaVertices"
                tipo = "P"
                value = frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdArea(tipo, Nothing, area, perimetro)
                If value Then
                    MsgBox("Area: " & CStr(area) & ", Perímetro: " & CStr(perimetro), MsgBoxStyle.Information, aplicacionNombre)
                End If
                ultimoComando = "areaXVertices"
            Case "AreaEntidad"
                tipo = "E"
                value = frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdArea(tipo, Nothing, area, perimetro)
                If value Then
                    MsgBox("Area: " & CStr(area) & ", Perímetro: " & CStr(perimetro), MsgBoxStyle.Information, aplicacionNombre)
                End If
                ultimoComando = "areaXEntidad"
            Case "identificarPunto"
                IdPunto()
                ultimoComando = "idPunto"
            Case "Osnap"
                VectorDraw.Professional.Dialogs.OSnapDialog.Show(frmPpal.doc, frmPpal.VdF.BaseControl.ActiveDocument.ActionControl)
                ultimoComando = "osnap"
            Case "Propiedades"
                propertyGrid()
                ultimoComando = "propiedades"
            Case "Layers"
                layers()
                ultimoComando = "layers"
            Case "configuraCursor"
                frmConfiguraCursor.ShowDialog()
            Case "ConfiguraLaminas"
                frmNuevoLayout.EdicionLamina = True
                frmNuevoLayout.ShowDialog()
                ultimoComando = "ConfiguraLaminas"
            Case "ConfiguraGrilla"
                frmGrilla.ShowDialog()
                ultimoComando = "ConfiguraGrilla"
            Case "configuraOsnap"
                VectorDraw.Professional.Dialogs.OSnapDialog.Show(frmPpal.doc, frmPpal.VdF.BaseControl.ActiveDocument.ActionControl)
                ultimoComando = "OSNAP"
            Case "configurarAutosave"
                configuraAutosave()
                ultimoComando = "autoSave"
            Case "configuracionEspacioModelo"
                frmConfiguraEspacioModelo.ShowDialog()
                ultimoComando = "confModelSpace"
            Case "encenderApagarEjesUcs"
                If frmPpal.VdF.BaseControl.ActiveDocument.ShowUCSAxis Then
                    frmPpal.VdF.BaseControl.ActiveDocument.ShowUCSAxis = False
                Else
                    frmPpal.VdF.BaseControl.ActiveDocument.ShowUCSAxis = True
                End If
                actualizarGrillaPropiedades()
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            Case "pasarByN"
                frmPpal.cambiarColores("byn")



                '......................................................................................................
                'octavo menu: Agrim 
                '......................................................................................................
                '
                'Catastro
            Case "PlantillaCatastro"
                ' cargar la plantilla de catastro: o sea los bloques, layers y textos.
                cargarPlantillaCatastro()
            Case "Antecedente"
                'traer el antecedente de Catastro
                importarAntecedente()
            Case "GuardarSys"
                'guardar .sys para Catastro
                Guarda_Antecedente()

                'Geodesia
            Case "PlantillaGeodesia"
                'este procedimiento esta en "modArchivos"
                'trae la plantilla de geodesia.
                plantillaGeodesia()
            Case "antecedenteGeodesia"
                'poner el antecedente de geodesia dentro
                'del dibujo activo. Puede ser que el di-
                'bujo activo sea la plantilla de Geodes.
                importarAntecedenteGeodesia()
            Case "guardarParaGeodesia"
                'guardar para Geodesia. Esto vuelve a 
                'poner el ucs original
                ucsOriginal()
                planOriginal()
                Try
                    frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("marcos").Frozen = True
                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                Catch ex As Exception
                    Err.Clear()
                End Try
                GuardarArchivoComo()
            Case "abrirCertificadoAmoj"
                'este procedimiento esta en "modArchivos"
                certificadoAmojonamiento()
            Case "AgrAcotar"
                Acotar(False, False, True, True)   'arriba, abajo
            Case "AgrAcotarArriba"
                Acotar(True, False, True, True)
            Case "AgrAcotarAbajo"
                Acotar(False, True, True, True)
            Case "AgrAcotarLados"
                Acotar(False, False, True, False)
            Case "AgrAcotarAngulos"
                Acotar(False, False, False, True)


            Case "Por_tres_puntos"
                ucsX3puntos()
            Case "Ubicacion_original"
                ucsOriginal()
            Case "Ucs_actual"
                planUcsActual()
            Case "Original"
                planOriginal()

                'menu Ayudas e Informacion
            Case "cambiosVersionActual"
                modInfoAyudas.cambiosVersionActual()
            Case "abreviaturas"
                modInfoAyudas.AbreviaturasDeComandos()
            Case "versionLibreria"
                modInfoAyudas.VersiónLibreria()
        End Select

    End Sub
    Public Sub manejaEventosObjetosAgrimensura(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Key As String = sender.Tag
        Select Case Key
            Case "objetoParcela"
                frmObjetosAgrimensura.TabControl1.SelectedIndex = 0
                frmObjetosAgrimensura.Show()
            Case "objetoDeslinde"
                frmObjetosAgrimensura.TabControl1.SelectedIndex = 1
                frmObjetosAgrimensura.Show()
            Case "exportarDatos"

                'Esto era para usar Mdb de Access:
                'If dondeGuardarLosDatos Is Nothing Then
                '    If Not armarMdb() Then
                '        MsgBox("NO se pudo armar la base de datos")
                '        Exit Sub
                '    End If
                'End If
                'buscarGuardarDatos()

                'Esto es para usar las dbf's existentes del Pgf
                buscarGuardarDatosDbf()

            Case "nomenclatura"
                frmObjetosAgrimensura.TabControl1.SelectedIndex = 2
                frmObjetosAgrimensura.Show()
            Case "distanciaesquina"
                frmObjetosAgrimensura.TabControl1.SelectedIndex = 3
                frmObjetosAgrimensura.Show()
            Case "poligonoEdificio"
                frmObjetosAgrimensura.TabControl1.SelectedIndex = 4
                frmObjetosAgrimensura.Show()

        End Select
    End Sub
    Public Sub manejaEventosPh(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim Key As String = sender.Tag
        Select Case Key
            Case "UF"
                frmPHUnidadesFuncionales.Show()
            Case "UC"
                frmPHUnidadesComplementarias.Show()
            Case "SC"
                frmPHSuperficiesComunes.Show()
            Case "poligonosDominio"
                frmPHPoligonoDominio.Show()
            Case "poligonosComunes"
                frmPHPoligonosComunes.Show()

        End Select
    End Sub
    '/////////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar de dibujar
    '/////////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosToolDibujar(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Key As String = sender.Tag
        Select Case Key
            Case "linea"
                frmPpal.VdF.CommandLine.PostExecuteCommand("line")
                ultimoComando = "linea"
            Case "poli"
                frmPpal.VdF.CommandLine.PostExecuteCommand("polyline")
                ultimoComando = "polilinea"
            Case "rectang"
                frmPpal.VdF.CommandLine.PostExecuteCommand("rect")
                ultimoComando = "rectangulo"
            Case "arco"
                frmPpal.VdF.CommandLine.PostExecuteCommand("arc")
                ultimoComando = "arco"
            Case "circulo"
                frmPpal.VdF.CommandLine.PostExecuteCommand("circle")
                ultimoComando = "circulo"
            Case "elipse"
                frmPpal.VdF.CommandLine.PostExecuteCommand("ellipse")
                ultimoComando = "elipse"
            Case "punto"
                frmPpal.VdF.CommandLine.PostExecuteCommand("point")
                ultimoComando = "punto"
            Case "texto"
                frmPpal.VdF.CommandLine.PostExecuteCommand("text")
                ultimoComando = "textoSingle"
            Case "hatch"
                'frmPpal.VdF.CommandLine.PostExecuteCommand("bhatch")
                hatch()
                ultimoComando = "hatch"
                'frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True
            Case "Insert"
                insertarBloque()
                ultimoComando = "insertarBloque"


        End Select

    End Sub
    Public Sub manejaEventos3D(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim key As String = sender.tag
        Select Case key
            Case "3Dgirar"
                'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VROT")
                frmPpal.VdF.CommandLine.PostExecuteCommand("GIRAR3D")
            Case "3Dtop"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VTOP")
            Case "3Dbottom"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VBOTTOM")
            Case "3Dleft"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VLEFT")
            Case "3Dright"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VRIGHT")
            Case "3Dfront"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VFRONT")
            Case "3Dback"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VBACK")
            Case "3Dne"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VINE")
            Case "3Dnw"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VINW")
            Case "3Dse"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VISE")
            Case "3Dsw"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.View3D("VISW")
        End Select
    End Sub

    '//////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar de acotar
    '///////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosAcotar(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim key As String = sender.tag
        Select Case key
            Case "CotaAlineada"
                AcotarDibujo("Alineada")
            Case "CotaRadial"
                AcotarDibujo("Radial")
            Case "CotaDiametral"
                AcotarDibujo("Diametral")
            Case "CotaAngular"
                AcotarDibujo("Angular")
            Case "CotaLeader"
                AcotarDibujo("Leader")
            Case "CotaEstilo"
                AcotarDibujo("Estilo")
        End Select
    End Sub

    Public Sub apagarEncenderOsnap(ByVal sender As Object, ByVal e As System.EventArgs)

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            MsgBox("Hay un comando pendiente. Temporariamente apagar o enceder Osnap sin comandos pendientes.", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        If frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = OsnapMode.DISABLE Then
            recargarOsnap(valorOsnap)
            frmPpal.ToolStrOsnapActivado.Text = "SI"
            frmPpal.ToolStrOsnapActivado.ToolTipText = "Osnap Activado"
        Else
            valorOsnap = frmPpal.VdF.BaseControl.ActiveDocument.osnapMode.ToString
            frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = OsnapMode.DISABLE
            frmPpal.ToolStrOsnapActivado.Text = "NO"
            frmPpal.ToolStrOsnapActivado.ToolTipText = "Osnap Desactivado"
        End If

    End Sub

    '//////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar del osnap
    '///////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosToolOsnap(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Key As String = sender.Tag

        If Not frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            Exit Sub
        End If
        If InStr(frmPpal.VdF.BaseControl.ActiveDocument.osnapMode.ToString, "DISABLE") <> 0 Then
            Exit Sub
        End If

        'Si llegué hasta aca es porque hay un comando pendiente y el osnap esta activado, ya sea porque estaba
        'activado de antes o porque se acaba de activar, por lo tanto al finalizar la operacion pendiente
        'el osnap debe quedar activado.

        Select Case Key
            Case "end"
                If InStr(frmPpal.VdF.BaseControl.ActiveDocument.osnapMode.ToString, "DISABLE") = 0 Then
                    frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.END
                End If
            Case "mid"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.MID
            Case "cen"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.CEN
            Case "int"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.INTERS
            Case "per"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.PER
            Case "nea"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.NEA
            Case "apa"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.APPARENTINT
            Case "non"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.NONE
            Case "nod"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.NODE
            Case "tan"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.TANG
                'VectorDraw.Professional.Dialogs.OSnapDialog.Show(frmPpal.doc, frmPpal.VdF.BaseControl.ActiveDocument.ActionControl)
            Case "qua"
                frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = VectorDraw.Geometry.OsnapMode.QUA
        End Select

    End Sub


    '//////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar de archivos 
    '///////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosToolGral(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Key As String = sender.Tag
        Select Case Key
            Case "nuevo"
                NuevoArchivo()
                ultimoComando = "nuevoArchivo"
            Case "abrir"
                AbrirArchivo()
                ultimoComando = "abrirArchivo"
            Case "guardar"
                GuardarArchivo()
                ultimoComando = "guardarArchivo"
            Case "imprimir"
                imprimir()
                ultimoComando = "imprimir"
            Case "btnCortar"
                cortarClip()

            Case "btnCopiar"
                copiarClip()
            Case "btnAyuda"
                Help.ShowHelp(frmPpal, ubicacionHelp & "\mhcad.chm")
            Case "btnPegar"
                pegarClip()
            Case "btnMatch"
                frmPpal.VdF.CommandLine.PostExecuteCommand("pincelito")
                'copiarPropiedades()

        End Select
    End Sub


    '//////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar de visadores
    '//////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosVisadores(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim key As String = sender.tag

        Select Case key

            Case "pdfVisadores"

                'verificar que exista un tamaño de papel definido..
                If Trim(frmConfiguraImpresion.txtAncho.Text) = "" Or Trim(frmConfiguraImpresion.txtAlto.Text) = "" Then
                    MsgBox("Seleccionar un tamaño de hoja.", MsgBoxStyle.Critical, aplicacionNombre)
                    Exit Sub
                End If

                frmPpal.baseControl.ActiveDocument.FileProperties.PDFExportProperties = vdFileProperties.PDFExportPropertiesFlags.UsePrinterPropertiesWithOutlineText
                Dim impresora As New vdPrint(frmPpal.baseControl.ActiveDocument.ActiveLayOut.Printer)
                impresora.PrinterName = VectorDraw.Professional.Utilities.vdGlobals.GetFileNameWithoutExtension(frmPpal.doc.FileName) + ".pdf"
                Dim pathDibujo As String = VectorDraw.Professional.Utilities.vdGlobals.GetDirectoryName(frmPpal.doc.FileName)
                Dim nombreDibujo As String = impresora.PrinterName


                'el rectangulo por dos puntos..
                Dim angulo, ancho, alto As Double
                Dim puntoUno As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
                Dim puntoDos As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
                Dim puntotres As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
                Dim respuestaDelMsgBox As Microsoft.VisualBasic.MsgBoxResult
                respuestaDelMsgBox = MsgBox("Seleccionar esquina inferior izquierda..")

                Dim ret As VectorDraw.Actions.StatusCode
                ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(puntoUno)
                If ret = VectorDraw.Actions.StatusCode.Success Then
                    MsgBox("Seleccionar esquina superior derecha..")
                    Dim retorno As Object = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserRect(puntoUno)
                    If Not retorno Is Nothing Then
                        Dim v As Vector
                        v = retorno
                        angulo = v.x
                        ancho = v.y
                        alto = v.z
                        puntoDos = puntoUno.Polar(0.0, ancho)
                        puntoDos = puntoDos.Polar(VectorDraw.Geometry.Globals.HALF_PI, alto)
                        puntotres.x = puntoUno.x
                        puntotres.y = puntoUno.y + alto
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If

                'Dim circulito As New VectorDraw.Professional.vdFigures.vdCircle
                'circulito.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                'circulito.setDocumentDefaults()
                'circulito.Center = puntoUno
                'circulito.Radius = 2.0
                'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circulito)

                'Dim circulito2 As New VectorDraw.Professional.vdFigures.vdCircle
                'circulito2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                'circulito2.setDocumentDefaults()
                'circulito2.Center = puntoDos
                'circulito2.Radius = 2.0
                'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circulito2)
                'frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

                Dim caja As VectorDraw.Geometry.Box = New VectorDraw.Geometry.Box(puntoUno, puntoDos)

                'tamaño del papel:
                Dim anchoPapel, altoPapel As Integer
                ancho = CDbl(Trim(frmConfiguraImpresion.txtAncho.Text))
                alto = CDbl(Trim(frmConfiguraImpresion.txtAlto.Text))
                anchoPapel = ancho * 100 / 25.4
                altoPapel = alto * 100 / 25.4


                impresora.InitializePreviewFormProperties(False, True, False, False)
                impresora.paperSize = New Rectangle(0.0, 0.0, anchoPapel, altoPapel)
                'impresora.PrintExtents()
                impresora.Resolution = 600


                Dim espesoresPuntas As VectorDraw.Geometry.DoubleArray = New VectorDraw.Geometry.DoubleArray
                For Each elemento As Double In matrizEspesores
                    espesoresPuntas.Add(elemento)
                Next
                impresora.Penwidth = espesoresPuntas

                impresora.margins.Left = CInt(Trim(frmConfiguraImpresion.txtIzquierda.Text) * 100 / 25.4)
                impresora.margins.Right = CInt(Trim(frmConfiguraImpresion.txtDerecha.Text) * 100 / 25.4)
                impresora.margins.Top = CInt(Trim(frmConfiguraImpresion.txtArriba.Text) * 100 / 25.4)
                impresora.margins.Bottom = CInt(Trim(frmConfiguraImpresion.txtAbajo.Text) * 100 / 25.4)
                impresora.PrintWindow = caja
                impresora.PrintScaleToFit()
                impresora.CenterDrawingToPaper()

                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Printer.CopyFrom(impresora)

                'habilitar para verificar como estan los parametros de impresion
                'impresora.DialogPreview()

                Dim archivoGuardadoOk As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.SaveAs(pathDibujo & "\" & nombreDibujo)
                'frmPpal.VdF.BaseControl .ActiveDocument .ExportToFile(archivo )
                If archivoGuardadoOk Then
                    MsgBox("Archivo exportado ok!!")
                Else
                    MsgBox("Error en la exportación del archivo.")
                End If

            Case "byn"
                '13/9/2011
                frmPpal.cambiarColores("byn")
            Case "configuraImpresora"
                frmConfiguraImpresion.ShowDialog()
            Case "salirVisadores"
                'frmPpal.cerrar()
                End
        End Select

    End Sub

    'Private Sub documentoDibujo_ActionEnd(ByVal sender As Object, ByVal actionName As String) Handles documentoDibujo.ActionEnd
    '    MsgBox("ok")
    'End Sub

    'Private Sub documentoDibujo_OnSaveUnknownFileName(ByVal sender As Object, ByVal fileName As String, ByRef success As Boolean) Handles documentoDibujo.OnSaveUnknownFileName
    '    MsgBox("ok")
    'End Sub


    '//////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar de edicion 1
    '///////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosToolEditar(ByVal sender As Object, ByVal e As System.EventArgs)
        '-----------------------------------------------------------------------------------------------
        ' viene del modulo "modConfigura", "public sub Configurar". Alli se cargan todos los manejadores
        '-----------------------------------------------------------------------------------------------
        Dim Key As String = sender.Tag

        Select Case Key
            Case "propiedades"
                propertyGrid()
            Case "copy"
                frmPpal.VdF.CommandLine.PostExecuteCommand("copy")
            Case "mirror"
                frmPpal.VdF.CommandLine.PostExecuteCommand("mirror")
            Case "move"
                frmPpal.VdF.CommandLine.PostExecuteCommand("move")
            Case "rotate"
                frmPpal.VdF.CommandLine.PostExecuteCommand("rotate")
            Case "scale"
                frmPpal.VdF.CommandLine.PostExecuteCommand("scale")
            Case "trim"
                frmPpal.VdF.CommandLine.PostExecuteCommand("trim")
            Case "extend"
                frmPpal.VdF.CommandLine.PostExecuteCommand("extend")
            Case "explode"
                frmPpal.VdF.CommandLine.PostExecuteCommand("explode")
            Case "fillet"
                frmPpal.VdF.CommandLine.PostExecuteCommand("F")
            Case "filletr0"
                frmPpal.VdF.CommandLine.PostExecuteCommand("FR0")
            Case "offset"
                offset()
            Case "break"
                frmPpal.VdF.CommandLine.PostExecuteCommand("break")
            Case "alinear"
                frmPpal.VdF.CommandLine.PostExecuteCommand("alinear")
        End Select

    End Sub

    '//////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar de edicion 2
    '///////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosToolEditar2(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Key As String = sender.Tag
        Select Case Key
            Case "Erase"
                If obtenerSeleccion.Count > 0 Then
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdErase(obtenerSeleccion)
                    LimpiarSeleccion(obtenerSeleccion)
                Else
                    'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdErase("USER")
                    frmPpal.VdF.CommandLine.PostExecuteCommand("erase")
                End If

                actualizarGrillaPropiedades()
                frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True
                ultimoComando = "borrar"

            Case "Undo"
                deshacer()
            Case "Redo"
                rehacer()
            Case "atributos"
                frmPpal.VdF.CommandLine.PostExecuteCommand("ATE")
                ultimoComando = "attedit"
            Case "escalasVp"
                ingresaEscalaVp()
                ultimoComando = "escVP"
        End Select
    End Sub

    '//////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar vistas
    '///////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosToolVistas(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Key As String = sender.Tag
        Select Case Key
            Case "Pan"
                'pan()
                frmPpal.VdF.CommandLine.PostExecuteCommand("PAN")
                ultimoComando = "pan"

            Case "ZE"
                ze()
            Case "ZW"
                zw()
            Case "ZP"
                zp()
            Case "Zreducir"
                zr()
            Case "ZAmpliar"
                za()
        End Select
    End Sub


    '//////////////////////////////////////////////////////////////////////////////////////
    ' la toolbar layers
    '///////////////////////////////////////////////////////////////////////////////////////
    Public Sub ManejaEventosToolLayers(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Key As String = sender.Tag
        Select Case Key
            Case "btnLayers"
                layers()
            Case "btnTipoLinea"
                tipoLinea()
            Case "cmbTipoLinea"
                cmbTipoLineaClick()
            Case "btnEspesor"
                espesores()
            Case "cmbEspesores"
                For Each i As VectorDraw.Professional.Constants.VdConstLineWeight In [Enum].GetValues(GetType(VectorDraw.Professional.Constants.VdConstLineWeight))
                    If i.ToString = frmPpal.ToolStrLayersCmbEspesor.Text Then
                        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineWeight = i
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                        Exit For
                    End If
                Next
            Case "btnColores", "lblColores"
                colores()
            Case "fondoLayout"
                cambiaFondoLayout()
        End Select
    End Sub
#End Region

    Private Sub cambiaFondoLayout()
        modLayouts.onOffMarcoPrinter()
    End Sub

    Public Sub insertaImagen()
        Dim ofd As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Dim fname As FileInfo
        Dim fnameDetalles As Bitmap
        With ofd
            .CheckFileExists = True
            .ShowReadOnly = False
            .Filter = "Archivos de imagenes (*.bmp; *.jpg; *.gif; *.tif; *.png)|*.bmp;*.jpg;*.gif;*.tif;*.png|Todos los Archivos (*.*)|*.*"
            .FilterIndex = 1
            .FileName = ""
            .InitialDirectory = "C:\"
            If .ShowDialog = DialogResult.OK Then
                fname = New FileInfo(.FileName)
                fnameDetalles = New Bitmap(.FileName.ToString)
            Else
                MsgBox("Seleccionar archivo de imagen")
                Exit Sub
            End If
        End With


        Dim imagedef1 As VectorDraw.Professional.vdPrimaries.vdImageDef = New VectorDraw.Professional.vdPrimaries.vdImageDef()
        imagedef1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        imagedef1.setDocumentDefaults()
        imagedef1.Name = fname.Name.ToString
        imagedef1.FileName = fname.FullName
        frmPpal.VdF.BaseControl.ActiveDocument.Images.AddItem(imagedef1)
        'Dim cuantas As Integer = frmPpal.VdF.BaseControl.ActiveDocument.Images.Count

        Dim image As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
        image.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        image.setDocumentDefaults()
        'We know that the first image is what we want so we can just get the [0] item from the collection 
        'else we could have used the Find methods.
        Dim ultima As Integer = frmPpal.VdF.BaseControl.ActiveDocument.Images.Count
        image.ImageDefinition = frmPpal.VdF.BaseControl.ActiveDocument.Images(ultima - 1)

        '------------------------
        'imagen georreferenciada
        '------------------------
        'ver si es un archivo tipo jpg o tif.

        'Si es uno de estos dos, ver si existe el archivo asociado de
        'georreferenciación. Para los tif el archivo de georreferenciación es .tfw y para los jpg es .jgw
        '
        'Si no existe el archivo de georreferenciación, el proceso sigue normal, o sea pide el punto de 
        'inserción, la escala y la rotación.
        '
        'Si existe el archivo de georreferenciación no pedir punto de insercion, escala y rotacion y calcular
        'con los valores del archivo de georreferenciación.
        If fname.Extension = ".jpg" Then

            If File.Exists(fname.DirectoryName & "\" & fname.Name.Replace(".jpg", ".jgw")) Then
                'calcular punto de insercion, rotacion y escala. 
                'Leer el archivo de configuracion 
                Dim archivo As Stream = File.Open(fname.DirectoryName & "\" & fname.Name.Replace(".jpg", ".jgw"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
                georreferenciar(image, archivo, fnameDetalles)
            Else
                preguntarValores(image)
            End If

        ElseIf fname.Extension = ".tif" Then

            If File.Exists(fname.DirectoryName & "\" & fname.Name.Replace(".tif", ".tfw")) Then
                'calcular punto de insercion, rotacion y escala
                'Leer el archivo de configuracion
                Dim archivo As Stream = File.Open(fname.DirectoryName & "\" & fname.Name.Replace(".tif", ".tfw"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
                georreferenciar(image, archivo, fnameDetalles)
            Else
                preguntarValores(image)
            End If

        Else
            preguntarValores(image)
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities.AddItem(image)
        ''And clip the image!!! Note that the cli points are relative to the upper corner of the image in Pixels.
        'image.ClipBoundary.Add(New VectorDraw.Geometry.gPoint(0.0, 0.0, 0.0))
        'image.ClipBoundary.Add(New VectorDraw.Geometry.gPoint(image.ImageDefinition.Width, 0.0, 0.0))
        'image.ClipBoundary.Add(New VectorDraw.Geometry.gPoint(0.0, image.ImageDefinition.Height, 0.0))
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        image.Dispose()
        'punto.Dispose()
        ultimoComando = "imagen"

    End Sub

    Private Sub georreferenciar(ByVal image As VectorDraw.Professional.vdFigures.vdImage, ByVal archivo As Stream, ByVal archivoImagen As Bitmap)
        Dim lector As New StreamReader(archivo)  'para leer el archivo de georref.
        Dim queLeyo As String, pasadas As Integer = 0
        Dim pixelX, pixelY, giroX, giroY, x1, y1 As Double

        Do Until lector.Peek = -1
            queLeyo = lector.ReadLine().ToString
            If queLeyo = "" Then Exit Do
            pasadas = pasadas + 1
            Select Case pasadas
                Case Is = 1
                    pixelX = CDbl(queLeyo)
                Case Is = 2
                    giroX = CDbl(queLeyo)
                Case Is = 3
                    giroY = CDbl(queLeyo)
                Case Is = 4
                    pixelY = CDbl(queLeyo)
                Case Is = 5
                    x1 = CDbl(queLeyo)
                Case Is = 6
                    y1 = CDbl(queLeyo)
            End Select
        Loop
        lector.Close()
        Dim ancho As Integer = archivoImagen.Width
        Dim alto As Integer = archivoImagen.Height

        '---------------------------
        ' punto de insercion
        '---------------------------
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        punto.x = x1 - (pixelX / 2)
        punto.y = y1 - (pixelX * (alto)) + (pixelX / 2)
        image.InsertionPoint = punto

        '-----------------
        ' escala
        '-----------------
        image.ImageScale = pixelX * ancho

        '-------------------
        ' rotacion
        '-------------------
        image.Rotation = 0.0


    End Sub

    Private Sub preguntarValores(ByVal image As VectorDraw.Professional.vdFigures.vdImage)

        '---------------------------
        ' punto de insercion
        '---------------------------
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccione punto de inserción")
        Dim ret As VectorDraw.Actions.StatusCode
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            image.InsertionPoint = punto
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
            Exit Sub
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.bHatch()
        '-----------------
        ' escala
        '-----------------
        Dim escalaImagen As Double = 0.0
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Ingrese escala de la imagen")
        Dim retorno As VectorDraw.Actions.StatusCode
        retorno = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserDouble(escalaImagen)
        If retorno = VectorDraw.Actions.StatusCode.Success Then
            image.ImageScale = escalaImagen
        Else
            image.ImageScale = 0.0
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)


        '-------------------
        ' rotacion
        '-------------------
        'image.Rotation 'double en radianes
        'elMtexto.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(nudAngulo.Value)  'en radianes
        Dim anguloImagen As Double = 0.0
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Ingrese ángulo de la imagen")
        Dim devuelto As VectorDraw.Actions.StatusCode
        devuelto = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserDouble(anguloImagen)
        If devuelto = VectorDraw.Actions.StatusCode.Success Then
            image.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(anguloImagen)
        Else
            image.Rotation = 0.0
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
    End Sub

    Public Sub ingresaEscalaVp()
        Dim escala As Single
        Dim respuesta As String = InputBox("Ingrese el denominador de la escala", aplicacionNombre)
        If respuesta = "" Then
            Exit Sub
        Else
            Try
                escala = CSng(respuesta)
                If frmPpal.btnUnidadesPapel.Text = "Unidades Papel = mm" Then
                    escala = 1000 / escala
                Else
                    escala = 100 / escala
                End If

                escalaViewport(escala)
            Catch ex As Exception
                MsgBox("Error. Introducir valores numéricos", MsgBoxStyle.Information, aplicacionNombre)
                Exit Sub
            End Try
        End If
    End Sub

    'acotar con las cotas comunes
    Public Sub AcotarDibujo(ByVal tipoDeCota As String)
        Select Case tipoDeCota
            Case "Alineada"
                'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Aligned, Nothing, Nothing, 0.0)
                frmPpal.VdF.CommandLine.PostExecuteCommand("dimAligned")
                ultimoComando = "cotaAlineada"
            Case "Radial"
                'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Radial, Nothing, Nothing, 0.0)
                frmPpal.VdF.CommandLine.PostExecuteCommand("dimRadial")
                ultimoComando = "cotaRadial"
            Case "Diametral"
                'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Diameter, Nothing, Nothing, 0.0)
                frmPpal.VdF.CommandLine.PostExecuteCommand("dimDiameter")
                ultimoComando = "cotaDiametral"
            Case "Angular"
                'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Angular, Nothing, Nothing, 0.0)
                frmPpal.VdF.CommandLine.PostExecuteCommand("dimAngular")
                ultimoComando = "cotaAngular"
            Case "Leader"
                'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdLeader(Nothing, Nothing)
                frmPpal.VdF.CommandLine.PostExecuteCommand("leader")
                ultimoComando = "leader"
                'frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True
            Case "Estilo"
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdDimStyleDialog()
                ultimoComando = "cotaEstilo"
        End Select

    End Sub

    Public Sub pegarClip()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ' ---------------------------------------------------------------------------------
        ' Trabajar con selecciones, en modo entidad-verbo.
        ' Ver si hay seleccion activa..
        If obtenerSeleccion.Count > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdClipPaste(obtenerSeleccion)
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdClipPaste(Nothing)
        End If
        LimpiarSeleccion(obtenerSeleccion)
        actualizarGrillaPropiedades()
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub copiarClip()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ' ---------------------------------------------------------------------------------
        ' Trabajar con selecciones, en modo entidad-verbo.
        ' Ver si hay seleccion activa..
        If obtenerSeleccion.Count > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdClipCopy(obtenerSeleccion)
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdClipCopy(Nothing)
        End If
        LimpiarSeleccion(obtenerSeleccion)
        actualizarGrillaPropiedades()
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub enviarAlFondo()
        frmPpal.doc.Prompt("Seleccionar una entidad")
        Dim fig As vdFigure
        Dim userPt As gPoint
        Dim retorno As VectorDraw.Actions.StatusCode = frmPpal.doc.ActionUtility.getUserEntity(fig, userPt)
        frmPpal.doc.Prompt(Nothing)
        If retorno = VectorDraw.Actions.StatusCode.Success Then
            If Not fig Is Nothing Then
                fig.Invalidate()
                frmPpal.doc.ActiveLayOut.Entities.ChangeOrder(fig, True)
                fig.Update()
                fig.Invalidate()
            End If
        End If
    End Sub
    Public Sub traerAlFrente()
        frmPpal.doc.Prompt("Seleccionar una entidad")
        Dim fig As vdFigure
        Dim userPt As gPoint
        Dim retorno As VectorDraw.Actions.StatusCode = frmPpal.doc.ActionUtility.getUserEntity(fig, userPt)
        frmPpal.doc.Prompt(Nothing)
        If retorno = VectorDraw.Actions.StatusCode.Success Then
            If Not fig Is Nothing Then
                fig.Invalidate()
                frmPpal.doc.ActiveLayOut.Entities.ChangeOrder(fig, False)
                fig.Update()
                fig.Invalidate()
            End If
        End If
    End Sub
    Public Sub cortarClip()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdClipCut(Nothing)

        ' ---------------------------------------------------------------------------------
        ' Trabajar con selecciones, en modo entidad-verbo.
        ' Ver si hay seleccion activa..
        If obtenerSeleccion.Count > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdClipCut(obtenerSeleccion)
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdClipCut(Nothing)
        End If
        LimpiarSeleccion(obtenerSeleccion)
        actualizarGrillaPropiedades()
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub

    Public Sub copiar()
        '---------------------------------------------------------------------------
        ' Comando copiar
        ' 9/2/2010, intento de cambiar cursor mientras dura la operacion de edicion.
        '----------------------------------------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ponerCursorParaSeleccionar()
        Dim isCopy As Boolean = True
        Dim sel As vdSelection
        If Not obtenerSeleccion.Count > 0 Then
            frmPpal.doc.Prompt("Seleccionar entidades a copiar: ")
            If Not frmPpal.doc.CommandAction.CmdSelect("USER") Then
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
                frmPpal.lineaComandos.UserText.Clear()
                ponerCursorOriginal()
                Exit Sub
            Else
                sel = frmPpal.doc.Selections.FindName("VDRAW_PREVIOUS_SELSET")
            End If
        Else
            sel = obtenerSeleccion()
        End If

        If (sel Is Nothing) Or (sel.Count < 1) Then
            'frmPpal.VdF.BaseControl.SetCustomMousePointer(elCursorOriginal)
            ponerCursorOriginal()
            Exit Sub
        End If

        'frmPpal.VdF.BaseControl.SetCustomMousePointer(Cursors.Cross)
        ponerCursorParaSeleccionarSegundaParte()
        frmPpal.doc.Prompt("Seleccionar punto origen: ")
        Dim ptFrom As gPoint = TryCast(frmPpal.doc.ActionUtility.getUserPoint(), gPoint)
        If (ptFrom Is Nothing) Then
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
            frmPpal.lineaComandos.UserText.Clear()
            ponerCursorOriginal()
            'Return False
            Exit Sub
        End If

        While isCopy
            isCopy = frmPpal.doc.CommandAction.CmdCopy(sel, ptFrom, "USER")
        End While
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
        frmPpal.lineaComandos.UserText.Clear()
        ponerCursorOriginal()

        LimpiarSeleccion(obtenerSeleccion)
        actualizarGrillaPropiedades()
        ultimoComando = "copiar"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub

    Public Sub mover()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ponerCursorParaSeleccionar()
        Dim sel As vdSelection
        If Not obtenerSeleccion.Count > 0 Then
            frmPpal.doc.Prompt("Seleccionar entidades a copiar: ")
            If Not frmPpal.doc.CommandAction.CmdSelect("USER") Then
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
                frmPpal.lineaComandos.UserText.Clear()
                ponerCursorOriginal()
                Exit Sub
            Else
                sel = frmPpal.doc.Selections.FindName("VDRAW_PREVIOUS_SELSET")
            End If
        Else
            sel = obtenerSeleccion()
        End If

        If (sel Is Nothing) Or (sel.Count < 1) Then
            'frmPpal.VdF.BaseControl.SetCustomMousePointer(elCursorOriginal)
            ponerCursorOriginal()
            Exit Sub
        End If

        ponerCursorParaSeleccionarSegundaParte()
        frmPpal.doc.Prompt("Seleccionar punto origen: ")
        Dim ptFrom As gPoint = TryCast(frmPpal.doc.ActionUtility.getUserPoint(), gPoint)
        If (ptFrom Is Nothing) Then
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
            frmPpal.lineaComandos.UserText.Clear()
            ponerCursorOriginal()
            Exit Sub
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMove(sel, ptFrom, "USER")

        ponerCursorOriginal()
        LimpiarSeleccion(obtenerSeleccion)
        actualizarGrillaPropiedades()
        ultimoComando = "mover"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub

    Public Sub offset()
        '--------------------------------
        ' Comando Offset
        '--------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim valor As String
        Dim retorno As VectorDraw.Actions.StatusCode
        Dim ofsetear As Boolean = True
        valor = InputBox("Ingresar distancia", "mh Cad", CStr(distanciaOffset))
        If IsNumeric(valor) Then
            If InStr(valor, ",") <> 0 Then
                valor = Replace(valor, ",", ".")
            End If
            distanciaOffset = CDbl(valor)
        Else
            MsgBox("Ingresar distancia utilizando cero a la izquierda para valores menores a 1")
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
            frmPpal.lineaComandos.UserText.Clear()
            Exit Sub
        End If

        ''If IsNumeric(temporal) Then
        'Dim haySepMiles As Integer = InStr(temporal, sepMiles)
        'If haySepMiles <> 0 Then
        '    temporal = Replace(temporal, sepMiles, sepDecimal)
        'End If
        'Dim haySepDec As Integer = InStr(temporal, sepDecimal)
        'If haySepDec = 1 Then
        '    temporal = "0" & temporal
        'End If
        'distanciaOffset = CDbl(temporal)

        Dim figura1 As vdFigure
        Dim punto1 As gPoint

        While ofsetear
            ponerCursorParaSeleccionar()
            frmPpal.doc.Prompt("Seleccionar entidad original")
            retorno = frmPpal.doc.ActionUtility.getUserEntity(figura1, punto1)
            If Not retorno = VectorDraw.Actions.StatusCode.Success Then
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
                frmPpal.lineaComandos.UserText.Clear()
                ponerCursorOriginal()
                frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True
                ultimoComando = "offset"
                Exit Sub
            Else
                figura1.HighLight = True
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                ofsetear = frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdOffset(figura1, distanciaOffset, "user")
            End If
            figura1.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        End While

    End Sub

    Public Sub mirror()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        'Dim sel As vdSelection
        'ponerCursorParaSeleccionar()
        'frmPpal.doc.Prompt("Seleccionar entidades a espejar: ")
        'If Not frmPpal.doc.CommandAction.CmdSelect("USER") Then
        '    frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
        '    frmPpal.lineaComandos.UserText.Clear()
        '    ponerCursorOriginal()
        '    Exit Sub
        'Else
        '    sel = frmPpal.doc.Selections.FindName("VDRAW_PREVIOUS_SELSET")
        'End If

        'ponerCursorParaSeleccionarSegundaParte()
        'frmPpal.doc.Prompt("Seleccionar primer punto linea simetria")
        'Dim ptFrom As gPoint = TryCast(frmPpal.doc.ActionUtility.getUserPoint(), gPoint)
        'If (ptFrom Is Nothing) Then
        '    frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
        '    frmPpal.lineaComandos.UserText.Clear()
        '    ponerCursorOriginal()
        '    Exit Sub
        'End If

        'frmPpal.doc.Prompt("Seleccionar segundo punto linea simetria")
        'Dim ptTo As gPoint = TryCast(frmPpal.doc.ActionUtility.getUserPoint(), gPoint)
        'If (ptTo Is Nothing) Then
        '    frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
        '    frmPpal.lineaComandos.UserText.Clear()
        '    ponerCursorOriginal()
        '    Exit Sub
        'End If

        'If obtenerSeleccion.Count > 0 Then
        '    'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMirror(obtenerSeleccion, "USER", "USER", "USER")
        '    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMirror(obtenerSeleccion, ptFrom, ptTo, "USER")
        'Else
        '    'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMirror(sel, "USER", "USER", "USER")
        '    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMirror(sel, ptFrom, ptTo, "USER")
        '    'frmPpal.VdF.CommandLine.PostExecuteCommand("mirror")
        'End If
        ponerCursorParaSeleccionar()
        If obtenerSeleccion.Count > 0 Then
            'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMirror(obtenerSeleccion, "USER", "USER", "USER")
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMirror(obtenerSeleccion, "USER", "USER", "USER")
        Else
            'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMirror(sel, "USER", "USER", "USER")
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMirror("USER", "USER", "USER", "USER")
            'frmPpal.VdF.CommandLine.PostExecuteCommand("mirror")
        End If

        ponerCursorOriginal()
        LimpiarSeleccion(obtenerSeleccion)
        actualizarGrillaPropiedades()
        ultimoComando = "mirror"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
        frmPpal.lineaComandos.UserText.Clear()

    End Sub

    Public Sub rotate()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ponerCursorParaSeleccionar()

        If obtenerSeleccion.Count > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdRotate(obtenerSeleccion, "USER", "USER")
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdRotate("USER", "USER", "USER")
        End If

        ponerCursorOriginal()
        LimpiarSeleccion(obtenerSeleccion)
        actualizarGrillaPropiedades()
        ultimoComando = "rotar"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub escala()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ponerCursorParaSeleccionar()
        If obtenerSeleccion.Count > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdScale(obtenerSeleccion, "USER", "USER")
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdScale("USER", "USER", "USER")
        End If

        LimpiarSeleccion(obtenerSeleccion)
        ponerCursorOriginal()
        actualizarGrillaPropiedades()
        ultimoComando = "escalear"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub trimear()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ponerCursorParaSeleccionar()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdTrim("USER", "USER")
        'frmPpal.VdF.CommandLine.PostExecuteCommand("trim")
        ultimoComando = "trim"
        ponerCursorOriginal()
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub extend()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ponerCursorParaSeleccionar()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdExtend("USER", "USER")
        'frmPpal.VdF.CommandLine.PostExecuteCommand("extend")
        ultimoComando = "extender"
        ponerCursorOriginal()
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub explode()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ponerCursorParaSeleccionar()
        If obtenerSeleccion.Count > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdExplode(obtenerSeleccion)
        Else
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdExplode("USER")
        End If
        ponerCursorOriginal()
        LimpiarSeleccion(obtenerSeleccion)
        actualizarGrillaPropiedades()
        ultimoComando = "explode"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub

    Public Sub filletr0()
        Dim filletearConRadioCero As Boolean = True
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim figura1 As vdFigure, figura2 As vdFigure
        Dim punto1 As gPoint, punto2 As gPoint, retorno As VectorDraw.Actions.StatusCode
        Dim arrayFigura1(1) As Object
        Dim arrayfigura2(1) As Object
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.UndoHistory.Clear()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN")

        Do While filletearConRadioCero
            ponerCursorParaSeleccionar()
            frmPpal.doc.Prompt("Seleccionar primer entidad")
            retorno = frmPpal.doc.ActionUtility.getUserEntity(figura1, punto1)
            If Not retorno = VectorDraw.Actions.StatusCode.Success Then
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
                frmPpal.lineaComandos.UserText.Clear()
                ponerCursorOriginal()
                Exit Sub
            Else
                arrayFigura1(0) = figura1
                arrayFigura1(1) = punto1
                figura1.HighLight = True
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                frmPpal.doc.Prompt("Seleccionar segunda entidad")
                retorno = frmPpal.doc.ActionUtility.getUserEntity(figura2, punto2)
                If Not retorno = VectorDraw.Actions.StatusCode.Success Then
                    frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
                    frmPpal.lineaComandos.UserText.Clear()
                    ponerCursorOriginal()
                    Exit Sub
                Else
                    arrayfigura2(0) = figura2
                    arrayfigura2(1) = punto2
                    figura2.HighLight = True
                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                    filletearConRadioCero = frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdFillet(arrayFigura1, arrayfigura2)
                End If
                figura1.HighLight = False
                figura2.HighLight = False
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            End If
        Loop
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Undo("END")

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
        frmPpal.lineaComandos.UserText.Clear()
        ponerCursorOriginal()
        ultimoComando = "filletr0"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True
    End Sub

    Public Sub fillet()
        Dim filletear As Boolean = True
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim figura1 As vdFigure, figura2 As vdFigure
        Dim punto1 As gPoint, punto2 As gPoint, retorno As VectorDraw.Actions.StatusCode
        Dim arrayFigura1(1) As Object
        Dim arrayfigura2(1) As Object

        Dim radio As Double
        ponerCursorParaPreguntar()
        frmPpal.doc.Prompt("Radio: ")
        retorno = frmPpal.doc.ActionUtility.getUserDouble(radio)
        If Not retorno = VectorDraw.Actions.StatusCode.Success Then
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
            frmPpal.lineaComandos.UserText.Clear()
            ponerCursorOriginal()
            Exit Sub
        End If

        Do While filletear
            ponerCursorParaSeleccionar()
            frmPpal.doc.Prompt("Seleccionar primer entidad")
            retorno = frmPpal.doc.ActionUtility.getUserEntity(figura1, punto1)
            If Not retorno = VectorDraw.Actions.StatusCode.Success Then
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
                frmPpal.lineaComandos.UserText.Clear()
                ponerCursorOriginal()
                Exit Sub
            Else
                arrayFigura1(0) = figura1
                arrayFigura1(1) = punto1
                figura1.HighLight = True
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                frmPpal.doc.Prompt("Seleccionar segunda entidad")
                retorno = frmPpal.doc.ActionUtility.getUserEntity(figura2, punto2)
                If Not retorno = VectorDraw.Actions.StatusCode.Success Then
                    frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
                    frmPpal.lineaComandos.UserText.Clear()
                    ponerCursorOriginal()
                    Exit Sub
                Else
                    arrayfigura2(0) = figura2
                    arrayfigura2(1) = punto2
                    figura2.HighLight = True
                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                    filletear = frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdFilletRadius(arrayFigura1, arrayfigura2, radio)
                End If
                figura1.HighLight = False
                figura2.HighLight = False
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            End If

        Loop

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
        frmPpal.lineaComandos.UserText.Clear()
        ponerCursorOriginal()
        ultimoComando = "fillet"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub break()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim figura1 As vdFigure, punto1 As gPoint
        Dim retorno As VectorDraw.Actions.StatusCode

        frmPpal.doc.Prompt("Seleccionar entidad")
        ponerCursorParaSeleccionar()
        retorno = frmPpal.doc.ActionUtility.getUserEntity(figura1, punto1)
        If Not retorno = VectorDraw.Actions.StatusCode.Success Then
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
            frmPpal.lineaComandos.UserText.Clear()
            ponerCursorOriginal()
            Exit Sub
        Else
            figura1.HighLight = True
            ponerCursorParaSeleccionarSegundaParte()
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdBreak(figura1, "USER", "USER")
            ultimoComando = "break"
            frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True
        End If
        figura1.HighLight = False
        ponerCursorOriginal()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub
    Public Sub xray()
        '//////////////////////////////////////////
        ' Dibujar una linea infinita radial (desde un punto)
        '//////////////////////////////////////////
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdRay("USER")
        ultimoComando = "xray"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub xlinea()
        '//////////////////////////////////////////
        ' Dibujar una linea infinita (xline)
        '//////////////////////////////////////////
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdXLine("USER")
        ultimoComando = "xlinea"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub linea()
        '//////////////////////////////////////////
        ' Dibujar una linea
        '//////////////////////////////////////////
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdLine("USER")
        ultimoComando = "linea"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub polilinea()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine("USER")
        ultimoComando = "polilinea"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub arco()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdArc("USER", "USER", "USER", "USER")
        ultimoComando = "arco"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub rectangulo()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdRect("User", "user")
        ultimoComando = "rectangulo"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub circulo()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdCircle("USER", "USER")
        ultimoComando = "circulo"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub elipse()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdEllipse("User", "user", "user")
        ultimoComando = "elipse"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub punto()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPoint("User")
        ultimoComando = "punto"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub hatch()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        'frmPpal.trama.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        'frmPpal.trama.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModePattern
        'frmPpal.trama.HatchProperties.HatchPattern = frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.FindName("STARS")
        'frmPpal.trama.HatchProperties.HatchScale = 0.5
        'frmPpal.trama.HatchProperties.FillColor.SystemColor = Color.Blue
        'frmPpal.trama.HatchProperties.FillBkColor.SystemColor = Color.Aquamarine

        'VectorDraw.Professional.Dialogs.frmGetHatchDialog.Show(Nothing, VdFramedControl1.BaseControl.ActiveDocument, VdFramedControl1.BaseControl.ActiveDocument.ActionControl)

        'VectorDraw.Professional.Dialogs.GetHatchPatternsDialog frm =
        'VectorDraw.Professional.Dialogs.GetHatchPatternsDialog.Show(vdFC.BaseControl.ActiveDocument,
        'vdFC.BaseControl.ActiveControl,
        'vdFC.BaseControl.ActiveDocument.HatchPatterns.Solid);

        'VectorDraw.Professional.vdPrimaries.vdHatchPattern myHatch = new
        'VectorDraw.Professional.vdPrimaries.vdHatchPattern();
        'myHatch.SetUnRegisterDocument(vdFC.BaseControl.ActiveDocument);
        'myHatch.setDocumentDefaults();
        'myHatch.Name = "TEST_HATCH"; //hatch

        'mostrar el cuadro de dialogo para seleccionar un tramado tipo pattern.............
        'VectorDraw.Professional.Dialogs.GetHatchPatternsDialog.Show(frmPpal.VdF.BaseControl.ActiveDocument, frmPpal.VdF.BaseControl.ActiveControl, frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.Single)
        '...................................................................................

        'For Each estilo As vdHatchPattern In frmPpal.VdF.BaseControl.ActiveDocument..HatchPatterns
        '    Dim cuantos As Integer = frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.Count
        '    Dim nombre As String = estilo.Name

        'Next

        frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.Horizontal.VisibleOnForms = False
        frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.Solid.VisibleOnForms = False
        frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.BDiagonal.VisibleOnForms = False
        frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.Cross.VisibleOnForms = False
        frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.DiagCross.VisibleOnForms = False
        frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.FDiagonal.VisibleOnForms = False
        frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.Vertical.VisibleOnForms = False
        'frmPpal.VdF.BaseControl.ActiveDocument.HatchPatterns.


        'frmPpal.VdF.BaseControl.ActiveDocument.Update()

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.bHatch()
        ultimoComando = "hatch"
        'frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub borrar(ByVal deDondeVengo As String)
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        ' ---------------------------------------------------------------------------------
        ' Trabajar con selecciones, en modo entidad-verbo.
        ' Ver si hay seleccion activa..

        If deDondeVengo = "TeclaSupr" Then
            If obtenerSeleccion.Count > 0 Then
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdErase(obtenerSeleccion)
            End If
        End If

        If deDondeVengo = "noTeclaSupr" Then
            If obtenerSeleccion.Count > 0 Then
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdErase(obtenerSeleccion)
            Else
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdErase("USER")
            End If
            LimpiarSeleccion(obtenerSeleccion)
        End If

        actualizarGrillaPropiedades()
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True
        ultimoComando = "borrar"

    End Sub
    Public Sub deshacer()

        'frmPpal.VdF.BaseControl.ActiveDocument.UndoHistory.Undo()
        'VectorDraw.Professional.ActionUtilities.vdCommandAction.UndoEx(frmPpal.VdF.BaseControl.ActiveDocument)
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.UndoHistory.Undo()

        ultimoComando = "deshacer"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub rehacer()

        frmPpal.VdF.BaseControl.ActiveDocument.UndoHistory.Redo()

        ultimoComando = "rehacer"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Public Sub pan()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Pan()
        ultimoComando = "pan"

    End Sub
    Public Sub ze()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
        frmPpal.ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
        ultimoComando = "ze"

    End Sub
    Public Sub zw()
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("w", Nothing, Nothing)

        frmPpal.VdF.CommandLine.PostExecuteCommand("zw")
        frmPpal.ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
        ultimoComando = "zw"
    End Sub
    Public Sub zp()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("p", Nothing, Nothing)
        frmPpal.ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
        ultimoComando = "zp"

    End Sub
    Public Sub zr()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("S", 0.8, Nothing)
        frmPpal.ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
        ultimoComando = "zr"

    End Sub
    Public Sub za()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Zoom("S", 1.2, Nothing)
        frmPpal.ToolStrViewportsEscala.Text = CStr(verEscalaViewport())
        ultimoComando = "za"

    End Sub
    Public Sub attedit()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar bloque con atributos...")
        Dim seleccion As VectorDraw.Professional.vdCollections.vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection
        If seleccion Is Nothing Then
            If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
            End If
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
            frmPpal.lineaComandos.UserText.Clear()
            Exit Sub
        End If

        If seleccion.Count > 0 Then
            For Each elemento As vdFigure In seleccion
                If elemento._TypeName = "vdInsert" Then
                    Dim bloque As vdInsert = elemento
                    If bloque.Attributes.Count > 0 Then
                        frmAte.cargarDatos(bloque)
                        frmAte.ShowDialog()
                    End If
                End If
            Next
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Else
            If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
            End If
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
            frmPpal.lineaComandos.UserText.Clear()

            Exit Sub
        End If
        ultimoComando = "attedit"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub

    Public Sub IdPunto()
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccione punto")
        'Dim seleccion As VectorDraw.Professional.vdCollections.vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint

        Dim ret As VectorDraw.Actions.StatusCode
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            frmPpal.ToolStripLabelID.Text = "X,Y,Z = X: " & CStr(Format(punto.x, "0.0000")) & "  Y: " & CStr(Format(punto.y, "0.0000")) & "  Z: " & CStr(Format(punto.z, "0.0000"))
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        ultimoComando = "idpunto"

    End Sub

    Public Sub copiarPropiedades()

        Dim fig1 As vdFigure = Nothing, fig2 As vdFigure = Nothing, figTmp As vdFigure
        Dim userpt1 As gPoint = Nothing, userpt2 As gPoint = Nothing

        Dim elCursor As System.Windows.Forms.Cursor = frmPpal.VdF.BaseControl.GetCustomMousePointer
        Dim otroCursor As Cursor

        otroCursor = New Cursor(ubicacionSoporte & "\selecciona1.cur")
        'frmPpal.VdF.BaseControl.SetCustomMousePointer(System.Windows.Forms.Cursors.Cross)
        frmPpal.VdF.BaseControl.SetCustomMousePointer(otroCursor)

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccione entidad ORIGINAL...")
        Dim code As VectorDraw.Actions.StatusCode = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig1, userpt1)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If (code = VectorDraw.Actions.StatusCode.Success) Then
            If Not (fig1 Is Nothing) Then
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccione entidad/des DESTINO")
                otroCursor = New Cursor(ubicacionSoporte & "\selecciona.cur")
                frmPpal.VdF.BaseControl.SetCustomMousePointer(otroCursor)
                'Dim code2 As VectorDraw.Actions.StatusCode = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig2, userpt2)
                'frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
                'If (code2 = VectorDraw.Actions.StatusCode.Success) Then
                '    If Not (fig2 Is Nothing) Then
                '        'figTmp.MatchProperties(fig1, frmPpal.VdF.BaseControl.ActiveDocument)
                '        fig2.PenColor = fig1.PenColor
                '        fig2.LineType = fig1.LineType
                '        fig2.LineTypeScale = fig1.LineTypeScale
                '        fig2.Layer = fig1.Layer
                '    End If
                'End If
                Dim seleccion As VectorDraw.Professional.vdCollections.vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection()
                frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
                If Not seleccion Is Nothing Then
                    For Each figura As vdFigure In seleccion
                        figura.PenColor = fig1.PenColor
                        figura.LineType = fig1.LineType
                        figura.LineTypeScale = fig1.LineTypeScale
                        figura.Layer = fig1.Layer
                    Next

                End If
            End If
        End If
        'frmPpal.VdF.BaseControl.SetCustomMousePointer(Cursors.PanSE)
        frmPpal.VdF.BaseControl.SetCustomMousePointer(elCursor)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        ultimoComando = "copiarPropiedades"
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True

    End Sub
    Private Sub bpoly()
        '-------------------
        ' bPoly
        '-------------------
        Dim laPoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        laPoli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        laPoli.setDocumentDefaults()

        Dim ret As VectorDraw.Actions.StatusCode

        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint

        Dim retorno As Boolean
        Dim listaDeVertices As VectorDraw.Geometry.Vertexes

        '---------------------------
        ' punto interno
        '---------------------------
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar punto interno")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            retorno = laPoli.GetBoundaryPolyFromPoint(punto, 0.0)
        Else
            Exit Sub
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        listaDeVertices = laPoli.VertexList

        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(laPoli)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

        laPoli = Nothing
        listaDeVertices = Nothing
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = True


        'Dim pDes1 As VectorDraw.Professional.vdFigures.vdPoint = New VectorDraw.Professional.vdFigures.vdPoint
        'pDes1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        'pDes1.setDocumentDefaults()
        'pDes1.InsertionPoint = linea1.EndPoint
        'Dim pD1 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        'pD1.x = pDes1.InsertionPoint.x
        'pD1.y = pDes1.InsertionPoint.y
        'pD1.z = pDes1.InsertionPoint.z
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(pD1)
    End Sub

End Module
