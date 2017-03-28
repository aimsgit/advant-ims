Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLcollectSponser
    Public Function GetRptCollectSponser(ByVal Academicyear As Integer, ByVal Batch As Integer, ByVal student As Integer, ByVal payment As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@AcademicYear", SqlDbType.Int)
        arParms(2).Value = Academicyear

        arParms(3) = New SqlParameter("@batch", SqlDbType.Int)
        arParms(3).Value = Batch

        arParms(4) = New SqlParameter("@stdId", SqlDbType.Int)
        arParms(4).Value = student

        arParms(5) = New SqlParameter("@paymentmethod", SqlDbType.Int)
        arParms(5).Value = payment





        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptCollectSponcerAmount", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPaymentMethodcombo1() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetPaymentMethodComboSponcer", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
