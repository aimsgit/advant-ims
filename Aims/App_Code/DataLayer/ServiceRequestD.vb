Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ServiceRequestD

    Dim EL As New UserRequestE
    Public Function GetServicerequest(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Status As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(0).Value = fromdate

        arParms(1) = New SqlParameter("@TDate", SqlDbType.DateTime)
        arParms(1).Value = todate

        arParms(2) = New SqlParameter("@Status", SqlDbType.VarChar, 20)
        arParms(2).Value = Status

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Get_rpt_ErrorLogDetails", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetServicerequest2(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Status As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(0).Value = fromdate

        arParms(1) = New SqlParameter("@TDate", SqlDbType.DateTime)
        arParms(1).Value = todate

        arParms(2) = New SqlParameter("@Status", SqlDbType.VarChar, 20)
        arParms(2).Value = Status

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Get_rpt_ServiceRequest", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal EL As ServiceRequestE) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(10) {}

        param(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar, 50)
        param(0).Value = EL.UserName
        param(1) = New SqlClient.SqlParameter("@RequestDate", SqlDbType.DateTime)
        param(1).Value = EL.RequestDate
        param(2) = New SqlClient.SqlParameter("@Priority", SqlDbType.VarChar, 50)
        param(2).Value = EL.Priority
        param(3) = New SqlClient.SqlParameter("@DescOfRequest", SqlDbType.VarChar, 255)
        param(3).Value = EL.DescOfRequest
        param(4) = New SqlClient.SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("EmpCode")
        param(5) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("UserCode")
        param(6) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("BranchCode")
        param(7) = New SqlClient.SqlParameter("@Email", SqlDbType.VarChar, 100)
        param(7).Value = EL.Email
        param(8) = New SqlClient.SqlParameter("@PhNo", SqlDbType.VarChar, 50)
        param(8).Value = EL.PhNo
        param(9) = New SqlClient.SqlParameter("@ModuleId", SqlDbType.Int)
        param(9).Value = EL.ModuleId
        param(10) = New SqlClient.SqlParameter("@SerReqId", SqlDbType.VarChar, 100)
        param(10).Value = EL.ServReqId

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_InsertIntoServiceRequest]", param)
        Return AffectedRows
    End Function
    Shared Function GetServiceEmailDetails(ByVal EL As ServiceRequestE) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(10) {}
        Dim ds As New DataSet
        param(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar, 50)
        param(0).Value = EL.UserName
        param(1) = New SqlClient.SqlParameter("@RequestDate", SqlDbType.DateTime)
        param(1).Value = EL.RequestDate
        param(2) = New SqlClient.SqlParameter("@Priority", SqlDbType.VarChar, 50)
        param(2).Value = EL.Priority
        param(3) = New SqlClient.SqlParameter("@DescOfRequest", SqlDbType.VarChar, 255)
        param(3).Value = EL.DescOfRequest
        param(4) = New SqlClient.SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("EmpCode")
        param(5) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("UserCode")
        param(6) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("BranchCode")
        param(7) = New SqlClient.SqlParameter("@Email", SqlDbType.VarChar, 100)
        param(7).Value = EL.Email
        param(8) = New SqlClient.SqlParameter("@PhNo", SqlDbType.VarChar, 50)
        param(8).Value = EL.PhNo
        param(9) = New SqlClient.SqlParameter("@ModuleId", SqlDbType.Int)
        param(9).Value = EL.ModuleId
        param(10) = New SqlClient.SqlParameter("@SerReqId", SqlDbType.VarChar, 100)
        param(10).Value = EL.ServReqId

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmailServiceRequest", param)
        Return ds.Tables(0)
    End Function
   
    Shared Function Delete(ByVal ID As Long) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        param(0) = New SqlClient.SqlParameter("@ID", SqlDbType.BigInt)
        param(0).Value = ID
        param(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_DeleteServiceRequest]", param)
        Return AffectedRows
    End Function
   
    Shared Function GetData(ByVal a As ServiceRequestE) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlClient.SqlParameter("@PriorityReq", SqlDbType.VarChar, 50)
        param(2).Value = a.Priority
       
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetServiceRequest]", param)
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpData(ByVal Empcode As String) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 100)
        param(2).Value = Empcode

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetEmpDetails]", param)
        Return ds.Tables(0)
    End Function

    Shared Function GetModuleName() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter() {}

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetModuleNames]", param)
        Return ds.Tables(0)
    End Function

    Public Shared Function GetSerReqId() As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter() {}


      

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[New_SelectServiceREqID]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
