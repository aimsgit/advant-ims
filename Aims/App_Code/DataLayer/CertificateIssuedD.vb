Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class CertificateIssuedD
    Public Function CertificateDetailsCombo() As DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@inst", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("InstituteID")
        arParms(1) = New SqlParameter("@bran", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BranchID")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_fillComboCertificate", arParms)
        Catch ex As Exception
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getStdIdByCode(ByVal ddlcode As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim params As New SqlClient.SqlParameter("@StdCode", SqlDbType.VarChar, 100)
            params.Value = ddlcode
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getstdCodeByStdIDfromStudentMaster", params)
        Catch ex As Exception
        End Try
        Return ds.Tables(0)
    End Function
    Public Function InsertIssueCertificate(ByVal p As CertificateIssuedE) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(7) {}

        arParms(0) = New SqlClient.SqlParameter("@Institute_Id", SqlDbType.Int)
        arParms(0).Value = p.Institute_ID

        arParms(1) = New SqlClient.SqlParameter("@Branch_Id", SqlDbType.Int)
        arParms(1).Value = p.Branch_ID

        arParms(2) = New SqlClient.SqlParameter("@Course_Id", SqlDbType.Int)
        arParms(2).Value = p.Course_ID

        arParms(3) = New SqlClient.SqlParameter("@Batch_No", SqlDbType.Int)
        arParms(3).Value = p.Batch_No

        arParms(4) = New SqlClient.SqlParameter("@Certificate_Id", SqlDbType.Int)
        arParms(4).Value = p.Certificate_ID

        arParms(5) = New SqlClient.SqlParameter("@StdId", SqlDbType.Int)
        arParms(5).Value = p.StdID

        arParms(6) = New SqlClient.SqlParameter("@IssueDate", SqlDbType.DateTime)
        arParms(6).Value = p.IssueDate

        arParms(7) = New SqlClient.SqlParameter("@Certificate_No", SqlDbType.Int)
        arParms(7).Value = p.Certificate_No

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertCertificateIssued", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function Report(ByVal ins As Integer, ByVal brn As Integer, ByVal crs As Integer, ByVal btch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        arParms(0) = New SqlClient.SqlParameter("@Param1", SqlDbType.Int)
        arParms(0).Value = ins

        arParms(1) = New SqlClient.SqlParameter("@Param2", SqlDbType.Int)
        arParms(1).Value = brn

        arParms(2) = New SqlClient.SqlParameter("@Param3", SqlDbType.Int)
        arParms(2).Value = crs

        arParms(3) = New SqlClient.SqlParameter("@Param4", SqlDbType.Int)
        arParms(3).Value = btch

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_certificate_report", arParms)
        Return ds.tables(0)
    End Function
    Public Function fillGridViewCertificateDetails(ByVal ins As Integer, ByVal brn As Integer, ByVal crs As Integer, ByVal btch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        arParms(0) = New SqlClient.SqlParameter("@Ins", SqlDbType.Int)
        arParms(0).Value = ins

        arParms(1) = New SqlClient.SqlParameter("@Brn", SqlDbType.Int)
        arParms(1).Value = brn

        arParms(2) = New SqlClient.SqlParameter("@Crs", SqlDbType.Int)
        arParms(2).Value = crs

        arParms(3) = New SqlClient.SqlParameter("@btch", SqlDbType.Int)
        arParms(3).Value = btch

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_fillGVCertificateIssued", arParms)
        Return ds.Tables(0)
    End Function
    'Proc_UpdateCertificateIssued
    'Proc_DeleteCertificateIssued
    'Public Function UpdateCertificateIssued(ByVal Institute_Id As Integer, ByVal IssueDate As DateTime, ByVal Certificate_No As Integer, ByVal ID As Integer, ByVal StdId As Integer, ByVal StdCode As String, ByVal StdName As String) As Int16
    Public Function UpdateCertificateIssued(ByVal Certificate_Id As Integer, ByVal IssueDate As Date, ByVal Certificate_No As Integer, ByVal ID As Integer) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        arParms(0) = New SqlClient.SqlParameter("@Certificate_Id", SqlDbType.Int)
        arParms(0).Value = Certificate_Id

        arParms(1) = New SqlClient.SqlParameter("@IssueDate", SqlDbType.DateTime)
        arParms(1).Value = IssueDate

        arParms(2) = New SqlClient.SqlParameter("@Certificate_No", SqlDbType.Int)
        arParms(2).Value = Certificate_No

        arParms(3) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
        arParms(3).Value = ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateCertificateIssued", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function DeleteCertificateIssued(ByVal ID As Integer) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As New Int16
        Try
            Dim params As New SqlClient.SqlParameter("@Id", SqlDbType.Int)
            params.Value = ID
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteCertificateIssued", params)
        Catch ex As Exception
        End Try
        Return rowsAffected
    End Function
End Class
