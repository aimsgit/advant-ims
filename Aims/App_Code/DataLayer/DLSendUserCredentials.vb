Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class DLSendUserCredentials
    Shared Function GetParentLoginDetails(ByVal ChkID As String, ByVal GroupName As String, ByVal Emp_Code As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@ChkID", SqlDbType.VarChar, 8000)
        arParms(0).Value = ChkID

        arParms(1) = New SqlParameter("@GroupName", SqlDbType.VarChar, 50)
        arParms(1).Value = GroupName

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")


        arParms(3) = New SqlParameter("@Emp_Code", SqlDbType.VarChar, 8000)
        arParms(3).Value = Emp_Code

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "RptSendParentCredentials", arParms)

        Return ds.Tables(0)
    End Function
    Shared Function GetParentEMAILSMSLoginDetails(ByVal ChkID As String, ByVal GroupName As String, ByVal Emp_Code As String, ByVal Mode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@ChkID", SqlDbType.VarChar, 8000)
        arParms(0).Value = ChkID

        arParms(1) = New SqlParameter("@GroupName", SqlDbType.VarChar, 50)
        arParms(1).Value = GroupName

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")


        arParms(3) = New SqlParameter("@Emp_Code", SqlDbType.VarChar, 8000)
        arParms(3).Value = Emp_Code

        arParms(4) = New SqlParameter("@Mode", SqlDbType.VarChar, 50)
        arParms(4).Value = Mode

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "RptSendEmailSMSParentCredentials", arParms)

        Return ds.Tables(0)
    End Function
    Shared Function GetEmployeeDetails(ByVal ChkID As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@ChkID", SqlDbType.VarChar, 8000)
        arParms(0).Value = ChkID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_DashBoardFeeCollectionDrillDown", arParms)

        Return ds.Tables(0)
    End Function
End Class
