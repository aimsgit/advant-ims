Imports Microsoft.VisualBasic

Public Class StudentE
    Private _id As Int64
    Private _branchcode As String
    Public Property ID() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
        End Set
    End Property
    Public Property BranchCode() As String
        Get
            Return _branchcode
        End Get
        Set(ByVal value As String)
            _branchcode = value
        End Set
    End Property


End Class
