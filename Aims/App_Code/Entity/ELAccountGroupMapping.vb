Imports Microsoft.VisualBasic

Public Class ELAccountGroupMapping
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _AccountGroupId As String
    Public Property AccountGroupId() As String
        Get
            Return _AccountGroupId
        End Get
        Set(ByVal value As String)
            _AccountGroupId = value
        End Set
    End Property
    Private _AccountSubGroupId As String
    Public Property AccountSubGroupId() As String
        Get
            Return _AccountSubGroupId
        End Get
        Set(ByVal value As String)
            _AccountSubGroupId = value
        End Set
    End Property
    Private _AccountSubGroup As String
    Public Property AccountSubGroup() As String
        Get
            Return _AccountSubGroup
        End Get
        Set(ByVal value As String)
            _AccountSubGroup = value
        End Set
    End Property
    Private _AccountGroup2 As String
    Public Property AccountGroup2() As String
        Get
            Return _AccountGroup2
        End Get
        Set(ByVal value As String)
            _AccountGroup2 = value
        End Set
    End Property
End Class
