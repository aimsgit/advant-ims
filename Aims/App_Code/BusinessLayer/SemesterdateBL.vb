Imports Microsoft.VisualBasic

Public Class SemesterdateBL
    Public Function InsertRecord(ByVal EL As Semester) As Integer
        Return SemesterdateDL.Insert(EL)
    End Function
    Public Function UpdateSemdate(ByVal EL As Semester) As Integer
        Return SemesterdateDL.Update(EL)
    End Function
    Public Function DispGrid(ByVal id As Integer, ByVal Course As Integer) As Data.DataTable
        Return SemesterdateDL.DispDB(id, Course)
    End Function
    Public Function GetDuplicateSemesterDuration(ByVal EL As Semester) As Data.DataTable
        Return SemesterdateDL.GetDuplicateSemesterDuration(EL)
    End Function
    Public Function DelSemdate(ByVal EL As Semester) As Integer
        Return SemesterdateDL.DeleteSemDB(EL)
    End Function
    Public Function CourseCombo() As DataTable
        Return SemesterdateDL.courseCombo()
    End Function

End Class
