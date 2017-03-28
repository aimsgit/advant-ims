Imports Microsoft.VisualBasic

Public Class mfg_PurchaseOrderEL
    Public _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Public _CurrencyID As Integer
    Public Property CurrencyID() As Integer
        Get
            Return _CurrencyID
        End Get
        Set(ByVal value As Integer)
            _CurrencyID = value
        End Set
    End Property
    Public _ExchangeRate As Double
    Public Property ExchangeRate() As Double
        Get
            Return _ExchangeRate
        End Get
        Set(ByVal value As Double)
            _ExchangeRate = value
        End Set
    End Property
    Public _ProductID As Integer
    Public Property ProductID() As Integer
        Get
            Return _ProductID
        End Get
        Set(ByVal value As Integer)
            _ProductID = value
        End Set
    End Property
    Public _UnitID As Integer
    Public Property UnitID() As Integer
        Get
            Return _UnitID
        End Get
        Set(ByVal value As Integer)
            _UnitID = value
        End Set
    End Property
    Public _Quantity As Double
    Public Property Quantity() As Double
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Double)
            _Quantity = value
        End Set
    End Property
    Public _UnitRate As Double
    Public Property UnitRate() As Double
        Get
            Return _UnitRate
        End Get
        Set(ByVal value As Double)
            _UnitRate = value
        End Set
    End Property
    Public _EstimatedPrice As Double
    Public Property EstimatedPrice() As Double
        Get
            Return _EstimatedPrice
        End Get
        Set(ByVal value As Double)
            _EstimatedPrice = value
        End Set
    End Property
    Public _EstimatedValue As Double
    Public Property EstimatedValue() As Double
        Get
            Return _EstimatedValue
        End Get
        Set(ByVal value As Double)
            _EstimatedValue = value
        End Set
    End Property
    Public _SupplierId As Integer
    Public Property SupplierId() As Integer
        Get
            Return _SupplierId
        End Get
        Set(ByVal value As Integer)
            _SupplierId = value
        End Set
    End Property
    Public _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Public _PONo As String
    Public Property PONo() As String
        Get
            Return _PONo
        End Get
        Set(ByVal value As String)
            _PONo = value
        End Set
    End Property
    Public _PODate As DateTime
    Public Property PODate() As DateTime
        Get
            Return _PODate
        End Get
        Set(ByVal value As DateTime)
            _PODate = value
        End Set
    End Property
    Public _POValidityDate As DateTime
    Public Property POValidityDate() As DateTime
        Get
            Return _POValidityDate
        End Get
        Set(ByVal value As DateTime)
            _POValidityDate = value
        End Set
    End Property
    Public _PaymentMethodId As Integer
    Public Property PaymentMethodId() As Integer
        Get
            Return _PaymentMethodId
        End Get
        Set(ByVal value As Integer)
            _PaymentMethodId = value
        End Set
    End Property
    Public _DivideOrder As Integer
    Public Property DivideOrder() As Integer
        Get
            Return _DivideOrder
        End Get
        Set(ByVal value As Integer)
            _DivideOrder = value
        End Set
    End Property
    Public _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Public _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public _ProductType As Integer
    Public Property ProductType() As Integer
        Get
            Return _ProductType
        End Get
        Set(ByVal value As Integer)
            _ProductType = value
        End Set
    End Property
    Public _TransportationMode As Integer
    Public Property TransportationMode() As Integer
        Get
            Return _TransportationMode
        End Get
        Set(ByVal value As Integer)
            _TransportationMode = value
        End Set
    End Property
    Public _ShipmentAddress As String
    Public Property ShipmentAddress() As String
        Get
            Return _ShipmentAddress
        End Get
        Set(ByVal value As String)
            _ShipmentAddress = value
        End Set
    End Property
    Public _PurchaseRequisition As String
    Public Property PurchaseRequisition() As String
        Get
            Return _PurchaseRequisition
        End Get
        Set(ByVal value As String)
            _PurchaseRequisition = value
        End Set
    End Property
End Class
