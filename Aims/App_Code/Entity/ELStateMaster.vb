Imports Microsoft.VisualBasic

Public Class ELStateMaster
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _State As String
    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            _State = value
        End Set
    End Property
    Private _Country As Integer
    Public Property Country() As Integer
        Get
            Return _Country
        End Get
        Set(ByVal value As Integer)
            _Country = value
        End Set
    End Property
End Class
