Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.IO

Public Class capPlanDL
    Public Function GetCapacityPlanReport(ByVal Branch As String, ByVal Year As String, ByVal Department As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = Branch

        arParms(2) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(2).Value = Year

        arParms(3) = New SqlParameter("@DeptName", SqlDbType.VarChar, 50)
        arParms(3).Value = Department

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_CapacityPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
End Class
