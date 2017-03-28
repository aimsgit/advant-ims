Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLInstitute
    Shared Function GetInstituteDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInstitute")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function Rpt_CenterEmpStdCount(ByVal InstCode As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@InstCode", SqlDbType.VarChar)
        arParms(0).Value = InstCode

        arParms(1) = New SqlParameter("@Fromdate", SqlDbType.DateTime)
        arParms(1).Value = Fromdate

        arParms(2) = New SqlParameter("@Todate", SqlDbType.DateTime)
        arParms(2).Value = Todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_CenterStdEmpCount", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_EmailSMSCount(ByVal InstCode As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Inst", SqlDbType.VarChar)
        arParms(0).Value = InstCode

        arParms(1) = New SqlParameter("@Fromdate", SqlDbType.DateTime)
        arParms(1).Value = Fromdate

        arParms(2) = New SqlParameter("@Todate", SqlDbType.DateTime)
        arParms(2).Value = Todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_EmailSMSCount", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_EmailSMSCountAll(ByVal InstCode As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Inst", SqlDbType.VarChar)
        arParms(0).Value = InstCode

        arParms(1) = New SqlParameter("@Fromdate", SqlDbType.DateTime)
        arParms(1).Value = Fromdate

        arParms(2) = New SqlParameter("@Todate", SqlDbType.DateTime)
        arParms(2).Value = Todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_EmailSMSCountAll", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
