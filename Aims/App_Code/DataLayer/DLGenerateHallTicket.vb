Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class DLGenerateHallTicket
    Shared Function GridViewGenerateHallTicket(ByVal ExamBatchId As Integer, ByVal StdCenter As String, ByVal StdCode As String, ByVal StdName As String, ByVal SortBy As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
            Parms(1).Value = StdCenter

            Parms(2) = New SqlParameter("@StdCode", SqlDbType.VarChar)
            Parms(2).Value = StdCode

            Parms(3) = New SqlParameter("@StdName", SqlDbType.VarChar)
            Parms(3).Value = StdName

            Parms(4) = New SqlParameter("@SortBy", SqlDbType.Int)
            Parms(4).Value = SortBy

            Parms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(5).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GridViewGenerateHallTicket", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ClearGenerateHallTicketNo(ByVal ExamBatchId As Integer, ByVal StdCenter As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
        arParms(1).Value = StdCenter

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ClearGenerateHallTicketNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ViewHallTicket(ByVal ExamBatchId As Integer, ByVal StdCenter As String, ByVal SortBy As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
            Parms(1).Value = StdCenter

            Parms(2) = New SqlParameter("@SortBy", SqlDbType.Int)
            Parms(2).Value = SortBy

            Parms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(3).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ViewHallTicketNo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function UpdateHallTicketNo(ByVal ExamBatchId As Integer, ByVal StdCenter As String, ByVal HallTicketNo As String, ByVal Prefix As String, ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
        arParms(1).Value = StdCenter

        arParms(2) = New SqlParameter("@HallTicketNo", SqlDbType.VarChar)
        arParms(2).Value = HallTicketNo

        arParms(3) = New SqlParameter("@Prefix", SqlDbType.VarChar)
        arParms(3).Value = Prefix

        arParms(4) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(4).Value = Id

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateHallTicketNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GenerateHallTicketLockStatus(ByVal ExamBatchId As Integer, ByVal StdCenter As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
            Parms(1).Value = StdCenter

            Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GenerateHallTicketNoLockStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CountRecordsGenHallTicket(ByVal ExamBatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CountRecordsGenHallTicket", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RecordsGenHallTicket(ByVal ExamBatchId As Integer) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CountRecordsGenHallTicket", Parms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function LockGenerateHallTicket(ByVal ExamBatchId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_LockGenerateHallTicket", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UnLockGenerateHallTicket(ByVal ExamBatchId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UnLockGenerateHallTicket", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CheckHallTicketLockStatus(ByVal ExamBatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckHallTicketLockStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckPublishHallTicket(ByVal ExamBatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckPublishHallTicket1", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function PublishHallTicket(ByVal ExamBatchId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_PublishHallTicket", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CheckHallTicketNoForPublish(ByVal ExamBatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckHallTicketNoForPublish", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GenerateHallTicket(ByVal ExamBatchId As Integer, ByVal FromSerialNo As String, ByVal ToSerialNo As String, ByVal id As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim Params() As SqlParameter = New SqlParameter(4) {}

        Params(0) = New SqlParameter("@ExamBatchId", Data.SqlDbType.Int)
        Params(0).Value = ExamBatchId

        Params(1) = New SqlParameter("@FromSerialNo", Data.SqlDbType.VarChar)
        Params(1).Value = FromSerialNo

        Params(2) = New SqlParameter("@ToSerialNo", Data.SqlDbType.VarChar)
        Params(2).Value = ToSerialNo

        Params(3) = New SqlParameter("@id", Data.SqlDbType.VarChar)
        Params(3).Value = id
        Params(4) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(4).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GenerateHallTicketReportChecked", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GenerateHallTicketReports(ByVal ExamBatchId As Integer, ByVal FromSerialNo As String, ByVal ToSerialNo As String, ByVal id As String) As DataTable
        Dim dt As DataTable
        dt = DLGenerateHallTicket.GenerateHallTicket(ExamBatchId, FromSerialNo, ToSerialNo, id)
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
    Shared Function publish(ByVal msg As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@msg", SqlDbType.VarChar, msg.Length)
        arParms(1).Value = msg

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_PublishExamHallTicket", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GenerateHallTicketCalenderReports(ByVal Exam As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim Params() As SqlParameter = New SqlParameter(2) {}

        Params(0) = New SqlParameter("@Exam", Data.SqlDbType.Int)
        Params(0).Value = Exam


        Params(1) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(1).Value = HttpContext.Current.Session("BranchCode")


        Params(2) = New SqlParameter("@Office", Data.SqlDbType.VarChar)
        Params(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GenerateHallTicketCalendarChecked", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function updatepublishflag(ByVal exambatch As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@ExamBatchId", Data.SqlDbType.Int)
        arParms(1).Value = exambatch

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePublishFlag", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
