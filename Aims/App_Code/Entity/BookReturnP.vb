Imports Microsoft.VisualBasic
'Namespace BookReturnP
Public Class BookReturnP
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _StudentCode As String
    Public Property StudentCode() As String
        Get
            Return _StudentCode
        End Get
        Set(ByVal value As String)
            _StudentCode = value
        End Set
    End Property
    Private _StudentName As String
    Public Property StudentName() As String
        Get
            Return _StudentName
        End Get
        Set(ByVal value As String)
            _StudentName = value
        End Set
    End Property
    Private _EmployeeCode As String
    Public Property EmployeeCode() As String
        Get
            Return _EmployeeCode
        End Get
        Set(ByVal value As String)
            _EmployeeCode = value
        End Set
    End Property
    Private _EmployeeName As String
    Public Property EmployeeName() As String
        Get
            Return _EmployeeName
        End Get
        Set(ByVal value As String)
            _EmployeeName = value
        End Set
    End Property
    Private _BookCode As String
    Public Property BookCode() As String
        Get
            Return _BookCode
        End Get
        Set(ByVal value As String)
            _BookCode = value
        End Set
    End Property
    Private _BookName As String
    Public Property BookName() As String
        Get
            Return _BookName
        End Get
        Set(ByVal value As String)
            _BookName = value
        End Set
    End Property
    Private _DueDate As Date
    Public Property DueDate() As Date
        Get
            Return _DueDate
        End Get
        Set(ByVal value As Date)
            _DueDate = value
        End Set
    End Property
    Private _ReturnDate As Date
    Public Property ReturnDate() As Date
        Get
            Return _ReturnDate
        End Get
        Set(ByVal value As Date)
            _ReturnDate = value
        End Set
    End Property
    Private _DayFine As Double
    Public Property DayFine() As Double
        Get
            Return _DayFine
        End Get
        Set(ByVal value As Double)
            _DayFine = value
        End Set
    End Property
    Private _Days As Integer
    Public Property Days() As Integer
        Get
            Return _Days
        End Get
        Set(ByVal value As Integer)
            _Days = value
        End Set
    End Property
    Private _Fine As Double
    Public Property Fine() As Double
        Get
            Return _Fine
        End Get
        Set(ByVal value As Double)
            _Fine = value
        End Set
    End Property
    Private _STD_ID As Integer
    Public Property STD_ID() As Integer
        Get
            Return _STD_ID
        End Get
        Set(ByVal value As Integer)
            _STD_ID = value
        End Set
    End Property
    Private _Std_Emp As String
    Public Property Std_Emp() As String
        Get
            Return _Std_Emp
        End Get
        Set(ByVal value As String)
            _Std_Emp = value
        End Set
    End Property
    Private _EmpID As Integer
    Public Property EmpID() As Integer
        Get
            Return _EmpID
        End Get
        Set(ByVal value As Integer)
            _EmpID = value
        End Set
    End Property
    Private _DeptId As Integer
    Public Property DeptId() As Integer
        Get
            Return _DeptId
        End Get
        Set(ByVal value As Integer)
            _DeptId = value
        End Set
    End Property
    Private _BookID As Integer
    Public Property BookID() As Integer
        Get
            Return _BookID
        End Get
        Set(ByVal value As Integer)
            _BookID = value
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
    'Private _id As String
    'Public Property id() As String
    '    Get
    '        Return _id
    '    End Get
    '    Set(ByVal value As String)
    '        _id = value
    '    End Set
    'End Property
    'Private _ActualReturnDate As Date
    'Public Property ActualReturnDate() As Date
    '    Get
    '        Return _ActualReturnDate
    '    End Get
    '    Set(ByVal value As Date)
    '        _ActualReturnDate = value
    '    End Set
    'End Property
    'Private _Date As DateTime
    'Public Property Todaydate() As DateTime
    '    Get
    '        Return _Date
    '    End Get
    '    Set(ByVal value As DateTime)
    '        _Date = value
    '    End Set
    'End Property
    'Private _ReturnDate As Date
    'Public Property ReturnDate() As Date
    '    Get
    '        Return _ReturnDate
    '    End Get
    '    Set(ByVal value As Date)
    '        _ReturnDate = value
    '    End Set
    'End Property
    'Private _Who As String
    'Public Property Who() As String
    '    Get
    '        Return _Who
    '    End Get
    '    Set(ByVal value As String)
    '        _Who = value
    '        If value = "Student" Then
    '            Rpt = "True"
    '        Else
    '            Rpt = "False"
    '        End If
    '    End Set
    'End Property
    'Private _Fine As Double
    'Public Property Fine() As Double
    '    Get
    '        Return _Fine
    '    End Get
    '    Set(ByVal value As Double)
    '        _Fine = value
    '    End Set
    'End Property
    'Private _Return As Double
    'Public Property ReturnBook() As Double
    '    Get
    '        Return _Return
    '    End Get
    '    Set(ByVal value As Double)
    '        _Return = value
    '    End Set
    'End Property
    'Private _Institute As Long
    'Public Property InstituteId() As Long
    '    Get
    '        Return _Institute
    '    End Get
    '    Set(ByVal value As Long)
    '        _Institute = value
    '    End Set
    'End Property
    'Private _Branch As Long
    'Public Property BranchId() As Long
    '    Get
    '        Return _Branch
    '    End Get
    '    Set(ByVal value As Long)
    '        _Branch = value
    '    End Set
    'End Property
    'Private _Bool As Boolean
    'Public Property Rpt() As Boolean
    '    Get
    '        Return _Bool
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _Bool = value
    '    End Set
    'End Property
End Class
'End Namespace
