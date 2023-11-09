Imports VectorDraw.Professional.vdCollections
Public Class frmPruebaMacizo
    Public i As Integer = _macizo.puntos.Count - 1
    Public j As Integer = 0
    Public t As Integer = 1
    Dim nombbre As String
    Dim espacio As Integer
    Dim st, ep As New VectorDraw.Geometry.gPoint
    Dim puntoS, puntoE As New VectorDraw.Geometry.gPoint
    '========================================================================
    '========================================================================
    '========================================================================
#Region "PRODECIMIENTOS INTERNOS"
#Region "Campos Vacios"
    Function controL_campos_vacios() As Boolean

        '===============Controles de campos en Blanco 
        If Radio_espacio_circulatorio.Checked = False And Radio_territorial.Checked = False Then

            MsgBox("Debe seleccionar el tipo de Lindero ")
            Return (True)
            Exit Function

        End If
        If Radio_espacio_circulatorio.Checked = True Then

            If CbxTipoEspacioCirculatorio.Text = "" Or TxtAnchoEspacioCirculatorio.Text = "" Or TxtNombreEspacioCirculatorio.Text = "" Then
                MsgBox("Falta Completar campo del Lindero ")
                Return (True)
                Exit Function
            End If

        End If

        If Radio_territorial.Checked = True Then
            If Combo_espacio_territorial.Text = "" Or T_espacio_territorial.Text = "" Then
                MsgBox("Falta Completar campo del Lindero ")
                Return (True)
                Exit Function

            End If


        End If



    End Function
#End Region
#Region "Cargo la Nomeclatura"
    Public Sub cargo_la_nomenclatura()
        'Levanto de la clase la Nomenclatura
        '===================================
        If IsNothing(nomenclatura.Circunscripcion) Then
        Else : Tcir.Text = nomenclatura.Circunscripcion
        End If

        If IsNothing(nomenclatura.Seccion) Then
        Else : Tsec.Text = nomenclatura.Seccion
        End If

        If IsNothing(nomenclatura.Chacra) Then
        Else : Tch_numero.Text = nomenclatura.Chacra
        End If

        If IsNothing(nomenclatura.ChacraLetra) Then
        Else : Tch_letra.Text = nomenclatura.ChacraLetra
        End If

        If IsNothing(nomenclatura.Quinta) Then
        Else : Tqui.Text = nomenclatura.Quinta
        End If

        If IsNothing(nomenclatura.QuintaLetra) Then
        Else : Tqui_letra.Text = nomenclatura.QuintaLetra
        End If

        If IsNothing(nomenclatura.Fraccion) Then
        Else : Tfrac.Text = nomenclatura.Fraccion
        End If

        If IsNothing(nomenclatura.FraccionLetra) Then
        Else : Tfrac_letra.Text = nomenclatura.FraccionLetra
        End If

        If IsNothing(nomenclatura.Manzana) Then
        Else : Tmanz.Text = nomenclatura.Manzana
        End If
        If IsNothing(nomenclatura.ManzanaLetra) Then
        Else : Tmanz_letra.Text = nomenclatura.ManzanaLetra
        End If
        ' Se carga hasta manzana en el Macizo
        '================================================
    End Sub
