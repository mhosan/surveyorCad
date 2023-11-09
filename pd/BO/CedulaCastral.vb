Namespace BO
    Public Class CedulaCastral
        Private _partido As String
        Private _partidoNombre As String
        Private _nomenclaturaCatastral As NomenclaturaCatastral
        Private _partida As String
        Private _ubicacion As Direccion
        Private _direccionTitular As Direccion
        Private _croquis As String
        Private _medidas As String
        Private _designacion As String
        Private _pavimento As String
        Private _alumbrado As String
        Private _electrica As String
        Private _aguaCorriente As String
        Private _gas As String
        Private _cloacas As String
        Private _paCircunscripcion As String
        Private _paSeccion As String
        Private _paChacra As String
        Private _paQuinta As String
        Private _paFraccion As String
        Private _paManzana As String
        Private _paParcela As String
        Private _paPartido As String

        Property PartidoNombre() As String
            Get
                Return _partidoNombre
            End Get
            Set(ByVal value As String)
                _partidoNombre = value
            End Set
        End Property
        Property PaCircunscripcion() As String
            Get
                Return _paCircunscripcion
            End Get
            Set(ByVal value As String)
                _paCircunscripcion = value
            End Set
        End Property

        Property PaSeccion() As String
            Get
                Return _paSeccion
            End Get
            Set(ByVal value As String)
                _paSeccion = value
            End Set
        End Property

        Property PaChacra() As String
            Get
                Return _paChacra
            End Get
            Set(ByVal value As String)
                _paChacra = value
            End Set
        End Property

        Property PaQuinta() As String
            Get
                Return _paQuinta
            End Get
            Set(ByVal value As String)
                _paQuinta = value
            End Set
        End Property

        Property PaFraccion() As String
            Get
                Return _paFraccion
            End Get
            Set(ByVal value As String)
                _paFraccion = value
            End Set
        End Property

        Property PaManzana() As String
            Get
                Return _paManzana
            End Get
            Set(ByVal value As String)
                _paManzana = value
            End Set
        End Property

        Property PaParcela() As String
            Get
                Return _paParcela
            End Get
            Set(ByVal value As String)
                _paParcela = value
            End Set
        End Property
        Property PaPartido() As String
            Get
                Return _paPartido
            End Get
            Set(ByVal value As String)
                _paPartido = value
            End Set
        End Property

        Public Property Cloacas() As String
            Get
                Return _cloacas
            End Get
            Set(ByVal value As String)
                _cloacas = value
            End Set
        End Property

        Public Property Gas() As String
            Get
                Return _gas
            End Get
            Set(ByVal value As String)
                _gas = value
            End Set
        End Property

        Public Property AguaCorriente() As String
            Get
                Return _aguaCorriente
            End Get
            Set(ByVal value As String)
                _aguaCorriente = value
            End Set
        End Property

        Public Property Electrica() As String
            Get
                Return _electrica
            End Get
            Set(ByVal value As String)
                _electrica = value
            End Set
        End Property
        Public Property Pavimento() As String
            Get
                Return _pavimento
            End Get
            Set(ByVal value As String)
                _pavimento = value
            End Set
        End Property


        Public Property Alumbrado() As String
            Get
                Return _alumbrado
            End Get
            Set(ByVal value As String)
                _alumbrado = value
            End Set
        End Property

        Public Property Designacion() As String
            Get
                Return _designacion
            End Get
            Set(ByVal value As String)
                _designacion = value
            End Set
        End Property


        Public Sub New()
            NomenclaturaCatastral = New NomenclaturaCatastral()
            Ubicacion = New Direccion()
            DireccionTitular = New Direccion()
        End Sub


        Property Partido() As String
            Get
                Return _partido
            End Get
            Set(ByVal value As String)
                _partido = value
            End Set
        End Property

        Property NomenclaturaCatastral() As NomenclaturaCatastral
            Get
                Return _nomenclaturaCatastral
            End Get
            Set(ByVal value As NomenclaturaCatastral)
                _nomenclaturaCatastral = value
            End Set
        End Property

        Property Partida() As String
            Get
                Return _partida
            End Get
            Set(ByVal value As String)
                _partida = value
            End Set
        End Property

        Property Ubicacion() As Direccion
            Get
                Return _ubicacion
            End Get
            Set(ByVal value As Direccion)
                _ubicacion = value
            End Set
        End Property

        Property DireccionTitular() As Direccion
            Get
                Return _direccionTitular
            End Get
            Set(ByVal value As Direccion)
                _direccionTitular = value
            End Set
        End Property

        Property Croquis() As String
            Get
                Return _croquis
            End Get
            Set(ByVal value As String)
                _croquis = value
            End Set
        End Property

        Private ReadOnly Property Length() As Integer
            Get
                Return _partido.Length
            End Get
        End Property

        Property Medidas() As String
            Get
                Return _medidas
            End Get
            Set(ByVal value As String)
                _medidas = value
            End Set
        End Property

    End Class


    Public Class Persona
        Private _nombre As String
        Private _tipo_doc As String
        Private _numeroDoc As String
        Private _calle As String
        Private _numeroCalle As String
        Private _cuerpo As String
        Private _piso As String
        Private _dpto As String
        Private _localidad As String
        Private _provincia As String
        Private _codigoPostal As String


        Property Nombre() As String
            Get
                Return _nombre
            End Get
            Set(ByVal value As String)
                _nombre = value
            End Set
        End Property
        Property TipoDoc() As String
            Get
                Return _tipo_doc
            End Get
            Set(ByVal value As String)
                _tipo_doc = value
            End Set
        End Property


        Property NumeroDoc() As String
            Get
                Return _numeroDoc
            End Get
            Set(ByVal value As String)
                _numeroDoc = value
            End Set
        End Property
        Property Calle() As String
            Get
                Return _calle
            End Get
            Set(ByVal value As String)
                _calle = value
            End Set
        End Property


        Property NumeroCalle() As String
            Get
                Return _numeroCalle
            End Get
            Set(ByVal value As String)
                _numeroCalle = value
            End Set
        End Property
        Property Cuerpo() As String
            Get
                Return _cuerpo
            End Get
            Set(ByVal value As String)
                _cuerpo = value
            End Set
        End Property
        Property Piso() As String
            Get
                Return _piso
            End Get
            Set(ByVal value As String)
                _piso = value
            End Set
        End Property
        Property Dpto() As String
            Get
                Return _dpto
            End Get
            Set(ByVal value As String)
                _dpto = value
            End Set
        End Property

        Property Localidad() As String
            Get
                Return _localidad
            End Get
            Set(ByVal value As String)
                _localidad = value
            End Set
        End Property

        Property Provincia() As String
            Get
                Return _provincia
            End Get
            Set(ByVal value As String)
                _provincia = value
            End Set
        End Property
        Property CodigoP() As String
            Get
                Return _codigoPostal
            End Get
            Set(ByVal value As String)
                _codigoPostal = value
            End Set
        End Property


    End Class
End Namespace