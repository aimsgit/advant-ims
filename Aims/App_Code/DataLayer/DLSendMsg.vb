Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLSendMsg
    Public Function GetData(ByVal s As String, ByVal FrmDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim parms() As SqlParameter = New SqlParameter(4) {}
        parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        parms(0).Value = HttpContext.Current.Session("Office")

        parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        parms(1).Value = HttpContext.Current.Session("BranchCode")

        parms(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        parms(2).Value = s

        parms(3) = New SqlParameter("@FrmDate", SqlDbType.DateTime)
        parms(3).Value = FrmDate

        parms(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        parms(4).Value = ToDate

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CommunicationApprovalGrid", parms)
        Return ds.Tables(0)
    End Function

    Public Function GetCommunication(ByVal ID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim parms() As SqlParameter = New SqlParameter(0) {}
        parms(0) = New SqlParameter("@CMID", SqlDbType.Int)
        parms(0).Value = ID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCommunication", parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Approve(ByVal ID As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowseffected As Integer
        Dim parms() As SqlParameter = New SqlParameter(1) {}
        parms(0) = New SqlParameter("@CMID", SqlDbType.Int)
        parms(0).Value = ID
        parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        parms(1).Value = HttpContext.Current.Session("BranchCode")

        rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ApproveCommunication", parms)
        Return rowseffected
    End Function

    Public Function Reject(ByVal ID As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowseffected As Integer
        Dim parms() As SqlParameter = New SqlParameter(1) {}
        parms(0) = New SqlParameter("@CMID", SqlDbType.Int)
        parms(0).Value = ID
        parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        parms(1).Value = HttpContext.Current.Session("BranchCode")

        rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_RejectCommunication", parms)
        Return rowseffected
    End Function

    Public Shared Function GetEmail() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "EmailDesp")
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
  
    Public Function InsertIntoOutbox(ByVal Prefix As String, ByVal ToPhone As String, ByVal Message As String, ByVal SentDate As DateTime) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
        Dim Rowseffected As New Integer
        Dim parms() As SqlParameter = New SqlParameter(3) {}

        parms(0) = New SqlParameter("@Prefix", SqlDbType.VarChar, 50)
        parms(0).Value = Prefix

        parms(1) = New SqlParameter("@ToPhone", SqlDbType.VarChar, 50)
        parms(1).Value = ToPhone

        parms(2) = New SqlParameter("@Message", SqlDbType.VarChar, Len(Message))
        parms(2).Value = Message

        parms(3) = New SqlParameter("@SentDate", SqlDbType.DateTime)
        parms(3).Value = SentDate
        Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, "insert into Outbox_tbl (Prefix,ToPhone,Message,SentDate)values(@Prefix,@ToPhone,@Message,@SentDate)")
        Return Rowseffected
    End Function
    Public Function DeleteRecord(ByVal ID As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowseffected As Integer
        Dim parms() As SqlParameter = New SqlParameter(1) {}
        parms(0) = New SqlParameter("@Id", SqlDbType.Int)
        parms(0).Value = ID
        parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        parms(1).Value = HttpContext.Current.Session("BranchCode")

        rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteCommunication", parms)
        Return rowseffected
    End Function

    Public Function UpdateRecord(ByVal id As Integer, ByVal msg As String, ByVal remarks As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowseffected As Integer
        Dim parms() As SqlParameter = New SqlParameter(5) {}

        parms(0) = New SqlParameter("@userCode", SqlDbType.VarChar, 50)
        parms(0).Value = HttpContext.Current.Session("userCode")

        parms(1) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        parms(1).Value = HttpContext.Current.Session("empCode")

        parms(2) = New SqlParameter("@msg", SqlDbType.VarChar, 8000)
        parms(2).Value = msg

        parms(3) = New SqlParameter("@remarks", SqlDbType.VarChar, 255)
        parms(3).Value = remarks

        parms(4) = New SqlParameter("@id", SqlDbType.Int)
        parms(4).Value = id

        parms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        parms(5).Value = HttpContext.Current.Session("BranchCode")

        rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateApprovedMsg", parms)
        Return rowseffected
    End Function

End Class
