Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLEarnDed
    Public Shared Function Insert(ByVal El As ELEarnDed) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Description", SqlDbType.VarChar, 500)
        arParms(0).Value = El.Description

        arParms(1) = New SqlParameter("@SubDescription", SqlDbType.VarChar, 500)
        arParms(1).Value = El.SubDescription

        arParms(2) = New SqlParameter("@EarnDedCode", SqlDbType.VarChar, 50)
        arParms(2).Value = El.EarnDedCode


        arParms(3) = New SqlParameter("@EarnDedType", SqlDbType.VarChar)
        arParms(3).Value = El.EarnDedType


        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Office")
        arParms(8) = New SqlParameter("@Taxable", SqlDbType.VarChar)
        arParms(8).Value = El.Taxable
        arParms(9) = New SqlParameter("@PFApplicable", SqlDbType.VarChar)
        arParms(9).Value = El.PFApplicable
        arParms(10) = New SqlParameter("@StopSalary", SqlDbType.VarChar, 2)
        arParms(10).Value = El.StopSalary
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertEarnDed", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetGridData(ByVal EL As ELEarnDed) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id

        arParms(3) = New SqlParameter("@EarnDedCode", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.EarnDedCode




        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEarnDed", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal EL As ELEarnDed) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteEarnDed", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As ELEarnDed) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = EL.id

        arParms(2) = New SqlParameter("@Description", SqlDbType.VarChar, 500)
        arParms(2).Value = EL.Description

        arParms(3) = New SqlParameter("@SubDescription", SqlDbType.VarChar, 500)
        arParms(3).Value = EL.SubDescription

        arParms(4) = New SqlParameter("@EarnDedCode", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.EarnDedCode


        arParms(5) = New SqlParameter("@EarnDedType", SqlDbType.VarChar)
        arParms(5).Value = EL.EarnDedType

        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")
        arParms(8) = New SqlParameter("@Taxable", SqlDbType.VarChar)
        arParms(8).Value = EL.Taxable
        arParms(9) = New SqlParameter("@PFApplicable", SqlDbType.VarChar)
        arParms(9).Value = EL.PFApplicable

        arParms(10) = New SqlParameter("@StopSalary", SqlDbType.VarChar, 2)
        arParms(10).Value = EL.StopSalary
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateEarnDed", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetDuplData(ByVal El As ELEarnDed) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@code", SqlDbType.VarChar, 100)
        arParms(2).Value = El.EarnDedCode
        arParms(3) = New SqlParameter("@Type", SqlDbType.VarChar, 100)
        arParms(3).Value = El.EarnDedType

        arParms(4) = New SqlParameter("@id", SqlDbType.Int)
        arParms(4).Value = El.id

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateEarnDed", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
