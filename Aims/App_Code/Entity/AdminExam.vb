Imports Microsoft.VisualBasic

Public Class AdminExamEL
    Private _Duration, _Minute As Integer
    Private _id, _Course, _Subject As Integer
    Private _AnswerLength, _QuestionsName, _Answer As String
    Public Property Course() As Integer
        Get
            Return _Course
        End Get
        Set(ByVal value As Integer)
            _Course = value
        End Set
    End Property
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Subject() As Integer
        Get
            Return _Subject
        End Get
        Set(ByVal value As Integer)
            _Subject = value
        End Set
    End Property
    Public Property Duration() As Integer
        Get
            Return _Duration
        End Get
        Set(ByVal value As Integer)
            _Duration = value
        End Set
    End Property
    Public Property Minute() As Integer
        Get
            Return _Minute
        End Get
        Set(ByVal value As Integer)
            _Minute = value
        End Set
    End Property
    Public Property AnswerLength() As String
        Get
            Return _AnswerLength
        End Get
        Set(ByVal value As String)
            _AnswerLength = value
        End Set
    End Property
    Public Property QuestionsName() As String
        Get
            Return _QuestionsName
        End Get
        Set(ByVal value As String)
            _QuestionsName = value
        End Set
    End Property
    Public Property Answer() As String
        Get
            Return _Answer
        End Get
        Set(ByVal value As String)
            _Answer = value
        End Set
    End Property

End Class
