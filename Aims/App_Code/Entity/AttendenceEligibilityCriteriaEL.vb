Imports Microsoft.VisualBasic

Public Class AttendenceEligibilityCriteriaEL
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _StdId As String
    Public Property StdId() As String
        Get
            Return _StdId
        End Get
        Set(ByVal value As String)
            _StdId = value
        End Set
    End Property
    Private _StdCode As String
    Public Property StdCode() As String
        Get
            Return _StdCode
        End Get
        Set(ByVal value As String)
            _StdCode = value
        End Set
    End Property
    Private _BatchId As Long
    Public Property BatchId() As Long
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Long)
            _BatchId = value
        End Set
    End Property
    Private _TBatchid As Integer
    Public Property TBatchid() As Integer
        Get
            Return _TBatchid
        End Get
        Set(ByVal value As Integer)
            _TBatchid = value
        End Set
    End Property
    Private _SemId As Long
    Public Property SemId() As Long
        Get
            Return _SemId
        End Get
        Set(ByVal value As Long)
            _SemId = value
        End Set
    End Property
    Private _Min As Long
    Public Property Min() As Long
        Get
            Return _Min
        End Get
        Set(ByVal value As Long)
            _Min = value
        End Set
    End Property
    Private _Eligible As String
    Public Property Eligible() As String
        Get
            Return _Eligible
        End Get
        Set(ByVal value As String)
            _Eligible = value
        End Set
    End Property
    Private _SubjectID As String
    Public Property SubjectID() As String
        Get
            Return _SubjectID
        End Get
        Set(ByVal value As String)
            _SubjectID = value
        End Set
    End Property
    Private _SubjectNamne As String
    Public Property SubjectNamne() As String
        Get
            Return _SubjectNamne
        End Get
        Set(ByVal value As String)
            _SubjectNamne = value
        End Set
    End Property
End Class
