Imports Microsoft.VisualBasic

Public Class ConfigProcessP
    Private _ID As Long
    Public Property ID() As Long
        Get
            Return _ID
        End Get
        Set(ByVal value As Long)
            _ID = value
        End Set
    End Property
    Private _TableID As Long
    Public Property TableID() As Long
        Get
            Return _TableID
        End Get
        Set(ByVal value As Long)
            _TableID = value
        End Set
    End Property
    Private _AppReq As String
    Public Property AppReq() As String
        Get
            Return _AppReq
        End Get
        Set(ByVal value As String)
            _AppReq = value
        End Set
    End Property
    Private _AppBy As String
    Public Property AppBy() As String
        Get
            Return _AppBy
        End Get
        Set(ByVal value As String)
            _AppBy = value
        End Set
    End Property
    Private _TableName As String
    Public Property TableName() As String
        Get
            Return _TableName
        End Get
        Set(ByVal value As String)
            _TableName = value
        End Set
    End Property
End Class
