Imports Microsoft.VisualBasic

Public Class ELCRMLead
    Private _DemoID As Integer
    Public Property DemoID() As Integer
        Get
            Return _DemoID
        End Get
        Set(ByVal value As Integer)
            _DemoID = value
        End Set
    End Property
    Private _DemoReport As String
    Public Property DemoReport() As String
        Get
            Return _DemoReport
        End Get
        Set(ByVal value As String)
            _DemoReport = value
        End Set
    End Property
    Private _Attachment As String
    Public Property Attachment() As String
        Get
            Return _Attachment
        End Get
        Set(ByVal value As String)
            _Attachment = value
        End Set
    End Property
    Private _Demostatus As String
    Public Property Demostatus() As String
        Get
            Return _Demostatus
        End Get
        Set(ByVal value As String)
            _Demostatus = value
        End Set
    End Property
    Private _AssignedTo As Integer
    Public Property AssignedTo() As Integer
        Get
            Return _AssignedTo
        End Get
        Set(ByVal value As Integer)
            _AssignedTo = value
        End Set
    End Property
    Private _DemoTime As DateTime
    Public Property DemoTime() As DateTime
        Get
            Return _DemoTime
        End Get
        Set(ByVal value As DateTime)
            _DemoTime = value
        End Set
    End Property
    Private _ProposalValue As Double
    Public Property ProposalValue() As Double
        Get
            Return _ProposalValue
        End Get
        Set(ByVal value As Double)
            _ProposalValue = value
        End Set
    End Property
    Private _DemoDate As Date
    Public Property DemoDate() As Date
        Get
            Return _DemoDate
        End Get
        Set(ByVal value As Date)
            _DemoDate = value
        End Set
    End Property
    Private _LeadID As String
    Public Property LeadID() As String
        Get
            Return _LeadID
        End Get
        Set(ByVal value As String)
            _LeadID = value
        End Set
    End Property
    Private _LeadName As String
    Public Property LeadName() As String
        Get
            Return _LeadName
        End Get
        Set(ByVal value As String)
            _LeadName = value
        End Set
    End Property
    Private _Product As String
    Public Property Product() As String
        Get
            Return _Product
        End Get
        Set(ByVal value As String)
            _Product = value
        End Set
    End Property
    Private _PropectId As String
    Public Property PropectId() As String
        Get
            Return _PropectId
        End Get
        Set(ByVal value As String)
            _PropectId = value
        End Set
    End Property
    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Private _ContactNo As String
    Public Property ContactNo() As String
        Get
            Return _ContactNo
        End Get
        Set(ByVal value As String)
            _ContactNo = value
        End Set
    End Property
    Private _EmailID As String
    Public Property EmailID() As String
        Get
            Return _EmailID
        End Get
        Set(ByVal value As String)
            _EmailID = value
        End Set
    End Property
    Private _LeadFrom As String
    Public Property LeadFrom() As String
        Get
            Return _LeadFrom
        End Get
        Set(ByVal value As String)
            _LeadFrom = value
        End Set
    End Property
    Private _EstimatedValue As Double
    Public Property EstimatedValue() As Double
        Get
            Return _EstimatedValue
        End Get
        Set(ByVal value As Double)
            _EstimatedValue = value
        End Set
    End Property
    Private _Probability As Double
    Public Property Probability() As Double
        Get
            Return _Probability
        End Get
        Set(ByVal value As Double)
            _Probability = value
        End Set
    End Property

    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
    Private _EmpCode As String
    Public Property EmpCode() As String
        Get
            Return _EmpCode
        End Get
        Set(ByVal value As String)
            _EmpCode = value
        End Set
    End Property
    Private _UserCode As String
    Public Property UserCode() As String
        Get
            Return _UserCode
        End Get
        Set(ByVal value As String)
            _UserCode = value
        End Set
    End Property
    Private _LeadDate As Date
    Public Property LeadDate() As Date
        Get
            Return _LeadDate
        End Get
        Set(ByVal value As Date)
            _LeadDate = value
        End Set
    End Property
    Private _State As Integer
    Public Property State() As Integer
        Get
            Return _State
        End Get
        Set(ByVal value As Integer)
            _State = value
        End Set
    End Property
    Private _Country As String
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            _Country = value
        End Set
    End Property
    Private _Skypeid As String
    Public Property Skypeid() As String
        Get
            Return _Skypeid
        End Get
        Set(ByVal value As String)
            _Skypeid = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class
