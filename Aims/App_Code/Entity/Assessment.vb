Imports Microsoft.VisualBasic


Public Class Assessment
    Private _id As Int64
    Private _name As String
    Private _SeqNo As Integer
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
    Public Property SeqNo() As Integer
        Get
            Return _SeqNo
        End Get
        Set(ByVal value As Integer)
            _SeqNo = value
        End Set
    End Property

End Class
