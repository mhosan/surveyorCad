Imports System.Windows.Forms

Public Class frmObjetosAgrimensura

    Dim datosLeidosDesdeBloqueExistente As Boolean
    Public WithEvents baseControl As VectorDraw.Professional.Control.VectorDrawBaseControl
    Public WithEvents doc As VectorDraw.Professional.vdObjects.vdDocument
    Public fig As VectorDraw.Professional.vdPrimaries.vdFigure = Nothing
    Public bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
    Dim punto2 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    Dim punto3 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    Dim linea1 As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
    Dim lapolilinea As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
    Dim laCota As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension
    Dim laCotaDistanciaEsquina As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension
    Dim laCotaDistanciaEsquinaAnchoCalle As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension
    Dim textoDistanciaEsquinaNombreCalle As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText

    Dim area As Double

    Structure parcela
        Dim denominacion As String
        Dim superficie As String

    End Structure

    Private Sub frmObjetosAgrimensura_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        baseControl = frmPpal.VdF.BaseControl
        doc = frmPpal.VdF.BaseControl.ActiveDocument

    End Sub

    Private Sub frmObjetosAgrimensura_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If Not laCota Is Nothing Then
            laCota.HighLight = False
        End If
        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
        End If
        If Not laCotaDistanciaEsquinaAnchoCalle Is Nothing Then
            laCotaDistanciaEsquinaAnchoCalle.HighLight = False
        End If
        If Not laCotaDistanciaEsquina Is Nothing Then
            laCotaDistanciaEsquina.HighLight = False
        End If
        If Not textoDistanciaEsquinaNombreCalle Is Nothing Then
            textoDistanciaEsquinaNombreCalle.HighLight = False
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '------------------------------------------------------------------
        '
        'Este es el "aceptar" general, el de mas abajo
        '
        '------------------------------------------------------------------
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        '---------------------------------------------------------
        'Este es el boton Cancelar general, el de mas abajo.
        '---------------------------------------------------------
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
        If Not laCota Is Nothing Then
            laCota.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
        Me.Close()

    End Sub

    Private Sub doc_ActionEnd(ByVal sender As Object, ByVal actionName As String) Handles doc.ActionEnd
        Me.Activate()
    End Sub

    Private Sub baseControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles baseControl.KeyDown
        Me.Activate()
    End Sub

    Private Sub btnSeleccionaCota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionaCota.Click
        '--------------------------------------------------------------------------------------------------------
        '
        'DESLINDE
        '
        'Al hacer click en este boton, se selecciona una COTA que pertenece a un lado del poligono de la parcela
        '--------------------------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        If Not laCota Is Nothing Then
            laCota.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar COTA (medida del lado a cargar deslinde)")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            If Not fig Is Nothing Then                                                           'hay algo seleccionado
                If fig._TypeName = "vdDimension" Then
                    laCota = New VectorDraw.Professional.vdFigures.vdDimension
                    laCota.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    laCota.setDocumentDefaults()
                    laCota = CType(fig, VectorDraw.Professional.vdFigures.vdDimension)
                    lblCotaDeLadoSeleccionada.Text = "Identificador: " & laCota.Handle.ToString & ", Medida: " & Format(laCota.Measurement, "0.00").ToString
                    lblMedida.Text = Format(laCota.Measurement, "0.00")
                    laCota.HighLight = True
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    Me.Activate()
                Else
                    MsgBox("La entidad seleccionada no es una cota")
                    lblCotaDeLadoSeleccionada.Text = "--"
                    laCota.HighLight = False
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    Me.Activate()
                    Exit Sub
                End If

                If laCota.XProperties.Count > 0 Then
                    For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In laCota.XProperties
                        If atributo.Name = "Parcela" Then
                            lblParcela.Text = atributo.PropValue.ToString
                        ElseIf atributo.Name = "Linderos" Then
                            txtLinderos.Text = atributo.PropValue.ToString
                        ElseIf atributo.Name = "Lado" Then
                            cmbTipoLado.Text = atributo.PropValue.ToString
                        ElseIf atributo.Name = "Rumbo" Then
                            cmbRumbo.Text = atributo.PropValue.ToString
                        ElseIf atributo.Name = "Medida" Then
                            lblMedida.Text = atributo.PropValue.ToString
                        End If
                    Next
                End If
            Else
                lblCotaDeLadoSeleccionada.Text = "--"
                laCota.HighLight = False
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                Me.Activate()
            End If
        Else
            lblCotaDeLadoSeleccionada.Text = "--"
            laCota.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            Me.Activate()
        End If

    End Sub

    Private Sub btnAceptaAtributosDeslinde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptaAtributosDeslinde.Click
        '-------------------------------------------------------------------------------------------------------------
        '
        'DESLINDE
        '
        'Se acepto la seleccion.
        '
        'agregar atributos a la cota del deslinde
        '1) Tipo = "Deslinde" (no se ingresa)
        '2) Parcela, asociar cota a pl. existente. De aqui sale denominación de la parcela (se selecciona de un combo)
        '3) Linderos. Campo de texto.
        '4) Lado. Seleccionar de un combo tipo de lado (frente, fondo, etc)
        '5) Rumbo. Seleccionar rumbo de un combo
        '6) Medida (es la medida de la cota)
        '--------------------------------------------------------------------------------------------------------------
        If laCota Is Nothing Then
            MsgBox("No hay selección de entidades válidas (cota)")
            Exit Sub
        End If

        If lblParcela.Text = "" Or lblParcela.Text = "--" Then
            MsgBox("Faltan datos (la parcela).")
            Exit Sub
        End If

        If txtLinderos Is Nothing Or txtLinderos.Text = "" Then
            MsgBox("Faltan datos (linderos).")
            Exit Sub
        End If

        If cmbTipoLado.Text = "" Then
            MsgBox("Faltan datos (tipo de lado).")
            Exit Sub
        End If

        If cmbRumbo.Text = "" Then
            MsgBox("Faltan datos (rumbo).")
            Exit Sub
        End If

        If lblMedida.Text = "" Then
            MsgBox("Faltan datos (medida del lado).")
            Exit Sub
        End If

        If laCota.XProperties.Count > 0 Then
            '------------
            'hay edicion
            '------------
            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In laCota.XProperties
                If atributo.Name = "Parcela" Then
                    atributo.PropValue = lblParcela.Text
                ElseIf atributo.Name = "Linderos" Then
                    atributo.PropValue = txtLinderos.Text
                ElseIf atributo.Name = "Lado" Then
                    atributo.PropValue = cmbTipoLado.Text
                ElseIf atributo.Name = "Rumbo" Then
                    atributo.PropValue = cmbRumbo.Text
                ElseIf atributo.Name = "Medida" Then
                    atributo.PropValue = lblMedida.Text
                End If
            Next
            laCota.ToolTip = "Deslinde de Parcela " & lblParcela.Text.ToString & vbCrLf & _
                             "Linderos: " & txtLinderos.Text & vbCrLf & _
                             "Lado: " & cmbTipoLado.Text & vbCrLf & _
                             "Medida: " & Format(laCota.Measurement, "0.0000").ToString & vbCrLf & _
                             "Rumbo " & cmbRumbo.Text
        Else
            '---------------------------------
            'primera vez que se cargan los att
            '---------------------------------
            Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Tipo"
            xProp.PropValue = "Deslinde"
            laCota.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Parcela"
            xProp.PropValue = lblParcela.Text
            laCota.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Linderos"
            xProp.PropValue = txtLinderos.Text
            laCota.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Lado"
            xProp.PropValue = cmbTipoLado.Text
            laCota.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Rumbo"
            xProp.PropValue = cmbRumbo.Text
            laCota.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Medida"
            xProp.PropValue = Format(laCota.Measurement, "0.0000")
            laCota.XProperties.AddItem(xProp)

            laCota.ToolTip = "Deslinde de Parcela " & lblParcela.Text.ToString & vbCrLf & _
                             "Linderos: " & txtLinderos.Text & vbCrLf & _
                             "Lado: " & cmbTipoLado.Text & vbCrLf & _
                             "Medida: " & Format(laCota.Measurement, "0.0000").ToString & vbCrLf & _
                             "Rumbo " & cmbRumbo.Text
        End If
        laCota.HighLight = False
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
    End Sub

    Private Sub btnCancelaAtributosDeslinde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelaAtributosDeslinde.Click

        '------------------------------------------------------------------
        '
        ' DESLINDE
        '
        'Boton "Cancelar"
        '
        '------------------------------------------------------------------
        txtLinderos.Text = ""
        cmbTipoLado.Text = ""
        cmbRumbo.Text = ""
        If Not laCota Is Nothing Then
            laCota.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
    End Sub

