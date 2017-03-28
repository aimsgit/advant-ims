Imports Microsoft.VisualBasic

Public Class Supplier
    Private _supp_ID As Integer
    Public Property Supp_ID() As Integer
        Get
            Return _supp_ID
        End Get
        Set(ByVal value As Integer)
            _supp_ID = value
        End Set
    End Property
    Private _supp_Name As String
    Public Property Supp_Name() As String
        Get
            Return _supp_Name
        End Get
        Set(ByVal value As String)
            _supp_Name = value
        End Set
    End Property
    Private _supp_Code As String
    Public Property Supp_Code() As String
        Get
            Return _supp_Code
        End Get
        Set(ByVal value As String)
            _supp_Code = value
        End Set
    End Property
    Private _supp_Address As String
    Public Property Supp_Address() As String
        Get
            Return _supp_Address
        End Get
        Set(ByVal value As String)
            _supp_Address = value
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
    Private _PostalCode As String
    Public Property PostalCode() As String
        Get
            Return _PostalCode
        End Get
        Set(ByVal value As String)
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
    Private _Buyer As String
    Public Property Buyer() As String
        Get
            Return _Buyer
        End Get
        Set(ByVal value As String)
            _Buyer = value
        End Set
    End Property
    'Public Sub New(ByVal supp_Name As String, ByVal supp_Code As String, ByVal supp_Address As String, ByVal contact_Person As String, ByVal contact_Number1 As String, ByVal credit_Period As Integer, ByVal credit_Limit As String, ByVal opening_Balance_CR As String, ByVal opening_Balance_DR As String, ByVal ob_date As Date, ByVal supp_ID As Integer)
    '    _supp_Name = supp_Name
    '    _supp_Code = supp_Code
    '    _supp_Address = supp_Address
    '    _contact_Person = contact_Person
    '    _contact_Number1 = contact_Number1
    '    _credit_Period = credit_Period
    '    _credit_Limit = credit_Limit
    '    _opening_Balance_CR = opening_Balance_CR
    '    _opening_Balance_DR = opening_Balance_DR
    '    _ob_date = ob_date
    '    _supp_ID = supp_ID
    'End Sub
    'Public Sub New()

    'End Sub
End Class
