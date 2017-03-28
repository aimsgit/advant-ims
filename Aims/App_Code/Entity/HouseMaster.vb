Imports Microsoft.VisualBasic

Public Class HouseMaster
    Public _Id As Int64
    Public _Name As String
    Public Property Id() As Int64
        Get
            Return _Id
        End Get
        Set(ByVal value As Int64)
            _Id = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    
End Class
