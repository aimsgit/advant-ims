Imports Microsoft.VisualBasic

Public Class Mfg_ELUnit
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Private _Conversion As Double
    Public Property Conversion() As Double
        Get
            Return _Conversion
        End Get
        Set(ByVal value As Double)
            _Conversion = value
        End Set
    End Property
End Class
