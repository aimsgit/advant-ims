Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class DLJobOpening
    Shared Function GetCompanyName() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetCompanyNameCombo", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function
    Shared Function InsertJobOpening(ByVal el As ELJobOpening) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@CompanyID", SqlDbType.Int)
        arParms(3).Value = el.Copmpanyid
        arParms(4) = New SqlParameter("@JobTitle", SqlDbType.VarChar, 150)
        arParms(4).Value = el.JobTitle
        arParms(5) = New SqlParameter("@Specialization", SqlDbType.VarChar, 150)
        arParms(5).Value = el.Specilization
        arParms(6) = New SqlParameter("@Skill", SqlDbType.VarChar, 50)
        arParms(6).Value = el.Skill
        arParms(7) = New SqlParameter("@CloseApplication", SqlDbType.VarChar, 50)
        arParms(7).Value = el.CloseApplication
        arParms(8) = New SqlParameter("@StatusOfJobOpening", SqlDbType.VarChar, 10)
        arParms(8).Value = el.StatusOfJobOpening
        arParms(9) = New SqlParameter("@EligibilityCriteria", SqlDbType.VarChar, 150)
        arParms(9).Value = el.Eligibility
        arParms(10) = New SqlParameter("@SelectionProcess", SqlDbType.VarChar, 200)
        arParms(10).Value = el.SelectionProcess
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertJobOpening", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetJobOpening(ByVal el As ELJobOpening) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.Id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetJobOpening", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function UpdateJobOpening(ByVal el As ELJobOpening) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(11) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@CompanyID", SqlDbType.Int)
        arParms(3).Value = el.Copmpanyid
        arParms(4) = New SqlParameter("@JobTitle", SqlDbType.VarChar, 150)
        arParms(4).Value = el.JobTitle
        arParms(5) = New SqlParameter("@Specialization", SqlDbType.VarChar, 150)
        arParms(5).Value = el.Specilization
        arParms(6) = New SqlParameter("@Skill", SqlDbType.VarChar, 50)
        arParms(6).Value = el.Skill
        arParms(7) = New SqlParameter("@CloseApplication", SqlDbType.VarChar, 50)
        arParms(7).Value = el.CloseApplication
        arParms(8) = New SqlParameter("@StatusOfJobOpening", SqlDbType.VarChar, 10)
        arParms(8).Value = el.StatusOfJobOpening
        arParms(9) = New SqlParameter("@EligibilityCriteria", SqlDbType.VarChar, 150)
        arParms(9).Value = el.Eligibility
        arParms(10) = New SqlParameter("@SelectionProcess", SqlDbType.VarChar, 200)
        arParms(10).Value = el.SelectionProcess
        arParms(11) = New SqlParameter("@id", SqlDbType.Int)
        arParms(11).Value = el.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateJobOpening", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlagJobOpening(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteJobOpening", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Public Function CheckDuplicateCompanyRegister(ByVal EL As ELJobOpening) As Data.DataTable
    '    Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim para() As SqlParameter = New SqlParameter(2) {}
    '    para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    para(0).Value = HttpContext.Current.Session("BranchCode")
    '    para(1) = New SqlParameter("@CompanyCode", SqlDbType.VarChar, 50)
    '    para(1).Value = EL.CompanyRegCode
    '    para(2) = New SqlParameter("@id", SqlDbType.Int)
    '    para(2).Value = EL.Id
    '    Try
    '        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_DuplicateJobOpening", para)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
End Class
