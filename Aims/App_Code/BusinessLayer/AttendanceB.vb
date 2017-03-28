Imports Microsoft.VisualBasic
Public Class AttendanceB
    Dim dal As New AttendanceD
    Public Function GetDept() As Data.DataTable
        Return dal.GetdeptData()
    End Function
    Public Function GetEmployee(ByVal Id As Int64, ByVal date1 As Date, ByVal Cid As Int16, ByVal brnid As Int64, ByVal insid As Int64) As Data.DataTable
        Return dal.GetDataByEmp(Id, date1, date1, Cid, insid, brnid)
    End Function
    Public Function getChecking(ByVal DeptId As Int64, ByVal Empid As String, ByVal Date1 As Date) As Data.DataTable
        Return dal.GetDataByCheckingLogin(Date1, DeptId, Empid)
    End Function
    Public Function EmpAttdInsert(ByVal Prop As AttendanceP) As Int16
        Dim Dal As New AttendanceD.EmpAttendance
        Return Dal.Empinsert(Prop)
    End Function
    Public Function EmpLoggoff(ByVal id As Int64, ByVal Logoff As DateTime, ByVal login As DateTime) As Int16
        Dim logo, logi, log As DateTime
        Dim twh As TimeSpan
        logo = Logoff
        logi = login
        'twh=DateDiff(
        twh = (logo - logi)
        'log = CDate(twh)
        log = DateTime.Today.Date
        log = log.Add(twh)
        'log = CDat(twh.Hours & ":" & twh.Minutes & ":" & twh.Seconds)
        Return dal.UpdateLogOff(Logoff, log, id)
    End Function
    Public Function EmpLoggin(ByVal id As Int64, ByVal Login As DateTime, ByVal logoff As DateTime) As Int16
        Dim logo, logi, log As DateTime
        Dim twh As TimeSpan
        logo = Login
        logi = logoff
        'twh=DateDiff(
        twh = (logo - logi)
        'log = CDate(twh)
        log = DateTime.Today.Date
        log = log.Add(twh)
        'log = CDat(twh.Hours & ":" & twh.Minutes & ":" & twh.Seconds)
        Return dal.UpdateLogin(Login, log, id)
    End Function
    Public Function GetByDeleteEmp(ByVal a As AttendanceP) As Int16
        Return dal.UpdateDel(a)
    End Function
    Public Function GetCheckingstd(ByVal Prop As AttendanceP) As Boolean
        Dim Dal As New AttendanceD.StudentAttendance
        Return Dal.GetDataByChecking(Prop.InsId, Prop.BrnId, Prop.Course_ID, Prop.Batch, Prop.SubjectId, Prop.Month, Prop.Year)
    End Function
    Public Function GetEmployeeDetails(ByVal Attendance_ID As Integer) As System.Data.DataTable
        Dim DLL As New AttendanceD.EmpAttendance
        Return DLL.GetEmpDetails(Attendance_ID)
    End Function
    'Public Function GetEmployeeDetailsRpt(ByVal id As Int16, ByVal SDate As DateTime, ByVal Cate As Int16) As System.Data.DataTable
    '    'Dim DLL As New GlobalDataSetTableAdapters.Qry_EmpAttdTableAdapter
    '    'Return DLL.GetDataByRpt(id, SDate, Cate)
    '    'Return 0
    'End Function
    Public Function GetStdAttdDetails(ByVal insid As Int64, ByVal Brnid As Int64, ByVal CrsId As Int64, ByVal batchno As Int64, ByVal monthId As String, ByVal SubjectId As Int32, ByVal yeari As Int32, ByVal stdCode As String, ByVal SemsterId As Int64) As System.Data.DataTable
        Dim dt As New Data.DataTable
        If insid > 0 And Brnid > 0 And CrsId > 0 And batchno <> Nothing And SubjectId > 0 Then
            Dim DLL As New AttendanceD.StudentAttendance
            If Not monthId <> "" And Not yeari > 0 And stdCode <> "" Then
                dt = DLL.GetDataByStdCode(insid, Brnid, CrsId, batchno, stdCode, SemsterId)
            ElseIf monthId <> "" And yeari > 0 And stdCode <> "" Then
                dt = DLL.GetDataByStdCodeDate(insid, Brnid, CrsId, batchno, stdCode, monthId, yeari, SemsterId)
            ElseIf monthId <> "" And yeari > 0 Then
                dt = DLL.GetDataByCourseDate(insid, Brnid, CrsId, batchno, SubjectId, monthId, yeari, SemsterId)
            End If
        End If
        Return dt
    End Function
    Public Function GetByGVStdAttd(ByVal Prop As AttendanceP) As System.Data.DataTable
        Dim DLL As New AttendanceD.StudentAttendance
        Return DLL.GvStdAttendance(Prop)
    End Function
    Public Function GetByDelete(ByVal prop As AttendanceP) As Int16
        Dim DLL As New AttendanceD.StudentAttendance
        Return DLL.DeletebyEmpAttd(prop.AttendanceID)
    End Function
    Public Function GetByUpdateEmpAttd1(ByVal StdId As Int64, ByVal TotalClass As Int32, ByVal TotalAttendance As Int32, ByVal InsId As Int64, ByVal BrnId As Int64, ByVal Courseid As Int64, ByVal SubjectId As Int64, ByVal Month As Int32, ByVal Year As Int32, ByVal Batch As Int64, ByVal Original_AttendanceID As Int64) As String
        Dim DLL As New AttendanceD.StudentAttendance
        Dim i As String = DLL.UpdateEmpAttd(StdId, TotalClass, TotalAttendance, InsId, BrnId, Courseid, SubjectId, Month, Year, Batch, Original_AttendanceID)
        Return i
    End Function
    'Public Function GetCourse(ByVal CourseId As Long) As Generic.List(Of Course)
    '    Dim co As New Generic.List(Of Course)
    '    Dim ds As DataSet = AttendanceD.GetCourse(CourseId)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        co.Add(New Course(row("Course_ID"), row("CourseName")))
    '    Next
    '    Return co
    'End Function
    'Public Function GetCourseid(ByVal CourseId As Long) As Course
    '    Dim Course As Course
    '    Dim ds As DataSet = AttendanceD.GetCourse(CourseId)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    Course = New Course(row("Course_ID"), row("CourseName"))
    '    Return Course
    'End Function



End Class

