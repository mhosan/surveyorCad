Imports VectorDraw.Professional.vdCollections


Module modBorrarEntidades

    Public Sub pdBorrarEntidades()

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar ENTIDADES a borrar (boton derecho del mouse para finalizar)")
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

        For Each entidad As VectorDraw.Professional.vdPrimaries.vdFigure In seleccion
            If entidad.ToolTip <> "" Then  'ojo, estoy buscando las entidades a borrar por el
                '                          tooltip. En el id puesto dentro del tooltip.
                '                          La busqueda deberia ser
                '                          por alguna marca mas permanente, por ej. en las xprop
                '                          de la entidad, que diga si pertenece al plano digital.
                Dim auxiliar() As String = Split(entidad.ToolTip, ", id:")
                If auxiliar.Count > 1 Then
                    idEntidad = CInt(Trim(auxiliar(1)))
                    modDatosDB.borrarEntidad(idEntidad) '<---- Borrar de la base de datos
                    entidad.Deleted = True              '<---- Borrar del dibujo
                End If
            End If
        Next
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub
End Module
