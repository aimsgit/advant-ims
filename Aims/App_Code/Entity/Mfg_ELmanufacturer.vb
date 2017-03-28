Imports Microsoft.VisualBasic

Public Class Mfg_ELmanufacturer
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Manufacturer As String
    Public Property Manufacturer() As String
        Get
            Return _Manufacturer
        End Get
        Set(ByVal value As String)
            _Manufacturer = value
        End Set
    End Property
    Private _Country As String
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            _Country = value
        End Set
    End Property
    Private _DisLock As String
    Public Property DisLock() As String
        Get
            Return _DisLock
        End Get
        Set(ByVal value As String)
            _DisLock = value
        End Set
    End Property
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
End Class
