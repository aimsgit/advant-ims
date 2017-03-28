Imports Microsoft.VisualBasic

Public Class BLNewCoursePlanner
    Public Function InsertCoursePlanner(ByVal p As NewCoursePlanner) As Integer
        Return DLNewCoursePlanner.InsertCoursePlanner(p)
    End Function
    Public Function UpdateCoursePlanner(ByVal p As NewCoursePlanner) As Integer
        Return DLNewCoursePlanner.UpdateCoursePlanner(p)
    End Function
    Public Function DeleteCoursePlanner(ByVal p As NewCoursePlanner) As Integer
        Return DLNewCoursePlanner.DeleteCoursePlanner(p)
    End Function
    Public Function DuplicateCoursePlanner(ByVal id As Integer, ByVal c As Integer, ByVal sem As Integer, ByVal subj As Integer) As DataTable
        Return DLNewCoursePlanner.DuplicateCoursePlanner(id, c, sem, subj)
    End Function
    Public Function GetCoursePlanner(ByVal p As Integer, ByVal c As Integer, ByVal s As Integer) As DataTable
        Return DLNewCoursePlanner.GetCoursePlanner(p, c, s)
    End Function
    Public Function GetCourseCombo() As DataTable
        Return DLNewCoursePlanner.GetCourseCombo()
    End Function
    Public Function GetCourseCombo1() As DataTable
        Return DLNewCoursePlanner.GetCourseCombo1()
    End Function
    Public Function GetCourseComboAdmission() As DataTable
        Return DLNewCoursePlanner.GetCourseComboAdmission()
    End Function
    Public Function GetCourseComboAdmission(ByVal Branchcode As String) As DataTable
        Return DLNewCoursePlanner.GetCourseComboAdmission(Branchcode)
    End Function
    Public Function GetSemesterCombo() As DataTable
        Return DLNewCoursePlanner.GetSemesterCombo()
    End Function
    Public Function GetSubjectCombo() As DataTable
        Return DLNewCoursePlanner.GetSubjectCombo()
    End Function
    Public Function GetSubjectComboByPrinci(ByVal PrincipalSubject As Integer, ByVal SubjectCategory As Integer) As DataTable
        Return DLNewCoursePlanner.GetSubjectComboByPrinci(PrincipalSubject, SubjectCategory)
    End Function

    Public Function GetSubjectComboExam() As DataTable
        Return DLNewCoursePlanner.GetSubjectComboExam()
    End Function
    Public Function GetPrincipalSubject() As DataTable
        Return DLNewCoursePlanner.GetPrincipalSubject()
    End Function
    Public Function GetSubjectCategory() As DataTable
        Return DLNewCoursePlanner.GetSubjectCategory()
    End Function
    Public Function GetCourseComboGvsSub(ByVal Branchcode As String) As DataTable
        Return DLNewCoursePlanner.GetCourseComboGvsSub(Branchcode)
    End Function
End Class
