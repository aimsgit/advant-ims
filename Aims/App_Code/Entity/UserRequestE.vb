Imports Microsoft.VisualBasic

Public Class UserRequestE
    Private _Id As Integer
    Private _UserId As String
    Private _UserName As String
    Private _RequestDate As Date
    Private _Priority As String
    Private _DescOfRequest As String
    Private _ApprovedBy As String
    Private _Status As String
    Private _ClosedDate As Date
    Private _Remarks As String
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Public Property UserId() As String
        Get
            Return _UserId
        End Get
        Set(ByVal value As String)
            _UserId = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Public Property RequestDate() As Date
        Get
            Return _RequestDate
        End Get
        Set(ByVal value As Date)
            _RequestDate = value
        End Set
    End Property
    Public Property Priority() As String
        Get
            Return _Priority
        End Get
        Set(ByVal value As String)
            _Priority = value
        End Set
    End Property
    Public Property DescOfRequest() As String
        Get
            Return _DescOfRequest
        End Get
        Set(ByVal value As String)
            _DescOfRequest = value
        End Set
    End Property
    Public Property ApprovedBy() As String
        Get
            Return _ApprovedBy
        End Get
        Set(ByVal value As String)
            _ApprovedBy = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property ClosedDate() As Date
        Get
            Return _ClosedDate
        End Get
        Set(ByVal value As Date)
            _ClosedDate = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class
