

Module modParseaStr

    Public Function desarmaStr(ByVal cadena As String, ByRef vector() As String) As Boolean
        '==================================================================================
        ' Toma un string y va desarmandolo usando como separador la coma.
        ' el resultado lo deja en un vector
        '==================================================================================
        If cadena = "" Then Exit Function

        Try
            Dim largo As Integer = Len(cadena)
            Dim ultimaComaDesdeAtras As Integer = CInt(InStrRev(cadena, ","))

            ReDim vector(0)

            Dim recortarDesde As Integer = 0
            Dim recorte As String

            Static pasadas As Integer = 0

            For i As Integer = 0 To largo - 1
                If i = ultimaComaDesdeAtras Then
                    pasadas = pasadas + 1
                    recorte = Trim(cadena.Substring(i, largo - i))
                    'MsgBox(recorte)
                    If pasadas > 1 Then
                        ReDim Preserve vector(UBound(vector) + 1)
                    End If
                    vector(UBound(vector)) = recorte
                Else
                    If cadena.Substring(i, 1) = "," Then
                        pasadas = pasadas + 1
                        recorte = Trim(cadena.Substring(recortarDesde, i - recortarDesde))
                        recortarDesde = i + 1
                        'MsgBox(recorte)
                        If pasadas > 1 Then
                            ReDim Preserve vector(UBound(vector) + 1)
                        End If
                        vector(UBound(vector)) = recorte
                    End If
                End If
            Next
        Catch ex As Exception
            Return False
            Exit Function
        End Try

        Return True

    End Function

End Module
