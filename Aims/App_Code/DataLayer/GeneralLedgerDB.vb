Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class GeneralLedgerDB
    'Shared Function GetGeneralLedgRpt() As System.Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet

    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}
    '    arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
    '    arParms(0).Value = HttpContext.Current.Session("InstituteID")

    '    arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
    '    arParms(1).Value = HttpContext.Current.Session("BranchID")

    '    arParms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
    '    arParms(2).Value = CDate(HttpContext.Current.Session("FinStartDate"))

    '    arParms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
    '    arParms(3).Value = CDate(HttpContext.Current.Session("FinEndDate"))

    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_DayBook_Qry", arParms)
    '    Return ds.Tables(0)
    'End Function

    Shared Function GetGeneralLedgRpt(ByVal AH As Integer, ByVal PR As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal AC As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@AccountGroup", SqlDbType.Int)
        arParms(4).Value = AH

        arParms(5) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(5).Value = PR

        arParms(6) = New SqlParameter("@AC", SqlDbType.Int)
        arParms(6).Value = AC


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_DayBook_Qry", arParms)
        Return ds.Tables(0)
    End Function
End Class
