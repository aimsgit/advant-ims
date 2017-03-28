Imports Microsoft.VisualBasic

Public Class ELPurchaseRequisition
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Reqdate As DateTime
    Public Property Reqdate() As DateTime
        Get
            Return _Reqdate
        End Get
        Set(ByVal value As DateTime)
            _Reqdate = value
        End Set
    End Property
    Private _PurchaseReq_No As String
    Public Property PurchaseReq_No() As String
        Get
            Return _PurchaseReq_No
        End Get
        Set(ByVal value As String)
            _PurchaseReq_No = value
        End Set
    End Property
    Private _Product_Id As Integer
    Public Property Product_Id() As Integer
        Get
            Return _Product_Id
        End Get
        Set(ByVal value As Integer)
            _Product_Id = value
        End Set
    End Property
    Private _Unit_Id As Integer
    Public Property Unit_Id() As Integer
        Get
            Return _Unit_Id
        End Get
        Set(ByVal value As Integer)
            _Unit_Id = value
        End Set
    End Property
    Private _Quantity As Integer
    Public Property Quantity() As Integer
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Integer)
            _Quantity = value
        End Set
    End Property
    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
End Class
