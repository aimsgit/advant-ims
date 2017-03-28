Imports Microsoft.VisualBasic

Public Class AssetType
    Private _AssetType_ID As Integer
    Public Property AssetType_ID() As Integer
        Get
            Return _AssetType_ID
        End Get
        Set(ByVal value As Integer)
            _AssetType_ID = value
        End Set
    End Property

    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Public Sub New(ByVal AssetTypeID As Integer, ByVal Name As String)
        _AssetType_ID = AssetTypeID
        _Name = Name
    End Sub
    Public Sub New()
    End Sub
End Class
