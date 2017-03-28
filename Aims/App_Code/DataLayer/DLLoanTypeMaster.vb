Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class DLLoanTypeMaster

    Shared Function Insert(ByVal EL As ELLoanTypeMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@LoanCode", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.LoanCode

        arParms(2) = New SqlParameter("@LoanType", SqlDbType.VarChar, 250)
        arParms(2).Value = EL.LoanType

        arParms(3) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("office")
        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_InsertLoanDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetGridData(ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal EL As ELLoanTypeMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.ID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteLoanDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As ELLoanTypeMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = EL.id

        arParms(2) = New SqlParameter("@LoanCode", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.LoanCode

        arParms(3) = New SqlParameter("@LoanType", SqlDbType.VarChar, 250)
        arParms(3).Value = EL.LoanType

        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateLoanTypeDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetDuplData(ByVal El As ELLoanTypeMaster) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@LoanCode", SqlDbType.VarChar, 100)
        arParms(2).Value = El.LoanCode

        arParms(3) = New SqlParameter("@id", SqlDbType.Int)
        arParms(3).Value = El.id

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateLoanCode", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetLoanCode(ByVal empid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")
        Parms(1) = New SqlParameter("@Empid", SqlDbType.Int)
        Parms(1).Value = empid


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLaonCode", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetEmployeeCombo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmployeeCode", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class

