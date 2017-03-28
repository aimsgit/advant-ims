Imports Microsoft.VisualBasic

Public Class ServiceResponseD
    Shared Function Update(ByVal EL As ServiceResponseE) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        param(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
        param(0).Value = EL.Id
        param(1) = New SqlClient.SqlParameter("@Priority", SqlDbType.VarChar, 50)
        param(1).Value = EL.Priority
        param(2) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 50)
        param(2).Value = EL.Status
        param(3) = New SqlClient.SqlParameter("@ResponseDate", SqlDbType.DateTime)
        param(3).Value = EL.ResponseDate
        param(4) = New SqlClient.SqlParameter("@Remarks", SqlDbType.VarChar, 255)
        param(4).Value = EL.DescOfResponse
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateAdminResponse]", param)
        Return AffectedRows
    End Function
    Shared Function GetData(ByVal EL As ServiceResponseE) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlClient.SqlParameter("@Priority", SqlDbType.VarChar, 50)
        param(2).Value = EL.Priority
        param(3) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 50)
        param(3).Value = EL.Status
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetServiceResponse]", param)
        Return ds.Tables(0)
    End Function

    Shared Function GetServiceRepondEmailDetails(ByVal EL As ServiceResponseE) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        Dim ds As New DataSet
        param(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
        param(0).Value = EL.Id
        param(1) = New SqlClient.SqlParameter("@email", SqlDbType.VarChar)
        param(1).Value = EL.Email_id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmailServiceResponse", param)
        Return ds.Tables(0)
    End Function
End Class
