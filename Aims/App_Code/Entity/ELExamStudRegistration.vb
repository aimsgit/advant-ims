Imports Microsoft.VisualBasic

Public Class ELExamStudRegistration


    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _ExamBatchId As Integer
    Public Property ExamBatchId() As Integer
        Get
            Return _ExamBatchId
        End Get
        Set(ByVal value As Integer)
            _ExamBatchId = value
        End Set
    End Property
    Private _BatchId As Integer
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property

    Private _StdId As Integer
    Public Property StdId() As Integer
        Get
            Return _StdId
        End Get
        Set(ByVal value As Integer)
            _StdId = value
        End Set
    End Property

    Private _Eligibility As Integer
    Public Property Eligibility() As Integer
        Get
            Return _Eligibility
        End Get
        Set(ByVal value As Integer)
            _Eligibility = value
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
