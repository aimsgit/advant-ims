Imports Microsoft.VisualBasic

Public Class ELAimsUsageAnalytics
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _InstId As String
    Public Property InstId() As String
        Get
            Return _InstId
        End Get
        Set(ByVal value As String)
            _InstId = value
        End Set
    End Property
    Private _BranchId As String
    Public Property BranchId() As String
        Get
            Return _BranchId
        End Get
        Set(ByVal value As String)
            _BranchId = value
        End Set
    End Property
    Private _TableId As Integer
    Public Property TableId() As Integer
        Get
            Return _TableId
        End Get
        Set(ByVal value As Integer)
            _TableId = value
        End Set
    End Property
    Private _FromDate As DateTime
    Public Property FromDate() As DateTime
        Get
            Return _FromDate
        End Get
        Set(ByVal value As DateTime)
            _FromDate = value
        End Set
    End Property
    Private _ToDate As DateTime
    Public Property ToDate() As DateTime
        Get
            Return _ToDate
        End Get
        Set(ByVal value As DateTime)
            _ToDate = value
        End Set
    End Property
End Class
