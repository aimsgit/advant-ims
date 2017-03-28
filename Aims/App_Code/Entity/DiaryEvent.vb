Imports Microsoft.VisualBasic

Public Class DiaryEvent
    Private _diaryId As Integer
    Public Property DiaryId() As Integer
        Get
            Return _diaryId
        End Get
        Set(ByVal value As Integer)
            _diaryId = value
        End Set
    End Property
    Private _eventName As String
    Public Property EventName() As String
        Get
            Return _eventName
        End Get
        Set(ByVal value As String)
            _eventName = value
        End Set
    End Property
    Private _eventDescription As String
    Public Property EventDescription() As String
        Get
            Return _eventDescription
        End Get
        Set(ByVal value As String)
            _eventDescription = value
        End Set
    End Property
    Private _eventDate As DateTime
    Public Property EventDate() As DateTime
        Get
            Return _eventDate
        End Get
        Set(ByVal value As DateTime)
            _eventDate = value
        End Set
    End Property
    Private _eventDuration As Int16
    Public Property EventDuration() As Int16
        Get
            Return _eventDuration
        End Get
        Set(ByVal value As Int16)
            _eventDuration = value
        End Set
    End Property
    Public Sub New(ByVal diaryId As Int16, ByVal eventName As String, ByVal eventDescription As String, ByVal eventDate As DateTime, ByVal eventDuration As Int16)
        _diaryId = diaryId
        _eventName = eventName
        _eventDescription = eventDescription
        _eventDate = eventDate
        _eventDuration = eventDuration
    End Sub
    Public Sub New()
    End Sub
End Class
