Imports System.IO
Imports System.Reflection
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects
Imports System.Collections.ArrayList
Imports VectorDraw.Professional.vdFigures

Imports ADOX
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb


Module modConfigura
    Public hayArchivoIntercambio As Boolean
    Public producto As String


#Region "Configurar. Rutina ppal. Se ejecuta en el load del form principal."


    Public Sub Configurar()

        agregarManejadores()
        'planoParaVisadoresSiNo()                    '<-----10/11/11, se sacó afuera en otro exe
        'certificadoDeAmojonamientoSiNo()            '<-----por ahora no se usa
        configurarInicio()
        configurarParaCroquis()
        If Not leerEstilos() Then
            MsgBox("No se puede leer la tabla de los estilos", vbInformation, "Plano Digital")
            Exit Sub
        Else
            tipografias()
        End If
    End Sub



#End Region

    Private Sub configurarParaCroquis()
        If Not frmPpal.croquis Then
            frmPpal.tsGuardarCambios.Enabled = True
            Exit Sub
        Else
            frmPpal.tsGuardarCambios.Enabled = False
            frmDatosCroquis.Show()
        End If
    End Sub

    Public Sub tipografias()

        'pd_1estiloMz = New VectorDraw.Professional.vdPrimaries.vdTextstyle
        estiloMz1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        estiloMz1.setDocumentDefaults()
        For Each registro As DataRow In tblEstilos.Rows
            If registro("nombreEstilo") = "Macizo" Then
                estiloMz1.Name = registro("nombreEstilo")
                estiloMz1.FontFile = registro("tipoLetra")
                estiloMz1.Height = registro("altura")
            End If
        Next


        'pd_2estiloNombreCalle = New VectorDraw.Professional.vdPrimaries.vdTextstyle
        estiloNombreCalle2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        estiloNombreCalle2.setDocumentDefaults()
        For Each registro As DataRow In tblEstilos.Rows
            If registro("nombreEstilo") = "Nombre calle" Then
                estiloNombreCalle2.Name = registro("nombreEstilo")
                estiloNombreCalle2.FontFile = registro("tipoLetra")
                estiloNombreCalle2.Height = registro("altura")
            End If
        Next


        'pd_3estiloMedidaPl = New VectorDraw.Professional.vdPrimaries.vdTextstyle
        estiloMedidaPl3.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        estiloMedidaPl3.setDocumentDefaults()
        For Each registro As DataRow In tblEstilos.Rows
            If registro("nombreEstilo") = "Medida parcela" Then
                estiloMedidaPl3.Name = registro("nombreEstilo")
                estiloMedidaPl3.FontFile = registro("tipoLetra")
                estiloMedidaPl3.Height = registro("altura")
            End If
        Next


        'pd_4estiloAnchoMuro = New VectorDraw.Professional.vdPrimaries.vdTextstyle
        estiloAnchoMuro4.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        estiloAnchoMuro4.setDocumentDefaults()
        For Each registro As DataRow In tblEstilos.Rows
            If registro("nombreEstilo") = "Ancho muro" Then
                estiloAnchoMuro4.Name = registro("nombreEstilo")
                estiloAnchoMuro4.FontFile = registro("tipoLetra")
                estiloAnchoMuro4.Height = registro("altura")
            End If
        Next

    End Sub

