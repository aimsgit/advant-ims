Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLAnnualSalaryStatment

    Shared Function RptSalarySummaryStatment(ByVal FromYear As Integer, ByVal ToYear As Integer, ByVal FromMonth As Integer, ByVal ToMonth As Integer, ByVal Dept As Integer, ByVal Empid As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@FromYear", SqlDbType.Int)
        arParms(1).Value = FromYear

        arParms(2) = New SqlParameter("@ToYear", SqlDbType.Int)
        arParms(2).Value = ToYear

        arParms(3) = New SqlParameter("@FromMonth", SqlDbType.Int)
        arParms(3).Value = FromMonth

        arParms(4) = New SqlParameter("@ToMonth", SqlDbType.Int)
        arParms(4).Value = ToMonth

        arParms(5) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(5).Value = Dept

        arParms(6) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(6).Value = Empid


        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AnnualSalaryStatment2", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function RptAnnualStatmentNew(ByVal FromYear As Integer, ByVal ToYear As Integer, ByVal FromMonth As Integer, ByVal ToMonth As Integer, ByVal Dept As Integer, ByVal Empid As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@FromYear", SqlDbType.Int)
        arParms(1).Value = FromYear

        arParms(2) = New SqlParameter("@ToYear", SqlDbType.Int)
        arParms(2).Value = ToYear

        arParms(3) = New SqlParameter("@FromMonth", SqlDbType.Int)
        arParms(3).Value = FromMonth

        arParms(4) = New SqlParameter("@ToMonth", SqlDbType.Int)
        arParms(4).Value = ToMonth

        arParms(5) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(5).Value = Dept

        arParms(6) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(6).Value = Empid
        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Office")


        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AnnualReport", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function RptAnnualStatment(ByVal FromYear As Integer, ByVal ToYear As Integer, ByVal FromMonth As Integer, ByVal ToMonth As Integer, ByVal Dept As Integer, ByVal Empid As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@FromYear", SqlDbType.Int)
        arParms(1).Value = FromYear

        arParms(2) = New SqlParameter("@ToYear", SqlDbType.Int)
        arParms(2).Value = ToYear

        arParms(3) = New SqlParameter("@FromMonth", SqlDbType.Int)
        arParms(3).Value = FromMonth

        arParms(4) = New SqlParameter("@ToMonth", SqlDbType.Int)
        arParms(4).Value = ToMonth

        arParms(5) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(5).Value = Dept

        arParms(6) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(6).Value = Empid


        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AnnualSalaryStatment2", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function Rptitemsummaries(ByVal Year As Integer, ByVal Month As String, ByVal Dept As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Year

        arParms(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(2).Value = Month

        arParms(3) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(3).Value = Dept

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Rpt_Itemsummaries", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function RptitemsummariesNew(ByVal Year As Integer, ByVal Month As String, ByVal Dept As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Year

        arParms(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(2).Value = Month

        arParms(3) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(3).Value = Dept

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Rpt_ItemsummariesNew", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function RptRemitenanceListNew(ByVal Year As Integer, ByVal Month As String, ByVal Item As Integer, ByVal ItemName As String, ByVal Payment As Integer, ByVal BankId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Year

        arParms(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(2).Value = Month

        arParms(3) = New SqlParameter("@Item", SqlDbType.Int)
        arParms(3).Value = Item

        arParms(4) = New SqlParameter("@Payment", SqlDbType.Int)
        arParms(4).Value = Payment
        arParms(5) = New SqlParameter("@BankId", SqlDbType.Int)
        arParms(5).Value = BankId
        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")

        arParms(7) = New SqlParameter("@ItemName", SqlDbType.VarChar, 50)
        arParms(7).Value = ItemName

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_RemitenanceListNew", arParms)
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If

    End Function
    Shared Function RptRemitenanceList(ByVal Year As Integer, ByVal Month As String, ByVal Item As String, ByVal Payment As Integer, ByVal BankId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Year

        arParms(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(2).Value = Month

        arParms(3) = New SqlParameter("@Item", SqlDbType.VarChar, 50)
        arParms(3).Value = Item

        arParms(4) = New SqlParameter("@Payment", SqlDbType.Int)
        arParms(4).Value = Payment
        arParms(5) = New SqlParameter("@BankId", SqlDbType.Int)
        arParms(5).Value = BankId

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_RemitenanceList", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function RptMonthlySalaryRegister(ByVal Year As Integer, ByVal Month As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Year

        arParms(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(2).Value = Month

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")



        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptMonthlySalaryRegister1", arParms)
        Return ds.Tables(0)
    End Function


    Shared Function RptMonthlyStatment(ByVal FromYear As Integer, ByVal ToYear As Integer, ByVal FromMonth As Integer, ByVal ToMonth As Integer, ByVal Dept As Integer, ByVal Empid As Integer, ByVal ColumnNames As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@FromYear", SqlDbType.Int)
        arParms(1).Value = FromYear

        arParms(2) = New SqlParameter("@ToYear", SqlDbType.Int)
        arParms(2).Value = ToYear

        arParms(3) = New SqlParameter("@FromMonth", SqlDbType.Int)
        arParms(3).Value = FromMonth

        arParms(4) = New SqlParameter("@ToMonth", SqlDbType.Int)
        arParms(4).Value = ToMonth

        arParms(5) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(5).Value = Dept

        arParms(6) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(6).Value = Empid

        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Office")

        arParms(8) = New SqlParameter("@ColumnNames", SqlDbType.VarChar, 5000)
        arParms(8).Value = ColumnNames

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_MonthlySalaryStatment", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function RptMonthlyReport(ByVal FromYear As Integer, ByVal ToYear As Integer, ByVal FromMonth As String, ByVal ToMonth As String, ByVal Dept As Integer, ByVal Empid As Integer, ByVal ColumnNames As String, ByVal ColumNName1 As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@FromYear", SqlDbType.Int)
        arParms(1).Value = FromYear

        arParms(2) = New SqlParameter("@ToYear", SqlDbType.Int)
        arParms(2).Value = ToYear

        arParms(3) = New SqlParameter("@FromMonth", SqlDbType.VarChar, 50)
        arParms(3).Value = FromMonth

        arParms(4) = New SqlParameter("@ToMonth", SqlDbType.VarChar, 50)
        arParms(4).Value = ToMonth

        arParms(5) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(5).Value = Dept

        arParms(6) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(6).Value = Empid

        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Office")

        arParms(8) = New SqlParameter("@ColumnNames", SqlDbType.VarChar, 5000)
        arParms(8).Value = ColumnNames
        arParms(9) = New SqlParameter("@ColumnNamesStr", SqlDbType.VarChar, 5000)
        arParms(9).Value = ColumNName1

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetMonthlyPayrollReport", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function GridMonthlySalaryStatement() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As New DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MonthlyStatementDynamicGrid")
            Return ds.Tables(0)
        Catch ex As Exception

        End Try
    End Function
    Shared Function GridMonthlycol() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As New DataSet
            Dim param() As SqlParameter = New SqlParameter(1) {}
            param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            param(0).Value = HttpContext.Current.Session("Office")
            param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            param(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MonthlyStatementDynamicGridNEw", param)
            Return ds.Tables(0)
        Catch ex As Exception

        End Try
    End Function
    Shared Function BankComboD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_NewGetBankCombo1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function RptSalaryNewPay(ByVal Year As Integer, ByVal Month As String, ByVal MonthNo As Integer, ByVal Dept As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Year

        arParms(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(2).Value = Month

        arParms(3) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(3).Value = Dept

        arParms(4) = New SqlParameter("@MonthNo", SqlDbType.VarChar, 50)
        arParms(4).Value = MonthNo
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SalaryNewPay", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function RptSalaryRepay(ByVal Year As Integer, ByVal Month As String, ByVal MonthNo As Integer, ByVal Dept As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Year

        arParms(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(2).Value = Month

        arParms(3) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(3).Value = Dept

        arParms(4) = New SqlParameter("@MonthNo", SqlDbType.VarChar, 50)
        arParms(4).Value = MonthNo
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SalaryRepay", arParms)
        Return ds.Tables(0)

    End Function
End Class
