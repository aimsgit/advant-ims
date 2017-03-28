Imports Microsoft.VisualBasic

Public Class ServiceRequestE
    Private _Id As Integer
    Private _ReqID As Integer
    Private _UserName As String
    Private _RequestDate As Date
    Private _Priority As String
    Private _DescOfRequest As String
    Private _ApprovedBy As String
    Private _Status As String
    Private _ClosedDate As Date
    Private _Remarks As String
    Private _Email As String
    Private _PhNo As String
    Private _ModuleId As Integer
    Private _ServReqId As String


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
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Public Property PhNo() As String
        Get
            Return _PhNo
        End Get
        Set(ByVal value As String)
            _PhNo = value
        End Set
    End Property

    Public Property ModuleId() As Integer
        Get
            Return _ModuleId
        End Get
        Set(ByVal value As Integer)
            _ModuleId = value
        End Set
    End Property
    Public Property ServReqId() As String
        Get
            Return _ServReqId
        End Get
        Set(ByVal value As String)
            _ServReqId = value
        End Set
    End Property
End Class


