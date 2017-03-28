Imports Microsoft.VisualBasic
Public Class ELQuestionPaper
    Private _section, _Ques_type, _question As String
    Private _id, _course, _batch, _subject As Integer
    Private _qdate As DateTime
    Private _marks As Double

    Public Property section() As String
        Get
            Return _section
        End Get
        Set(ByVal value As String)
            _section = value

        End Set
    End Property
    Public Property course() As Integer
        Get
            Return _course
        End Get
        Set(ByVal value As Integer)
            _course = value

        End Set
    End Property
    Public Property batch() As Integer
        Get
            Return _batch
        End Get
        Set(ByVal value As Integer)
            _batch = value

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
    Public Property qdate() As DateTime
        Get
            Return _qdate
        End Get
        Set(ByVal value As DateTime)
            _qdate = value

        End Set
    End Property
    
    Public Property question() As String
        Get
            Return _question
        End Get
        Set(ByVal value As String)
            _question = value

        End Set
    End Property
    Public Property subject() As Integer
        Get
            Return _subject
        End Get
        Set(ByVal value As Integer)
            _subject = value

        End Set
    End Property
    Public Property Ques_type() As String
        Get
            Return _Ques_type
        End Get
        Set(ByVal value As String)
            _Ques_type = value

        End Set
    End Property
    Public Property marks() As Double
        Get
            Return _marks
        End Get
        Set(ByVal value As Double)
            _marks = value

        End Set
    End Property
End Class
