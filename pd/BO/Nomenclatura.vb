Namespace BO
    Public Class Nomenclatura
        Inherits NomenclaturaCatastral
       
        Private _chacraLetra As String
        Private _quintaLetra As String
        Private _fraccionLetra As String
        Private _manzanaLetra As String
        Private _parcelaLetra As String
       
        Property ChacraLetra() As String
            Get
                Return _chacraLetra
            End Get
            Set(ByVal value As String)
                _chacraLetra = value
            End Set
        End Property

        Property QuintaLetra() As String
            Get
                Return _quintaLetra
            End Get
            Set(ByVal value As String)
                _quintaLetra = value
            End Set
        End Property

        Property FraccionLetra() As String
            Get
                Return _fraccionLetra
            End Get
            Set(ByVal value As String)
                _fraccionLetra = value
            End Set
        End Property

        Property ManzanaLetra() As String
            Get
                Return _manzanaLetra
            End Get
            Set(ByVal value As String)
                _manzanaLetra = value
            End Set
        End Property

        Property ParcelaLetra() As String
            Get
                Return _parcelaLetra
            End Get
            Set(ByVal value As String)
                _parcelaLetra = value
            End Set
        End Property

    End Class
End Namespace

