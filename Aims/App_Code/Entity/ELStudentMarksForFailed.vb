Imports Microsoft.VisualBasic

Public Class ELStudentMarksForFailed
    Private _A_Marks As Double
    Public Property A_Marks() As Double
        Get
            Return _A_Marks
        End Get
        Set(ByVal value As Double)
            _A_Marks = value
        End Set
    End Property
    Private _Batch As Integer
    Public Property Batch() As Integer
        Get
            Return _Batch
        End Get
        Set(ByVal value As Integer)
            _Batch = value
        End Set
    End Property
    Private _Semester As Integer
    Public Property Semester() As Integer
        Get
            Return _Semester
        End Get
        Set(ByVal value As Integer)
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
    Private _StudId As String
    Public Property StudId() As String
        Get
            Return _StudId
        End Get
        Set(ByVal value As String)
            _StudId = value
        End Set
    End Property
    Private _StudName As String
    Public Property StudName() As String
        Get
            Return _StudName
        End Get
        Set(ByVal value As String)
            _StudName = value
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
    Private _Max As Double
    Public Property Max() As Double
        Get
            Return _Max
        End Get
        Set(ByVal value As Double)
            _Max = value
        End Set
    End Property
    Private _Max1 As Integer
    Public Property Max1() As Integer
        Get
            Return _Max1
        End Get
        Set(ByVal value As Integer)
            _Max1 = value
        End Set
    End Property
    Private _Min1 As Integer
    Public Property Min1() As Integer
        Get
            Return _Min1
        End Get
        Set(ByVal value As Integer)
            _Min1 = value
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
    Private _ExamAttend As Integer
    Public Property ExamAttend() As Integer
        Get
            Return _ExamAttend
        End Get
        Set(ByVal value As Integer)
            _ExamAttend = value
        End Set
    End Property

End Class
