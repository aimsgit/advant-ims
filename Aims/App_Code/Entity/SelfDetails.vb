Imports Microsoft.VisualBasic

Public Class SelfDetails
    Private _coid As Long
    Public Property CoId() As Long
        Get
            Return _coid
        End Get
        Set(ByVal value As Long)
            _coid = value
        End Set
    End Property
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _address As String
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property
    Private _registration As String
    Public Property Registration() As String
        Get
            Return _registration
        End Get
        Set(ByVal value As String)
            _registration = value
        End Set
    End Property
    Private _city As String
    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property
    Private _state As String
    Public Property State() As String
        Get
            Return _state
        End Get
        Set(ByVal value As String)
            _state = value
        End Set
    End Property
    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    Private _country As String
    Public Property Country() As String
        Get
            Return _country
        End Get
        Set(ByVal value As String)
            _country = value
        End Set
    End Property
    Private _contactperson As String
    Public Property Contactperson() As String
        Get
            Return _contactperson
        End Get
        Set(ByVal value As String)
            _contactperson = value
        End Set
    End Property
    Private _contactno1 As String
    Public Property Contactno1() As String
        Get
            Return _contactno1
        End Get
        Set(ByVal value As String)
            _contactno1 = value
        End Set
    End Property
    Private _contactno2 As String
    Public Property Contactno2() As String
        Get
            Return _contactno2
        End Get
        Set(ByVal value As String)
            _contactno2 = value
        End Set
    End Property
    Private _fax As String
    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal value As String)
            _fax = value
        End Set
    End Property
    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Private _website As String
    Public Property Website() As String
        Get
            Return _website
        End Get
        Set(ByVal value As String)
            _website = value
        End Set
    End Property
    Private _bid As Long
    Public Property BranchId() As Long
        Get
            Return _bid
        End Get
        Set(ByVal value As Long)
            _bid = value
        End Set
    End Property
    Private _logo As String
    Public Property Logo() As String
        Get
            Return _logo
        End Get
        Set(ByVal value As String)
            _logo = value
        End Set
    End Property
    Private _logoDefault As String
    Public Property logoDefault() As String
        Get
            Return _logoDefault
        End Get
        Set(ByVal value As String)
            _logoDefault = value
        End Set
    End Property
    Private _logoHeader As String
    Public Property logoHeader() As String
        Get
            Return _logoHeader
        End Get
        Set(ByVal value As String)
            _logoHeader = value
        End Set
    End Property
    Private _Prefix As String
    Public Property Prefix() As String
        Get
            Return _Prefix
        End Get
        Set(ByVal value As String)
            _Prefix = value
        End Set
    End Property
    Private _HeaderColor As String
    Public Property HeaderColor() As String
        Get
            Return _HeaderColor
        End Get
        Set(ByVal value As String)
            _HeaderColor = value
        End Set
    End Property
    Private _AdminName As String
    Public Property AdminName() As String
        Get
            Return _AdminName
        End Get
        Set(ByVal value As String)
            _AdminName = value
        End Set
    End Property
    Private _AdminPassword As String
    Public Property AdminPassword() As String
        Get
            Return _AdminPassword
        End Get
        Set(ByVal value As String)
            _AdminPassword = value
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
    Private _PasswordExpiryDate As DateTime
    Public Property PasswordExpiryDate() As DateTime
        Get
            Return _PasswordExpiryDate
        End Get
        Set(ByVal value As DateTime)
            _PasswordExpiryDate = value
        End Set
    End Property
    Private _CreationDate As DateTime
    Public Property CreationDate() As DateTime
        Get
            Return _CreationDate
        End Get
        Set(ByVal value As DateTime)
            _CreationDate = value
        End Set
    End Property
    Private _SDID As Integer
    Public Property SDID() As Integer
        Get
            Return _SDID
        End Get
        Set(ByVal value As Integer)
            _SDID = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal coid As Long, ByVal name As String, ByVal address As String, ByVal registration As String, ByVal city As String, ByVal state As String, ByVal code As String, ByVal country As String, ByVal contactperson As String, ByVal contactno1 As String, ByVal contactno2 As String, ByVal fax As String, ByVal email As String, ByVal website As String, ByVal bid As Int32, ByVal logo As String)
        _coid = coid
        _name = name
        _address = address
        _registration = registration
        _city = city
        _state = state
        _code = code
        _country = country
        _contactperson = contactperson
        _contactno1 = contactno1
        _contactno2 = contactno2
        _fax = fax
        _email = email
        _website = website
        _bid = bid
        _logo = logo
    End Sub
    Public Sub New(ByVal coid As Long, ByVal name As String, ByVal address As String, ByVal registration As String, ByVal city As String, ByVal state As String, ByVal code As String, ByVal country As String, ByVal contactperson As String, ByVal contactno1 As String, ByVal contactno2 As String, ByVal fax As String, ByVal email As String, ByVal website As String)
        _coid = coid
        _name = name
        _address = address
        _registration = registration
        _city = city
        _state = state
        _code = code
        _country = country
        _contactperson = contactperson
        _contactno1 = contactno1
        _contactno2 = contactno2
        _fax = fax
        _email = email
        _website = website

    End Sub
    'Private _deleteflag As String
    'Public Property DeleteFlag() As String
    '    Get
    '        Return _deleteflag
    '    End Get
    '    Set(ByVal value As String)
    '        _deleteflag = value
    '    End Set
    'End Property
    Private _hoflag As Int16
    Public Property HoFlag() As Int16
        Get
            Return _hoflag
        End Get
        Set(ByVal value As Int16)
            _hoflag = value
        End Set
    End Property
End Class
