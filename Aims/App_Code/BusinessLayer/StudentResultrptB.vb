Imports Microsoft.VisualBasic
Imports Student_ResultrptD
Imports Student_ResultrptP


Public Class StudentResultrptdb
    Dim Bl As New StudentResultdb
    Public Function student_resultB(ByVal SR As RPT_StudentResult) As Data.DataSet
        Dim DstudentResult As New StudentResultdb
        Dim ds As New Data.DataSet
        ds = DstudentResult.getdata_ID(SR)
        Return ds
    End Function
    Public Function GetDataByrptStdResult(ByVal Branch As String, ByVal CourseId As Integer, ByVal Subjectid As Integer, ByVal SemesterId As Integer, ByVal BatchNo As Integer, ByVal AssessmentId As Integer, ByVal ClassType As Integer, ByVal SortBy As Integer) As Data.DataTable
        'Dim dt As New Data.DataTable
        Return Bl.GetDataByrptStdResult(Branch, CourseId, Subjectid, SemesterId, BatchNo, AssessmentId, ClassType, SortBy)
        'Return dt
    End Function
End Class
