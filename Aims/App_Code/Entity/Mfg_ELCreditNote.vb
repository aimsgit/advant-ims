Imports Microsoft.VisualBasic

Public Class Mfg_ELCreditNote
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Invoiveid As Integer
    Public Property Invoiveid() As Integer
        Get
            Return _Invoiveid
        End Get
        Set(ByVal value As Integer)
            _Invoiveid = value
        End Set
    End Property
    Private _InvoiveType As String
    Public Property InvoiveType() As String
        Get
            Return _InvoiveType
        End Get
        Set(ByVal value As String)
            _InvoiveType = value
        End Set
    End Property
    Private _Debit As String
    Public Property Debit() As String
        Get
            Return _Debit
        End Get
        Set(ByVal value As String)
            _Debit = value
        End Set
    End Property
    Private _Currency As Integer
    Public Property Currency() As Integer
        Get
            Return _Currency
        End Get
        Set(ByVal value As Integer)
            _Currency = value
        End Set
    End Property
    Private _ExchangeRate As Double
    Public Property ExchangeRate() As Double
        Get
            Return _ExchangeRate
        End Get
        Set(ByVal value As Double)
            _ExchangeRate = value
        End Set
    End Property
    Private _Amount As Double
    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
        End Set
    End Property
    Private _Supplier_Buyer As Integer
    Public Property Supplier_Buyer() As Integer
        Get
            Return _Supplier_Buyer
        End Get
        Set(ByVal value As Integer)
            _Supplier_Buyer = value
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
End Class