#Region "parcela"
    Private Sub btnSeleccionarPoligono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarPoligono.Click
        '--------------------------------------------------------------------------------------
        '
        'PARCELA
        '
        'Al hacer click en este boton, se selecciona una PARCELA 
        'El poligono debe ser cerrado.
        '
        '--------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

        'Definir poligono..
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar PARCELA (debe ser una polilinea cerrada)")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            If Not fig Is Nothing Then                                                           'hay algo seleccionado
                If fig._TypeName = "vdPolyline" Then                                             'es una polilinea
                    lapolilinea = New VectorDraw.Professional.vdFigures.vdPolyline
                    lapolilinea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    lapolilinea.setDocumentDefaults()
                    lapolilinea = CType(fig, VectorDraw.Professional.vdFigures.vdPolyline)
                    Dim PolAbiertaCerrada As VectorDraw.Professional.Constants.VdConstPlineFlag = lapolilinea.Flag
                    If PolAbiertaCerrada = 0 Then
                        MsgBox("Entidad no válida (Solo polilineas cerradas)")
                        lapolilinea.Dispose()
                        lapolilinea = Nothing
                        Me.Activate()
                        Exit Sub
                    End If
                    If lapolilinea.XProperties.Count > 0 Then
                        'si tiene xprop ojo, revisar si no es otra cosa (un pol de dom o una sup de ph):rechazar la selección.
                        Dim xPropABuscar As VectorDraw.Professional.vdObjects.vdXProperty = lapolilinea.XProperties.FindName("Tipo")
                        If Not xPropABuscar Is Nothing Then
                            If xPropABuscar.PropValue.ToString = "Parcela" Then
                                '----------------------------------
                                'Si es edicion el ok sale por aca..
                                '----------------------------------
                                If lapolilinea.Area < 0 Then
                                    area = lapolilinea.Area * -1
                                Else
                                    area = lapolilinea.Area
                                End If

                                lblParcelaSeleccionada.Text = "Identificador: " & lapolilinea.Handle.ToString & ", Sup: " & Format(area, "0.0000").ToString

                                xPropABuscar = lapolilinea.XProperties.FindName("Nro")
                                If Not xPropABuscar Is Nothing Then
                                    txtParcelaNombreNro.Text = xPropABuscar.PropValue.ToString
                                    txtParcN.Text = txtParcelaNombreNro.Text
                                    xPropABuscar = Nothing
                                End If

                                xPropABuscar = lapolilinea.XProperties.FindName("Letra")
                                If Not xPropABuscar Is Nothing Then
                                    txtParcelaNombreLetra.Text = xPropABuscar.PropValue.ToString
                                    xPropABuscar = Nothing
                                End If

                                lblParcela.Text = txtParcelaNombreNro.Text & " " & txtParcelaNombreLetra.Text

                                xPropABuscar = lapolilinea.XProperties.FindName("Area")
                                If Not xPropABuscar Is Nothing Then
                                    lblSuperficieGuardada.Text = xPropABuscar.PropValue.ToString
                                    xPropABuscar = Nothing
                                End If

                                lapolilinea.HighLight = True
                                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                                Me.Activate()
                                Exit Sub
                            Else
                                MsgBox("Entidad no válida (ya esta asignada con otra etiqueta de tipo de entidad")
                                lapolilinea.Dispose()
                                lapolilinea = Nothing
                                Me.Activate()
                                Exit Sub
                            End If
                        End If
                    Else
                        lapolilinea.HighLight = True
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                        If lapolilinea.Area < 0 Then
                            area = lapolilinea.Area * -1
                        Else
                            area = lapolilinea.Area
                        End If
                        lblParcelaSeleccionada.Text = "Identificador: " & lapolilinea.Handle.ToString & ", Sup: " & Format(area, "0.0000").ToString
                        Me.Activate()
                    End If
                Else
                    MsgBox("Entidad no válida (Solo polilineas cerradas)")
                    lapolilinea = Nothing
                    Me.Activate()
                End If
            Else
                MsgBox("Seleccionar una polilineas cerrada")
                lapolilinea = Nothing
                Me.Activate()
            End If
        Else
            lapolilinea = Nothing
            Me.Activate()
        End If

    End Sub

    Private Sub btnAceptaAttParcela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptaAttParcela.Click
        '------------------------------------------------------------------
        '
        'PARCELA
        '
        'Se acepto la seleccion
        '
        'agregar atributos al poligono de la PARCELA
        '1) Tipo  = "Parcela" (no se ingresa)
        '2) Nro   = Numero de la denominación de la parcela (se ingresa)
        '3) Letra = Letra de la denominación de la parcela (se ingresa)
        '4) Area  = dbl (se calcula)
        '-------------------------------------------------------------------
        If lapolilinea Is Nothing Then
            MsgBox("No hay seleccion de entidades validas (polilineas cerradas)")
            Exit Sub
        End If

        If txtParcelaNombreLetra.Text = "" Or txtParcelaNombreNro.Text = "" Or lblParcelaSeleccionada.Text = "--" Or lblParcelaSeleccionada.Text = "" Then
            MsgBox("Faltan datos.")
            Exit Sub
        End If

        If lapolilinea.XProperties.Count > 0 Then
            '--------------
            'hay edicion
            '--------------
            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In lapolilinea.XProperties
                If atributo.Name = "Nro" Then
                    atributo.PropValue = txtParcelaNombreNro.Text
                ElseIf atributo.Name = "Letra" Then
                    atributo.PropValue = txtParcelaNombreLetra.Text
                ElseIf atributo.Name = "Area" Then
                    atributo.PropValue = lblSuperficieGuardada.Text
                End If
            Next
            lblParcela.Text = txtParcelaNombreNro.Text & " " & txtParcelaNombreLetra.Text
            txtParcN.Text = txtParcelaNombreNro.Text
            txtParcL.Text = txtParcelaNombreLetra.Text

            If lapolilinea.Area < 0 Then
                area = lapolilinea.Area * -1
            Else
                area = lapolilinea.Area
            End If
            lapolilinea.ToolTip = "Parcela " & txtParcelaNombreNro.Text.ToString & txtParcelaNombreLetra.Text.ToString & ", Sup: " & Format(area, "0.0000").ToString
        Else
            '---------------------------------
            'primera vez que se cargan los att
            '---------------------------------
            Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty

            If txtParcelaNombreNro.Text <> "" Then
                xProp.Name = "Nro"
                xProp.PropValue = txtParcelaNombreNro.Text
                lapolilinea.XProperties.AddItem(xProp)

                xProp = New VectorDraw.Professional.vdObjects.vdXProperty
                xProp.Name = "Letra"
                xProp.PropValue = txtParcelaNombreLetra.Text
                lapolilinea.XProperties.AddItem(xProp)

                lblParcela.Text = txtParcelaNombreNro.Text & " " & txtParcelaNombreLetra.Text
                txtParcN.Text = txtParcelaNombreNro.Text
                txtParcL.Text = txtParcelaNombreLetra.Text
            End If

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Tipo"
            xProp.PropValue = "Parcela"
            lapolilinea.XProperties.AddItem(xProp)

            If lapolilinea.Area < 0 Then
                area = lapolilinea.Area * -1
            Else
                area = lapolilinea.Area
            End If
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Area"
            xProp.PropValue = Format(area, "0.0000")
            lapolilinea.XProperties.AddItem(xProp)

            lapolilinea.ToolTip = "Parcela " & txtParcelaNombreNro.Text.ToString & txtParcelaNombreLetra.Text & ", Sup: " & Format(area, "0.0000").ToString
        End If

        'agregar un bloque con un circulo y dentro la denominacion de la parcela
        agregarBloqueIdParcela(CDbl(Format(area, "0.0000")))

        'finalizar...
        lapolilinea.HighLight = False
        Me.Activate()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

    End Sub

    Private Sub btnCancelaAttParcela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelaAttParcela.Click

        '----------------------------------------------
        '
        ' PARCELA
        '
        ' Boton "Cancelar" 
        '
        '----------------------------------------------
        lblParcelaSeleccionada.Text = "--"
        txtParcelaNombreNro.Text = ""
        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
    End Sub

    Private Function agregarBloqueIdParcela(ByVal area As Double) As Boolean

        '---------------------------------------------------------------------------------------
        '
        ' PARCELA
        '
        'Llamado por btnAceptaAttParcela_Click
        '
        'Dibuja un circulo con la identificacion de la parcela y debajo del circulo la superficie 
        '
        '----------------------------------------------------------------------------------------

        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing
        Dim ptSup As VectorDraw.Geometry.gPoint = Nothing

        '--------------------------------------
        'borrar la inserción y borrar el bloque
        '--------------------------------------
        Dim bloqueBorrar As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("idParcela")
        'primero borrar el vdInsert
        For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If obj._TypeName = "vdInsert" Then
                Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = CType(obj, VectorDraw.Professional.vdFigures.vdInsert)
                If elVdInsert.Block.Name = "idParcela" Then
                    elVdInsert.Invalidate()
                    elVdInsert.Deleted = True
                    elVdInsert.Update()
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(elVdInsert)
                    Exit For
                End If
            End If
        Next
        'sigo ahora borrando el bloque..
        If Not bloqueBorrar Is Nothing Then
            bloqueBorrar.Deleted = True
            bloqueBorrar.Update()
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(bloqueBorrar)
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            frmPHUnidadesFuncionales.limpiarMemoria()
        End If


        Dim bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
        bloque.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloque.setDocumentDefaults()
        bloque.Name = "idParcela"

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar posicion del circulo identificador de la parcela..")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            bloque.Origin = pt
        Else
            Return False
            Exit Function
        End If

        'acata
        Dim circulo As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        circulo.setDocumentDefaults()
        circulo.Center = pt
        circulo.Radius = 2
        bloque.Entities.AddItem(circulo)

        Dim texto As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
        texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        texto.setDocumentDefaults()
        'texto.PenColor.ColorIndex= 3
        texto.TextString = txtParcelaNombreNro.Text & " " & txtParcelaNombreLetra.Text
        'frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "verdana"
        texto.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        texto.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        texto.InsertionPoint = pt
        bloque.Entities.AddItem(texto)
        texto = Nothing

        Dim textoSup As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
        textoSup.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoSup.setDocumentDefaults()
        textoSup.TextString = "Sup: " & area.ToString & " m2"
        textoSup.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoSup.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        ptSup = New VectorDraw.Geometry.gPoint
        ptSup.x = pt.x
        ptSup.y = pt.y - (circulo.Radius * 1.5)
        textoSup.InsertionPoint = ptSup
        bloque.Entities.AddItem(textoSup)

        frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddItem(bloque)

        Dim insertar As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert
        insertar.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        insertar.setDocumentDefaults()

        insertar.Block = bloque
        insertar.InsertionPoint = pt
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(insertar)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Return True

    End Function
