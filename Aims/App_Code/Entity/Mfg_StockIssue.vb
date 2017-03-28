Imports Microsoft.VisualBasic

Public Class Mfg_StockIssue
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _IssueNo As String
    Public Property IssueNo() As String
        Get
            Return _IssueNo
        End Get
        Set(ByVal value As String)
            _IssueNo = value
        End Set
    End Property
    Private _DCNo As String
    Public Property DCNo() As String
        Get
            Return _DCNo
        End Get
        Set(ByVal value As String)
            _DCNo = value
        End Set
    End Property
    Private _EntryDate As DateTime
    Public Property EntryDate() As DateTime
        Get
            Return _EntryDate
        End Get
        Set(ByVal value As DateTime)
            _EntryDate = value
        End Set
    End Property
    Private _WorkOrder As Integer
    Public Property WorkOrder() As Integer
        Get
            Return _WorkOrder
        End Get
        Set(ByVal value As Integer)
            _WorkOrder = value
        End Set
    End Property
    Private _IndentNo As String
    Public Property IndentNo() As String
        Get
            Return _IndentNo
        End Get
        Set(ByVal value As String)
            _IndentNo = value
        End Set
    End Property
    Private _DONo As String
    Public Property DONo() As String
        Get
            Return _DONo
        End Get
        Set(ByVal value As String)
            _DONo = value
        End Set
    End Property
    Private _PartyName As Integer
    Public Property PartyName() As Integer
        Get
            Return _PartyName
        End Get
        Set(ByVal value As Integer)
            _PartyName = value
        End Set
    End Property
    Private _ProductId As Integer
    Public Property ProductId() As Integer
        Get
            Return _ProductId
        End Get
        Set(ByVal value As Integer)
            _ProductId = value
        End Set
    End Property
    Private _CV As Integer
    Public Property CV() As Integer
        Get
            Return _CV
        End Get
        Set(ByVal value As Integer)
            _CV = value
        End Set
    End Property
    Private _QtyIssued As Integer
    Public Property QtyIssued() As Integer
        Get
            Return _QtyIssued
        End Get
        Set(ByVal value As Integer)
            _QtyIssued = value
        End Set
    End Property
    Private _QtyReturned As Integer
    Public Property QtyReturned() As Integer
        Get
            Return _QtyReturned
        End Get
        Set(ByVal value As Integer)
            _QtyReturned = value
        End Set
    End Property
    Private _ExpiryDate As DateTime
    Public Property ExpiryDate() As DateTime
        Get
            Return _ExpiryDate
        End Get
        Set(ByVal value As DateTime)
            _ExpiryDate = value
        End Set
    End Property
    Private _PartyType As Integer
    Public Property PartyType() As Integer
        Get
            Return _PartyType
        End Get
        Set(ByVal value As Integer)
            _PartyType = value
        End Set
    End Property
    Private _BatchId As Integer
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Private _StockIssueId As Integer
    Public Property StockIssueId() As Integer
        Get
            Return _StockIssueId
        End Get
        Set(ByVal value As Integer)
            _StockIssueId = value
        End Set
    End Property
End Class

