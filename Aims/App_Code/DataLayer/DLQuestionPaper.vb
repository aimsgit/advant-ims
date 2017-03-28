Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.IO
Public Class DLQuestionPaper
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
    Shared Function GetBatch(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@Courseid", SqlDbType.VarChar, 50)
            Parms(0).Value = Courseid


            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchddl1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubject(ByVal Batchid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@Batchid", SqlDbType.Int)
            Parms(0).Value = Batchid


            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getSubjectddl", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    'Shared Function GetQuestionNumber(ByVal Subjectid As Integer) As DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Try
    '        Dim Parms() As SqlParameter = New SqlParameter(2) {}

    '        Parms(0) = New SqlParameter("@Subjectid", SqlDbType.Int)
    '        Parms(0).Value = Subjectid


    '        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '        Parms(1).Value = HttpContext.Current.Session("BranchCode")

    '        Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '        Parms(2).Value = HttpContext.Current.Session("Office")

    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getQuestionNumberddl", Parms)
    '        Return ds.Tables(0)
    '    Catch ex As Exception
    '        Return Nothing
    '        MsgBox(ex.ToString)
    '    End Try
    'End Function
    Public Function CheckDuplicateQuestionPaper(ByVal EL As ELQuestionPaper) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        'Dim para() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(0).Value = EL.course
        arParms(1) = New SqlParameter("@date", SqlDbType.DateTime)
        arParms(1).Value = EL.qdate
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = EL.id
        arParms(3) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(3).Value = EL.subject
        arParms(4) = New SqlParameter("@Question", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.question
        arParms(5) = New SqlParameter("@Section", SqlDbType.NVarChar)
        arParms(5).Value = EL.section
        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        arParms(7) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(7).Value = EL.batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateQuestionPaper", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function InsertQuestionPaper(ByVal EL As ELQuestionPaper) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(10) {}
        Params(0) = New SqlParameter("@Subject", Data.SqlDbType.Int)
        Params(0).Value = EL.subject
        Params(1) = New SqlParameter("@date", Data.SqlDbType.DateTime)
        Params(1).Value = EL.qdate
        Params(2) = New SqlParameter("@Course", Data.SqlDbType.Int)
        Params(2).Value = EL.course
        Params(3) = New SqlParameter("@Batch", Data.SqlDbType.Int)
        Params(3).Value = EL.batch
        Params(4) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(4).Value = EL.id
        Params(5) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(5).Value = HttpContext.Current.Session("BranchCode")
        Params(6) = New SqlParameter("@EmpCode", Data.SqlDbType.VarChar)
        Params(6).Value = HttpContext.Current.Session("EmpCode")
        Params(7) = New SqlParameter("@UserCode", Data.SqlDbType.VarChar)
        Params(7).Value = HttpContext.Current.Session("UserCode")
        Params(8) = New SqlParameter("@Office", Data.SqlDbType.VarChar)
        Params(8).Value = HttpContext.Current.Session("Office")
        Params(9) = New SqlParameter("@Question", Data.SqlDbType.VarChar, 50)
        Params(9).Value = EL.question
        Params(10) = New SqlParameter("@Section", Data.SqlDbType.NVarChar)
        Params(10).Value = EL.section
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_InsertQuestionPaper", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function QuestionPaperGridView(ByVal EL As ELQuestionPaper) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}
            Parms(0) = New SqlParameter("@ID", SqlDbType.Int)
            Parms(0).Value = EL.id

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_QuestionPaperGridView", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteQuestionPaper(ByVal EL As ELQuestionPaper) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(1) {}
        Params(0) = New SqlParameter("@ID", Data.SqlDbType.Int)
        Params(0).Value = EL.id

        Params(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        Params(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_DeleteQuestionPaper", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function GetQuestion(ByVal EL As ELQuestionPaper) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(4) {}

        para(0) = New SqlParameter("@Course", Data.SqlDbType.Int)
        para(0).Value = EL.course
       
        para(1) = New SqlParameter("@Subject", Data.SqlDbType.Int)
        para(1).Value = EL.subject

        para(2) = New SqlParameter("@QuesType", Data.SqlDbType.VarChar)
        para(2).Value = EL.Ques_type

        para(3) = New SqlParameter("@Branchcode", SqlDbType.VarChar)
        para(3).Value = HttpContext.Current.Session("BranchCode")

        para(4) = New SqlParameter("@Office", SqlDbType.VarChar)
        para(4).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_SelectQuestion", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateQuestionPaperMarks(ByVal EL As ELQuestionPaper) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(1) {}
        Params(0) = New SqlParameter("@ID", Data.SqlDbType.Int)
        Params(0).Value = EL.id
        Params(1) = New SqlParameter("@Marks", Data.SqlDbType.Float)
        Params(1).Value = EL.marks
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_UpdateQuestionMarks", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function RptQnPaper(ByVal Crs As Integer, ByVal Batchid As Integer, ByVal Sem As Integer, ByVal Subj As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(1).Value = Batchid

            Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(2).Value = Sem

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = Subj

            Parms(4) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(4).Value = Crs


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_QuestionPaper]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function RptQnPaperDetails(ByVal Crs As Integer, ByVal Batchid As Integer, ByVal Sem As Integer, ByVal Subj As Integer) As DataTable
        Dim dt As DataTable
        dt = DLQuestionPaper.RptQnPaper(Crs, Batchid, Sem, Subj)
        If dt.Rows.Count > 0 Then
            Dim i As Integer = dt.Rows.Count - 1
            While (i >= 0)
                If dt.Rows(i)("Diagram").ToString <> "" Then
                    Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Diagram").ToString)
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
        End If
       
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
