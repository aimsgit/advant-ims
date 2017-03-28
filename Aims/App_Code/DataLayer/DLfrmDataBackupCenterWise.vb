Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLfrmDataBackupCenterWise
    Shared Function insertBranch() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetBranchCode", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetGridData(ByVal el As ELfrmDataBackupCenterWise) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = el.BranchCode

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = el.Id

        arParms(3) = New SqlParameter("@RbId", SqlDbType.VarChar, 50)
        arParms(3).Value = el.RbId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getDataBackupCenterWise", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
