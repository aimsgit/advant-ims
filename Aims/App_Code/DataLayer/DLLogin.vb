Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLLogin

    Shared Function GetImage() As Data.DataTable
        Dim ds As New DataSet
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetLoginFont")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetLoginFontColor() As Data.DataTable
        Dim ds As New DataSet
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetLoginFontColor")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function InsertIP(ByVal IP As String, ByVal Country As String, ByVal City As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}

        Parms(0) = New SqlParameter("@IPaddr", SqlDbType.VarChar, 50)
        Parms(0).Value = IP

        Parms(1) = New SqlParameter("@Country", SqlDbType.VarChar, 100)
        Parms(1).Value = Country

        Parms(2) = New SqlParameter("@City", SqlDbType.VarChar, 100)
        Parms(2).Value = City

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_InsertIP", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function UpdateIP(ByVal ID As Integer, ByVal Branchcode As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@ID", SqlDbType.Int)
        Parms(0).Value = ID

        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = Branchcode

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Update_IP", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function


    Shared Function CheckIP(ByVal IP As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@IP", SqlDbType.VarChar, 50)
        Parms(0).Value = IP

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_CheckIP", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetCourse(ByVal Batch As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        Parms(0).Value = Batch

        Parms(1) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getrptCourse", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Shared Function GetLogIn() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter() {}

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LoginReports", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
