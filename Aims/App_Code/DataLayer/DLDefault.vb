Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DLDefault
    Shared Function GetOnlineUser() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("ID")
        Dim ds As New DataSet
        Try
            If (HttpContext.Current.Session("chat") = "Support") Then
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getOnlineUser", arParms)
            End If
            If (HttpContext.Current.Session("chat") = "User") Then
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getOnlineTech", arParms)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetOnlineTech() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("ID")
        Dim ds As New DataSet
        Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function AddTech(ByVal Username As String, ByVal Password As String) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Username", SqlDbType.VarChar, 50)
        arParms(0).Value = Username
        arParms(1) = New SqlParameter("@Password", SqlDbType.VarChar, 50)
        arParms(1).Value = Password
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_NewTech", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
