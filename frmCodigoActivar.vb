Imports System.IO

Public Class frmCodigoActivar

    Private Sub frmCodigoActivar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = aplicacionNombre
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim hashLocal As String

        If Not leerInput() Then Exit Sub
        If File.Exists("C:\datos.txt") Then
            hashLocal = Genero_Hash("C:\datos.txt")
        Else
            MsgBox("No se encuentra el archivo enviado en la ubicaciòn predeterminada (C:\). El archivo enviado es el archivo datos.txt. Seleccione la ubicación de este archivo.", MsgBoxStyle.Information, aplicacionNombre)
            With ofd
                .CheckFileExists = True
                .ShowReadOnly = False
                .Filter = "Archivos txt|*.txt"
                .FilterIndex = 2
                .FileName = ""
                If .ShowDialog = DialogResult.OK Then
                    Dim fname As New FileInfo(.FileName)
                    hashLocal = Genero_Hash(fname.FullName)
                Else
                    Exit Sub
                End If
            End With
        End If

        If txtRecibido1.Text = hashLocal Then
            If File.Exists(ubicacionSoporte & "mhcad.sys") Then
                File.Delete(ubicacionSoporte & "mhcad.sys")
            End If
            Dim secuenciaArchivo As Stream = File.Open(ubicacionSoporte & "mhcad.sys", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
            Dim escribir As New StreamWriter(secuenciaArchivo)
            secuenciaArchivo.Seek(0, SeekOrigin.Begin)
            escribir.WriteLine("mhCad")
            escribir.Flush()
            escribir.Close()
            secuenciaArchivo.Close()
            MsgBox("Verificacion codigo de activacion ok. Reiniciar el programa.", MsgBoxStyle.Information, aplicacionNombre)
        Else
            MsgBox("Fallo verificacion codigo de activacion", MsgBoxStyle.Exclamation, aplicacionNombre)
            vaciar()
        End If

    End Sub

    Private Function leerInput() As Boolean
        txtRecibido1.Text = txtRecibido1.Text + txtRecibido2.Text + txtRecibido3.Text + txtRecibido4.Text
        If txtRecibido1.Text.ToString.Length <> 32 Then
            MsgBox("Codigo invalido (cantidad de caracteres erronea)", MsgBoxStyle.Information, aplicacionNombre)
            vaciar()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub vaciar()
        txtRecibido1.Text = ""
        txtRecibido2.Text = ""
        txtRecibido3.Text = ""
        txtRecibido4.Text = ""

    End Sub

    Private Sub txtRecibido1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecibido1.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txtRecibido2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecibido1.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txtRecibido3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecibido1.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txtRecibido4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecibido1.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

End Class