Imports Microsoft.VisualBasic

Public Class LessonPlanEL
    Private _ID As Integer
    Private _EmpID As Integer
    Private _Courseid As Integer
    Private _SemesterID As Integer
    Private _SubjectID As Integer
    Private _Topic As String
    Private _TopicHrs As Double
    Private _FromDate As Date
    Private _ToDate As Date
    Private _Week As String
    Private _Unit As String
    Private _Portion As Double
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Public Property EmpID() As Integer
        Get
            Return _EmpID
        End Get
        Set(ByVal value As Integer)
            _EmpID = value
        End Set
    End Property

    Public Property Courseid() As Integer
        Get
            Return _Courseid
        End Get
        Set(ByVal value As Integer)
            _Courseid = value
        End Set
    End Property
    Public Property SemesterID() As Integer
        Get
            Return _SemesterID
        End Get
        Set(ByVal value As Integer)
            _SemesterID = value
        End Set
    End Property
    Public Property SubjectID() As Integer
        Get
            Return _SubjectID
        End Get
        Set(ByVal value As Integer)
            _SubjectID = value
        End Set
    End Property
    Public Property Topic() As String
        Get
            Return _Topic
        End Get
        Set(ByVal value As String)
            _Topic = value
        End Set
    End Property
    Public Property Unit() As String
        Get
            Return _Unit
        End Get
        Set(ByVal value As String)
            _Unit = value
        End Set
    End Property
    Public Property TopicHrs() As Double
        Get
            Return _TopicHrs
        End Get
        Set(ByVal value As Double)
            _TopicHrs = value
        End Set
    End Property
    Public Property Portion() As Double
        Get
            Return _Portion
        End Get
        Set(ByVal value As Double)
            _Portion = value
        End Set
    End Property

    Public Property FromDate() As Date
        Get
            Return _FromDate
        End Get
        Set(ByVal value As Date)
            _FromDate = value
        End Set
    End Property
    Public Property ToDate() As Date
        Get
            Return _ToDate
        End Get
        Set(ByVal value As Date)
            _ToDate = value
        End Set
    End Property
    Public Property Week() As String
        Get
            Return _Week
        End Get
        Set(ByVal value As String)
            _Week = value
        End Set
    End Property
End Class
