Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class DLStudentIDCard
    Public Function GetStudentNameCombo(ByVal BatchID As Integer, ByVal Courseid As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(3) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = BatchID
        param(3) = New SqlParameter("@Course", SqlDbType.Int)
        param(3).Value = Courseid
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetddlStd", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBatchCombo(ByVal Courseid As Integer) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@Course", SqlDbType.Int)
        Para(2).Value = Courseid

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_ddlgetBatch", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetCourseCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(1) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetddlCourse", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetStudentDetail(ByVal Batch As Integer, ByVal Course As Integer, ByVal Student As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(0).Value = Batch
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(2).Value = Course
        arParms(3) = New SqlParameter("@Student", SqlDbType.Int)
        arParms(3).Value = Student
        
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RPT_StudentIDCard", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function RPT_GetStudentID(ByVal Batch As Integer, ByVal Course As Integer, ByVal Student As Integer) As DataTable
        Dim dt As DataTable
        dt = DLStudentIDCard.GetStudentDetail(Batch, Course, Student)
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
    Shared Function EmployeeIDCard(ByVal branch As String, ByVal Ecode As String, ByVal DeptID As Integer) As DataTable
        Dim dt As DataTable
        dt = DLStudentIDCard.GetEmployeeID(branch, Ecode, DeptID)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("Photos").ToString <> "" Then
                Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Photos").ToString)
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
    Shared Function GetEmployeeID(ByVal branch As String, ByVal Ecode As String, ByVal DeptID As Integer) As DataTable
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = branch
        arParms(2) = New SqlParameter("@Ecode", SqlDbType.VarChar, 50)
        arParms(2).Value = Ecode
        arParms(3) = New SqlParameter("@DeptID", SqlDbType.VarChar, 50)
        arParms(3).Value = DeptID

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "RptEmployeeIDCard", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
