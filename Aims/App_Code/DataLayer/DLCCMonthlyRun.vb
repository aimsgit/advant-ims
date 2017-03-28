Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLCCMonthlyRun
    Public Function Clientcontractmonthlyrun(ByVal EL As ELCCMonthlyRun) As DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = EL.BranchCode
        para(1) = New SqlParameter("@FromMonth", SqlDbType.Int)
        para(1).Value = EL.FromMonth
        para(2) = New SqlParameter("@FromYear", SqlDbType.Int)
        para(2).Value = EL.FromYear
        para(3) = New SqlParameter("@ToMonth", SqlDbType.Int)
        para(3).Value = EL.ToMonth
        para(4) = New SqlParameter("@ToYear", SqlDbType.Int)
        para(4).Value = EL.ToYear
        para(5) = New SqlParameter("@ClientID", SqlDbType.VarChar, 50)
        para(5).Value = EL.ClientID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_Clientcontractmonthlyrun", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetClientcontractmonthlyrun(ByVal EL As ELCCMonthlyRun) As DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = EL.BranchCode
        para(1) = New SqlParameter("@FromMonth", SqlDbType.Int)
        para(1).Value = EL.FromMonth
        para(2) = New SqlParameter("@FromYear", SqlDbType.Int)
        para(2).Value = EL.FromYear
        para(3) = New SqlParameter("@ToMonth", SqlDbType.Int)
        para(3).Value = EL.ToMonth
        para(4) = New SqlParameter("@ToYear", SqlDbType.Int)
        para(4).Value = EL.ToYear
        para(5) = New SqlParameter("@ClientID", SqlDbType.VarChar, 50)
        para(5).Value = EL.ClientID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetClientcontractmonthlyrun", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function AutoGenerateNo(ByVal EL As ELCCMonthlyRun) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetClientCInvoiceNo", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function UpdateClientcontractmonthlyrun(ByVal EL As ELCCMonthlyRun, ByVal status As String, ByVal status1 As String) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@ID", SqlDbType.Int)
        para(0).Value = EL.id
        para(1) = New SqlParameter("@Status", SqlDbType.VarChar, 2)
        para(1).Value = status
        para(2) = New SqlParameter("@InvoiceNo", SqlDbType.VarChar, 50)
        para(2).Value = EL.InvoiceNo
        para(3) = New SqlParameter("@Status1", SqlDbType.VarChar, 2)
        para(3).Value = status1
        Try
            ds = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_UpdateClientcontractmonthlyrun", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function UpdateClientcontractInvoiceNo(ByVal EL As ELCCMonthlyRun) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@ID", SqlDbType.Int)
        para(0).Value = EL.id
        para(1) = New SqlParameter("@InvoiceNo", SqlDbType.VarChar, 50)
        para(1).Value = EL.InvoiceNo
        Try
            ds = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_UpdateClientInvoiceNo", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    Shared Function chkactive(ByVal EL As ELCCMonthlyRun) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(5) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = EL.BranchCode
            arParms(1) = New SqlParameter("@Fromdate", SqlDbType.VarChar, 20)
            arParms(1).Value = EL.FromMonth
            arParms(2) = New SqlParameter("@ToDate", SqlDbType.VarChar, 20)
            arParms(2).Value = EL.ToMonth
            arParms(3) = New SqlParameter("@Yearfrom", SqlDbType.VarChar, 20)
            arParms(3).Value = EL.FromYear
            arParms(4) = New SqlParameter("@YearTo", SqlDbType.VarChar, 20)
            arParms(4).Value = EL.ToYear
            arParms(5) = New SqlParameter("@ClientId", SqlDbType.VarChar, 50)
            arParms(5).Value = EL.ClientID
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_checkactive]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function CountData(ByVal EL As ELCCMonthlyRun) As Data.DataSet
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = EL.BranchCode
        para(1) = New SqlParameter("@FromMonth", SqlDbType.Int)
        para(1).Value = EL.FromMonth
        para(2) = New SqlParameter("@FromYear", SqlDbType.Int)
        para(2).Value = EL.FromYear
        para(3) = New SqlParameter("@ToMonth", SqlDbType.Int)
        para(3).Value = EL.ToMonth
        para(4) = New SqlParameter("@ToYear", SqlDbType.Int)
        para(4).Value = EL.ToYear
        para(5) = New SqlParameter("@ClientID", SqlDbType.VarChar, 50)
        para(5).Value = EL.ClientID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "New_CheckLockMonthlyRun", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function LockSummary(ByVal EL As ELCCMonthlyRun) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim para() As SqlParameter = New SqlParameter(5) {}
            para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(0).Value = EL.BranchCode
            para(1) = New SqlParameter("@FromMonth", SqlDbType.Int)
            para(1).Value = EL.FromMonth
            para(2) = New SqlParameter("@FromYear", SqlDbType.Int)
            para(2).Value = EL.FromYear
            para(3) = New SqlParameter("@ToMonth", SqlDbType.Int)
            para(3).Value = EL.ToMonth
            para(4) = New SqlParameter("@ToYear", SqlDbType.Int)
            para(4).Value = EL.ToYear
            para(5) = New SqlParameter("@ClientID", SqlDbType.VarChar, 50)
            para(5).Value = EL.ClientID

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_LockAttenMonthlyRun]", para)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetunlockData(ByVal role As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(1).Value = role

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetUnlockMonthlyRun]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Unlock(ByVal EL As ELCCMonthlyRun) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim para() As SqlParameter = New SqlParameter(5) {}
            para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(0).Value = EL.BranchCode
            para(1) = New SqlParameter("@FromMonth", SqlDbType.Int)
            para(1).Value = EL.FromMonth
            para(2) = New SqlParameter("@FromYear", SqlDbType.Int)
            para(2).Value = EL.FromYear
            para(3) = New SqlParameter("@ToMonth", SqlDbType.Int)
            para(3).Value = EL.ToMonth
            para(4) = New SqlParameter("@ToYear", SqlDbType.Int)
            para(4).Value = EL.ToYear
            para(5) = New SqlParameter("@ClientID", SqlDbType.VarChar, 50)
            para(5).Value = EL.ClientID

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_UnlockAttenMonthlyRun]", para)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ClearInvoiceData(ByVal ClientId As String, ByVal BranchCode As String, ByVal FromDate As String, ByVal FromYear As String, ByVal ToDate As String, ByVal ToYear As String, ByVal InvoiceNo As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@ClientId", SqlDbType.VarChar, 50)
        arParms(0).Value = ClientId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = BranchCode

        arParms(2) = New SqlParameter("@FromDate", SqlDbType.VarChar, 50)
        arParms(2).Value = FromDate

        arParms(3) = New SqlParameter("@FromYear", SqlDbType.VarChar, 50)
        arParms(3).Value = FromDate

        arParms(4) = New SqlParameter("@InvoiceNo", SqlDbType.VarChar, 50)
        arParms(4).Value = InvoiceNo

        arParms(5) = New SqlParameter("@ToDate", SqlDbType.VarChar, 50)
        arParms(5).Value = ToDate

        arParms(6) = New SqlParameter("@ToYear", SqlDbType.VarChar, 50)
        arParms(6).Value = ToYear
        
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_ClearMonthlyRun]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CountData1(ByVal EL As ELCCMonthlyRun) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = EL.BranchCode
        para(1) = New SqlParameter("@FromMonth", SqlDbType.Int)
        para(1).Value = EL.FromMonth
        para(2) = New SqlParameter("@FromYear", SqlDbType.Int)
        para(2).Value = EL.FromYear
        para(3) = New SqlParameter("@ToMonth", SqlDbType.Int)
        para(3).Value = EL.ToMonth
        para(4) = New SqlParameter("@ToYear", SqlDbType.Int)
        para(4).Value = EL.ToYear
        para(5) = New SqlParameter("@ClientID", SqlDbType.VarChar, 50)
        para(5).Value = EL.ClientID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "New_CheckLockMonthlyRun", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
