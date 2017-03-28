Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DlLeaveRegisterRpt
    Public Function Rpt_LeaveRegister(ByVal DP As Integer, ByVal LT As Integer, ByVal YR As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@LeaveTypeID", SqlDbType.Int)
        arParms(2).Value = LT

        arParms(3) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(3).Value = DP

        arParms(4) = New SqlParameter("@Year", SqlDbType.VarChar)
        arParms(4).Value = YR

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_LeaveRegister", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeptCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlDeptcombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetLeave() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("Office")
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_LeaveTypeCombo1", Parms)
        Return ds.Tables(0)
    End Function
    Shared Function ddlYear() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLYearCombo")
        Return ds.Tables(0)
    End Function
End Class
