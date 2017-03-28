Imports Microsoft.VisualBasic

Public Class ELExchangeRateTable
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _Cname As String
    Public Property CName() As String
        Get
            Return _Cname
        End Get
        Set(ByVal value As String)
            _Cname = value
        End Set
    End Property
    Private _CCode As Integer
    Public Property CCode() As Integer
        Get
            Return _CCode
        End Get
        Set(ByVal value As Integer)
            _CCode = value
        End Set
    End Property
    Private _CSymbol As String
    Public Property CSymbol() As String
        Get
            Return _CSymbol
        End Get
        Set(ByVal value As String)
            _CSymbol = value
        End Set
    End Property
    Private _BRate As Double
    Public Property BRate() As Double
        Get
            Return _BRate
        End Get
        Set(ByVal value As Double)
            _BRate = value
        End Set
    End Property
    Private _SRate As Double
    Public Property SRate() As Double
        Get
            Return _SRate
        End Get
        Set(ByVal value As Double)
            _SRate = value
        End Set
    End Property
    Private _Cone As String
    Public Property Cone() As String
        Get
            Return _Cone
        End Get
        Set(ByVal value As String)
            _Cone = value
        End Set
    End Property
    Private _Ctwo As String
    Public Property Ctwo() As String
        Get
            Return _Ctwo
        End Get
        Set(ByVal value As String)
            _Ctwo = value
        End Set
    End Property
End Class
