Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLSubjectSubGrpMapping
    Public Function GetSubjectSubGrpCombo(ByVal Subject As Integer, ByVal Batch As Integer, ByVal Semester As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(0).Value = Subject
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpId")
        arParms(4) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@UserRole", SqlDbType.NVarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserRole")
        arParms(6) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(6).Value = HttpContext.Current.Session("DeptId")
        arParms(7) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(7).Value = Batch
        arParms(8) = New SqlParameter("@semester", SqlDbType.Int)
        arParms(8).Value = Semester

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_SubjectSubgrpCombo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetSubjectSubGrpComboAll(ByVal Subject As Integer, ByVal Batch As Integer, ByVal Semester As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(0).Value = Subject
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpId")
        arParms(4) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserRole")
        arParms(6) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(6).Value = HttpContext.Current.Session("DeptId")
        arParms(7) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(7).Value = Batch
        arParms(8) = New SqlParameter("@semester", SqlDbType.Int)
        arParms(8).Value = Semester

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_SubjectSubgrpComboAll", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetSubjectSubGrpCombo1() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_SubjectSubgrpCombo1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
   
    Shared Function generate(ByVal EL As ELSubjectSubGrpMapping) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}

        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = EL.SubjectId
        param(4) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("EmpCode")
        param(5) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("UserCode")
        param(6) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("BranchCode")


        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SubjectSubgrpMap", param)
        Return AffectedRows
    End Function
    Shared Function generateIndstd(ByVal EL As ELSubjectSubGrpMapping) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(7) {}

        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = EL.SubjectId
        param(4) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("EmpCode")
        param(5) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("UserCode")
        param(6) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("BranchCode")
        param(7) = New SqlClient.SqlParameter("@Stdid", SqlDbType.Int)
        param(7).Value = EL.Stdid


        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SubjectSubgrpMapIndstd", param)
        Return AffectedRows
    End Function
    Shared Function getduplicate(ByVal EL As ELSubjectSubGrpMapping) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = EL.SubjectId

        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDuplicateSubjectSubGrpMapping]", param)
        Return ds.Tables(0)
    End Function
    Shared Function getduplicateInStd(ByVal EL As ELSubjectSubGrpMapping) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = EL.SubjectId

        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@Stdid", SqlDbType.Int)
        param(5).Value = EL.Stdid


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetIndStdDuplSubjSubGrpMap]", param)
        Return ds.Tables(0)
    End Function

    Shared Function clear(ByVal EL As ELSubjectSubGrpMapping) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = EL.SubjectId

        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
       

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_ClearSubGrpMmapping]", param)
        Return AffectedRows
    End Function

    Shared Function GetData(ByVal EL As ELSubjectSubGrpMapping) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = EL.SubjectId
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
      

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSubjectSubgrpMapping", param)
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ELSubjectSubGrpMapping, ByVal ID As String) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlClient.SqlParameter("@SubGrpid", SqlDbType.Int)
        param(0).Value = EL.Id
        param(1) = New SqlClient.SqlParameter("@SubGrp", SqlDbType.Int)
        param(1).Value = EL.SubuGrp
        param(2) = New SqlClient.SqlParameter("@ID", SqlDbType.VarChar, 1000)
        param(2).Value = ID
        param(3) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("EmpCode")
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")


        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateSubjectGrpMapping", param)
        Return AffectedRows
    End Function
    Shared Function Lock(ByVal EL As ELSubjectSubGrpMapping) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = EL.SubjectId
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        



        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_LockSubjectSubGrpMapping", param)
        Return AffectedRows
    End Function

    Shared Function CheckLock(ByVal EL As ELSubjectSubGrpMapping) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = EL.SubjectId
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckLockSubjectSubGrpMapping", param)
        Return ds.Tables(0)
    End Function
    Shared Function PostCheck(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetUnlockSubjectSubGroup", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function RptSubjSubgrpFacultyMap(ByVal BatchId As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet

     
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId ", SqlDbType.Int)
        arParms(1).Value = BatchId

        arParms(2) = New SqlParameter("@SemId ", SqlDbType.Int)
        arParms(2).Value = SemId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SubjSubgrpFacultyMap", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ChangeFlag(ByVal El As ELSubjectSubGrpMapping) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = El.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_DelStdFrmSubSubGrp]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function RptSubjSubgrpMap(ByVal SubjectId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(2).Value = SubjectId
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_SubjectSubgrp", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RptSubjSubgrpStudentMap(ByVal BatchId As Integer, ByVal SemesterId As Integer, ByVal SubjectId As Integer, ByVal SubjectSubGrpId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = BatchId
        arParms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
        arParms(3).Value = SemesterId
        arParms(4) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(4).Value = SubjectId
        arParms(5) = New SqlParameter("@SubjectSubGrpId", SqlDbType.Int)
        arParms(5).Value = SubjectSubGrpId
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_SubjSubgrpStudentMap", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    'Code By Jina
    Public Function GetSubjectSubGroupCombo(ByVal Subject As Integer, ByVal Batch As Integer, ByVal Semester As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(0).Value = Subject
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpId")
        arParms(4) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@UserRole", SqlDbType.NVarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserRole")
        arParms(6) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(6).Value = HttpContext.Current.Session("DeptId")
        arParms(7) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(7).Value = Batch
        arParms(8) = New SqlParameter("@semester", SqlDbType.Int)
        arParms(8).Value = Semester

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_SubjectSubgroupCombo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetSubjectSubGrpComboAllNew1(ByVal BranchCode As String, ByVal Subject As Integer, ByVal BatchId As Integer, ByVal SemId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(0).Value = Subject
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = BranchCode
        arParms(3) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpId")
        arParms(4) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserRole")
        arParms(6) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(6).Value = HttpContext.Current.Session("DeptId")
        arParms(7) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(7).Value = BatchId
        arParms(8) = New SqlParameter("@semester", SqlDbType.Int)
        arParms(8).Value = SemId

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_SubjectSubgrpComboAllNew1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
