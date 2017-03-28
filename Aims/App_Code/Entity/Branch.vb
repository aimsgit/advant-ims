Imports Microsoft.VisualBasic

Public Class Branch
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
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
    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    Private _ssbcode As String
    Public Property SSBCode() As String
        Get
            Return _ssbcode
        End Get
        Set(ByVal value As String)
            _ssbcode = value
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
    Private _ContactNo As String
    Public Property ContactNo() As String
        Get
            Return _ContactNo
        End Get
        Set(ByVal value As String)
            _ContactNo = value
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
    Private _hocode As String
    Public Property HOCode() As String
        Get
            Return _hocode
        End Get
        Set(ByVal value As String)
            _hocode = value
        End Set
    End Property
    Private _Logo As String
    Public Property Logo() As String
        Get
            Return _Logo
        End Get
        Set(ByVal value As String)
            _Logo = value
        End Set
    End Property
    Private _PFAcct As String
    Public Property PFAcct() As String
        Get
            Return _PFAcct
        End Get
        Set(ByVal value As String)
            _PFAcct = value
        End Set
    End Property
    Private _EmailID As String
    Public Property EmailID() As String
        Get
            Return _EmailID
        End Get
        Set(ByVal value As String)
            _EmailID = value
        End Set
    End Property
    Private _Website As String
    Public Property Website() As String
        Get
            Return _Website
        End Get
        Set(ByVal value As String)
            _Website = value
        End Set
    End Property
    Private _brntype As String
    Public Property BrnType() As String
        Get
            Return _brntype
        End Get
        Set(ByVal value As String)
            _brntype = value
        End Set
    End Property
    Private _rptbrn As String
    Public Property RptBrn() As String
        Get
            Return _rptbrn
        End Get
        Set(ByVal value As String)
            _rptbrn = value
        End Set
    End Property
    Private _contactperson As String
    Public Property ContactPerson() As String
        Get
            Return _contactperson
        End Get
        Set(ByVal value As String)
            _contactperson = value
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
    Private _accountno As String
    Public Property AccountNo() As String
        Get
            Return _accountno
        End Get
        Set(ByVal value As String)
            _accountno = value
        End Set
    End Property
    Private _bankcode As String
    Public Property BankCode() As String
        Get
            Return _bankcode
        End Get
        Set(ByVal value As String)
            _bankcode = value
        End Set
    End Property
    Private _bankbranch As String
    Public Property BankBranch() As String
        Get
            Return _bankbranch
        End Get
        Set(ByVal value As String)
            _bankbranch = value
        End Set
    End Property
    Private _BreakTime As Integer
    Public Property BreakTime() As Integer
        Get
            Return _BreakTime
        End Get
        Set(ByVal value As Integer)
            _BreakTime = value
        End Set
    End Property

    Private _FromEmailID As String
    Public Property FromEmailID() As String
        Get
            Return _FromEmailID
        End Get
        Set(ByVal value As String)
            _FromEmailID = value
        End Set
    End Property

    Private _FromPassword As String
    Public Property FromPassword() As String
        Get
            Return _FromPassword
        End Get
        Set(ByVal value As String)
            _FromPassword = value
        End Set
    End Property

    Private _SMTPHost As String
    Public Property SMTPHost() As String
        Get
            Return _SMTPHost
        End Get
        Set(ByVal value As String)
            _SMTPHost = value
        End Set
    End Property

    Private _Accredited As String
    Public Property Accredited() As String
        Get
            Return _Accredited
        End Get
        Set(ByVal value As String)
            _Accredited = value
        End Set
    End Property
    Private _BankId As String
    Public Property BankId() As String
        Get
            Return _BankId
        End Get
        Set(ByVal value As String)
            _BankId = value
        End Set
    End Property

    Private _ApprovedBy As String
    Public Property ApprovedBy() As String
        Get
            Return _ApprovedBy
        End Get
        Set(ByVal value As String)
            _ApprovedBy = value
        End Set
    End Property

    Private _AffiliatedTo As String
    Public Property AffiliatedTo() As String
        Get
            Return _AffiliatedTo
        End Get
        Set(ByVal value As String)
            _AffiliatedTo = value
        End Set
    End Property

    Private _EmailService As String
    Public Property EmailService() As String
        Get
            Return _EmailService
        End Get
        Set(ByVal value As String)
            _EmailService = value
        End Set
    End Property

    Private _SMSService As String
    Public Property SMSService() As String
        Get
            Return _SMSService
        End Get
        Set(ByVal value As String)
            _SMSService = value
        End Set
    End Property

    Private _BranchRegistationNo As String
    Public Property BranchRegistationNo() As String
        Get
            Return _BranchRegistationNo
        End Get
        Set(ByVal value As String)
            _BranchRegistationNo = value
        End Set
    End Property
                    
    Public Sub New()
    End Sub
    Private _deleteflag As String

    Public Property DeleteFlag() As String
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As String)
            _deleteflag = value
        End Set
    End Property
    Private _TagLine As String
    Public Property TagLine() As String
        Get
            Return _TagLine
        End Get
        Set(ByVal value As String)
            _TagLine = value
        End Set
    End Property
    Private _IncludeInsName As String
    Public Property IncludeInsName() As String
        Get
            Return _IncludeInsName
        End Get
        Set(ByVal value As String)
            _IncludeInsName = value
        End Set
    End Property
    Private _ChkTeacherSubject As String
    Public Property ChkTeacherSubject() As String
        Get
            Return _ChkTeacherSubject
        End Get
        Set(ByVal value As String)
            _ChkTeacherSubject = value
        End Set
    End Property
    Private _SPassword As String
    Public Property SPassword() As String
        Get
            Return _SPassword
        End Get
        Set(ByVal value As String)
            _SPassword = value
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

    Private _Biometric As String
    Public Property Biometric() As String
        Get
            Return _Biometric
        End Get
        Set(ByVal value As String)
            _Biometric = value
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
    Private _BranchImg As String
    Public Property BranchImg() As String
        Get
            Return _BranchImg
        End Get
        Set(ByVal value As String)
            _BranchImg = value
        End Set
    End Property
End Class
