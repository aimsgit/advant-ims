Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class DL_GenderwiseStudentAttendance
    Shared Function GetCourseName() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetCourseName", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function

    Shared Function SubjectComboAllDDL(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Courseid", SqlDbType.Int)
            Parms(2).Value = Courseid
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectSubjectAllDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SelectGenderwiseReport(ByVal course As Integer, ByVal subject As Integer, ByVal attdate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@course", SqlDbType.Int)
            Parms(2).Value = course

            Parms(3) = New SqlParameter("@subject", SqlDbType.Int)
            Parms(3).Value = subject

            Parms(4) = New SqlParameter("@AttDate", SqlDbType.DateTime)
            Parms(4).Value = attdate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GenderwisereportAttReport2", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SelectGenderwiseAttReport(ByVal course As Integer, ByVal subject As Integer, ByVal attdate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@course", SqlDbType.Int)
            Parms(2).Value = course

            Parms(3) = New SqlParameter("@subject", SqlDbType.Int)
            Parms(3).Value = subject

            Parms(4) = New SqlParameter("@AttDate", SqlDbType.DateTime)
            Parms(4).Value = attdate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GenderwisereportAtt", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
