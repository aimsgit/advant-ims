Imports Microsoft.VisualBasic

Public Class UserRequestD
    Dim EL As New UserRequestE
    Shared Function Insert(ByVal EL As UserRequestE) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        param(0) = New SqlClient.SqlParameter("@UserID", SqlDbType.VarChar, 50)
        param(0).Value = EL.UserId
        param(1) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar, 50)
        param(1).Value = EL.UserName
        param(2) = New SqlClient.SqlParameter("@RequestDate", SqlDbType.DateTime)
        param(2).Value = EL.RequestDate
        param(3) = New SqlClient.SqlParameter("@Priority", SqlDbType.VarChar, 50)
        param(3).Value = EL.Priority
        param(4) = New SqlClient.SqlParameter("@DescOfRequest", SqlDbType.VarChar, 255)
        param(4).Value = EL.DescOfRequest
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertUserRequset", param)
        Return AffectedRows
    End Function
    Shared Function Update(ByVal EL As UserRequestE) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        param(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
        param(0).Value = EL.Id
        param(1) = New SqlClient.SqlParameter("@ApprovedBy", SqlDbType.VarChar, 50)
        param(1).Value = EL.ApprovedBy
        param(2) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 50)
        param(2).Value = EL.Status
        param(3) = New SqlClient.SqlParameter("@ClosedDate", SqlDbType.DateTime)
        param(3).Value = EL.ClosedDate
        param(4) = New SqlClient.SqlParameter("@Remarks", SqlDbType.VarChar, 255)
        param(4).Value = EL.Remarks
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateUserRequest", param)
        Return AffectedRows
    End Function
    Shared Function Delete(ByVal ID As Long) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param As SqlClient.SqlParameter = New SqlClient.SqlParameter("@ID", SqlDbType.BigInt)
        param.Value = ID
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "", param)
        Return AffectedRows
    End Function
    Shared Function GetData() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_UserRequestData")
        Return ds.Tables(0)
    End Function
    Shared Function GetData(ByVal UserID As String) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param As SqlClient.SqlParameter = New SqlClient.SqlParameter("@UserID", SqlDbType.VarChar, 50)
        param.Value = UserID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_UserRequestStatus", param)
        Return ds.Tables(0)
    End Function
    Shared Function GetData(ByVal EL As UserRequestE) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
        param(0) = New SqlClient.SqlParameter("@UserID", SqlDbType.VarChar, 50)
        param(0).Value = el.UserId
        param(1) = New SqlClient.SqlParameter("@RequestDate", SqlDbType.DateTime)
        param(1).Value = el.RequestDate
        param(2) = New SqlClient.SqlParameter("@Priority", SqlDbType.VarChar, 50)
        param(2).Value = el.Priority
        param(3) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 50)
        param(3).Value = el.Status
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_FilterUserRequest", param)
        Return ds.Tables(0)
    End Function
    Shared Function GetData(ByVal ID As Int32) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param As SqlClient.SqlParameter = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
        param.Value = ID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_UserRequestStatus", param)
        Return ds.Tables(0)
    End Function
End Class
