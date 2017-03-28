Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLProjectMaster
    Shared Function Insert(ByVal PM As ELProjectMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@Project_Name", SqlDbType.VarChar, 250)
        arParms(0).Value = PM.ProjectName

        arParms(1) = New SqlParameter("@Description", SqlDbType.VarChar, 250)
        arParms(1).Value = PM.Description

        arParms(2) = New SqlParameter("@Proposed_By", SqlDbType.Int)
        arParms(2).Value = PM.SubmittedBy

        arParms(3) = New SqlParameter("@Proposed_Date", SqlDbType.DateTime)
        arParms(3).Value = PM.SubmittedDate

        If PM.ApprovedBy = 0 Then
            arParms(4) = New SqlParameter("@Approved_By", SqlDbType.Int)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@Approved_By", SqlDbType.Int)
            arParms(4).Value = PM.ApprovedBy
        End If

        If PM.ApprovedDate = "1/1/1900" Then
            arParms(5) = New SqlParameter("@Approved_Date", SqlDbType.DateTime)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Approved_Date", SqlDbType.DateTime)
            arParms(5).Value = PM.ApprovedDate
        End If
        If PM.StartDate = "1/1/1900" Then
            arParms(6) = New SqlParameter("@Prj_Start_Date", SqlDbType.DateTime)
            arParms(6).Value = DBNull.Value
        Else
            arParms(6) = New SqlParameter("@Prj_Start_Date", SqlDbType.DateTime)
            arParms(6).Value = PM.StartDate
        End If
        If PM.EndDate = "1/1/1900" Then
            arParms(7) = New SqlParameter("@Prj_End_Date", SqlDbType.DateTime)
            arParms(7).Value = DBNull.Value
        Else
            arParms(7) = New SqlParameter("@Prj_End_Date", SqlDbType.DateTime)
            arParms(7).Value = PM.EndDate
        End If

        arParms(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("BranchCode")

        arParms(10) = New SqlParameter("@userCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("UserCode")
        arParms(11) = New SqlParameter("@SponsorID", SqlDbType.Int)
        arParms(11).Value = PM.SponsorID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveProjectMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal PM As ELProjectMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(12) {}

        arParms(0) = New SqlParameter("@Project_Name", SqlDbType.VarChar, 250)
        arParms(0).Value = PM.ProjectName

        arParms(1) = New SqlParameter("@Description", SqlDbType.VarChar, 250)
        arParms(1).Value = PM.Description

        arParms(2) = New SqlParameter("@Proposed_By", SqlDbType.Int)
        arParms(2).Value = PM.SubmittedBy

        arParms(3) = New SqlParameter("@Proposed_Date", SqlDbType.DateTime)
        arParms(3).Value = PM.SubmittedDate

        If PM.ApprovedBy = 0 Then
            arParms(4) = New SqlParameter("@Approved_By", SqlDbType.Int)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@Approved_By", SqlDbType.Int)
            arParms(4).Value = PM.ApprovedBy
        End If
       

        If PM.ApprovedDate = "1/1/1900" Then
            arParms(5) = New SqlParameter("@Approved_Date", SqlDbType.DateTime)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Approved_Date", SqlDbType.DateTime)
            arParms(5).Value = PM.ApprovedDate
        End If
        If PM.StartDate = "1/1/1900" Then
            arParms(6) = New SqlParameter("@Prj_Start_Date", SqlDbType.DateTime)
            arParms(6).Value = DBNull.Value
        Else
            arParms(6) = New SqlParameter("@Prj_Start_Date", SqlDbType.DateTime)
            arParms(6).Value = PM.StartDate
        End If
        If PM.EndDate = "1/1/1900" Then
            arParms(7) = New SqlParameter("@Prj_End_Date", SqlDbType.DateTime)
            arParms(7).Value = DBNull.Value
        Else
            arParms(7) = New SqlParameter("@Prj_End_Date", SqlDbType.DateTime)
            arParms(7).Value = PM.EndDate
        End If

        arParms(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("BranchCode")

        arParms(10) = New SqlParameter("@userCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("UserCode")

        arParms(11) = New SqlParameter("@ProjectID", SqlDbType.Int)
        arParms(11).Value = PM.ProjectID
        arParms(12) = New SqlParameter("@SponsorID", SqlDbType.Int)
        arParms(12).Value = PM.SponsorID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateProjectMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function DisplayGridValue(ByVal PM As ELProjectMaster) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@ProjectID", SqlDbType.Int)
        arParms(2).Value = PM.ProjectID

        arParms(3) = New SqlParameter("@ProjectName", SqlDbType.VarChar, 250)
        arParms(3).Value = PM.ProjectName

        arParms(4) = New SqlParameter("@PStartDate", SqlDbType.DateTime)
        arParms(4).Value = PM.StartDate

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProjectMaster", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function Getduplicate(ByVal PM As ELProjectMaster) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Project_Name", SqlDbType.VarChar, 250)
        arParms(2).Value = PM.ProjectName

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateProjectMaster", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function ChangeFlag(ByVal PM As ELProjectMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@ProjectID", SqlDbType.Int)
        arParms(0).Value = PM.ProjectID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteProjectMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetEmpCodeExt(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpCodeAutoExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetSubmittedBy() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmployeeCombo", arParms)
        Return ds.Tables(0)
    End Function
End Class