#End Region

#Region "nomenclatura"

    Private Sub btnAceptaAtributosNomenclatura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptaAtributosNomenclatura.Click

        '----------------------------------------------------
        '
        ' NOMENCLATURA
        '
        ' Boton "Aceptar" los atributos
        '
        '----------------------------------------------------

        '--------------------------------------
        'borrar la inserción y borrar el bloque
        '--------------------------------------
        If datosLeidosDesdeBloqueExistente Then
            datosLeidosDesdeBloqueExistente = False
            Dim bloqueBorrar As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("nomenclatura")
            'primero borrar el vdInsert
            For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
                If obj Is Nothing Then Exit For
                If obj._TypeName = "vdInsert" Then
                    Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = CType(obj, VectorDraw.Professional.vdFigures.vdInsert)
                    If elVdInsert.XProperties.Count > 0 Then
                        For Each xdata As VectorDraw.Professional.vdObjects.vdXProperty In elVdInsert.XProperties
                            If xdata.Name = "Pdo" Then
                                elVdInsert.Invalidate()
                                elVdInsert.Deleted = True
                                elVdInsert.Update()
                                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(elVdInsert)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
            'sigo ahora borrando el bloque..
            bloqueBorrar.Deleted = True
            bloqueBorrar.Update()
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(bloqueBorrar)
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            frmPHUnidadesFuncionales.limpiarMemoria()
        End If



        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing
        Dim bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
        bloque.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloque.setDocumentDefaults()
        bloque.Name = "nomenclatura"

        If txtPdo.Text = "" Or txtPda.Text = "" Then
            MsgBox("Faltan el Pdo Pda")
            Exit Sub
        End If

        If txtChaL.Text = "" And txtChaN.Text = "" And txtQtaL.Text = "" And txtQtaN.Text = "" _
            And txtMzaL.Text = "" And txtMzaN.Text = "" Then
            MsgBox("Faltan datos. Ingresar Chacra o Quinta o Manzana como mínimo")
            Exit Sub
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar posicion de nomenclatura..")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            bloque.Origin = pt
        Else
            Exit Sub
        End If

        Dim texto As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
        texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        texto.setDocumentDefaults()
        'texto.PenColor.ColorIndex= 3
        texto.TextString = "Cha: " & txtChaN.Text & txtChaL.Text _
            & vbCrLf & "Qta: " & txtQtaN.Text & txtQtaL.Text _
            & vbCrLf & "Mza: " & txtMzaN.Text & txtMzaL.Text
        'frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "verdana"
        texto.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        texto.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        texto.InsertionPoint = pt
        bloque.Entities.AddItem(texto)

        frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddItem(bloque)


        Dim insertar As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert
        insertar.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        insertar.setDocumentDefaults()

        'definir las xproperties del insert del bloque con los datos de la nomenclatura.

        Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty
        xProp.Name = "Pdo"
        xProp.PropValue = txtPdo.Text.ToString
        insertar.XProperties.AddItem(xProp)

        xProp = New VectorDraw.Professional.vdObjects.vdXProperty
        xProp.Name = "Pda"
        xProp.PropValue = txtPda.Text.ToString
        insertar.XProperties.AddItem(xProp)

        xProp = New VectorDraw.Professional.vdObjects.vdXProperty
        xProp.Name = "Tipo"
        xProp.PropValue = "Nomenclatura"
        insertar.XProperties.AddItem(xProp)

        If txtCirc.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Circ"
            xProp.PropValue = txtCirc.Text.ToString
            insertar.XProperties.AddItem(xProp)
        End If

        If txtSecc.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Secc"
            xProp.PropValue = txtSecc.Text.ToString
            insertar.XProperties.AddItem(xProp)
        End If
        If txtChaN.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Chan"
            xProp.PropValue = CInt(txtChaN.Text)
            insertar.XProperties.AddItem(xProp)
        End If
        If txtChaL.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Chal"
            xProp.PropValue = txtChaL.Text.ToString
            insertar.XProperties.AddItem(xProp)
        End If
        If txtQtaN.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Qtan"
            xProp.PropValue = CInt(txtQtaN.Text)
            insertar.XProperties.AddItem(xProp)
        End If
        If txtQtaL.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Qtal"
            xProp.PropValue = txtQtaL.Text.ToString
            insertar.XProperties.AddItem(xProp)
        End If
        If txtFraN.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Fran"
            xProp.PropValue = CInt(txtFraN.Text)
            insertar.XProperties.AddItem(xProp)
        End If
        If txtFraL.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Fral"
            xProp.PropValue = txtFraL.Text.ToString
            insertar.XProperties.AddItem(xProp)
        End If
        If txtMzaN.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Mzan"
            xProp.PropValue = CInt(txtMzaN.Text)
            insertar.XProperties.AddItem(xProp)
        End If
        If txtMzaL.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Mzal"
            xProp.PropValue = txtMzaL.Text.ToString
            insertar.XProperties.AddItem(xProp)
        End If
        If txtSubPl.Text <> "" Then
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Subp"
            xProp.PropValue = txtSubPl.Text.ToString
            insertar.XProperties.AddItem(xProp)
        End If


        insertar.Block = bloque
        insertar.InsertionPoint = pt
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(insertar)
        Me.Activate()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)


    End Sub

    Private Sub btnCancelaAtributosNomenclatura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelaAtributosNomenclatura.Click

        '---------------------------------------------------------
        '
        ' NOMENCLATURA 
        '
        ' Boton "Cancelar" atributos de nomenclatura
        '
        '---------------------------------------------------------

        txtPdo.Text = ""
        txtPda.Text = ""
        txtCirc.Text = ""
        txtSecc.Text = ""
        txtChaN.Text = ""
        txtChaL.Text = ""
        txtQtaN.Text = ""
        txtQtaL.Text = ""
        txtFraN.Text = ""
        txtFraL.Text = ""
        txtMzaN.Text = ""
        txtMzaL.Text = ""
        txtSubPl.Text = ""

    End Sub

    Private Sub btnSeleccionarBloqueNomenclaturaExistente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarBloqueNomenclaturaExistente.Click

        '-------------------------------------------------------
        '
        ' NOMENCLATURA
        '
        ' Boton "Seleccionar bloque nomenclatura existente"
        '
        '--------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        Dim insertar As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert
        insertar.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        insertar.setDocumentDefaults()

        Dim bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
        bloque.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloque.setDocumentDefaults()
        bloque.Name = "nomenclatura"

        Dim xPropABuscar As VectorDraw.Professional.vdObjects.vdXProperty = New VectorDraw.Professional.vdObjects.vdXProperty

        Dim figuraSeleccionada As VectorDraw.Professional.vdPrimaries.vdFigure = Nothing
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar bloque de nomenclatura..")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(figuraSeleccionada, pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            If figuraSeleccionada._TypeName = "vdInsert" Then
                insertar = CType(figuraSeleccionada, VectorDraw.Professional.vdFigures.vdInsert)
                If insertar.Block.Name = "nomenclatura" Then
                    datosLeidosDesdeBloqueExistente = True
                    xPropABuscar = insertar.XProperties.FindName("Pdo")
                    If Not xPropABuscar Is Nothing Then
                        txtPdo.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Pda")
                    If Not xPropABuscar Is Nothing Then
                        txtPda.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Circ")
                    If Not xPropABuscar Is Nothing Then
                        txtCirc.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Secc")
                    If Not xPropABuscar Is Nothing Then
                        txtSecc.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Chan")
                    If Not xPropABuscar Is Nothing Then
                        txtChaN.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Chal")
                    If Not xPropABuscar Is Nothing Then
                        txtChaL.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Qtan")
                    If Not xPropABuscar Is Nothing Then
                        txtQtaN.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Qtal")
                    If Not xPropABuscar Is Nothing Then
                        txtQtaL.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Fran")
                    If Not xPropABuscar Is Nothing Then
                        txtFraN.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Fral")
                    If Not xPropABuscar Is Nothing Then
                        txtFraL.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Mzan")
                    If Not xPropABuscar Is Nothing Then
                        txtMzaN.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Mzal")
                    If Not xPropABuscar Is Nothing Then
                        txtMzaL.Text = xPropABuscar.PropValue.ToString
                    End If
                    xPropABuscar = insertar.XProperties.FindName("Subp")
                    If Not xPropABuscar Is Nothing Then
                        txtSubPl.Text = xPropABuscar.PropValue.ToString
                    End If

                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        Me.Activate()
    End Sub
