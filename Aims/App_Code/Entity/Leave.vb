Imports Microsoft.VisualBasic
Imports System

Public Class Leave
    Private _lmid As Long
    Public Property LmId() As Long
        Get
            Return _lmid
        End Get
        Set(ByVal value As Long)
            _lmid = value
        End Set
    End Property
    Private _eid As Long
    Public Property EId() As Long
        Get
            Return _eid
        End Get
        Set(ByVal value As Long)
            _eid = value
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
    Private _Dept_Id As Integer
    Public Property Dept_Id() As Integer
        Get
            Return _Dept_Id
        End Get
        Set(ByVal value As Integer)
            _Dept_Id = value
        End Set
    End Property
    Private _EmpId As Integer
    Public Property EmpId() As Integer
        Get
            Return _EmpId
        End Get
        Set(ByVal value As Integer)
            _EmpId = value
        End Set
    End Property
    Private _leave_type As String
    Public Property Leave_Type() As String
        Get
            Return _leave_type
        End Get
        Set(ByVal value As String)
            _leave_type = value
        End Set
    End Property
    Private _leavetype As Long
    Public Property LeaveType() As Long
        Get
            Return _leavetype
        End Get
        Set(ByVal value As Long)
            _leavetype = value
        End Set
    End Property
    Private _balanceleave As Double
    Public Property BalanceLeave() As Double
        Get
            Return _balanceleave
        End Get
        Set(ByVal value As Double)
            _balanceleave = value
        End Set
    End Property
    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Private _Year As Integer
    Public Property Year() As Integer
        Get
            Return _Year
        End Get
        Set(ByVal value As Integer)
            _Year = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal lmid As Long, ByVal eid As Long, ByVal empname As String, ByVal leave_type As String, ByVal leavetype As Long, ByVal balanceleave As Long, ByVal remarks As String)
        _lmid = lmid
        _eid = eid
        _empname = empname
        _leave_type = Leave_Type
        _leavetype = leavetype
        _balanceleave = balanceleave
        _remarks = remarks
    End Sub
    Private _delflag As Int16
    Public Property Delflag() As Int16
        Get
            Return _delflag
        End Get
        Set(ByVal value As Int16)
            _delflag = value
        End Set
    End Property
End Class
