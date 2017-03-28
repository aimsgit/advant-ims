Imports Microsoft.VisualBasic

Public Class ELAssetType
    Private _AssetType_ID As Integer
    Public Property AssetType_ID() As Integer
        Get
            Return _AssetType_ID
        End Get
        Set(ByVal value As Integer)
            _AssetType_ID = value
        End Set
    End Property

    Private _AssetType_Name As String
    Public Property AssetType_Name() As String
        Get
            Return _AssetType_Name
        End Get
        Set(ByVal value As String)
            _AssetType_Name = value
        End Set
    End Property
    Private _AssetType_Code As String
    Public Property AssetType_Code() As String
        Get
            Return _AssetType_Code
        End Get
        Set(ByVal value As String)
            _AssetType_Code = value
        End Set
    End Property
    Private _AssetType_Desc As String
    Public Property AssetType_Desc() As String
        Get
            Return _AssetType_Desc
        End Get
        Set(ByVal value As String)
            _AssetType_Desc = value
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
    Public Sub New(ByVal AssetType_ID As Integer, ByVal AssetType_Name As String, ByVal AssetType_Code As Integer, ByVal AssetType_Desc As String, ByVal deleteflag As Int16)
        _AssetType_ID = AssetType_ID
        _AssetType_Name = AssetType_Name
        _AssetType_Code = AssetType_Code
        _AssetType_Desc = AssetType_Desc
        _deleteFlag = deleteflag
    End Sub
    Public Sub New()
    End Sub
End Class
