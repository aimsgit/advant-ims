Imports Microsoft.VisualBasic

Public Class Medium
    Private _id As Long

    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
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

    Private _deleteflag As Int16

    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal id As Long, ByVal name As String)
        _id = id
        _name = name
    End Sub
End Class
