Imports Microsoft.VisualBasic

Public Class ELExamResources
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _BatchNameId As Integer
    Public Property BatchNameId() As Integer
        Get
            Return _BatchNameId
        End Get
        Set(ByVal value As Integer)
            _BatchNameId = value
        End Set
    End Property
    Private _ResTypeId As String
    Public Property ResTypeId() As String
        Get
            Return _ResTypeId
        End Get
        Set(ByVal value As String)
            _ResTypeId = value
        End Set
    End Property
    Private _ResNameId As Integer
    Public Property ResNameId() As Integer
        Get
            Return _ResNameId
        End Get
        Set(ByVal value As Integer)
            _ResNameId = value
        End Set
    End Property
    Private _Capacity As String
    Public Property Capacity() As String
        Get
            Return _Capacity
        End Get
        Set(ByVal value As String)
            _Capacity = value
        End Set
    End Property
    Private _Branchcode As String
    Public Property Branchcode() As String
        Get
            Return _Branchcode
        End Get
        Set(ByVal value As String)
            _Branchcode = value
        End Set
    End Property

End Class
