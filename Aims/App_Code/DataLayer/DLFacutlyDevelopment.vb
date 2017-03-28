Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLFacutlyDevelopment
    Shared Function GetDeptType() As System.Data.DataTable
        'Function for Inserting the data into DDL. By: Niraj 26-03-2013 .
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLDeptType", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function Insert(ByVal El As ELFacutlyDevelopment) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(0).Value = El.DeptId

        arParms(1) = New SqlParameter("@ProgramName", SqlDbType.VarChar, 250)
        arParms(1).Value = El.Program_Name

        arParms(2) = New SqlParameter("@ConductedBy", SqlDbType.VarChar, 250)
        arParms(2).Value = El.ConductedBy

        arParms(3) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(3).Value = El.FromDate

        arParms(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(4).Value = El.ToDate

        arParms(5) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(5).Value = El.Remarks

        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")

        arParms(9) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertFacultyDevlopment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal El As ELFacutlyDevelopment) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(0).Value = El.DeptId

        arParms(1) = New SqlParameter("@ProgramName", SqlDbType.VarChar, 250)
        arParms(1).Value = El.Program_Name

        arParms(2) = New SqlParameter("@ConductedBy", SqlDbType.VarChar, 250)
        arParms(2).Value = El.ConductedBy

        arParms(3) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(3).Value = El.FromDate

        arParms(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(4).Value = El.ToDate

        arParms(5) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(5).Value = El.Remarks

        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")

        arParms(9) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(9).Value = El.ID

        arParms(10) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateFacultyDevelopment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayGridValue(ByVal El As ELFacutlyDevelopment) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.ID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetFacultyDevelopment", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal EL As ELFacutlyDevelopment) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.ID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteFacultyDevelopment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function RptGetFacultyDevelopment(ByVal Dept As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@DeptID", SqlDbType.NVarChar, 50)
        arParms(2).Value = Dept

        arParms(3) = New SqlParameter("@FromDate", SqlDbType.Date)
        arParms(3).Value = FromDate

        arParms(4) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(4).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_FDR", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetDeptTypeAll() As System.Data.DataTable
        'Function for Inserting the data into DDL. By: Niraj 27-03-2013 .
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlDepartmentReport", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDeptTypeAllAICTE() As System.Data.DataTable
        'Function for Inserting the data into DDL. By: Niraj 27-03-2013 .
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlDepartmentReportAICTE", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class