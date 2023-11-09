Imports System.IO


Module Var_Cedula
    Private idTitular As Integer
    Public deslinde_cedula As String
    Public dueño As New BO.Persona


    Public Function Titulares(ByRef datos As Data.DataRow) As BO.Persona
        Dim titu = New BO.Persona
        titu.Nombre = datos("nombre").ToString & "," & "  " & datos("apellido").ToString
        titu.TipoDoc = datos("tipo_doc").ToString
        titu.NumeroDoc = datos("doc").ToString
        titu.Calle = datos("calle").ToString
        titu.NumeroCalle = datos("num_calle").ToString
        titu.Piso = datos("piso").ToString
        titu.Dpto = datos("dpto").ToString
        titu.Localidad = datos("localidad").ToString
        titu.Provincia = "Bs As"
        titu.CodigoP = datos("codigo_p").ToString
        Return (titu)
    End Function

    Public Sub creaCarpeta()
        If Directory.Exists("c:\cpaPD\Imagenes") Then
        Else
            Directory.CreateDirectory("c:\cpaPD\Imagenes")
        End If
    End Sub
    Public Sub creaCarpetaCopia()
        If Directory.Exists("c:\cpaPD\Copia de Seguridad") Then
        Else
            Directory.CreateDirectory("c:\cpaPD\Copia de Seguridad")
        End If
    End Sub

End Module
