Imports Microsoft.VisualBasic

Public Class ELPublishResult
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _Batchid As Integer
    Public Property Batchid() As Integer
        Get
            Return _Batchid
        End Get
        Set(ByVal value As Integer)
            _Batchid = value
        End Set
    End Property
    Private _Semesterid As Integer
    Public Property Semesterid() As Integer
        Get
            Return _Semesterid
        End Get
        Set(ByVal value As Integer)
            _Semesterid = value
        End Set
    End Property
    Private _Subjectid As Integer
    Public Property Subjectid() As Integer
        Get
            Return _Subjectid
        End Get
        Set(ByVal value As Integer)
            _Subjectid = value
        End Set
    End Property
    Private _Assessmentid As Integer
    Public Property Assessmentid() As Integer
        Get
            Return _Assessmentid
        End Get
        Set(ByVal value As Integer)
            _Assessmentid = value
        End Set
    End Property
    Private _Publish_Result As String
    Public Property Publish_Result() As String
        Get
            Return _Publish_Result
        End Get
        Set(ByVal value As String)
            _Publish_Result = value
        End Set
    End Property
End Class
