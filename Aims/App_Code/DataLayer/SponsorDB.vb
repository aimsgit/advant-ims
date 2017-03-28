Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class SponsorDB
    Shared Function GetSponsor1(ByVal s As Sponsor) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'If id = 0 Then
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Sponsor_ID", SqlDbType.Int)
        arParms(0).Value = s.Sponsor_ID
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode ", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetSponsorDetails", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal s As Sponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@SponsorName", SqlDbType.NVarChar, 100)
        arParms(0).Value = s.Name

        arParms(1) = New SqlParameter("@SponsorAddress", SqlDbType.NVarChar, 150)
        arParms(1).Value = s.Address

        arParms(2) = New SqlParameter("@ContactNumber", SqlDbType.NVarChar, 50)
        arParms(2).Value = s.ContactNo

        arParms(3) = New SqlParameter("@Email", SqlDbType.NVarChar, 50)
        arParms(3).Value = s.EMail

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
        arParms(4).Value = s.Remarks

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")


        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")
        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveSponsor", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal s As Sponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@SponsorName", SqlDbType.NVarChar, 100)
        arParms(0).Value = s.Name

        arParms(1) = New SqlParameter("@SponsorAddress", SqlDbType.NVarChar, 150)
        arParms(1).Value = s.Address

        arParms(2) = New SqlParameter("@ContactNumber", SqlDbType.NVarChar, 50)
        arParms(2).Value = s.ContactNo

        arParms(3) = New SqlParameter("@Email", SqlDbType.NVarChar, 50)
        arParms(3).Value = s.EMail

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
        arParms(4).Value = s.Remarks

        arParms(5) = New SqlParameter("@Sponsor_ID", SqlDbType.Int)
        arParms(5).Value = s.Sponsor_ID


        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")
        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateSponsor", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Sponsor_ID As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter() = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Sponsor_ID", SqlDbType.BigInt)
        arParms(0).Value = Sponsor_ID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteSponsor", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function SponsorCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSponsor", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetSponsorCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSponsorDetailsForStudent", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function SponsorName(ByVal id As Integer) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim str As String
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        str = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_GetSponsorName", arParms)
        Return str
    End Function
    Shared Function GetReport(ByVal Office As String, ByVal BranchCode As String) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptSponserMaster", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function CheckDuplicate(ByVal s As Sponsor) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(5) {}

        Para(0) = New SqlParameter("@SponsorName", SqlDbType.NVarChar, 100)
        Para(0).Value = s.Name
        Para(1) = New SqlParameter("@SponsorAddress", SqlDbType.NVarChar, 150)
        Para(1).Value = s.Address
        Para(2) = New SqlParameter("@ContactNumber", SqlDbType.NVarChar, 50)
        Para(2).Value = s.ContactNo
        Para(3) = New SqlParameter("@Email", SqlDbType.NVarChar, 50)
        Para(3).Value = s.EMail

        Para(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(4).Value = HttpContext.Current.Session("BranchCode")

        Para(5) = New SqlParameter("@id", SqlDbType.Int)
        Para(5).Value = s.Sponsor_ID
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_SponserDuplicate", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptGetSponsor() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'If id = 0 Then
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Sponsor_ID", SqlDbType.Int)
        arParms(0).Value = 0
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode ", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetSponsorDetails", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
