<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpal))
        Me.ToolStrLayers = New System.Windows.Forms.ToolStrip()
        Me.toolStrLayersBtnLayers = New System.Windows.Forms.ToolStripButton()
        Me.toolStrBtnApagarLayersPapel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrLayersBtnTipoLinea = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrLayersCmbTipoLinea = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrLayersBtnEspesor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrLayersCmbEspesor = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrLayersBtnColor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrLayersLblColor = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLayersBtnFondoLayout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelID = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsLbIdTrabajo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBorrarEntidad = New System.Windows.Forms.ToolStripButton()
        Me.tsEstilos = New System.Windows.Forms.ToolStripButton()
        Me.tsMoverParcela = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsdMacizo = New System.Windows.Forms.ToolStripDropDownButton()
        Me.definirMacizoPorPuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.definirMacizoPorPolilinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdMacizoLinderos = New System.Windows.Forms.ToolStripDropDownButton()
        Me.DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefinirMacizoSeleccionandoPolilineaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdDistanciaEsquina = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsdDefinirPorPuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdDefinirPorPolilinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdParcela = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsdDefinirPlPorPuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CroquisDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdParcelaLindera = New System.Windows.Forms.ToolStripDropDownButton()
        Me.DefinirParcelaLinderaPorPuntosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefinirParcelaLinderaPorPolilineaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMuros = New System.Windows.Forms.ToolStripButton()
        Me.tsdSimbolos = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsdNorteUno = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCroquis = New System.Windows.Forms.ToolStripButton()
        Me.tsGuardarCambios = New System.Windows.Forms.ToolStripButton()
        Me.VdF = New vdControls.vdFramedControl()
        Me.ToolStrVistas = New System.Windows.Forms.ToolStrip()
        Me.ToolStrPan = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrZoomExtension = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrZoomWindows = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrZoomPrevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrZoomReducir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrZoomAmpliar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujar = New System.Windows.Forms.ToolStrip()
        Me.ToolStrDibujarLinea = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarPolilinea = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarRectang = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarArco = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarCirculo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarElipse = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarPunto = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarTexto = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarHatch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDibujarInsert = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditar2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStrEditarDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarRehacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarAtt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEscalaViewport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditar = New System.Windows.Forms.ToolStrip()
        Me.ToolStrEditarPropiedades = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarCopy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarMirror = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarMove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarRotate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarScale = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarTrim = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarExtend = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarExplode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarFilletR0 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarFillet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarOffset = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarBreak = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEditarAlinear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3D = New System.Windows.Forms.ToolStrip()
        Me.tsbtn3Drotacion = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dtop = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dbottom = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dleft = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dright = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dfront = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dback = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dne = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dnw = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dse = New System.Windows.Forms.ToolStripButton()
        Me.tsbtn3Dsw = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnap = New System.Windows.Forms.ToolStrip()
        Me.ToolStrOsnapEnd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapMid = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapCen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapInt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapPer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapNea = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapApa = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapNod = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapNon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapQua = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapTan = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrOsnapActivado = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirDwtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.puntasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirPlotearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshacerUndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RehacerRedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CortarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VistasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomExtensióntodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomVentanaWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomAnteriorPreviousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomDisminuirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomAumentarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.PanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStrSendToBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrBringToFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevaLáminaLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentanasViewPortsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaVentanaViewPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DibujandoRectanguloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.APartirDeUnaEntidadCerradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalasEnVentanasViewPortsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemE100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemE50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemE1000 = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresarDenominadorEscalaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GiroDeViewPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PosiciónOriginalDelViewPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BloquearViewPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarUnidadesDelEspacioPapelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.UcsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UcsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PorTresPuntosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UbicaciónOriginalWorldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UcsActualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OriginalWorldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DibujarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LineaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.xLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.xray = New System.Windows.Forms.ToolStripMenuItem()
        Me.PolilineaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ArcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CirculoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElipseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RectanguloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.PuntoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstiloDePuntoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnaLineaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultilineaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstiloDeTextoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.TramadosHatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.BloquesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarAtributosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearAtributoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarBloqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.Imagenes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarEraseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiarCopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SimetriaMirrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EquidiistanciaOffsetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoverMoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotarRotateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalaScaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecortarTrimToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstirarExtendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.deformarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.arrayRectangularToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.arrayPolarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilletRadioCeroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpalmeFilletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExplotarExplodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlinearAlignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CortarBreakToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.ItemMenuCopiarPropiedades = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.bPolyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasarABynToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlineadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiametralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AngularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.leader = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstilosDeCotasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedirDistanciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedirAreaXVerticesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedirAreaXEntidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.IdPunto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReferenciaAObjetosOsnapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PantallaPropiedadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarrasDeHerramientasToolBarsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DibujarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdiciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Edición2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OsnapToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayersToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstandarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VistasPanYZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewPortsescalasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónCursor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraGrilla = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionOsnap = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónAutoSaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraLaminas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciònEspacioModeloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.encenderApagarEjesUcs = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgrimensoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirPlantillaCatastroToolStr = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirAntecedenteDpctToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarArchivoParaDpctSysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.AbrirPlantillaGeodesiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrAntecedeGeodesia = New System.Windows.Forms.ToolStripMenuItem()
        Me.guardarDefinitivoParaGeodesia = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.PHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cuadroSuperficiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnidadesFuncionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnidadesComplementariasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuperficiesComunesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.poligonosDominioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.poligonosComunesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.AbrirCertifAmojToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotasAgrimensuraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcotarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotaDominioLineaSuperiorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotaDominioLineaInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcotarLadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AngulosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjetosAgrimensuraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParcelaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeslindeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NomenclaturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DistanciaEsquinaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PoligonoEdificioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudasEInformaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Abreviaturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersiónLibreriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivarProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarDatosEnArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresarElCodigoDeActivaciònToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiosEnLaVersionActualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrGeneral = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CortarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopiarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.MatchToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrViewports = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrViewportsEscala = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStrEscViewpBtn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUnidadesPapel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBloquearVP = New System.Windows.Forms.ToolStripButton()
        Me.toolStripBtnPropVP = New System.Windows.Forms.ToolStripButton()
        Me.botonApagarViewports = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrCotas = New System.Windows.Forms.ToolStrip()
        Me.ToolStrAlineada = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrRadial = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrDiametral = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrAngular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrLeader = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrEstilo = New System.Windows.Forms.ToolStripButton()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ofdDwt = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.CachedCedulaFinal_121 = New mhCad.CachedCedulaFinal_12()
        Me.ToolStrLayers.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.LeftToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.RightToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrVistas.SuspendLayout()
        Me.ToolStrDibujar.SuspendLayout()
        Me.ToolStrEditar2.SuspendLayout()
        Me.ToolStrEditar.SuspendLayout()
        Me.ToolStrip3D.SuspendLayout()
        Me.ToolStrOsnap.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.toolStrGeneral.SuspendLayout()
        Me.ToolStrViewports.SuspendLayout()
        Me.ToolStrCotas.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrLayers
        '
        Me.ToolStrLayers.AllowItemReorder = True
        Me.ToolStrLayers.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrLayers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStrLayersBtnLayers, Me.toolStrBtnApagarLayersPapel, Me.ToolStripSeparator24, Me.ToolStrLayersBtnTipoLinea, Me.ToolStrLayersCmbTipoLinea, Me.ToolStripSeparator26, Me.ToolStrLayersBtnEspesor, Me.ToolStrLayersCmbEspesor, Me.ToolStripSeparator25, Me.ToolStrLayersBtnColor, Me.ToolStrLayersLblColor, Me.ToolStripSeparator16, Me.ToolStripLayersBtnFondoLayout, Me.ToolStripSeparator20, Me.ToolStripLabelID})
        Me.ToolStrLayers.Location = New System.Drawing.Point(3, 99)
        Me.ToolStrLayers.Name = "ToolStrLayers"
        Me.ToolStrLayers.Size = New System.Drawing.Size(634, 25)
        Me.ToolStrLayers.TabIndex = 0
        Me.ToolStrLayers.Text = "ToolStrip1"
        '
        'toolStrLayersBtnLayers
        '
        Me.toolStrLayersBtnLayers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStrLayersBtnLayers.Image = Global.mhCad.My.Resources.Resources.Layers
        Me.toolStrLayersBtnLayers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStrLayersBtnLayers.Name = "toolStrLayersBtnLayers"
        Me.toolStrLayersBtnLayers.Size = New System.Drawing.Size(23, 22)
        Me.toolStrLayersBtnLayers.Tag = "btnLayers"
        Me.toolStrLayersBtnLayers.Text = "ToolStripButton1"
        Me.toolStrLayersBtnLayers.ToolTipText = "Manejo de capas (layers)"
        '
        'toolStrBtnApagarLayersPapel
        '
        Me.toolStrBtnApagarLayersPapel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStrBtnApagarLayersPapel.Image = Global.mhCad.My.Resources.Resources.smartGroup
        Me.toolStrBtnApagarLayersPapel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStrBtnApagarLayersPapel.Name = "toolStrBtnApagarLayersPapel"
        Me.toolStrBtnApagarLayersPapel.Size = New System.Drawing.Size(23, 22)
        Me.toolStrBtnApagarLayersPapel.Text = "ToolStripButton1"
        Me.toolStrBtnApagarLayersPapel.ToolTipText = "Apagar/Encender layers en espacio papel. Este comando SOLO funciona dentro de un " &
    "VIEWPORT."
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrLayersBtnTipoLinea
        '
        Me.ToolStrLayersBtnTipoLinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrLayersBtnTipoLinea.Image = Global.mhCad.My.Resources.Resources.Ltypes
        Me.ToolStrLayersBtnTipoLinea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrLayersBtnTipoLinea.Name = "ToolStrLayersBtnTipoLinea"
        Me.ToolStrLayersBtnTipoLinea.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrLayersBtnTipoLinea.Tag = "btnTipoLinea"
        Me.ToolStrLayersBtnTipoLinea.Text = "ToolStripButton1"
        Me.ToolStrLayersBtnTipoLinea.ToolTipText = "Manejo de tipos de linea"
        '
        'ToolStrLayersCmbTipoLinea
        '
        Me.ToolStrLayersCmbTipoLinea.AutoToolTip = True
        Me.ToolStrLayersCmbTipoLinea.Name = "ToolStrLayersCmbTipoLinea"
        Me.ToolStrLayersCmbTipoLinea.Size = New System.Drawing.Size(121, 25)
        Me.ToolStrLayersCmbTipoLinea.Tag = "cmbTipoLinea"
        Me.ToolStrLayersCmbTipoLinea.ToolTipText = "Manejo de tipos de linea"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrLayersBtnEspesor
        '
        Me.ToolStrLayersBtnEspesor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrLayersBtnEspesor.Image = Global.mhCad.My.Resources.Resources.LWeigth
        Me.ToolStrLayersBtnEspesor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrLayersBtnEspesor.Name = "ToolStrLayersBtnEspesor"
        Me.ToolStrLayersBtnEspesor.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrLayersBtnEspesor.Tag = "btnEspesor"
        Me.ToolStrLayersBtnEspesor.Text = "ToolStripButton1"
        Me.ToolStrLayersBtnEspesor.ToolTipText = "Manejo de espesores"
        '
        'ToolStrLayersCmbEspesor
        '
        Me.ToolStrLayersCmbEspesor.Name = "ToolStrLayersCmbEspesor"
        Me.ToolStrLayersCmbEspesor.Size = New System.Drawing.Size(121, 25)
        Me.ToolStrLayersCmbEspesor.Tag = "cmbEspesores"
        Me.ToolStrLayersCmbEspesor.ToolTipText = "Manejo de espesores"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrLayersBtnColor
        '
        Me.ToolStrLayersBtnColor.BackColor = System.Drawing.Color.Red
        Me.ToolStrLayersBtnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStrLayersBtnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrLayersBtnColor.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrLayersBtnColor.Image = Global.mhCad.My.Resources.Resources.acad_punto
        Me.ToolStrLayersBtnColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrLayersBtnColor.Name = "ToolStrLayersBtnColor"
        Me.ToolStrLayersBtnColor.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrLayersBtnColor.Tag = "btnColores"
        Me.ToolStrLayersBtnColor.Text = "ToolStripButton1"
        Me.ToolStrLayersBtnColor.ToolTipText = "Manejo de colores"
        '
        'ToolStrLayersLblColor
        '
        Me.ToolStrLayersLblColor.Name = "ToolStrLayersLblColor"
        Me.ToolStrLayersLblColor.Size = New System.Drawing.Size(0, 22)
        Me.ToolStrLayersLblColor.Tag = "lblColores"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLayersBtnFondoLayout
        '
        Me.ToolStripLayersBtnFondoLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLayersBtnFondoLayout.Image = Global.mhCad.My.Resources.Resources.color_wheel
        Me.ToolStripLayersBtnFondoLayout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripLayersBtnFondoLayout.Name = "ToolStripLayersBtnFondoLayout"
        Me.ToolStripLayersBtnFondoLayout.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripLayersBtnFondoLayout.Tag = "fondoLayout"
        Me.ToolStripLayersBtnFondoLayout.Text = "ToolStripButton1"
        Me.ToolStripLayersBtnFondoLayout.ToolTipText = "Cambiar el color de fondo del Layout," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "en espacio papel y dentro de un viewport" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "(ventana)"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelID
        '
        Me.ToolStripLabelID.Name = "ToolStripLabelID"
        Me.ToolStripLabelID.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripLabelID.Text = "X,Y,Z: Sin selección"
        Me.ToolStripLabelID.ToolTipText = "Coordenadas del punto seleccionado con el comando ""ID"""
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button1)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.VdF)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1073, 428)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'ToolStripContainer1.LeftToolStripPanel
        '
        Me.ToolStripContainer1.LeftToolStripPanel.Controls.Add(Me.ToolStrVistas)
        Me.ToolStripContainer1.LeftToolStripPanel.Controls.Add(Me.ToolStrDibujar)
        Me.ToolStripContainer1.LeftToolStripPanel.Controls.Add(Me.ToolStrEditar2)
        Me.ToolStripContainer1.LeftToolStripPanel.Controls.Add(Me.ToolStrEditar)
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        '
        'ToolStripContainer1.RightToolStripPanel
        '
        Me.ToolStripContainer1.RightToolStripPanel.Controls.Add(Me.ToolStrip3D)
        Me.ToolStripContainer1.RightToolStripPanel.Controls.Add(Me.ToolStrOsnap)
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1145, 552)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStrGeneral)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrViewports)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrCotas)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrLayers)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(309, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Az. y Rbo linea"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNuevo, Me.tsLbIdTrabajo, Me.ToolStripSeparator36, Me.tsBorrarEntidad, Me.tsEstilos, Me.tsMoverParcela, Me.ToolStripSeparator35, Me.tsdMacizo, Me.tsdMacizoLinderos, Me.tsdDistanciaEsquina, Me.tsdParcela, Me.tsdParcelaLindera, Me.tsMuros, Me.tsdSimbolos, Me.tsCroquis, Me.tsGuardarCambios})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(309, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(522, 23)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsNuevo
        '
        Me.tsNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsNuevo.Image = CType(resources.GetObject("tsNuevo.Image"), System.Drawing.Image)
        Me.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNuevo.Margin = New System.Windows.Forms.Padding(15, 1, 0, 2)
        Me.tsNuevo.Name = "tsNuevo"
        Me.tsNuevo.Size = New System.Drawing.Size(23, 20)
        Me.tsNuevo.Text = "Trabajo nuevo"
        Me.tsNuevo.Visible = False
        '
        'tsLbIdTrabajo
        '
        Me.tsLbIdTrabajo.Margin = New System.Windows.Forms.Padding(0, 4, 10, 2)
        Me.tsLbIdTrabajo.Name = "tsLbIdTrabajo"
        Me.tsLbIdTrabajo.Size = New System.Drawing.Size(92, 15)
        Me.tsLbIdTrabajo.Tag = "Nada"
        Me.tsLbIdTrabajo.Text = "Id trabajo activo"
        Me.tsLbIdTrabajo.ToolTipText = "Identificador del trabajo activo."
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        Me.ToolStripSeparator36.Size = New System.Drawing.Size(6, 23)
        '
        'tsBorrarEntidad
        '
        Me.tsBorrarEntidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBorrarEntidad.Image = CType(resources.GetObject("tsBorrarEntidad.Image"), System.Drawing.Image)
        Me.tsBorrarEntidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBorrarEntidad.Name = "tsBorrarEntidad"
        Me.tsBorrarEntidad.Size = New System.Drawing.Size(23, 20)
        Me.tsBorrarEntidad.Text = "ToolStripButton1"
        Me.tsBorrarEntidad.ToolTipText = "Borrar entidad"
        '
        'tsEstilos
        '
        Me.tsEstilos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEstilos.Image = Global.mhCad.My.Resources.Resources.acad_texto
        Me.tsEstilos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEstilos.Name = "tsEstilos"
        Me.tsEstilos.Size = New System.Drawing.Size(23, 20)
        Me.tsEstilos.Text = "ToolStripButton1"
        Me.tsEstilos.ToolTipText = "Editar estilos de textos"
        '
        'tsMoverParcela
        '
        Me.tsMoverParcela.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsMoverParcela.Image = Global.mhCad.My.Resources.Resources.et_mocoro24
        Me.tsMoverParcela.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsMoverParcela.Name = "tsMoverParcela"
        Me.tsMoverParcela.Size = New System.Drawing.Size(23, 20)
        Me.tsMoverParcela.Text = "ToolStripButton1"
        Me.tsMoverParcela.ToolTipText = "Ubicar parcela."
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Margin = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(6, 23)
        '
        'tsdMacizo
        '
        Me.tsdMacizo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsdMacizo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.definirMacizoPorPuntos, Me.definirMacizoPorPolilinea})
        Me.tsdMacizo.Enabled = False
        Me.tsdMacizo.Image = CType(resources.GetObject("tsdMacizo.Image"), System.Drawing.Image)
        Me.tsdMacizo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdMacizo.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.tsdMacizo.Name = "tsdMacizo"
        Me.tsdMacizo.Size = New System.Drawing.Size(29, 20)
        Me.tsdMacizo.Text = "Macizo"
        Me.tsdMacizo.ToolTipText = "Incorporar Macizo al plano digital"
        '
        'definirMacizoPorPuntos
        '
        Me.definirMacizoPorPuntos.Name = "definirMacizoPorPuntos"
        Me.definirMacizoPorPuntos.Size = New System.Drawing.Size(277, 22)
        Me.definirMacizoPorPuntos.Text = "Definir Macizo seleccionando puntos"
        '
        'definirMacizoPorPolilinea
        '
        Me.definirMacizoPorPolilinea.Name = "definirMacizoPorPolilinea"
        Me.definirMacizoPorPolilinea.Size = New System.Drawing.Size(277, 22)
        Me.definirMacizoPorPolilinea.Text = "Definir Macizo seleccionando polilinea"
        '
        'tsdMacizoLinderos
        '
        Me.tsdMacizoLinderos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsdMacizoLinderos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem, Me.DefinirMacizoSeleccionandoPolilineaToolStripMenuItem})
        Me.tsdMacizoLinderos.Enabled = False
        Me.tsdMacizoLinderos.Image = CType(resources.GetObject("tsdMacizoLinderos.Image"), System.Drawing.Image)
        Me.tsdMacizoLinderos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdMacizoLinderos.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.tsdMacizoLinderos.Name = "tsdMacizoLinderos"
        Me.tsdMacizoLinderos.Size = New System.Drawing.Size(29, 20)
        Me.tsdMacizoLinderos.Text = "Macizo linderos"
        Me.tsdMacizoLinderos.ToolTipText = "Incorporar Macizo linderos al plano digital"
        '
        'DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem
        '
        Me.DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem.Name = "DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem"
        Me.DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem.Size = New System.Drawing.Size(322, 22)
        Me.DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem.Text = "Definir Macizo linderos seleccionando puntos"
        '
        'DefinirMacizoSeleccionandoPolilineaToolStripMenuItem
        '
        Me.DefinirMacizoSeleccionandoPolilineaToolStripMenuItem.Name = "DefinirMacizoSeleccionandoPolilineaToolStripMenuItem"
        Me.DefinirMacizoSeleccionandoPolilineaToolStripMenuItem.Size = New System.Drawing.Size(322, 22)
        Me.DefinirMacizoSeleccionandoPolilineaToolStripMenuItem.Text = "Definir Macizo linderos seleccionando polilinea"
        '
        'tsdDistanciaEsquina
        '
        Me.tsdDistanciaEsquina.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsdDistanciaEsquina.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdDefinirPorPuntos, Me.tsdDefinirPorPolilinea})
        Me.tsdDistanciaEsquina.Enabled = False
        Me.tsdDistanciaEsquina.Image = CType(resources.GetObject("tsdDistanciaEsquina.Image"), System.Drawing.Image)
        Me.tsdDistanciaEsquina.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdDistanciaEsquina.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.tsdDistanciaEsquina.Name = "tsdDistanciaEsquina"
        Me.tsdDistanciaEsquina.Size = New System.Drawing.Size(29, 20)
        Me.tsdDistanciaEsquina.Text = "Distancia a esquina"
        Me.tsdDistanciaEsquina.ToolTipText = "Incorporar Distancia a esquina al plano digital"
        '
        'tsdDefinirPorPuntos
        '
        Me.tsdDefinirPorPuntos.Name = "tsdDefinirPorPuntos"
        Me.tsdDefinirPorPuntos.Size = New System.Drawing.Size(298, 22)
        Me.tsdDefinirPorPuntos.Text = "Definir distancia a esquina por puntos"
        '
        'tsdDefinirPorPolilinea
        '
        Me.tsdDefinirPorPolilinea.Name = "tsdDefinirPorPolilinea"
        Me.tsdDefinirPorPolilinea.Size = New System.Drawing.Size(298, 22)
        Me.tsdDefinirPorPolilinea.Text = "Definir distancia a esquina selecc. polilinea"
        '
        'tsdParcela
        '
        Me.tsdParcela.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsdParcela.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdDefinirPlPorPuntos, Me.ToolStripMenuItem2, Me.CroquisDatosToolStripMenuItem})
        Me.tsdParcela.Enabled = False
        Me.tsdParcela.Image = CType(resources.GetObject("tsdParcela.Image"), System.Drawing.Image)
        Me.tsdParcela.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdParcela.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.tsdParcela.Name = "tsdParcela"
        Me.tsdParcela.Size = New System.Drawing.Size(29, 20)
        Me.tsdParcela.Text = "Parcela"
        Me.tsdParcela.ToolTipText = "Incorporar Parcela al plano digital"
        '
        'tsdDefinirPlPorPuntos
        '
        Me.tsdDefinirPlPorPuntos.Name = "tsdDefinirPlPorPuntos"
        Me.tsdDefinirPlPorPuntos.Size = New System.Drawing.Size(279, 22)
        Me.tsdDefinirPlPorPuntos.Text = "Definir parcela PRINCIPAL por puntos"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(279, 22)
        Me.ToolStripMenuItem2.Text = "Definir parcela PRINCIPAL por polilinea"
        '
        'CroquisDatosToolStripMenuItem
        '
        Me.CroquisDatosToolStripMenuItem.Name = "CroquisDatosToolStripMenuItem"
        Me.CroquisDatosToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.CroquisDatosToolStripMenuItem.Text = "Croquis: Datos"
        '
        'tsdParcelaLindera
        '
        Me.tsdParcelaLindera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsdParcelaLindera.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefinirParcelaLinderaPorPuntosToolStripMenuItem, Me.DefinirParcelaLinderaPorPolilineaToolStripMenuItem})
        Me.tsdParcelaLindera.Enabled = False
        Me.tsdParcelaLindera.Image = Global.mhCad.My.Resources.Resources.color_2
        Me.tsdParcelaLindera.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdParcelaLindera.Name = "tsdParcelaLindera"
        Me.tsdParcelaLindera.Size = New System.Drawing.Size(29, 20)
        Me.tsdParcelaLindera.Text = "ToolStripDropDownButton1"
        Me.tsdParcelaLindera.ToolTipText = "Incorporar parcela lindera al plano digital"
        '
        'DefinirParcelaLinderaPorPuntosToolStripMenuItem
        '
        Me.DefinirParcelaLinderaPorPuntosToolStripMenuItem.Name = "DefinirParcelaLinderaPorPuntosToolStripMenuItem"
        Me.DefinirParcelaLinderaPorPuntosToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.DefinirParcelaLinderaPorPuntosToolStripMenuItem.Text = "Definir parcela lindera por puntos"
        '
        'DefinirParcelaLinderaPorPolilineaToolStripMenuItem
        '
        Me.DefinirParcelaLinderaPorPolilineaToolStripMenuItem.Name = "DefinirParcelaLinderaPorPolilineaToolStripMenuItem"
        Me.DefinirParcelaLinderaPorPolilineaToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.DefinirParcelaLinderaPorPolilineaToolStripMenuItem.Text = "Definir parcela lindera por polilinea"
        '
        'tsMuros
        '
        Me.tsMuros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsMuros.Enabled = False
        Me.tsMuros.Image = Global.mhCad.My.Resources.Resources.muros
        Me.tsMuros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsMuros.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.tsMuros.Name = "tsMuros"
        Me.tsMuros.Size = New System.Drawing.Size(23, 20)
        Me.tsMuros.Text = "ToolStripButton1"
        Me.tsMuros.ToolTipText = "Definir muros"
        '
        'tsdSimbolos
        '
        Me.tsdSimbolos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsdSimbolos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdNorteUno})
        Me.tsdSimbolos.Enabled = False
        Me.tsdSimbolos.Image = Global.mhCad.My.Resources.Resources.et_clipit16
        Me.tsdSimbolos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdSimbolos.Margin = New System.Windows.Forms.Padding(10, 1, 5, 2)
        Me.tsdSimbolos.Name = "tsdSimbolos"
        Me.tsdSimbolos.Size = New System.Drawing.Size(29, 20)
        Me.tsdSimbolos.Text = "ToolStripDropDownButton1"
        Me.tsdSimbolos.ToolTipText = "Insertar un simbolo"
        '
        'tsdNorteUno
        '
        Me.tsdNorteUno.Image = Global.mhCad.My.Resources.Resources.edSelect_feature_editing_OVER
        Me.tsdNorteUno.Name = "tsdNorteUno"
        Me.tsdNorteUno.Size = New System.Drawing.Size(113, 22)
        Me.tsdNorteUno.Text = "Norte 1"
        '
        'tsCroquis
        '
        Me.tsCroquis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsCroquis.Image = Global.mhCad.My.Resources.Resources.HatchV
        Me.tsCroquis.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCroquis.Name = "tsCroquis"
        Me.tsCroquis.Size = New System.Drawing.Size(23, 20)
        Me.tsCroquis.Text = "ToolStripButton1"
        Me.tsCroquis.ToolTipText = "Generar imagen para cèdula."
        '
        'tsGuardarCambios
        '
        Me.tsGuardarCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsGuardarCambios.Image = Global.mhCad.My.Resources.Resources.Diskete
        Me.tsGuardarCambios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGuardarCambios.Name = "tsGuardarCambios"
        Me.tsGuardarCambios.Size = New System.Drawing.Size(23, 20)
        Me.tsGuardarCambios.Text = "ToolStripButton1"
        Me.tsGuardarCambios.ToolTipText = "Guardar cambios en textos (posiciòn y contenido. NO estilo). Solo para Parcela Ve" &
    "ctorial."
        '
        'VdF
        '
        Me.VdF.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.VdF.BackColor = System.Drawing.SystemColors.Control
        Me.VdF.Cursor = Global.mhCad.My.MySettings.Default.vdfCursor
        Me.VdF.DataBindings.Add(New System.Windows.Forms.Binding("Cursor", Global.mhCad.My.MySettings.Default, "vdfCursor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.VdF.DisplayPolarCoord = False
        Me.VdF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HelpProvider1.SetHelpString(Me.VdF, "")
        Me.VdF.HistoryLines = CType(3UI, UInteger)
        Me.VdF.Location = New System.Drawing.Point(0, 0)
        Me.VdF.Name = "VdF"
        Me.VdF.PropertyGridWidth = CType(300UI, UInteger)
        Me.HelpProvider1.SetShowHelp(Me.VdF, True)
        Me.VdF.Size = New System.Drawing.Size(1073, 428)
        Me.VdF.TabIndex = 0
        '
        'ToolStrVistas
        '
        Me.ToolStrVistas.AllowItemReorder = True
        Me.ToolStrVistas.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrVistas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrPan, Me.ToolStrZoomExtension, Me.ToolStrZoomWindows, Me.ToolStrZoomPrevious, Me.ToolStrZoomReducir, Me.ToolStrZoomAmpliar})
        Me.ToolStrVistas.Location = New System.Drawing.Point(0, 3)
        Me.ToolStrVistas.Name = "ToolStrVistas"
        Me.ToolStrVistas.Size = New System.Drawing.Size(24, 149)
        Me.ToolStrVistas.TabIndex = 3
        '
        'ToolStrPan
        '
        Me.ToolStrPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrPan.Image = Global.mhCad.My.Resources.Resources.acad_pan
        Me.ToolStrPan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrPan.Name = "ToolStrPan"
        Me.ToolStrPan.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrPan.Tag = "Pan"
        Me.ToolStrPan.Text = "ToolStripButton1"
        Me.ToolStrPan.ToolTipText = "Pan (desplazamiento)"
        '
        'ToolStrZoomExtension
        '
        Me.ToolStrZoomExtension.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrZoomExtension.Image = Global.mhCad.My.Resources.Resources.acad_ZE
        Me.ToolStrZoomExtension.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrZoomExtension.Name = "ToolStrZoomExtension"
        Me.ToolStrZoomExtension.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrZoomExtension.Tag = "ZE"
        Me.ToolStrZoomExtension.Text = "ToolStripButton10"
        Me.ToolStrZoomExtension.ToolTipText = "Zoom Extensión (todo)"
        '
        'ToolStrZoomWindows
        '
        Me.ToolStrZoomWindows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrZoomWindows.Image = Global.mhCad.My.Resources.Resources.acad_ZW
        Me.ToolStrZoomWindows.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrZoomWindows.Name = "ToolStrZoomWindows"
        Me.ToolStrZoomWindows.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrZoomWindows.Tag = "ZW"
        Me.ToolStrZoomWindows.Text = "ToolStripButton10"
        Me.ToolStrZoomWindows.ToolTipText = "Zoom Ventana (Windows)"
        '
        'ToolStrZoomPrevious
        '
        Me.ToolStrZoomPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrZoomPrevious.Image = Global.mhCad.My.Resources.Resources.acad_ZP
        Me.ToolStrZoomPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrZoomPrevious.Name = "ToolStrZoomPrevious"
        Me.ToolStrZoomPrevious.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrZoomPrevious.Tag = "ZP"
        Me.ToolStrZoomPrevious.Text = "ToolStripButton1"
        Me.ToolStrZoomPrevious.ToolTipText = "Zoom Anterior"
        '
        'ToolStrZoomReducir
        '
        Me.ToolStrZoomReducir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrZoomReducir.Image = Global.mhCad.My.Resources.Resources.ZoomReducir
        Me.ToolStrZoomReducir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrZoomReducir.Name = "ToolStrZoomReducir"
        Me.ToolStrZoomReducir.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrZoomReducir.Tag = "Zreducir"
        Me.ToolStrZoomReducir.Text = "ToolStripButton1"
        Me.ToolStrZoomReducir.ToolTipText = "Zoom Reducir"
        '
        'ToolStrZoomAmpliar
        '
        Me.ToolStrZoomAmpliar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrZoomAmpliar.Image = Global.mhCad.My.Resources.Resources.ZoomAmpliar
        Me.ToolStrZoomAmpliar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrZoomAmpliar.Name = "ToolStrZoomAmpliar"
        Me.ToolStrZoomAmpliar.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrZoomAmpliar.Tag = "ZAmpliar"
        Me.ToolStrZoomAmpliar.Text = "ToolStripButton1"
        Me.ToolStrZoomAmpliar.ToolTipText = "Zoom Ampliar"
        '
        'ToolStrDibujar
        '
        Me.ToolStrDibujar.AllowItemReorder = True
        Me.ToolStrDibujar.Dock = System.Windows.Forms.DockStyle.None
        Me.HelpProvider1.SetHelpString(Me.ToolStrDibujar, "Texto de la toolbar de dibujar")
        Me.ToolStrDibujar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrDibujarLinea, Me.ToolStrDibujarPolilinea, Me.ToolStrDibujarRectang, Me.ToolStrDibujarArco, Me.ToolStrDibujarCirculo, Me.ToolStrDibujarElipse, Me.ToolStrDibujarPunto, Me.ToolStrDibujarTexto, Me.ToolStrDibujarHatch, Me.ToolStrDibujarInsert})
        Me.ToolStrDibujar.Location = New System.Drawing.Point(0, 152)
        Me.ToolStrDibujar.Name = "ToolStrDibujar"
        Me.HelpProvider1.SetShowHelp(Me.ToolStrDibujar, True)
        Me.ToolStrDibujar.Size = New System.Drawing.Size(24, 241)
        Me.ToolStrDibujar.TabIndex = 2
        '
        'ToolStrDibujarLinea
        '
        Me.ToolStrDibujarLinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarLinea.Image = Global.mhCad.My.Resources.Resources.acad_linea
        Me.ToolStrDibujarLinea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarLinea.Name = "ToolStrDibujarLinea"
        Me.ToolStrDibujarLinea.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarLinea.Tag = "linea"
        Me.ToolStrDibujarLinea.Text = "ToolStripButton1"
        Me.ToolStrDibujarLinea.ToolTipText = "Dibujar lineas"
        '
        'ToolStrDibujarPolilinea
        '
        Me.ToolStrDibujarPolilinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarPolilinea.Image = Global.mhCad.My.Resources.Resources.acad_poli
        Me.ToolStrDibujarPolilinea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarPolilinea.Name = "ToolStrDibujarPolilinea"
        Me.ToolStrDibujarPolilinea.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarPolilinea.Tag = "poli"
        Me.ToolStrDibujarPolilinea.Text = "ToolStripButton1"
        Me.ToolStrDibujarPolilinea.ToolTipText = "Dibujar polilineas"
        '
        'ToolStrDibujarRectang
        '
        Me.ToolStrDibujarRectang.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarRectang.Image = Global.mhCad.My.Resources.Resources.acad_rectang
        Me.ToolStrDibujarRectang.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarRectang.Name = "ToolStrDibujarRectang"
        Me.ToolStrDibujarRectang.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarRectang.Tag = "rectang"
        Me.ToolStrDibujarRectang.Text = "ToolStripButton1"
        Me.ToolStrDibujarRectang.ToolTipText = "Dibujar rectangulo por los dos vertices opuestos."
        '
        'ToolStrDibujarArco
        '
        Me.ToolStrDibujarArco.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarArco.Image = Global.mhCad.My.Resources.Resources.acad_arco
        Me.ToolStrDibujarArco.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarArco.Name = "ToolStrDibujarArco"
        Me.ToolStrDibujarArco.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarArco.Tag = "arco"
        Me.ToolStrDibujarArco.Text = "ToolStripButton1"
        Me.ToolStrDibujarArco.ToolTipText = "Dibujar un arco ingresando punto central, radio, ángulo de comienzo y ángulo fina" &
    "l."
        '
        'ToolStrDibujarCirculo
        '
        Me.ToolStrDibujarCirculo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarCirculo.Image = Global.mhCad.My.Resources.Resources.acad_circulo
        Me.ToolStrDibujarCirculo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarCirculo.Name = "ToolStrDibujarCirculo"
        Me.ToolStrDibujarCirculo.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarCirculo.Tag = "circulo"
        Me.ToolStrDibujarCirculo.Text = "ToolStripButton1"
        Me.ToolStrDibujarCirculo.ToolTipText = "Dibujar un círculo ingresando centro y radio."
        '
        'ToolStrDibujarElipse
        '
        Me.ToolStrDibujarElipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarElipse.Image = Global.mhCad.My.Resources.Resources.acad_elipse
        Me.ToolStrDibujarElipse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarElipse.Name = "ToolStrDibujarElipse"
        Me.ToolStrDibujarElipse.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarElipse.Tag = "elipse"
        Me.ToolStrDibujarElipse.Text = "ToolStripButton1"
        Me.ToolStrDibujarElipse.ToolTipText = "Dibujar una elipse ingresando el centro, punto extremo del semieje mayor, punto e" &
    "xtremo del semieje menor."
        '
        'ToolStrDibujarPunto
        '
        Me.ToolStrDibujarPunto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarPunto.Image = Global.mhCad.My.Resources.Resources.acad_punto
        Me.ToolStrDibujarPunto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarPunto.Name = "ToolStrDibujarPunto"
        Me.ToolStrDibujarPunto.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarPunto.Tag = "punto"
        Me.ToolStrDibujarPunto.Text = "ToolStripButton1"
        Me.ToolStrDibujarPunto.ToolTipText = "Dibujar un punto."
        '
        'ToolStrDibujarTexto
        '
        Me.ToolStrDibujarTexto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarTexto.Image = Global.mhCad.My.Resources.Resources.acad_texto
        Me.ToolStrDibujarTexto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarTexto.Name = "ToolStrDibujarTexto"
        Me.ToolStrDibujarTexto.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarTexto.Tag = "texto"
        Me.ToolStrDibujarTexto.Text = "ToolStripButton1"
        Me.ToolStrDibujarTexto.ToolTipText = "Dibujar texto"
        '
        'ToolStrDibujarHatch
        '
        Me.ToolStrDibujarHatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarHatch.Image = Global.mhCad.My.Resources.Resources.acad_hatch
        Me.ToolStrDibujarHatch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarHatch.Name = "ToolStrDibujarHatch"
        Me.ToolStrDibujarHatch.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarHatch.Tag = "hatch"
        Me.ToolStrDibujarHatch.Text = "ToolStripButton1"
        Me.ToolStrDibujarHatch.ToolTipText = "Dibujar un tramado (Hatch)"
        '
        'ToolStrDibujarInsert
        '
        Me.ToolStrDibujarInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDibujarInsert.Image = Global.mhCad.My.Resources.Resources.et_ncopy16
        Me.ToolStrDibujarInsert.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDibujarInsert.Name = "ToolStrDibujarInsert"
        Me.ToolStrDibujarInsert.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrDibujarInsert.Tag = "Insert"
        Me.ToolStrDibujarInsert.Text = "ToolStripButton1"
        Me.ToolStrDibujarInsert.ToolTipText = "Insertar un bloque"
        '
        'ToolStrEditar2
        '
        Me.ToolStrEditar2.AllowItemReorder = True
        Me.ToolStrEditar2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrEditar2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrEditarDeshacer, Me.ToolStrEditarRehacer, Me.ToolStrEditarBorrar, Me.ToolStrEditarAtt, Me.ToolStrEscalaViewport})
        Me.ToolStrEditar2.Location = New System.Drawing.Point(24, 336)
        Me.ToolStrEditar2.Name = "ToolStrEditar2"
        Me.ToolStrEditar2.Size = New System.Drawing.Size(24, 92)
        Me.ToolStrEditar2.TabIndex = 0
        '
        'ToolStrEditarDeshacer
        '
        Me.ToolStrEditarDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarDeshacer.Image = Global.mhCad.My.Resources.Resources.acad_undo
        Me.ToolStrEditarDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarDeshacer.Name = "ToolStrEditarDeshacer"
        Me.ToolStrEditarDeshacer.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarDeshacer.Tag = "Undo"
        Me.ToolStrEditarDeshacer.Text = "ToolStripButton1"
        Me.ToolStrEditarDeshacer.ToolTipText = "Deshacer (Undo)"
        '
        'ToolStrEditarRehacer
        '
        Me.ToolStrEditarRehacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarRehacer.Image = Global.mhCad.My.Resources.Resources.acad_redo
        Me.ToolStrEditarRehacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarRehacer.Name = "ToolStrEditarRehacer"
        Me.ToolStrEditarRehacer.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarRehacer.Tag = "Redo"
        Me.ToolStrEditarRehacer.Text = "ToolStripButton10"
        Me.ToolStrEditarRehacer.ToolTipText = "Rehacer (Redo)"
        '
        'ToolStrEditarBorrar
        '
        Me.ToolStrEditarBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarBorrar.Image = Global.mhCad.My.Resources.Resources.acad_borrar
        Me.ToolStrEditarBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarBorrar.Name = "ToolStrEditarBorrar"
        Me.ToolStrEditarBorrar.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarBorrar.Tag = "Erase"
        Me.ToolStrEditarBorrar.Text = "ToolStripButton10"
        Me.ToolStrEditarBorrar.ToolTipText = "Borrar (Erase)"
        '
        'ToolStrEditarAtt
        '
        Me.ToolStrEditarAtt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarAtt.Image = Global.mhCad.My.Resources.Resources.et_GATTE24
        Me.ToolStrEditarAtt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarAtt.Name = "ToolStrEditarAtt"
        Me.ToolStrEditarAtt.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarAtt.Tag = "atributos"
        Me.ToolStrEditarAtt.Text = "ToolStripButton1"
        Me.ToolStrEditarAtt.ToolTipText = "Edición de atributos (Seleccionar un bloque)"
        '
        'ToolStrEscalaViewport
        '
        Me.ToolStrEscalaViewport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEscalaViewport.Image = Global.mhCad.My.Resources.Resources.ScaleV
        Me.ToolStrEscalaViewport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEscalaViewport.Name = "ToolStrEscalaViewport"
        Me.ToolStrEscalaViewport.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEscalaViewport.Tag = "escalasVp"
        Me.ToolStrEscalaViewport.Text = "ToolStripButton1"
        Me.ToolStrEscalaViewport.ToolTipText = "Ingresar escala en ventana (View Port)"
        '
        'ToolStrEditar
        '
        Me.ToolStrEditar.AllowItemReorder = True
        Me.ToolStrEditar.Dock = System.Windows.Forms.DockStyle.None
        Me.HelpProvider1.SetHelpString(Me.ToolStrEditar, "Texto de la toolbar editar")
        Me.ToolStrEditar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrEditarPropiedades, Me.ToolStrEditarCopy, Me.ToolStrEditarMirror, Me.ToolStrEditarMove, Me.ToolStrEditarRotate, Me.ToolStrEditarScale, Me.ToolStrEditarTrim, Me.ToolStrEditarExtend, Me.ToolStrEditarExplode, Me.ToolStrEditarFilletR0, Me.ToolStrEditarFillet, Me.ToolStrEditarOffset, Me.ToolStrEditarBreak, Me.ToolStrEditarAlinear})
        Me.ToolStrEditar.Location = New System.Drawing.Point(24, 3)
        Me.ToolStrEditar.Name = "ToolStrEditar"
        Me.HelpProvider1.SetShowHelp(Me.ToolStrEditar, True)
        Me.ToolStrEditar.Size = New System.Drawing.Size(24, 333)
        Me.ToolStrEditar.TabIndex = 1
        '
        'ToolStrEditarPropiedades
        '
        Me.ToolStrEditarPropiedades.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarPropiedades.Image = Global.mhCad.My.Resources.Resources.acad_prop
        Me.ToolStrEditarPropiedades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarPropiedades.Name = "ToolStrEditarPropiedades"
        Me.ToolStrEditarPropiedades.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarPropiedades.Tag = "propiedades"
        Me.ToolStrEditarPropiedades.Text = "ToolStripButton1"
        Me.ToolStrEditarPropiedades.ToolTipText = "Encender/apagar pantalla propiedades"
        '
        'ToolStrEditarCopy
        '
        Me.ToolStrEditarCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarCopy.Image = Global.mhCad.My.Resources.Resources.acad_copy
        Me.ToolStrEditarCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarCopy.Name = "ToolStrEditarCopy"
        Me.ToolStrEditarCopy.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarCopy.Tag = "copy"
        Me.ToolStrEditarCopy.Text = "ToolStripButton1"
        Me.ToolStrEditarCopy.ToolTipText = "Copiar (copy)"
        '
        'ToolStrEditarMirror
        '
        Me.ToolStrEditarMirror.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarMirror.Image = Global.mhCad.My.Resources.Resources.acad_mirror
        Me.ToolStrEditarMirror.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarMirror.Name = "ToolStrEditarMirror"
        Me.ToolStrEditarMirror.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarMirror.Tag = "mirror"
        Me.ToolStrEditarMirror.Text = "ToolStripButton1"
        Me.ToolStrEditarMirror.ToolTipText = "Simetria (mirror)"
        '
        'ToolStrEditarMove
        '
        Me.ToolStrEditarMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarMove.Image = Global.mhCad.My.Resources.Resources.acad_mover
        Me.ToolStrEditarMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarMove.Name = "ToolStrEditarMove"
        Me.ToolStrEditarMove.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarMove.Tag = "move"
        Me.ToolStrEditarMove.Text = "ToolStripButton1"
        Me.ToolStrEditarMove.ToolTipText = "Mover (move)"
        '
        'ToolStrEditarRotate
        '
        Me.ToolStrEditarRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarRotate.Image = Global.mhCad.My.Resources.Resources.acad_rotar
        Me.ToolStrEditarRotate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarRotate.Name = "ToolStrEditarRotate"
        Me.ToolStrEditarRotate.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarRotate.Tag = "rotate"
        Me.ToolStrEditarRotate.Text = "ToolStripButton1"
        Me.ToolStrEditarRotate.ToolTipText = "Rotar (rotate)"
        '
        'ToolStrEditarScale
        '
        Me.ToolStrEditarScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarScale.Image = Global.mhCad.My.Resources.Resources.acad_scale
        Me.ToolStrEditarScale.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarScale.Name = "ToolStrEditarScale"
        Me.ToolStrEditarScale.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarScale.Tag = "scale"
        Me.ToolStrEditarScale.Text = "ToolStripButton1"
        Me.ToolStrEditarScale.ToolTipText = "Cambiar escala (Scale)"
        '
        'ToolStrEditarTrim
        '
        Me.ToolStrEditarTrim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarTrim.Image = Global.mhCad.My.Resources.Resources.acad_trim
        Me.ToolStrEditarTrim.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarTrim.Name = "ToolStrEditarTrim"
        Me.ToolStrEditarTrim.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarTrim.Tag = "trim"
        Me.ToolStrEditarTrim.Text = "ToolStripButton1"
        Me.ToolStrEditarTrim.ToolTipText = "Recortar (Trim)"
        '
        'ToolStrEditarExtend
        '
        Me.ToolStrEditarExtend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarExtend.Image = Global.mhCad.My.Resources.Resources.acad_extend
        Me.ToolStrEditarExtend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarExtend.Name = "ToolStrEditarExtend"
        Me.ToolStrEditarExtend.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarExtend.Tag = "extend"
        Me.ToolStrEditarExtend.Text = "ToolStripButton1"
        Me.ToolStrEditarExtend.ToolTipText = "Estirar o extender (extend)"
        '
        'ToolStrEditarExplode
        '
        Me.ToolStrEditarExplode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarExplode.Image = Global.mhCad.My.Resources.Resources.acad_explode
        Me.ToolStrEditarExplode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarExplode.Name = "ToolStrEditarExplode"
        Me.ToolStrEditarExplode.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarExplode.Tag = "explode"
        Me.ToolStrEditarExplode.Text = "ToolStripButton1"
        Me.ToolStrEditarExplode.ToolTipText = "Desarmar bloques (explode)"
        '
        'ToolStrEditarFilletR0
        '
        Me.ToolStrEditarFilletR0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarFilletR0.Image = Global.mhCad.My.Resources.Resources.FilletV
        Me.ToolStrEditarFilletR0.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarFilletR0.Name = "ToolStrEditarFilletR0"
        Me.ToolStrEditarFilletR0.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarFilletR0.Tag = "filletr0"
        Me.ToolStrEditarFilletR0.Text = "ToolStripButton1"
        Me.ToolStrEditarFilletR0.ToolTipText = "Empalme (fillet) con radio cero"
        '
        'ToolStrEditarFillet
        '
        Me.ToolStrEditarFillet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarFillet.Image = Global.mhCad.My.Resources.Resources.acad_fillet
        Me.ToolStrEditarFillet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarFillet.Name = "ToolStrEditarFillet"
        Me.ToolStrEditarFillet.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarFillet.Tag = "fillet"
        Me.ToolStrEditarFillet.Text = "ToolStripButton1"
        Me.ToolStrEditarFillet.ToolTipText = "Empalme (fillet) con radio distinto de cero"
        '
        'ToolStrEditarOffset
        '
        Me.ToolStrEditarOffset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarOffset.Image = Global.mhCad.My.Resources.Resources.acad_offset
        Me.ToolStrEditarOffset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarOffset.Name = "ToolStrEditarOffset"
        Me.ToolStrEditarOffset.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarOffset.Tag = "offset"
        Me.ToolStrEditarOffset.Text = "ToolStripButton1"
        Me.ToolStrEditarOffset.ToolTipText = "Equidistancia (offset)"
        '
        'ToolStrEditarBreak
        '
        Me.ToolStrEditarBreak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarBreak.Image = Global.mhCad.My.Resources.Resources.acad_break
        Me.ToolStrEditarBreak.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarBreak.Name = "ToolStrEditarBreak"
        Me.ToolStrEditarBreak.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarBreak.Tag = "break"
        Me.ToolStrEditarBreak.Text = "ToolStripButton1"
        Me.ToolStrEditarBreak.ToolTipText = "Cortar (Break)"
        '
        'ToolStrEditarAlinear
        '
        Me.ToolStrEditarAlinear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEditarAlinear.Image = Global.mhCad.My.Resources.Resources.acad_alinear
        Me.ToolStrEditarAlinear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEditarAlinear.Name = "ToolStrEditarAlinear"
        Me.ToolStrEditarAlinear.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrEditarAlinear.Tag = "alinear"
        Me.ToolStrEditarAlinear.Text = "ToolStripButton1"
        Me.ToolStrEditarAlinear.ToolTipText = "Alinear (Align)"
        '
        'ToolStrip3D
        '
        Me.ToolStrip3D.AllowItemReorder = True
        Me.ToolStrip3D.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip3D.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtn3Drotacion, Me.tsbtn3Dtop, Me.tsbtn3Dbottom, Me.tsbtn3Dleft, Me.tsbtn3Dright, Me.tsbtn3Dfront, Me.tsbtn3Dback, Me.tsbtn3Dne, Me.tsbtn3Dnw, Me.tsbtn3Dse, Me.tsbtn3Dsw})
        Me.ToolStrip3D.Location = New System.Drawing.Point(0, 267)
        Me.ToolStrip3D.Name = "ToolStrip3D"
        Me.ToolStrip3D.Size = New System.Drawing.Size(24, 161)
        Me.ToolStrip3D.TabIndex = 6
        '
        'tsbtn3Drotacion
        '
        Me.tsbtn3Drotacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Drotacion.Image = CType(resources.GetObject("tsbtn3Drotacion.Image"), System.Drawing.Image)
        Me.tsbtn3Drotacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Drotacion.Name = "tsbtn3Drotacion"
        Me.tsbtn3Drotacion.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Drotacion.Tag = "3Dgirar"
        Me.tsbtn3Drotacion.Text = "ToolStripButton1"
        Me.tsbtn3Drotacion.ToolTipText = "Girar en 3D"
        '
        'tsbtn3Dtop
        '
        Me.tsbtn3Dtop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dtop.Image = CType(resources.GetObject("tsbtn3Dtop.Image"), System.Drawing.Image)
        Me.tsbtn3Dtop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dtop.Name = "tsbtn3Dtop"
        Me.tsbtn3Dtop.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dtop.Tag = "3Dtop"
        Me.tsbtn3Dtop.Text = "ToolStripButton2"
        Me.tsbtn3Dtop.ToolTipText = "Vista en planta, superior o normal."
        '
        'tsbtn3Dbottom
        '
        Me.tsbtn3Dbottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dbottom.Image = CType(resources.GetObject("tsbtn3Dbottom.Image"), System.Drawing.Image)
        Me.tsbtn3Dbottom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dbottom.Name = "tsbtn3Dbottom"
        Me.tsbtn3Dbottom.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dbottom.Tag = "3Dbottom"
        Me.tsbtn3Dbottom.Text = "ToolStripButton3"
        Me.tsbtn3Dbottom.ToolTipText = "Vista inferior"
        '
        'tsbtn3Dleft
        '
        Me.tsbtn3Dleft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dleft.Image = CType(resources.GetObject("tsbtn3Dleft.Image"), System.Drawing.Image)
        Me.tsbtn3Dleft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dleft.Name = "tsbtn3Dleft"
        Me.tsbtn3Dleft.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dleft.Tag = "3Dleft"
        Me.tsbtn3Dleft.Text = "ToolStripButton4"
        Me.tsbtn3Dleft.ToolTipText = "Vista izquierda"
        '
        'tsbtn3Dright
        '
        Me.tsbtn3Dright.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dright.Image = CType(resources.GetObject("tsbtn3Dright.Image"), System.Drawing.Image)
        Me.tsbtn3Dright.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dright.Name = "tsbtn3Dright"
        Me.tsbtn3Dright.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dright.Tag = "3Dright"
        Me.tsbtn3Dright.Text = "ToolStripButton1"
        Me.tsbtn3Dright.ToolTipText = "Vista derecha"
        '
        'tsbtn3Dfront
        '
        Me.tsbtn3Dfront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dfront.Image = CType(resources.GetObject("tsbtn3Dfront.Image"), System.Drawing.Image)
        Me.tsbtn3Dfront.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dfront.Name = "tsbtn3Dfront"
        Me.tsbtn3Dfront.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dfront.Tag = "3Dfront"
        Me.tsbtn3Dfront.Text = "ToolStripButton1"
        Me.tsbtn3Dfront.ToolTipText = "Vista de frente"
        '
        'tsbtn3Dback
        '
        Me.tsbtn3Dback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dback.Image = CType(resources.GetObject("tsbtn3Dback.Image"), System.Drawing.Image)
        Me.tsbtn3Dback.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dback.Name = "tsbtn3Dback"
        Me.tsbtn3Dback.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dback.Tag = "3Dback"
        Me.tsbtn3Dback.Text = "ToolStripButton1"
        Me.tsbtn3Dback.ToolTipText = "Vista posterior"
        '
        'tsbtn3Dne
        '
        Me.tsbtn3Dne.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dne.Image = CType(resources.GetObject("tsbtn3Dne.Image"), System.Drawing.Image)
        Me.tsbtn3Dne.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dne.Name = "tsbtn3Dne"
        Me.tsbtn3Dne.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dne.Tag = "3Dne"
        Me.tsbtn3Dne.Text = "ToolStripButton1"
        Me.tsbtn3Dne.ToolTipText = "Vista noreste"
        '
        'tsbtn3Dnw
        '
        Me.tsbtn3Dnw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dnw.Image = CType(resources.GetObject("tsbtn3Dnw.Image"), System.Drawing.Image)
        Me.tsbtn3Dnw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dnw.Name = "tsbtn3Dnw"
        Me.tsbtn3Dnw.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dnw.Tag = "3Dnw"
        Me.tsbtn3Dnw.Text = "ToolStripButton1"
        Me.tsbtn3Dnw.ToolTipText = "Vista noroeste"
        '
        'tsbtn3Dse
        '
        Me.tsbtn3Dse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dse.Image = CType(resources.GetObject("tsbtn3Dse.Image"), System.Drawing.Image)
        Me.tsbtn3Dse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dse.Name = "tsbtn3Dse"
        Me.tsbtn3Dse.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dse.Tag = "3Dse"
        Me.tsbtn3Dse.Text = "ToolStripButton1"
        Me.tsbtn3Dse.ToolTipText = "Vista sureste"
        '
        'tsbtn3Dsw
        '
        Me.tsbtn3Dsw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtn3Dsw.Image = CType(resources.GetObject("tsbtn3Dsw.Image"), System.Drawing.Image)
        Me.tsbtn3Dsw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn3Dsw.Name = "tsbtn3Dsw"
        Me.tsbtn3Dsw.Size = New System.Drawing.Size(22, 20)
        Me.tsbtn3Dsw.Tag = "3Dsw"
        Me.tsbtn3Dsw.Text = "ToolStripButton1"
        Me.tsbtn3Dsw.ToolTipText = "Vista suroeste"
        '
        'ToolStrOsnap
        '
        Me.ToolStrOsnap.AllowItemReorder = True
        Me.ToolStrOsnap.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrOsnap.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrOsnapEnd, Me.ToolStrOsnapMid, Me.ToolStrOsnapCen, Me.ToolStrOsnapInt, Me.ToolStrOsnapPer, Me.ToolStrOsnapNea, Me.ToolStrOsnapApa, Me.ToolStrOsnapNod, Me.ToolStrOsnapNon, Me.ToolStrOsnapQua, Me.ToolStrOsnapTan, Me.ToolStrOsnapActivado})
        Me.ToolStrOsnap.Location = New System.Drawing.Point(0, 3)
        Me.ToolStrOsnap.Name = "ToolStrOsnap"
        Me.ToolStrOsnap.Size = New System.Drawing.Size(24, 264)
        Me.ToolStrOsnap.TabIndex = 5
        '
        'ToolStrOsnapEnd
        '
        Me.ToolStrOsnapEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapEnd.Image = Global.mhCad.My.Resources.Resources.SnapEnd1
        Me.ToolStrOsnapEnd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapEnd.Name = "ToolStrOsnapEnd"
        Me.ToolStrOsnapEnd.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapEnd.Tag = "end"
        Me.ToolStrOsnapEnd.Text = "ToolStripButton1"
        Me.ToolStrOsnapEnd.ToolTipText = "Referencia a objeto (Osnap) a punto final (end point)"
        '
        'ToolStrOsnapMid
        '
        Me.ToolStrOsnapMid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapMid.Image = Global.mhCad.My.Resources.Resources.SnapMid1
        Me.ToolStrOsnapMid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapMid.Name = "ToolStrOsnapMid"
        Me.ToolStrOsnapMid.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapMid.Tag = "mid"
        Me.ToolStrOsnapMid.Text = "ToolStripButton1"
        Me.ToolStrOsnapMid.ToolTipText = "Referencia a objeto (Osnap) a punto medio (mid point)"
        '
        'ToolStrOsnapCen
        '
        Me.ToolStrOsnapCen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapCen.Image = Global.mhCad.My.Resources.Resources.SnapCen1
        Me.ToolStrOsnapCen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapCen.Name = "ToolStrOsnapCen"
        Me.ToolStrOsnapCen.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapCen.Tag = "cen"
        Me.ToolStrOsnapCen.Text = "ToolStripButton1"
        Me.ToolStrOsnapCen.ToolTipText = "Referencia a objeto (Osnap) a punto centro o central  (center point)"
        '
        'ToolStrOsnapInt
        '
        Me.ToolStrOsnapInt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapInt.Image = Global.mhCad.My.Resources.Resources.SnapInt1
        Me.ToolStrOsnapInt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapInt.Name = "ToolStrOsnapInt"
        Me.ToolStrOsnapInt.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapInt.Tag = "int"
        Me.ToolStrOsnapInt.Text = "ToolStripButton1"
        Me.ToolStrOsnapInt.ToolTipText = "Referencia a objeto (Osnap) a punto intersección (int point)"
        '
        'ToolStrOsnapPer
        '
        Me.ToolStrOsnapPer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapPer.Image = Global.mhCad.My.Resources.Resources.SnapPer1
        Me.ToolStrOsnapPer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapPer.Name = "ToolStrOsnapPer"
        Me.ToolStrOsnapPer.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapPer.Tag = "per"
        Me.ToolStrOsnapPer.Text = "ToolStripButton1"
        Me.ToolStrOsnapPer.ToolTipText = "Referencia a objeto (Osnap) a punto perpendicular (per point)"
        '
        'ToolStrOsnapNea
        '
        Me.ToolStrOsnapNea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapNea.Image = Global.mhCad.My.Resources.Resources.SnapNear1
        Me.ToolStrOsnapNea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapNea.Name = "ToolStrOsnapNea"
        Me.ToolStrOsnapNea.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapNea.Tag = "nea"
        Me.ToolStrOsnapNea.Text = "ToolStripButton1"
        Me.ToolStrOsnapNea.ToolTipText = "Referencia a objeto (Osnap) a punto mas cercano que pertenezca a la entidad (near" &
    "est point)"
        '
        'ToolStrOsnapApa
        '
        Me.ToolStrOsnapApa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapApa.Image = Global.mhCad.My.Resources.Resources.SnapApaInt1
        Me.ToolStrOsnapApa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapApa.Name = "ToolStrOsnapApa"
        Me.ToolStrOsnapApa.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapApa.Tag = "apa"
        Me.ToolStrOsnapApa.Text = "ToolStripButton1"
        Me.ToolStrOsnapApa.ToolTipText = "Referencia a Objetos (Osna) a la intersección aparente."
        '
        'ToolStrOsnapNod
        '
        Me.ToolStrOsnapNod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapNod.Image = Global.mhCad.My.Resources.Resources.acad_punto
        Me.ToolStrOsnapNod.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapNod.Name = "ToolStrOsnapNod"
        Me.ToolStrOsnapNod.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapNod.Tag = "nod"
        Me.ToolStrOsnapNod.Text = "ToolStripButton1"
        Me.ToolStrOsnapNod.ToolTipText = "Referencia a objeto (Osnap) " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a un punto (Node point)"
        '
        'ToolStrOsnapNon
        '
        Me.ToolStrOsnapNon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapNon.Image = Global.mhCad.My.Resources.Resources.SnapCancel1
        Me.ToolStrOsnapNon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapNon.Name = "ToolStrOsnapNon"
        Me.ToolStrOsnapNon.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapNon.Tag = "non"
        Me.ToolStrOsnapNon.Text = "ToolStripButton1"
        Me.ToolStrOsnapNon.ToolTipText = "Anular la última selección de punto de referencia a objetos (Osnap)"
        '
        'ToolStrOsnapQua
        '
        Me.ToolStrOsnapQua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapQua.Image = Global.mhCad.My.Resources.Resources.SnapQua1
        Me.ToolStrOsnapQua.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapQua.Name = "ToolStrOsnapQua"
        Me.ToolStrOsnapQua.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapQua.Tag = "qua"
        Me.ToolStrOsnapQua.Text = "ToolStripButton2"
        Me.ToolStrOsnapQua.ToolTipText = "Referencia a objeto Cuadrante (Quadrant)"
        '
        'ToolStrOsnapTan
        '
        Me.ToolStrOsnapTan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrOsnapTan.Image = Global.mhCad.My.Resources.Resources.SnapTan
        Me.ToolStrOsnapTan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapTan.Name = "ToolStrOsnapTan"
        Me.ToolStrOsnapTan.Size = New System.Drawing.Size(22, 20)
        Me.ToolStrOsnapTan.Tag = "tan"
        Me.ToolStrOsnapTan.Text = "ToolStripButton1"
        Me.ToolStrOsnapTan.ToolTipText = "Referencia a objetos Tangente "
        '
        'ToolStrOsnapActivado
        '
        Me.ToolStrOsnapActivado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStrOsnapActivado.Image = CType(resources.GetObject("ToolStrOsnapActivado.Image"), System.Drawing.Image)
        Me.ToolStrOsnapActivado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrOsnapActivado.Name = "ToolStrOsnapActivado"
        Me.ToolStrOsnapActivado.Size = New System.Drawing.Size(22, 19)
        Me.ToolStrOsnapActivado.Tag = "activarDesactivarOsnap"
        Me.ToolStrOsnapActivado.Text = "SI"
        Me.ToolStrOsnapActivado.ToolTipText = "Osnap Activado"
        Me.ToolStrOsnapActivado.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.EdicionToolStripMenuItem, Me.VistasToolStripMenuItem, Me.DibujarToolStripMenuItem, Me.ModificarToolStripMenuItem, Me.CotaToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.AgrimensoresToolStripMenuItem, Me.AyudasEInformaciónToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1145, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.AbrirToolStripMenuItem, Me.AbrirDwtToolStripMenuItem, Me.CerrarToolStripMenuItem, Me.ToolStripSeparator1, Me.GuardarToolStripMenuItem, Me.GuardarComoToolStripMenuItem, Me.ToolStripSeparator2, Me.puntasToolStripMenuItem, Me.ImprimirPlotearToolStripMenuItem, Me.ToolStripSeparator3, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_nuevo
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.NuevoToolStripMenuItem.Tag = "Nuevo"
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.Archivo_Abrir
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.AbrirToolStripMenuItem.Tag = "Abrir"
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'AbrirDwtToolStripMenuItem
        '
        Me.AbrirDwtToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_abrir
        Me.AbrirDwtToolStripMenuItem.Name = "AbrirDwtToolStripMenuItem"
        Me.AbrirDwtToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.AbrirDwtToolStripMenuItem.Tag = "abrirDwt"
        Me.AbrirDwtToolStripMenuItem.Text = "Abrir archivo .dwt"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.Desactivado
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.CerrarToolStripMenuItem.Tag = "Cerrar"
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(223, 6)
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.Diskete
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.GuardarToolStripMenuItem.Tag = "Guardar"
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.GuardarComoToolStripMenuItem.Tag = "GuardarComo"
        Me.GuardarComoToolStripMenuItem.Text = "Guardar como"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(223, 6)
        '
        'puntasToolStripMenuItem
        '
        Me.puntasToolStripMenuItem.Name = "puntasToolStripMenuItem"
        Me.puntasToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.puntasToolStripMenuItem.Tag = "puntas"
        Me.puntasToolStripMenuItem.Text = "Configurar impresion/ploteo"
        '
        'ImprimirPlotearToolStripMenuItem
        '
        Me.ImprimirPlotearToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.Impresora
        Me.ImprimirPlotearToolStripMenuItem.Name = "ImprimirPlotearToolStripMenuItem"
        Me.ImprimirPlotearToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ImprimirPlotearToolStripMenuItem.Tag = "Imprimir"
        Me.ImprimirPlotearToolStripMenuItem.Text = "Imprimir (Plotear)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(223, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.dropdown
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.SalirToolStripMenuItem.Tag = "Salir"
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'EdicionToolStripMenuItem
        '
        Me.EdicionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeshacerUndoToolStripMenuItem, Me.RehacerRedoToolStripMenuItem, Me.ToolStripSeparator4, Me.CortarToolStripMenuItem, Me.CopiarToolStripMenuItem, Me.PegarToolStripMenuItem})
        Me.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        Me.EdicionToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.EdicionToolStripMenuItem.Text = "Edicion"
        '
        'DeshacerUndoToolStripMenuItem
        '
        Me.DeshacerUndoToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_undo
        Me.DeshacerUndoToolStripMenuItem.Name = "DeshacerUndoToolStripMenuItem"
        Me.DeshacerUndoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeshacerUndoToolStripMenuItem.Tag = "Deshacer"
        Me.DeshacerUndoToolStripMenuItem.Text = "Deshacer (Undo)"
        '
        'RehacerRedoToolStripMenuItem
        '
        Me.RehacerRedoToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_redo
        Me.RehacerRedoToolStripMenuItem.Name = "RehacerRedoToolStripMenuItem"
        Me.RehacerRedoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RehacerRedoToolStripMenuItem.Tag = "Rehacer"
        Me.RehacerRedoToolStripMenuItem.Text = "Rehacer (Redo)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(177, 6)
        '
        'CortarToolStripMenuItem
        '
        Me.CortarToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.CutV
        Me.CortarToolStripMenuItem.Name = "CortarToolStripMenuItem"
        Me.CortarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CortarToolStripMenuItem.Tag = "Cortar"
        Me.CortarToolStripMenuItem.Text = "Cortar"
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.CopyClipV
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CopiarToolStripMenuItem.Tag = "CopiarClip"
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'PegarToolStripMenuItem
        '
        Me.PegarToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.PasteV
        Me.PegarToolStripMenuItem.Name = "PegarToolStripMenuItem"
        Me.PegarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PegarToolStripMenuItem.Tag = "Pegar"
        Me.PegarToolStripMenuItem.Text = "Pegar"
        '
        'VistasToolStripMenuItem
        '
        Me.VistasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZoomExtensióntodoToolStripMenuItem, Me.ZoomVentanaWindowToolStripMenuItem, Me.ZoomAnteriorPreviousToolStripMenuItem, Me.ZoomDisminuirToolStripMenuItem, Me.ZoomAumentarToolStripMenuItem, Me.ToolStripSeparator5, Me.PanToolStripMenuItem, Me.ToolStripSeparator6, Me.toolStrSendToBack, Me.toolStrBringToFront, Me.ToolStripSeparator27, Me.NuevaLáminaLayoutToolStripMenuItem, Me.VentanasViewPortsToolStripMenuItem, Me.CambiarUnidadesDelEspacioPapelToolStripMenuItem, Me.ToolStripSeparator17, Me.UcsToolStripMenuItem})
        Me.VistasToolStripMenuItem.Name = "VistasToolStripMenuItem"
        Me.VistasToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.VistasToolStripMenuItem.Text = "Vistas"
        '
        'ZoomExtensióntodoToolStripMenuItem
        '
        Me.ZoomExtensióntodoToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.ZoomE
        Me.ZoomExtensióntodoToolStripMenuItem.Name = "ZoomExtensióntodoToolStripMenuItem"
        Me.ZoomExtensióntodoToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ZoomExtensióntodoToolStripMenuItem.Tag = "Ze"
        Me.ZoomExtensióntodoToolStripMenuItem.Text = "Zoom Extensión (todo)"
        '
        'ZoomVentanaWindowToolStripMenuItem
        '
        Me.ZoomVentanaWindowToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_ZW
        Me.ZoomVentanaWindowToolStripMenuItem.Name = "ZoomVentanaWindowToolStripMenuItem"
        Me.ZoomVentanaWindowToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ZoomVentanaWindowToolStripMenuItem.Tag = "Zw"
        Me.ZoomVentanaWindowToolStripMenuItem.Text = "Zoom Ventana (Window)"
        '
        'ZoomAnteriorPreviousToolStripMenuItem
        '
        Me.ZoomAnteriorPreviousToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_ZP
        Me.ZoomAnteriorPreviousToolStripMenuItem.Name = "ZoomAnteriorPreviousToolStripMenuItem"
        Me.ZoomAnteriorPreviousToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ZoomAnteriorPreviousToolStripMenuItem.Tag = "Zp"
        Me.ZoomAnteriorPreviousToolStripMenuItem.Text = "Zoom Anterior (Previous)"
        '
        'ZoomDisminuirToolStripMenuItem
        '
        Me.ZoomDisminuirToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.ZoomReducir
        Me.ZoomDisminuirToolStripMenuItem.Name = "ZoomDisminuirToolStripMenuItem"
        Me.ZoomDisminuirToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ZoomDisminuirToolStripMenuItem.Tag = "ZDisminuir"
        Me.ZoomDisminuirToolStripMenuItem.Text = "Zoom Disminuir"
        '
        'ZoomAumentarToolStripMenuItem
        '
        Me.ZoomAumentarToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.ZoomAmpliar
        Me.ZoomAumentarToolStripMenuItem.Name = "ZoomAumentarToolStripMenuItem"
        Me.ZoomAumentarToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ZoomAumentarToolStripMenuItem.Tag = "ZAumentar"
        Me.ZoomAumentarToolStripMenuItem.Text = "Zoom Aumentar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(261, 6)
        '
        'PanToolStripMenuItem
        '
        Me.PanToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_pan
        Me.PanToolStripMenuItem.Name = "PanToolStripMenuItem"
        Me.PanToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.PanToolStripMenuItem.Tag = "Pan"
        Me.PanToolStripMenuItem.Text = "Pan"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(261, 6)
        '
        'toolStrSendToBack
        '
        Me.toolStrSendToBack.Image = Global.mhCad.My.Resources.Resources.move_to_bottom
        Me.toolStrSendToBack.Name = "toolStrSendToBack"
        Me.toolStrSendToBack.Size = New System.Drawing.Size(264, 22)
        Me.toolStrSendToBack.Tag = "sendtoback"
        Me.toolStrSendToBack.Text = "Enviar al fondo"
        '
        'toolStrBringToFront
        '
        Me.toolStrBringToFront.Image = Global.mhCad.My.Resources.Resources.move_to_top
        Me.toolStrBringToFront.Name = "toolStrBringToFront"
        Me.toolStrBringToFront.Size = New System.Drawing.Size(264, 22)
        Me.toolStrBringToFront.Tag = "bringtofront"
        Me.toolStrBringToFront.Text = "Traer al frente"
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(261, 6)
        '
        'NuevaLáminaLayoutToolStripMenuItem
        '
        Me.NuevaLáminaLayoutToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.gpPolygon
        Me.NuevaLáminaLayoutToolStripMenuItem.Name = "NuevaLáminaLayoutToolStripMenuItem"
        Me.NuevaLáminaLayoutToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.NuevaLáminaLayoutToolStripMenuItem.Tag = "NewLayout"
        Me.NuevaLáminaLayoutToolStripMenuItem.Text = "Nueva Lámina (Layout)"
        '
        'VentanasViewPortsToolStripMenuItem
        '
        Me.VentanasViewPortsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaVentanaViewPortToolStripMenuItem, Me.EscalasEnVentanasViewPortsToolStripMenuItem, Me.GiroDeViewPortToolStripMenuItem, Me.PosiciónOriginalDelViewPortToolStripMenuItem, Me.BloquearViewPortToolStripMenuItem})
        Me.VentanasViewPortsToolStripMenuItem.Name = "VentanasViewPortsToolStripMenuItem"
        Me.VentanasViewPortsToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.VentanasViewPortsToolStripMenuItem.Text = "Ventanas (ViewPorts)"
        '
        'NuevaVentanaViewPortToolStripMenuItem
        '
        Me.NuevaVentanaViewPortToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DibujandoRectanguloToolStripMenuItem, Me.APartirDeUnaEntidadCerradaToolStripMenuItem})
        Me.NuevaVentanaViewPortToolStripMenuItem.Name = "NuevaVentanaViewPortToolStripMenuItem"
        Me.NuevaVentanaViewPortToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.NuevaVentanaViewPortToolStripMenuItem.Tag = "NewViewPort"
        Me.NuevaVentanaViewPortToolStripMenuItem.Text = "Nueva Ventana (ViewPort)"
        '
        'DibujandoRectanguloToolStripMenuItem
        '
        Me.DibujandoRectanguloToolStripMenuItem.Name = "DibujandoRectanguloToolStripMenuItem"
        Me.DibujandoRectanguloToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.DibujandoRectanguloToolStripMenuItem.Tag = "NewViewPort"
        Me.DibujandoRectanguloToolStripMenuItem.Text = "Dibujando rectangulo"
        '
        'APartirDeUnaEntidadCerradaToolStripMenuItem
        '
        Me.APartirDeUnaEntidadCerradaToolStripMenuItem.Name = "APartirDeUnaEntidadCerradaToolStripMenuItem"
        Me.APartirDeUnaEntidadCerradaToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.APartirDeUnaEntidadCerradaToolStripMenuItem.Tag = "aPartirDeEntidad"
        Me.APartirDeUnaEntidadCerradaToolStripMenuItem.Text = "A partir de una entidad cerrada"
        '
        'EscalasEnVentanasViewPortsToolStripMenuItem
        '
        Me.EscalasEnVentanasViewPortsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemE100, Me.ToolStripMenuItemE50, Me.ToolStripMenuItemE1000, Me.IngresarDenominadorEscalaToolStripMenuItem})
        Me.EscalasEnVentanasViewPortsToolStripMenuItem.Name = "EscalasEnVentanasViewPortsToolStripMenuItem"
        Me.EscalasEnVentanasViewPortsToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.EscalasEnVentanasViewPortsToolStripMenuItem.Text = "Escalas en Ventanas (ViewPorts)"
        '
        'ToolStripMenuItemE100
        '
        Me.ToolStripMenuItemE100.Name = "ToolStripMenuItemE100"
        Me.ToolStripMenuItemE100.Size = New System.Drawing.Size(226, 22)
        Me.ToolStripMenuItemE100.Tag = "100"
        Me.ToolStripMenuItemE100.Text = "1:100"
        '
        'ToolStripMenuItemE50
        '
        Me.ToolStripMenuItemE50.Name = "ToolStripMenuItemE50"
        Me.ToolStripMenuItemE50.Size = New System.Drawing.Size(226, 22)
        Me.ToolStripMenuItemE50.Tag = "50"
        Me.ToolStripMenuItemE50.Text = "1:50"
        '
        'ToolStripMenuItemE1000
        '
        Me.ToolStripMenuItemE1000.Name = "ToolStripMenuItemE1000"
        Me.ToolStripMenuItemE1000.Size = New System.Drawing.Size(226, 22)
        Me.ToolStripMenuItemE1000.Tag = "1000"
        Me.ToolStripMenuItemE1000.Text = "1:1000"
        '
        'IngresarDenominadorEscalaToolStripMenuItem
        '
        Me.IngresarDenominadorEscalaToolStripMenuItem.Name = "IngresarDenominadorEscalaToolStripMenuItem"
        Me.IngresarDenominadorEscalaToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.IngresarDenominadorEscalaToolStripMenuItem.Tag = "IngresaEscala"
        Me.IngresarDenominadorEscalaToolStripMenuItem.Text = "Ingresar denominador escala"
        '
        'GiroDeViewPortToolStripMenuItem
        '
        Me.GiroDeViewPortToolStripMenuItem.Name = "GiroDeViewPortToolStripMenuItem"
        Me.GiroDeViewPortToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.GiroDeViewPortToolStripMenuItem.Tag = "girovp"
        Me.GiroDeViewPortToolStripMenuItem.Text = "Giro de ViewPort"
        '
        'PosiciónOriginalDelViewPortToolStripMenuItem
        '
        Me.PosiciónOriginalDelViewPortToolStripMenuItem.Name = "PosiciónOriginalDelViewPortToolStripMenuItem"
        Me.PosiciónOriginalDelViewPortToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.PosiciónOriginalDelViewPortToolStripMenuItem.Tag = "resetvp"
        Me.PosiciónOriginalDelViewPortToolStripMenuItem.Text = "Posición original del ViewPort"
        '
        'BloquearViewPortToolStripMenuItem
        '
        Me.BloquearViewPortToolStripMenuItem.Name = "BloquearViewPortToolStripMenuItem"
        Me.BloquearViewPortToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.BloquearViewPortToolStripMenuItem.Tag = "bvp"
        Me.BloquearViewPortToolStripMenuItem.Text = "Bloquear ViewPort"
        '
        'CambiarUnidadesDelEspacioPapelToolStripMenuItem
        '
        Me.CambiarUnidadesDelEspacioPapelToolStripMenuItem.Name = "CambiarUnidadesDelEspacioPapelToolStripMenuItem"
        Me.CambiarUnidadesDelEspacioPapelToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.CambiarUnidadesDelEspacioPapelToolStripMenuItem.Tag = "unidadesEspacioPapel"
        Me.CambiarUnidadesDelEspacioPapelToolStripMenuItem.Text = "Cambiar unidades del espacio papel"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(261, 6)
        '
        'UcsToolStripMenuItem
        '
        Me.UcsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UcsToolStripMenuItem1, Me.PlanToolStripMenuItem})
        Me.UcsToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.et_rtucs24
        Me.UcsToolStripMenuItem.Name = "UcsToolStripMenuItem"
        Me.UcsToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.UcsToolStripMenuItem.Text = "Ucs"
        '
        'UcsToolStripMenuItem1
        '
        Me.UcsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorTresPuntosToolStripMenuItem, Me.UbicaciónOriginalWorldToolStripMenuItem})
        Me.UcsToolStripMenuItem1.Image = Global.mhCad.My.Resources.Resources.et_rtucs24
        Me.UcsToolStripMenuItem1.Name = "UcsToolStripMenuItem1"
        Me.UcsToolStripMenuItem1.Size = New System.Drawing.Size(97, 22)
        Me.UcsToolStripMenuItem1.Tag = "Ucs"
        Me.UcsToolStripMenuItem1.Text = "Ucs"
        '
        'PorTresPuntosToolStripMenuItem
        '
        Me.PorTresPuntosToolStripMenuItem.Name = "PorTresPuntosToolStripMenuItem"
        Me.PorTresPuntosToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.PorTresPuntosToolStripMenuItem.Tag = "Por_tres_puntos"
        Me.PorTresPuntosToolStripMenuItem.Text = "Por tres puntos (3)"
        '
        'UbicaciónOriginalWorldToolStripMenuItem
        '
        Me.UbicaciónOriginalWorldToolStripMenuItem.Name = "UbicaciónOriginalWorldToolStripMenuItem"
        Me.UbicaciónOriginalWorldToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.UbicaciónOriginalWorldToolStripMenuItem.Tag = "Ubicacion_original"
        Me.UbicaciónOriginalWorldToolStripMenuItem.Text = "Ubicación original (World)"
        '
        'PlanToolStripMenuItem
        '
        Me.PlanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UcsActualToolStripMenuItem, Me.OriginalWorldToolStripMenuItem})
        Me.PlanToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.et_mstrch16
        Me.PlanToolStripMenuItem.Name = "PlanToolStripMenuItem"
        Me.PlanToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.PlanToolStripMenuItem.Tag = "Plan"
        Me.PlanToolStripMenuItem.Text = "Plan"
        '
        'UcsActualToolStripMenuItem
        '
        Me.UcsActualToolStripMenuItem.Name = "UcsActualToolStripMenuItem"
        Me.UcsActualToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.UcsActualToolStripMenuItem.Tag = "Ucs_actual"
        Me.UcsActualToolStripMenuItem.Text = "Ucs actual (U)"
        '
        'OriginalWorldToolStripMenuItem
        '
        Me.OriginalWorldToolStripMenuItem.Name = "OriginalWorldToolStripMenuItem"
        Me.OriginalWorldToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.OriginalWorldToolStripMenuItem.Tag = "Original"
        Me.OriginalWorldToolStripMenuItem.Text = "Original (World)"
        '
        'DibujarToolStripMenuItem
        '
        Me.DibujarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LineaToolStripMenuItem, Me.xLine, Me.xray, Me.PolilineaToolStripMenuItem, Me.ToolStripSeparator7, Me.ArcoToolStripMenuItem, Me.CirculoToolStripMenuItem, Me.ElipseToolStripMenuItem, Me.RectanguloToolStripMenuItem, Me.ToolStripSeparator8, Me.PuntoToolStripMenuItem, Me.EstiloDePuntoToolStripMenuItem, Me.ToolStripSeparator9, Me.TextosToolStripMenuItem, Me.ToolStripSeparator10, Me.TramadosHatchToolStripMenuItem, Me.ToolStripSeparator11, Me.BloquesToolStripMenuItem, Me.ToolStripSeparator29, Me.Imagenes})
        Me.DibujarToolStripMenuItem.Name = "DibujarToolStripMenuItem"
        Me.DibujarToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.DibujarToolStripMenuItem.Text = "Dibujar"
        '
        'LineaToolStripMenuItem
        '
        Me.LineaToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_linea
        Me.LineaToolStripMenuItem.Name = "LineaToolStripMenuItem"
        Me.LineaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LineaToolStripMenuItem.Tag = "Linea"
        Me.LineaToolStripMenuItem.Text = "Linea"
        '
        'xLine
        '
        Me.xLine.Name = "xLine"
        Me.xLine.Size = New System.Drawing.Size(180, 22)
        Me.xLine.Tag = "xlinea"
        Me.xLine.Text = "Linea infinita (xline)"
        '
        'xray
        '
        Me.xray.Name = "xray"
        Me.xray.Size = New System.Drawing.Size(180, 22)
        Me.xray.Tag = "xray"
        Me.xray.Text = "Linea radial (xray)"
        '
        'PolilineaToolStripMenuItem
        '
        Me.PolilineaToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_poli
        Me.PolilineaToolStripMenuItem.Name = "PolilineaToolStripMenuItem"
        Me.PolilineaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PolilineaToolStripMenuItem.Tag = "Polilinea"
        Me.PolilineaToolStripMenuItem.Text = "Polilinea"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(177, 6)
        '
        'ArcoToolStripMenuItem
        '
        Me.ArcoToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_arco
        Me.ArcoToolStripMenuItem.Name = "ArcoToolStripMenuItem"
        Me.ArcoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ArcoToolStripMenuItem.Tag = "Arco"
        Me.ArcoToolStripMenuItem.Text = "Arco"
        '
        'CirculoToolStripMenuItem
        '
        Me.CirculoToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_circulo
        Me.CirculoToolStripMenuItem.Name = "CirculoToolStripMenuItem"
        Me.CirculoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CirculoToolStripMenuItem.Tag = "Circulo"
        Me.CirculoToolStripMenuItem.Text = "Circulo"
        '
        'ElipseToolStripMenuItem
        '
        Me.ElipseToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_elipse
        Me.ElipseToolStripMenuItem.Name = "ElipseToolStripMenuItem"
        Me.ElipseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ElipseToolStripMenuItem.Tag = "Elipse"
        Me.ElipseToolStripMenuItem.Text = "Elipse"
        '
        'RectanguloToolStripMenuItem
        '
        Me.RectanguloToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_rectang
        Me.RectanguloToolStripMenuItem.Name = "RectanguloToolStripMenuItem"
        Me.RectanguloToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RectanguloToolStripMenuItem.Tag = "Rectangulo"
        Me.RectanguloToolStripMenuItem.Text = "Rectangulo"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(177, 6)
        '
        'PuntoToolStripMenuItem
        '
        Me.PuntoToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_punto
        Me.PuntoToolStripMenuItem.Name = "PuntoToolStripMenuItem"
        Me.PuntoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PuntoToolStripMenuItem.Tag = "Punto"
        Me.PuntoToolStripMenuItem.Text = "Punto"
        '
        'EstiloDePuntoToolStripMenuItem
        '
        Me.EstiloDePuntoToolStripMenuItem.Name = "EstiloDePuntoToolStripMenuItem"
        Me.EstiloDePuntoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EstiloDePuntoToolStripMenuItem.Tag = "EstiloPunto"
        Me.EstiloDePuntoToolStripMenuItem.Text = "Estilo de Punto"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(177, 6)
        '
        'TextosToolStripMenuItem
        '
        Me.TextosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnaLineaToolStripMenuItem, Me.MultilineaToolStripMenuItem, Me.EstiloDeTextoToolStripMenuItem})
        Me.TextosToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_texto
        Me.TextosToolStripMenuItem.Name = "TextosToolStripMenuItem"
        Me.TextosToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TextosToolStripMenuItem.Text = "Textos"
        '
        'UnaLineaToolStripMenuItem
        '
        Me.UnaLineaToolStripMenuItem.Name = "UnaLineaToolStripMenuItem"
        Me.UnaLineaToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.UnaLineaToolStripMenuItem.Tag = "UnaLinea"
        Me.UnaLineaToolStripMenuItem.Text = "Una linea"
        '
        'MultilineaToolStripMenuItem
        '
        Me.MultilineaToolStripMenuItem.Name = "MultilineaToolStripMenuItem"
        Me.MultilineaToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.MultilineaToolStripMenuItem.Tag = "Multilinea"
        Me.MultilineaToolStripMenuItem.Text = "Multilinea"
        '
        'EstiloDeTextoToolStripMenuItem
        '
        Me.EstiloDeTextoToolStripMenuItem.Name = "EstiloDeTextoToolStripMenuItem"
        Me.EstiloDeTextoToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.EstiloDeTextoToolStripMenuItem.Tag = "EstiloTexto"
        Me.EstiloDeTextoToolStripMenuItem.Text = "Estilo de texto"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(177, 6)
        '
        'TramadosHatchToolStripMenuItem
        '
        Me.TramadosHatchToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_hatch
        Me.TramadosHatchToolStripMenuItem.Name = "TramadosHatchToolStripMenuItem"
        Me.TramadosHatchToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TramadosHatchToolStripMenuItem.Tag = "Hatch"
        Me.TramadosHatchToolStripMenuItem.Text = "Tramados (Hatch)"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(177, 6)
        '
        'BloquesToolStripMenuItem
        '
        Me.BloquesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearToolStripMenuItem, Me.InsertarToolStripMenuItem, Me.EditarAtributosToolStripMenuItem, Me.CrearAtributoToolStripMenuItem, Me.ExportarBloqueToolStripMenuItem})
        Me.BloquesToolStripMenuItem.Name = "BloquesToolStripMenuItem"
        Me.BloquesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BloquesToolStripMenuItem.Text = "Bloques"
        '
        'CrearToolStripMenuItem
        '
        Me.CrearToolStripMenuItem.Name = "CrearToolStripMenuItem"
        Me.CrearToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CrearToolStripMenuItem.Tag = "Crear"
        Me.CrearToolStripMenuItem.Text = "Crear bloque"
        '
        'InsertarToolStripMenuItem
        '
        Me.InsertarToolStripMenuItem.Name = "InsertarToolStripMenuItem"
        Me.InsertarToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.InsertarToolStripMenuItem.Tag = "Insertar"
        Me.InsertarToolStripMenuItem.Text = "Insertar bloque"
        '
        'EditarAtributosToolStripMenuItem
        '
        Me.EditarAtributosToolStripMenuItem.Name = "EditarAtributosToolStripMenuItem"
        Me.EditarAtributosToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.EditarAtributosToolStripMenuItem.Tag = "editarAtributos"
        Me.EditarAtributosToolStripMenuItem.Text = "Editar atributos"
        '
        'CrearAtributoToolStripMenuItem
        '
        Me.CrearAtributoToolStripMenuItem.Name = "CrearAtributoToolStripMenuItem"
        Me.CrearAtributoToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CrearAtributoToolStripMenuItem.Tag = "crearatributo"
        Me.CrearAtributoToolStripMenuItem.Text = "Crear atributo"
        '
        'ExportarBloqueToolStripMenuItem
        '
        Me.ExportarBloqueToolStripMenuItem.Name = "ExportarBloqueToolStripMenuItem"
        Me.ExportarBloqueToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExportarBloqueToolStripMenuItem.Tag = "exportarBloque"
        Me.ExportarBloqueToolStripMenuItem.Text = "Exportar bloque"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(177, 6)
        '
        'Imagenes
        '
        Me.Imagenes.Name = "Imagenes"
        Me.Imagenes.Size = New System.Drawing.Size(180, 22)
        Me.Imagenes.Tag = "Imagenes"
        Me.Imagenes.Text = "Imagenes"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarEraseToolStripMenuItem, Me.CopiarCopyToolStripMenuItem, Me.SimetriaMirrorToolStripMenuItem, Me.EquidiistanciaOffsetToolStripMenuItem, Me.MoverMoveToolStripMenuItem, Me.RotarRotateToolStripMenuItem, Me.EscalaScaleToolStripMenuItem, Me.RecortarTrimToolStripMenuItem, Me.EstirarExtendToolStripMenuItem, Me.deformarToolStripMenuItem1, Me.ToolStripSeparator31, Me.arrayRectangularToolStripMenuItem2, Me.arrayPolarToolStripMenuItem1, Me.ToolStripSeparator34, Me.FilletRadioCeroToolStripMenuItem, Me.EmpalmeFilletToolStripMenuItem, Me.ToolStripSeparator32, Me.ExplotarExplodeToolStripMenuItem, Me.AlinearAlignToolStripMenuItem, Me.CortarBreakToolStripMenuItem, Me.ToolStripSeparator28, Me.ItemMenuCopiarPropiedades, Me.ToolStripSeparator30, Me.bPolyToolStripMenuItem, Me.PasarABynToolStripMenuItem})
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'BorrarEraseToolStripMenuItem
        '
        Me.BorrarEraseToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_borrar
        Me.BorrarEraseToolStripMenuItem.Name = "BorrarEraseToolStripMenuItem"
        Me.BorrarEraseToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.BorrarEraseToolStripMenuItem.Tag = "Borrar"
        Me.BorrarEraseToolStripMenuItem.Text = "Borrar (Erase)"
        '
        'CopiarCopyToolStripMenuItem
        '
        Me.CopiarCopyToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_copy
        Me.CopiarCopyToolStripMenuItem.Name = "CopiarCopyToolStripMenuItem"
        Me.CopiarCopyToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.CopiarCopyToolStripMenuItem.Tag = "Copiar"
        Me.CopiarCopyToolStripMenuItem.Text = "Copiar (Copy)"
        '
        'SimetriaMirrorToolStripMenuItem
        '
        Me.SimetriaMirrorToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_mirror
        Me.SimetriaMirrorToolStripMenuItem.Name = "SimetriaMirrorToolStripMenuItem"
        Me.SimetriaMirrorToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.SimetriaMirrorToolStripMenuItem.Tag = "Simetria"
        Me.SimetriaMirrorToolStripMenuItem.Text = "Simetria (Mirror)"
        '
        'EquidiistanciaOffsetToolStripMenuItem
        '
        Me.EquidiistanciaOffsetToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_offset
        Me.EquidiistanciaOffsetToolStripMenuItem.Name = "EquidiistanciaOffsetToolStripMenuItem"
        Me.EquidiistanciaOffsetToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.EquidiistanciaOffsetToolStripMenuItem.Tag = "Equidistancia"
        Me.EquidiistanciaOffsetToolStripMenuItem.Text = "Equidiistancia (Offset)"
        '
        'MoverMoveToolStripMenuItem
        '
        Me.MoverMoveToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_mover
        Me.MoverMoveToolStripMenuItem.Name = "MoverMoveToolStripMenuItem"
        Me.MoverMoveToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.MoverMoveToolStripMenuItem.Tag = "Mover"
        Me.MoverMoveToolStripMenuItem.Text = "Mover (Move)"
        '
        'RotarRotateToolStripMenuItem
        '
        Me.RotarRotateToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_rotar
        Me.RotarRotateToolStripMenuItem.Name = "RotarRotateToolStripMenuItem"
        Me.RotarRotateToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.RotarRotateToolStripMenuItem.Tag = "Rotar"
        Me.RotarRotateToolStripMenuItem.Text = "Rotar (Rotate)"
        '
        'EscalaScaleToolStripMenuItem
        '
        Me.EscalaScaleToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_scale
        Me.EscalaScaleToolStripMenuItem.Name = "EscalaScaleToolStripMenuItem"
        Me.EscalaScaleToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.EscalaScaleToolStripMenuItem.Tag = "Escala"
        Me.EscalaScaleToolStripMenuItem.Text = "Escala (Scale)"
        '
        'RecortarTrimToolStripMenuItem
        '
        Me.RecortarTrimToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_trim
        Me.RecortarTrimToolStripMenuItem.Name = "RecortarTrimToolStripMenuItem"
        Me.RecortarTrimToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.RecortarTrimToolStripMenuItem.Tag = "Recortar"
        Me.RecortarTrimToolStripMenuItem.Text = "Recortar (Trim)"
        '
        'EstirarExtendToolStripMenuItem
        '
        Me.EstirarExtendToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_extend
        Me.EstirarExtendToolStripMenuItem.Name = "EstirarExtendToolStripMenuItem"
        Me.EstirarExtendToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.EstirarExtendToolStripMenuItem.Tag = "Estirar"
        Me.EstirarExtendToolStripMenuItem.Text = "Estirar (Extend)"
        '
        'deformarToolStripMenuItem1
        '
        Me.deformarToolStripMenuItem1.Name = "deformarToolStripMenuItem1"
        Me.deformarToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.deformarToolStripMenuItem1.Tag = "deformar"
        Me.deformarToolStripMenuItem1.Text = "Deformar (Stretch)"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(230, 6)
        '
        'arrayRectangularToolStripMenuItem2
        '
        Me.arrayRectangularToolStripMenuItem2.Name = "arrayRectangularToolStripMenuItem2"
        Me.arrayRectangularToolStripMenuItem2.Size = New System.Drawing.Size(233, 22)
        Me.arrayRectangularToolStripMenuItem2.Tag = "arrayRectangular"
        Me.arrayRectangularToolStripMenuItem2.Text = "Array rectangular"
        '
        'arrayPolarToolStripMenuItem1
        '
        Me.arrayPolarToolStripMenuItem1.Name = "arrayPolarToolStripMenuItem1"
        Me.arrayPolarToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.arrayPolarToolStripMenuItem1.Tag = "arrayPolar"
        Me.arrayPolarToolStripMenuItem1.Text = "Array polar"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(230, 6)
        '
        'FilletRadioCeroToolStripMenuItem
        '
        Me.FilletRadioCeroToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.FilletV
        Me.FilletRadioCeroToolStripMenuItem.Name = "FilletRadioCeroToolStripMenuItem"
        Me.FilletRadioCeroToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.FilletRadioCeroToolStripMenuItem.Tag = "filletRadioCero"
        Me.FilletRadioCeroToolStripMenuItem.Text = "Fillet (empalme) con radio = 0"
        '
        'EmpalmeFilletToolStripMenuItem
        '
        Me.EmpalmeFilletToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_fillet
        Me.EmpalmeFilletToolStripMenuItem.Name = "EmpalmeFilletToolStripMenuItem"
        Me.EmpalmeFilletToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.EmpalmeFilletToolStripMenuItem.Tag = "Empalme"
        Me.EmpalmeFilletToolStripMenuItem.Text = "Fillet (empalme)"
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(230, 6)
        '
        'ExplotarExplodeToolStripMenuItem
        '
        Me.ExplotarExplodeToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_explode
        Me.ExplotarExplodeToolStripMenuItem.Name = "ExplotarExplodeToolStripMenuItem"
        Me.ExplotarExplodeToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ExplotarExplodeToolStripMenuItem.Tag = "Explotar"
        Me.ExplotarExplodeToolStripMenuItem.Text = "Explotar (Explode)"
        '
        'AlinearAlignToolStripMenuItem
        '
        Me.AlinearAlignToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_alinear
        Me.AlinearAlignToolStripMenuItem.Name = "AlinearAlignToolStripMenuItem"
        Me.AlinearAlignToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.AlinearAlignToolStripMenuItem.Tag = "Alinear"
        Me.AlinearAlignToolStripMenuItem.Text = "Alinear (Align)"
        '
        'CortarBreakToolStripMenuItem
        '
        Me.CortarBreakToolStripMenuItem.Image = Global.mhCad.My.Resources.Resources.acad_break
        Me.CortarBreakToolStripMenuItem.Name = "CortarBreakToolStripMenuItem"
        Me.CortarBreakToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.CortarBreakToolStripMenuItem.Tag = "Break"
        Me.CortarBreakToolStripMenuItem.Text = "Cortar (Break)"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(230, 6)
        '
        'ItemMenuCopiarPropiedades
        '
        Me.ItemMenuCopiarPropiedades.Image = Global.mhCad.My.Resources.Resources.pincelito1
        Me.ItemMenuCopiarPropiedades.Name = "ItemMenuCopiarPropiedades"
        Me.ItemMenuCopiarPropiedades.Size = New System.Drawing.Size(233, 22)
        Me.ItemMenuCopiarPropiedades.Tag = "tagCopiarPropiedades"
        Me.ItemMenuCopiarPropiedades.Text = "Copiar propiedades"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(230, 6)
        '
        'bPolyToolStripMenuItem
        '
        Me.bPolyToolStripMenuItem.Name = "bPolyToolStripMenuItem"
        Me.bPolyToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.bPolyToolStripMenuItem.Tag = "bpoly"
        Me.bPolyToolStripMenuItem.Text = "bPoly"
        '
        'PasarABynToolStripMenuItem
        '
        Me.PasarABynToolStripMenuItem.Name = "PasarABynToolStripMenuItem"
        Me.PasarABynToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.PasarABynToolStripMenuItem.Tag = "pasarByN"
        Me.PasarABynToolStripMenuItem.Text = "Pasar a byn"
        '
        'CotaToolStripMenuItem
        '
        Me.CotaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlineadaToolStripMenuItem, Me.RadialToolStripMenuItem, Me.DiametralToolStripMenuItem, Me.AngularToolStripMenuItem, Me.leader, Me.EstilosDeCotasToolStripMenuItem})
        Me.CotaToolStripMenuItem.Name = "CotaToolStripMenuItem"
        Me.CotaToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.CotaToolStripMenuItem.Text = "Cota"
        '
        'AlineadaToolStripMenuItem
        '
        Me.AlineadaToolStripMenuItem.Name = "AlineadaToolStripMenuItem"
        Me.AlineadaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AlineadaToolStripMenuItem.Tag = "Alineada"
        Me.AlineadaToolStripMenuItem.Text = "Alineada"
        '
        'RadialToolStripMenuItem
        '
        Me.RadialToolStripMenuItem.Name = "RadialToolStripMenuItem"
        Me.RadialToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RadialToolStripMenuItem.Tag = "Radial"
        Me.RadialToolStripMenuItem.Text = "Radial"
        '
        'DiametralToolStripMenuItem
        '
        Me.DiametralToolStripMenuItem.Name = "DiametralToolStripMenuItem"
        Me.DiametralToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DiametralToolStripMenuItem.Tag = "Diametral"
        Me.DiametralToolStripMenuItem.Text = "Diametral"
        '
        'AngularToolStripMenuItem
        '
        Me.AngularToolStripMenuItem.Name = "AngularToolStripMenuItem"
        Me.AngularToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AngularToolStripMenuItem.Tag = "Angular"
        Me.AngularToolStripMenuItem.Text = "Angular"
        '
        'leader
        '
        Me.leader.Name = "leader"
        Me.leader.Size = New System.Drawing.Size(180, 22)
        Me.leader.Tag = "leader"
        Me.leader.Text = "Nota (leader)"
        '
        'EstilosDeCotasToolStripMenuItem
        '
        Me.EstilosDeCotasToolStripMenuItem.Name = "EstilosDeCotasToolStripMenuItem"
        Me.EstilosDeCotasToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EstilosDeCotasToolStripMenuItem.Tag = "EstiloCota"
        Me.EstilosDeCotasToolStripMenuItem.Text = "Estilos de cotas"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MedirDistanciaToolStripMenuItem, Me.MedirAreaXVerticesToolStripMenuItem, Me.MedirAreaXEntidadToolStripMenuItem, Me.ToolStripSeparator21, Me.IdPunto, Me.ToolStripSeparator12, Me.ReferenciaAObjetosOsnapToolStripMenuItem, Me.PantallaPropiedadesToolStripMenuItem, Me.LayersToolStripMenuItem, Me.ToolStripSeparator13, Me.BarrasDeHerramientasToolBarsToolStripMenuItem, Me.ConfiguraciónCursor, Me.ConfiguraGrilla, Me.configuracionOsnap, Me.ConfiguraciónAutoSaveToolStripMenuItem, Me.ConfiguraLaminas, Me.ConfiguraciònEspacioModeloToolStripMenuItem, Me.encenderApagarEjesUcs})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.HerramientasToolStripMenuItem.Text = "Herramientas"
        '
        'MedirDistanciaToolStripMenuItem
        '
        Me.MedirDistanciaToolStripMenuItem.Name = "MedirDistanciaToolStripMenuItem"
        Me.MedirDistanciaToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.MedirDistanciaToolStripMenuItem.Tag = "Distancia"
        Me.MedirDistanciaToolStripMenuItem.Text = "Medir distancia"
        '
        'MedirAreaXVerticesToolStripMenuItem
        '
        Me.MedirAreaXVerticesToolStripMenuItem.Name = "MedirAreaXVerticesToolStripMenuItem"
        Me.MedirAreaXVerticesToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.MedirAreaXVerticesToolStripMenuItem.Tag = "AreaVertices"
        Me.MedirAreaXVerticesToolStripMenuItem.Text = "Medir Area ( x vertices )"
        '
        'MedirAreaXEntidadToolStripMenuItem
        '
        Me.MedirAreaXEntidadToolStripMenuItem.Name = "MedirAreaXEntidadToolStripMenuItem"
        Me.MedirAreaXEntidadToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.MedirAreaXEntidadToolStripMenuItem.Tag = "AreaEntidad"
        Me.MedirAreaXEntidadToolStripMenuItem.Text = "Medir Area ( x entidad )"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(350, 6)
        '
        'IdPunto
        '
        Me.IdPunto.Name = "IdPunto"
        Me.IdPunto.Size = New System.Drawing.Size(353, 22)
        Me.IdPunto.Tag = "identificarPunto"
        Me.IdPunto.Text = "Coordenadas de punto (""id"")"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(350, 6)
        '
        'ReferenciaAObjetosOsnapToolStripMenuItem
        '
        Me.ReferenciaAObjetosOsnapToolStripMenuItem.Name = "ReferenciaAObjetosOsnapToolStripMenuItem"
        Me.ReferenciaAObjetosOsnapToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.ReferenciaAObjetosOsnapToolStripMenuItem.Tag = "Osnap"
        Me.ReferenciaAObjetosOsnapToolStripMenuItem.Text = "Referencia a Objetos (Osnap)"
        '
        'PantallaPropiedadesToolStripMenuItem
        '
        Me.PantallaPropiedadesToolStripMenuItem.Name = "PantallaPropiedadesToolStripMenuItem"
        Me.PantallaPropiedadesToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.PantallaPropiedadesToolStripMenuItem.Tag = "Propiedades"
        Me.PantallaPropiedadesToolStripMenuItem.Text = "Pantalla Propiedades"
        '
        'LayersToolStripMenuItem
        '
        Me.LayersToolStripMenuItem.Name = "LayersToolStripMenuItem"
        Me.LayersToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.LayersToolStripMenuItem.Tag = "Layers"
        Me.LayersToolStripMenuItem.Text = "Layers"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(350, 6)
        '
        'BarrasDeHerramientasToolBarsToolStripMenuItem
        '
        Me.BarrasDeHerramientasToolBarsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DibujarToolStripMenuItem1, Me.EdiciónToolStripMenuItem, Me.Edición2ToolStripMenuItem, Me.OsnapToolStripMenuItem1, Me.LayersToolStripMenuItem1, Me.EstandarToolStripMenuItem, Me.VistasPanYZoomToolStripMenuItem, Me.ViewPortsescalasToolStripMenuItem, Me.CotasToolStripMenuItem})
        Me.BarrasDeHerramientasToolBarsToolStripMenuItem.Name = "BarrasDeHerramientasToolBarsToolStripMenuItem"
        Me.BarrasDeHerramientasToolBarsToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.BarrasDeHerramientasToolBarsToolStripMenuItem.Text = "Barras de herramientas (ToolBars)"
        '
        'DibujarToolStripMenuItem1
        '
        Me.DibujarToolStripMenuItem1.Checked = True
        Me.DibujarToolStripMenuItem1.CheckOnClick = True
        Me.DibujarToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DibujarToolStripMenuItem1.Name = "DibujarToolStripMenuItem1"
        Me.DibujarToolStripMenuItem1.Size = New System.Drawing.Size(223, 22)
        Me.DibujarToolStripMenuItem1.Text = "Dibujar"
        Me.DibujarToolStripMenuItem1.ToolTipText = "Apagar/Encender barra de herramientas de dibujar."
        '
        'EdiciónToolStripMenuItem
        '
        Me.EdiciónToolStripMenuItem.Checked = True
        Me.EdiciónToolStripMenuItem.CheckOnClick = True
        Me.EdiciónToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EdiciónToolStripMenuItem.Name = "EdiciónToolStripMenuItem"
        Me.EdiciónToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.EdiciónToolStripMenuItem.Text = "Edición"
        '
        'Edición2ToolStripMenuItem
        '
        Me.Edición2ToolStripMenuItem.Checked = True
        Me.Edición2ToolStripMenuItem.CheckOnClick = True
        Me.Edición2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Edición2ToolStripMenuItem.Name = "Edición2ToolStripMenuItem"
        Me.Edición2ToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.Edición2ToolStripMenuItem.Text = "Edicion 2"
        '
        'OsnapToolStripMenuItem1
        '
        Me.OsnapToolStripMenuItem1.Checked = True
        Me.OsnapToolStripMenuItem1.CheckOnClick = True
        Me.OsnapToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OsnapToolStripMenuItem1.Name = "OsnapToolStripMenuItem1"
        Me.OsnapToolStripMenuItem1.Size = New System.Drawing.Size(223, 22)
        Me.OsnapToolStripMenuItem1.Text = "Referencia a objetos (osnap)"
        '
        'LayersToolStripMenuItem1
        '
        Me.LayersToolStripMenuItem1.Checked = True
        Me.LayersToolStripMenuItem1.CheckOnClick = True
        Me.LayersToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LayersToolStripMenuItem1.Name = "LayersToolStripMenuItem1"
        Me.LayersToolStripMenuItem1.Size = New System.Drawing.Size(223, 22)
        Me.LayersToolStripMenuItem1.Text = "Layers"
        '
        'EstandarToolStripMenuItem
        '
        Me.EstandarToolStripMenuItem.Checked = True
        Me.EstandarToolStripMenuItem.CheckOnClick = True
        Me.EstandarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EstandarToolStripMenuItem.Name = "EstandarToolStripMenuItem"
        Me.EstandarToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.EstandarToolStripMenuItem.Text = "Estandar"
        '
        'VistasPanYZoomToolStripMenuItem
        '
        Me.VistasPanYZoomToolStripMenuItem.Checked = True
        Me.VistasPanYZoomToolStripMenuItem.CheckOnClick = True
        Me.VistasPanYZoomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VistasPanYZoomToolStripMenuItem.Name = "VistasPanYZoomToolStripMenuItem"
        Me.VistasPanYZoomToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.VistasPanYZoomToolStripMenuItem.Text = "Vistas (Pan y Zoom)"
        '
        'ViewPortsescalasToolStripMenuItem
        '
        Me.ViewPortsescalasToolStripMenuItem.Checked = True
        Me.ViewPortsescalasToolStripMenuItem.CheckOnClick = True
        Me.ViewPortsescalasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewPortsescalasToolStripMenuItem.Name = "ViewPortsescalasToolStripMenuItem"
        Me.ViewPortsescalasToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ViewPortsescalasToolStripMenuItem.Text = "ViewPorts (escalas)"
        '
        'CotasToolStripMenuItem
        '
        Me.CotasToolStripMenuItem.Checked = True
        Me.CotasToolStripMenuItem.CheckOnClick = True
        Me.CotasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CotasToolStripMenuItem.Name = "CotasToolStripMenuItem"
        Me.CotasToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.CotasToolStripMenuItem.Text = "Cotas"
        '
        'ConfiguraciónCursor
        '
        Me.ConfiguraciónCursor.Name = "ConfiguraciónCursor"
        Me.ConfiguraciónCursor.Size = New System.Drawing.Size(353, 22)
        Me.ConfiguraciónCursor.Tag = "configuraCursor"
        Me.ConfiguraciónCursor.Text = "Configuración cursor"
        '
        'ConfiguraGrilla
        '
        Me.ConfiguraGrilla.Name = "ConfiguraGrilla"
        Me.ConfiguraGrilla.Size = New System.Drawing.Size(353, 22)
        Me.ConfiguraGrilla.Tag = "ConfiguraGrilla"
        Me.ConfiguraGrilla.Text = "Configuración Grilla"
        '
        'configuracionOsnap
        '
        Me.configuracionOsnap.Name = "configuracionOsnap"
        Me.configuracionOsnap.Size = New System.Drawing.Size(353, 22)
        Me.configuracionOsnap.Tag = "configuraOsnap"
        Me.configuracionOsnap.Text = "Configuración Osnap (referencia a objetos)"
        '
        'ConfiguraciónAutoSaveToolStripMenuItem
        '
        Me.ConfiguraciónAutoSaveToolStripMenuItem.Name = "ConfiguraciónAutoSaveToolStripMenuItem"
        Me.ConfiguraciónAutoSaveToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.ConfiguraciónAutoSaveToolStripMenuItem.Tag = "configurarAutosave"
        Me.ConfiguraciónAutoSaveToolStripMenuItem.Text = "Configuración AutoSave"
        '
        'ConfiguraLaminas
        '
        Me.ConfiguraLaminas.Name = "ConfiguraLaminas"
        Me.ConfiguraLaminas.Size = New System.Drawing.Size(353, 22)
        Me.ConfiguraLaminas.Tag = "ConfiguraLaminas"
        Me.ConfiguraLaminas.Text = "Configuración láminas (layout)"
        '
        'ConfiguraciònEspacioModeloToolStripMenuItem
        '
        Me.ConfiguraciònEspacioModeloToolStripMenuItem.Name = "ConfiguraciònEspacioModeloToolStripMenuItem"
        Me.ConfiguraciònEspacioModeloToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.ConfiguraciònEspacioModeloToolStripMenuItem.Tag = "configuracionEspacioModelo"
        Me.ConfiguraciònEspacioModeloToolStripMenuItem.Text = "Configuración espacio modelo"
        '
        'encenderApagarEjesUcs
        '
        Me.encenderApagarEjesUcs.Name = "encenderApagarEjesUcs"
        Me.encenderApagarEjesUcs.Size = New System.Drawing.Size(353, 22)
        Me.encenderApagarEjesUcs.Tag = "encenderApagarEjesUcs"
        Me.encenderApagarEjesUcs.Text = "Encender / apagar visualización ejes origen de coord."
        '
        'AgrimensoresToolStripMenuItem
        '
        Me.AgrimensoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirPlantillaCatastroToolStr, Me.AbrirAntecedenteDpctToolStripMenuItem, Me.GuardarArchivoParaDpctSysToolStripMenuItem, Me.ToolStripSeparator14, Me.AbrirPlantillaGeodesiaToolStripMenuItem, Me.toolStrAntecedeGeodesia, Me.guardarDefinitivoParaGeodesia, Me.ToolStripSeparator15, Me.PHToolStripMenuItem, Me.ToolStripSeparator33, Me.AbrirCertifAmojToolStripMenuItem1, Me.CotasAgrimensuraToolStripMenuItem, Me.ObjetosAgrimensuraToolStripMenuItem, Me.ExportarDatosToolStripMenuItem})
        Me.AgrimensoresToolStripMenuItem.Name = "AgrimensoresToolStripMenuItem"
        Me.AgrimensoresToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.AgrimensoresToolStripMenuItem.Text = "Agrimensura"
        '
        'AbrirPlantillaCatastroToolStr
        '
        Me.AbrirPlantillaCatastroToolStr.Name = "AbrirPlantillaCatastroToolStr"
        Me.AbrirPlantillaCatastroToolStr.Size = New System.Drawing.Size(246, 22)
        Me.AbrirPlantillaCatastroToolStr.Tag = "PlantillaCatastro"
        Me.AbrirPlantillaCatastroToolStr.Text = "Abrir plantilla Catastro"
        '
        'AbrirAntecedenteDpctToolStripMenuItem
        '
        Me.AbrirAntecedenteDpctToolStripMenuItem.Name = "AbrirAntecedenteDpctToolStripMenuItem"
        Me.AbrirAntecedenteDpctToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.AbrirAntecedenteDpctToolStripMenuItem.Tag = "Antecedente"
        Me.AbrirAntecedenteDpctToolStripMenuItem.Text = "Insertar anteced. Dpct (.dxf)"
        '
        'GuardarArchivoParaDpctSysToolStripMenuItem
        '
        Me.GuardarArchivoParaDpctSysToolStripMenuItem.Name = "GuardarArchivoParaDpctSysToolStripMenuItem"
        Me.GuardarArchivoParaDpctSysToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.GuardarArchivoParaDpctSysToolStripMenuItem.Tag = "GuardarSys"
        Me.GuardarArchivoParaDpctSysToolStripMenuItem.Text = "Guardar p/Dpct (.Sys)"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(243, 6)
        '
        'AbrirPlantillaGeodesiaToolStripMenuItem
        '
        Me.AbrirPlantillaGeodesiaToolStripMenuItem.Name = "AbrirPlantillaGeodesiaToolStripMenuItem"
        Me.AbrirPlantillaGeodesiaToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.AbrirPlantillaGeodesiaToolStripMenuItem.Tag = "PlantillaGeodesia"
        Me.AbrirPlantillaGeodesiaToolStripMenuItem.Text = "Abrir plantilla Geodesia"
        '
        'toolStrAntecedeGeodesia
        '
        Me.toolStrAntecedeGeodesia.Name = "toolStrAntecedeGeodesia"
        Me.toolStrAntecedeGeodesia.Size = New System.Drawing.Size(246, 22)
        Me.toolStrAntecedeGeodesia.Tag = "antecedenteGeodesia"
        Me.toolStrAntecedeGeodesia.Text = "Insertar antecedente Geodesia"
        Me.toolStrAntecedeGeodesia.Visible = False
        '
        'guardarDefinitivoParaGeodesia
        '
        Me.guardarDefinitivoParaGeodesia.Name = "guardarDefinitivoParaGeodesia"
        Me.guardarDefinitivoParaGeodesia.Size = New System.Drawing.Size(246, 22)
        Me.guardarDefinitivoParaGeodesia.Tag = "guardarParaGeodesia"
        Me.guardarDefinitivoParaGeodesia.Text = "Guardar definitivo para Geodesia"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(243, 6)
        '
        'PHToolStripMenuItem
        '
        Me.PHToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cuadroSuperficiesToolStripMenuItem, Me.poligonosDominioToolStripMenuItem, Me.poligonosComunesToolStripMenuItem})
        Me.PHToolStripMenuItem.Name = "PHToolStripMenuItem"
        Me.PHToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.PHToolStripMenuItem.Tag = "PH"
        Me.PHToolStripMenuItem.Text = "PH"
        '
        'cuadroSuperficiesToolStripMenuItem
        '
        Me.cuadroSuperficiesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnidadesFuncionalesToolStripMenuItem, Me.UnidadesComplementariasToolStripMenuItem, Me.SuperficiesComunesToolStripMenuItem})
        Me.cuadroSuperficiesToolStripMenuItem.Name = "cuadroSuperficiesToolStripMenuItem"
        Me.cuadroSuperficiesToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.cuadroSuperficiesToolStripMenuItem.Tag = ""
        Me.cuadroSuperficiesToolStripMenuItem.Text = "Cuadro de superficies"
        '
        'UnidadesFuncionalesToolStripMenuItem
        '
        Me.UnidadesFuncionalesToolStripMenuItem.Name = "UnidadesFuncionalesToolStripMenuItem"
        Me.UnidadesFuncionalesToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.UnidadesFuncionalesToolStripMenuItem.Tag = "UF"
        Me.UnidadesFuncionalesToolStripMenuItem.Text = "Unidades funcionales"
        '
        'UnidadesComplementariasToolStripMenuItem
        '
        Me.UnidadesComplementariasToolStripMenuItem.Name = "UnidadesComplementariasToolStripMenuItem"
        Me.UnidadesComplementariasToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.UnidadesComplementariasToolStripMenuItem.Tag = "UC"
        Me.UnidadesComplementariasToolStripMenuItem.Text = "Unidades complementarias"
        '
        'SuperficiesComunesToolStripMenuItem
        '
        Me.SuperficiesComunesToolStripMenuItem.Name = "SuperficiesComunesToolStripMenuItem"
        Me.SuperficiesComunesToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SuperficiesComunesToolStripMenuItem.Tag = "SC"
        Me.SuperficiesComunesToolStripMenuItem.Text = "Superficies comunes"
        '
        'poligonosDominioToolStripMenuItem
        '
        Me.poligonosDominioToolStripMenuItem.Name = "poligonosDominioToolStripMenuItem"
        Me.poligonosDominioToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.poligonosDominioToolStripMenuItem.Tag = "poligonosDominio"
        Me.poligonosDominioToolStripMenuItem.Text = "Poligono de dominio"
        '
        'poligonosComunesToolStripMenuItem
        '
        Me.poligonosComunesToolStripMenuItem.Name = "poligonosComunesToolStripMenuItem"
        Me.poligonosComunesToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.poligonosComunesToolStripMenuItem.Tag = "poligonosComunes"
        Me.poligonosComunesToolStripMenuItem.Text = "Poligonos de Dominio comun"
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(243, 6)
        '
        'AbrirCertifAmojToolStripMenuItem1
        '
        Me.AbrirCertifAmojToolStripMenuItem1.Name = "AbrirCertifAmojToolStripMenuItem1"
        Me.AbrirCertifAmojToolStripMenuItem1.Size = New System.Drawing.Size(246, 22)
        Me.AbrirCertifAmojToolStripMenuItem1.Tag = "abrirCertificadoAmoj"
        Me.AbrirCertifAmojToolStripMenuItem1.Text = "Plantilla Certif Amoj"
        '
        'CotasAgrimensuraToolStripMenuItem
        '
        Me.CotasAgrimensuraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcotarToolStripMenuItem, Me.CotaDominioLineaSuperiorToolStripMenuItem, Me.CotaDominioLineaInToolStripMenuItem, Me.AcotarLadosToolStripMenuItem, Me.AngulosToolStripMenuItem})
        Me.CotasAgrimensuraToolStripMenuItem.Name = "CotasAgrimensuraToolStripMenuItem"
        Me.CotasAgrimensuraToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.CotasAgrimensuraToolStripMenuItem.Text = "Cotas Agrimensura"
        '
        'AcotarToolStripMenuItem
        '
        Me.AcotarToolStripMenuItem.Name = "AcotarToolStripMenuItem"
        Me.AcotarToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.AcotarToolStripMenuItem.Tag = "AgrAcotar"
        Me.AcotarToolStripMenuItem.Text = "Lados y ángulos"
        '
        'CotaDominioLineaSuperiorToolStripMenuItem
        '
        Me.CotaDominioLineaSuperiorToolStripMenuItem.Name = "CotaDominioLineaSuperiorToolStripMenuItem"
        Me.CotaDominioLineaSuperiorToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CotaDominioLineaSuperiorToolStripMenuItem.Tag = "AgrAcotarArriba"
        Me.CotaDominioLineaSuperiorToolStripMenuItem.Text = "Lados y áng. con linea sup."
        '
        'CotaDominioLineaInToolStripMenuItem
        '
        Me.CotaDominioLineaInToolStripMenuItem.Name = "CotaDominioLineaInToolStripMenuItem"
        Me.CotaDominioLineaInToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CotaDominioLineaInToolStripMenuItem.Tag = "AgrAcotarAbajo"
        Me.CotaDominioLineaInToolStripMenuItem.Text = "Lados y áng. con linea inf."
        '
        'AcotarLadosToolStripMenuItem
        '
        Me.AcotarLadosToolStripMenuItem.Name = "AcotarLadosToolStripMenuItem"
        Me.AcotarLadosToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.AcotarLadosToolStripMenuItem.Tag = "AgrAcotarLados"
        Me.AcotarLadosToolStripMenuItem.Text = "Lados"
        '
        'AngulosToolStripMenuItem
        '
        Me.AngulosToolStripMenuItem.Name = "AngulosToolStripMenuItem"
        Me.AngulosToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.AngulosToolStripMenuItem.Tag = "AgrAcotarAngulos"
        Me.AngulosToolStripMenuItem.Text = "Angulos"
        '
        'ObjetosAgrimensuraToolStripMenuItem
        '
        Me.ObjetosAgrimensuraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParcelaToolStripMenuItem, Me.DeslindeToolStripMenuItem, Me.NomenclaturaToolStripMenuItem, Me.DistanciaEsquinaToolStripMenuItem, Me.PoligonoEdificioToolStripMenuItem})
        Me.ObjetosAgrimensuraToolStripMenuItem.Name = "ObjetosAgrimensuraToolStripMenuItem"
        Me.ObjetosAgrimensuraToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.ObjetosAgrimensuraToolStripMenuItem.Text = "Objetos Agrimensura"
        '
        'ParcelaToolStripMenuItem
        '
        Me.ParcelaToolStripMenuItem.Name = "ParcelaToolStripMenuItem"
        Me.ParcelaToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ParcelaToolStripMenuItem.Tag = "objetoParcela"
        Me.ParcelaToolStripMenuItem.Text = "Parcela"
        '
        'DeslindeToolStripMenuItem
        '
        Me.DeslindeToolStripMenuItem.Name = "DeslindeToolStripMenuItem"
        Me.DeslindeToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.DeslindeToolStripMenuItem.Tag = "objetoDeslinde"
        Me.DeslindeToolStripMenuItem.Text = "Deslinde"
        '
        'NomenclaturaToolStripMenuItem
        '
        Me.NomenclaturaToolStripMenuItem.Name = "NomenclaturaToolStripMenuItem"
        Me.NomenclaturaToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.NomenclaturaToolStripMenuItem.Tag = "nomenclatura"
        Me.NomenclaturaToolStripMenuItem.Text = "Nomenclatura"
        '
        'DistanciaEsquinaToolStripMenuItem
        '
        Me.DistanciaEsquinaToolStripMenuItem.Name = "DistanciaEsquinaToolStripMenuItem"
        Me.DistanciaEsquinaToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.DistanciaEsquinaToolStripMenuItem.Tag = "distanciaesquina"
        Me.DistanciaEsquinaToolStripMenuItem.Text = "Distancia Esquina"
        '
        'PoligonoEdificioToolStripMenuItem
        '
        Me.PoligonoEdificioToolStripMenuItem.Name = "PoligonoEdificioToolStripMenuItem"
        Me.PoligonoEdificioToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.PoligonoEdificioToolStripMenuItem.Tag = "poligonoEdificio"
        Me.PoligonoEdificioToolStripMenuItem.Text = "Poligono Edificio"
        '
        'ExportarDatosToolStripMenuItem
        '
        Me.ExportarDatosToolStripMenuItem.Name = "ExportarDatosToolStripMenuItem"
        Me.ExportarDatosToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.ExportarDatosToolStripMenuItem.Tag = "exportarDatos"
        Me.ExportarDatosToolStripMenuItem.Text = "Exportar datos"
        '
        'AyudasEInformaciónToolStripMenuItem
        '
        Me.AyudasEInformaciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Abreviaturas, Me.VersiónLibreriaToolStripMenuItem, Me.ActivarProductoToolStripMenuItem, Me.CambiosEnLaVersionActualToolStripMenuItem})
        Me.AyudasEInformaciónToolStripMenuItem.Name = "AyudasEInformaciónToolStripMenuItem"
        Me.AyudasEInformaciónToolStripMenuItem.Size = New System.Drawing.Size(135, 20)
        Me.AyudasEInformaciónToolStripMenuItem.Text = "Ayudas e Información"
        '
        'Abreviaturas
        '
        Me.Abreviaturas.Name = "Abreviaturas"
        Me.Abreviaturas.Size = New System.Drawing.Size(225, 22)
        Me.Abreviaturas.Tag = "abreviaturas"
        Me.Abreviaturas.Text = " Abreviaturas de comandos"
        '
        'VersiónLibreriaToolStripMenuItem
        '
        Me.VersiónLibreriaToolStripMenuItem.Name = "VersiónLibreriaToolStripMenuItem"
        Me.VersiónLibreriaToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.VersiónLibreriaToolStripMenuItem.Tag = "versionLibreria"
        Me.VersiónLibreriaToolStripMenuItem.Text = "Versión libreria"
        '
        'ActivarProductoToolStripMenuItem
        '
        Me.ActivarProductoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargarDatosEnArchivoToolStripMenuItem, Me.IngresarElCodigoDeActivaciònToolStripMenuItem})
        Me.ActivarProductoToolStripMenuItem.Name = "ActivarProductoToolStripMenuItem"
        Me.ActivarProductoToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ActivarProductoToolStripMenuItem.Tag = "ActivarProducto"
        Me.ActivarProductoToolStripMenuItem.Text = "Activar Producto"
        '
        'CargarDatosEnArchivoToolStripMenuItem
        '
        Me.CargarDatosEnArchivoToolStripMenuItem.Name = "CargarDatosEnArchivoToolStripMenuItem"
        Me.CargarDatosEnArchivoToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.CargarDatosEnArchivoToolStripMenuItem.Text = "Cargar datos en archivo ""datos.txt"""
        '
        'IngresarElCodigoDeActivaciònToolStripMenuItem
        '
        Me.IngresarElCodigoDeActivaciònToolStripMenuItem.Name = "IngresarElCodigoDeActivaciònToolStripMenuItem"
        Me.IngresarElCodigoDeActivaciònToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.IngresarElCodigoDeActivaciònToolStripMenuItem.Text = "Ingresar el codigo de activaciòn"
        '
        'CambiosEnLaVersionActualToolStripMenuItem
        '
        Me.CambiosEnLaVersionActualToolStripMenuItem.Name = "CambiosEnLaVersionActualToolStripMenuItem"
        Me.CambiosEnLaVersionActualToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CambiosEnLaVersionActualToolStripMenuItem.Tag = "cambiosVersionActual"
        Me.CambiosEnLaVersionActualToolStripMenuItem.Text = "Cambios en la version actual"
        '
        'toolStrGeneral
        '
        Me.toolStrGeneral.AllowItemReorder = True
        Me.toolStrGeneral.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrGeneral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.toolStripSeparator, Me.CortarToolStripButton, Me.CopiarToolStripButton, Me.PegarToolStripButton, Me.toolStripSeparator18, Me.MatchToolStripButton, Me.ToolStripSeparator19, Me.AyudaToolStripButton})
        Me.toolStrGeneral.Location = New System.Drawing.Point(3, 24)
        Me.toolStrGeneral.Name = "toolStrGeneral"
        Me.HelpProvider1.SetShowHelp(Me.toolStrGeneral, True)
        Me.toolStrGeneral.Size = New System.Drawing.Size(237, 25)
        Me.toolStrGeneral.TabIndex = 3
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NuevoToolStripButton.Tag = "nuevo"
        Me.NuevoToolStripButton.Text = "&Nuevo"
        Me.NuevoToolStripButton.ToolTipText = "Nuevo dibujo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AbrirToolStripButton.Image = CType(resources.GetObject("AbrirToolStripButton.Image"), System.Drawing.Image)
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AbrirToolStripButton.Tag = "abrir"
        Me.AbrirToolStripButton.Text = "&Abrir"
        Me.AbrirToolStripButton.ToolTipText = "Abrir dibujo existente"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.GuardarToolStripButton.Tag = "guardar"
        Me.GuardarToolStripButton.Text = "&Guardar"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton.Image = CType(resources.GetObject("ImprimirToolStripButton.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton.Tag = "imprimir"
        Me.ImprimirToolStripButton.Text = "&Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CortarToolStripButton
        '
        Me.CortarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CortarToolStripButton.Image = CType(resources.GetObject("CortarToolStripButton.Image"), System.Drawing.Image)
        Me.CortarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CortarToolStripButton.Name = "CortarToolStripButton"
        Me.CortarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CortarToolStripButton.Tag = "btnCortar"
        Me.CortarToolStripButton.Text = "Cort&ar"
        '
        'CopiarToolStripButton
        '
        Me.CopiarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopiarToolStripButton.Image = CType(resources.GetObject("CopiarToolStripButton.Image"), System.Drawing.Image)
        Me.CopiarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopiarToolStripButton.Name = "CopiarToolStripButton"
        Me.CopiarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopiarToolStripButton.Tag = "btnCopiar"
        Me.CopiarToolStripButton.Text = "&Copiar"
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = CType(resources.GetObject("PegarToolStripButton.Image"), System.Drawing.Image)
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Tag = "btnPegar"
        Me.PegarToolStripButton.Text = "&Pegar"
        '
        'toolStripSeparator18
        '
        Me.toolStripSeparator18.Name = "toolStripSeparator18"
        Me.toolStripSeparator18.Size = New System.Drawing.Size(6, 25)
        '
        'MatchToolStripButton
        '
        Me.MatchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MatchToolStripButton.Image = Global.mhCad.My.Resources.Resources.pincelito1
        Me.MatchToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.MatchToolStripButton.Name = "MatchToolStripButton"
        Me.MatchToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.MatchToolStripButton.Tag = "btnMatch"
        Me.MatchToolStripButton.Text = "ToolStripButton1"
        Me.MatchToolStripButton.ToolTipText = "Copiar propiedades"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AyudaToolStripButton.Image = CType(resources.GetObject("AyudaToolStripButton.Image"), System.Drawing.Image)
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AyudaToolStripButton.Tag = "btnAyuda"
        Me.AyudaToolStripButton.Text = "Ay&uda"
        '
        'ToolStrViewports
        '
        Me.ToolStrViewports.Dock = System.Windows.Forms.DockStyle.None
        Me.HelpProvider1.SetHelpString(Me.ToolStrViewports, "")
        Me.ToolStrViewports.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStrViewportsEscala, Me.ToolStrEscViewpBtn, Me.ToolStripSeparator22, Me.btnUnidadesPapel, Me.ToolStripSeparator23, Me.btnBloquearVP, Me.toolStripBtnPropVP, Me.botonApagarViewports})
        Me.ToolStrViewports.Location = New System.Drawing.Point(3, 49)
        Me.ToolStrViewports.Name = "ToolStrViewports"
        Me.HelpProvider1.SetShowHelp(Me.ToolStrViewports, True)
        Me.ToolStrViewports.Size = New System.Drawing.Size(520, 25)
        Me.ToolStrViewports.TabIndex = 4
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripLabel1.Text = "Escala Viewport:"
        '
        'ToolStrViewportsEscala
        '
        Me.ToolStrViewportsEscala.AutoSize = False
        Me.ToolStrViewportsEscala.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ToolStrViewportsEscala.Margin = New System.Windows.Forms.Padding(5, 0, 1, 0)
        Me.ToolStrViewportsEscala.Name = "ToolStrViewportsEscala"
        Me.ToolStrViewportsEscala.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ToolStrViewportsEscala.Size = New System.Drawing.Size(70, 25)
        '
        'ToolStrEscViewpBtn
        '
        Me.ToolStrEscViewpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEscViewpBtn.Image = Global.mhCad.My.Resources.Resources.okay_up
        Me.ToolStrEscViewpBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEscViewpBtn.Name = "ToolStrEscViewpBtn"
        Me.ToolStrEscViewpBtn.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrEscViewpBtn.Text = "ToolStripButton1"
        Me.ToolStrEscViewpBtn.ToolTipText = "Aceptar escala ingresada."
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(6, 25)
        '
        'btnUnidadesPapel
        '
        Me.btnUnidadesPapel.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnUnidadesPapel.ForeColor = System.Drawing.Color.Black
        Me.btnUnidadesPapel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUnidadesPapel.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.btnUnidadesPapel.Name = "btnUnidadesPapel"
        Me.btnUnidadesPapel.Size = New System.Drawing.Size(128, 22)
        Me.btnUnidadesPapel.Text = "Unidades Papel = mm"
        Me.btnUnidadesPapel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(6, 25)
        '
        'btnBloquearVP
        '
        Me.btnBloquearVP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBloquearVP.Image = Global.mhCad.My.Resources.Resources.et_mocoro24
        Me.btnBloquearVP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBloquearVP.Name = "btnBloquearVP"
        Me.btnBloquearVP.Size = New System.Drawing.Size(23, 22)
        Me.btnBloquearVP.Text = "ToolStripButton1"
        Me.btnBloquearVP.ToolTipText = "Bloquear / Desbloquear Viewport"
        '
        'toolStripBtnPropVP
        '
        Me.toolStripBtnPropVP.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.toolStripBtnPropVP.ForeColor = System.Drawing.Color.Black
        Me.toolStripBtnPropVP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnPropVP.Name = "toolStripBtnPropVP"
        Me.toolStripBtnPropVP.Size = New System.Drawing.Size(126, 22)
        Me.toolStripBtnPropVP.Text = "Propiedades ViewPort"
        Me.toolStripBtnPropVP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.toolStripBtnPropVP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.toolStripBtnPropVP.ToolTipText = "Propiedades del viewPort activo."
        '
        'botonApagarViewports
        '
        Me.botonApagarViewports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.botonApagarViewports.Image = Global.mhCad.My.Resources.Resources.contextMenuRefresh___copia
        Me.botonApagarViewports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botonApagarViewports.Name = "botonApagarViewports"
        Me.botonApagarViewports.Size = New System.Drawing.Size(23, 22)
        Me.botonApagarViewports.Text = "ToolStripButton1"
        Me.botonApagarViewports.ToolTipText = "Apagar / Encender TODOS los viewPorts generados con el sistema."
        '
        'ToolStrCotas
        '
        Me.ToolStrCotas.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrCotas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrAlineada, Me.ToolStrRadial, Me.ToolStrDiametral, Me.ToolStrAngular, Me.ToolStrLeader, Me.ToolStrEstilo})
        Me.ToolStrCotas.Location = New System.Drawing.Point(3, 74)
        Me.ToolStrCotas.Name = "ToolStrCotas"
        Me.ToolStrCotas.Size = New System.Drawing.Size(150, 25)
        Me.ToolStrCotas.TabIndex = 5
        '
        'ToolStrAlineada
        '
        Me.ToolStrAlineada.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrAlineada.Image = CType(resources.GetObject("ToolStrAlineada.Image"), System.Drawing.Image)
        Me.ToolStrAlineada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrAlineada.Name = "ToolStrAlineada"
        Me.ToolStrAlineada.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrAlineada.Tag = "CotaAlineada"
        Me.ToolStrAlineada.Text = "ToolStripButton1"
        Me.ToolStrAlineada.ToolTipText = "Cota alineada"
        '
        'ToolStrRadial
        '
        Me.ToolStrRadial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrRadial.Image = CType(resources.GetObject("ToolStrRadial.Image"), System.Drawing.Image)
        Me.ToolStrRadial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrRadial.Name = "ToolStrRadial"
        Me.ToolStrRadial.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrRadial.Tag = "CotaRadial"
        Me.ToolStrRadial.Text = "ToolStripButton1"
        Me.ToolStrRadial.ToolTipText = "Cota radial"
        '
        'ToolStrDiametral
        '
        Me.ToolStrDiametral.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrDiametral.Image = CType(resources.GetObject("ToolStrDiametral.Image"), System.Drawing.Image)
        Me.ToolStrDiametral.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrDiametral.Name = "ToolStrDiametral"
        Me.ToolStrDiametral.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrDiametral.Tag = "CotaDiametral"
        Me.ToolStrDiametral.Text = "ToolStripButton1"
        Me.ToolStrDiametral.ToolTipText = "Cota Diametral"
        '
        'ToolStrAngular
        '
        Me.ToolStrAngular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrAngular.Image = CType(resources.GetObject("ToolStrAngular.Image"), System.Drawing.Image)
        Me.ToolStrAngular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrAngular.Name = "ToolStrAngular"
        Me.ToolStrAngular.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrAngular.Tag = "CotaAngular"
        Me.ToolStrAngular.Text = "ToolStripButton1"
        Me.ToolStrAngular.ToolTipText = "Cota Angular"
        '
        'ToolStrLeader
        '
        Me.ToolStrLeader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrLeader.Image = CType(resources.GetObject("ToolStrLeader.Image"), System.Drawing.Image)
        Me.ToolStrLeader.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrLeader.Name = "ToolStrLeader"
        Me.ToolStrLeader.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrLeader.Tag = "CotaLeader"
        Me.ToolStrLeader.Text = "ToolStripButton1"
        Me.ToolStrLeader.ToolTipText = "Cota nota (leader)"
        '
        'ToolStrEstilo
        '
        Me.ToolStrEstilo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrEstilo.Image = CType(resources.GetObject("ToolStrEstilo.Image"), System.Drawing.Image)
        Me.ToolStrEstilo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrEstilo.Name = "ToolStrEstilo"
        Me.ToolStrEstilo.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrEstilo.Tag = "CotaEstilo"
        Me.ToolStrEstilo.Text = "ToolStripButton1"
        Me.ToolStrEstilo.ToolTipText = "Estilos de cotas"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "C:\DesaMhcad\DesaDotNet\mhCad\mhCad\mhCad.chm"
        '
        'ofdDwt
        '
        Me.ofdDwt.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 35000
        '
        'frmPpal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 552)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("WindowState", Global.mhCad.My.MySettings.Default, "estadoVentanaAplicacion", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPpal"
        Me.Text = " "
        Me.WindowState = Global.mhCad.My.MySettings.Default.estadoVentanaAplicacion
        Me.ToolStrLayers.ResumeLayout(False)
        Me.ToolStrLayers.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.LeftToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.LeftToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.RightToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.RightToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrVistas.ResumeLayout(False)
        Me.ToolStrVistas.PerformLayout()
        Me.ToolStrDibujar.ResumeLayout(False)
        Me.ToolStrDibujar.PerformLayout()
        Me.ToolStrEditar2.ResumeLayout(False)
        Me.ToolStrEditar2.PerformLayout()
        Me.ToolStrEditar.ResumeLayout(False)
        Me.ToolStrEditar.PerformLayout()
        Me.ToolStrip3D.ResumeLayout(False)
        Me.ToolStrip3D.PerformLayout()
        Me.ToolStrOsnap.ResumeLayout(False)
        Me.ToolStrOsnap.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.toolStrGeneral.ResumeLayout(False)
        Me.toolStrGeneral.PerformLayout()
        Me.ToolStrViewports.ResumeLayout(False)
        Me.ToolStrViewports.PerformLayout()
        Me.ToolStrCotas.ResumeLayout(False)
        Me.ToolStrCotas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrLayers As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStrLayersBtnLayers As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents VdF As vdControls.vdFramedControl
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImprimirPlotearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeshacerUndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RehacerRedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CortarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PegarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VistasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomExtensióntodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomVentanaWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomAnteriorPreviousToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomDisminuirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomAumentarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NuevaLáminaLayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentanasViewPortsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaVentanaViewPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscalasEnVentanasViewPortsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemE100 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemE50 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemE1000 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarDenominadorEscalaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GiroDeViewPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PosiciónOriginalDelViewPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DibujarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LineaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PolilineaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ArcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CirculoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ElipseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RectanguloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PuntoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstiloDePuntoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnaLineaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultilineaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstiloDeTextoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TramadosHatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BloquesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarEraseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarCopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SimetriaMirrorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EquidiistanciaOffsetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoverMoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RotarRotateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscalaScaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecortarTrimToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstirarExtendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmpalmeFilletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExplotarExplodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlinearAlignToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CortarBreakToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CotaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlineadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiametralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AngularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstilosDeCotasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HerramientasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MedirDistanciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MedirAreaXVerticesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MedirAreaXEntidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReferenciaAObjetosOsnapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PantallaPropiedadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LayersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgrimensoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirAntecedenteDpctToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarArchivoParaDpctSysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AbrirPlantillaGeodesiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CotasAgrimensuraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcotarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CotaDominioLineaSuperiorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CotaDominioLineaInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStrGeneral As System.Windows.Forms.ToolStrip
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CortarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopiarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AyudaToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrLayersBtnTipoLinea As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrLayersCmbTipoLinea As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStrLayersBtnEspesor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrLayersCmbEspesor As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStrLayersBtnColor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnap As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrOsnapEnd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnapMid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnapCen As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnapInt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnapPer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnapNea As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnapNon As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnapNod As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrOsnapQua As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditar2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrEditarDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrEditarPropiedades As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarMirror As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarMove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarRotate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarScale As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarTrim As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarExtend As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarExplode As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarFillet As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarOffset As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarBreak As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarAlinear As System.Windows.Forms.ToolStripButton
    Friend WithEvents BarrasDeHerramientasToolBarsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DibujarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdiciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OsnapToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LayersToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstandarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrLayersLblColor As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrDibujar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrDibujarLinea As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDibujarPolilinea As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDibujarRectang As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDibujarArco As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDibujarCirculo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDibujarElipse As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDibujarPunto As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDibujarTexto As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDibujarHatch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarRehacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Edición2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrVistas As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrPan As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrZoomExtension As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrZoomWindows As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrZoomPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrZoomReducir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrZoomAmpliar As System.Windows.Forms.ToolStripButton
    Friend WithEvents VistasPanYZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirDwtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarAtributosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofdDwt As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStrEditarAtt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEscalaViewport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEditarFilletR0 As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirCertifAmojToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLayersBtnFondoLayout As System.Windows.Forms.ToolStripButton
    Friend WithEvents AyudasEInformaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersiónLibreriaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UcsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UcsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorTresPuntosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UbicaciónOriginalWorldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UcsActualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OriginalWorldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BloquearViewPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabelID As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IdPunto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents guardarDefinitivoParaGeodesia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Abreviaturas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents xLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents xray As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents leader As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrOsnapApa As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStrAntecedeGeodesia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStrSendToBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStrBringToFront As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStrBtnApagarLayersPapel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrViewports As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrViewportsEscala As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrEscViewpBtn As System.Windows.Forms.ToolStripButton
    Friend WithEvents MatchToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CrearAtributoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUnidadesPapel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrCotas As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrAlineada As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrRadial As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrDiametral As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrAngular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrLeader As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrEstilo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ViewPortsescalasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CotasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnBloquearVP As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirPlantillaCatastroToolStr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarUnidadesDelEspacioPapelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivarProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargarDatosEnArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarElCodigoDeActivaciònToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrDibujarInsert As System.Windows.Forms.ToolStripButton
    Friend WithEvents ConfiguraciónCursor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ItemMenuCopiarPropiedades As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripBtnPropVP As System.Windows.Forms.ToolStripButton
    Friend WithEvents botonApagarViewports As System.Windows.Forms.ToolStripButton
    Friend WithEvents ConfiguraLaminas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguraGrilla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionOsnap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Imagenes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiosEnLaVersionActualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ConfiguraciónAutoSaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrOsnapTan As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bPolyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DibujandoRectanguloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents APartirDeUnaEntidadCerradaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguraciònEspacioModeloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilletRadioCeroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator32 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrOsnapActivado As System.Windows.Forms.ToolStripButton
    Friend WithEvents PHToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ObjetosAgrimensuraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParcelaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeslindeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarDatosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NomenclaturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcotarLadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AngulosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DistanciaEsquinaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoligonoEdificioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents encenderApagarEjesUcs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarBloqueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasarABynToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents arrayRectangularToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents arrayPolarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents deformarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip3D As System.Windows.Forms.ToolStrip
    Friend WithEvents puntasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbtn3Drotacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dtop As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dbottom As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dleft As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dright As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dfront As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dback As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dne As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dnw As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dse As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtn3Dsw As System.Windows.Forms.ToolStripButton
    Friend WithEvents cuadroSuperficiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents poligonosDominioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents poligonosComunesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnidadesFuncionalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnidadesComplementariasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuperficiesComunesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsLbIdTrabajo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsBorrarEntidad As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsdMacizo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents definirMacizoPorPuntos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents definirMacizoPorPolilinea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsdMacizoLinderos As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents DefinirMacizoLinderosSeleccionandoPuntosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefinirMacizoSeleccionandoPolilineaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsdDistanciaEsquina As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsdDefinirPorPuntos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsdDefinirPorPolilinea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsdParcela As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsdDefinirPlPorPuntos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator36 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsMoverParcela As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsMuros As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsdSimbolos As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsdNorteUno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCroquis As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tsdParcelaLindera As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents DefinirParcelaLinderaPorPuntosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefinirParcelaLinderaPorPolilineaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CroquisDatosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsGuardarCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEstilos As System.Windows.Forms.ToolStripButton
    Friend WithEvents CachedCedulaFinal_121 As mhCad.CachedCedulaFinal_12

End Class