#Region "agregarManejadores"
    Public Sub agregarManejadores()

        '--------------------------------
        'Manejadores de eventos
        '--------------------------------

        'Menu principal: Archivo
        '-------------------------------------------------------------------------------
        AddHandler frmPpal.NuevoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AbrirToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CerrarToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.GuardarToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.GuardarComoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ImprimirPlotearToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.puntasToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.SalirToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AbrirDwtToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal


        'Menu principal: Edicion
        '--------------------------------------------------------------------------------------
        AddHandler frmPpal.DeshacerUndoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.RehacerRedoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CortarToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CopiarToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.PegarToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal


        'Menu principal: Vistas
        '------------------------------------------------------------------------------------------
        AddHandler frmPpal.ZoomExtensióntodoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ZoomVentanaWindowToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ZoomAnteriorPreviousToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ZoomDisminuirToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ZoomAumentarToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.PanToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.NuevaLáminaLayoutToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        'AddHandler frmPpal.NuevaVentanaViewPortToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.DibujandoRectanguloToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.APartirDeUnaEntidadCerradaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ToolStripMenuItemE100.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ToolStripMenuItemE50.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ToolStripMenuItemE1000.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.IngresarDenominadorEscalaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.GiroDeViewPortToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.PosiciónOriginalDelViewPortToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.PorTresPuntosToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.UbicaciónOriginalWorldToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.UcsActualToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.OriginalWorldToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.BloquearViewPortToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CambiarUnidadesDelEspacioPapelToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.toolStrSendToBack.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.toolStrBringToFront.Click, AddressOf ManejaEventosMenuPpal


        'Menu principal: Dibujar
        '------------------------------------------------------------------------------------------------------
        AddHandler frmPpal.LineaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.xLine.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.xray.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.PolilineaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ArcoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CirculoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ElipseToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.RectanguloToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.PuntoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.EstiloDePuntoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        'texto de una linea:
        AddHandler frmPpal.UnaLineaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        'texto multilinea:
        AddHandler frmPpal.MultilineaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        'estilo de texto:
        AddHandler frmPpal.EstiloDeTextoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        'hatch:
        AddHandler frmPpal.TramadosHatchToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CrearToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.InsertarToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.EditarAtributosToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CrearAtributoToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ExportarBloqueToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal

        AddHandler frmPpal.Imagenes.Click, AddressOf ManejaEventosMenuPpal




        'Menu principal: Modificar
        '------------------------------------------------------------------------------------------
        AddHandler frmPpal.BorrarEraseToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CopiarCopyToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.SimetriaMirrorToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.EquidiistanciaOffsetToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.MoverMoveToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.RotarRotateToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.EscalaScaleToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.EstirarExtendToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.EmpalmeFilletToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.FilletRadioCeroToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ExplotarExplodeToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AlinearAlignToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CortarBreakToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.RecortarTrimToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ItemMenuCopiarPropiedades.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.bPolyToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.arrayRectangularToolStripMenuItem2.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.arrayPolarToolStripMenuItem1.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.deformarToolStripMenuItem1.Click, AddressOf ManejaEventosMenuPpal


        'Menu principal: Acotar
        '----------------------------------------------------------------------------------------------
        AddHandler frmPpal.AlineadaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.RadialToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.DiametralToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AngularToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.EstilosDeCotasToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.leader.Click, AddressOf ManejaEventosMenuPpal



        'Menu principal: Herramientas
        '---------------------------------------------------------------------------------------------
        AddHandler frmPpal.MedirDistanciaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.MedirAreaXVerticesToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.MedirAreaXEntidadToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.IdPunto.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ReferenciaAObjetosOsnapToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.PantallaPropiedadesToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.LayersToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ConfiguraciónCursor.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ConfiguraLaminas.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ConfiguraGrilla.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.configuracionOsnap.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ConfiguraciónAutoSaveToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.ConfiguraciònEspacioModeloToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.encenderApagarEjesUcs.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.PasarABynToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal


        'Menu principal: Agrimensores
        '------------------------------------------------------------------------------------------------
        AddHandler frmPpal.AbrirPlantillaCatastroToolStr.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AbrirAntecedenteDpctToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.GuardarArchivoParaDpctSysToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AbrirPlantillaGeodesiaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.toolStrAntecedeGeodesia.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.guardarDefinitivoParaGeodesia.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AbrirCertifAmojToolStripMenuItem1.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AcotarToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CotaDominioLineaInToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.CotaDominioLineaSuperiorToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AcotarLadosToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.AngulosToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        '--------------------------------------------------------------------------------------------------

        'ph:
        AddHandler frmPpal.UnidadesFuncionalesToolStripMenuItem.Click, AddressOf manejaEventosPh
        AddHandler frmPpal.UnidadesComplementariasToolStripMenuItem.Click, AddressOf manejaEventosPh
        AddHandler frmPpal.SuperficiesComunesToolStripMenuItem.Click, AddressOf manejaEventosPh
        AddHandler frmPpal.poligonosDominioToolStripMenuItem.Click, AddressOf manejaEventosPh
        AddHandler frmPpal.poligonosComunesToolStripMenuItem.Click, AddressOf manejaEventosPh


        '--------------------------------------------------------------------------------------------------
        'objetos de agrimensura
        AddHandler frmPpal.ParcelaToolStripMenuItem.Click, AddressOf manejaEventosObjetosAgrimensura
        AddHandler frmPpal.DeslindeToolStripMenuItem.Click, AddressOf manejaEventosObjetosAgrimensura
        AddHandler frmPpal.ExportarDatosToolStripMenuItem.Click, AddressOf manejaEventosObjetosAgrimensura
        AddHandler frmPpal.NomenclaturaToolStripMenuItem.Click, AddressOf manejaEventosObjetosAgrimensura
        AddHandler frmPpal.DistanciaEsquinaToolStripMenuItem.Click, AddressOf manejaEventosObjetosAgrimensura
        AddHandler frmPpal.PoligonoEdificioToolStripMenuItem.Click, AddressOf manejaEventosObjetosAgrimensura


        'Menú Ayudas y configuración:
        '-----------------------------------------------------------------------------------------------
        AddHandler frmPpal.CambiosEnLaVersionActualToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.Abreviaturas.Click, AddressOf ManejaEventosMenuPpal
        AddHandler frmPpal.VersiónLibreriaToolStripMenuItem.Click, AddressOf ManejaEventosMenuPpal



        '===================================================================================================
        '///////////////////////////////////////////////////////////////////////////////////////////////////
        ' Las toolbars:
        '///////////////////////////////////////////////////////////////////////////////////////////////////
        '===================================================================================================
        'toolbar: Layers
        AddHandler frmPpal.toolStrLayersBtnLayers.Click, AddressOf ManejaEventosToolLayers
        AddHandler frmPpal.ToolStrLayersBtnTipoLinea.Click, AddressOf ManejaEventosToolLayers
        AddHandler frmPpal.ToolStrLayersCmbTipoLinea.SelectedIndexChanged, AddressOf ManejaEventosToolLayers
        AddHandler frmPpal.ToolStrLayersBtnEspesor.Click, AddressOf ManejaEventosToolLayers
        AddHandler frmPpal.ToolStrLayersCmbEspesor.SelectedIndexChanged, AddressOf ManejaEventosToolLayers
        AddHandler frmPpal.ToolStrLayersBtnColor.Click, AddressOf ManejaEventosToolLayers
        AddHandler frmPpal.ToolStrLayersLblColor.Click, AddressOf ManejaEventosToolLayers
        AddHandler frmPpal.ToolStripLayersBtnFondoLayout.Click, AddressOf ManejaEventosToolLayers

        'toolbar: Osnap
        AddHandler frmPpal.ToolStrOsnapEnd.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapMid.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapCen.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapInt.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapPer.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapNea.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapNon.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapNod.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapQua.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapApa.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapTan.Click, AddressOf ManejaEventosToolOsnap
        AddHandler frmPpal.ToolStrOsnapActivado.Click, AddressOf apagarEncenderOsnap



        'toolbar: General
        AddHandler frmPpal.NuevoToolStripButton.Click, AddressOf ManejaEventosToolGral
        AddHandler frmPpal.AbrirToolStripButton.Click, AddressOf ManejaEventosToolGral
        AddHandler frmPpal.GuardarToolStripButton.Click, AddressOf ManejaEventosToolGral
        AddHandler frmPpal.ImprimirToolStripButton.Click, AddressOf ManejaEventosToolGral
        AddHandler frmPpal.CortarToolStripButton.Click, AddressOf ManejaEventosToolGral
        AddHandler frmPpal.CopiarToolStripButton.Click, AddressOf ManejaEventosToolGral
        AddHandler frmPpal.PegarToolStripButton.Click, AddressOf ManejaEventosToolGral
        AddHandler frmPpal.AyudaToolStripButton.Click, AddressOf ManejaEventosToolGral
        AddHandler frmPpal.MatchToolStripButton.Click, AddressOf ManejaEventosToolGral

        'toolbar: Dibujar
        'AddHandler frmPpal.ToolStrEditarDeshacer.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarLinea.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarPolilinea.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarRectang.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarArco.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarCirculo.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarElipse.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarPunto.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarTexto.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarHatch.Click, AddressOf ManejaEventosToolDibujar
        AddHandler frmPpal.ToolStrDibujarInsert.Click, AddressOf ManejaEventosToolDibujar


        'toolbar: Editar
        AddHandler frmPpal.ToolStrEditarPropiedades.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarCopy.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarMirror.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarMove.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarRotate.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarScale.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarTrim.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarExtend.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarExplode.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarFillet.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarFilletR0.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarOffset.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarBreak.Click, AddressOf ManejaEventosToolEditar
        AddHandler frmPpal.ToolStrEditarAlinear.Click, AddressOf ManejaEventosToolEditar

        'toolbar Editar 2
        AddHandler frmPpal.ToolStrEditarDeshacer.Click, AddressOf ManejaEventosToolEditar2
        AddHandler frmPpal.ToolStrEditarRehacer.Click, AddressOf ManejaEventosToolEditar2
        AddHandler frmPpal.ToolStrEditarBorrar.Click, AddressOf ManejaEventosToolEditar2
        AddHandler frmPpal.ToolStrEditarAtt.Click, AddressOf ManejaEventosToolEditar2
        AddHandler frmPpal.ToolStrEscalaViewport.Click, AddressOf ManejaEventosToolEditar2

        'toolbar vistas
        AddHandler frmPpal.ToolStrPan.Click, AddressOf ManejaEventosToolVistas
        AddHandler frmPpal.ToolStrZoomExtension.Click, AddressOf ManejaEventosToolVistas
        AddHandler frmPpal.ToolStrZoomWindows.Click, AddressOf ManejaEventosToolVistas
        AddHandler frmPpal.ToolStrZoomPrevious.Click, AddressOf ManejaEventosToolVistas
        AddHandler frmPpal.ToolStrZoomReducir.Click, AddressOf ManejaEventosToolVistas
        AddHandler frmPpal.ToolStrZoomAmpliar.Click, AddressOf ManejaEventosToolVistas

        'toolbar acotar
        AddHandler frmPpal.ToolStrAlineada.Click, AddressOf ManejaEventosAcotar
        AddHandler frmPpal.ToolStrRadial.Click, AddressOf ManejaEventosAcotar
        AddHandler frmPpal.ToolStrDiametral.Click, AddressOf ManejaEventosAcotar
        AddHandler frmPpal.ToolStrAngular.Click, AddressOf ManejaEventosAcotar
        AddHandler frmPpal.ToolStrLeader.Click, AddressOf ManejaEventosAcotar
        AddHandler frmPpal.ToolStrEstilo.Click, AddressOf ManejaEventosAcotar

        'toolbar 3D
        AddHandler frmPpal.tsbtn3Drotacion.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dtop.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dbottom.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dleft.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dright.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dfront.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dback.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dne.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dnw.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dse.Click, AddressOf manejaEventos3D
        AddHandler frmPpal.tsbtn3Dsw.Click, AddressOf manejaEventos3D

    End Sub
