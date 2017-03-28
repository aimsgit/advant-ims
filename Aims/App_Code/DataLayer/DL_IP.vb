Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DL_IP
    Shared Function Insert(ByVal IP As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@IPaddr", SqlDbType.VarChar, 50)
        arParms(0).Value = IP

        'arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")

        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "proc_AddIP", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal IP_ID As Integer, ByVal IP As String) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@IPaddr", SqlDbType.VarChar, 50)
        arParms(0).Value = IP

        'arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")

        arParms(2) = New SqlParameter("@IP_ID", SqlDbType.VarChar, 50)
        arParms(2).Value = IP_ID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateIP", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CheckDuplicate(ByVal IP As String, ByVal IP_Id As Integer) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@IP", SqlDbType.VarChar, 50)
        Para(0).Value = IP
        Para(1) = New SqlParameter("@IP_Id", SqlDbType.Int)
        Para(1).Value = IP_Id
        'Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_getipduplicate", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetIP(ByVal IP_ID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@IP", SqlDbType.Int)
        arParms(0).Value = IP_ID
        'arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getip", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Delete(ByVal IP_ID As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@IP", SqlDbType.Int)
        arParms.Value = IP_ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_deleteip", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetCountry() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlCountry")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function rptIPLocation(ByVal Country As String, ByVal User As String, ByVal Sdate As DateTime, ByVal Edate As DateTime) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        arParms(0).Value = Country

        arParms(1) = New SqlParameter("@User", SqlDbType.VarChar, 10)
        arParms(1).Value = User

        arParms(2) = New SqlParameter("@Sdate", SqlDbType.DateTime)
        arParms(2).Value = Sdate

        arParms(3) = New SqlParameter("@Edate", SqlDbType.DateTime)
        arParms(3).Value = Edate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_rptIP", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
