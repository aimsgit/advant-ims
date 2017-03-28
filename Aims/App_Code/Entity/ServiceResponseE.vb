Imports Microsoft.VisualBasic

Public Class ServiceResponseE

    Private _Id As Integer
    Private _ReqID As Integer
    Private _UserName As String
    Private _Institute As String
    Private _BranchName As String
    Private _Status As String
    Private _ResponseDate As Date
    Private _CloseDate As Date
    Private _Priority As String
    Private _DescOfRequest As String
    Private _DescOfResponse As String

   
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Public Property ReqID() As Integer
        Get
            Return _ReqID
        End Get
        Set(ByVal value As Integer)
            _ReqID = value
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
    Public Property Institute() As String
        Get
            Return _Institute
        End Get
        Set(ByVal value As String)
            _Institute = value
        End Set
    End Property
    Public Property BranchName() As String
        Get
            Return _BranchName
        End Get
        Set(ByVal value As String)
            _BranchName = value
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
    Public Property ResponseDate() As Date
        Get
            Return _ResponseDate
        End Get
        Set(ByVal value As Date)
            _ResponseDate = value
        End Set
    End Property
    Public Property CloseDate() As Date
        Get
            Return _CloseDate
        End Get
        Set(ByVal value As Date)
            _CloseDate = value
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
    Public Property DescOfResponse() As String
        Get
            Return _DescOfResponse
        End Get
        Set(ByVal value As String)
            _DescOfResponse = value
        End Set
    End Property

    Private _requestdateEamil As Date
    Public Property requestdateEamil() As Date
        Get
            Return _requestdateEamil
        End Get
        Set(ByVal value As Date)
            _requestdateEamil = value
        End Set
    End Property
    Private _EmailserviceRequestNo As String
    Public Property EmailserviceRequestNo() As String
        Get
            Return _EmailserviceRequestNo
        End Get
        Set(ByVal value As String)
            _EmailserviceRequestNo = value
        End Set
    End Property
    Private _Email_id As String
    Public Property Email_id() As String
        Get
            Return _Email_id
        End Get
        Set(ByVal value As String)
            _Email_id = value
        End Set
    End Property

    Private _EmailPhone As String
    Public Property EmailPhone() As String
        Get
            Return _EmailPhone
        End Get
        Set(ByVal value As String)
            _EmailPhone = value
        End Set
    End Property
    Private _EmailInstitute As String
    Public Property EmailInstitute() As String
        Get
            Return _EmailInstitute
        End Get
        Set(ByVal value As String)
            _EmailInstitute = value
        End Set
    End Property
    Private _EmailBranchName As String
    Public Property EmailBranchName() As String
        Get
            Return _EmailBranchName
        End Get
        Set(ByVal value As String)
            _EmailBranchName = value
        End Set
    End Property
    Private _Emailstatus As String
    Public Property Emailstatus() As String
        Get
            Return _Emailstatus
        End Get
        Set(ByVal value As String)
            _Emailstatus = value
        End Set
    End Property
    Private _EmailName As String
    Public Property EmailName() As String
        Get
            Return _EmailName
        End Get
        Set(ByVal value As String)
            _EmailName = value
        End Set
    End Property
    Private _EmailPriority As String
    Public Property EmailPriority() As String
        Get
            Return _EmailPriority
        End Get
        Set(ByVal value As String)
            _EmailPriority = value
        End Set
    End Property
End Class
