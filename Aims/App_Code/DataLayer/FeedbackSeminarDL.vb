Imports System.Web.UI.WebControls
Imports System.Data.SqlClient

Public Class FeedbackSeminarDL

    Shared Function GetEmployee() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_getEmployee]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Insert(ByVal FS As FeedbackSeminarEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        arParms(0) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(0).Value = FS.DeptID

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(1).Value = FS.EmpID

        arParms(2) = New SqlParameter("@ProgramTitle", SqlDbType.VarChar, 50)
        arParms(2).Value = FS.ProgramTitle

        arParms(3) = New SqlParameter("@Location", SqlDbType.VarChar, 50)
        arParms(3).Value = FS.Location

        arParms(4) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(4).Value = FS.FromDate

        arParms(5) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(5).Value = FS.ToDate

        arParms(6) = New SqlParameter("@TrainingFaculty", SqlDbType.VarChar, 50)
        arParms(6).Value = FS.TrainingFaculty

        arParms(7) = New SqlParameter("@ProgramFeedbackbyCandidate", SqlDbType.VarChar, 250)
        arParms(7).Value = FS.ProgramFeedback


        arParms(8) = New SqlParameter("@CanYou", SqlDbType.Int)
        arParms(8).Value = FS.CanYou

        arParms(9) = New SqlParameter("@ProgramEffectivenessbyHOD", SqlDbType.VarChar, 250)
        arParms(9).Value = FS.ProgramEffectiveness

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        arParms(11) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("EmpCode")

        arParms(12) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("UserCode")

        arParms(13) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_InsertFeedbackSeminar]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetFeedback(ByVal FS As FeedbackSeminarEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@FBAID", SqlDbType.Int)
        arParms(2).Value = FS.Id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_getFeedbackSeminar]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal FS As FeedbackSeminarEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(14) {}

        arParms(0) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(0).Value = FS.DeptID

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(1).Value = FS.EmpID

        arParms(2) = New SqlParameter("@ProgramTitle", SqlDbType.VarChar, 50)
        arParms(2).Value = FS.ProgramTitle

        arParms(3) = New SqlParameter("@Location", SqlDbType.VarChar, 50)
        arParms(3).Value = FS.Location

        arParms(4) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(4).Value = FS.FromDate

        arParms(5) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(5).Value = FS.ToDate

        arParms(6) = New SqlParameter("@TrainingFaculty", SqlDbType.VarChar, 50)
        arParms(6).Value = FS.TrainingFaculty

        arParms(7) = New SqlParameter("@ProgramFeedbackbyCandidate", SqlDbType.VarChar, 250)
        arParms(7).Value = FS.ProgramFeedback


        arParms(8) = New SqlParameter("@CanYou", SqlDbType.Int)
        arParms(8).Value = FS.CanYou

        arParms(9) = New SqlParameter("@ProgramEffectivenessbyHOD", SqlDbType.VarChar, 250)
        arParms(9).Value = FS.ProgramEffectiveness

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        arParms(11) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("EmpCode")

        arParms(12) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("UserCode")

        arParms(13) = New SqlParameter("@FBAID", SqlDbType.Int)
        arParms(13).Value = FS.Id

        arParms(14) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateFeedbackSeminar]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal FS As FeedbackSeminarEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FBAID", SqlDbType.Int)
        arParms(0).Value = FS.Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[proc_ChangeFlagFeedbackSeminar]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    '-------function For Report
    Shared Function GetDepartmentR() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[ddlDepartmentReport]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetEmployeeR() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_ddlEmployee]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetFeedbackSeminar(ByVal DeptID As Integer, ByVal EmpID As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@DeptID", SqlDbType.Int)
        param(2).Value = DeptID

        param(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        param(3).Value = EmpID

        param(4) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        param(4).Value = FromDate

        param(5) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        param(5).Value = ToDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_FeedbackSeminar]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
