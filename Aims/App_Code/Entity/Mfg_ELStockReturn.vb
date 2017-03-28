Imports Microsoft.VisualBasic

Public Class Mfg_ELStockReturn
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _PID As Integer
    Public Property PID() As Integer
        Get
            Return _PID
        End Get
        Set(ByVal value As Integer)
            _PID = value
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
    Private _Party As Integer
    Public Property Party() As Integer
        Get
            Return _Party
        End Get
        Set(ByVal value As Integer)
            _Party = value
        End Set
    End Property
    Private _ReturnId As Integer
    Public Property ReturnId() As Integer
        Get
            Return _ReturnId
        End Get
        Set(ByVal value As Integer)
            _ReturnId = value
        End Set
    End Property
    Private _ChallanNo As String
    Public Property ChallanNo() As String
        Get
            Return _ChallanNo
        End Get
        Set(ByVal value As String)
            _ChallanNo = value
        End Set
    End Property
    Private _ReturnNo As String
    Public Property ReturnNo() As String
        Get
            Return _ReturnNo
        End Get
        Set(ByVal value As String)
            _ReturnNo = value
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
    Private _ReturnDate As DateTime
    Public Property ReturnDate() As DateTime
        Get
            Return _ReturnDate
        End Get
        Set(ByVal value As DateTime)
            _ReturnDate = value
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
    Private _WorkOrder As Integer
    Public Property WorkOrder() As Integer
        Get
            Return _WorkOrder
        End Get
        Set(ByVal value As Integer)
            _WorkOrder = value
        End Set
    End Property
    Private _ItemDesc As Integer
    Public Property ItemDesc() As Integer
        Get
            Return _ItemDesc
        End Get
        Set(ByVal value As Integer)
            _ItemDesc = value
        End Set
    End Property
    Private _ReturnedQty As Double
    Public Property ReturnedQty() As Double
        Get
            Return _ReturnedQty
        End Get
        Set(ByVal value As Double)
            _ReturnedQty = value
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
    Private _Qty As Integer
    Public Property Qty() As Integer
        Get
            Return _Qty
        End Get
        Set(ByVal value As Integer)
            _Qty = value
        End Set
    End Property
    Private _HidPurchaseReturnId As Integer
    Public Property HidPurchaseReturnId() As Integer
        Get
            Return _HidPurchaseReturnId
        End Get
        Set(ByVal value As Integer)
            _HidPurchaseReturnId = value
        End Set
    End Property
    Private _IssueId As Integer
    Public Property IssueId() As Integer
        Get
            Return _IssueId
        End Get
        Set(ByVal value As Integer)
            _IssueId = value
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
End Class