#End Region
#End Region

    Private Sub frmPruebaMacizo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Configuracion_Pantalla.ajustarResolucion(Me)
        Dim Random As New Random()
        BtnAceptar.Enabled = False
        id_macizo = Random.Next(100000, 999999)
        modFuncionesMacizo.SeteoMazico()
        cargo_la_nomenclatura()
        BaseControl11.ActiveDocument.ClearAll()
        'BaseControl11.ActiveDocument.[New]()

        BaseControl11.Cursor = Cursors.No
        BaseControl11.ActiveDocument.ActionLayout.BkColorEx = Color.Green
        '==============LLamo al modulo pruebaMacizo2, ahi dibujo todo================================
        modPruebaMacizo2.Dibujo_Macizo()
        modPruebaMacizo2.vertices()
        puntoS = ConvertToGPoint(_macizo.puntos(0))
        puntoE = ConvertToGPoint(_macizo.puntos(1))
        modPruebaMacizo2.Pinto_linea(puntoS, puntoE)
        '============================================================================================
        '===========Indica en pantalla Lado y Metros=================================================
        LdelosLados.Text = "1"
        Lmt.Text = Format(VectorDraw.Geometry.gPoint.Distance2D(puntoS, puntoE), "##,##0.00").ToString
        '=============================================================================================

    End Sub

    Private Sub BtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiguiente.Click
        If controL_campos_vacios() = True Then
            Exit Sub
        End If
        '======== i es la cantidad de lados del macizo=================================
        If j <= i Then
            st.x = _macizo.puntos(j).X
            st.y = _macizo.puntos(j).Y
            st.z = 0.0

            If j = i Then
                BtnAceptar.Enabled = True
                ep.x = _macizo.puntos(0).X
                ep.y = _macizo.puntos(0).Y
                ep.z = 0.0
            Else
                ep.x = _macizo.puntos(j + 1).X
                ep.y = _macizo.puntos(j + 1).Y
                ep.z = 0.0
            End If
            '=====Para pintar la linea siguiente==========================================
            '=============================================================================
            If t <= i Then

                puntoS.x = _macizo.puntos(t).X
                puntoS.y = _macizo.puntos(t).Y
                puntoS.z = 0.0
                If t <> i Then
                    puntoE.x = _macizo.puntos(t + 1).X
                    puntoE.y = _macizo.puntos(t + 1).Y
                    puntoE.z = 0.0
                    LdelosLados.Text = t + 1
                    Lmt.Text = Format(VectorDraw.Geometry.gPoint.Distance2D(puntoS, puntoE), "##,##0.00").ToString
                Else
                    LdelosLados.Text = t + 1
                    puntoE.x = _macizo.puntos(0).X
                    puntoE.y = _macizo.puntos(0).Y
                    puntoE.z = 0.0
                    Lmt.Text = Format(VectorDraw.Geometry.gPoint.Distance2D(puntoS, puntoE), "##,##0.00").ToString
                End If
            End If
            '=============================================================================
            '=============================================================================
            '=========Dependiendo del espacio marcado(territorial/circulatorio)==========
            '============================================================================
            If Radio_espacio_circulatorio.Checked = True Then
                espacio = 1
                nombbre = TxtNombreEspacioCirculatorio.Text
                ancho_paralela1 = Convert.ToDouble(TxtAnchoEspacioCirculatorio.Text)

            Else
                Radio_territorial.Checked = False
                nombbre = T_espacio_territorial.Text
                espacio = 0
                ancho_paralela1 = Convert.ToDouble(17)
            End If
            '===============================================================================
            '===============================================================================
            '==============LLamo al modulo pruebaMacizo2, ahi dibujo todo===================
            modPruebaMacizo2.DIBUJAME_LA_PARALELA1(st, ep, ancho_paralela1, nombbre, espacio)
            modPruebaMacizo2.Pinto_linea(puntoS, puntoE)
            '===============================================================================
            '===============================================================================
            '=========Incrementan los puntos de los dibujos================================
            j = j + 1
            t = t + 1
            '==============================================================================
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        bander = True  ' avisa en el modmacizo que cancelo
        modDatosDB.elimino(identificadorTrabajo)
        Me.Close()

    End Sub

   
    Private Sub BtnAceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        'Aca se tiene que descargar cmdPolyline
        'BaseControl11.ActiveDocument.CommandAction.CmdPolyLine(Nothing)
        'BaseControl11.ActiveDocument.ActiveLayOut.Entities.EraseAll()
        'BaseControl11 = Nothing
        Dim designacionMacizo As String = "nomenclatura"
        modDatosDB.agregarDatosMacizoBD(designacionMacizo, copia_lapoli, "macizo")
        Me.Dispose()

    End Sub
End Class