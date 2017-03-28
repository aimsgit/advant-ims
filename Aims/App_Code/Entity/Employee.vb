Imports Microsoft.VisualBasic

Public Class Employee
    Private _emp_Id As Integer
    Public Property Emp_Id() As Integer
        Get
            Return _emp_Id
        End Get
        Set(ByVal value As Integer)
            _emp_Id = value
        End Set
    End Property
    Private _AttendanceID As Int64
    Public Property AttendanceID() As Int64
        Get
            Return _AttendanceID
        End Get
        Set(ByVal value As Int64)
            _AttendanceID = CInt(value)
        End Set
    End Property
    Private _emp_Name As String
    Public Property Emp_Name() As String
        Get
            Return _emp_Name
        End Get
        Set(ByVal value As String)
            _emp_Name = value
        End Set
    End Property
    Private _emp_Code As String
    Public Property Emp_Code() As String
        Get
            Return _emp_Code
        End Get
        Set(ByVal value As String)
            _emp_Code = value
        End Set
    End Property
    Private _emp_category As Long
    Public Property Emp_Category() As Long
        Get
            Return _emp_category
        End Get
        Set(ByVal value As Long)
            _emp_category = value
        End Set
    End Property
    Private _employment_type As Long
    Public Property Employment_Type() As Long
        Get
            Return _employment_type
        End Get
        Set(ByVal value As Long)
            _employment_type = value
        End Set
    End Property
    Private _dob As Date
    Public Property DOB() As Date
        Get
            Return _dob
        End Get
        Set(ByVal value As Date)
            _dob = value
        End Set
    End Property
    Private _doj As Date
    Public Property DOJ() As Date
        Get
            Return _doj
        End Get
        Set(ByVal value As Date)
            _doj = value
        End Set
    End Property
    Private _dol As Date
    Public Property DOL() As Date
        Get
            Return _dol
        End Get
        Set(ByVal value As Date)
            _dol = value
        End Set
    End Property
    Private _designation As String
    Public Property Designation() As String
        Get
            Return _designation
        End Get
        Set(ByVal value As String)
            _designation = value
        End Set
    End Property
    Private _branch_ID As Integer
    Public Property Branch_ID() As Integer
        Get
            Return _branch_ID
        End Get
        Set(ByVal value As Integer)
            _branch_ID = value
        End Set
    End Property
    Private _institute_ID As Integer
    Public Property Institute_ID() As Integer
        Get
            Return _institute_ID
        End Get
        Set(ByVal value As Integer)
            _institute_ID = value
        End Set
    End Property
    Private _dept_ID As Integer
    Public Property Dept_ID() As Integer
        Get
            Return _dept_ID
        End Get
        Set(ByVal value As Integer)
            _dept_ID = value
        End Set
    End Property

    Private _salary As Integer
    Public Property Salary() As Integer
        Get
            Return _salary
        End Get
        Set(ByVal value As Integer)
            _salary = value
        End Set
    End Property
    Private _accountNo As String
    Public Property AccountNo() As String
        Get
            Return _accountNo
        End Get
        Set(ByVal value As String)
            _accountNo = value
        End Set
    End Property
    Private _bank_ID As Integer
    Public Property Bank_ID() As Integer
        Get
            Return _bank_ID
        End Get
        Set(ByVal value As Integer)
            _bank_ID = value
        End Set
    End Property
    Private _emp_address As String
    Public Property Emp_Address() As String
        Get
            Return _emp_address
        End Get
        Set(ByVal value As String)
            _emp_address = value
        End Set
    End Property
    Private _emp_City As String
    Public Property Emp_City() As String
        Get
            Return _emp_City
        End Get
        Set(ByVal value As String)
            _emp_City = value
        End Set
    End Property
    Private _zip As String
    Public Property Zip() As String
        Get
            Return _zip
        End Get
        Set(ByVal value As String)
            _zip = value
        End Set
    End Property
    Private _state As Int32
    Public Property State() As Int32
        Get
            Return _state
        End Get
        Set(ByVal value As Int32)
            _state = value
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
    Private _contact_No1 As String
    Public Property Contact_No1() As String
        Get
            Return _contact_No1
        End Get
        Set(ByVal value As String)
            _contact_No1 = value
        End Set
    End Property
    Private _contact_No2 As String
    Public Property Contact_No2() As String 'AppointedBy Field
        Get
            Return _contact_No2
        End Get
        Set(ByVal value As String)
            _contact_No2 = value
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
    Private _opening_Balance_CR As Integer
    Public Property Opening_Balance_CR() As Integer
        Get
            Return _opening_Balance_CR
        End Get
        Set(ByVal value As Integer)
            _opening_Balance_CR = value
        End Set
    End Property
    Private _opening_Balance_DR As Integer
    Public Property Opening_Balance_DR() As Integer
        Get
            Return _opening_Balance_DR
        End Get
        Set(ByVal value As Integer)
            _opening_Balance_DR = value
        End Set
    End Property
    Private _opBalanceDate As Date
    Public Property OpBalanceDate() As Date
        Get
            Return _opBalanceDate
        End Get
        Set(ByVal value As Date)
            _opBalanceDate = value
        End Set
    End Property
    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Private _photos As String
    Public Property Photos() As String
        Get
            Return _photos
        End Get
        Set(ByVal value As String)
            _photos = value
        End Set
    End Property
    Private _ITcategory As String
    Public Property ITCategory() As String
        Get
            Return _ITcategory
        End Get
        Set(ByVal value As String)
            _ITcategory = value
        End Set
    End Property
    Private _district As String
    Public Property District() As String
        Get
            Return _district
        End Get
        Set(ByVal value As String)
            _district = value
        End Set
    End Property
    Private _uniquecode As String
    Public Property UniqueCode() As String
        Get
            Return _uniquecode
        End Get
        Set(ByVal value As String)
            _uniquecode = value
        End Set
    End Property
    Private _transferto As Integer
    Public Property TransferTo() As Integer
        Get
            Return _transferto
        End Get
        Set(ByVal value As Integer)
            _transferto = value
        End Set
    End Property
    Private _StartDate As Date
    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property
    Private _EndDate As Date
    Public Property EndDate() As DateTime
        Get
            Return _EndDate
        End Get
        Set(ByVal value As DateTime)
            _EndDate = value
        End Set
    End Property
    Private _Empid As String
    Public Property Empid() As String
        Get
            Return _Empid
        End Get
        Set(ByVal value As String)
            _Empid = value
        End Set
    End Property
    'Private _categoryname As String
    'Public Property CategoryName() As String
    '    Get
    '        Return _categoryname
    '    End Get
    '    Set(ByVal value As String)
    '        _categoryname = value
    '    End Set
    'End Property
    'Private _branchName As String
    'Public Property BranchName() As String
    '    Get
    '        Return _branchName
    '    End Get
    '    Set(ByVal value As String)
    '        _branchName = value
    '    End Set
    'End Property
    'Private _instituteName As String
    'Public Property InstituteName() As String
    '    Get
    '        Return _instituteName
    '    End Get
    '    Set(ByVal value As String)
    '        _instituteName = value
    '    End Set
    'End Property
    'Private _bankName As String
    'Public Property BankName() As String
    '    Get
    '        Return _bankName
    '    End Get
    '    Set(ByVal value As String)
    '        _bankName = value
    '    End Set
    'End Property
    Public Sub New(ByVal emp_Name As String, ByVal emp_Code As String, ByVal emp_Category As Long, ByVal employment_Type As Long, ByVal dob As Date, ByVal doj As Date, ByVal dol As Date, ByVal designation As String, ByVal branch_ID As Integer, ByVal institute_ID As Integer, ByVal dept_ID As Integer, ByVal salary As Integer, ByVal accountNo As String, ByVal bank_ID As Integer, ByVal emp_address As String, ByVal emp_City As String, ByVal zip As String, ByVal state As Int32, ByVal country As String, ByVal contact_No1 As String, ByVal contact_No2 As String, ByVal email As String, ByVal emp_ID As Integer, ByVal photos As String, ByVal ITcategory As String, ByVal district As String, ByVal uniquecode As String, ByVal transferto As Integer)
        _emp_Name = emp_Name
        _emp_Code = emp_Code
        _emp_category = emp_Category
        _employment_type = employment_Type
        _dob = dob
        _doj = doj
        _dol = dol
        _designation = designation
        _branch_ID = branch_ID
        _institute_ID = institute_ID
        _dept_ID = dept_ID
        _salary = salary
        _accountNo = accountNo
        _bank_ID = bank_ID
        _emp_address = emp_address
        _emp_City = emp_City
        _zip = zip
        _state = state
        _country = country
        _contact_No1 = contact_No1
        _contact_No2 = contact_No2 'AppointedBy Field
        _email = email
        '_opening_Balance_CR = opening_Balance_CR
        '_opening_Balance_DR = opening_Balance_DR
        '_opBalanceDate = opBalanceDate
        '_remarks = remarks
        _emp_Id = emp_ID
        _photos = photos
        _ITcategory = ITcategory
        _district = district
        _uniquecode = uniquecode
        _transferto = transferto
    End Sub
    Public Sub New()
    End Sub
End Class
