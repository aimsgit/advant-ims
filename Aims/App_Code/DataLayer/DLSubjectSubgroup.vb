Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLSubjectSubgroup
    Public Function GetSubjectCombofromBatch(ByVal BatchID As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(0).Value = BatchID
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_NewSubjectCombofrombatch", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal EL As ELSubjectSubgrp) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@SubGrp_Id", SqlDbType.Int)
        arParms(1).Value = EL.SubGrpId

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@Batch_Id", SqlDbType.Int)
        arParms(4).Value = EL.BatchId

        arParms(5) = New SqlParameter("@Semester_Id", SqlDbType.Int)
        arParms(5).Value = EL.Sem_Id

        arParms(6) = New SqlParameter("@Subject_Id", SqlDbType.Int)
        arParms(6).Value = EL.Subjectid

        arParms(7) = New SqlParameter("@Faculty_Id", SqlDbType.Int)
        arParms(7).Value = EL.Emp_Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertSubjectSubgrp", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    
    Shared Function GetGridData(ByVal EL As ELSubjectSubgrp) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id

        arParms(3) = New SqlParameter("@Faculty_Id", SqlDbType.Int)
        arParms(3).Value = EL.Emp_Id

        arParms(4) = New SqlParameter("@Batch_Id", SqlDbType.Int)
        arParms(4).Value = EL.BatchId

        arParms(5) = New SqlParameter("@Semester_Id", SqlDbType.Int)
        arParms(5).Value = EL.Sem_Id

        arParms(6) = New SqlParameter("@Subject_Id", SqlDbType.Int)
        arParms(6).Value = EL.Subjectid

        

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSubjectSugrp", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
   
    Shared Function Update(ByVal EL As ELSubjectSubgrp) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@SubGrp_Id", SqlDbType.Int)
        arParms(1).Value = EL.SubGrpId

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@Batch_Id", SqlDbType.Int)
        arParms(4).Value = EL.BatchId

        arParms(5) = New SqlParameter("@Semester_Id", SqlDbType.Int)
        arParms(5).Value = EL.Sem_Id

        arParms(6) = New SqlParameter("@Subject_Id", SqlDbType.Int)
        arParms(6).Value = EL.Subjectid

        arParms(7) = New SqlParameter("@Faculty_Id", SqlDbType.Int)
        arParms(7).Value = EL.Emp_Id

        arParms(8) = New SqlParameter("@id", SqlDbType.Int)
        arParms(8).Value = EL.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateSubjectSubgrp", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal EL As ELSubjectSubgrp) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteSubjectSubgrpFacultyMapping", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal El As ELSubjectSubgrp) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = El.id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch_Id", SqlDbType.Int)
        arParms(2).Value = El.BatchId

        arParms(3) = New SqlParameter("@Semester_Id", SqlDbType.Int)
        arParms(3).Value = El.Sem_Id

        arParms(4) = New SqlParameter("@Subject_Id", SqlDbType.Int)
        arParms(4).Value = El.Subjectid

        arParms(5) = New SqlParameter("@SubGrp_Id", SqlDbType.Int)
        arParms(5).Value = El.SubGrpId

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateSubjectSubgrp", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
End Class
