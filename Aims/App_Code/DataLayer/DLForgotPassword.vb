Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLForgotPassword
    Shared Function GetforgotPass(ByVal RbId As Integer, ByVal userId As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        'arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(0).Value = HttpContext.Current.Session("BranchCode")
        'arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(0) = New SqlParameter("@RbId", SqlDbType.Int)
        arParms(0).Value = RbId
        arParms(1) = New SqlParameter("@userId", SqlDbType.VarChar, 50)
        arParms(1).Value = userId

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "GetforgotPassowrd", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function

    Shared Function InsertForgot(ByVal Name As String, ByVal UserName As String, ByVal Password As String, ByVal Email As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(4) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = "000000000000"
        Parms(1) = New SqlParameter("@Name", SqlDbType.VarChar, 50)
        Parms(1).Value = Name
        Parms(2) = New SqlParameter("@UserName", SqlDbType.VarChar, 50)
        Parms(2).Value = UserName
        Parms(3) = New SqlParameter("@Password", SqlDbType.VarChar, 50)
        Parms(3).Value = Password
        Parms(4) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        Parms(4).Value = Email

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_InsertForgot]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
End Class