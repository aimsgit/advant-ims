Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLFeeStructDup
    Shared Function GetFeeStructureDuplicate(ByVal f As feeStructureE) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim Parms() As SqlParameter = New SqlParameter(7) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Parms(2) = New SqlParameter("@AcademicYear_id", SqlDbType.Int)
        Parms(2).Value = f.AcademicYear_id

        Parms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(3).Value = f.batchID

        Parms(4) = New SqlParameter("@Semester_ID", SqlDbType.Int)
        Parms(4).Value = f.Semester_ID

        Parms(5) = New SqlParameter("@Category", SqlDbType.Int)
        Parms(5).Value = f.CategoryID

        Parms(6) = New SqlParameter("@FeeHead_ID", SqlDbType.Int)
        Parms(6).Value = f.Feehead_ID

        Parms(7) = New SqlParameter("@id", SqlDbType.Int)
        Parms(7).Value = f.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateFeeStructure", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetFeeStructureDuplicateNew(ByVal f As feeStructureE) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim Parms() As SqlParameter = New SqlParameter(4) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Parms(2) = New SqlParameter("@AcademicYear_id", SqlDbType.Int)
        Parms(2).Value = f.AcademicYear_id

        Parms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(3).Value = f.batchID

        Parms(4) = New SqlParameter("@CategoryID", SqlDbType.Int)
        Parms(4).Value = f.CategoryID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateFeeStructureNew", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
