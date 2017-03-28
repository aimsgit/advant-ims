Imports Microsoft.VisualBasic
Imports System.io
Public Class AttendanceP
    Private _stdid As Int64
    Public Property StdId() As Int64
        Get
            Return _stdid
        End Get
        Set(ByVal value As Int64)
            _stdid = value
        End Set
    End Property

    Private _totalclass As Integer
    Public Property Totalclass() As Int32
        Get
            Return _totalclass
        End Get
        Set(ByVal value As Int32)
            _totalclass = CInt(value)
        End Set
    End Property

    Private _totalAttendance As Integer
    Public Property TotalAttendance() As Int32
        Get
            Return _totalAttendance
        End Get
        Set(ByVal value As Int32)
            _totalAttendance = CInt(value)
        End Set
    End Property

    Private _insId As Int64
    Public Property InsId() As Int64
        Get
            Return _insId
        End Get
        Set(ByVal value As Int64)
            _insId = CInt(value)
        End Set
    End Property
    Private _brnId As Int64
    Public Property BrnId() As Int64
        Get
            Return _brnId
        End Get
        Set(ByVal value As Int64)
            _brnId = CInt(value)
        End Set
    End Property
    Private _DeptId As Integer
    Public Property DeptId() As String
        Get
            Return _DeptId
        End Get
        Set(ByVal value As String)
            _DeptId = CInt(value)
        End Set
    End Property
    Private _Category As Int64
    Public Property Category() As Int16
        Get
            Return _Category
        End Get
        Set(ByVal value As Int16)
            _Category = CInt(value)
        End Set
    End Property
    Private _StartDate As Date
    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property
    Private _EndDate As Date
    Public Property EndDate() As Date
        Get
            Return _EndDate
        End Get
        Set(ByVal value As Date)
            _EndDate = value
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
    Private _id As Integer
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = CInt(value)
        End Set
    End Property
    Private _Course_ID As Int64
    Public Property Course_ID() As Int64
        Get
            Return _Course_ID
        End Get
        Set(ByVal value As Int64)
            _Course_ID = CInt(value)
        End Set
    End Property
    Private _CourseName As String
    Public Property CourseName() As String
        Get
            Return _CourseName
        End Get
        Set(ByVal value As String)
            _CourseName = value
        End Set
    End Property
    Private _subjectid As Int32
    Public Property SubjectId() As String
        Get
            Return _subjectid
        End Get
        Set(ByVal value As String)
            _subjectid = CInt(value)
        End Set
    End Property

    Private _month As String
    Public Property Month() As String
        Get
            Return _month
        End Get
        Set(ByVal value As String)
            _month = value
        End Set
    End Property
    Private _year As Integer
    Public Property Year() As Integer
        Get
            Return _year
        End Get
        Set(ByVal value As Integer)
            _year = CInt(value)
        End Set
    End Property
    Private _time As Date
    Public Property time() As Date
        Get
            Return _time
        End Get
        Set(ByVal value As Date)
            _time = value
        End Set
    End Property
    Private _Batch As Int64
    Public Property Batch() As Int64
        Get
            Return _Batch
        End Get
        Set(ByVal value As Int64)
            _Batch = value
        End Set
    End Property
    Private _Cate As Int32
    Public Property Cate() As Int32
        Get
            Return _Cate
        End Get
        Set(ByVal value As Int32)
            _Cate = value
        End Set
    End Property
    Private _AttendanceID As Int64
    Public Property AttendanceID() As Int64
        Get
            Return _AttendanceID
        End Get
        Set(ByVal value As Int64)
            _AttendanceID = CInt(value)
        End Set
    End Property
    Private _Semsterd As Int64
    Public Property SemsterId() As Int64
        Get
            Return _Semsterd
        End Get
        Set(ByVal value As Int64)
            _Semsterd = value
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
    Public Sub New(ByVal StdId As Int64, ByVal TotalClass As Int32, ByVal TotalAttendance As Int32, ByVal InsId As Int64, ByVal BrnId As Int64, ByVal Courseid As Int64, ByVal SubjectId As Int64, ByVal Month As Int32, ByVal Year As Int32, ByVal Batch As Int64, ByVal Original_AttendanceID As Int64)
        Me.StdId = StdId
        Me.Totalclass = TotalClass
        Me.TotalAttendance = TotalAttendance
        Me.InsId = InsId
        Me.BrnId = BrnId
        Me.Course_ID = Course_ID
        Me.SubjectId = SubjectId
        Me.Month = Month
        Me.Year = Year
        Me.Batch = Batch
        Me.AttendanceID = Original_AttendanceID
    End Sub
    Public Sub New()

    End Sub
   
End Class