Imports Microsoft.VisualBasic

Public Class TransportReg
    Private _Institute_ID As Int64
    Public Property Institute_ID() As Int64
        Get
            Return _Institute_ID
        End Get
        Set(ByVal value As Int64)
            _Institute_ID = value
        End Set
    End Property
    Private _empname As String
    Public Property EmpName() As String
        Get
            Return _empname
        End Get
        Set(ByVal value As String)
            _empname = value
        End Set
    End Property
    Private _StdEmp As String
    Public Property Std_Emp() As String
        Get
            Return _StdEmp
        End Get
        Set(ByVal value As String)
            _StdEmp = value
        End Set
    End Property
    Private _RBUser As String
    Public Property RBUser() As String
        Get
            Return _RBUser
        End Get
        Set(ByVal value As String)
            _RBUser = value
        End Set
    End Property
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Branch_ID As Int64
    Public Property Branch_ID() As Int64
        Get
            Return _Branch_ID
        End Get
        Set(ByVal value As Int64)
            _Branch_ID = value
        End Set
    End Property
    Private _Acode As Int64
    Public Property Acode() As Int64
        Get
            Return _Acode
        End Get
        Set(ByVal value As Int64)
            _Acode = value
        End Set
    End Property
    Private _Std_ID As Int64
    Public Property Std_ID() As Int64
        Get
            Return _Std_ID
        End Get
        Set(ByVal value As Int64)
            _Std_ID = value
        End Set
    End Property
    Private _Employee_ID As Int64
    Public Property Employee_ID() As Int64
        Get
            Return _Employee_ID
        End Get
        Set(ByVal value As Int64)
            _Employee_ID = value
        End Set
    End Property
    Private _Emp_Code As Int16
    Public Property EmpCd() As Int64
        Get
            Return _Emp_Code
        End Get

        Set(ByVal value As Int64)
            _Emp_Code = value
        End Set
    End Property
    Private _RegDate As Date
    Public Property RegDate() As Date
        Get
            Return _RegDate
        End Get
        Set(ByVal value As Date)
            _RegDate = value
        End Set
    End Property

    Private _RegistrationDate As Date
    Public Property RegistrationDate() As Date
        Get
            Return _RegistrationDate
        End Get
        Set(ByVal value As Date)
            _RegistrationDate = value
        End Set
    End Property
    Private _PickUpPoint As String
    Public Property PickUpPoint() As String
        Get
            Return _PickUpPoint
        End Get
        Set(ByVal value As String)
            _PickUpPoint = value
        End Set
    End Property
    Private _PickUptime As DateTime
    Public Property PickUptime() As DateTime
        Get
            Return _PickUptime
        End Get
        Set(ByVal value As DateTime)
            _PickUptime = value
        End Set
    End Property
    Private _Code As String
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property
    Private _RouteID As Int64
    Public Property RouteID() As Int64
        Get
            Return _RouteID
        End Get
        Set(ByVal value As Int64)
            _RouteID = value
        End Set
    End Property
    Private _Std_Flag As Int64
    Public Property Std_Flag() As Int64
        Get
            Return _Std_Flag
        End Get
        Set(ByVal value As Int64)
            _Std_Flag = value
        End Set
    End Property
    Private _Emp_Flag As Int64
    Public Property Emp_Flag() As Int64
        Get
            Return _Emp_Flag
        End Get
        Set(ByVal value As Int64)
            _Emp_Flag = value
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
    Private _StdCode As Int64
    Public Property StdCode() As Int64
        Get
            Return _StdCode
        End Get
        Set(ByVal value As Int64)
            _StdCode = value
        End Set
    End Property

    Private _EmpCode As Int64
    Public Property EmpCode() As Int64
        Get
            Return _EmpCode
        End Get
        Set(ByVal value As Int64)
            _EmpCode = value
        End Set
    End Property
    Private _EmpId As Int64
    Public Property EmpId() As Int64
        Get
            Return _EmpId
        End Get
        Set(ByVal value As Int64)
            _EmpId = value
        End Set
    End Property

    Private _VehicleID As Int64
    Public Property VehicleID() As Int64
        Get
            Return _VehicleID
        End Get
        Set(ByVal value As Int64)
            _VehicleID = value
        End Set
    End Property
    Private _DeleteFlag As Int64
    Public Property DeleteFlag() As Int64
        Get
            Return _DeleteFlag
        End Get
        Set(ByVal value As Int64)
            _DeleteFlag = value
        End Set
    End Property
    Private _TRNO As Int64
    Public Property TRNO() As Int64
        Get
            Return _TRNO
        End Get
        Set(ByVal value As Int64)
            _TRNO = value
        End Set
    End Property
    Private _stdname As String
    Public Property StdName() As String
        Get
            Return _stdname
        End Get
        Set(ByVal value As String)
            _stdname = value
        End Set
    End Property
    Private _EmpCod As String
    Public Property EmpCod() As String
        Get
            Return _EmpCod
        End Get
        Set(ByVal value As String)
            _EmpCod = value
        End Set
    End Property

    Public Sub New()
    End Sub
End Class

