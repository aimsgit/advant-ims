Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLBudget
    'code for Insert Budget  By Nitin 23-05-2012
    Public Function Insert(ByVal Budget As Budget) As Int16

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Count As Int32

        Dim arParms() As SqlParameter = New SqlParameter(14) {}

        arParms(0) = New SqlParameter("@A_Code", SqlDbType.Int)
        arParms(0).Value = Budget.Year

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@ProjectID_Auto", SqlDbType.Int)
        arParms(4).Value = Budget.Project_ID

        arParms(5) = New SqlParameter("@Project_Estimate", SqlDbType.Money)
        arParms(5).Value = Budget.Project_Estimate

        arParms(6) = New SqlParameter("@DateOfEstimation", SqlDbType.Date)
        arParms(6).Value = Budget.DateOfEstimation

        arParms(7) = New SqlParameter("@Approved_Budget", SqlDbType.Money)
        arParms(7).Value = Budget.Approved_Budget

        arParms(8) = New SqlParameter("@DateOfApproval", SqlDbType.Date)
        arParms(8).Value = Budget.DateOfApproval

        arParms(9) = New SqlParameter("@Revised_Budget", SqlDbType.Money)
        arParms(9).Value = Budget.Revised_Budget

        arParms(10) = New SqlParameter("@DateRevBudget", SqlDbType.Date)
        arParms(10).Value = Budget.DateRevBudget

        arParms(11) = New SqlParameter("@Used_Budget", SqlDbType.Money)
        arParms(11).Value = Budget.Used_Budget

        arParms(12) = New SqlParameter("@Progress_Percent", SqlDbType.Float)
        arParms(12).Value = Budget.Progress_Percent

        arParms(13) = New SqlParameter("@Status_Date", SqlDbType.Date)
        arParms(13).Value = Budget.Status_Date

        arParms(14) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(14).Value = Budget.Remarks


        Try
            Count = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_InsertintoBudget]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'code for Update Budget  By Nitin 23-05-2012
    Public Function Update(ByVal Budget As Budget) As Long
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(15) {}

        arParms(0) = New SqlParameter("@A_Code", SqlDbType.Int)
        arParms(0).Value = Budget.Year

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@ProjectID_Auto", SqlDbType.Int)
        arParms(4).Value = Budget.Project_ID

        arParms(5) = New SqlParameter("@Project_Estimate", SqlDbType.Money)
        arParms(5).Value = Budget.Project_Estimate

        arParms(6) = New SqlParameter("@DateOfEstimation", SqlDbType.DateTime)
        arParms(6).Value = Budget.DateOfEstimation

        arParms(7) = New SqlParameter("@Approved_Budget", SqlDbType.Money)
        arParms(7).Value = Budget.Approved_Budget

        arParms(8) = New SqlParameter("@DateOfApproval", SqlDbType.DateTime)
        arParms(8).Value = Budget.DateOfApproval

        arParms(9) = New SqlParameter("@Revised_Budget", SqlDbType.Money)
        arParms(9).Value = Budget.Revised_Budget

        arParms(10) = New SqlParameter("@DateRevBudget", SqlDbType.DateTime)
        arParms(10).Value = Budget.DateRevBudget

        arParms(11) = New SqlParameter("@Used_Budget", SqlDbType.Money)
        arParms(11).Value = Budget.Used_Budget

        arParms(12) = New SqlParameter("@Progress_Percent", SqlDbType.Float)
        arParms(12).Value = Budget.Progress_Percent

        arParms(13) = New SqlParameter("@Status_Date", SqlDbType.DateTime)
        arParms(13).Value = Budget.Status_Date

        arParms(14) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(14).Value = Budget.Remarks

        arParms(15) = New SqlParameter("@BudgetID_Auto", SqlDbType.Int)
        arParms(15).Value = Budget.BudgetID


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBudget", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'code for Get Budget  By Nitin 23-05-2012
    Public Function GetBudget(ByVal Budget As Budget) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@BudgetID_Auto", SqlDbType.Int)
        arParms(2).Value = Budget.BudgetID
        arParms(3) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        arParms(3).Value = Budget.Year
        arParms(4) = New SqlParameter("@ProjectName", SqlDbType.VarChar, 50)
        arParms(4).Value = Budget.Project_ID

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetBudget]", arParms)
        Return ds.Tables(0)
    End Function
    'code for Delete Budget  By Nitin 23-05-2012
    Public Function DeleteBudget(ByVal id As Integer) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BudgetId", SqlDbType.Int)
        arParms(0).Value = id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteBudgetID", arParms)
        Return rowsaffected
    End Function
    'code for Check Duplicate entry By Nitin 23-05-2012
    Public Function CheckDuplicate(ByVal Budget As Budget) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@A_Code", SqlDbType.Int)
        para(2).Value = Budget.Year

        para(3) = New SqlParameter("@ProjectID_Auto", SqlDbType.Int)
        para(3).Value = Budget.Project_ID

        para(4) = New SqlParameter("@id", SqlDbType.Int)
        para(4).Value = Budget.BudgetID

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetDuplicateBudget", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function GetProjectNameCombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "[Proc_GetProjectNameCombo]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    'code for Search Button By Nitin 22-06-2012
    Public Function GetBudgetSearch(ByVal Budget As Budget) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@BudgetID_Auto", SqlDbType.Int)
        arParms(2).Value = Budget.BudgetID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBudgetSearch", arParms)
        Return ds.Tables(0)
    End Function
End Class
