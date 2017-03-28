Imports Microsoft.VisualBasic

Public Class ELTransportaionMfg
    Private _id As Int64
    Private _name As String
    Public Property ID() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Sub New()

    End Sub
End Class
