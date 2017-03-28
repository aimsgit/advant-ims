Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLGradeMaster
    Shared Function Insert(ByVal EL As ELGradeMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(0).Value = EL.CourseName

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@min", SqlDbType.Float)
        arParms(4).Value = EL.Min

        arParms(5) = New SqlParameter("@max", SqlDbType.Float)
        arParms(5).Value = EL.Max

        arParms(6) = New SqlParameter("@Grade", SqlDbType.NVarChar, 50)
        arParms(6).Value = EL.Grade

        arParms(7) = New SqlParameter("@GradePoint", SqlDbType.Float)
        arParms(7).Value = EL.GradePoint

        arParms(8) = New SqlParameter("@Division", SqlDbType.NVarChar, 200)
        arParms(8).Value = EL.Division
        arParms(9) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertGradeMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetData(ByVal EL As ELGradeMaster) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = EL.id

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetGradeMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ELGradeMaster) As Long
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(0).Value = EL.CourseName

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@min", SqlDbType.Float)
        arParms(4).Value = EL.Min

        arParms(5) = New SqlParameter("@max", SqlDbType.Float)
        arParms(5).Value = EL.Max

        arParms(6) = New SqlParameter("@Grade", SqlDbType.NVarChar, 50)
        arParms(6).Value = EL.Grade

        arParms(7) = New SqlParameter("@id", SqlDbType.Int)
        arParms(7).Value = EL.id

        arParms(8) = New SqlParameter("@GradePoint", SqlDbType.Float)
        arParms(8).Value = EL.GradePoint

        arParms(9) = New SqlParameter("@Division", SqlDbType.NVarChar, 200)
        arParms(9).Value = EL.Division

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateGradeMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal EL As ELGradeMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteGradeMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetDuplicateType(ByVal El As ELGradeMaster) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@grade", SqlDbType.NVarChar, 50)
        arParms(1).Value = El.Grade

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = El.id

        arParms(3) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(3).Value = El.CourseName

        arParms(4) = New SqlParameter("@Max", SqlDbType.Float)
        arParms(4).Value = El.Max

        arParms(5) = New SqlParameter("@Min", SqlDbType.Float)
        arParms(5).Value = El.Min
        'arParms(6) = New SqlParameter("@GradePoint", SqlDbType.Float)
        'arParms(6).Value = El.GradePoint


        Try

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_DuplicateGradeMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetMinMax(ByVal El As ELGradeMaster) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

      
        Try

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_GetMinMaxGradeMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    ' Code Written by Niraj on 10 june 2013
    Shared Function GetCourseAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCourseAll", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function
    Public Function RptGradeMaster(ByVal CourseID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int, 50)
        arParms(2).Value = CourseID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GradeMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
