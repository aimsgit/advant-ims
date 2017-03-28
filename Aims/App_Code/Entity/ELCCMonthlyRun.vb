Imports Microsoft.VisualBasic

Public Class ELCCMonthlyRun
    Private _ClientID As String
    Public Property ClientID() As String
        Get
            Return _ClientID
        End Get
        Set(ByVal value As String)
            _ClientID = value
        End Set
    End Property
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
    Private _InvoiceNo As String
    Public Property InvoiceNo() As String
        Get
            Return _InvoiceNo
        End Get
        Set(ByVal value As String)
            _InvoiceNo = value
        End Set
    End Property
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _FromMonth As Integer
    Public Property FromMonth() As Integer
        Get
            Return _FromMonth
        End Get
        Set(ByVal value As Integer)
            _FromMonth = value
        End Set
    End Property
    Private _ToMonth As Integer
    Public Property ToMonth() As Integer
        Get
            Return _ToMonth
        End Get
        Set(ByVal value As Integer)
            _ToMonth = value
        End Set
    End Property
    Private _FromYear As Integer
    Public Property FromYear() As Integer
        Get
            Return _FromYear
        End Get
        Set(ByVal value As Integer)
            _FromYear = value
        End Set
    End Property
    Private _ToYear As Integer
    Public Property ToYear() As Integer
        Get
            Return _ToYear
        End Get
        Set(ByVal value As Integer)
            _ToYear = value
        End Set
    End Property
End Class
