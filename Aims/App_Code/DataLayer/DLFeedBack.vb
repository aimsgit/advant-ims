Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class DLFeedBack
    Public Function InsertFeedBackStudent(ByVal el As ELFeedBackDetails) As Integer
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

            Dim rowsAffected As Integer = 0

            Dim arParms() As SqlParameter = New SqlParameter(10) {}

            arParms(0) = New SqlParameter("@Branchname", SqlDbType.VarChar, 50)
            arParms(0).Value = el.BranchName

            arParms(1) = New SqlParameter("@username", SqlDbType.VarChar, 50)
            arParms(1).Value = el.UserName

            arParms(2) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
            arParms(2).Value = el.Email

            arParms(3) = New SqlParameter("@ContactNo", SqlDbType.VarChar, 100)
            arParms(3).Value = el.ContactNo

            arParms(4) = New SqlParameter("@ChildLink", SqlDbType.Int)
            arParms(4).Value = el.ChildLink

            arParms(5) = New SqlParameter("@FeedBack", SqlDbType.VarChar, 2)
            arParms(5).Value = el.FeedBack

            arParms(6) = New SqlParameter("@Suggestion", SqlDbType.VarChar, 250)
            arParms(6).Value = el.Suggestion

            arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(7).Value = HttpContext.Current.Session("BranchCode")

            arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
            arParms(8).Value = "0"

            arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            arParms(9).Value = HttpContext.Current.Session("UserCode")

            arParms(10) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
            arParms(10).Value = HttpContext.Current.Session("StudentCode")

            Try
                rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "proc_SaveNewFeedBack", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetENPLOYEEDetails(ByVal el As ELFeedBackDetails) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim Para() As SqlParameter = New SqlParameter(2) {}

            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Emp_Id", SqlDbType.Int)
            Para(1).Value = el.Empid
            'Para(1).Value = HttpContext.Current.Session("Emp_Id")

            Para(2) = New SqlParameter("@office", SqlDbType.VarChar, 2)
            Para(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetEMPDetailsNew]", Para)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetFeedbackDetails(ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal LG As Integer, ByVal Status As String) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim Para() As SqlParameter = New SqlParameter(5) {}

            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            Para(1).Value = Fromdate

            Para(2) = New SqlParameter("@todate", SqlDbType.DateTime)
            Para(2).Value = Todate

            Para(3) = New SqlParameter("@office", SqlDbType.VarChar, 2)
            Para(3).Value = HttpContext.Current.Session("Office")

            Para(4) = New SqlParameter("@LG", SqlDbType.Int)
            Para(4).Value = LG

            Para(5) = New SqlParameter("@Status", SqlDbType.VarChar, 20)
            Para(5).Value = Status

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetFeedback_DisplayGrid", Para)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetFeedbackDetailsReport(ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal LG As Integer, ByVal Status As String) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim Para() As SqlParameter = New SqlParameter(5) {}

            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            Para(1).Value = Fromdate

            Para(2) = New SqlParameter("@todate", SqlDbType.DateTime)
            Para(2).Value = Todate
            'Para(1).Value = HttpContext.Current.Session("Emp_Id")

            Para(3) = New SqlParameter("@office", SqlDbType.VarChar, 2)
            Para(3).Value = HttpContext.Current.Session("Office")

            Para(4) = New SqlParameter("@LG", SqlDbType.Int)
            Para(4).Value = LG

            Para(5) = New SqlParameter("@Status", SqlDbType.VarChar, 20)
            Para(5).Value = Status

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[GetFeedback_DetailsReport]", Para)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetSessionValue(ByVal Sess As Integer) As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim Para() As SqlParameter = New SqlParameter(2) {}

            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@Session", SqlDbType.Int)
            Para(2).Value = Sess

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetSessionValue]", Para)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetStudentDetails(ByVal el As ELFeedBackDetails) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim Para() As SqlParameter = New SqlParameter(2) {}

            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
            Para(1).Value = el.StudentCode
            'Para(1).Value = HttpContext.Current.Session("Emp_Id")

            Para(2) = New SqlParameter("@office", SqlDbType.VarChar, 2)
            Para(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDetailsforFeedBack", Para)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function InsertFeedBackEmp(ByVal el As ELFeedBackDetails) As Integer
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

            Dim rowsAffected As Integer = 0

            Dim arParms() As SqlParameter = New SqlParameter(10) {}

            arParms(0) = New SqlParameter("@Branchname", SqlDbType.VarChar, 50)
            arParms(0).Value = el.BranchName

            arParms(1) = New SqlParameter("@username", SqlDbType.VarChar, 50)
            arParms(1).Value = el.UserName

            arParms(2) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
            arParms(2).Value = el.Email

            arParms(3) = New SqlParameter("@ContactNo", SqlDbType.VarChar, 100)
            arParms(3).Value = el.ContactNo

            arParms(4) = New SqlParameter("@ChildLink", SqlDbType.Int)
            arParms(4).Value = el.ChildLink

            arParms(5) = New SqlParameter("@FeedBack", SqlDbType.VarChar, 2)
            arParms(5).Value = el.FeedBack

            arParms(6) = New SqlParameter("@Suggestion", SqlDbType.VarChar, 250)
            arParms(6).Value = el.Suggestion

            arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(7).Value = HttpContext.Current.Session("BranchCode")

            arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
            arParms(8).Value = HttpContext.Current.Session("EmpCode")

            arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            arParms(9).Value = HttpContext.Current.Session("UserCode")

            arParms(10) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
            arParms(10).Value = "0"

            Try
                rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "proc_SaveNewFeedBack", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Close(ByVal FBid As Int64, ByVal el As ELFeedBackDetails) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer

        Dim Param() As SqlParameter = New SqlParameter(1) {}
        Param(0) = New SqlClient.SqlParameter("@FB_ID", SqlDbType.Int)
        Param(0).Value = FBid

        Param(1) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 20)
        Param(1).Value = el.Estatus

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateFeedbackStatus", Param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function

    Shared Function DeleteFeedback(ByVal FBId As Int64) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer

        Dim Param() As SqlParameter = New SqlParameter(0) {}
        Param(0) = New SqlClient.SqlParameter("@FBID", SqlDbType.Int)
        Param(0).Value = FBId

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteFeedback", Param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function

End Class