#End Region




#Region "paraVisadores"
    'Private Sub planoParaVisadoresSiNo()
    '    '================================================================================================
    '    'ver si esta el archivo con el dibujo a abrir para los visadores.
    '    '
    '    'Este archivo se llama "plano.txt". Si este archivo esta, ver si tiene una linea con el path y
    '    'nombre de un archivo de dibujo dwg.
    '    'Si el archivo contiene esta linea, abrir el dibujo. Luego borrar el archivo
    '    'Si el archivo no contiene esta linea, borrar el archivo.
    '    '================================================================================================
    '    Dim huboError As Boolean
    '    Dim fileInt As New FileInfo("C:\CpaCad2\plano.txt")
    '    Dim existe As Boolean = fileInt.Exists
    '    If existe = False Then
    '        Exit Sub
    '    End If


    '    'leer archivo de intercambio..
    '    Dim archivo As Stream = File.Open("C:\CpaCad2\" & "plano.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
    '    Dim lector As New StreamReader(archivo)
    '    Dim queLeyo As String
    '    Do Until lector.Peek = -1
    '        queLeyo = lector.ReadLine().ToString
    '        If queLeyo = "" Then Exit Do

    '        If Strings.InStr(queLeyo, ".dwg") > 0 Then
    '            'es la linea donde esta el path del dwg a abrir..
    '            Dim hayDibujo As FileInfo = New FileInfo(queLeyo)
    '            If hayDibujo.Exists = False Then
    '                MsgBox("No se encuentra el archivo " & queLeyo & " que aparece en el archivo de intercambio.", MsgBoxStyle.Information, aplicacionNombre)
    '                huboError = True
    '                Exit Do
    '            Else
    '                Dim success As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(queLeyo)
    '                If (success) Then
    '                    'Dim respuesta As DialogResult = MsgBox("Pasar a blanco y negro?", MsgBoxStyle.YesNo, aplicacionNombre)
    '                    'If respuesta = DialogResult.Yes Then
    '                    '13/9/2011
    '                    'frmPpal.blancoNegro()
    '                    'End If
    '                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    '                    configurarInicio()
    '                    archivoActivo(queLeyo)
    '                End If
    '            End If
    '        End If

    '        If UCase(queLeyo) = "VISADORES" Then
    '            'armar version para visadores..
    '            frmPpal.VdF.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, False)
    '            frmPpal.VdF.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.StatusBar, False)
    '            frmPpal.VdF.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, False)
    '            frmPpal.ToolStrViewports.Visible = False
    '            frmPpal.ToolStrViewportsEscala.Visible = False
    '            'frmPpal.ToolStrEscViewpBtn.Visible = False
    '            'frmPpal.toolStripBtnPropVP.Visible = False
    '            frmPpal.toolStrGeneral.Visible = False
    '            frmPpal.ToolStrCotas.Visible = False
    '            frmPpal.ToolStrOsnap.Visible = False
    '            frmPpal.ToolStrEditar.Visible = False
    '            frmPpal.ToolStrEditar2.Visible = False
    '            frmPpal.ToolStrDibujar.Visible = False
    '            frmPpal.ToolStrLayers.Visible = False
    '            frmPpal.ToolStrCotas.Visible = False
    '            frmPpal.MenuStrip1.Visible = False
    '            frmPpal.ToolStripVisadores.Visible = True
    '            frmPpal.ControlBox = False
    '            frmPpal.WindowState = System.Windows.Forms.FormWindowState.Maximized
    '            versionVisadores = True
    '        End If
    '    Loop
    '    lector.Close()
    '    If Not huboError Then
    '        '13/9/2011
    '        fileInt.Delete()
    '    End If

    'End Sub

