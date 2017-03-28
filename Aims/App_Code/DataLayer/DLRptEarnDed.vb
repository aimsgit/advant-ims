Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class DLRptEarnDed
    Shared Function GetDepartment(ByVal BranchCode As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = BranchCode
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_EarnDedDeptCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpName(ByVal BranchCode As String, ByVal DeptId As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = BranchCode
        Para(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        Para(2).Value = DeptId
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_Emp_NameComboEarnDed", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmployeeEarning(ByVal BranchName As String, ByVal Department As String, ByVal EmpName As String, ByVal Year As Integer, ByVal Month As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchName

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        arParms(2).Value = Department

        arParms(3) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(3).Value = EmpName

        arParms(4) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(4).Value = Year

        arParms(5) = New SqlParameter("@Month", SqlDbType.VarChar, 150)
        arParms(5).Value = Month

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Rpt_Earn", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmployeedDeduction(ByVal BranchName As String, ByVal Department As String, ByVal EmpName As String, ByVal Year As Integer, ByVal Month As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchName

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        arParms(2).Value = Department

        arParms(3) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(3).Value = EmpName

        arParms(4) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(4).Value = Year

        arParms(5) = New SqlParameter("@Month", SqlDbType.VarChar, 150)
        arParms(5).Value = Month

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Rpt_Ded", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class

