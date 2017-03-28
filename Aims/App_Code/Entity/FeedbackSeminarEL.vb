Imports Microsoft.VisualBasic

Public Class FeedbackSeminarEL
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _DeptID As Long
    Public Property DeptID() As Long
        Get
            Return _DeptID
        End Get
        Set(ByVal value As Long)
            _DeptID = value
        End Set
    End Property
    Private _EmpID As Long
    Public Property EmpID() As Long
        Get
            Return _EmpID
        End Get
        Set(ByVal value As Long)
            _EmpID = value
        End Set
    End Property
    Private _ProgramTitle As String
    Public Property ProgramTitle() As String
        Get
            Return _ProgramTitle
        End Get
        Set(ByVal value As String)
            _ProgramTitle = value
        End Set
    End Property
    Private _Location As String
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property
    Private _FromDate As Date
    Public Property FromDate() As Date
        Get
            Return _FromDate
        End Get
        Set(ByVal value As Date)
            _FromDate = value
        End Set
    End Property
    Private _ToDate As Date
    Public Property ToDate() As Date
        Get
            Return _ToDate
        End Get
        Set(ByVal value As Date)
            _ToDate = value
        End Set
    End Property
    Private _TrainingFaculty As String
    Public Property TrainingFaculty() As String
        Get
            Return _TrainingFaculty
        End Get
        Set(ByVal value As String)
            _TrainingFaculty = value
        End Set
    End Property
    Private _ProgramFeedback As String
    Public Property ProgramFeedback() As String
        Get
            Return _ProgramFeedback
        End Get
        Set(ByVal value As String)
            _ProgramFeedback = value
        End Set
    End Property
    Private _CanYou As String
    Public Property CanYou() As String
        Get
            Return _CanYou
        End Get
        Set(ByVal value As String)
            _CanYou = value
        End Set
    End Property
    Private _ProgramEffectiveness As String
    Public Property ProgramEffectiveness() As String
        Get
            Return _ProgramEffectiveness
        End Get
        Set(ByVal value As String)
            _ProgramEffectiveness = value
        End Set
    End Property
End Class
