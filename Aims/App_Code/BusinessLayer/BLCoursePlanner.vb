Imports Microsoft.VisualBasic

Public Class BLCoursePlanner
    Dim d1 As New DLCoursePlanner
    Public Function GetCoursePlannerReport(ByVal CRS As String) As Data.DataTable

        Return d1.GetCoursePlannerReportt(CRS)
    End Function
End Class
