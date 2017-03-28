Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data


Public Class ELStudentEnquiryForm
    Private _Id As Integer
    Private _CourseId As Integer
    Private _StudentId As Integer
    Private _BatchId As Integer
    Private _StudCode As String
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Public Property CourseId() As Integer
        Get
            Return _CourseId
        End Get
        Set(ByVal value As Integer)
            _CourseId = value
        End Set
    End Property
    Public Property StudentId() As Integer
        Get
            Return _StudentId
        End Get
        Set(ByVal value As Integer)
            _StudentId = value
        End Set
    End Property
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property

    Public Property StudCode() As String
        Get
            Return _StudCode
        End Get
        Set(ByVal value As String)
            _StudCode = value
        End Set
    End Property
End Class
