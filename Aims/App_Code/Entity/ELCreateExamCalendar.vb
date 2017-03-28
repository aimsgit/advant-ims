Imports Microsoft.VisualBasic

Public Class ELCreateExamCalendar
    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Private _SubjectId As Integer
    Public Property SubjectId() As Integer
        Get
            Return _SubjectId
        End Get
        Set(ByVal value As Integer)
            _SubjectId = value
        End Set
    End Property
    Private _BatchId As Integer
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property
    Private _TOE As String
    Public Property TOE() As String
        Get
            Return _TOE
        End Get
        Set(ByVal value As String)
            _TOE = value
        End Set
    End Property
    Private _DOE As DateTime
    Public Property DOE() As DateTime
        Get
            Return _DOE
        End Get
        Set(ByVal value As DateTime)
            _DOE = value
        End Set
    End Property
End Class
