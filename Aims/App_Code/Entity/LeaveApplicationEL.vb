Imports Microsoft.VisualBasic

Public Class LeaveApplicationEL
    Private _emp_Name As String
    Public Property Emp_Name() As String
        Get
            Return _emp_Name
        End Get
        Set(ByVal value As String)
            _emp_Name = value
        End Set
    End Property
    Private _nofdays As Double
    Public Property nofdays() As Double
        Get
            Return _nofdays
        End Get
        Set(ByVal value As Double)
            _nofdays = value
        End Set
    End Property
    Private _leavetype As Int64
    Public Property leavetype() As Int64
        Get
            Return _leavetype
        End Get
        Set(ByVal value As Int64)
            _leavetype = CInt(value)
        End Set
    End Property
    Private _baleave As Double
    Public Property baleave() As Double
        Get
            Return _baleave
        End Get
        Set(ByVal value As Double)
            _baleave = CInt(value)
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
    Private _empid As Int16
    Public Property empid() As Int16
        Get
            Return _empid
        End Get
        Set(ByVal value As Int16)
            _empid = value
        End Set
    End Property
    Private _reason As String
    Public Property reason() As String
        Get
            Return _reason
        End Get
        Set(ByVal value As String)
            _reason = value
        End Set
    End Property
    Private _FeedBack As String
    Public Property FeedBack() As String
        Get
            Return _FeedBack
        End Get
        Set(ByVal value As String)
            _FeedBack = value
        End Set
    End Property
    Private _appDate As Date
    Public Property appDate() As Date
        Get
            Return _appDate
        End Get
        Set(ByVal value As Date)
            _appDate = value
        End Set
    End Property
    Private _Leavefrom As Date
    Public Property Leavefrom() As Date
        Get
            Return _Leavefrom
        End Get
        Set(ByVal value As Date)
            _Leavefrom = value
        End Set
    End Property
    Private _Leaveto As Date
    Public Property Leaveto() As Date
        Get
            Return _Leaveto
        End Get
        Set(ByVal value As Date)
            _Leaveto = value
        End Set
    End Property
    Private _RBId1 As Integer
    Public Property RBId1() As Integer
        Get
            Return _RBId1
        End Get
        Set(ByVal value As Integer)
            _RBId1 = value
        End Set
    End Property
    Private _RBId2 As Integer
    Public Property RBId2() As Integer
        Get
            Return _RBId2
        End Get
        Set(ByVal value As Integer)
            _RBId2 = value
        End Set
    End Property

    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Private _ApproveStatus As String
    Public Property ApproveStatus() As String
        Get
            Return _ApproveStatus
        End Get
        Set(ByVal value As String)
            _ApproveStatus = value
        End Set
    End Property

    Private _UserCode As String
    Public Property UserCode() As String
        Get
            Return _UserCode
        End Get
        Set(ByVal value As String)
            _UserCode = value
        End Set
    End Property
    Private _ApplicantRemarks As String
    Public Property ApplicantRemarks() As String
        Get
            Return _ApplicantRemarks
        End Get
        Set(ByVal value As String)
            _ApplicantRemarks = value
        End Set
    End Property
End Class
