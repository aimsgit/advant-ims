Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class DLRptDistrictwiseStudentCount
    Shared Function insertBranchCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranchComboDistrictMinistry", arParms)
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Public Function Rpt_DistrictwiseDashboard(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_DistrictwiseStudentCount_Dashboard", Parms)
            'Old Procedure Name : Rpt_Streamwise_Enrol_Dashboard
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
