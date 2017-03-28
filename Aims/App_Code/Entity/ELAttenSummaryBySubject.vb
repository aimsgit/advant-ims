Imports Microsoft.VisualBasic

Public Class ELAttenSummaryBySubject
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Stdcode As String
    Public Property Stdcode() As String
        Get
            Return _Stdcode
        End Get
        Set(ByVal value As String)
            _Stdcode = value
        End Set
    End Property
    Private _StdName As String
    Public Property StdName() As String
        Get
            Return _StdName
        End Get
        Set(ByVal value As String)
            _StdName = value
        End Set
    End Property
    Private _Bid As String
    Public Property Bid() As String
        Get
            Return _Bid
        End Get
        Set(ByVal value As String)
            _Bid = value
        End Set
    End Property
    Private _Sid As String
    Public Property Sid() As String
        Get
            Return _Sid
        End Get
        Set(ByVal value As String)
            _Sid = value
        End Set
    End Property
    Private _SubId As Integer
    Public Property SubId() As Integer
        Get
            Return _SubId
        End Get
        Set(ByVal value As Integer)
            _SubId = value
        End Set
    End Property
    Private _TotAtten As Integer
    Public Property TotAtten() As Integer
        Get
            Return _TotAtten
        End Get
        Set(ByVal value As Integer)
            _TotAtten = value
        End Set
    End Property
    Private _ActualAtten As Integer
    Public Property ActualAtten() As Integer
        Get
            Return _ActualAtten
        End Get
        Set(ByVal value As Integer)
            _ActualAtten = value
        End Set
    End Property
    Private _AttenPer As Double
    Public Property AttenPer() As Double
        Get
            Return _AttenPer
        End Get
        Set(ByVal value As Double)
            _AttenPer = value
        End Set
    End Property
    Private _AsOnDate As DateTime
    Public Property AsOnDate() As DateTime
        Get
            Return _AsOnDate
        End Get
        Set(ByVal value As DateTime)
            _AsOnDate = value
        End Set
    End Property

End Class