#End Region

#Region "Distancia a esquina"

    Private Sub btnSeleccionarDist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarDist.Click
        '--------------------------------------------------------------------------------------------------------
        '
        'DISTANCIA A ESQUINA 
        '
        'seleccion de COTA de distancia a esquina.
        '
        'Al hacer click en este boton, se selecciona una COTA que pertenece a una distancia a esquina 
        '--------------------------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        If Not laCotaDistanciaEsquina Is Nothing Then
            laCotaDistanciaEsquina.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar COTA de distancia a esquina")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            If Not fig Is Nothing Then                                                           'hay algo seleccionado
                If fig._TypeName = "vdDimension" Then
                    laCotaDistanciaEsquina = New VectorDraw.Professional.vdFigures.vdDimension
                    laCotaDistanciaEsquina.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    laCotaDistanciaEsquina.setDocumentDefaults()
                    laCotaDistanciaEsquina = CType(fig, VectorDraw.Professional.vdFigures.vdDimension)
                    lblCotaDistanciaEsquinaSeleccionada.Text = "Distancia leida: " & Format(laCotaDistanciaEsquina.Measurement, "0.00").ToString
                    'lblCotaDistanciaEsquinaMedida.Text = Format(laCotaDistanciaEsquina.Measurement, "0.00")
                    laCotaDistanciaEsquina.HighLight = True
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    Me.Activate()
                Else
                    MsgBox("La entidad seleccionada no es una cota")
                    lblCotaDistanciaEsquinaSeleccionada.Text = "Distancia guardada"
                    laCotaDistanciaEsquina.HighLight = False
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    Me.Activate()
                    Exit Sub
                End If

                If laCotaDistanciaEsquina.XProperties.Count > 0 Then
                    For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In laCotaDistanciaEsquina.XProperties
                        If atributo.Name = "Medida" Then
                            lblCotaDistanciaEsquinaMedida.Text = "Distancia guardada " & atributo.PropValue.ToString
                        End If
                    Next
                End If
            Else
                lblCotaDistanciaEsquinaSeleccionada.Text = "Distancia guardada"
                laCotaDistanciaEsquina.HighLight = False
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                Me.Activate()
            End If
        Else
            lblCotaDistanciaEsquinaSeleccionada.Text = "Distancia guardada"
            laCotaDistanciaEsquina.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            Me.Activate()
        End If

    End Sub

    Private Sub btnSeleccionarAnchoCalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarAnchoCalle.Click
        '---------------------------------------------------------------------------------------------------------------
        '
        'DISTANCIA A ESQUINA 
        '
        'seleccion de COTA del ancho de calle.
        '
        'Al hacer click en este boton, se selecciona una COTA que pertenece al ancho de calle de la distancia a esquina 
        '----------------------------------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        If Not laCotaDistanciaEsquinaAnchoCalle Is Nothing Then
            laCotaDistanciaEsquinaAnchoCalle.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar COTA de ancho de calle perteneciente a la distancia a esquina")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            If Not fig Is Nothing Then                                                           'hay algo seleccionado
                If fig._TypeName = "vdDimension" Then
                    laCotaDistanciaEsquinaAnchoCalle = New VectorDraw.Professional.vdFigures.vdDimension
                    laCotaDistanciaEsquinaAnchoCalle.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    laCotaDistanciaEsquinaAnchoCalle.setDocumentDefaults()
                    laCotaDistanciaEsquinaAnchoCalle = CType(fig, VectorDraw.Professional.vdFigures.vdDimension)
                    lblCotaDistanciaEsquinaSeleccionadaAnchoCalle.Text = "Ancho calle leido: " & Format(laCotaDistanciaEsquinaAnchoCalle.Measurement, "0.00").ToString
                    'lblCotaDistanciaEsquinaMedidaAnchoCalle.Text = Format(laCotaDistanciaEsquinaAnchoCalle.Measurement, "0.00")
                    laCotaDistanciaEsquinaAnchoCalle.HighLight = True
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    Me.Activate()
                Else
                    MsgBox("La entidad seleccionada no es una cota")
                    lblCotaDistanciaEsquinaSeleccionadaAnchoCalle.Text = "Ancho guardado"
                    laCotaDistanciaEsquinaAnchoCalle.HighLight = False
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    Me.Activate()
                    Exit Sub
                End If

                If laCotaDistanciaEsquinaAnchoCalle.XProperties.Count > 0 Then
                    For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In laCotaDistanciaEsquinaAnchoCalle.XProperties
                        If atributo.Name = "Medida" Then
                            lblCotaDistanciaEsquinaMedidaAnchoCalle.Text = "Ancho guardado " & atributo.PropValue.ToString
                        End If
                    Next
                End If
            Else
                lblCotaDistanciaEsquinaSeleccionadaAnchoCalle.Text = "Ancho guardado"
                laCotaDistanciaEsquinaAnchoCalle.HighLight = False
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                Me.Activate()
            End If
        Else
            lblCotaDistanciaEsquinaSeleccionadaAnchoCalle.Text = "Ancho guardado"
            laCotaDistanciaEsquinaAnchoCalle.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            Me.Activate()
        End If

    End Sub

    Private Sub btnSeleccionarTexto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarTexto.Click
        '---------------------------------------------------------------------------------------------------------------
        '
        'DISTANCIA A ESQUINA 
        '
        'seleccion del TEXTO ancho de calle.
        '
        'Al hacer click en este boton, se selecciona una TEXTO que pertenece al ancho de calle de la distancia a esquina 
        '----------------------------------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        If Not textoDistanciaEsquinaNombreCalle Is Nothing Then
            textoDistanciaEsquinaNombreCalle.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar TEXTO del nombre de calle perteneciente a la distancia a esquina")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            If Not fig Is Nothing Then                                                           'hay algo seleccionado
                If fig._TypeName = "vdText" Then
                    textoDistanciaEsquinaNombreCalle = New VectorDraw.Professional.vdFigures.vdText
                    textoDistanciaEsquinaNombreCalle.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    textoDistanciaEsquinaNombreCalle.setDocumentDefaults()
                    textoDistanciaEsquinaNombreCalle = CType(fig, VectorDraw.Professional.vdFigures.vdText)
                    txtDistanciaEsquinaNombreCalleSeleccionada.Text = "Nombre de cale leido: " & textoDistanciaEsquinaNombreCalle.TextString
                    'txtDistanciaEsquinaNombreCalle.Text = textoDistanciaEsquinaNombreCalle.TextString
                    textoDistanciaEsquinaNombreCalle.HighLight = True
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    Me.Activate()
                Else
                    MsgBox("La entidad seleccionada no es un texto")
                    txtDistanciaEsquinaNombreCalleSeleccionada.Text = "Nombre de calle guardado"
                    textoDistanciaEsquinaNombreCalle.HighLight = False
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    Me.Activate()
                    Exit Sub
                End If

                If textoDistanciaEsquinaNombreCalle.XProperties.Count > 0 Then
                    For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In textoDistanciaEsquinaNombreCalle.XProperties
                        If atributo.Name = "Texto" Then
                            txtDistanciaEsquinaNombreCalle.Text = "Nombre de calle guardado " & atributo.PropValue.ToString
                        End If
                    Next
                End If
            Else
                txtDistanciaEsquinaNombreCalleSeleccionada.Text = "Nombre de calle guardado"
                textoDistanciaEsquinaNombreCalle.HighLight = False
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                Me.Activate()
            End If
        Else
            txtDistanciaEsquinaNombreCalleSeleccionada.Text = "Nombre de calle guardado"
            textoDistanciaEsquinaNombreCalle.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            Me.Activate()
        End If

    End Sub

    Private Sub btnAceptaAttDistEsq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptaAttDistEsq.Click
        '-------------------------------------------------------------------------------------------------------------
        '
        'DISTANCIA A ESQUINA 
        '
        'Se acepto la seleccion.
        '
        'agregar atributos a la COTA de la distancia a esquina, la COTA del ancho de calle y el TEXTO del nombre de calle.
        '
        'COTA DISTANCIA A ESQUINA
        '1) Tipo = "DEsquinaCota" (no se ingresa)
        '2) Medida = Es la medida de la cota
        '
        'COTA DE ANCHO DE CALLE
        '1) Tipo = "DEsquinaCotaAnchoCalle" (no se ingresa)
        '6) Medida = Es la medida de la cota
        '
        'TEXTO DEL NOMBRE DE CALLE
        '1) Tipo = "DEsquinaNombreCalle" (no se ingresa)
        '2) Texto = Es el texto del nombre de calle
        '--------------------------------------------------------------------------------------------------------------
        If laCotaDistanciaEsquina.Measurement = 0.0 Then
            MsgBox("Faltan datos (la cota de distancia a esquina, de la distancia a esquina)")
            Exit Sub
        End If

        If laCotaDistanciaEsquinaAnchoCalle.Measurement = 0.0 Then
            MsgBox("Faltan datos (la cota del ancho de calle, de la distancia a esquina)")
            Exit Sub
        End If

        If textoDistanciaEsquinaNombreCalle.TextString = "" Then
            MsgBox("Faltan datos (el nombre de calle, de la distancia a esquina)")
            Exit Sub
        End If


        '===========================================================================================================
        ' cota dist. esq.
        '===========================================================================================================
        If laCotaDistanciaEsquina.XProperties.Count > 0 Then
            '------------
            'hay edicion
            '------------
            Dim partes() As String
            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In laCotaDistanciaEsquina.XProperties
                If atributo.Name = "Medida" Then
                    partes = lblCotaDistanciaEsquinaSeleccionada.Text.Split(":")
                    atributo.PropValue = Trim(partes(1))
                End If
            Next
            laCotaDistanciaEsquina.ToolTip = "Distancia a esquina: " & Trim(partes(1))

        Else
            '---------------------------------
            'primera vez que se cargan los att
            '---------------------------------
            Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Tipo"
            xProp.PropValue = "DEsquinaCota"
            laCotaDistanciaEsquina.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Medida"
            Dim partes() As String = lblCotaDistanciaEsquinaSeleccionada.Text.Split(":")
            xProp.PropValue = Trim(partes(1))
            laCotaDistanciaEsquina.XProperties.AddItem(xProp)

            laCotaDistanciaEsquina.ToolTip = "Distancia a esquina: " & Trim(partes(1))
        End If


        '===========================================================================================================
        ' cota ancho de calle
        '===========================================================================================================
        If laCotaDistanciaEsquinaAnchoCalle.XProperties.Count > 0 Then
            '------------
            'hay edicion
            '------------
            Dim partes() As String
            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In laCotaDistanciaEsquinaAnchoCalle.XProperties
                If atributo.Name = "Medida" Then
                    partes = lblCotaDistanciaEsquinaSeleccionadaAnchoCalle.Text.Split(":")
                    atributo.PropValue = Trim(partes(1))
                End If
            Next
            laCotaDistanciaEsquinaAnchoCalle.ToolTip = "Distancia a esquina, ancho de calle: " & Trim(partes(1))
        Else
            '---------------------------------
            'primera vez que se cargan los att
            '---------------------------------
            Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Tipo"
            xProp.PropValue = "DEsquinaCotaAnchoCalle"
            laCotaDistanciaEsquinaAnchoCalle.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Medida"
            Dim partes() As String = lblCotaDistanciaEsquinaSeleccionadaAnchoCalle.Text.Split(":")
            xProp.PropValue = Trim(partes(1))
            laCotaDistanciaEsquinaAnchoCalle.XProperties.AddItem(xProp)

            laCotaDistanciaEsquinaAnchoCalle.ToolTip = "Distancia a esquina, ancho de calle: " & Trim(partes(1))
        End If


        '===========================================================================================================
        ' Nombre de calle
        '===========================================================================================================
        If textoDistanciaEsquinaNombreCalle.XProperties.Count > 0 Then
            '------------
            'hay edicion
            '------------
            Dim partes() As String
            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In textoDistanciaEsquinaNombreCalle.XProperties
                If atributo.Name = "Texto" Then
                    partes = txtDistanciaEsquinaNombreCalleSeleccionada.Text.Split(":")
                    atributo.PropValue = Trim(partes(1))
                End If
            Next
            textoDistanciaEsquinaNombreCalle.ToolTip = "Distancia a esquina, Calle: " & Trim(partes(1))

        Else
            '---------------------------------
            'primera vez que se cargan los att
            '---------------------------------
            Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Tipo"
            xProp.PropValue = "DEsquinaNombreCalle"
            textoDistanciaEsquinaNombreCalle.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Texto"
            Dim partes() As String = txtDistanciaEsquinaNombreCalleSeleccionada.Text.Split(":")
            xProp.PropValue = Trim(partes(1))
            textoDistanciaEsquinaNombreCalle.XProperties.AddItem(xProp)

            textoDistanciaEsquinaNombreCalle.ToolTip = "Distancia a esquina, Calle: " & Trim(partes(1))

        End If

        laCotaDistanciaEsquina.HighLight = False
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

    End Sub

