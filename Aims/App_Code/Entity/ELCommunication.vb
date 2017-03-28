Imports Microsoft.VisualBasic

Public Class ELCommunication
    Private _date1 As Date
    Public Property date1() As Date
        Get
            Return _date1
        End Get
        Set(ByVal value As Date)
            _date1 = value
        End Set
    End Property
    Private _toDate As Date
    Public Property toDate() As Date
        Get
            Return _toDate
        End Get
        Set(ByVal value As Date)
            _toDate = value
        End Set
    End Property
    Private _Message As String
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value
        End Set
    End Property
    Private _From As String
    Public Property From() As String
        Get
            Return _From
        End Get
        Set(ByVal value As String)
            _From = value
        End Set
    End Property
    Private _Mode As String
    Public Property Mode() As String
        Get
            Return _Mode
        End Get
        Set(ByVal value As String)
            _Mode = value
        End Set
    End Property
    Private _GroupType As String
    Public Property GroupType() As String
        Get
            Return _GroupType
        End Get
        Set(ByVal value As String)
            _GroupType = value
        End Set
    End Property
    Private _Institute As String
    Public Property Institute() As String
        Get
            Return _Institute
        End Get
        Set(ByVal value As String)
            _Institute = value
        End Set
    End Property
    Private _Branch As String
    Public Property Branch() As String
        Get
            Return _Branch
        End Get
        Set(ByVal value As String)
            _Branch = value
        End Set
    End Property
    Private _ID As String
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Private _deleteflag As Int16
End Class
