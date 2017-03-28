Imports Microsoft.VisualBasic

Public Class TimeSheetEL
    Private _ID As Integer
    Private _EmpID As Integer
    Private _BatchID As Integer
    Private _SemesterID As Integer
    Private _SubjectID As Integer
    Private _TopicID As Integer
    Private _Date1 As Date
    Private _time As DateTime
    Private _Period As String
    Private _Duration As Double
    Private _WorkDescription As String

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

    Public Property BatchID() As Integer
        Get
            Return _BatchID
        End Get
        Set(ByVal value As Integer)
            _BatchID = value
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
    Public Property TopicID() As Integer
        Get
            Return _TopicID
        End Get
        Set(ByVal value As Integer)
            _TopicID = value
        End Set
    End Property
    Public Property Date1() As Date
        Get
            Return _Date1
        End Get
        Set(ByVal value As Date)
            _Date1 = value
        End Set
    End Property

    Public Property time() As DateTime
        Get
            Return _time
        End Get
        Set(ByVal value As DateTime)
            _time = value
        End Set
    End Property
    Public Property Period() As String
        Get
            Return _Period
        End Get
        Set(ByVal value As String)
            _Period = value
        End Set
    End Property
    Public Property Duration() As Double
        Get
            Return _Duration
        End Get
        Set(ByVal value As Double)
            _Duration = value
        End Set
    End Property
    Public Property WorkDescription() As String
        Get
            Return _WorkDescription
        End Get
        Set(ByVal value As String)
            _WorkDescription = value
        End Set
    End Property
End Class
