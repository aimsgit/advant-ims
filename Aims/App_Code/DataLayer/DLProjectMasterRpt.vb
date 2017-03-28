Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLProjectMasterRpt
    Public Function Rpt_PrjMaster(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.Date)
        arParms(2).Value = FromDate

        arParms(3) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(3).Value = ToDate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_ProjectMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
