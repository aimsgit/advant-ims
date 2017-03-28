Imports Microsoft.VisualBasic

Public Class Mfg_ELSupplierDetails
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Private _code As String
    Public Property code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
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
    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
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
    Private _Tin As Double
    Public Property Tin() As Double
        Get
            Return _Tin
        End Get
        Set(ByVal value As Double)
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
    Private _FaxNO As Double
    Public Property FaxNO() As Double
        Get
            Return _FaxNO
        End Get
        Set(ByVal value As Double)
            _FaxNO = value
        End Set
    End Property
    Private _Contactno1 As Integer
    Public Property Contactno1() As Integer
        Get
            Return _Contactno1
        End Get
        Set(ByVal value As Integer)
            _Contactno1 = value
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
End Class
