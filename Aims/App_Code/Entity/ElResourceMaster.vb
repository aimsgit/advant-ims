Imports Microsoft.VisualBasic

Public Class ElResourceMaster
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Capacity As Integer
    Public Property Capacity() As Integer
        Get
            Return _Capacity
        End Get
        Set(ByVal value As Integer)
            _Capacity = value
        End Set
    End Property

    Private _resourcetype As String
    Public Property ResourceType() As String
        Get
            Return _resourcetype
        End Get
        Set(ByVal value As String)
            _resourcetype = value
        End Set
    End Property
    Private _resourcename As String
    Public Property ResourceName() As String
        Get
            Return _resourcename
        End Get
        Set(ByVal value As String)
            _resourcename = value
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
    Public Sub New(ByVal id As Integer, ByVal feehead As String)
        _id = id

    End Sub
    Public Sub New()
    End Sub
End Class
