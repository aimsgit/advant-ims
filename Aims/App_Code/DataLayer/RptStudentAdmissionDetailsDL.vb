Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.IO

Public Class RptStudentAdmissionDetailsDL
    Dim dt As New DataTable
    Dim query As String
    Dim ds As New DataSet
    Shared Function GetAcademicYear() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_AcademicYearComboforSDR]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function GetCourse() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CourseComboforSDR]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function GetBatch(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            'Parms(2) = New SqlParameter("@AYear", SqlDbType.VarChar, 30)
            'Parms(2).Value = AYear

            Parms(2) = New SqlParameter("@Courseid", SqlDbType.VarChar, 30)
            Parms(2).Value = Courseid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_BatchComboforSDRNew]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function GetStudent(ByVal batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = batch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_StudentComboforSDR]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetStudentAdmission(ByVal CourseID As Integer, ByVal BatchID As Integer, ByVal StudentID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            'Parms(2) = New SqlParameter("@AYID", SqlDbType.Int)
            'Parms(2).Value = AYID

            Parms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
            Parms(2).Value = CourseID

            Parms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
            Parms(3).Value = BatchID

            Parms(4) = New SqlParameter("@StudentID", SqlDbType.Int)
            Parms(4).Value = StudentID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_StudentIndividualReport]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetStudentAdmissiondetails(ByVal CourseID As Integer, ByVal BatchID As Integer, ByVal StudentID As Integer) As DataTable
        Dim dt As DataTable
        dt = RptStudentAdmissionDetailsDL.GetStudentAdmission(CourseID, BatchID, StudentID)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("Std_Photo").ToString <> "" Then
                Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Std_Photo").ToString)
                If File.Exists(s) Then
                    LoadImage(dt.Rows(i), "image_stream", s)
                Else
                    LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
                End If
            Else
                LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
            End If
            i = i - 1
        End While
        Return dt
    End Function
    Shared Sub LoadImage(ByVal objDataRow As DataRow, ByVal strImageField As String, ByVal FilePath As String)
        Try
            Dim fs As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Dim Image(fs.Length) As Byte
            fs.Read(Image, 0, CInt(fs.Length))
            fs.Close()
            objDataRow(strImageField) = Image
        Catch ex As Exception
            'Response.Write("<font color=red>" + ex.Message + "</font>")
        End Try
    End Sub
End Class
