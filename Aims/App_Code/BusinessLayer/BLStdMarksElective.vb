Imports Microsoft.VisualBasic

Public Class BLStdMarksElective
    Public Function InsertStdMarks(ByVal m As NewStdMarks) As Integer
        Return DLStdMarksElective.InsertStdMarks(m)
    End Function
    Public Function ViewStdMarks(ByVal m As NewStdMarks) As Data.DataTable
        Return DLStdMarksElective.ViewStdMarks(m)
    End Function
    Public Function LockStdMarks(ByVal m As NewStdMarks) As Integer
        Return DLStdMarksElective.LockStdMarks(m)
    End Function
    Public Function ChangeFlag(ByVal El As NewStdMarks) As Integer
        Return DLStdMarksElective.ChangeFlag(El)
    End Function
    Public Function UNLockStdMarks(ByVal m As NewStdMarks) As Integer
        Return DLStdMarksElective.UNLockStdMarks(m)
    End Function
    Public Function ClearMarks(ByVal m As NewStdMarks) As Integer
        Return DLStdMarksElective.ClearMarks(m)
    End Function
    Public Function UpdateMarks(ByVal m As NewStdMarks) As Integer
        Return DLStdMarksElective.UpdateMarks(m)
    End Function
    Public Function UpdateGradePoint(ByVal m As NewStdMarks) As Integer
        Return DLStdMarksElective.UpdateGradePoint(m)
    End Function
    Public Function UpdateMarksFromGrade(ByVal m As NewStdMarks) As Integer
        Return DLStdMarksElective.UpdateMarksFromGrade(m)
    End Function
    Public Function CheckLockMarks(ByVal m As NewStdMarks) As DataSet
        Return DLStdMarksElective.CheckLockMarks(m)
    End Function
    Public Function GetSubjectComboBatchPlanner(ByVal BatchId As Integer, ByVal SemesterId As Integer) As DataTable
        Return DLNew_StudentMarks.GetSubjectComboBatchPlanner(BatchId, SemesterId)
    End Function
End Class