#End Region
#Region "certificadoAmojonamiento"
    Private Sub certificadoDeAmojonamientoSiNo()
        '================================================================================================
        'ver si esta el archivo de intercambio..
        '
        ' Si el archivo de intercambio esta, arrancar cargando la plantilla del certificado de amoj.
        ' Si el archivo de intercambio NO TIENE una linea con el path\nombre.dwg, cargar los datos 
        ' del archivo de intercambio SIN los datos de la oblea de visado (nro visado, codigo barras, etc)
        ' Si el archivo de intercambio TIENE una linea con el path\nombre.dwg, los datos generales de la
        ' plantilla ya fueron cargados. Cargar solamente la información de la oblea de visado si es que 
        ' este dato esta.
        '
        ' Si el archivo de intercambio no esta arrancar normal (documento vacio)
        '=================================================================================================
        Dim fileInt As New FileInfo("C:\CpaCad2\intercambio.INT")
        Dim existe As Boolean = fileInt.Exists

        If existe = False Then
            hayArchivoIntercambio = False
            Exit Sub
        Else
            'el archivo existe por lo tanto cargarlo..
            hayArchivoIntercambio = True
            certificadoAmojonamiento()
        End If

    End Sub
#End Region




#Region "configurarInicio (primera vez)"
    Public Sub configurarInicio()
        '--------------------------------------------------------------------------------------------------
        ' Procedimientos que se ejecutan cuando se inicia el pgma y cuando se carga/inicia un nuevo archivo
        '--------------------------------------------------------------------------------------------------
        frmPpal.VdF.ShowMenu(False)
        apagaGrilla()
        frmPpal.VdF.DisplayPolarCoord = False
        frmPpal.VdF.BaseControl.ActiveDocument.MirrorText = False

        'agregar los estilos de cotas de agrim.
        Agregar_Estilos_Cotas()

        actualizarCmbTipoLinea()
        actualizarCmbEspesores()
        actualizarLblColores()

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")

        'establecer que tecla, junto con el boton derecho del mouse, muestra la pantalla del osnap
        'frmPpal.VdF.BaseControl.ActiveDocument.OsnapDialogKey = System.Windows.Forms.Keys.ShiftKey
        leerConfiguracionOsnap()

        agregarComboLayers()
        actualizarCmbLayers()

        frmPpal.VdF.BaseControl.ActiveDocument.GridMode = False
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = False
        If modeloSi() = True Then
            'frmPpal.ToolStrViewports.Enabled = False
            frmPpal.ToolStrViewportsEscala.Enabled = False
            frmPpal.ToolStrEscViewpBtn.Enabled = False
            frmPpal.btnUnidadesPapel.Enabled = False
            frmPpal.btnBloquearVP.Enabled = False
            frmPpal.toolStripBtnPropVP.Enabled = False

        Else
            'frmPpal.ToolStrViewports.Enabled = True
            frmPpal.ToolStrViewportsEscala.Enabled = True
            frmPpal.ToolStrEscViewpBtn.Enabled = True
            frmPpal.btnUnidadesPapel.Enabled = True
            frmPpal.btnBloquearVP.Enabled = True
            frmPpal.toolStripBtnPropVP.Enabled = True

        End If

        'ubicar tamaño y posicion de algunas toolbars.
        posicionarToolBars()
        leerConfiguracionAutoSave()
        configuracionesGuardadas()

        sacarPorcientos()

    End Sub
