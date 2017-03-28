Imports Microsoft.VisualBasic

Public Class CertificateIssuedE
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _Institute_ID As Integer
    Public Property Institute_ID() As Integer
        Get
            Return _Institute_ID
        End Get
        Set(ByVal value As Integer)
            _Institute_ID = value
        End Set
    End Property
    Private _Branch_ID As Integer
    Public Property Branch_ID() As Integer
        Get
            Return _Branch_ID
        End Get
        Set(ByVal value As Integer)
            _Branch_ID = value
        End Set
    End Property
    Private _Course_ID As Integer
    Public Property Course_ID() As Integer
        Get
            Return _Course_ID
        End Get
        Set(ByVal value As Integer)
            _Course_ID = value
        End Set
    End Property
    Private _Batch_No As Integer
    Public Property Batch_No() As Integer
        Get
            Return _Batch_No
        End Get
        Set(ByVal value As Integer)
            _Batch_No = value
        End Set
    End Property
    Private _Certificate_ID As Integer
    Public Property Certificate_ID() As Integer
        Get
            Return _Certificate_ID
        End Get
        Set(ByVal value As Integer)
            _Certificate_ID = value
        End Set
    End Property
    Private _StdID As Integer
    Public Property StdID() As Integer
        Get
            Return _StdID
        End Get
        Set(ByVal value As Integer)
            _StdID = value
        End Set
    End Property
    Private _IssueDate As Date
    Public Property IssueDate() As Date
        Get
            Return _IssueDate
        End Get
        Set(ByVal value As Date)
            _IssueDate = value
        End Set
    End Property
    Private _Certificate_No As Integer
    Public Property Certificate_No() As Integer
        Get
            Return _Certificate_No
        End Get
        Set(ByVal value As Integer)
            _Certificate_No = value
        End Set
    End Property
    Private _Del_Flag As Boolean
    Public Property Del_Flag() As Boolean
        Get
            Return _Del_Flag
        End Get
        Set(ByVal value As Boolean)
            _Del_Flag = value
        End Set
    End Property

    Public Sub New(ByVal Certificate_ID As Integer)

    End Sub
    Public Sub New()

    End Sub
End Class
