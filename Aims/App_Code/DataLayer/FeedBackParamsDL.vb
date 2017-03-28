Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class FeedBackParamsDL
    Shared Function ViewParameters() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetFeedBackParameters", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function
    Shared Function GenerateParameters() As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(3).Value = HttpContext.Current.Session("Office")

        
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertFeedBackParameters", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ClearParameters() As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ClearFeedBackParameters", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateFeedBackParameters(ByVal FeedBackId As Integer, ByVal ParameterName As String, ByVal Max As Integer, ByVal Min As Integer, ByVal Weightage As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@FeedBackId", SqlDbType.Int)
        arParms(1).Value = FeedBackId

        If ParameterName = "" Then
            arParms(2) = New SqlParameter("@ParameterName", SqlDbType.NVarChar)
            arParms(2).Value = DBNull.Value
        Else
            arParms(2) = New SqlParameter("@ParameterName", SqlDbType.NVarChar)
            arParms(2).Value = ParameterName
        End If
        If Max = -1 Then
            arParms(3) = New SqlParameter("@Max", SqlDbType.Int)
            arParms(3).Value = DBNull.Value
        Else
            arParms(3) = New SqlParameter("@Max", SqlDbType.Int)
            arParms(3).Value = Max
        End If

        If Min = -1 Then
            arParms(4) = New SqlParameter("@Min", SqlDbType.Int)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@Min", SqlDbType.Int)
            arParms(4).Value = Min
        End If

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        'arParms(6) = New SqlParameter("@Weightage", SqlDbType.Int)
        'arParms(6).Value = Weightage
        If Weightage = 1 Then
            arParms(6) = New SqlParameter("@Weightage", SqlDbType.Int)
            arParms(6).Value = DBNull.Value
        Else
            arParms(6) = New SqlParameter("@Weightage", SqlDbType.Int)
            arParms(6).Value = Weightage
        End If

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpDateFeedBackParameters", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CheckFeedBackGenStatus() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckFeedBackParaGenStatus", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function
    Shared Function GetDepartmentCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ddlDeptFeedback", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function InserFeedbackDept(ByVal El As ELFeedbackDept) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(0).Value = El.DeptID


        arParms(1) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(1).Value = El.StartDate


        arParms(2) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(2).Value = El.EndDate

        arParms(3) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")
        arParms(7) = New SqlParameter("@DeptName", SqlDbType.VarChar, 50)
        arParms(7).Value = El.DeptName



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsetFeedbackDept", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayDeptFeedback(ByVal El As ELFeedbackDept) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.ID
        arParms(3) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(3).Value = El.DeptID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDeptFeedBack", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function UpdateDeptFeedback(ByVal El As ELFeedbackDept) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(0).Value = El.DeptID

        arParms(1) = New SqlParameter("@FeedbackStartDate", SqlDbType.DateTime)
        arParms(1).Value = El.StartDate

        arParms(2) = New SqlParameter("@FeedbackEndDate", SqlDbType.DateTime)
        arParms(2).Value = El.EndDate

        arParms(3) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(6).Value = El.ID
        arParms(7) = New SqlParameter("@DeptName", SqlDbType.VarChar, 50)
        arParms(7).Value = El.DeptName
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateDeptFeedback", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetDuplData(ByVal El As ELFeedbackDept) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@DeptID", SqlDbType.VarChar, 100)
        arParms(2).Value = El.DeptID

        arParms(3) = New SqlParameter("@id", SqlDbType.Int)
        arParms(3).Value = El.id

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateDept", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckPublishFeedback(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_PublishFeedback", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function PublishFeedback(ByVal id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@DeptId", SqlDbType.VarChar, 5000)
        param(0).Value = id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_PublishFeedbackReport", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
End Class

