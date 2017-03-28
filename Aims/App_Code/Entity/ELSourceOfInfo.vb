Imports Microsoft.VisualBasic

Public Class ELSourceOfInfo
    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _SourceOfInfo As String
    Public Property SourceOfInfo() As String
        Get
            Return _SourceOfInfo
        End Get
        Set(ByVal value As String)
            _SourceOfInfo = value
        End Set
    End Property
End Class
