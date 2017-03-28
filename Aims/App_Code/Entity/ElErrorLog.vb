Imports Microsoft.VisualBasic

Public Class ElErrorLog
    Private _EDate As Date
    Public Property EDate() As Date
        Get
            Return _EDate
        End Get
        Set(ByVal value As Date)
            _EDate = value
        End Set
    End Property
    Private _TDate As Date
    Public Property TDate() As Date
        Get
            Return _TDate
        End Get
        Set(ByVal value As Date)
            _TDate = value
        End Set
    End Property
    Private _LogId As Int64
    Public Property LogId() As Int64
        Get
            Return _LogId
        End Get
        Set(ByVal value As Int64)
            _LogId = value
        End Set
    End Property
    Private _EStatus As String
    Public Property Estatus() As String
        Get
            Return _EStatus
        End Get
        Set(ByVal value As String)
            _EStatus = value
        End Set
    End Property
    Private _totalcount As Int64
    Public Property TotalCount() As Int64
        Get
            Return _totalcount
        End Get
        Set(ByVal value As Int64)
            _totalcount = value
        End Set
    End Property
End Class
