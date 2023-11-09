Imports ADOX
Imports System.Data
Imports System.Data.OleDb

Module modPegarDatosEntidad

    Public Sub pegarDatosEntidad(ByVal entidad As VectorDraw.Professional.vdObjects.vdPrimary, ByVal idEntidadBuscar As Integer)

        '-------------------------------------------------------------------------------------
        'POLILINEA
        '-------------------------------------------------------------------------------------
        If entidad._TypeName() = "vdPolyline" Then
            Dim laPolilinea As VectorDraw.Professional.vdFigures.vdPolyline
            laPolilinea = TryCast(entidad, VectorDraw.Professional.vdFigures.vdPolyline)
            If Not laPolilinea.ToolTip = "" Then
                laPolilinea.ToolTip = ""
            End If

            'leerDatosEntidad hace un query entre las tablas entidades, atributosLogicos y atributosGeometricos
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        If tablaDatos.Columns(i).ColumnName = "linderos" Then
                            Select Case Trim(tablaDatos.Rows(0).Item(i).ToString)
                                Case Is = "macizo"
                                    laPolilinea.ToolTip = "Tipo Entidad: Macizo, id: " & idEntidadBuscar.ToString
                                Case Is = "parcela ppal"
                                    laPolilinea.ToolTip = "Tipo Entidad: Parcela principal, Dato cargado: " & tablaDatos.Rows(0).Item("nomenclatura").ToString & ", id: " & idEntidadBuscar.ToString
                                Case Is = "parcela lindera"
                                    laPolilinea.ToolTip = "Tipo Entidad: Parcela lindera, Dato cargado: " & tablaDatos.Rows(0).Item("nomenclatura").ToString & ", id: " & idEntidadBuscar.ToString
                                Case Is = "macizo lindero"
                                    laPolilinea.ToolTip = "Tipo Entidad: Macizo lindero, id: " & idEntidadBuscar.ToString
                            End Select
                        End If
                    Next
                Else
                    laPolilinea.ToolTip = "No hay datos"
                End If
            End If
            laPolilinea.Dispose()
            laPolilinea = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'TEXTO
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdText" Then
            Dim elTexto As VectorDraw.Professional.vdFigures.vdText
            elTexto = TryCast(entidad, VectorDraw.Professional.vdFigures.vdText)

            If Not elTexto.ToolTip = "" Then
                elTexto.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        elTexto.ToolTip = elTexto.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    elTexto.ToolTip = "No hay datos"
                End If
            End If

            elTexto.Dispose()
            elTexto = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'MTEXT
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdMText" Then
            Dim elTextoMultiple As VectorDraw.Professional.vdFigures.vdMText
            elTextoMultiple = TryCast(entidad, VectorDraw.Professional.vdFigures.vdMText)

            If Not elTextoMultiple.ToolTip = "" Then
                elTextoMultiple.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        elTextoMultiple.ToolTip = elTextoMultiple.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    elTextoMultiple.ToolTip = "No hay datos"
                End If
            End If

            elTextoMultiple.Dispose()
            elTextoMultiple = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'POLIHATCH
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdPolyhatch" Then
            Dim elPolyHatch As VectorDraw.Professional.vdFigures.vdPolyhatch
            elPolyHatch = TryCast(entidad, VectorDraw.Professional.vdFigures.vdPolyhatch)

            If Not elPolyHatch.ToolTip = "" Then
                elPolyHatch.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        elPolyHatch.ToolTip = elPolyHatch.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    elPolyHatch.ToolTip = "No hay datos"
                End If
            End If

            elPolyHatch.Dispose()
            elPolyHatch = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'COTA
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdDimension" Then
            Dim laCota As VectorDraw.Professional.vdFigures.vdDimension
            laCota = TryCast(entidad, VectorDraw.Professional.vdFigures.vdDimension)

            If Not laCota.ToolTip = "" Then
                laCota.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        laCota.ToolTip = laCota.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    laCota.ToolTip = "No hay datos"
                End If
            End If

            laCota.Dispose()
            laCota = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'ARCO
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdArc" Then
            Dim elArco As VectorDraw.Professional.vdFigures.vdArc
            elArco = TryCast(entidad, VectorDraw.Professional.vdFigures.vdArc)

            If Not elArco.ToolTip = "" Then
                elArco.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        elArco.ToolTip = elArco.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    elArco.ToolTip = "No hay datos"
                End If
            End If

            elArco.Dispose()
            elArco = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'CIRCULO
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdCircle" Then
            Dim elCirculo As VectorDraw.Professional.vdFigures.vdCircle
            elCirculo = TryCast(entidad, VectorDraw.Professional.vdFigures.vdCircle)

            If Not elCirculo.ToolTip = "" Then
                elCirculo.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        elCirculo.ToolTip = elCirculo.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    elCirculo.ToolTip = "No hay datos"
                End If
            End If

            elCirculo.Dispose()
            elCirculo = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'ELIPSE
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdEllipse" Then
            Dim laElipse As VectorDraw.Professional.vdFigures.vdEllipse
            laElipse = TryCast(entidad, VectorDraw.Professional.vdFigures.vdEllipse)

            If Not laElipse.ToolTip = "" Then
                laElipse.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        laElipse.ToolTip = laElipse.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    laElipse.ToolTip = "No hay datos"
                End If
            End If

            laElipse.Dispose()
            laElipse = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'LEADER
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdLeader" Then
            Dim elLeader As VectorDraw.Professional.vdFigures.vdLeader
            elLeader = TryCast(entidad, VectorDraw.Professional.vdFigures.vdLeader)

            If Not elLeader.ToolTip = "" Then
                elLeader.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        elLeader.ToolTip = elLeader.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    elLeader.ToolTip = "No hay datos"
                End If
            End If

            elLeader.Dispose()
            elLeader = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'LINEA
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdLine" Then
            Dim laLinea As VectorDraw.Professional.vdFigures.vdLine
            laLinea = TryCast(entidad, VectorDraw.Professional.vdFigures.vdLine)

            If Not laLinea.ToolTip = "" Then
                laLinea.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        laLinea.ToolTip = laLinea.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    laLinea.ToolTip = "No hay datos"
                End If
            End If

            laLinea.Dispose()
            laLinea = Nothing
        End If


        '-------------------------------------------------------------------------------------
        'PUNTO
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdPoint" Then
            Dim elPunto As VectorDraw.Professional.vdFigures.vdPoint
            elPunto = TryCast(entidad, VectorDraw.Professional.vdFigures.vdPoint)

            If Not elPunto.ToolTip = "" Then
                elPunto.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        elPunto.ToolTip = elPunto.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    elPunto.ToolTip = "No hay datos"
                End If
            End If

            elPunto.Dispose()
            elPunto = Nothing
        End If

        '-------------------------------------------------------------------------------------
        'RECTANGULO
        '-------------------------------------------------------------------------------------
        If entidad._TypeName = "vdRect" Then
            Dim elRectangulo As VectorDraw.Professional.vdFigures.vdRect
            elRectangulo = TryCast(entidad, VectorDraw.Professional.vdFigures.vdRect)

            If Not elRectangulo.ToolTip = "" Then
                elRectangulo.ToolTip = ""
            End If
            Dim tablaDatos As DataTable = leerDatosEntidad(idEntidadBuscar)
            If Not tablaDatos Is Nothing Then
                If tablaDatos.Rows.Count = 1 Then
                    For i As Integer = 0 To tablaDatos.Columns.Count - 1
                        elRectangulo.ToolTip = elRectangulo.ToolTip & vbCrLf & tablaDatos.Columns(i).ColumnName.ToString & " " & tablaDatos.Rows(0).Item(i).ToString & ", id: " & idEntidadBuscar.ToString
                    Next
                Else
                    elRectangulo.ToolTip = "No hay datos"
                End If

            End If

            elRectangulo.Dispose()
            elRectangulo = Nothing
        End If

        '    laCota.ToolTip = "Deslinde de Parcela " & lblParcela.Text.ToString & vbCrLf & _
        '                     "Linderos: " & txtLinderos.Text & vbCrLf & _
        '                     "Lado: " & cmbTipoLado.Text & vbCrLf & _
        '                     "Medida: " & Format(laCota.Measurement, "0.0000").ToString & vbCrLf & _
        '                     "Rumbo " & cmbRumbo.Text


    End Sub

End Module
