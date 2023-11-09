Imports System.Data
Imports System.Data.OleDb
Imports System.IO
'Imports System.Data.SqlClient
Module Conexion

    Public conexionMdb1 As OleDbConnection

    Public Function conectar1() As Boolean
        'Dim cadena As String = "D:\CPA_Plano Digital\Desarrollo_13_08_2012\Copy of cpaCad_version 2.3.3\BD"
        Dim cadena As String = Application.StartupPath & "\planoDigitalDB"
        Dim sCnn As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & cadena & "\pd.mdb"
        'Establecer y Abrir la conexión

        conexionMdb1 = New OleDbConnection(sCnn)
        conexionMdb1.Open()

        Return True

        'Catch ex As Exception
        'Return False
        '    End Try


    End Function


    Public Function cerrarConexion1()
        If conexionMdb1 Is Nothing Then
            Return True
        End If



        Try
            conexionMdb1.Close()
            conexionMdb1.Dispose()
            conexionMdb1 = Nothing
            Return True
        Catch ex As Exception
            Return False
        Finally


            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try

    End Function


End Module
