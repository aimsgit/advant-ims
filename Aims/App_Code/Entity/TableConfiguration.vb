Imports Microsoft.VisualBasic

Public Class TableConfiguration
    Private _Workflow_ID As Int16
    Public Property Workflow_ID() As Int16
        Get
            Return _Workflow_ID
        End Get
        Set(ByVal value As Int16)
            _Workflow_ID = value
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
    Private _ExpDate As DateTime
    Public Property ExpDate() As DateTime
        Get
            Return _ExpDate
        End Get
        Set(ByVal value As DateTime)
            _ExpDate = value
        End Set
    End Property
    Private _Tablecode As Int32
    Public Property Tablecode() As Int32
        Get
            Return _Tablecode
        End Get
        Set(ByVal value As Int32)
            _Tablecode = value
        End Set
    End Property
    Private _App_Req As String
    Public Property App_Req() As String
        Get
            Return _App_Req
        End Get
        Set(ByVal value As String)
            _App_Req = value
        End Set
    End Property
    Private _FirstApprover As String
    Public Property FirstApprover() As String
        Get
            Return _FirstApprover
        End Get
        Set(ByVal value As String)
            _FirstApprover = value
        End Set
    End Property
    Private _SecApprover As String
    Public Property SecApprover() As String
        Get
            Return _SecApprover
        End Get
        Set(ByVal value As String)
            _SecApprover = value
        End Set
    End Property
    Private _ThirdApprover As String
    Public Property ThirdApprover() As String
        Get
            Return _ThirdApprover
        End Get
        Set(ByVal value As String)
            _ThirdApprover = value
        End Set
    End Property
    Private _FourthApprover As String
    Public Property FourthApprover() As String
        Get
            Return _FourthApprover
        End Get
        Set(ByVal value As String)
            _FourthApprover = value
        End Set
    End Property
    Private _FifthApprover As String
    Public Property FifthApprover() As String
        Get
            Return _FifthApprover
        End Get
        Set(ByVal value As String)
            _FifthApprover = value
        End Set
    End Property
    Private _FirstEmpCode As String
    Public Property FirstEmpCode() As String
        Get
            Return _FirstEmpCode
        End Get
        Set(ByVal value As String)
            _FirstEmpCode = value
        End Set
    End Property
    Private _SecEmpCode As String
    Public Property SecEmpCode() As String
        Get
            Return _SecEmpCode
        End Get
        Set(ByVal value As String)
            _SecEmpCode = value
        End Set
    End Property
    Private _ThirdEmpCode As String
    Public Property ThirdEmpCode() As String
        Get
            Return _ThirdEmpCode
        End Get
        Set(ByVal value As String)
            _ThirdEmpCode = value
        End Set
    End Property
    Private _FourthEmpCode As String
    Public Property FourthEmpCode() As String
        Get
            Return _FourthEmpCode
        End Get
        Set(ByVal value As String)
            _FourthEmpCode = value
        End Set
    End Property
    Private _FifthEmpCode As String
    Public Property FifthEmpCode() As String
        Get
            Return _FifthEmpCode
        End Get
        Set(ByVal value As String)
            _FifthEmpCode = value
        End Set
    End Property
    Private _Del_Flag As String
    Public Property Del_Flag() As String
        Get
            Return _Del_Flag
        End Get
        Set(ByVal value As String)
            _Del_Flag = value
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
    Private _EmpCode As String
    Public Property EmpCode() As String
        Get
            Return _EmpCode
        End Get
        Set(ByVal value As String)
            _EmpCode = value
        End Set
    End Property
    Sub New()
    End Sub
End Class
