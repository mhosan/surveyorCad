Imports System.IO

Public Class frmDatosActivar
    Dim verificaciones As Boolean
    Dim verificaEmpresa As Boolean, verificaProvincia As Boolean, verificaCiudad As Boolean, verificaMail As Boolean

    Private Sub frmDatosActivar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = aplicacionNombre
        lblAclara.Text = "Guardar archivo para enviar: Guardar los datos ingresados " _
        & "en un archivo de texto para ser enviado por mail a la direcciòn: mhosan@gmail.com." _
        & "El archivo se llama datos.txt y se guarda en la raiz del disco rìgido C, o sea en C:\ "
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If verificarDatos() Then
            guardarArchivoEnviar()
        Else
            MsgBox("Faltan datos. Por favor revisar", MsgBoxStyle.Information, aplicacionNombre)
        End If
    End Sub

    Private Sub guardarArchivoEnviar()
        Try
            'primero ver si existe el archivo de alguna pasada anterior
            'y si existe borrarlo:
            If File.Exists("C:\datos.txt") Then
                File.Delete("C:\datos.txt")
            End If

            'guardar los datos..
            Dim datosLicencia As Stream = File.Open("C:\datos.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
            Dim escribir As New StreamWriter(datosLicencia)

            datosLicencia.Seek(0, SeekOrigin.Begin)
            escribir.WriteLine(txtEmpresa.Text)
            escribir.WriteLine(txtProvincia.Text)
            escribir.WriteLine(txtCiudad.Text)
            If Not txtCalle.Text = Nothing Or Not Trim(txtCalle.Text) = "" Then
                escribir.WriteLine(txtCalle.Text)
            End If
            If Not txtNumero.Text = Nothing Or Not Trim(txtNumero.Text) = "" Then
                escribir.WriteLine(txtNumero.Text)
            End If
            If Not txtTelefono.Text = Nothing Or Not Trim(txtTelefono.Text) = "" Then
                escribir.WriteLine(txtTelefono.Text)
            End If
            escribir.WriteLine(txtMail.Text)
            If Not txtWeb.Text = Nothing Or Not Trim(txtWeb.Text) = "" Then
                escribir.WriteLine(txtWeb.Text)
            End If
            If Not txtWeb.Text = Nothing Or Not Trim(txtWeb.Text) = "" Then
                escribir.WriteLine(txtContacto.Text)
            End If
            escribir.Flush()
            escribir.Close()
            datosLicencia.Close()
            MsgBox("Datos de activacion de licencia guardados ok en el archivo C:\datos.txt. Enviar ese archivo a la direcciòn de mail mhosan@gmail.com para recibir el codigo de activaciòn.", MsgBoxStyle.Information, aplicacionNombre)
            Me.Close()
        Catch ex As Exception
            Err.Clear()
            MsgBox("Error al guardar los datos de activaciòn de la licencia.")
            Exit Sub
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Function verificarDatos() As Boolean
        If verificaEmpresa And verificaProvincia And verificaCiudad And verificaMail Then
            verificarDatos = True
        Else
            verificarDatos = False
        End If
    End Function

#Region "validaciones"
    Private Sub txtEmpresa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmpresa.Validating
        If txtEmpresa.Text = Nothing Or Trim(txtEmpresa.Text) = "" Then
            e.Cancel = True
            txtEmpresa.Select(0, txtEmpresa.Text.Length)
            ErrorProvider1.SetError(txtEmpresa, "Ingresar empresa")
            verificaEmpresa = False
            Exit Sub
        Else
            verificaEmpresa = True
        End If
    End Sub

    Private Sub txtEmpresa_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpresa.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtProvincia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtProvincia.Validating
        If txtProvincia.Text = Nothing Or Trim(txtProvincia.Text) = "" Then
            e.Cancel = True
            txtProvincia.Select(0, txtProvincia.Text.Length)
            ErrorProvider1.SetError(txtProvincia, "Ingresar provincia")
            verificaProvincia = False
            Exit Sub
        Else
            verificaProvincia = True
        End If
    End Sub

    Private Sub txtProvincia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProvincia.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtCiudad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCiudad.Validating
        If txtCiudad.Text = Nothing Or Trim(txtCiudad.Text) = "" Then
            e.Cancel = True
            txtCiudad.Select(0, txtCiudad.Text.Length)
            ErrorProvider1.SetError(txtCiudad, "Ingresar ciudad")
            verificaCiudad = False
            Exit Sub
        Else
            verificaCiudad = True
        End If
    End Sub

    Private Sub txtCiudad_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCiudad.Validated
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtMail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMail.Validating
        If txtMail.Text = Nothing Or Trim(txtMail.Text) = "" Then
            e.Cancel = True
            txtMail.Select(0, txtMail.Text.Length)
            ErrorProvider1.SetError(txtMail, "Ingresar mail")
            verificaMail = False
            Exit Sub
        Else
            verificaMail = True
        End If
    End Sub
#End Region
End Class