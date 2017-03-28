Imports Microsoft.VisualBasic
Imports Attendance

Public Class StdAttendancewitclasstype
    Dim a As New StdAttendancewitclasstypeDL
    Public Function InsertAttandanceCT(ByVal El As StdAttendanceP) As Integer
        Return a.InsertAttandanceCT(El)
    End Function
    Public Function GetBatch(ByVal El As StdAttendanceP) As Data.DataTable
        Return a.GetBatch(El)
    End Function
    Public Function AttendanceduplicateCT(ByVal El As StdAttendanceP) As Data.DataTable
        Return a.AttendanceduplicateCT(El)
    End Function
  
    Public Function GetByGVStdAttdCT(ByVal El As StdAttendanceP) As Data.DataTable
        Return a.GetByGVStdAttdCT(El)
    End Function

    Public Function UpdateRecordCT(ByVal El As StdAttendanceP) As Integer
        Return a.UpdateRecord(El)
    End Function
    Public Function ChangeFlagCT(ByVal El As StdAttendanceP) As Integer
        Return stdAttndance.ChangeFlag(El)
    End Function
    Public Function UpdateCollectionVerificationCT(ByVal El As StdAttendanceP) As Integer
        Return a.UpdateCollectionVerificationCT(El)
    End Function
    Public Function LockAttendanceCT(ByVal El As String) As Integer
        Return a.LockAttendance(El)
    End Function
    Public Function CheckLockAttendanceCT(ByVal El As String) As String
        Return a.CheckLockAttendance(El)
    End Function
    Public Function SendMessageCT(ByVal El As String, ByVal service As String) As Data.DataTable
        Return a.SendMessage(El, service)
    End Function
    Public Function UnLockAttendanceCT(ByVal El As String) As Integer
        Return a.UnLockAttendance(El)
    End Function
    Public Function ClearAttendanceCT(ByVal El As String) As Integer
        Return a.ClearAttendance(El)
    End Function
End Class


