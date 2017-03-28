Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLBatchLot
    Shared Function Insert(ByVal EL As Mfg_ELBatchLot) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Batch", SqlDbType.VarChar, 250)
        arParms(1).Value = EL.Batch

        arParms(2) = New SqlParameter("@ProductId", SqlDbType.Int)
        arParms(2).Value = EL.Productid

        arParms(3) = New SqlParameter("@Mfg_Date", SqlDbType.DateTime)
        arParms(3).Value = EL.MfgDate

        arParms(4) = New SqlParameter("@ProcessId", SqlDbType.Int)
        arParms(4).Value = EL.Processid

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = EL.Remarks

        arParms(8) = New SqlParameter("@StockIssueId", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.Issueid
        arParms(9) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertBatchLot", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetGridData(ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = Id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetBatchLot", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function Update(ByVal EL As Mfg_ELBatchLot) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Batch", SqlDbType.VarChar, 250)
        arParms(1).Value = EL.Batch

        arParms(2) = New SqlParameter("@ProductId", SqlDbType.Int)
        arParms(2).Value = EL.Productid

        arParms(3) = New SqlParameter("@Mfg_Date", SqlDbType.DateTime)
        arParms(3).Value = EL.MfgDate

        arParms(4) = New SqlParameter("@ProcessId", SqlDbType.Int)
        arParms(4).Value = EL.Processid

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = EL.Remarks

        arParms(8) = New SqlParameter("@StockIssueId", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.Issueid

        arParms(9) = New SqlParameter("@id", SqlDbType.Int)
        arParms(9).Value = EL.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateBatchLot", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal EL As Mfg_ELBatchLot) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteBatchLot", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function GetDuplicateShift(ByVal EL As Mfg_ELBatchLot) As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Shift_Desc", SqlDbType.VarChar, 250)
        para(1).Value = EL.Batch

        para(2) = New SqlParameter("@Start_Time", SqlDbType.DateTime)
        para(2).Value = EL.Productid

        para(3) = New SqlParameter("@id", SqlDbType.Int)
        para(3).Value = EL.id

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_DuplicateBatchLot", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
