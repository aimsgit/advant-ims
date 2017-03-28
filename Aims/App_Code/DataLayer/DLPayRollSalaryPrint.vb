Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLPayRollSalaryPrint
    Shared Function ddlYear() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_DDLYearPrint]")
        Return ds.Tables(0)
    End Function
    Shared Function ddlMonth() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_DDLMonthPrint]")
        Return ds.Tables(0)
    End Function
    Shared Function ddlBank() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Params() As SqlParameter = New SqlParameter(0) {}
        Dim ds As DataSet
        Params(0) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
        Params(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_DDLBankPrint]", Params)
        Return ds.Tables(0)
    End Function
    Shared Function GridViewLoadData(ByVal month As String, ByVal year As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Params() As SqlParameter = New SqlParameter(2) {}
        Dim ds As DataSet
        Params(0) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
        Params(0).Value = HttpContext.Current.Session("BranchCode")

        Params(1) = New SqlParameter("@Month", Data.SqlDbType.VarChar, 50)
        Params(1).Value = month

        Params(2) = New SqlParameter("@Year", Data.SqlDbType.VarChar, 50)
        Params(2).Value = year

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetPayRollSalaryDetails]", Params)
        Return ds.Tables(0)
    End Function
    Shared Function ViewChequeNo(ByVal month As String, ByVal year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Month", Data.SqlDbType.VarChar, 50)
            Parms(1).Value = month

            Parms(2) = New SqlParameter("@Year", Data.SqlDbType.VarChar, 50)
            Parms(2).Value = year

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetPayRollSalaryDetails]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateChequeNo(ByVal month As String, ByVal year As String, ByVal FromCheque As Integer, ByVal ChequeDate As DateTime, ByVal bank As String, ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar)
        arParms(0).Value = month

        arParms(1) = New SqlParameter("@Year", SqlDbType.VarChar)
        arParms(1).Value = year

        arParms(2) = New SqlParameter("@ChequeNo", SqlDbType.Int)
        arParms(2).Value = FromCheque

        arParms(3) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
        arParms(3).Value = ChequeDate

        arParms(4) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(4).Value = Id

        arParms(5) = New SqlParameter("@BankCode", SqlDbType.Int)
        arParms(5).Value = bank

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateChequeNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ClearGenerateChequeNo(ByVal month As String, ByVal year As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@month", SqlDbType.VarChar)
        arParms(0).Value = month

        arParms(1) = New SqlParameter("@year", SqlDbType.VarChar)
        arParms(1).Value = year

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ClearGenerateChequeNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CountRecordsChequeNo(ByVal month As String, ByVal year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@Month", SqlDbType.VarChar)
            Parms(0).Value = month

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar)
            Parms(1).Value = year


            Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CountRecordsChequeNo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RecordsGenChequeNo(ByVal month As String, ByVal year As String) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@Month", SqlDbType.VarChar)
            Parms(0).Value = month

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar)
            Parms(1).Value = year


            Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CountRecordsChequeNo", Parms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function LockGenerateChequeNo(ByVal month As String, ByVal year As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar)
        arParms(0).Value = month

        arParms(1) = New SqlParameter("@Year", SqlDbType.VarChar)
        arParms(1).Value = year

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_LockGenerateChequeNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UnlockChequeNo(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetUnlockChequeNo", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function UnLockGenerateChequeNo(ByVal month As String, ByVal year As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar)
        arParms(0).Value = month

        arParms(1) = New SqlParameter("@Year", SqlDbType.VarChar)
        arParms(1).Value = year

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UnLockGenerateChequeNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CheckChequeNoLockStatus(ByVal month As String, ByVal year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@Month", SqlDbType.VarChar)
            Parms(0).Value = month

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar)
            Parms(1).Value = year

            Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckChequeNoLockStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPrintPath() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        Dim ds As New DataSet

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetPayrollChequePrintPath")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
End Class
