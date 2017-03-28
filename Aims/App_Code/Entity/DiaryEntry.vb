Imports Microsoft.VisualBasic

Public Class DiaryEntry
    Private _diaryEntryId As Integer
    Public Property DiaryEntryId() As Integer
        Get
            Return _diaryEntryId
        End Get
        Set(ByVal value As Integer)
            _diaryEntryId = value
        End Set
    End Property
    Private _entryText As String
    Public Property EntryText() As String
        Get
            Return _entryText
        End Get
        Set(ByVal value As String)
            _entryText = value
        End Set
    End Property
    Private _entryTitle As String
    Public Property EntryTitle() As String
        Get
            Return _entryTitle
        End Get
        Set(ByVal value As String)
            _entryTitle = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal diaryEntryId As Int16, ByVal entryText As String, ByVal entryTitle As String)
        _diaryEntryId = diaryEntryId
        _entryText = entryText
        _entryTitle = entryTitle

    End Sub
End Class
