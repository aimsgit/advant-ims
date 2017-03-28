Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLOpeningBalanceEntry
    Shared Function GetOpeningBalanceEntry(ByVal El As ELOpeningBalanceEntry) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.Id

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetOpeningBalanceEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal El As ELOpeningBalanceEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Account_Group", SqlDbType.Int)
        arParms(1).Value = El.Account_Group

        arParms(2) = New SqlParameter("@Account", SqlDbType.Int)
        arParms(2).Value = El.Account

        arParms(3) = New SqlParameter("@Account_Treatment", SqlDbType.Int)
        arParms(3).Value = El.Account_Treatment

       
        arParms(4) = New SqlParameter("@date", SqlDbType.Date)
        arParms(4).Value = El.Acct_date

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@Item", SqlDbType.VarChar, 200)
        arParms(7).Value = El.Item

        arParms(8) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(8).Value = El.Amount

        arParms(9) = New SqlParameter("@Bank", SqlDbType.Int)
        arParms(9).Value = El.Bank

        arParms(10) = New SqlParameter("@Remarks", SqlDbType.VarChar, 200)
        arParms(10).Value = El.Remarks

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertOpeningBalanceEntryintodayBook", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal El As ELOpeningBalanceEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(11) {}

       

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Account_Group", SqlDbType.Int)
        arParms(1).Value = El.Account_Group

        arParms(2) = New SqlParameter("@Account", SqlDbType.Int)
        arParms(2).Value = El.Account

        arParms(3) = New SqlParameter("@Account_Treatment", SqlDbType.Int)
        arParms(3).Value = El.Account_Treatment
        
        arParms(4) = New SqlParameter("@date", SqlDbType.Date)
        arParms(4).Value = El.Acct_date


        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@id", SqlDbType.Int)
        arParms(7).Value = El.Id

        arParms(8) = New SqlParameter("@Item", SqlDbType.VarChar, 200)
        arParms(8).Value = El.Item

        arParms(9) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(9).Value = El.Amount

        arParms(10) = New SqlParameter("@Bank", SqlDbType.Int)
        arParms(10).Value = El.Bank

        arParms(11) = New SqlParameter("@Remarks", SqlDbType.VarChar, 200)
        arParms(11).Value = El.Remarks


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateOpeningBalanceEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal ID As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@id", SqlDbType.Int)
        arParms.Value = ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteOpeningBalanceEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