#End Region





#Region "Configurar Inicio archivo existente"
    Public Sub configurarInicioArchivoExistente()
        '-------------------------------------------------------------
        ' Rutinas que se ejecutan cuando se carga un archivo existente.
        ' Se llama desde "modArchivos.abrirArchivo".
        '-------------------------------------------------------------

        '---------------------------------------------------
        'agregar_Estilos_Textos()                           '
        'Agregar_Bloques()                                  ' <---Catastro.
        '---------------------------------------------------

        Agregar_Estilos_Cotas()
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")

        'establecer que tecla, junto con el boton derecho del mouse, muestra la pantalla del osnap
        'frmPpal.VdF.BaseControl.ActiveDocument.OsnapDialogKey = System.Windows.Forms.Keys.ShiftKey
        leerConfiguracionOsnap()

        agregarComboLayers()
        actualizarCmbLayers()

        'frmPpal.VdF.SetStatusBarOption(vdControls.vdFramedControl.StatusBarOptions.OsnapButton, False)

        frmPpal.VdF.BaseControl.ActiveDocument.GridMode = False
        frmPpal.VdF.BaseControl.ActiveDocument.IsModified = False
        If modeloSi() = True Then
            'frmPpal.ToolStrViewports.Enabled = False
            frmPpal.ToolStrViewportsEscala.Enabled = False
            frmPpal.ToolStrEscViewpBtn.Enabled = False
            frmPpal.btnUnidadesPapel.Enabled = False
            frmPpal.btnBloquearVP.Enabled = False
            frmPpal.toolStripBtnPropVP.Enabled = False
        Else
            'frmPpal.ToolStrViewports.Enabled = True
            frmPpal.ToolStrViewportsEscala.Enabled = True
            frmPpal.ToolStrEscViewpBtn.Enabled = True
            frmPpal.btnUnidadesPapel.Enabled = True
            frmPpal.btnBloquearVP.Enabled = True
            frmPpal.toolStripBtnPropVP.Enabled = True
        End If
        posicionarToolBars()
        configuracionesGuardadas()

        sacarPorcientos()

    End Sub
    Private Sub sacarPorcientos()
        Dim indice As Integer = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count
        Dim fig As vdFigure

        For i As Integer = indice - 1 To 0 Step -1
            fig = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Item(i)
            If fig._TypeName = "vdText" Then
                Dim texto As New vdText
                texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                texto.setDocumentDefaults()
                texto = CType(fig, vdText)
                If InStr(texto.TextString, "%%O") Then
                    texto.TextString = texto.TextString.ToString.Replace("%%O", "")
                    texto.TextLine = VectorDraw.Render.grTextStyleExtra.TextLineFlags.OverLine
                End If
                If InStr(texto.TextString, "%%U") Then
                    texto.TextString = texto.TextString.ToString.Replace("%%O", "")
                    texto.TextLine = VectorDraw.Render.grTextStyleExtra.TextLineFlags.UnderLine
                End If
                texto.Update()
            End If
        Next
    End Sub
