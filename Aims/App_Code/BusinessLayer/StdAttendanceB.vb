Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
Namespace Attendance
    Public Class StdAttendanceB
        'Public Function GetDept() As Data.DataTable
        '    Dim DLL As New GlobalDataSetTableAdapters.DeptMasterTableAdapter
        '    Return DLL.GetData
        'End Function
        'Public Function getChecking(ByVal DeptId As Int64, ByVal Empid As Int64, ByVal Date1 As Date) As Data.DataTable
        '    Dim DAL As New GlobalDataSetTableAdapters.EmployeeAttendanceTableAdapter
        '    Return DAL.GetDataByCheckingLogin(Date1, DeptId, Empid)
        'End Function

        Public Function GetCheckingstd(ByVal Prop As StdAttendanceP) As Boolean
            Dim Dal As New StudentAttendance
            Return Dal.GetDataByChecking(Prop.Courseid, Prop.Batch, Prop.SubjectId, Prop.AttendanceDate, Prop.Assessment_ID)
        End Function

        Public Function GetStdAttdDetails(ByVal insid As Int64, ByVal Brnid As Int64, ByVal CrsId As Int64, ByVal batchno As Int64, ByVal monthId As Int32, ByVal SubjectId As Int32, ByVal yeari As Int32, ByVal stdCode As String, ByVal SemsterId As Int64, ByVal attDate As DateTime, ByVal Assessment_ID As Int32, ByVal SemesterWise As Boolean) As System.Data.DataTable
            Dim dt As New Data.DataTable
            If insid > 0 And Brnid > 0 And CrsId > 0 And batchno <> Nothing Then
                Dim DLL As New StudentAttendance
                If stdCode <> "" Then
                    If SemesterWise = True Then
                        dt = DLL.GetDataByStdCode(batchno, stdCode, SemsterId)
                    Else
                        dt = DLL.GetDataByStdCodeDate(batchno, stdCode, monthId, yeari, SemsterId, SubjectId, attDate, Assessment_ID)
                    End If
                Else
                    If SemesterWise = True Then
                        dt = DLL.GetDataByStdCode(batchno, stdCode, SemsterId)
                    Else
                        dt = DLL.GetDataByCourseDate(batchno, SubjectId, monthId, yeari, SemsterId, attDate, Assessment_ID)
                    End If
                End If
            End If
            Return dt
        End Function
        Public Function GetByGVStdAttd(ByVal Prop As StdAttendanceP) As System.Data.DataTable
            Dim DLL As New StudentAttendance
            Return DLL.GvStdAttendance(Prop)
        End Function
        Public Function GetByDeleteStd(ByVal Prop As StdAttendanceP) As Int16
            Dim DLL As New StudentAttendance
            Return DLL.DeletebyStdAttd(Prop.AttendanceID)
        End Function

        Public Function BatchComboStdAttd(ByVal Batchid As Long, ByVal AttdDate As DateTime) As Batch
            Dim batch As New Batch
            Dim ds As DataSet = StudentAttendance.BatchComboStdAtt(Batchid, AttdDate)
            Try
                Dim row As DataRow = ds.Tables(0).Rows(0)
                batch = New Batch(row("Batchid"), row("SessionCnt"), row("Dailycnt"))
            Catch e As Exception
            Finally
            End Try
            Return batch
        End Function
        Public Function GetByUpdateStdAttd(ByVal StdId As Int64, ByVal InsId As Int64, ByVal BrnId As Int64, ByVal Courseid As Int64, ByVal SubjectId As Int64, ByVal Month As Int32, ByVal Year As Int32, ByVal Batch As Int64, ByVal SemsterId As Int64, ByVal AttendanceDate As DateTime, ByVal Assessment_ID As Int32, ByVal Original_AttendanceID As Int64, ByVal TotalAttendance As Boolean) As String
            'Public Function GetByUpdateStdAttd(ByVal AttendanceID As Int64, ByVal TotalAttendance As Boolean) As String
            Dim DLL As New StudentAttendance
            Dim i As String = DLL.UpdateStdAttd(StdId, InsId, BrnId, Courseid, SubjectId, Month, Year, Batch, AttendanceDate, Original_AttendanceID, SemsterId, TotalAttendance, Assessment_ID)
            'Dim i As String = DLL.UpdateStdAttd(AttendanceID, TotalAttendance)
            Return i
        End Function
        Private _attendanceAdapter As AttendanceTableAdapter = Nothing
        Public ReadOnly Property Adapter() As AttendanceTableAdapter
            Get
                If _attendanceAdapter Is Nothing Then
                    _attendanceAdapter = New AttendanceTableAdapter
                End If
                Return _attendanceAdapter
            End Get
        End Property
        'Public Function UpdateWithTransaction(ByVal Attendanc As GlobalDataSet.AttendanceDataTable) As Integer
        '    'Return Adapter.UpdateWithTransaction(Attendanc)
        'End Function

        Public Function fillCourseBatch(ByVal StdId As Int32) As DataTable
            Dim DLL As New StudentAttendance
            Return DLL.fillCourseBatch(StdId)
        End Function
    End Class
End Namespace
