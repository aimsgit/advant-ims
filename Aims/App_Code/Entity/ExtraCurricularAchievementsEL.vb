Imports Microsoft.VisualBasic

Public Class ExtraCurricularAchievementsEL
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _DeptID As Long
    Public Property DeptID() As Long
        Get
            Return _DeptID
        End Get
        Set(ByVal value As Long)
            _DeptID = value
        End Set
    End Property
    Private _NameOfActivity As String
    Public Property NameOfActivity() As String
        Get
            Return _NameOfActivity
        End Get
        Set(ByVal value As String)
            _NameOfActivity = value
        End Set
    End Property
    Private _FromDate As Date
    Public Property FromDate() As Date
        Get
            Return _FromDate
        End Get
        Set(ByVal value As Date)
            _FromDate = value
        End Set
    End Property
    Private _ToDate As Date
    Public Property ToDate() As Date
        Get
            Return _ToDate
        End Get
        Set(ByVal value As Date)
            _ToDate = value
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
    Private _StdCode As String
    Public Property StdCode() As String
        Get
            Return _StdCode
        End Get
        Set(ByVal value As String)
            _StdCode = value
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
    Private _StdEmp As String
    Public Property Std_Emp() As String
        Get
            Return _StdEmp
        End Get
        Set(ByVal value As String)
            _StdEmp = value
        End Set
    End Property
    Private _empid As Integer
    Public Property Empid() As Integer
        Get
            Return _empid
        End Get
        Set(ByVal value As Integer)
            _empid = value
        End Set
    End Property
    Private _stdid As Integer
    Public Property Stdid() As Integer
        Get
            Return _stdid
        End Get
        Set(ByVal value As Integer)
            _stdid = value
        End Set
    End Property
End Class
