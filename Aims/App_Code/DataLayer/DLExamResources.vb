Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient

Public Class DLExamResources
    Dim dt As New DataTable
    Dim query As String
    Dim ds As New DataSet

    Shared Function GetExamBatch() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ddlExambatch", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetExamBranch(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_ExamBatchCenter]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetResourceType(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ddlResourceType", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetResourceType1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ddlResourceTypeSelect", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetResourcename(ByVal Rid As String, ByVal Branchcode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = Branchcode

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Rid", SqlDbType.VarChar, 50)
            Parms(2).Value = Rid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_ddlResourceName]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetResourcename1(ByVal Rid As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Rid", SqlDbType.VarChar, 50)
            Parms(2).Value = Rid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_ddlResourceName]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Insert(ByVal EL As ELExamResources) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = EL.BatchNameId

        arParms(2) = New SqlParameter("@ResType", SqlDbType.VarChar, 100)
        arParms(2).Value = EL.ResTypeId

        arParms(3) = New SqlParameter("@ResName", SqlDbType.Int)
        arParms(3).Value = EL.ResNameId

        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@Capacity", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.Capacity

        arParms(7) = New SqlParameter("@FrmBranch", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Branchcode

        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "[Proc_InsertExamResorces]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetGridData(ByVal El As ELExamResources, ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = Id

        arParms(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(3).Value = El.BatchNameId

        arParms(4) = New SqlParameter("@ResType", SqlDbType.VarChar, 100)
        arParms(4).Value = El.ResTypeId

        arParms(5) = New SqlParameter("@ResName", SqlDbType.VarChar, 50)
        arParms(5).Value = El.ResNameId

        arParms(6) = New SqlParameter("@FrmBranch", SqlDbType.VarChar, 50)
        arParms(6).Value = El.Branchcode


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_ViewExamResources]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function CheckLockAttendance(ByVal id As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As String = ""

        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        Try
            Rowseffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "proc_CheckLockResources", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function LockAttendance(ByVal BatchNameId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@BatchNameId", SqlDbType.Int)
        param(0).Value = BatchNameId
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_LockAttendanceResources", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function GetGridDataRes(ByVal Rtype As String, ByVal Rname As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@ResType", SqlDbType.VarChar, 100)
        arParms(2).Value = Rtype

        arParms(3) = New SqlParameter("@ResName", SqlDbType.Int)
        arParms(3).Value = Rname

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetResourceAllocation1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getdata(ByVal StartTime As DateTime, ByVal EndTime As DateTime, ByVal Day As Integer, ByVal Rname As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@StartTime", SqlDbType.DateTime)
        arParms(2).Value = StartTime

        arParms(3) = New SqlParameter("@EndTime", SqlDbType.DateTime)
        arParms(3).Value = EndTime

        arParms(4) = New SqlParameter("@Day", SqlDbType.Int)
        arParms(4).Value = Day

        arParms(5) = New SqlParameter("@rname", SqlDbType.Int)
        arParms(5).Value = Rname



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetResource", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ELExamResources) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = EL.id

        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = EL.BatchNameId

        arParms(3) = New SqlParameter("@ResType", SqlDbType.VarChar, 100)
        arParms(3).Value = EL.ResTypeId

        arParms(4) = New SqlParameter("@ResName", SqlDbType.Int)
        arParms(4).Value = EL.ResNameId

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@Capacity", SqlDbType.VarChar, 100)
        arParms(7).Value = EL.Capacity

        arParms(8) = New SqlParameter("@FrmBranch", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.Branchcode
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateExamResorces]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal EL As ELExamResources) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        'Dim arParms As SqlParameter = New SqlParameter
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = EL.id
        'arParms = New SqlParameter("@id", SqlDbType.Int)

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_DeleteExamResorces]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetDuplData(ByVal El As ELExamResources) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = El.BatchNameId

        arParms(3) = New SqlParameter("@ResType", SqlDbType.VarChar, 100)
        arParms(3).Value = El.ResTypeId

        arParms(4) = New SqlParameter("@ResName", SqlDbType.Int)
        arParms(4).Value = El.ResNameId

        arParms(5) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(5).Value = El.id

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDuplicateExamRes]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetCapacityAutoFill(ByVal El As ELExamResources) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = El.Branchcode

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.Int)
            Parms(2).Value = El.id

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetExamResCapacity", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function publish(ByVal msg As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@msg", SqlDbType.VarChar, msg.Length)
        arParms(1).Value = msg

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")



        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "[Proc_PublishExamRes]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetGridData1(ByVal El As ELExamResources, ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = Id

        arParms(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(3).Value = El.BatchNameId

        arParms(4) = New SqlParameter("@ResType", SqlDbType.VarChar, 100)
        arParms(4).Value = El.ResTypeId

        arParms(5) = New SqlParameter("@ResName", SqlDbType.VarChar, 50)
        arParms(5).Value = El.ResNameId

        arParms(6) = New SqlParameter("@FrmBranch", SqlDbType.VarChar, 50)
        arParms(6).Value = El.Branchcode


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_ViewExamResources1]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetpublishGridData(ByVal El As ELExamResources, ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = Id

        arParms(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(3).Value = El.BatchNameId

        arParms(4) = New SqlParameter("@ResType", SqlDbType.VarChar, 100)
        arParms(4).Value = El.ResTypeId

        arParms(5) = New SqlParameter("@ResName", SqlDbType.VarChar, 50)
        arParms(5).Value = El.ResNameId

        arParms(6) = New SqlParameter("@FrmBranch", SqlDbType.VarChar, 50)
        arParms(6).Value = El.Branchcode


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_PublishExamResources]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function UpdatePublish(ByVal El As ELExamResources) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(2).Value = El.BatchNameId

        arParms(3) = New SqlParameter("@ResType", SqlDbType.VarChar, 100)
        arParms(3).Value = El.ResTypeId

        arParms(4) = New SqlParameter("@ResName", SqlDbType.VarChar, 50)
        arParms(4).Value = El.ResNameId

        arParms(5) = New SqlParameter("@FrmBranch", SqlDbType.VarChar, 50)
        arParms(5).Value = El.Branchcode

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdatePublishExamResources]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function CountData(ByVal BatchNameId As Integer) As Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchNameId", SqlDbType.Int)
        arParms(2).Value = BatchNameId

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CntAssignResources]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    Shared Function UnLockData(ByVal BatchNameId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@BatchNameId", SqlDbType.Int)
        Parms(1).Value = BatchNameId

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UnLockExamResources]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetunlockData(ByVal id As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        arParms(1).Value = id

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetUnlockExamResources]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function CntData(ByVal BatchNameId As Integer) As Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchNameId", SqlDbType.Int)
        arParms(2).Value = BatchNameId

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CntAssignResources]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function


    Public Function UpdateLockFlag(ByVal BatchNameId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchNameId", SqlDbType.Int)
        arParms(2).Value = BatchNameId

        Dim rowsAffected As Integer = 0
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateLockFlag]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

End Class
