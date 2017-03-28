Imports Microsoft.VisualBasic

Public Class TableMaster
    Private _TableID As Int64
    Public Property TableID() As Int64
        Get
            Return _TableID
        End Get
        Set(ByVal value As Int64)
            _TableID = value
        End Set
    End Property
    Private _TableName As String
    Public Property TableName() As String
        Get
            Return _TableName
        End Get
        Set(ByVal value As String)
            _TableName = value
        End Set
    End Property
    Private _Del_Flag As String
    Public Property Del_Flag() As String
        Get
            Return _Del_Flag
        End Get
        Set(ByVal value As String)
            _Del_Flag = value
        End Set
    End Property
    Private _TableAL As String
    Public Property TableAL() As String
        Get
            Return _TableAL
        End Get
        Set(ByVal value As String)
            _TableAL = value
        End Set
    End Property
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class
