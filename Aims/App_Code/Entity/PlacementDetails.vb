Imports Microsoft.VisualBasic

Public Class PlacementDetails
    Private _Placement_Id As Integer
    Public Property PlacementId() As Integer
        Get
            Return _Placement_Id
        End Get
        Set(ByVal value As Integer)
            _Placement_Id = value
        End Set
    End Property
    Private _institute As Long
    Public Property Institute() As Long
        Get
            Return _institute
        End Get
        Set(ByVal value As Long)
            _institute = value
        End Set
    End Property
    Private _branch As Long
    Public Property Branch() As Long
        Get
            Return _branch
        End Get
        Set(ByVal value As Long)
            _branch = value
        End Set
    End Property
    Private _studname As Char
    Public Property studname() As String
        Get
            Return _studname
        End Get
        Set(ByVal value As String)
            _studname = value
        End Set
    End Property

    Private _batch As String
    Public Property Batch() As String
        Get
            Return _batch
        End Get
        Set(ByVal value As String)
            _batch = value
        End Set
    End Property
    Private _studCode As String
    Public Property studCode() As String
        Get
            Return _studCode
        End Get
        Set(ByVal value As String)
            _studCode = value
        End Set
    End Property
    Private _studid As Int32
    Public Property studid() As Int32
        Get
            Return _studid
        End Get
        Set(ByVal value As Int32)
            _studid = value
        End Set
    End Property
   
    Private _compname As Int32
    Public Property CompName() As Integer
        Get
            Return _compname
        End Get
        Set(ByVal value As Int32)
            _compname = value
        End Set
    End Property
    Private _date As Date
    Public Property PlacementDate() As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
        End Set
    End Property
    Private _enddate As Date
    Public Property EndDate() As Date
        Get
            Return _enddate
        End Get
        Set(ByVal value As Date)
            _enddate = value
        End Set
    End Property

    Private _salary As Double
    Public Property Salary() As Double
        Get
            Return _salary
        End Get
        Set(ByVal value As Double)
            _salary = value
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
    Private _remark As String
    Public Property Remark() As String
        Get
            Return _remark
        End Get
        Set(ByVal value As String)
            _remark = value
        End Set
    End Property
    Private _trainingplacement As String
    Public Property trainingplacement() As String
        Get
            Return _trainingplacement
        End Get
        Set(ByVal value As String)
            _trainingplacement = value
        End Set
    End Property
    Private _Faculty_Incharge As String
    Public Property Faculty_Incharge() As String
        Get
            Return _Faculty_Incharge
        End Get
        Set(ByVal value As String)
            _Faculty_Incharge = value
        End Set
    End Property
    Private _Contact_Person As String
    Public Property Contact_Person() As String
        Get
            Return _Contact_Person
        End Get
        Set(ByVal value As String)
            _Contact_Person = value
        End Set
    End Property
    Public Sub New(ByVal compname As String, ByVal enddate As Date, ByVal salary As Long, ByVal designation As String, ByVal remark As String, ByVal Contact_Person As String, ByVal Faculty_Incharge As String)

        '_course = Course
        _studname = studname
        '_Academicyear = Academic
        _studCode = studCode
        _compname = compname
        _date = PlacementDate
        _enddate = enddate
        _salary = salary
        _designation = designation
        _remark = remark
        _
        _Faculty_Incharge = Faculty_Incharge
        _Contact_Person = Contact_Person
    End Sub
    Public Sub New()
    End Sub
    Private _deleteflag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
End Class
