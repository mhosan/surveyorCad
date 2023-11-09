Imports System.Windows.Forms
Imports System.Data

Public Class frmPHPoligonoDominio

    Public WithEvents baseControl As VectorDraw.Professional.Control.VectorDrawBaseControl
    Public WithEvents doc As VectorDraw.Professional.vdObjects.vdDocument
    Public fig As VectorDraw.Professional.vdPrimaries.vdFigure = Nothing
    Public bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
    Dim punto2 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    Dim punto3 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    Dim linea1 As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
    Dim lapolilinea As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline

    Private Sub frmPHPoligonoDominio_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        frmPHUnidadesFuncionales.cargarGrillaUF()
        cargarPoligonosDominio()

    End Sub

    Private Sub doc_ActionEnd(ByVal sender As Object, ByVal actionName As String) Handles doc.ActionEnd
        '------------------------------------------------------------------------------------------------------------------
        ' esto es para volver a activar esta pantalla cuando se minimizó (para realizar alguna accion) y la accion terminó.
        ' en ese momento se produce el evento ActionEnd
        '------------------------------------------------------------------------------------------------------------------
        Me.Activate()
    End Sub

    Private Sub baseControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles baseControl.KeyDown
        '------------------------------------------------------------------------------------------------------------------
        ' esto es para volver a activar esta pantalla cuando se minimizó (para realizar alguna accion) y la accion terminó.
        ' en ese momento se produce el evento cuando se oprime una tecla
        '------------------------------------------------------------------------------------------------------------------
        Me.Activate()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
        Me.Close()
    End Sub

    Private Sub cargarPoligonosDominio()
        '-------------------------------------------------------------------------------
        ' cargar los poligonos de dominio que existen en el combo "cmbPoligonosDominio".
        ' este combo esta en la parte inferior de la pantalla y se usa para seleccionar
        ' superficies.
        '-------------------------------------------------------------------------------
        frmPHUnidadesFuncionales.limpiarMemoria()

        cmbPoligonosDominio.Items.Clear()
        'Dim vector(CInt(nudCantUF.Value)) As Integer
        'Dim matrizValores(1000, 3) As String
        'cuantos poligonos y cuales tiene cada uf
        'Dim jj As Integer = 0
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdPolyline" Then
                Dim poligono As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
                poligono = figura
                If poligono.XProperties.Count > 0 Then
                    For Each xprop As VectorDraw.Professional.vdObjects.vdXProperty In poligono.XProperties 'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.XProperties
                        If xprop.Name = "DenominacionPolDominio" Then
                            cmbPoligonosDominio.Items.Add(xprop.PropValue.ToString)
                            '                    vector(CInt(xprop.PropValue)) = vector(CInt(xprop.PropValue)) + 1
                            '                    matrizValores(jj, 0) = xprop.PropValue
                            '                ElseIf xprop.Name = "Tipo" Then
                            '                    matrizValores(jj, 1) = xprop.PropValue
                            '                ElseIf xprop.Name = "Denominacion" Then
                            '                    matrizValores(jj, 2) = xprop.PropValue
                        End If
                    Next
                    '            jj = jj + 1
                End If
            End If
        Next

    End Sub

    Private Sub btnSeleccionarPoligono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarPoligono.Click
        '===============================================================================================
        'Al hacer click en este boton, se selecciona una polilinea, que será considerada como un
        'poligono DE DOMINIO y se le definen sus atributos. La polilinea o el poligono debe ser cerrado.
        '
        '1) Denominación del poligono
        '2) A que UF pertenece
        '3) Tipo: es siempre "Pol_Dominio"
        '===============================================================================================
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

        If cmbUf.Items.Count = 0 Then
            MsgBox("No hay UF's definidas.", vbCritical, aplicacionNombre)
            Exit Sub
        End If

        'Definir poligono..
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar polígono de DOMINIO...")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        If ret = VectorDraw.Actions.StatusCode.Success Then

            If Not fig Is Nothing Then                                                           'hay algo seleccionado

                If fig._TypeName = "vdPolyline" Then                                             'es una polilinea

                    lapolilinea = New VectorDraw.Professional.vdFigures.vdPolyline
                    lapolilinea = CType(fig, VectorDraw.Professional.vdFigures.vdPolyline)

                    If lapolilinea.XProperties.Count = 2 Then
                        Dim xPropAVerificar As VectorDraw.Professional.vdObjects.vdXProperty
                        'si tiene 2 xprop es una superficie, rechazar la selección.
                        xPropAVerificar = lapolilinea.XProperties.FindName("Pertenece")
                        If Not xPropAVerificar Is Nothing Then
                            xPropAVerificar = lapolilinea.XProperties.FindName("tipoSuperficie")
                            If Not xPropAVerificar Is Nothing Then
                                MsgBox("La entidad seleccionada ya esta asignada como una superficie.")
                                Exit Sub
                            Else
                                MsgBox("La entidad seleccionada ya tiene datos asignados.")
                                Exit Sub
                            End If
                        Else
                            MsgBox("La entidad seleccionada ya tiene datos asignados.")
                            Exit Sub
                        End If
                    ElseIf lapolilinea.XProperties.Count = 3 Then
                        'ver si es un poligono de dominio. Si es cargar los datos. 
                        Dim xPropABuscar As VectorDraw.Professional.vdObjects.vdXProperty = lapolilinea.XProperties.FindName("Denominacion")
                        'si esta la xprop "Denominación" es porque es un poligono de dominio
                        If Not xPropABuscar Is Nothing Then
                            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In lapolilinea.XProperties
                                If atributo.Name = "DenominacionPolDominio" Then
                                    txtPolDominioNombre.Text = atributo.PropValue.ToString
                                ElseIf atributo.Name = "Pertenece" Then
                                    cmbUf.Text = atributo.PropValue.ToString
                                End If
                            Next
                            '----------------------------------
                            'Si es edicion el ok sale por aca..
                            '----------------------------------
                            If lapolilinea.Area < 0 Then
                                lblPoligonoDominioSeleccionado.Text = Format(lapolilinea.Area * -1, "0.00").ToString
                            Else
                                lblPoligonoDominioSeleccionado.Text = Format(lapolilinea.Area, "0.00").ToString
                            End If
                            lapolilinea.HighLight = True
                            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                            Dim encontrado As Boolean = False
                            'revisar
                            'For Each item As String In cmbPoligonosDominio.Items
                            '    If item = txtPolDominioNombre.Text.ToString Then
                            '        encontrado = True
                            '        Exit For
                            '    End If
                            'Next
                            'If encontrado = False Then
                            '    cmbPoligonosDominio.Items.Add(txtPolDominioNombre.Text.ToString)
                            'Else
                            '    encontrado = False
                            'End If
                            Me.Activate()
                            Exit Sub
                        End If
                    End If

                    '-------------------------------------------------
                    'la polilinea seleccionada no tiene datos adjuntos.
                    'revisar si esta bien cerrada
                    '--------------------------------------------------
                    Dim PolAbiertaCerrada As VectorDraw.Professional.Constants.VdConstPlineFlag = lapolilinea.Flag
                    If PolAbiertaCerrada = 0 Then
                        lblPoligonoDominioSeleccionado.Text = "Entidad no válida (Solo polilineas cerradas)"
                        If Not lapolilinea Is Nothing Then
                            lapolilinea.HighLight = False
                            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                        End If
                        lapolilinea.Dispose()
                        lapolilinea = Nothing
                        Me.Activate()
                    Else
                        '--------------------------------------------------------------------------------------------------
                        'Si es alta el ok sale por aca. 
                        'No hace nada, solo muestra la superficie que tiene esa polilinea y la deja lista para cargarle los
                        'datos de poligono de dominio. Los datos a cargar son la denominacion y a que uf/uc pertenece.
                        '--------------------------------------------------------------------------------------------------
                        lapolilinea.HighLight = True
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                        'lblPoligonoDominioSeleccionado.Text = "Identificador: " & lapolilinea.Handle.ToString & ", Sup: " & Format(lapolilinea.Area, "0.0###").ToString
                        If lapolilinea.Area < 0 Then
                            lblPoligonoDominioSeleccionado.Text = Format(lapolilinea.Area * -1, "0.00").ToString
                        Else
                            lblPoligonoDominioSeleccionado.Text = Format(lapolilinea.Area, "0.00").ToString
                        End If
                        Me.Activate()
                    End If
                Else
                    '--------------------
                    'NO es una polilinea
                    '--------------------
                    lblPoligonoDominioSeleccionado.Text = "Entidad no válida. NO es una polilinea cerrada"
                    If Not lapolilinea Is Nothing Then
                        lapolilinea.HighLight = False
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    End If
                    lapolilinea = Nothing
                    Me.Activate()
                End If
            Else
                '--------------------
                'NO hay seleccion
                '--------------------
                lblPoligonoDominioSeleccionado.Text = "--"
                If Not lapolilinea Is Nothing Then
                    lapolilinea.HighLight = False
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                End If
                lapolilinea = Nothing
                Me.Activate()
            End If
        Else
            '--------------------
            'NO hay seleccion
            '--------------------
            lblPoligonoDominioSeleccionado.Text = "--"
            If Not lapolilinea Is Nothing Then
                lapolilinea.HighLight = False
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            End If
            lapolilinea = Nothing
            Me.Activate()
        End If

    End Sub

    Private Sub btnPegarDatosPolDom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPegarDatosPolDom.Click
        '==================================================================
        '
        'agregar atributos al poligono de DOMINIO
        'o sea pegarle los datos (xprop) a la entidad polilinea cerrada.
        'Los datos que se pegan son:
        '1) Denominacion
        '2) A que uf/uc pertenece.
        '3) tipo. Es "Pol_dominio"
        '
        '==================================================================

        If lapolilinea Is Nothing Then
            MsgBox("No hay seleccion de entidades validas (polilineas cerradas)")
            Exit Sub
        End If
        If txtPolDominioNombre.Text = "" Or cmbUf.Text = "" Then
            MsgBox("Faltan datos.")
            Exit Sub
        End If
        If lapolilinea.XProperties.Count = 3 Then
            '--------------
            'hay edicion
            '--------------
            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In lapolilinea.XProperties
                If atributo.Name = "DenominacionPolDominio" Then
                    atributo.PropValue = txtPolDominioNombre.Text
                ElseIf atributo.Name = "Pertenece" Then
                    'Dim cadenas() As String = cmbUfUc.Text.Split(":")
                    'atributo.PropValue = CInt(cadenas(1))
                    atributo.PropValue = cmbUf.Text.ToString
                End If
            Next
            lapolilinea.ToolTip = "Poligono de dominio " & txtPolDominioNombre.Text.ToString & ", pertenece a la UF/UC " & cmbUf.Text.ToString
        Else
            '---------------------------------
            'primera vez que se cargan los att
            '---------------------------------
            Dim xProp As New VectorDraw.Professional.vdObjects.vdXProperty

            If txtPolDominioNombre.Text <> "" Then
                xProp.Name = "DenominacionPolDominio"
                xProp.PropValue = txtPolDominioNombre.Text
                lapolilinea.XProperties.AddItem(xProp)
            End If

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "tipoPolDominio"
            xProp.PropValue = "Pol_Dominio"
            lapolilinea.XProperties.AddItem(xProp)

            If cmbUf.Text <> "" Then
                xProp = New VectorDraw.Professional.vdObjects.vdXProperty
                xProp.Name = "Pertenece"
                'Dim cadenas() As String = cmbUfUc.Text.Split(":")
                'xProp.PropValue = CInt(cadenas(1))
                xProp.PropValue = cmbUf.Text.ToString
                lapolilinea.XProperties.AddItem(xProp)
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            End If

            Dim encontrado As Boolean = False
            'revisar
            'For Each item As String In cmbPoligonosDominio.Items
            '    If item = txtPolDominioNombre.Text.ToString Then
            '        encontrado = True
            '        Exit For
            '    End If
            'Next
            'If encontrado = False Then
            '    cmbPoligonosDominio.Items.Add(txtPolDominioNombre.Text.ToString)
            'Else
            encontrado = False
        End If
        lapolilinea.ToolTip = "Poligono de dominio " & txtPolDominioNombre.Text.ToString & ", pertenece a la UF/UC " & cmbUf.Text.ToString
        'End If

        '----------------------------------------------------------
        'actualizar el combo de los poligonos de dominio existentes
        '----------------------------------------------------------
        cargarPoligonosDominio()

        '-------------------------------------------------------------------------------------------------------------------
        'cuando se agregan datos a una polilinea y se transforma en un poligono de dominio, disparar codigo que arme tabla
        'con todas las uf, pol dom y superficies. 
        'Luego de armada la tabla, disparar dibujar planilla (frmPHUnidadesFuncionales.SeleccionarPunto) leyendo de la tabla
        '-------------------------------------------------------------------------------------------------------------------
        'armaTblPlanillaUf()
        'frmPHUnidadesFuncionales.seleccionarPunto()

        lapolilinea.HighLight = False
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()


    End Sub

    Private Sub btnSeleccionarSuperficie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarSuperficie.Click
        '======================================================================================
        'Al hacer click en este boton, se selecciona una SUPERFICIE (es una polilinea cerrada)
        'y se le definen sus atributos.
        '
        '1) Tipo de superficie
        '2) A que poligono de dominio pertenece
        '=======================================================================================
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing

        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

        'Definir poligono..
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar una SUPERFICIE...")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        If ret = VectorDraw.Actions.StatusCode.Success Then

            If Not fig Is Nothing Then

                If fig._TypeName = "vdPolyline" Then

                    lapolilinea = New VectorDraw.Professional.vdFigures.vdPolyline
                    lapolilinea = CType(fig, VectorDraw.Professional.vdFigures.vdPolyline)

                    If lapolilinea.XProperties.Count = 3 Then
                        Dim xPropAVerificar As VectorDraw.Professional.vdObjects.vdXProperty
                        'si tiene 3 xprop es un poligiono de DOMINIO, rechazar la selección. Reviso solo por dos..
                        xPropAVerificar = lapolilinea.XProperties.FindName("Pertenece")
                        If Not xPropAVerificar Is Nothing Then
                            xPropAVerificar = lapolilinea.XProperties.FindName("tipoPolDominio")
                            If Not xPropAVerificar Is Nothing Then
                                MsgBox("La entidad seleccionada ya esta asignada como poligono de DOMINIO.")
                                Exit Sub
                            Else
                                MsgBox("La entidad seleccionada ya tiene datos asignados.")
                                Exit Sub
                            End If
                        Else
                            MsgBox("La entidad seleccionada ya tiene datos asignados.")
                            Exit Sub
                        End If
                    ElseIf lapolilinea.XProperties.Count = 2 Then
                        '----------------------------------
                        'Si es edicion el ok sale por aca..
                        '----------------------------------
                        For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In lapolilinea.XProperties
                            If atributo.Name = "tipoSuperficie" Then
                                If atributo.PropValue Is "Cubierta" Then
                                    rbCubierta.Checked = True
                                ElseIf atributo.PropValue Is "Semicubierta" Then
                                    rbSemicubierta.Checked = True
                                ElseIf atributo.PropValue Is "Descubierta" Then
                                    rbDescubierta.Checked = True
                                ElseIf atributo.PropValue Is "Balcon" Then
                                    rbBalcon.Checked = True
                                End If
                            ElseIf atributo.Name = "Pertenece" Then
                                cmbPoligonosDominio.Text = atributo.PropValue.ToString
                            End If
                        Next
                        lblSuperficieSeleccionado.Text = "Identificador: " & lapolilinea.Handle.ToString & ", Sup: " & Format(lapolilinea.Area, "0.0###").ToString
                        lapolilinea.HighLight = True
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                        Me.Activate()
                        Exit Sub
                    End If
                    '-------------------------------------------------
                    'la polilinea seleccionada no tiene datos adjuntos.
                    'revisar si esta bien cerrada
                    '--------------------------------------------------
                    Dim PolAbiertaCerrada As VectorDraw.Professional.Constants.VdConstPlineFlag = lapolilinea.Flag
                    If PolAbiertaCerrada = 0 Then
                        lblSuperficieSeleccionado.Text = "Entidad no válida (Solo polilineas cerradas)"
                        lapolilinea.Dispose()
                        lapolilinea = Nothing
                        Me.Activate()
                    Else
                        '---------------
                        'alta..
                        '---------------
                        'lblSuperficieSeleccionado.Text = "Identificador: " & lapolilinea.Handle.ToString & ", Sup: " & Format(lapolilinea.Area, "0.0###").ToString
                        lapolilinea.HighLight = True
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                        If lapolilinea.Area < 0 Then
                            lblSuperficieSeleccionado.Text = Format(lapolilinea.Area * -1, "0.00").ToString
                        Else
                            lblSuperficieSeleccionado.Text = Format(lapolilinea.Area, "0.00").ToString
                        End If
                        Me.Activate()
                    End If
                Else
                    lblSuperficieSeleccionado.Text = "Entidad no válida (Solo polilineas cerradas)"
                    If Not lapolilinea Is Nothing Then
                        lapolilinea.HighLight = False
                        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                    End If
                    lapolilinea = Nothing
                    Me.Activate()
                End If
            Else
                '--------------------
                'NO hay seleccion
                '--------------------
                lblSuperficieSeleccionado.Text = "--"
                If Not lapolilinea Is Nothing Then
                    lapolilinea.HighLight = False
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                End If
                lapolilinea = Nothing
                Me.Activate()
            End If
        Else
            lblSuperficieSeleccionado.Text = "--"
            If Not lapolilinea Is Nothing Then
                lapolilinea.HighLight = False
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            End If
            lapolilinea = Nothing
            Me.Activate()
        End If

    End Sub

    Private Sub btnPegarDatosSuperficie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPegarDatosSuperficie.Click
        '-------------------------------------------------
        'agregar atributos a la polilinea de la SUPERFICIE
        '
        '1) Tipo de superficie
        '2) A que poligono de dominio pertenece
        '-------------------------------------------------
        If lapolilinea Is Nothing Then
            MsgBox("No hay seleccion de entidades validas (polilineas cerradas)")
            Exit Sub
        End If

        If cmbPoligonosDominio.Text = "" Then
            MsgBox("Faltan datos.")
            Exit Sub
        End If

        If rbBalcon.Checked = False And _
            rbCubierta.Checked = False And _
            rbDescubierta.Checked = False _
            And rbSemicubierta.Checked = False Then
            MsgBox("Faltan datos.")
            Exit Sub
        End If

        Dim stringToolTip As String = ""
        If lapolilinea.XProperties.Count = 2 Then
            '---------------
            'hay edicion
            '---------------
            For Each atributo As VectorDraw.Professional.vdObjects.vdXProperty In lapolilinea.XProperties
                If atributo.Name = "tipoSuperficie" Then
                    If rbCubierta.Checked Then
                        atributo.PropValue = "Cubierta"
                        stringToolTip = "Cubierta"
                    ElseIf rbSemicubierta.Checked Then
                        atributo.PropValue = "Semicubierta"
                        stringToolTip = "Semicubierta"
                    ElseIf rbDescubierta.Checked Then
                        atributo.PropValue = "Descubierta"
                        stringToolTip = "Descubierta"
                    ElseIf rbBalcon.Checked Then
                        atributo.PropValue = "Balcon"
                        stringToolTip = "Balcon"
                    End If
                ElseIf atributo.Name = "Pertenece" Then
                    atributo.PropValue = cmbPoligonosDominio.Text.ToString
                End If
            Next
            stringToolTip = stringToolTip & ", pertenece al poligono de dominio " & cmbPoligonosDominio.Text.ToString
            lapolilinea.ToolTip = stringToolTip
        Else
            '---------------------------------
            'primera vez que se cargan los att
            '---------------------------------
            Dim xProp As VectorDraw.Professional.vdObjects.vdXProperty

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "tipoSuperficie"
            If rbCubierta.Checked Then
                xProp.PropValue = "Cubierta"
                stringToolTip = "Cubierta"
            ElseIf rbSemicubierta.Checked Then
                xProp.PropValue = "Semicubierta"
                stringToolTip = "Semicubierta"
            ElseIf rbDescubierta.Checked Then
                xProp.PropValue = "Descubierta"
                stringToolTip = "Descubierta"
            ElseIf rbBalcon.Checked Then
                xProp.PropValue = "Balcon"
                stringToolTip = "Balcon"
            End If
            'fig.XProperties.AddItem(xProp)
            lapolilinea.XProperties.AddItem(xProp)

            xProp = New VectorDraw.Professional.vdObjects.vdXProperty
            xProp.Name = "Pertenece"
            xProp.PropValue = cmbPoligonosDominio.Text.ToString
            'fig.XProperties.AddItem(xProp)
            lapolilinea.XProperties.AddItem(xProp)

            stringToolTip = stringToolTip & ", pertenece al poligono de dominio " & cmbPoligonosDominio.Text.ToString
            lapolilinea.ToolTip = stringToolTip
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
        lapolilinea.HighLight = False
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

    End Sub

    Private Sub armaTblPlanillaUf()

        Dim tblUf As New DataTable
        'tblUf.TableName = "tbluuUf"
        tblUf.Columns.Add(New DataColumn("uf", GetType(String)))
        tblUf.Columns.Add(New DataColumn("pol", GetType(String)))
        tblUf.Columns.Add(New DataColumn("cub", GetType(Double)))
        tblUf.Columns.Add(New DataColumn("semi", GetType(Double)))
        tblUf.Columns.Add(New DataColumn("desc", GetType(Double)))
        tblUf.Columns.Add(New DataColumn("balc", GetType(Double)))
        tblUf.Columns.Add(New DataColumn("totPol", GetType(Double)))
        tblUf.Columns.Add(New DataColumn("totUf", GetType(Double)))

        Dim dr As DataRow
        dr = tblUf.NewRow
        dr("uf") = "1"
        dr("pol") = "00-01"
        dr("cub") = 89.08
        tblUf.Rows.Add(dr)


    End Sub
End Class
