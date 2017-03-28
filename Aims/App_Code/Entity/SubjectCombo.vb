Imports Microsoft.VisualBasic

Public Class SubjectCombo
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Sub New(ByVal name As String, ByVal id As Integer)
        _name = name
        _id = id
    End Sub
End Class
