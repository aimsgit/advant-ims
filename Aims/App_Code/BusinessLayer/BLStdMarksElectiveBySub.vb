Imports Microsoft.VisualBasic

Public Class BLStdMarksElectiveBySub
    Dim a As New DLStdMarksElectiveBySub
    Public Function InsertStdMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Return DLStdMarksElectiveBySub.InsertStdMarks(m)
    End Function
    Public Function ViewStdMarks(ByVal m As ELNewStdMarksBySub) As Data.DataTable
        Return DLStdMarksElectiveBySub.ViewStdMarks(m)
    End Function
    Public Function LockStdMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Return DLStdMarksElectiveBySub.LockStdMarks(m)
    End Function
    Public Function ChangeFlag(ByVal El As ELNewStdMarksBySub) As Integer
        Return DLStdMarksElectiveBySub.ChangeFlag(El)
    End Function
    Public Function UNLockStdMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Return DLStdMarksElectiveBySub.UNLockStdMarks(m)
    End Function
    Public Function ClearMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Return DLStdMarksElectiveBySub.ClearMarks(m)
    End Function
    Public Function UpdateMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Return DLStdMarksElectiveBySub.UpdateMarks(m)
    End Function
    Public Function UpdateMarksFromGrade(ByVal m As ELNewStdMarksBySub) As Integer
        Return DLStdMarksElectiveBySub.UpdateMarksFromGrade(m)
    End Function
    Public Function CheckLockMarks(ByVal m As ELNewStdMarksBySub) As DataSet
        Return DLStdMarksElectiveBySub.CheckLockMarks(m)
    End Function
    Public Function GetSubjectComboBatchPlanner(ByVal BatchId As Integer, ByVal SemesterId As Integer) As DataTable
        Return DLNew_StudentMarks.GetSubjectComboBatchPlanner(BatchId, SemesterId)
    End Function
    Public Function BatchAccess(ByVal El As ELNewStdMarksBySub) As Data.DataTable
        Return a.BatchAccess(El)
    End Function
    Public Function SemAccess(ByVal El As ELNewStdMarksBySub) As Data.DataTable
        Return a.SemAccess(El)
    End Function
End Class
