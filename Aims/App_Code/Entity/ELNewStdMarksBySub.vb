Imports Microsoft.VisualBasic

Public Class ELNewStdMarksBySub
    Private _Percent As Double
    Public Property Percent() As Double
        Get
            Return _Percent
        End Get
        Set(ByVal value As Double)
            _Percent = value
        End Set
    End Property
    Private _A_Marks As Double
    Public Property A_Marks() As Double
        Get
            Return _A_Marks
        End Get
        Set(ByVal value As Double)
            _A_Marks = value
        End Set
    End Property
    Private _SubGrp As Integer
    Public Property SubGrp() As Integer
        Get
            Return _SubGrp
        End Get
        Set(ByVal value As Integer)
            _SubGrp = value
        End Set
    End Property
    Private _Grade As String
    Public Property Grade() As String
        Get
            Return _Grade
        End Get
        Set(ByVal value As String)
            _Grade = value
        End Set
    End Property

    Private _Pass_Fail As String
    Public Property Pass_Fail() As String
        Get
            Return _Pass_Fail
        End Get
        Set(ByVal value As String)
            _Pass_Fail = value
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
    Private _A_Year As Integer
    Public Property A_Year() As Integer
        Get
            Return _A_Year
        End Get
        Set(ByVal value As Integer)
            _A_Year = value
        End Set
    End Property
    Private _Batch As String
    Public Property Batch() As String
        Get
            Return _Batch
        End Get
        Set(ByVal value As String)
            _Batch = value
        End Set
    End Property
    Private _Semester As String
    Public Property Semester() As String
        Get
            Return _Semester
        End Get
        Set(ByVal value As String)
            _Semester = value
        End Set
    End Property
    Private _Subject As Integer
    Public Property Subject() As Integer
        Get
            Return _Subject
        End Get
        Set(ByVal value As Integer)
            _Subject = value
        End Set
    End Property
    Private _StdId As Integer
    Public Property StdId() As Integer
        Get
            Return _StdId
        End Get
        Set(ByVal value As Integer)
            _StdId = value
        End Set
    End Property
    Private _Assesment As Integer
    Public Property Assesment() As Integer
        Get
            Return _Assesment
        End Get
        Set(ByVal value As Integer)
            _Assesment = value
        End Set
    End Property
    Private _AssesmentDate As DateTime
    Public Property AssesmentDate() As DateTime
        Get
            Return _AssesmentDate
        End Get
        Set(ByVal value As DateTime)
            _AssesmentDate = value
        End Set
    End Property
    Private _ClassType As Integer
    Public Property ClassType() As Integer
        Get
            Return _ClassType
        End Get
        Set(ByVal value As Integer)
            _ClassType = value
        End Set
    End Property
    Private _Elective As Integer
    Public Property Elective() As Integer
        Get
            Return _Elective
        End Get
        Set(ByVal value As Integer)
            _Elective = value
        End Set
    End Property
    Private _StudId As Integer
    Public Property StudId() As Integer
        Get
            Return _StudId
        End Get
        Set(ByVal value As Integer)
            _StudId = value
        End Set
    End Property
    Private _Max As Double
    Public Property Max() As Double
        Get
            Return _Max
        End Get
        Set(ByVal value As Double)
            _Max = value
        End Set
    End Property
    Private _Min As Double
    Public Property Min() As Double
        Get
            Return _Min
        End Get
        Set(ByVal value As Double)
            _Min = value
        End Set
    End Property
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _ExamAttendance As Integer
    Public Property ExamAttendance() As Integer
        Get
            Return _ExamAttendance
        End Get
        Set(ByVal value As Integer)
            _ExamAttendance = value
        End Set
    End Property
    Private _Max1 As Double
    Public Property Max1() As Double
        Get
            Return _Max1
        End Get
        Set(ByVal value As Double)
            _Max1 = value
        End Set
    End Property
    Private _Min1 As Double
    Public Property Min1() As Double
        Get
            Return _Min1
        End Get
        Set(ByVal value As Double)
            _Min1 = value
        End Set
    End Property
    Sub New(ByVal Course As String, ByVal subject As String, ByVal theory As Int16, ByVal Lab As String, ByVal Project As String, ByVal Semester As String, ByVal id As Integer)
        _A_Year = A_Year
        _Subject = subject
        _Batch = Batch
        _Assesment = Assesment
        _ClassType = ClassType
        _Semester = Semester
        _id = id
        _A_Marks = A_Marks
    End Sub
    Sub New()

    End Sub
End Class
