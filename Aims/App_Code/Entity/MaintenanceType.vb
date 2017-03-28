Imports Microsoft.VisualBasic

Public Class MaintenanceType
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _maintenancetype As String
    Public Property MaintenanceType() As String
        Get
            Return _maintenancetype
        End Get
        Set(ByVal value As String)
            _maintenancetype = value
        End Set
    End Property
    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal id As Integer, ByVal maintenancetype As String, ByVal remarks As String)
        _id = id
        _maintenancetype = maintenancetype
        _remarks = remarks
    End Sub
    Private _deleteFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteFlag
        End Get
        Set(ByVal value As Int16)
            _deleteFlag = value
        End Set
    End Property
End Class
