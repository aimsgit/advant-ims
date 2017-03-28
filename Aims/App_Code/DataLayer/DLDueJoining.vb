Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLDueJoining
    Shared Function ddlYear() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_DDLYear]")
        Return ds.Tables(0)
    End Function
    Shared Function GetDueJoining(ByVal Months As Integer, ByVal Year As Integer, ByVal Based As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Month", SqlDbType.Int)
        arParms(1).Value = Months

        arParms(2) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(2).Value = Year

        arParms(3) = New SqlParameter("@Based", SqlDbType.VarChar, 5)
        arParms(3).Value = Based

        arParms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("Office")
        'arParms(5) = New SqlParameter("@Criteria", SqlDbType.VarChar, 5)
        'arParms(5).Value = Criteria


        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DueForJoining", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function GetEmpEligibilie(ByVal Months As Integer, ByVal Year As Integer, ByVal Based As String, ByVal Criteria As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Month", SqlDbType.Int)
        arParms(1).Value = Months

        arParms(2) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(2).Value = Year

        arParms(3) = New SqlParameter("@Based", SqlDbType.VarChar, 5)
        arParms(3).Value = Based

        arParms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("Office")

        arParms(5) = New SqlParameter("@Criteria", SqlDbType.VarChar, 5)
        arParms(5).Value = Criteria
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpEligibile", arParms)
        Return ds.Tables(0)

    End Function
End Class
