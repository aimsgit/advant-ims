Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class BatchSemesterMapDB
    Shared Function getBatch() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchCombo", arParms)
        Return ds
    End Function

    Shared Function Update(ByVal BSM As BatchSemesterMap) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@PKID", SqlDbType.Int)
        arParms(0).Value = BSM.PKID

        arParms(1) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(1).Value = BSM.StartDate

        arParms(2) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(2).Value = BSM.EndDate

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_updateBatchSemMapping", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal BSM As BatchSemesterMap) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@PKID", SqlDbType.Int)
        arParms(0).Value = BSM.PKID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_Delete", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function getBatchSemMap(ByVal BSM As BatchSemesterMap) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(0).Value = BSM.BatchID
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBatchSemesterMapping", arParms)
        Return ds
    End Function
    'Code for get Batch Semester Map Report By Nitin 09/05/2012

    Shared Function RptBatchSemesterMap(ByVal Batch As Integer, ByVal Aid As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = Batch
        arParms(3) = New SqlParameter("@Aid", SqlDbType.Int)
        arParms(3).Value = Aid
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptBatchSemesterMap", arParms)
        Return ds.Tables(0)
    End Function

End Class
