Imports Microsoft.VisualBasic

Public Class ELSemFinalResult
    Private _ID As String
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property

    Private _Assesmentid As Integer
    Public Property Assesmentid() As Integer
        Get
            Return _Assesmentid
        End Get
        Set(ByVal value As Integer)
            _Assesmentid = value
        End Set
    End Property
    Private _Batch As Integer
    Public Property Batch() As Integer
        Get
            Return _Batch
        End Get
        Set(ByVal value As Integer)
            _Batch = value
        End Set
    End Property
    Private _AssessID As String
    Public Property AssessID() As String
        Get
            Return _AssessID
        End Get
        Set(ByVal value As String)
            _AssessID = value
        End Set
    End Property

    Private _Semester As Integer
    Public Property Semester() As Integer
        Get
            Return _Semester
        End Get
        Set(ByVal value As Integer)
            _Semester = value
        End Set
    End Property
    Private _AssesmentTypeID As String
    Public Property AssesmentTypeID() As String
        Get
            Return _AssesmentTypeID
        End Get
        Set(ByVal value As String)
            _AssesmentTypeID = value
        End Set
    End Property

  
End Class
