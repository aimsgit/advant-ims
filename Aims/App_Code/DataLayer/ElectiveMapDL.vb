Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ElectiveMapDL
    Dim EL As New UserRequestE
    Shared Function generate(ByVal EL As ElectiveMapEL) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(7) {}

        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@ElectiveId", SqlDbType.Int)
        param(3).Value = EL.ElectiveId
        param(4) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("EmpCode")
        param(5) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("UserCode")
        param(6) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("BranchCode")
        param(7) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(7).Value = HttpContext.Current.Session("Office")
        'param(8) = New SqlClient.SqlParameter("@ElecSubject", SqlDbType.Int)
        'param(8).Value = EL.SubjectId

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_GenerateElectiveMap]", param)
        Return AffectedRows
    End Function
    Shared Function generateInStd(ByVal EL As ElectiveMapEL) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(8) {}

        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@ElectiveId", SqlDbType.Int)
        param(3).Value = EL.ElectiveId
        param(4) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("EmpCode")
        param(5) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("UserCode")
        param(6) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("BranchCode")
        param(7) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(7).Value = HttpContext.Current.Session("Office")
        'param(8) = New SqlClient.SqlParameter("@ElecSubject", SqlDbType.Int)
        'param(8).Value = EL.SubjectId
        param(8) = New SqlClient.SqlParameter("@Stdid", SqlDbType.Int)
        param(8).Value = EL.Stdid
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_GenerateElectiveMapIndStd]", param)
        Return AffectedRows
    End Function
    Shared Function getduplicate(ByVal EL As ElectiveMapEL) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@ElectiveId", SqlDbType.Int)
        param(3).Value = EL.ElectiveId

        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(5).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDuplicateElectiveMap]", param)
        Return ds.Tables(0)
    End Function
    Shared Function RptElectivemap(ByVal Batch As Integer, ByVal Semester As Integer, ByVal ElecSubject As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlClient.SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Batch
        param(1) = New SqlClient.SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Semester
        param(2) = New SqlClient.SqlParameter("@ElecSubject", SqlDbType.Int)
        param(2).Value = ElecSubject
        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        param(4) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(4).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[RptElectiveMap]", param)
        Return ds.Tables(0)
    End Function
    Shared Function RptStudentCredit(ByVal Batch As Integer, ByVal Semester As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        param(0) = New SqlClient.SqlParameter("@batchid", SqlDbType.Int)
        param(0).Value = Batch
        param(1) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(1).Value = Semester
        param(2) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")
        param(3) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(3).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_StudentCredit]", param)
        Return ds.Tables(0)
    End Function

    Shared Function clear(ByVal EL As ElectiveMapEL) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@ElectiveId", SqlDbType.Int)
        param(3).Value = EL.ElectiveId
       
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(5).Value = HttpContext.Current.Session("Office")

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_ClearElectiveMap]", param)
        Return AffectedRows
    End Function

    Shared Function GetData(ByVal EL As ElectiveMapEL) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@ElectiveId", SqlDbType.Int)
        param(3).Value = EL.ElectiveId
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(5).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetElectiveMap]", param)
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ElectiveMapEL, ByVal ID As String) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        param(0) = New SqlClient.SqlParameter("@EMID", SqlDbType.VarChar, 1000)
        param(0).Value = ID

        param(1) = New SqlClient.SqlParameter("@SubjectId", SqlDbType.Int)
        param(1).Value = EL.SubjectId

        param(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("EmpCode")

        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")


        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateElectiveMap]", param)
        Return AffectedRows
    End Function
    Shared Function Lock(ByVal EL As ElectiveMapEL) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@ElectiveId", SqlDbType.Int)
        param(3).Value = EL.ElectiveId
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(5).Value = HttpContext.Current.Session("Office")



        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_LockElectiveMap]", param)
        Return AffectedRows
    End Function

    Shared Function CheckLock(ByVal EL As ElectiveMapEL) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@ElectiveId", SqlDbType.Int)
        param(3).Value = EL.ElectiveId
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(5).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CheckLockElectiveMap]", param)
        Return ds.Tables(0)
    End Function
    Shared Function PostCheck(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlClient.SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetUnlockElectiveMap", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function ChangeFlag(ByVal El As ElectiveMapEL) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = El.Id
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_DeleteStdFrmElectiveMap]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function getduplicateStd(ByVal EL As ElectiveMapEL) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}

        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@ElectiveId", SqlDbType.Int)
        param(3).Value = EL.ElectiveId

        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(5).Value = HttpContext.Current.Session("Office")

        param(6) = New SqlClient.SqlParameter("@Stdid", SqlDbType.Int)
        param(6).Value = EL.Stdid

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDuplicateElectiveMapStd]", param)
        Return ds.Tables(0)
    End Function
End Class
