Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLImportStdCode
    Shared Function ImportStdCode(ByVal id As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.VarChar)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[ImportSyudentcode]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ImportStdCode1(ByVal id As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.VarChar)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[ImportSyudentcode1]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ImportStdCode2(ByVal name As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.VarChar)
        arParms(0).Value = name

        arParms(1) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[ImportSyudentcode2]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal TempCode As String, ByVal UniversityCode As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(4) {}
        Parms(0) = New SqlParameter("@TempCode", SqlDbType.VarChar, (50))
        Parms(0).Value = TempCode
        Parms(1) = New SqlParameter("@UniversityCode", SqlDbType.VarChar, (50))
        Parms(1).Value = UniversityCode
        Parms(2) = New SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("UserCode")

        Parms(3) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("EmpCode")

        Parms(4) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("BranchCode")
   

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateImportsStdCode", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
