Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class BRSDB
    Shared Function GetBRS(ByVal el As BRSEntity) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}

        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@Table", SqlDbType.VarChar, 2)
        para(2).Value = el.table

        para(3) = New SqlParameter("@Flag", SqlDbType.VarChar, 2)
        para(3).Value = el.StatusFlag

        para(4) = New SqlParameter("@FromDate", SqlDbType.Date)
        para(4).Value = el.FromDate

        para(5) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(5).Value = el.ToDate

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBRSDetls", para)
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal el As BRSEntity) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Status", SqlDbType.VarChar, 2)
        arParms(0).Value = el.StatusFlag
        arParms(1) = New SqlParameter("@table", SqlDbType.VarChar, 2)
        arParms(1).Value = el.table
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.ID
        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")
        If el.Clearing_Date = "1/1/9100" Then
            arParms(4) = New SqlParameter("@Clearing_Date", SqlDbType.DateTime)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@Clearing_Date", SqlDbType.DateTime)
            arParms(4).Value = el.Clearing_Date

        End If
        
        If el.ChequeBounce_Date = "1/1/9100" Then
            arParms(5) = New SqlParameter("@ChequeBounce_Date", SqlDbType.DateTime)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@ChequeBounce_Date", SqlDbType.DateTime)
            arParms(5).Value = el.ChequeBounce_Date

        End If
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBRSDtls", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetBRSRpt() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("InstituteID")
        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BranchID")
        arParms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(2).Value = CDate(HttpContext.Current.Session("FinStartDate"))
        arParms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(3).Value = CDate(HttpContext.Current.Session("FinEndDate"))
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_BRS_RPT", arParms)
        Return ds
    End Function
    Public Function GetBRSReport(ByVal StartDate As Date, ByVal EndDate As Date, ByVal BankId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}

        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@StartDate", SqlDbType.Date)
        para(2).Value = StartDate

        para(3) = New SqlParameter("@EndDate", SqlDbType.Date)
        para(3).Value = EndDate

        para(4) = New SqlParameter("@Bank_ID", SqlDbType.Int)
        para(4).Value = BankId

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Rpt_BankReconciliation", para)
        Return ds.Tables(0)
    End Function
End Class
