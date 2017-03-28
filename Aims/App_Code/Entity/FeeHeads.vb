Imports Microsoft.VisualBasic

Public Class FeeHeads
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _feehead As String
    Public Property FeeHead() As String
        Get
            Return _feehead
        End Get
        Set(ByVal value As String)
            _feehead = value
        End Set
    End Property
    Private _deleteFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteFlag
        End Get
        Set(ByVal value As Int16)
            _deleteFlag = value
        End Set
    End Property
    Public Sub New(ByVal id As Integer, ByVal feehead As String)
        _id = id
        _feehead = feehead
    End Sub
    Public Sub New()
    End Sub
End Class
