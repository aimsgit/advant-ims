Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient

Public Class ExtraCurricularAchivementsDL
    Dim dt As New DataTable
    Dim query As String
    Dim ds As New DataSet

    Shared Function GetDepartment() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[ddlDepartment]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Insert(ByVal ECA As ExtraCurricularAchievementsEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(0).Value = ECA.DeptID

        arParms(1) = New SqlParameter("@STD_ID", SqlDbType.Int)
        arParms(1).Value = ECA.StdCode

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = ECA.EmpCode

        arParms(3) = New SqlParameter("@Std_Emp", SqlDbType.VarChar, 50)
        arParms(3).Value = ECA.Std_Emp

        arParms(4) = New SqlParameter("@NameOfActivity", SqlDbType.VarChar, 250)
        arParms(4).Value = ECA.NameOfActivity

        arParms(5) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(5).Value = ECA.FromDate

        arParms(6) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(6).Value = ECA.ToDate

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = ECA.Remarks

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")

        arParms(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("EmpCode")

        arParms(10) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("UserCode")

        arParms(11) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("Office")

       
        

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_InsertExtraCurricullarAchievements]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetECA(ByVal ECA As ExtraCurricularAchievementsEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@AID", SqlDbType.Int)
        arParms(2).Value = ECA.Id

        arParms(3) = New SqlParameter("@NameOfActivity", SqlDbType.VarChar, 250)
        arParms(3).Value = ECA.NameOfActivity

        arParms(4) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(4).Value = ECA.DeptID



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_getECA]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function Update(ByVal ECA As ExtraCurricularAchievementsEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(0).Value = ECA.DeptID

        arParms(1) = New SqlParameter("@NameOfActivity", SqlDbType.VarChar, 250)
        arParms(1).Value = ECA.NameOfActivity

        arParms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(2).Value = ECA.FromDate

        arParms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(3).Value = ECA.ToDate

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(4).Value = ECA.Remarks

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@AID", SqlDbType.Int)
        arParms(8).Value = ECA.ID

        arParms(9) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("Office")

        arParms(10) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(10).Value = ECA.EmpCode

        arParms(11) = New SqlParameter("@STD_ID", SqlDbType.Int)
        arParms(11).Value = ECA.StdCode

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateExtraCurricullarAchievements]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal ECA As ExtraCurricularAchievementsEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@AID", SqlDbType.Int)
        arParms(0).Value = ECA.Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_ChangeECA", arParms)
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

    Shared Function GetECAR(ByVal DeptID As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@DeptID", SqlDbType.Int)
        param(2).Value = DeptID

        param(3) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        param(3).Value = FromDate

        param(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        param(4).Value = ToDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_ECA]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