#End Region


#Region "Cargar plantilla Catastro"
    Public Sub cargarPlantillaCatastro()
        '--------------------------------------------------
        ' Llamada desde "modPublico.ManejaEventosMenuPpal"
        '--------------------------------------------------

        'agregar los bloques de la plantilla de catastro.                       '| 
        Agregar_Bloques()                                                       '|

        'agregar los layers de la plantilla de catastro.                        '|
        modLayers.agregarLayers()                                               '|
        '                                                                       '|
        'agregar los estilos de textos de la plantilla de catastro              '|<---- Catastro
        agregar_Estilos_Textos()                                                '| 
        '                                                                       '|

    End Sub
#End Region




#Region "Posicinar toolbars"
    Public Sub posicionarToolBars()
        '---------------------------------------------------------------------------------
        ' Llamada desde modConfigura.posicionarToolbars
        '
        ' fijar la posicion de la toolbar de las escalas de viewports y la toolbar general
        '---------------------------------------------------------------------------------

        'la toolbar de los viewports:
        frmPpal.ToolStrViewports.Location = New System.Drawing.Point(422, 24)
        frmPpal.ToolStrViewports.Size = New System.Drawing.Size(400, 25)

        'la toolbar general:
        frmPpal.toolStrGeneral.Location = New System.Drawing.Point(3, 24)

        'la toolbar de cotas:
        frmPpal.ToolStrCotas.Location = New System.Drawing.Point(240, 24)

    End Sub

#End Region


