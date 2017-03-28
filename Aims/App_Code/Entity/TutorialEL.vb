Imports Microsoft.VisualBasic

Public Class TutorialEL
    Private _Link_Name As String
    Private _Duration, _Minute, _id, _Course, _Subject As Integer

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
    Public Property Course() As Integer
        Get
            Return _Course
        End Get
        Set(ByVal value As Integer)
            _Course = value
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
    Public Property Duration() As Integer
        Get
            Return _Duration
        End Get
        Set(ByVal value As Integer)
            _Duration = value
        End Set
    End Property
    Public Property Link_Name() As String
        Get
            Return _Link_Name
        End Get
        Set(ByVal value As String)
            _Link_Name = value
        End Set
    End Property
End Class
