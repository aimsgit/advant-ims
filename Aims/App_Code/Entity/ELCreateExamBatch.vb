Imports Microsoft.VisualBasic

Public Class ELCreateExamBatch
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _BatchName As String
    Public Property BatchName() As String
        Get
            Return _BatchName
        End Get
        Set(ByVal value As String)
            _BatchName = value
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
