Imports Microsoft.VisualBasic

Public Class BLNew_stdMarks
    Dim dl As New DLNew_StudentMarks
    Public Function GetAcademicCombo() As DataTable
        Return DLNew_StudentMarks.GetAcademicCombo()
    End Function
    Public Function GetAcademicCombo1() As DataTable
        Return DLNew_StudentMarks.GetAcademicComboAll()
    End Function
    Public Function GetAcademicCombo(ByVal Branchcode As String) As DataTable
        Return DLNew_StudentMarks.GetAcademicCombo(Branchcode)
    End Function
    Public Function GetBatchCombo(ByVal A_Year As Integer) As DataTable
        'MsgBox("reached get batch combo")
        Return DLNew_StudentMarks.GetBatchCombo(A_Year)
    End Function
    Public Function GetBatchCombo(ByVal A_Year As Integer, ByVal Course As Integer) As DataTable
        'MsgBox("reached get batch combo")
        Return DLNew_StudentMarks.GetBatchCombo(A_Year, Course)
    End Function
    Public Function GetBatchCombo2() As DataTable
        'MsgBox("reached get batch combo")
        Return DLNew_StudentMarks.GetBatchCombo2()
    End Function

    Public Function GetSemesterCombo() As DataTable
        Return DLNew_StudentMarks.GetSemesterCombo()
    End Function
    Public Function GetSubjectCombo(ByVal BatchId As Integer, ByVal SemesterId As Integer) As DataTable
        Return DLNew_StudentMarks.GetSubjectCombo(BatchId, SemesterId)
    End Function
    Public Function GetSubjectComboBatchPlanner(ByVal BatchId As Integer, ByVal SemesterId As Integer) As DataTable
        Return DLNew_StudentMarks.GetSubjectComboBatchPlanner(BatchId, SemesterId)
    End Function
    Public Function GetAssesmentCombo() As DataTable
        Return DLNew_StudentMarks.GetAssesmentCombo()
    End Function
    Public Function GetClassCombo() As DataTable
        Return DLNew_StudentMarks.GetClassCombo()
    End Function
    Public Function InsertStdMarks(ByVal m As NewStdMarks) As Integer
        Return DLNew_StudentMarks.InsertStdMarks(m)
    End Function
    Public Function ViewStdMarks(ByVal m As NewStdMarks) As Data.DataTable
        Return DLNew_StudentMarks.ViewStdMarks(m)
    End Function
    Public Function GetBatch(ByVal m As NewStdMarks) As Data.DataTable
        Return dl.GetBatch(m)
    End Function
    Public Function LockStdMarks(ByVal m As NewStdMarks) As Integer
        Return DLNew_StudentMarks.LockStdMarks(m)
    End Function
    Public Function UNLockStdMarks(ByVal m As NewStdMarks) As Integer
        Return DLNew_StudentMarks.UNLockStdMarks(m)
    End Function
    Public Function ClearMarks(ByVal m As NewStdMarks) As Integer
        Return DLNew_StudentMarks.ClearMarks(m)
    End Function
    Public Function UpdateMarks(ByVal m As NewStdMarks) As Integer
        Return DLNew_StudentMarks.UpdateMarks(m)
    End Function
    Public Function UpdateMarksFromGrade(ByVal m As NewStdMarks) As Integer
        Return DLNew_StudentMarks.UpdateMarksFromGrade(m)
    End Function
    Public Function CheckLockMarks(ByVal m As NewStdMarks) As DataSet
        Return DLNew_StudentMarks.CheckLockMarks(m)
    End Function
    Public Function GetBatchComboB(ByVal A_Year As Integer) As DataTable
        'MsgBox("reached get batch combo")
        Return DLNew_StudentMarks.GetBatchComboB(A_Year)
    End Function
    Public Function GetAcademicComboGvsSub(ByVal Branchcode As String) As DataTable
        Return DLNew_StudentMarks.GetAcademicComboGvsSub(Branchcode)
    End Function
End Class
