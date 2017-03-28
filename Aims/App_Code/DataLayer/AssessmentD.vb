Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class AssessmentD
    'code for insert data By sheela 13-3-2012
    Public Function Insert(ByVal Name As String, ByVal SeqNo As Integer) As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@type", SqlDbType.NVarChar, 50)
        arParms(0).Value = Name
        arParms(1) = New SqlParameter("@empid", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
        arParms(4) = New SqlParameter("@SeqNo", SqlDbType.Int)
        arParms(4).Value = SeqNo
        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office")
        
        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "proc_InsertAssessment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function Getrecords(ByVal id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim le As New Assessment
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
            arParms(0).Value = id
            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")
            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAssessment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetrecordsById(ByVal id As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim le As New Assessment
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@ID", SqlDbType.VarChar, 4000)
            arParms(0).Value = id
            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")
            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAssessmentById", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'code for update data By sheela 13-3-2012

    Public Function Update(ByVal EL As Assessment) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@type", SqlDbType.NVarChar, 50)
        arParms(0).Value = EL.Name

        arParms(1) = New SqlParameter("@empid", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(4).Value = EL.ID

        arParms(5) = New SqlParameter("@SeqNo", SqlDbType.Int)
        arParms(5).Value = EL.SeqNo
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateAssesment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    'code for delete data By sheela 13-3-2012
    Public Function Delete(ByVal id As Int64) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_AssessmentDelete", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    'code for duplicate data By sheela 13-3-2012
    Public Function GetDuplicateCertificateMaster(ByVal EL As Assessment) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@Name", SqlDbType.NVarChar, 50)
        para(0).Value = EL.Name
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.ID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_GetDuplicateAssesment", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetReport() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim le As New Assessment
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
            arParms(0).Value = 0
            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")
            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAssessment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
