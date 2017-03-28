Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.IO
Public Class StudentIndHostelAdmissionDetailsDL
    Shared Function insertBranchCombo_Adminition() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranchComboAll_RptStl1", arParms)
        Return ds.Tables(0)
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CourseComboforSDR1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetBatch(ByVal Courseid As Integer, ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode


            Parms(1) = New SqlParameter("@Courseid", SqlDbType.VarChar, 50)
            Parms(1).Value = Courseid




            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchddl1", Parms)
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_StudentComboforSDR1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GenerateStdHostelAddmisionR(ByVal BranchCode As String, ByVal Course As Integer, ByVal BatchId As Integer, ByVal StudentId As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim Params() As SqlParameter = New SqlParameter(3) {}

        Params(0) = New SqlParameter("@Course", Data.SqlDbType.Int)
        Params(0).Value = Course

        Params(1) = New SqlParameter("@BatchId", Data.SqlDbType.Int)
        Params(1).Value = BatchId

        Params(2) = New SqlParameter("@StudentId", Data.SqlDbType.Int)
        Params(2).Value = StudentId

        Params(3) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(3).Value = BranchCode

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GenerateStdHostelAddDetails", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GenerateStudentHostelAddmissionDetailsReports(ByVal BranchCode As String, ByVal Course As Integer, ByVal BatchId As Integer, ByVal StudentId As Integer) As DataTable
        Dim dt As DataTable
        dt = StudentIndHostelAdmissionDetailsDL.GenerateStdHostelAddmisionR(BranchCode, Course, BatchId, StudentId)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("Std_Photo").ToString <> "" Then
                Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Std_Photo").ToString)
                If File.Exists(s) Then
                    LoadImage(dt.Rows(i), "image_stream", s)
                Else
                    LoadImage(dt.Rows(i), "image_stream", HttpContext.Current.Server.MapPath("~/Images/imageupload.gif"))
                End If
            Else
                LoadImage(dt.Rows(i), "image_stream", HttpContext.Current.Server.MapPath("~/Images/imageupload.gif"))
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
