Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DLTableConfiguration
    Shared Function InsertTableConfig(ByVal C As TableConfiguration) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        Dim s As String = HttpContext.Current.Session("BranchCode")
        Dim s1 As String = HttpContext.Current.Session("UserCode")
        Dim s2 As String = HttpContext.Current.Session("EmpCode")

        arParms(0) = New SqlParameter("@usercode", SqlDbType.NVarChar, 100)
        arParms(0).Value = HttpContext.Current.Session("UserCode")

        arParms(1) = New SqlParameter("@empcode", SqlDbType.NVarChar, 100)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 100)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@FirstApprover", SqlDbType.NVarChar, 100)
        arParms(3).Value = C.FirstApprover

        arParms(4) = New SqlParameter("@SecApprover", SqlDbType.NVarChar, 100)
        arParms(4).Value = C.SecApprover

        arParms(5) = New SqlParameter("@ThirdApprover", SqlDbType.NVarChar, 100)
        arParms(5).Value = C.ThirdApprover

        arParms(6) = New SqlParameter("@FourthApprover", SqlDbType.NVarChar, 100)
        arParms(6).Value = C.FourthApprover

        arParms(7) = New SqlParameter("@FifthApprover", SqlDbType.NVarChar, 100)
        arParms(7).Value = C.FifthApprover

        arParms(8) = New SqlParameter("@FirstEmpCode", SqlDbType.NVarChar, 100)
        arParms(8).Value = C.FirstEmpCode

        arParms(9) = New SqlParameter("@SecEmpCode", SqlDbType.NVarChar, 100)
        arParms(9).Value = C.SecEmpCode

        arParms(10) = New SqlParameter("@ThirdEmpCode", SqlDbType.NVarChar, 100)
        arParms(10).Value = C.ThirdEmpCode

        arParms(11) = New SqlParameter("@FourthEmpCode", SqlDbType.NVarChar, 100)
        arParms(11).Value = C.FourthEmpCode

        arParms(12) = New SqlParameter("@FifthEmpCode", SqlDbType.NVarChar, 100)
        arParms(12).Value = C.FifthEmpCode

        arParms(13) = New SqlParameter("@TableCode", SqlDbType.Int)
        arParms(13).Value = C.Tablecode

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_InsertWorkFlow]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateTableConfig(ByVal C As TableConfiguration) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(14) {}

        Dim s As String = HttpContext.Current.Session("BranchCode")
        Dim s1 As String = HttpContext.Current.Session("UserCode")
        Dim s2 As String = HttpContext.Current.Session("EmpCode")

        arParms(0) = New SqlParameter("@usercode", SqlDbType.NVarChar, 100)
        arParms(0).Value = HttpContext.Current.Session("UserCode")

        arParms(1) = New SqlParameter("@empcode", SqlDbType.NVarChar, 100)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 100)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@FirstApprover", SqlDbType.NVarChar, 100)
        arParms(3).Value = C.FirstApprover

        arParms(4) = New SqlParameter("@SecApprover", SqlDbType.NVarChar, 100)
        arParms(4).Value = C.SecApprover

        arParms(5) = New SqlParameter("@ThirdApprover", SqlDbType.NVarChar, 100)
        arParms(5).Value = C.ThirdApprover

        arParms(6) = New SqlParameter("@FourthApprover", SqlDbType.NVarChar, 100)
        arParms(6).Value = C.FourthApprover

        arParms(7) = New SqlParameter("@FifthApprover", SqlDbType.NVarChar, 100)
        arParms(7).Value = C.FifthApprover

        arParms(8) = New SqlParameter("@FirstEmpCode", SqlDbType.NVarChar, 100)
        arParms(8).Value = C.FirstEmpCode

        arParms(9) = New SqlParameter("@SecEmpCode", SqlDbType.NVarChar, 100)
        arParms(9).Value = C.SecEmpCode

        arParms(10) = New SqlParameter("@ThirdEmpCode", SqlDbType.NVarChar, 100)
        arParms(10).Value = C.ThirdEmpCode

        arParms(11) = New SqlParameter("@FourthEmpCode", SqlDbType.NVarChar, 100)
        arParms(11).Value = C.FourthEmpCode

        arParms(12) = New SqlParameter("@FifthEmpCode", SqlDbType.NVarChar, 100)
        arParms(12).Value = C.FifthEmpCode

        arParms(13) = New SqlParameter("@TableCode", SqlDbType.Int)
        arParms(13).Value = C.Tablecode

        arParms(14) = New SqlParameter("@WRKFLWID", SqlDbType.Int)
        arParms(14).Value = C.Workflow_ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_UpdateWorkFlow]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetTableConfigDetails(ByVal C As TableConfiguration) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        If C.Workflow_ID = "0" Then
            arParms(1) = New SqlParameter("@Wf_ID", SqlDbType.NVarChar, 100)
            arParms(1).Value = ""
        Else
            arParms(1) = New SqlParameter("@Wf_ID", SqlDbType.Int)
            arParms(1).Value = C.Workflow_ID
        End If

        arParms(2) = New SqlParameter("@office", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("Office")

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetWorkFlowDetails]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DeleteTableConfig(ByVal C As TableConfiguration) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = C.Workflow_ID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_DeleteWorkFlow]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetBranchtype() As DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetBranchType]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpName(ByVal C As String) As String

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim s As String = ""
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        arParms(0).Value = C
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            s = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "[SP_GetEmpName]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return s
    End Function

    Shared Function GetBranchTypeName(ByVal C As String) As String

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim s As String = ""
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchType", SqlDbType.NVarChar, 50)
        arParms(0).Value = C
        Try
            s = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "[SP_GetBranchTypeName]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return s
    End Function

    Shared Function GetHOEmpExt(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetHOEmpExt]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetHOEmpForWorkFlow() As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetEmpNameForWorkFlow]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckDupli(ByVal rnd As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@TableCode", SqlDbType.VarChar, 50)
        arParms(0).Value = rnd

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckApprovalDuplicate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
