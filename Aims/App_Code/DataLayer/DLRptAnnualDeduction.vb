Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class DLRptAnnualDeduction
    Shared Function GetDepartment() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_AnnualDeductionDeptCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetEmpNameCombo(ByVal DeptId As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        Para(2).Value = DeptId
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_DeductionEmpNameCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function ddlYear() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_DeductionDDLYear]")
        Return ds.Tables(0)
    End Function

    Shared Function RptAnnualDeduction(ByVal FromYear As Integer, ByVal ToYear As Integer, ByVal FromMonth As Integer, ByVal ToMonth As Integer, ByVal Dept As Integer, ByVal Empid As Integer) As System.Data.DataTable
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
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_AnnualReportDeduction]", arParms)
        Return ds.Tables(0)

    End Function
End Class
