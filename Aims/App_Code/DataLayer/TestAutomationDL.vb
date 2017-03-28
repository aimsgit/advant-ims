Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class TestAutomationDL
    Shared Function GetLinkName() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserRole")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@LanguageID", SqlDbType.Int)
        arParms(3).Value = HttpContext.Current.Session("LanguageID")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLinkNameTest", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
