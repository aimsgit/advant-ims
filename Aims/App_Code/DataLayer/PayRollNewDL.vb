Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class PayRollNewDL
    Shared Function EmployeeCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EmployeeList", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function EarningDeduction() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EarningDeduction", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function Insert(ByVal EL As PayRollNewEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(0).Value = EL.EmpId

        arParms(1) = New SqlParameter("@EarningDeduction", SqlDbType.Int)
        arParms(1).Value = EL.EarningDeduction

        arParms(2) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(2).Value = EL.Amount

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")

        arParms(7) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(7).Value = EL.FromDate

        arParms(8) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(8).Value = EL.ToDate

        arParms(9) = New SqlParameter("@StopSalary", SqlDbType.VarChar, 2)
        arParms(9).Value = EL.StopSalary


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_SavePayRollDetails]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayGridview(ByVal Id As Integer, ByVal EmpId As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim rowsAffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(3) {}
        Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(0).Value = Id


        Params(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(1).Value = HttpContext.Current.Session("BranchCode")

        Params(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(2).Value = HttpContext.Current.Session("Office")

        Params(3) = New SqlParameter("@EmpId", SqlDbType.Int)
        Params(3).Value = EmpId

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "NewDisplayParollDetails", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function Update(ByVal EL As PayRollNewEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(0).Value = EL.EmpId

        arParms(1) = New SqlParameter("@EarningDeduction", SqlDbType.VarChar, (50))
        arParms(1).Value = EL.EarningDeduction

        arParms(2) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(2).Value = EL.Amount

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@id", Data.SqlDbType.Int)
        arParms(6).Value = EL.Id

        arParms(7) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(7).Value = EL.FromDate

        arParms(8) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(8).Value = EL.ToDate

        arParms(9) = New SqlParameter("@StopSalary", SqlDbType.VarChar, 2)
        arParms(9).Value = EL.StopSalary

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePayRollDetailsNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Delete(ByVal EL As PayRollNewEL) As Integer
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

    Dim arParms() As SqlParameter = New SqlParameter(1) {}
    Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeletePayRllDetailsNew", arParms)
        Return rowsAffected
    End Function

    Shared Function GetDuplicatePayrollDetailsNew(ByVal El As PayRollNewEL) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(1).Value = El.EmpId

        arParms(2) = New SqlParameter("@EarningDeduction", SqlDbType.Int)
        arParms(2).Value = El.EarningDeduction


        arParms(3) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(3).Value = El.Id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetNewDuplicatePayrollDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function DisplayGridviewDeduction(ByVal Id As Integer, ByVal EmpId As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim rowsAffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(3) {}
        Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(0).Value = Id


        Params(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(1).Value = HttpContext.Current.Session("BranchCode")

        Params(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(2).Value = HttpContext.Current.Session("Office")

        Params(3) = New SqlParameter("@EmpId", SqlDbType.Int)
        Params(3).Value = EmpId

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "NewDisplayParollDetailsDeduction", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
