Imports Microsoft.VisualBasic

Public Class Experience
    Private _ExperienceType As Integer
    Public Property ExperienceType() As Integer
        Get
            Return _ExperienceType
        End Get
        Set(ByVal value As Integer)
            _ExperienceType = value
        End Set
    End Property
    Private _FromDate As String
    Public Property FromDate() As String
        Get
            Return _FromDate
        End Get
        Set(ByVal value As String)
            _FromDate = value
        End Set
    End Property
    Private _ToDate As DateTime
    Public Property ToDate() As DateTime
        Get
            Return _ToDate
        End Get
        Set(ByVal value As DateTime)
            _ToDate = value
        End Set
    End Property
    Private _Certificate As String
    Public Property Certificate() As String
        Get
            Return _Certificate
        End Get
        Set(ByVal value As String)
            _Certificate = value
        End Set
    End Property
    Private _RemarksE As String
    Public Property RemarksE() As String
        Get
            Return _RemarksE
        End Get
        Set(ByVal value As String)
            _RemarksE = value
        End Set
    End Property
    Private _id As Long
    Public Property ExpId() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _std_code As String
    Public Property Std_code() As String
        Get
            Return _std_code
        End Get
        Set(ByVal value As String)
            _std_code = value
        End Set
    End Property
    Private _qname As String
    Public Property Name() As String
        Get
            Return _qname
        End Get
        Set(ByVal value As String)
            _qname = value
        End Set
    End Property
    Private _noOfYears As String
    Public Property NoOfYears() As String
        Get
            Return _noOfYears
        End Get
        Set(ByVal value As String)
            _noOfYears = value
        End Set
    End Property
    Private _natureofjob As String
    Public Property Natureofjob() As String
        Get
            Return _natureofjob
        End Get
        Set(ByVal value As String)
            _natureofjob = value
        End Set
    End Property
    Public Sub New(ByVal id As Long, ByVal std_code As String, ByVal name As String, ByVal noOfYears As String, ByVal natureofjob As String)
        _id = id
        _std_code = std_code
        _qname = name
        _noOfYears = noOfYears
        _natureofjob = natureofjob
    End Sub
    Public Sub New()
    End Sub
End Class
