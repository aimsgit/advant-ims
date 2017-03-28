Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class SemesterDB
    Public Function GetSemester() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetSemester", arParms)

        Return ds.Tables(0)

    End Function
    Public Function DeleteAss(ByVal id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@id", SqlDbType.Int)
        param(0).Value = id

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteSemester", param)
        Return rowsaffected
    End Function
    Public Function InsertAssessment(ByVal type As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@type", SqlDbType.NVarChar, 50)
        Parms(0).Value = type
       
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")
        Parms(2) = New SqlParameter("@empid", SqlDbType.Int)
        Parms(2).Value = HttpContext.Current.Session("UserID")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertAssessment", Parms)
        Return rowsaffected
    End Function
    Public Function InsertSemester(ByVal type As Semester) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(4) {}
        Parms(0) = New SqlParameter("@SemName", SqlDbType.NVarChar, 50)
        Parms(0).Value = type.Name
        Parms(1) = New SqlParameter("@durationDays", SqlDbType.Int)
        Parms(1).Value = type.durationDays
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Parms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("empCode")
        Parms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("UserCode")
        'Parms(3) = New SqlParameter("@empid", SqlDbType.Int)
        'Parms(3).Value = HttpContext.Current.Session("UserID")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertSemester", Parms)
        Return rowsaffected


    End Function
    Public Function UpdateAsse(ByVal sem As Semester) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@SemName", SqlDbType.NVarChar, 50)
        param(0).Value = sem.Name
        param(1) = New SqlParameter("@ID", SqlDbType.Int)
        param(1).Value = sem.ID
        param(2) = New SqlParameter("@durationDays", SqlDbType.Int)
        param(2).Value = sem.durationDays
        param(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        param(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("empCode")
        param(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("UserCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateSemester", param)
        Return rowsaffected
    End Function
    Public Function getData1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        'Parms(0) = New SqlParameter("@id", SqlDbType.Int)
        'Parms(0).Value = type
        Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("Office")
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAssessmentType", Parms)
        Return ds.Tables(0)
    End Function
    Public Function getData2(ByVal e As Semester) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.Int)
        Parms(0).Value = e.ID
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetSemester", Parms)
        Return ds.Tables(0)
    End Function
    Public Function GVSemesterComboUser() As System.Data.DataSet
        'Public Function GVSemesterComboUser(ByVal assessment As Boolean, ByVal semester As Boolean) As System.Data.DataSet
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        'param(0) = New SqlParameter("@type1", SqlDbType.Bit)
        'param(0).Value = assessment
        'param(1) = New SqlParameter("@type2", SqlDbType.Bit)
        'param(1).Value = semester
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GVSemesterComboUser", param)
        Return ds
    End Function


    Shared Function RptAssessment(ByVal Office As Int64, ByVal BranchCode As Int64) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAssessmentType1", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Rptsemester(ByVal Office As String, ByVal BranchCode As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@branch", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAssessmentType", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetDuplicateSemesterMaster(ByVal EL As Semester) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@Name", SqlDbType.NVarChar, 50)
        para(0).Value = EL.Name
        para(1) = New SqlParameter("@Duration", SqlDbType.Int)
        para(1).Value = EL.durationDays
        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        para(3) = New SqlParameter("@id", SqlDbType.Int)
        para(3).Value = EL.ID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateSemesterMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getReport() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.Int)
        Parms(0).Value = 0
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetSemester", Parms)
        Return ds.Tables(0)
    End Function
End Class
