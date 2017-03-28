Imports Microsoft.VisualBasic

Public Class Theme
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Sub New(ByVal name As String)
        _name = name
    End Sub
    Public Sub New()
    End Sub
End Class
