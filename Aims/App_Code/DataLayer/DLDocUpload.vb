Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLDocUpload
    Shared Function Insert(ByVal EL As ELDocUpload) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Link", SqlDbType.NVarChar, EL.Link.Length)
        arParms(1).Value = EL.Link

        arParms(2) = New SqlParameter("@Description", SqlDbType.VarChar, 250)
        arParms(2).Value = EL.Desc

        arParms(3) = New SqlParameter("@RevNo", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.RevNo

        arParms(4) = New SqlParameter("@RevDate", SqlDbType.Date)
        arParms(4).Value = EL.RevDate

        arParms(5) = New SqlParameter("@Remarks", SqlDbType.VarChar, 400)
        arParms(5).Value = EL.Remarks

        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")
        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_InsertDoc", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As ELDocUpload) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = EL.id

        arParms(2) = New SqlParameter("@Link", SqlDbType.NVarChar, EL.Link.Length)
        arParms(2).Value = EL.Link

        arParms(3) = New SqlParameter("@Description", SqlDbType.VarChar, 250)
        arParms(3).Value = EL.Desc

        arParms(4) = New SqlParameter("@RevNo", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.RevNo

        arParms(5) = New SqlParameter("@RevDate", SqlDbType.Date)
        arParms(5).Value = EL.RevDate

        arParms(6) = New SqlParameter("@Remarks", SqlDbType.VarChar, 400)
        arParms(6).Value = EL.Remarks

        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateDoc", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal EL As ELDocUpload) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(1).Value = EL.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_Delete", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetGridData(ByVal EL As ELDocUpload) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Desc", SqlDbType.VarChar, 200)
        arParms(2).Value = EL.Desc
        arParms(3) = New SqlParameter("@id", SqlDbType.Int)
        arParms(3).Value = EL.id
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetDoc", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Getupload() As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("office")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_GetDocConfigvalue", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    ' To get the user Name from Configuration Table
    ' Written  by Niraj Dated 16-03-2015
    Shared Function GetDocUserName() As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("office")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_GetDocFtpUserName", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    ' To get the Password from Configuration Table
    ' Written  by Niraj Dated 16-03-2015
    Shared Function GetDocPassword() As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("office")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_GetDocFtpPassword", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    ' To get the Password from Configuration Table
    ' Written  by Niraj Dated 16-03-2015
    Shared Function GetDocFilePathToUpload() As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("office")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_GetDocFtpFilePath", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteDoc(ByVal EL As ELDocUpload) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteDocfile", arParms)
        Return rowsAffected
    End Function
End Class
