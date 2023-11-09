Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Configuration
'Imports System.Data.SqlClient
Imports System.Data
'Imports reglasDeNegocio
Imports Microsoft.Reporting.WinForms
Imports System.Collections.ArrayList
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Imports System.Data.OleDb
Imports System.IO
Imports ADOX
Imports System.Windows.Forms
Public Class Rep
    Private Function Gettitular() As BO.Persona

        conectar1()

        'Dim adaptador As New OleDb.OleDbDataAdapter("Select Max(idTrabajo)from trabajos ", conexionMdb1)
        'Dim ds As New DataSet
        'Dim sql As String
        'Dim Cmd As OleDbCommand = New OleDbCommand()
        'Dim idEnti As Integer
        'Dim x, y, z As Double
        'x = ppto.x
        'y = ppto.y
        'z = ppto.z
        'adaptador.Fill(ds, "Trabajo")
        'If ds.Tables("Trabajo").Rows.Count = 1 Then
        '    'ALTA:
        '    Dim ultimo_trabajo As Integer = ds.Tables(0).Rows(0).Item(0)
        '    idEnti = Random.Next(999999)
    End Function
    Private Sub BotonExportar()
        For Each ctrl As Control In Me.CrystalReportViewer1.Controls
            'Buscar toolstrip del visor de informes
            If (TypeOf ctrl Is ToolStrip) Then
                Dim ts As ToolStrip = CType(ctrl, ToolStrip)
                For Each tsi As ToolStripItem In ts.Items
                    'Buscar el boton exportar por un ImageIndex
                    If (TypeOf tsi Is ToolStripButton _
                       And tsi.ImageIndex = 8) Then
                        AddHandler Button1.Click, AddressOf Me.Exportar_Click
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub

    Private Function GetCedulaCatastral() As BO.CedulaCastral

        Dim cc = New BO.CedulaCastral
        ' ======== 1 ====================================================
        cc.Partido = "(" & frmInicial.T_num_p.Text & ")" & " " & frmInicial.Combo_partido.Text
        cc.PartidoNombre = frmInicial.T_num_p.Text
        cc.Partida = frmInicial.t_partida.Text
        '===============================================================
        '========= 2 ===================================================
        cargonomenclatura()
        cc.NomenclaturaCatastral.Circunscripcion = nomenclatura.Circunscripcion
        cc.NomenclaturaCatastral.Seccion = nomenclatura.Seccion
        cc.NomenclaturaCatastral.Chacra = nomenclatura.Chacra & " " & nomenclatura.ChacraLetra
        cc.NomenclaturaCatastral.Quinta = nomenclatura.Quinta & " " & nomenclatura.QuintaLetra
        cc.NomenclaturaCatastral.Fraccion = nomenclatura.Fraccion & " " & nomenclatura.FraccionLetra
        cc.NomenclaturaCatastral.Manzana = nomenclatura.Manzana & " " & nomenclatura.ManzanaLetra
        cc.NomenclaturaCatastral.Parcela = nomenclatura.Parcela & " " & nomenclatura.ParcelaLetra

        '===============================================================
        '========= 3 ===================================================
        cc.Ubicacion.Calle = frmInicial.T_calle_i.Text
        cc.Ubicacion.Nro = 10
        cc.Ubicacion.EntreCalle1 = 116
        cc.Ubicacion.EntreCalle2 = 117
        cc.Ubicacion.Localidad = "La Plata"
        cc.Ubicacion.CodigoPostal = 123
        '===============================================================
        '====== 4 ======================================================
        cc.Designacion = "Muchas mass designacionasdkjñsdlfkasñdfasld"
        cc.Medidas = "Muchassadalsñdkfjlañksdjasñdfklasdfasd"
        '===============================================================
        '====== 8 ======================================================
        cc.PaChacra = nomenclatura.Chacra & " " & nomenclatura.ChacraLetra
        cc.PaSeccion = nomenclatura.Seccion
        cc.PaQuinta = nomenclatura.Quinta & " " & nomenclatura.QuintaLetra
        cc.PaParcela = nomenclatura.Parcela & " " & nomenclatura.ParcelaLetra
        cc.PaPartido = frmInicial.T_num_p.Text
        cc.PaManzana = nomenclatura.Manzana & " " & nomenclatura.ManzanaLetra
        cc.PaCircunscripcion = nomenclatura.Circunscripcion
        cc.PaFraccion = nomenclatura.Fraccion & " " & nomenclatura.FraccionLetra
        ' ===============================================================
        ' ======= 10 ====================================================
        cc.Pavimento = "X"
        cc.AguaCorriente = "X"
        cc.Alumbrado = "X"
        cc.Cloacas = "X"
        cc.Electrica = "X"
        cc.Gas = "X"
        'ubicar imagen aqui...
        Dim archivo As String = CStr(identificadorTrabajo)
        cc.Croquis = "c:\cpaPD\Imagenes\" + archivo + ".jpg"
        Return (cc)

    End Function

    Private Sub Rep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim titular = Gettitular()

        Dim cedulaCatastral = GetCedulaCatastral()
        Dim paramFiels As New ParameterFields()

        '// Creo el parametro y asigno el nombre
        '=====================================================
        Dim param_partido As New ParameterField()
        param_partido.ParameterFieldName = "Partido"
        '// creo el valor que se asignara al parametro
        Dim valor_partido As New ParameterDiscreteValue()
        If String.IsNullOrEmpty(cedulaCatastral.Partido) = False Then
            valor_partido.Value = cedulaCatastral.Partido
        Else
            valor_partido.Value = ""
        End If
        valor_partido.Value = cedulaCatastral.Partido
        param_partido.CurrentValues.Add(valor_partido)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_partido)

        ' =====================================================
        Dim param_partida As New ParameterField()
        param_partida.ParameterFieldName = "Partida"
        '// creo el valor que se asignara al parametro
        Dim valor_partida As New ParameterDiscreteValue()
        If String.IsNullOrEmpty(cedulaCatastral.Partida) = False Then
            valor_partida.Value = cedulaCatastral.Partida
        Else
            valor_partida.Value = ""
        End If
        param_partida.CurrentValues.Add(valor_partida)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_partida)

        '=====================================================
        Dim param As New ParameterField()
        param.ParameterFieldName = "Circ"
        '// creo el valor que se asignara al parametro
        Dim discreteValue As New ParameterDiscreteValue()

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Circunscripcion) = False Then
            discreteValue.Value = cedulaCatastral.NomenclaturaCatastral.Circunscripcion
        Else
            discreteValue.Value = ""

        End If

        param.CurrentValues.Add(discreteValue)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param)

        '========================
        Dim param_sec As New ParameterField
        param_sec.Name = "Sec"
        Dim valor_sec As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Seccion) = False Then
            valor_sec.Value = cedulaCatastral.NomenclaturaCatastral.Seccion
        Else
            valor_sec.Value = ""
        End If
        param_sec.CurrentValues.Add(valor_sec)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_sec)

        '========================
        Dim param_chacra As New ParameterField
        param_chacra.Name = "chacra"
        Dim valor As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Chacra) = False Then
            valor.Value = cedulaCatastral.NomenclaturaCatastral.Chacra
        Else
            valor.Value = ""
        End If
        valor.Value = "ch"
        param_chacra.CurrentValues.Add(valor)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_chacra)

        '========================
        Dim param_quinta As New ParameterField
        param_quinta.Name = "quinta"
        Dim valor_quinta As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Quinta) = False Then
            valor_quinta.Value = cedulaCatastral.NomenclaturaCatastral.Quinta
        Else
            valor_quinta.Value = ""
        End If

        param_quinta.CurrentValues.Add(valor_quinta)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_quinta)

        '========================
        Dim param_frac As New ParameterField
        param_frac.Name = "fraccion"
        Dim valor_frac As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Fraccion) = False Then
            valor_frac.Value = cedulaCatastral.NomenclaturaCatastral.Fraccion
        Else
            valor_frac.Value = ""
        End If

        'cedulaCatastral.Partido
        param_frac.CurrentValues.Add(valor_frac)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_frac)

        '========================

        Dim param_mzna As New ParameterField
        param_mzna.Name = "manzana"
        Dim valor_mzna As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Manzana) = False Then
            valor_mzna.Value = cedulaCatastral.NomenclaturaCatastral.Manzana
        Else
            valor_mzna.Value = ""
        End If

        param_mzna.CurrentValues.Add(valor_mzna)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_mzna)

        '========================
        Dim param_parcela As New ParameterField
        param_parcela.Name = "parcela"
        Dim valor_parcela As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Parcela) = False Then
            valor_parcela.Value = cedulaCatastral.NomenclaturaCatastral.Parcela
        Else
            valor_parcela.Value = ""
        End If

        param_parcela.CurrentValues.Add(valor_parcela)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_parcela)

        '========================
        Dim param_calle_parce As New ParameterField
        param_calle_parce.Name = "Calle_parce"
        Dim valor_calle_parce As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.Ubicacion.Calle) = False Then
            valor_calle_parce.Value = cedulaCatastral.Ubicacion.Calle
        Else
            valor_calle_parce.Value = ""
        End If
        param_calle_parce.CurrentValues.Add(valor_calle_parce)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_calle_parce)

        ''========================
        Dim param_numero_parce As New ParameterField
        param_numero_parce.Name = "numero_parce"
        Dim valor_numero_parce As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Ubicacion.Nro) = False Then
            valor_numero_parce.Value = cedulaCatastral.Ubicacion.Nro
        Else
            valor_numero_parce.Value = ""
        End If
        param_numero_parce.CurrentValues.Add(valor_numero_parce)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_numero_parce)

        '========================
        Dim param_entreCalle_parce As New ParameterField
        param_entreCalle_parce.Name = "EntreCalle_parce"
        Dim valor_entreCalle_parce As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.Ubicacion.EntreCalle1) = False Then
            valor_entreCalle_parce.Value = cedulaCatastral.Ubicacion.EntreCalle1
        Else
            valor_entreCalle_parce.Value = ""
        End If


        param_entreCalle_parce.CurrentValues.Add(valor_entreCalle_parce)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_entreCalle_parce)

        '========================
        Dim param_yCalle_parce As New ParameterField
        param_yCalle_parce.Name = "YCalle_parce"
        Dim valor_yCalle_parce As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Ubicacion.EntreCalle2) = False Then
            valor_yCalle_parce.Value = cedulaCatastral.Ubicacion.EntreCalle2
        Else
            valor_yCalle_parce.Value = ""
        End If
        param_yCalle_parce.CurrentValues.Add(valor_yCalle_parce)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_yCalle_parce)

        '========================
        Dim param_localidad_parce As New ParameterField
        param_localidad_parce.Name = "Localidad_parce"
        Dim valor_localidad_parce As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.Ubicacion.Localidad) = False Then
            valor_localidad_parce.Value = cedulaCatastral.Ubicacion.Localidad
        Else
            valor_localidad_parce.Value = ""
        End If
        param_localidad_parce.CurrentValues.Add(valor_localidad_parce)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_localidad_parce)
        '========================
        Dim param_codpostal_parce As New ParameterField
        param_codpostal_parce.Name = "Cod_Postal_parce"
        Dim valor_codpostal_parce As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Ubicacion.CodigoPostal) = False Then
            valor_codpostal_parce.Value = cedulaCatastral.Ubicacion.CodigoPostal
        Else
            valor_codpostal_parce.Value = ""
        End If
        param_codpostal_parce.CurrentValues.Add(valor_codpostal_parce)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_codpostal_parce)
        '========================

        '==================================0
        'FALTA COMPLETAR ESTOS DATOS
        '==================================0
        Dim param_car As New ParameterField
        param_car.Name = "Car"
        Dim valor_car As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Parcela) = False Then
            valor_car.Value = cedulaCatastral.NomenclaturaCatastral.Parcela
        Else
            valor_car.Value = ""
        End If
        param_car.CurrentValues.Add(valor_car)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_car)

        '========================
        Dim param_pdo As New ParameterField
        param_pdo.Name = "Pdo"
        Dim valor_pdo As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Partido) = False Then
            valor_pdo.Value = cedulaCatastral.NomenclaturaCatastral.Parcela
        Else
            valor_pdo.Value = ""
        End If
        param_pdo.CurrentValues.Add(valor_pdo)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_pdo)
        '========================
        Dim param_num_orden As New ParameterField
        param_num_orden.Name = "Numero_Orden"
        Dim valor_numero_orden As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Parcela) = False Then
            valor_numero_orden.Value = cedulaCatastral.NomenclaturaCatastral.Parcela
        Else
            valor_numero_orden.Value = ""
        End If
        param_num_orden.CurrentValues.Add(valor_numero_orden)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_num_orden)
        '========================
        Dim param_año As New ParameterField
        param_año.Name = "Año"
        Dim valor_año As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Parcela) = False Then
            valor_año.Value = cedulaCatastral.NomenclaturaCatastral.Parcela
        Else
            valor_año.Value = ""
        End If
        param_año.CurrentValues.Add(valor_año)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_año)
        '========================
        Dim param_desigancion As New ParameterField
        param_desigancion.Name = "Designacion_d_Bien"
        Dim valor_desigancion As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Designacion) = False Then
            valor_desigancion.Value = cedulaCatastral.Designacion
        Else
            valor_desigancion.Value = ""
        End If
        param_desigancion.CurrentValues.Add(valor_desigancion)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_desigancion)

        '========================
        Dim param_medidasLinderos As New ParameterField
        param_medidasLinderos.Name = "Medidas_L_y_S"
        Dim valor_medidaslinderos As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Medidas) = False Then
            valor_medidaslinderos.Value = cedulaCatastral.Medidas
        Else
            valor_medidaslinderos.Value = ""
        End If

        param_medidasLinderos.CurrentValues.Add(valor_medidaslinderos)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_medidasLinderos)

        '========================
        Dim param_Catastral_Linderos As New ParameterField
        param_Catastral_Linderos.Name = "Catastral_Medidas_L_y_S"
        Dim valor_Catastral_linderos As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Parcela) = False Then
            valor_Catastral_linderos.Value = cedulaCatastral.NomenclaturaCatastral.Parcela
        Else
            valor_Catastral_linderos.Value = ""
        End If


        param_Catastral_Linderos.CurrentValues.Add(valor_Catastral_linderos)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_Catastral_Linderos)

        '========================
        Dim param_restricciones As New ParameterField
        param_restricciones.Name = "Restricciones"
        Dim valor_retri As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Parcela) = False Then
            valor_retri.Value = cedulaCatastral.NomenclaturaCatastral.Parcela
        Else
            valor_retri.Value = ""
        End If
        param_restricciones.CurrentValues.Add(valor_retri)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_restricciones)
        '==========HASTA ACA FALTA COMPLETAR



        '========================
        Dim param_titular_nombre As New ParameterField
        param_titular_nombre.Name = "Titular_nombre"
        Dim valor_titular_nom As New ParameterDiscreteValue
        If String.IsNullOrEmpty(dueño.Nombre) = False Then
            valor_titular_nom.Value = dueño.Nombre
        Else
            valor_titular_nom.Value = ""
        End If


        param_titular_nombre.CurrentValues.Add(valor_titular_nom)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_nombre)


        '========================
        Dim param_titular_tipoDni As New ParameterField
        param_titular_tipoDni.Name = "Titular_tipo_Dni"
        Dim valo_tipoDni As New ParameterDiscreteValue
        If String.IsNullOrEmpty(dueño.TipoDoc) = False Then
            valo_tipoDni.Value = dueño.TipoDoc
        Else
            valo_tipoDni.Value = ""
        End If

        param_titular_tipoDni.CurrentValues.Add(valo_tipoDni)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_tipoDni)

        '========================
        Dim param_titular_Dni As New ParameterField
        param_titular_Dni.Name = "Titular_Numero_Dni"
        Dim valor_Dni As New ParameterDiscreteValue
        If String.IsNullOrEmpty(dueño.NumeroDoc) = False Then
            valor_Dni.Value = dueño.NumeroDoc
        Else
            valor_Dni.Value = ""
        End If

        param_titular_Dni.CurrentValues.Add(valor_Dni)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_Dni)

        '========================
        Dim param_titular_calle As New ParameterField
        param_titular_calle.Name = "Titular_Calle"
        Dim valor_calle As New ParameterDiscreteValue

        If String.IsNullOrEmpty(dueño.Calle) = False Then
            valor_calle.Value = dueño.Calle
        Else
            valor_calle.Value = ""
        End If

        param_titular_calle.CurrentValues.Add(valor_calle)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_calle)

        '========================
        Dim param_titular_numerocalle As New ParameterField
        param_titular_numerocalle.Name = "Titular_Numrero_Calle"
        Dim valor_ncalle As New ParameterDiscreteValue
        If String.IsNullOrEmpty(dueño.NumeroCalle) = False Then
            valor_ncalle.Value = dueño.NumeroCalle
        Else
            valor_ncalle.Value = ""
        End If

        param_titular_numerocalle.CurrentValues.Add(valor_ncalle)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_numerocalle)

        '========================
        Dim param_titular_cuerpo As New ParameterField
        param_titular_cuerpo.Name = "Titular_Cuerpo"
        Dim valor_cuerpo As New ParameterDiscreteValue
        If String.IsNullOrEmpty(dueño.Cuerpo) = False Then
            valor_cuerpo.Value = dueño.Cuerpo
        Else
            valor_cuerpo.Value = ""
        End If
        param_titular_cuerpo.CurrentValues.Add(valor_cuerpo)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_cuerpo)

        '========================
        Dim param_titular_piso As New ParameterField
        param_titular_piso.Name = "Titular_Piso"
        Dim valor_piso As New ParameterDiscreteValue
        If String.IsNullOrEmpty(dueño.Piso) = False Then
            valor_piso.Value = dueño.Piso
        Else
            valor_piso.Value = ""
        End If
        param_titular_piso.CurrentValues.Add(valor_piso)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_piso)

        '========================
        Dim param_titular_dpto As New ParameterField
        param_titular_dpto.Name = "Titular_Dpto"
        Dim valor_dpto As New ParameterDiscreteValue
        If String.IsNullOrEmpty(dueño.Dpto) = False Then
            valor_dpto.Value = dueño.Dpto
        Else
            valor_dpto.Value = ""
        End If

        param_titular_dpto.CurrentValues.Add(valor_dpto)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_dpto)

        '========================
        Dim param_titular_localidad As New ParameterField
        param_titular_localidad.Name = "Titular_Localidad"
        Dim valor_loca As New ParameterDiscreteValue

        If String.IsNullOrEmpty(dueño.Localidad) = False Then
            valor_loca.Value = dueño.Localidad
        Else
            valor_loca.Value = ""
        End If
        param_titular_localidad.CurrentValues.Add(valor_loca)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_localidad)

        '========================
        Dim param_titular_prov As New ParameterField
        param_titular_prov.Name = "Titular_Provincia"
        Dim valor_prov As New ParameterDiscreteValue
        If String.IsNullOrEmpty(dueño.Provincia) = False Then
            valor_prov.Value = dueño.Provincia
        Else
            valor_prov.Value = ""
        End If
        param_titular_prov.CurrentValues.Add(valor_prov)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_prov)

        '========================
        Dim param_titular_cp As New ParameterField
        param_titular_cp.Name = "Titular_CP"
        Dim valor_cp As New ParameterDiscreteValue

        If String.IsNullOrEmpty(dueño.CodigoP) = False Then
            valor_cp.Value = dueño.CodigoP
        Else
            valor_cp.Value = ""
        End If

        param_titular_cp.CurrentValues.Add(valor_cp)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_titular_cp)
        '========================
        Dim param_plano_parcela As New ParameterField
        param_plano_parcela.Name = "Plano_Parcela"
        Dim valor_plano_parce As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Parcela) = False Then
            valor_plano_parce.Value = cedulaCatastral.NomenclaturaCatastral.Parcela
        Else
            valor_plano_parce.Value = ""
        End If

        param_plano_parcela.CurrentValues.Add(valor_plano_parce)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_plano_parcela)


        '========================
        Dim param_plano_circ As New ParameterField
        param_plano_circ.Name = "Plano_Circ"
        Dim valor_plano_c As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Circunscripcion) = False Then
            valor_plano_c.Value = cedulaCatastral.NomenclaturaCatastral.Circunscripcion
        Else
            valor_plano_c.Value = ""
        End If
        param_plano_circ.CurrentValues.Add(valor_plano_c)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_plano_circ)

        '========================
        Dim param_plano_sec As New ParameterField
        param_plano_sec.Name = "Plano_Sec"
        Dim valor_plano_s As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Seccion) = False Then
            valor_plano_s.Value = cedulaCatastral.NomenclaturaCatastral.Seccion
        Else
            valor_plano_s.Value = ""
        End If

        param_plano_sec.CurrentValues.Add(valor_plano_s)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_plano_sec)

        '========================
        Dim param_plano_ch As New ParameterField
        param_plano_ch.Name = "Plano_Chacra"
        Dim valor_plano_cha As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Chacra) = False Then
            valor_plano_cha.Value = cedulaCatastral.NomenclaturaCatastral.Seccion
        Else
            valor_plano_cha.Value = ""
        End If

        param_plano_ch.CurrentValues.Add(valor_plano_cha)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_plano_ch)

        '========================
        Dim param_plano_qui As New ParameterField
        param_plano_qui.Name = "Plano_Quinta"
        Dim valor_plano_qui As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Quinta) = False Then
            valor_plano_qui.Value = cedulaCatastral.NomenclaturaCatastral.Quinta
        Else
            valor_plano_qui.Value = ""
        End If
        param_plano_qui.CurrentValues.Add(valor_plano_qui)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_plano_qui)

        '========================
        Dim param_plano_f As New ParameterField
        param_plano_f.Name = "Plano_Faccion"
        Dim valor_plano_f As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Fraccion) = False Then
            valor_plano_f.Value = cedulaCatastral.NomenclaturaCatastral.Fraccion
        Else
            valor_plano_f.Value = ""
        End If
        param_plano_f.CurrentValues.Add(valor_plano_f)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_plano_f)

        '========================
        Dim param_plano_m As New ParameterField
        param_plano_m.Name = "Plano_Manzana"
        Dim valor_plano_m As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.NomenclaturaCatastral.Manzana) = False Then
            valor_plano_m.Value = cedulaCatastral.NomenclaturaCatastral.Manzana
        Else
            valor_plano_m.Value = ""
        End If
        param_plano_m.CurrentValues.Add(valor_plano_m)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_plano_m)

        '========================
        Dim param_plano_par As New ParameterField
        param_plano_par.Name = "Plano_Partido"
        Dim valor_plano_p As New ParameterDiscreteValue

        If String.IsNullOrEmpty(cedulaCatastral.PartidoNombre) = False Then
            valor_plano_p.Value = cedulaCatastral.PartidoNombre
        Else
            valor_plano_p.Value = ""
        End If
        param_plano_par.CurrentValues.Add(valor_plano_p)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(param_plano_par)
        '========================================
        '===================================================
        'HOJA DOS
        '===================================================
        '========================
        Dim imagen As New ParameterField
        imagen.Name = "ima"
        Dim valor_ima As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Croquis) = False Then
            valor_ima.Value = cedulaCatastral.Croquis
        Else
            valor_ima.Value = ""
        End If
        imagen.CurrentValues.Add(valor_ima)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(imagen)




        Dim pavimento As New ParameterField
        pavimento.Name = "pavimento"
        Dim valor_pavimento As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Pavimento) = False Then
            valor_pavimento.Value = cedulaCatastral.Pavimento
        Else
            valor_pavimento.Value = ""
        End If
        pavimento.CurrentValues.Add(valor_pavimento)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(pavimento)
        '===================================================
        Dim alumbrado As New ParameterField
        alumbrado.Name = "alumbrado"
        Dim valor_alumbrado As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Alumbrado) = False Then
            valor_alumbrado.Value = cedulaCatastral.Alumbrado
        Else
            valor_alumbrado.Value = ""
        End If
        alumbrado.CurrentValues.Add(valor_alumbrado)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(alumbrado)

        '===================================================
        Dim agua As New ParameterField
        agua.Name = "agua"
        Dim valor_agua As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.AguaCorriente) = False Then
            valor_agua.Value = cedulaCatastral.AguaCorriente
        Else
            valor_agua.Value = ""
        End If
        agua.CurrentValues.Add(valor_agua)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(agua)
        '===================================================
        Dim cloacas As New ParameterField
        cloacas.Name = "cloacas"
        Dim valor_cloacas As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Cloacas) = False Then
            valor_cloacas.Value = cedulaCatastral.Cloacas

        Else
            valor_cloacas.Value = ""
        End If
        cloacas.CurrentValues.Add(valor_cloacas)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(cloacas)

        '===================================================
        Dim energia As New ParameterField
        energia.Name = "luz"
        Dim valor_energia As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Electrica) = False Then
            valor_energia.Value = cedulaCatastral.Electrica

        Else
            valor_energia.Value = ""
        End If
        energia.CurrentValues.Add(valor_energia)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(energia)
        '===================================================
        Dim gas As New ParameterField
        gas.Name = "gas"
        Dim valor_gas As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_gas.Value = cedulaCatastral.Gas

        Else
            valor_gas.Value = ""
        End If
        gas.CurrentValues.Add(valor_gas)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(gas)

        '=======================================================
        Dim destinatario As New ParameterField
        destinatario.Name = "destinatario"
        Dim valor_destina As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_destina.Value = "Nombre Destinatario"

        Else
            valor_destina.Value = ""
        End If
        destinatario.CurrentValues.Add(valor_destina)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario)


        '=======================================================
        Dim destinatario_calle As New ParameterField
        destinatario_calle.Name = "destinatario_calle"
        Dim valor_d_calle As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_d_calle.Value = "Nombre Calle"

        Else
            valor_d_calle.Value = ""
        End If
        destinatario_calle.CurrentValues.Add(valor_d_calle)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario_calle)
        '=======================================================
        Dim destinatario_numero As New ParameterField
        destinatario_numero.Name = "destinatatio_num"
        Dim valor_d_numero As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_d_numero.Value = "Nombre Calle"

        Else
            valor_d_numero.Value = ""
        End If
        destinatario_numero.CurrentValues.Add(valor_d_numero)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario_numero)
        '=======================================================
        Dim destinatario_cuerpo As New ParameterField
        destinatario_cuerpo.Name = "destinatario_cuerpo"
        Dim valor_d_cuerpo As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_d_cuerpo.Value = "Nombre Calle"

        Else
            valor_d_cuerpo.Value = ""
        End If
        destinatario_cuerpo.CurrentValues.Add(valor_d_cuerpo)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario_cuerpo)

        '=======================================================

        '=======================================================
        Dim destinatario_piso As New ParameterField
        destinatario_piso.Name = "destinatario_piso"
        Dim valor_d_piso As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_d_piso.Value = "Nombre Calle"

        Else
            valor_d_piso.Value = ""
        End If
        destinatario_piso.CurrentValues.Add(valor_d_piso)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario_piso)
        '=======================================================
        Dim destinatario_dpto As New ParameterField
        destinatario_dpto.Name = "destinatario_dpto"
        Dim valor_d_dpto As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_d_dpto.Value = "Nombre Calle"

        Else
            valor_d_dpto.Value = ""
        End If
        destinatario_dpto.CurrentValues.Add(valor_d_dpto)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario_dpto)
        '=======================================================
        '=======================================================
        Dim destinatario_localidad As New ParameterField
        destinatario_localidad.Name = "destinatario_localidad"
        Dim valor_d_localidad As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_d_localidad.Value = "Nombre Calle"

        Else
            valor_d_localidad.Value = ""
        End If
        destinatario_localidad.CurrentValues.Add(valor_d_localidad)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario_localidad)
        '=======================================================
        '=======================================================
        Dim destinatario_pcia As New ParameterField
        destinatario_pcia.Name = "destinatario_pcia"
        Dim valor_d_pcia As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_d_pcia.Value = "Nombre Calle"

        Else
            valor_d_pcia.Value = ""
        End If
        destinatario_pcia.CurrentValues.Add(valor_d_pcia)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario_pcia)
        '=======================================================

        '=======================================================
        Dim destinatario_cp As New ParameterField
        destinatario_cp.Name = "destinatario_cp"
        Dim valor_d_cp As New ParameterDiscreteValue
        If String.IsNullOrEmpty(cedulaCatastral.Gas) = False Then
            valor_d_cp.Value = "Nombre Calle"

        Else
            valor_d_cp.Value = ""
        End If
        destinatario_cp.CurrentValues.Add(valor_d_cp)
        '// Asigno el paramametro a la coleccion
        paramFiels.Add(destinatario_cp)
        '=======================================================



        CrystalReportViewer1.ParameterFieldInfo = paramFiels

        ' Me.ShowDialog()
    End Sub

    Private Sub Exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim grabar As SaveFileDialog = New SaveFileDialog
        'Título del cuadro de diálogo.
        grabar.AddExtension = True
        grabar.FileName = "CEDULA"
        grabar.Title = "Exportar Cédula(Consejo Profesional de Agrimensores)"

        'Filtro para el tipo de archivo a guardar.
        '
        ' 1 = Excel
        ' 3 = Word
        ' 4 = PDF
        '
        grabar.Filter = "Adobe Acrobat (*.pdf)|*.pdf" '"Microsoft Excel (*.xls)|*.xls" & _
        '   "|Microsoft Excel (Sólo Datos)|*.xls|Adobe Acrobat (*.pdf)|*.pdf|Microsoft Word (*.doc)|*.doc"
        'Mostrar como predeterminado el tipo # 1
        ' grabar.FilterIndex = 4
        'Si se presiona botón Guardar
        If (grabar.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Dim opcionesRpt As DiskFileDestinationOptions = New DiskFileDestinationOptions
            Dim rptDoc As ReportDocument = CType(Me.CrystalReportViewer1.ReportSource, ReportDocument)
            'Configurando la exportación del reporte
            Dim opcionesExportacion As ExportOptions = rptDoc.ExportOptions
            'El nombre del archivo a exportar será el que se ingrese
            'en el cuadro de diálogo.
            opcionesRpt.DiskFileName = grabar.FileName
            opcionesExportacion.ExportDestinationOptions = opcionesRpt
            'Indica que se guardarán los archivos en el disco duro
            opcionesExportacion.ExportDestinationType = ExportDestinationType.DiskFile
            ' Select Case (grabar.FilterIndex)
            '  Case 1
            '.xls (97 - 2003)
            '    opcionesExportacion.ExportFormatType = ExportFormatType.Excel
            'Pasar al reporte la configuración establecida.
            ' rptDoc.Export(opcionesExportacion)
            '    Case 3
            ' .doc (97 - 2003)
            '      opcionesExportacion.ExportFormatType = ExportFormatType.WordForWindows
            'Pasar al reporte la configuración establecida.
            '       rptDoc.Export(opcionesExportacion)
            'Case 4
            ' .pdf
            opcionesExportacion.ExportFormatType = ExportFormatType.PortableDocFormat
            'Pasar al reporte la configuración establecida.
            rptDoc.Export(opcionesExportacion)
            'End Select
            'Mensaje al finalizar la exportación
            MessageBox.Show("La exportación ha finalizado correctamente.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class