Imports Microsoft.VisualBasic

Public Class ELSaleorderMfg
    Private _Sales_Order_ID As Integer
    Public Property Sales_Order_ID() As Integer
        Get
            Return _Sales_Order_ID
        End Get
        Set(ByVal value As Integer)
            _Sales_Order_ID = value
        End Set
    End Property
    Private _RBProduct As Integer
    Public Property RBProduct() As Integer
        Get
            Return _RBProduct
        End Get
        Set(ByVal value As Integer)
            _RBProduct = value
        End Set
    End Property
    Private _SaleMain_ID As Integer
    Public Property SaleMain_ID() As Integer
        Get
            Return _SaleMain_ID
        End Get
        Set(ByVal value As Integer)
            _SaleMain_ID = value
        End Set
    End Property
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _Party_ID As Integer
    Public Property Party_ID() As Integer
        Get
            Return _Party_ID
        End Get
        Set(ByVal value As Integer)
            _Party_ID = value
        End Set
    End Property

    Private _Sale_Order_Number As String
    Public Property Sale_Order_Number() As String
        Get
            Return _Sale_Order_Number
        End Get
        Set(ByVal value As String)
            _Sale_Order_Number = value
        End Set
    End Property
    Private _PartyAutoNo As Integer
    Public Property PartyAutoNo() As Integer
        Get
            Return _PartyAutoNo
        End Get
        Set(ByVal value As Integer)
            _PartyAutoNo = value
        End Set
    End Property
    Private _BuyerAddress As String
    Public Property BuyerAddress() As String
        Get
            Return _BuyerAddress
        End Get
        Set(ByVal value As String)
            _BuyerAddress = value
        End Set
    End Property

    Private _Product_ID As String
    Public Property Product_ID() As String
        Get
            Return _Product_ID
        End Get
        Set(ByVal value As String)
            _Product_ID = value
        End Set
    End Property

    Private _Sale_Order_Date As DateTime
    Public Property Sale_Order_Date() As DateTime
        Get
            Return _Sale_Order_Date
        End Get
        Set(ByVal value As DateTime)
            _Sale_Order_Date = value
        End Set
    End Property
    Private _Valid_Upto As DateTime
    Public Property Valid_Upto() As DateTime
        Get
            Return _Valid_Upto
        End Get
        Set(ByVal value As DateTime)
            _Valid_Upto = value
        End Set
    End Property
    Private _Quantity_Ordered As Integer
    Public Property Quantity_Ordered() As Integer
        Get
            Return _Quantity_Ordered
        End Get
        Set(ByVal value As Integer)
            _Quantity_Ordered = value
        End Set
    End Property

    Private _PaymentMethod As String
    Public Property PaymentMethod() As String
        Get
            Return _PaymentMethod
        End Get
        Set(ByVal value As String)
            _PaymentMethod = value
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

    Private _InvoiceNo As String
    Public Property InvoiceNo() As String
        Get
            Return _InvoiceNo
        End Get
        Set(ByVal value As String)
            _InvoiceNo = value
        End Set
    End Property
    Private _TransportDate As DateTime
    Public Property TransportDate() As DateTime
        Get
            Return _TransportDate
        End Get
        Set(ByVal value As DateTime)
            _TransportDate = value
        End Set
    End Property
    Private _Update_Flag_SO_Details As String
    Public Property Update_Flag_SO_Details() As String
        Get
            Return _Update_Flag_SO_Details
        End Get
        Set(ByVal value As String)
            _Update_Flag_SO_Details = value
        End Set
    End Property

    Private _Flag_Update_SO_ID As String
    Public Property Flag_Update_SO_ID() As String
        Get
            Return _Flag_Update_SO_ID
        End Get
        Set(ByVal value As String)
            _Flag_Update_SO_ID = value
        End Set
    End Property

    Private _SODetailSubID As Integer
    Public Property SODetailSubID() As Integer
        Get
            Return _SODetailSubID
        End Get
        Set(ByVal value As Integer)
            _SODetailSubID = value
        End Set
    End Property
    Private _EstimatedPrice As Integer
    Public Property EstimatedPrice() As Integer
        Get
            Return _EstimatedPrice
        End Get
        Set(ByVal value As Integer)
            _EstimatedPrice = value
        End Set
    End Property
    Private _EstimatedValue As Integer
    Public Property EstimatedValue() As Integer
        Get
            Return _EstimatedValue
        End Get
        Set(ByVal value As Integer)
            _EstimatedValue = value
        End Set
    End Property
    Private _Flag_Delete_SOD As String
    Public Property Flag_Delete_SOD() As String
        Get
            Return _Flag_Delete_SOD
        End Get
        Set(ByVal value As String)
            _Flag_Delete_SOD = value
        End Set
    End Property
    Private _Calculation_Flag As String
    Public Property Calculation_Flag() As String
        Get
            Return _Calculation_Flag
        End Get
        Set(ByVal value As String)
            _Calculation_Flag = value
        End Set
    End Property
    Private _Currency_Code As Integer
    Public Property Currency_Code() As Integer
        Get
            Return _Currency_Code
        End Get
        Set(ByVal value As Integer)
            _Currency_Code = value
        End Set
    End Property
    Private _Currency_Factor As Double
    Public Property Currency_Factor() As Double
        Get
            Return _Currency_Factor
        End Get
        Set(ByVal value As Double)
            _Currency_Factor = value
        End Set
    End Property
    Private _Currency_Rate As Double
    Public Property Currency_Rate() As Double
        Get
            Return _Currency_Rate
        End Get
        Set(ByVal value As Double)
            _Currency_Rate = value
        End Set
    End Property
    Private _Issued_Qty As Integer
    Public Property Issued_Qty() As Integer
        Get
            Return _Issued_Qty
        End Get
        Set(ByVal value As Integer)
            _Issued_Qty = value
        End Set
    End Property
    Private _Sold_Qty As Integer
    Public Property Sold_Qty() As Integer
        Get
            Return _Sold_Qty
        End Get
        Set(ByVal value As Integer)
            _Sold_Qty = value
        End Set
    End Property
    Private _Ship_Address As String
    Public Property Ship_Address() As String
        Get
            Return _Ship_Address
        End Get
        Set(ByVal value As String)
            _Ship_Address = value
        End Set
    End Property
    Private _Ship_Method As String
    Public Property Ship_Method() As String
        Get
            Return _Ship_Method
        End Get
        Set(ByVal value As String)
            _Ship_Method = value
        End Set
    End Property
    Private _Ship_Date As DateTime
    Public Property Ship_Date() As DateTime
        Get
            Return _Ship_Date
        End Get
        Set(ByVal value As DateTime)
            _Ship_Date = value
        End Set
    End Property
    Private _Sale_Invoice_No As String
    Public Property Sale_Invoice_No() As String
        Get
            Return _Sale_Invoice_No
        End Get
        Set(ByVal value As String)
            _Sale_Invoice_No = value
        End Set
    End Property
    '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' ''EL
    Private _Product_ID1 As Integer
    Public Property Product_ID1() As Integer
        Get
            Return _Product_ID1
        End Get
        Set(ByVal value As Integer)
            _Product_ID1 = value
        End Set
    End Property

    Private _SO_Detail_ID As Integer
    Public Property SO_Detail_ID() As Integer
        Get
            Return _SO_Detail_ID
        End Get
        Set(ByVal value As Integer)
            _SO_Detail_ID = value
        End Set
    End Property
    Private _Sales_Order_ID1 As Integer
    Public Property Sales_Order_ID1() As Integer
        Get
            Return _Sales_Order_ID1
        End Get
        Set(ByVal value As Integer)
            _Sales_Order_ID1 = value
        End Set
    End Property

    Private _SODate As DateTime
    Public Property SODate() As DateTime
        Get
            Return _SODate
        End Get
        Set(ByVal value As DateTime)
            _SODate = value
        End Set
    End Property
    Private _Quantity_Ordered1 As Double
    Public Property Quantity_Ordered1() As Double
        Get
            Return _Quantity_Ordered1
        End Get
        Set(ByVal value As Double)
            _Quantity_Ordered1 = value
        End Set
    End Property
    Private _SODetailSubID1 As Integer
    Public Property SODetailSubID1() As Integer
        Get
            Return _SODetailSubID1
        End Get
        Set(ByVal value As Integer)
            _SODetailSubID1 = value
        End Set
    End Property
    Private _PartyAutoNo1 As Integer
    Public Property PartyAutoNo1() As Integer
        Get
            Return _PartyAutoNo1
        End Get
        Set(ByVal value As Integer)
            _PartyAutoNo1 = value
        End Set
    End Property
    Public Sub New()

    End Sub
End Class