#End Region

    Private Sub btnSeleccionarPoligonoEdificio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarPoligonoEdificio.Click
        '--------------------------------------------------------------------------------------
        '
        'POLIGONO DE EDIFICIO
        '
        'Al hacer click en este boton, se selecciona un poligono de edificio que debe ser una polilinea cerrada
        '
        '--------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

        'Definir poligono..
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar POLIGONO EDIFICIO (debe ser una polilinea cerrada)")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            If Not fig Is Nothing Then                                                           'hay algo seleccionado
                If fig._TypeName = "vdPolyline" Then                                             'es una polilinea
                    lapolilinea = New VectorDraw.Professional.vdFigures.vdPolyline
                    lapolilinea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    lapolilinea.setDocumentDefaults()
                    lapolilinea = CType(fig, VectorDraw.Professional.vdFigures.vdPolyline)
                    Dim PolAbiertaCerrada As VectorDraw.Professional.Constants.VdConstPlineFlag = lapolilinea.Flag
                    If PolAbiertaCerrada = 0 Then
                        MsgBox("Entidad no válida (Solo polilineas cerradas)")
                        lapolilinea.Dispose()
                        lapolilinea = Nothing
                        Me.Activate()
                        Exit Sub
                    End If
                    If lapolilinea.XProperties.Count > 0 Then
                        'si tiene xprop ojo, revisar si no es otra cosa (un pol de dom o una sup de ph):rechazar la selección.
                        Dim xPropABuscar As VectorDraw.Professional.vdObjects.vdXProperty = lapolilinea.XProperties.FindName("Tipo")
                        If Not xPropABuscar Is Nothing Then
                            If xPropABuscar.PropValue.ToString <> "PEdificio" Then
                                MsgBox("La polilinea seleccionada no es un polígono de edificio")
                                Exit Sub
                            End If

                            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In lapolilinea.XProperties
                                If atributo.Name = "Numero" Then
                                    nudNumeroPoligono.Value = CInt(atributo.PropValue)
                                ElseIf atributo.Name = "Area" Then
                                    lblArea.Text = atributo.PropValue.ToString
                                ElseIf atributo.Name = "TipoArea" Then
                                    cmbTipoArea.Text = atributo.PropValue.ToString
                                ElseIf atributo.Name = "Formulario" Then
                                    txtFormulario.Text = atributo.PropValue.ToString
                                ElseIf atributo.Name = "Planta" Then
                                    txtPlanta.Text = atributo.PropValue.ToString
                                End If
                            Next
                            Me.Activate()
                            Exit Sub
                        Else
                            MsgBox("Entidad no válida (ya esta asignada con otra etiqueta de tipo de entidad")
                            lapolilinea.Dispose()
                            lapolilinea = Nothing
                            Me.Activate()
                            Exit Sub
                        End If
                    Else
                        lapolilinea.HighLight = True
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                        If lapolilinea.Area < 0 Then
                            area = lapolilinea.Area * -1
                        Else
                            area = lapolilinea.Area
                        End If
                        lblPoligonoEdificioSeleccionado.Text = "Identificador: " & lapolilinea.Handle.ToString & ", Sup: " & Format(area, "0.0000").ToString
                        Me.Activate()
                    End If
                Else
                    MsgBox("Entidad no válida (Solo polilineas cerradas)")
                    lapolilinea = Nothing
                    Me.Activate()
                End If
            Else
                MsgBox("Seleccionar una polilineas cerrada")
                lapolilinea = Nothing
                Me.Activate()
            End If
        Else
            lapolilinea = Nothing
            Me.Activate()
        End If

    End Sub


    Private Sub btnCancelaPoligonoEdificio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelaPoligonoEdificio.Click

        nudNumeroPoligono.Value = 1
        lblArea.Text = ""
        txtFormulario.Text = ""
        txtPlanta.Text = ""
        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
    End Sub


    Private Sub btnAceptaPoligonoEdificio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptaPoligonoEdificio.Click
        '-------------------------------------------
        '
        'POLIGONO EDIFICIO
        '
        'Se aceptó la seleccion
        '
        'agregar atributos al POLIGONO EDIFICIO 
        '1) Tipo = "PEdificio"
        '2) Numero =
        '3) Area =
        '4) TipoArea =
        '5) Formulario =
        '6) Planta =
        '-------------------------------------------
        If lapolilinea Is Nothing Then
            MsgBox("No hay seleccion de entidades validas (polilineas cerradas)")
            Exit Sub
        End If

        If txtParcelaNombreLetra.Text = "" Or txtParcelaNombreNro.Text = "" Or lblParcelaSeleccionada.Text = "--" Or lblParcelaSeleccionada.Text = "" Then
            MsgBox("Faltan los datos de la parcela.")
            Exit Sub
        End If

        Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty
        Dim atributo As New VectorDraw.Professional.vdObjects.vdXProperty
        If lapolilinea.XProperties.Count > 0 Then
            '--------------
            'hay edicion
            '--------------
            atributo = lapolilinea.XProperties.FindName("Numero")
            If Not atributo Is Nothing Then
                atributo.PropValue = nudNumeroPoligono.Value
            Else
                xProp = New VectorDraw.Professional.vdObjects.vdXProperty
                xProp.Name = "Numero"
                xProp.PropValue = nudNumeroPoligono.Value
                lapolilinea.XProperties.AddItem(xProp)
            End If
            atributo = Nothing

            atributo = lapolilinea.XProperties.FindName("Area")
            If Not atributo Is Nothing Then
                If lapolilinea.Area < 0 Then
                    area = lapolilinea.Area * -1
                Else
                    area = lapolilinea.Area
                End If
                lblArea.Text = area.ToString
                atributo.PropValue = area
            Else
                If lapolilinea.Area < 0 Then
                    area = lapolilinea.Area * -1
                Else
                    area = lapolilinea.Area
                End If
                xProp = New VectorDraw.Professional.vdObjects.vdXProperty
                xProp.Name = "Area"
                xProp.PropValue = Format(area, "0.0000")
                lapolilinea.XProperties.AddItem(xProp)
            End If
            atributo = Nothing

            atributo = lapolilinea.XProperties.FindName("TipoArea")
            If Not atributo Is Nothing Then
                atributo.PropValue = cmbTipoArea.Text
            Else
                xProp = New VectorDraw.Professional.vdObjects.vdXProperty
                xProp.Name = "TipoArea"
                xProp.PropValue = cmbTipoArea.Text
                lapolilinea.XProperties.AddItem(xProp)
            End If
            atributo = Nothing

            atributo = lapolilinea.XProperties.FindName("Formulario")
            If Not atributo Is Nothing Then
                atributo.PropValue = txtFormulario.Text
            Else
                xProp = New VectorDraw.Professional.vdObjects.vdXProperty
                xProp.Name = "Formulario"
                xProp.PropValue = txtFormulario.Text
                lapolilinea.XProperties.AddItem(xProp)
            End If
            atributo = Nothing

            atributo = lapolilinea.XProperties.FindName("Planta")
            If Not atributo Is Nothing Then
                atributo.PropValue = txtPlanta.Text
            Else
                xProp = New VectorDraw.Professional.vdObjects.vdXProperty
                xProp.Name = "Planta"
                xProp.PropValue = txtPlanta.Text
                lapolilinea.XProperties.AddItem(xProp)
            End If
            atributo = Nothing

            lapolilinea.ToolTip = "Poligono Edificio " & nudNumeroPoligono.Value.ToString & ", Sup: " & Format(area, "0.0000").ToString & " Formulario: " & txtFormulario.Text.ToString & " Planta: " & txtPlanta.Text.ToString & " Tipo superficie: " & cmbTipoArea.Text
        Else
            '---------------------------------
            'primera vez que se cargan los att
            '---------------------------------
            'Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty

            xProp.Name = "Tipo"
            xProp.PropValue = "PEdificio"
            lapolilinea.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Numero"
            xProp.PropValue = nudNumeroPoligono.Value
            lapolilinea.XProperties.AddItem(xProp)

            If lapolilinea.Area < 0 Then
                area = lapolilinea.Area * -1
            Else
                area = lapolilinea.Area
            End If
            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Area"
            xProp.PropValue = Format(area, "0.0000")
            lapolilinea.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Formulario"
            xProp.PropValue = txtFormulario.Text
            lapolilinea.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Planta"
            xProp.PropValue = txtPlanta.Text
            lapolilinea.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "TipoArea"
            xProp.PropValue = cmbTipoArea.Text
            lapolilinea.XProperties.AddItem(xProp)

            lapolilinea.ToolTip = "Poligono Edificio " & nudNumeroPoligono.Value.ToString & ", Sup: " & Format(area, "0.0000").ToString & " Formulario: " & txtFormulario.Text.ToString & " Planta: " & txtPlanta.Text.ToString & " Tipo superficie: " & cmbTipoArea.Text
        End If

        'agregar un bloque con un circulo y dentro la denominacion de la parcela
        'agregarBloqueIdParcela(CDbl(Format(area, "0.0000")))

        'finalizar...
        lapolilinea.HighLight = False
        Me.Activate()
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

    End Sub

End Class
