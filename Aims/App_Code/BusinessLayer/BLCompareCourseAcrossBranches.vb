Imports Microsoft.VisualBasic

Public Class BLCompareCourseAcrossBranches
    Dim DLCompareCourseAcrossBranches As DLCompareCourseAcrossBranches
    Public Function GetAcademicYear() As System.Data.DataTable
        Return DLCompareCourseAcrossBranches.GetAcademicYear()
    End Function
    Public Function GetCourse1() As System.Data.DataTable
        Return DLCompareCourseAcrossBranches.GetCourse1()
    End Function
    Public Function GetCourse2() As System.Data.DataTable
        Return DLCompareCourseAcrossBranches.GetCourse2()
    End Function
    Public Function GetCourse3() As System.Data.DataTable
        Return DLCompareCourseAcrossBranches.GetCourse3()
    End Function
    Public Function GetCourse4() As System.Data.DataTable
        Return DLCompareCourseAcrossBranches.GetCourse4()
    End Function
    Public Function GetGenerateView(ByVal CourseCode1 As String, ByVal CourseCode2 As String, ByVal CourseCode3 As String, ByVal CourseCode4 As String) As System.Data.DataTable
        Return DLCompareCourseAcrossBranches.GetGenerateView(CourseCode1, CourseCode2, CourseCode3, CourseCode4)
    End Function
End Class
