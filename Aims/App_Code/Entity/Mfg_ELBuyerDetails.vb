Imports Microsoft.VisualBasic

Public Class Mfg_ELBuyerDetails
    Private _Buyer_ID As Integer
    Public Property Buyer_ID() As Integer
        Get
            Return _Buyer_ID
        End Get
        Set(ByVal value As Integer)
            _Buyer_ID = value
        End Set
    End Property
    Private _Buyer_Name As String
    Public Property Buyer_Name() As String
        Get
            Return _Buyer_Name
        End Get
        Set(ByVal value As String)
            _Buyer_Name = value
        End Set
    End Property
    Private _Suplier As String
    Public Property Suplier() As String
        Get
            Return _Suplier
        End Get
        Set(ByVal value As String)
            _Suplier = value
        End Set
    End Property
    Private _SE As String
    Public Property SE() As String
        Get
            Return _SE
        End Get
        Set(ByVal value As String)
            _SE = value
        End Set
    End Property
    Private _Discountlock As String
    Public Property Discountlock() As String
        Get
            Return _Discountlock
        End Get
        Set(ByVal value As String)
            _Discountlock = value
        End Set
    End Property
    Private _Area As String
    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property
    Private _Buyer_Code As String
    Public Property Buyer_Code() As String
        Get
            Return _Buyer_Code
        End Get
        Set(ByVal value As String)
            _Buyer_Code = value
        End Set
    End Property
    Private _Buyer_Address As String
    Public Property Buyer_Address() As String
        Get
            Return _Buyer_Address
        End Get
        Set(ByVal value As String)
            _Buyer_Address = value
        End Set
    End Property
    Private _contact_Person As String
    Public Property Contact_Person() As String
        Get
            Return _contact_Person
        End Get
        Set(ByVal value As String)
            _contact_Person = value
        End Set
    End Property
    Private _contact_Number1 As String
    Public Property Contact_Number1() As String
        Get
            Return _contact_Number1
        End Get
        Set(ByVal value As String)
            _contact_Number1 = value
        End Set
    End Property
    Private _credit_Period As String
    Public Property Credit_Period() As String
        Get
            Return _credit_Period
        End Get
        Set(ByVal value As String)
            _credit_Period = value
        End Set
    End Property
    Private _credit_Limit As String
    Public Property Credit_Limit() As String
        Get
            Return _credit_Limit
        End Get
        Set(ByVal value As String)
            _credit_Limit = value
        End Set
    End Property
    Private _credit_Bills As String
    Public Property credit_Bills() As String
        Get
            Return _credit_Bills
        End Get
        Set(ByVal value As String)
            _credit_Bills = value
        End Set
    End Property

    Private _opening_Balance_CR As String
    Public Property Opening_Balance_CR() As String
        Get
            Return _opening_Balance_CR
        End Get
        Set(ByVal value As String)
            _opening_Balance_CR = value
        End Set
    End Property
    Private _opening_Balance_DR As String
    Public Property Opening_Balance_DR() As String
        Get
            Return _opening_Balance_DR
        End Get
        Set(ByVal value As String)
            _opening_Balance_DR = value
        End Set
    End Property
    Private _ob_date As DateTime
    Public Property OpBalanceDate() As DateTime
        Get
            Return _ob_date
        End Get
        Set(ByVal value As DateTime)
            _ob_date = value
        End Set
    End Property
    Private _Registered As String
    Public Property Registered() As String
        Get
            Return _Registered
        End Get
        Set(ByVal value As String)
            _Registered = value
        End Set
    End Property
    Private _dlock As String
    Public Property dlock() As String
        Get
            Return _dlock
        End Get
        Set(ByVal value As String)
            _dlock = value
        End Set
    End Property
    Private _CSTNo As String
    Public Property CSTNo() As String
        Get
            Return _CSTNo
        End Get
        Set(ByVal value As String)
            _CSTNo = value
        End Set
    End Property
    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Private _City As String
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            _City = value
        End Set
    End Property
    Private _State As String
    Public Property State() As Integer
        Get
            Return _State
        End Get
        Set(ByVal value As Integer)
            _State = value
        End Set
    End Property
    Private _Country As String
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            _Country = value
        End Set
    End Property
    Private _DLNo As String
    Public Property DLNo() As String
        Get
            Return _DLNo
        End Get
        Set(ByVal value As String)
            _DLNo = value
        End Set
    End Property

    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Private _Tin As String
    Public Property Tin() As String
        Get
            Return _Tin
        End Get
        Set(ByVal value As String)
            _Tin = value
        End Set
    End Property
    Private _PostalCode As Integer
    Public Property PostalCode() As Integer
        Get
            Return _PostalCode
        End Get
        Set(ByVal value As Integer)
            _PostalCode = value
        End Set
    End Property
    Private _FaxNO As String
    Public Property FaxNO() As String
        Get
            Return _FaxNO
        End Get
        Set(ByVal value As String)
            _FaxNO = value
        End Set
    End Property
    Private _Contactno2 As String
    Public Property Contactno2() As String
        Get
            Return _Contactno2
        End Get
        Set(ByVal value As String)
            _Contactno2 = value
        End Set
    End Property
    Private _CreditLimit As Double
    Public Property CreditLimit() As Double
        Get
            Return _CreditLimit
        End Get
        Set(ByVal value As Double)
            _CreditLimit = value
        End Set
    End Property
    Private _Discount As Double
    Public Property Discount() As Double
        Get
            Return _Discount
        End Get
        Set(ByVal value As Double)
            _Discount = value
        End Set
    End Property
    Private _Creditperiod As Integer
    Public Property Creditperiod() As Integer
        Get
            Return _Creditperiod
        End Get
        Set(ByVal value As Integer)
            _Creditperiod = value
        End Set
    End Property
    Private _str As Double
    Public Property str() As Double
        Get
            Return _str
        End Get
        Set(ByVal value As Double)
            _str = value
        End Set
    End Property
    Private _stp As Double
    Public Property stp() As Double
        Get
            Return _stp
        End Get
        Set(ByVal value As Double)
            _stp = value
        End Set
    End Property
    Private _OPdate As Date
    Public Property OPdate() As Date
        Get
            Return _OPdate
        End Get
        Set(ByVal value As Date)
            _OPdate = value
        End Set
    End Property
End Class