#Region "Osnap (leer, guardar, recargar)"
    Public Sub leerConfiguracionOsnap()

        Dim archivo As Stream = File.Open(ubicacionSoporte & "config.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
        Dim lector As New StreamReader(archivo)

        Dim valorOsnap As String = lector.ReadLine
        Dim vectorOsnap() As String

        If desarmaStr(valorOsnap, vectorOsnap) = False Then
            'MsgBox("No se pudo leer la configuración del Osnap", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If

        Dim osnapAcumulado As Integer = 0
        For a As Integer = 0 To UBound(vectorOsnap)
            Select Case vectorOsnap(a)
                Case "END"
                    osnapAcumulado = osnapAcumulado + 1
                Case "MID"
                    osnapAcumulado = osnapAcumulado + 2
                Case "CEN"
                    osnapAcumulado = osnapAcumulado + 4
                Case "INS"
                    osnapAcumulado = osnapAcumulado + 8
                Case "PER"
                    osnapAcumulado = osnapAcumulado + 16
                Case "NEA"
                    osnapAcumulado = osnapAcumulado + 32
                Case "INTERS"
                    osnapAcumulado = osnapAcumulado + 64
                Case "QUA"
                    osnapAcumulado = osnapAcumulado + 256
                Case "TANG"
                    osnapAcumulado = osnapAcumulado + 512
                Case "APPARENTINT"
                    osnapAcumulado = osnapAcumulado + 1024
            End Select
        Next

        Dim elOsnap As VectorDraw.Geometry.OsnapMode = New VectorDraw.Geometry.OsnapMode
        elOsnap = osnapAcumulado
        frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = elOsnap
        lector.Close()


    End Sub

    Public Sub guardarConfiguracionOsnap()

        Dim archivoConfiguracion As New FileInfo(ubicacionSoporte & "config.txt")
        Dim existe As Boolean = archivoConfiguracion.Exists
        If existe Then
            archivoConfiguracion.Delete()
        End If
        archivoConfiguracion = Nothing

        'importar "System.io".
        'aqui se pasa un filestream desde el metodo open de la clase file al metodo constructor de SteamWriter
        Dim archivo As Stream = File.Open(ubicacionSoporte & "config.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        Dim escritor As New StreamWriter(archivo)

        Dim valorOsnap As String = frmPpal.VdF.BaseControl.ActiveDocument.osnapMode.ToString

        escritor.Write(valorOsnap)
        escritor.Close()

    End Sub


    Public Sub recargarOsnap(ByVal valorOsnap As String)

        Dim vectorOsnap() As String

        If desarmaStr(valorOsnap, vectorOsnap) = False Then
            MsgBox("No se pudo leer la configuración del Osnap", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        End If
        Dim osnapAcumulado As Integer = 0
        For a As Integer = 0 To UBound(vectorOsnap)
            Select Case vectorOsnap(a)
                Case "END"
                    osnapAcumulado = osnapAcumulado + 1
                Case "MID"
                    osnapAcumulado = osnapAcumulado + 2
                Case "CEN"
                    osnapAcumulado = osnapAcumulado + 4
                Case "INS"
                    osnapAcumulado = osnapAcumulado + 8
                Case "PER"
                    osnapAcumulado = osnapAcumulado + 16
                Case "NEA"
                    osnapAcumulado = osnapAcumulado + 32
                Case "INTERS"
                    osnapAcumulado = osnapAcumulado + 64
                Case "QUA"
                    osnapAcumulado = osnapAcumulado + 256
                Case "TANG"
                    osnapAcumulado = osnapAcumulado + 512
                Case "APPARENTINT"
                    osnapAcumulado = osnapAcumulado + 1024
            End Select
        Next

        Dim elOsnap As VectorDraw.Geometry.OsnapMode = New VectorDraw.Geometry.OsnapMode
        elOsnap = osnapAcumulado
        frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = elOsnap

    End Sub
#End Region




#Region "Determinar archivo activo"
    Public Sub archivoActivo(ByVal nombre As String)
        '-------------------------------------------
        ' Llamada desde "frmPpal.Load"
        ' modCertifAmoj.CertificadoAmojonamiento"
        '-------------------------------------------

        'Dim versionProducto As String = "2.0." & DateDiff(DateInterval.Day, #1/1/2010#, #7/9/2010#)
        Dim versionProducto As String = "2.3.3"
        If nombre = "" Then
            frmPpal.Text = aplicacionNombre & " - " & versionProducto
        Else
            frmPpal.Text = aplicacionNombre & " - " & versionProducto & " - " & nombre
        End If

    End Sub
#End Region


#Region "autosave"

    Public Sub leerConfiguracionAutoSave()
        Dim archivo As Stream = File.Open(ubicacionSoporte & "autosave.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
        Dim lector As New StreamReader(archivo)
        Dim valorAutoSave As String = lector.ReadLine

        If valorAutoSave Is Nothing Then
            frmPpal.tiempoDeAutosave = 300000 'cinco minutos pasados a milisegundos
        Else
            frmPpal.tiempoDeAutosave = CInt(valorAutoSave) 'el tiempo leido en ms del archivo "autosave.txt"
        End If
        frmPpal.Timer1.Interval = frmPpal.tiempoDeAutosave


    End Sub

    Public Sub configuraAutosave()
        '---------------------------------
        ' configurar el tiempo de autosave
        '---------------------------------
        Dim temporal As String
        temporal = InputBox("Ingresar tiempo en minutos para hacer copia de seguridad", "mh Cad", CStr(frmPpal.tiempoDeAutosave / 60000))
        If IsNumeric(temporal) Then
            If InStr(temporal, ",") <> 0 Or InStr(temporal, ".") <> 0 Then
                MsgBox("Ingresar un valor numérico entero.", MsgBoxStyle.Information, aplicacionNombre)
                Exit Sub
            End If
            frmPpal.tiempoDeAutosave = CInt(temporal) * 60000
            frmPpal.Timer1.Interval = frmPpal.tiempoDeAutosave
        Else
            If temporal = "" Then
                Exit Sub
            Else
                MsgBox("Ingresar un valor numérico entero.", MsgBoxStyle.Information, aplicacionNombre)
            End If
        End If

        Dim archivoAutoSave As New FileInfo(ubicacionSoporte & "autosave.txt")
        Dim existe As Boolean = archivoAutoSave.Exists
        If existe Then
            archivoAutoSave.Delete()
        End If
        archivoAutoSave = Nothing

        Dim archivo As Stream = File.Open(ubicacionSoporte & "autosave.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        Dim escritor As New StreamWriter(archivo)

        escritor.Write(frmPpal.tiempoDeAutosave)
        escritor.Close()

        ultimoComando = "autosave"
    End Sub

#End Region

    Private Sub configuracionesGuardadas()
        'agrego que se fije si hubo un cambio de ensamblado y es la primera vez que lee las configuraciones y en ese caso
        'leeria los valores por defecto de las propiedades guardadas. Esto es porque los datos guardados dependen de la 
        'version del ensamblado. Si el valor leido para la esquina superior izquierda es -999 quiere decir que es la primer
        'lectura, por lo tanto hay que ejecutar la sentencia "upgrade" para actualizar los valores a los que se tenian en
        'la anterior version del ensamblado
        'If My.Settings.Left = -999 Then
        '    My.Settings.Upgrade()
        'End If
        If My.Settings.nuncaSeGuardo Then
            My.Settings.Upgrade()
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Model.BkColorEx = My.Settings.ColorFondo
        frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorAxisColor = My.Settings.ColorCursor
        frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.CursorPickColor = My.Settings.ColorCaja
        frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.PickSize = My.Settings.MedidaCaja
        frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.AxisSize = My.Settings.MedidaCursor
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

        frmPpal.VdF.BaseControl.ActiveDocument.Document.GlobalRenderProperties.EnableMiddleGripForPolylines = True

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        My.Settings.vdfCursor = frmPpal.VdF.BaseControl.GetCustomMousePointer
        frmPpal.WindowState = My.Settings.estadoVentanaAplicacion
        frmPpal.Left = My.Settings.Left
        frmPpal.Top = My.Settings.top
        frmPpal.Width = My.Settings.width
        frmPpal.Height = My.Settings.heigth

        '----------------------------
        ' Espesores
        '----------------------------
        If My.Settings.espesores Is Nothing Then
            My.Settings.espesores = New System.Collections.Specialized.StringCollection
            For a As Integer = 0 To 254
                My.Settings.espesores.Add("0.001")
            Next
        Else
            Dim i As Integer = 0, separadorDecimal As String = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator

            For Each elemento As String In My.Settings.espesores
                If InStr(elemento, ".") <> 0 Then
                    If separadorDecimal <> "." Then
                        elemento = elemento.ToString.Replace(".", separadorDecimal)
                    End If
                End If
                If InStr(elemento, ",") <> 0 Then
                    If separadorDecimal <> "," Then
                        elemento = elemento.ToString.Replace(",", separadorDecimal)
                    End If
                End If
                matrizEspesores(i) = CDbl(elemento)
                i = i + 1
            Next
        End If
        '------------------------------
        ' Espesores
        '------------------------------



        '------------------------------
        ' Impresora seleccionada
        '------------------------------




    End Sub

    Public Sub ponerCursorParaPreguntar()
        Dim cursorDeSeleccionar As Cursor = Cursors.Help
        frmPpal.VdF.BaseControl.SetCustomMousePointer(cursorDeSeleccionar)
    End Sub

    Public Sub ponerCursorParaSeleccionar()
        Dim cursorDeSeleccionar As Cursor = New Cursor(ubicacionSoporte & "\selecciona1.cur")
        frmPpal.VdF.BaseControl.SetCustomMousePointer(cursorDeSeleccionar)
    End Sub

    Public Sub ponerCursorParaSeleccionarSegundaParte()
        Dim cursorDeSeleccionar As Cursor = Cursors.Cross
        frmPpal.VdF.BaseControl.SetCustomMousePointer(cursorDeSeleccionar)
    End Sub

    Public Sub ponerCursorOriginal()
        Dim elCursorOriginal As System.Windows.Forms.Cursor = My.Settings.vdfCursor
        frmPpal.VdF.BaseControl.SetCustomMousePointer(elCursorOriginal)
    End Sub
End Module
