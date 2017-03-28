Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.IO


Public Class RptStudentAdmissionDetailsBL
    Public Function GetAcademicYear() As DataTable
        Return RptStudentAdmissionDetailsDL.GetAcademicYear()
    End Function
    Public Function GetCourse() As DataTable
        Return RptStudentAdmissionDetailsDL.GetCourse()
    End Function
    Public Function GetBatch(ByVal Courseid As Integer) As DataTable
        Return RptStudentAdmissionDetailsDL.GetBatch(Courseid)
    End Function
    Public Function GetStudent(ByVal BatchID As Integer) As DataTable
        Return RptStudentAdmissionDetailsDL.GetStudent(BatchID)
    End Function

    'Public Function GetStudentImage(ByVal UID As String) As DataTable
    '    Dim dt As DataTable
    '    dt = selfdetailsDB.RPT_GetDeatilsByBranch(UID).Tables(0)
    '    For i As Int16 = 0 To i < dt.Rows.Count - 1
    '        If dt.Rows(i)("Logo").ToString <> "" Then
    '            Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Logo").ToString)
    '            If File.Exists(s) Then
    '                LoadImage(dt.Rows(i), "image_stream", s)
    '            Else
    '                LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
    '            End If
    '        Else
    '            LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
    '        End If
    '    Next
    '    Return dt
    'End Function
    'Protected Sub LoadImage(ByVal objDataRow As DataRow, ByVal strImageField As String, ByVal FilePath As String)
    '    Try
    '        Dim fs As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
    '        Dim Image(fs.Length) As Byte
    '        fs.Read(Image, 0, CInt(fs.Length))
    '        fs.Close()
    '        objDataRow(strImageField) = Image
    '    Catch ex As Exception
    '        'Response.Write("<font color=red>" + ex.Message + "</font>")
    '    End Try
    'End Sub

End Class
