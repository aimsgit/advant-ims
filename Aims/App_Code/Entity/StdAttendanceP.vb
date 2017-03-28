Imports Microsoft.VisualBasic
Imports System.io
Namespace Attendance
    <Serializable()> Public Class StdAttendanceP
        Private _BranchCode As String
        Public Property BranchCode() As String
            Get
                Return _BranchCode
            End Get
            Set(ByVal value As String)
                _BranchCode = value
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
        Private _userID As Int64
        Public Property UserID() As int64
            Get
                Return _userID
            End Get
            Set(ByVal value As int64)
                _userID = value
            End Set
        End Property
        Private _ElecSub As Integer
        Public Property ElecSub() As Integer
            Get
                Return _ElecSub
            End Get
            Set(ByVal value As Integer)
                _ElecSub = value
            End Set
        End Property
        Private _SubGrp As Integer
        Public Property SubGrp() As Integer
            Get
                Return _SubGrp
            End Get
            Set(ByVal value As Integer)
                _SubGrp = value
            End Set
        End Property
        Private _periodNo As Integer
        Public Property PeriodNo() As Integer
            Get
                Return _periodNo
            End Get
            Set(ByVal value As Integer)
                _periodNo = value
            End Set
        End Property
        Private _del_Flag As String
        Public Property Del_Flag() As String
            Get
                Return _del_Flag
            End Get
            Set(ByVal value As String)
                _del_Flag = value
            End Set
        End Property
        Private _entryDate As Date
        Public Property EntryDate() As Date
            Get
                Return _entryDate
            End Get
            Set(ByVal value As Date)
                _entryDate = value
            End Set
        End Property
        Private _academic As Int64
        Public Property Academic() As Int64
            Get
                Return _academic
            End Get
            Set(ByVal value As Int64)
                _academic = value
            End Set
        End Property
        Private _classtype As String
        Public Property ClassType() As String
            Get
                Return _classtype
            End Get
            Set(ByVal value As String)
                _classtype = value
            End Set
        End Property
        Private _semesterid As String
        Public Property SemesterId() As String
            Get
                Return _semesterid
            End Get
            Set(ByVal value As String)
                _semesterid = value
            End Set
        End Property

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

        Private _sessioncountday As String
        Public Property SessionCountDay() As String
            Get
                Return _sessioncountday
            End Get
            Set(ByVal value As String)
                _sessioncountday = value
            End Set
        End Property
        Private _sessioncountday1 As String
        Public Property SessionCountDay1() As String
            Get
                Return _sessioncountday1
            End Get
            Set(ByVal value As String)
                _sessioncountday1 = value
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
        Private _id As String
        Public Property Id() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = CInt(value)
            End Set
        End Property
        Private _courseid As Int64
        Public Property Courseid() As Int64
            Get
                Return _courseid
            End Get
            Set(ByVal value As Int64)
                _courseid = CInt(value)
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

        Private _present As String
        Public Property Present() As String
            Get
                Return _present
            End Get
            Set(ByVal value As String)
                _present = value
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

        Private _Batch As Int64
        Public Property Batch() As Int64
            Get
                Return _Batch
            End Get
            Set(ByVal value As Int64)
                _Batch = value
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
        Private _attendance As Boolean
        Public Property Attendance() As Boolean
            Get
                Return _attendance
            End Get
            Set(ByVal value As Boolean)
                _attendance = value
            End Set
        End Property
        Private _assessment_id As Int32
        Public Property Assessment_ID() As Int32
            Get
                Return _assessment_id
            End Get
            Set(ByVal value As Int32)
                _assessment_id = value
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
        Private _AttendanceDate As Date
        Public Property AttendanceDate() As Date
            Get
                Return _AttendanceDate
            End Get
            Set(ByVal value As Date)
                _AttendanceDate = value
            End Set
        End Property
        Private _AttendanceDate1 As Date
        Public Property AttendanceDate1() As Date
            Get
                Return _AttendanceDate1
            End Get
            Set(ByVal value As Date)
                _AttendanceDate1 = value
            End Set
        End Property
        Public Sub New(ByVal StdId As Int64, ByVal TotalClass As Int32, ByVal SessionCountDay As Int32, ByVal InsId As Int64, ByVal SemesterId As String, ByVal BrnId As Int64, ByVal Courseid As Int64, ByVal SubjectId As Int64, ByVal Month As Int32, ByVal Year As Int32, ByVal Batch As Int64, ByVal Original_AttendanceID As Int64, ByVal Attendance As Boolean, ByVal Assessment_ID As Int32)
            Me.StdId = StdId
            Me.Totalclass = TotalClass
            Me.SessionCountDay = SessionCountDay
            Me.InsId = InsId
            Me.BrnId = BrnId
            Me.Courseid = Courseid
            Me.SubjectId = SubjectId
            Me.SemesterId = SemesterId
            Me.Month = Month
            Me.Year = Year
            Me.Batch = Batch
            Me.Academic = Academic
            Me.AttendanceID = Original_AttendanceID
            Me.Attendance = Attendance
            Me.Assessment_ID = Assessment_ID
        End Sub
        Public Sub New()

        End Sub
    End Class
End Namespace
