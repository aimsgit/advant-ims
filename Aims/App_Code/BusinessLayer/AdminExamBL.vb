Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class AdminExamBL
    Public Function InsertAdminExamEL(ByVal Exam As AdminExamEL) As String
        Return AdminExamDL.InsertAdminExamEL(Exam)
    End Function
    Public Function DisplayGridview(ByVal Exam As AdminExamEL) As Data.DataTable
        Return AdminExamDL.DisplayGridview(Exam)
    End Function
    Public Function DeleteAdminExam(ByVal Exam As AdminExamEL) As String
        Return AdminExamDL.DeleteAdminExamEL(Exam)
    End Function
    Public Function UpdateAdminExamEL(ByVal Exam As AdminExamEL) As String
        Return AdminExamDL.UpdateAdminExamEL(Exam)
    End Function
End Class
