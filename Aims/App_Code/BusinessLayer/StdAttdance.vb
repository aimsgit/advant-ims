Imports Microsoft.VisualBasic
Imports Attendance

Public Class StdAttdance
    Dim a As New stdAttndance
    Public Function InsertAttandance(ByVal El As StdAttendanceP) As Integer
        Return a.InsertAttandance(El)
    End Function
    Public Function InsertAttandanceNoSubject(ByVal El As StdAttendanceP) As Integer
        Return a.InsertAttandanceNosubject(El)
    End Function
    Public Function InsertAttandance1(ByVal El As StdAttendanceP) As Integer
        Return a.InsertAttandance1(El)
    End Function
    Public Function Attendanceduplicate(ByVal El As StdAttendanceP) As Data.DataTable
        Return a.Attendanceduplicate(El)
    End Function
    Public Function GetBatch(ByVal El As StdAttendanceP) As Data.DataTable
        Return a.GetBatch(El)
    End Function
    Public Function GetBatchNosubject(ByVal El As StdAttendanceP) As Data.DataTable
        Return a.GetBatchNosubject(El)
    End Function
    Public Function Attendanceduplicate1(ByVal El As StdAttendanceP) As Data.DataTable
        Return a.Attendanceduplicate1(El)
    End Function
    Public Function GetStudentReportWitElecSub(ByVal BranchCode As String, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Min As Integer, ByVal Max As Integer, ByVal SortBy As Integer, ByVal Category As Integer) As Data.DataTable
        Return a.GetStudentReportWitElecSub(BranchCode, Bat, Sem, Subj, StdId, fromdate, todate, Min, Max, SortBy, Category)
    End Function
    Public Function GetByGVStdAttd(ByVal El As StdAttendanceP) As Data.DataTable
        Return a.GetByGVStdAttd(El)
    End Function
   
    Public Function UpdateRecord(ByVal El As StdAttendanceP) As Integer
        Return a.UpdateRecord(El)
    End Function
    Public Function ChangeFlag(ByVal El As StdAttendanceP) As Integer
        Return stdAttndance.ChangeFlag(El)
    End Function
    Public Function UpdateCollectionVerification(ByVal El As StdAttendanceP) As Integer
        Return a.UpdateCollectionVerification(El)
    End Function
    Public Function LockAttendance(ByVal El As String) As Integer
        Return a.LockAttendance(El)
    End Function
    Public Function CheckLockAttendance(ByVal El As String) As String
        Return a.CheckLockAttendance(El)
    End Function
    Public Function SendMessage(ByVal El As String, ByVal service As String) As Data.DataTable
        Return a.SendMessage(El, service)
    End Function
    Public Function UnLockAttendance(ByVal El As String) As Integer
        Return a.UnLockAttendance(El)
    End Function
    Public Function ClearAttendance(ByVal El As String) As Integer
        Return a.ClearAttendance(El)
    End Function
    Public Function GetStudentElecSubReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal ES As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Min As Integer, ByVal Max As Integer, ByVal SortBy As Integer, ByVal category As Integer) As Data.DataTable
        Return a.GetStudentReport(Bat, Sem, Subj, ES, StdId, fromdate, todate, Min, Max, SortBy, category)
    End Function
    Public Function GetSemAssessmtRpt(ByVal Crs As Integer, ByVal Bat As String, ByVal Sem As Integer, ByVal Subj As Integer, ByVal StdId As Integer, ByVal SortBy As Integer, ByVal AsstId As Integer, ByVal EmpStudLog As Integer) As Data.DataTable
        Return a.GetSemAssessmtRpt(Crs, Bat, Sem, Subj, StdId, SortBy, AsstId, EmpStudLog)
    End Function
End Class
