Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLLeaveApplication
    Shared Function GetLeaveDetials(ByVal DeptId As Integer, ByVal EmpId As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(2).Value = DeptId

        arParms(3) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(3).Value = EmpId

        arParms(4) = New SqlParameter("@FromDate", SqlDbType.Date)
        arParms(4).Value = FromDate
        arParms(5) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(5).Value = ToDate

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetPaid_UnpaidLeave", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function GetLeavingDateDetials(ByVal batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = batch
        


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetLeavingDateForbatch", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal std As String, ByVal leaving As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        arParms(2) = New SqlParameter("@ID", SqlDbType.VarChar, 200)
        arParms(2).Value = std

        arParms(3) = New SqlParameter("@LeavingDate", SqlDbType.VarChar, 50)
        arParms(3).Value = leaving


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateLeavingDate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
