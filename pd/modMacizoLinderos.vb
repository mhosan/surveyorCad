
Imports VectorDraw.Professional.vdCollections

Module modMacizoLinderos


    Public Sub DefinirMacizoLinderosSeleccionandoPuntos()
        '--------------------------------------------------
        'macizo linderos. seleccion por puntos
        '--------------------------------------------------
        Dim elOsnap As VectorDraw.Geometry.OsnapMode = New VectorDraw.Geometry.OsnapMode
        elOsnap = VectorDraw.Geometry.OsnapMode.END + VectorDraw.Geometry.OsnapMode.INTERS
        frmPpal.VdF.BaseControl.ActiveDocument.osnapMode = elOsnap
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Blue)
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01 '0.15


        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPolyLine("USER")


        Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        lapoli = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)

        '..............................................................................................................
        'Dim macizoLinderoCalle As String = InputBox("Ingresar calle del macizo lindero", "Atributos de Macizo Lindero")
        'If Trim(macizoLinderoCalle) = "" Then
        '    MsgBox("No se ingreso informacion.")
        'Else
        agregarDatosMacizoLinderoBD("macizo lindero", lapoli)
        Dim boxing As VectorDraw.Professional.vdObjects.vdPrimary
        boxing = lapoli
        pegarDatosEntidad(boxing, idEntidad)
        'End If
        '..............................................................................................................

        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenWidth = 0.01
        frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
    End Sub


    Public Sub DefinirMacizoSeleccionandoPolilinea()
        '---------------------------------------------------
        'macizo linderos. seleccion por polilinea
        '---------------------------------------------------
        Dim Parray As Object

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar POLILINEA (boton derecho del mouse para finalizar)")
        Dim seleccion As vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

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

        If seleccion.Item(0)._TypeName = "vdPolyline" Then
            Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
            lapoli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            lapoli.setDocumentDefaults()
            lapoli = CType(seleccion.Item(0), VectorDraw.Professional.vdFigures.vdPolyline)
            Parray = lapoli.VertexList
            'Dim PolAbiertaCerrada As VectorDraw.Professional.Constants.VdConstPlineFlag = lapoli.Flag
            'If PolAbiertaCerrada = 0 Then 'abierta
            '    acotarPolilineas(i, Arriba, Abajo, Parray, True, Lados, Angulos)
            'Else
            '    acotarPolilineas(i, Arriba, Abajo, Parray, False, Lados, Angulos)
            'End If
            lapoli.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Blue)
            lapoli.PenWidth = 0.01 '0.15
            'vdf.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lapoli)

            '..................
            Dim macizoLinderoCalle As String = InputBox("Ingresar calle del macizo lindero", "Atributos de Macizo Lindero")
            If Trim(macizoLinderoCalle) = "" Then
                MsgBox("No se ingreso informacion.")
            Else
                agregarDatosMacizoLinderoBD(macizoLinderoCalle, lapoli)
                Dim boxing As VectorDraw.Professional.vdObjects.vdPrimary
                boxing = lapoli
                pegarDatosEntidad(boxing, idEntidad)
            End If
            '...................

            lapoli.Dispose()
            frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        End If

    End Sub
End Module
