Imports Microsoft.VisualBasic

Public Class ELAssetTansferNew
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _AssetType As Integer
    Public Property AssetType() As Integer
        Get
            Return _AssetType
        End Get
        Set(ByVal value As Integer)
            _AssetType = value
        End Set
    End Property
    Private _AssetName As Integer
    Public Property AssetName() As Integer
        Get
            Return _AssetName
        End Get
        Set(ByVal value As Integer)
            _AssetName = value
        End Set
    End Property
    Private _AssetDate As DateTime
    Public Property AssetDate() As DateTime
        Get
            Return _AssetDate
        End Get
        Set(ByVal value As DateTime)
            _AssetDate = value
        End Set
    End Property
    Private _FromBranch As String
    Public Property FromBranch() As String
        Get
            Return _FromBranch
        End Get
        Set(ByVal value As String)
            _FromBranch = value
        End Set
    End Property
    Private _ToBranch As String
    Public Property ToBranch() As String
        Get
            Return _ToBranch
        End Get
        Set(ByVal value As String)
            _ToBranch = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class
