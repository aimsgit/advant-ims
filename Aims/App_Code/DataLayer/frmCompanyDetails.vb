Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class CompanyDB1

    Public Function Getrecords(ByVal id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim le As New CompanyDetails

        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@PCId", SqlDbType.Int)
            arParms(0).Value = id
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")
            arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCompanyDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'Return ds.Tables(0)
    End Function

    Shared Function Insert(ByVal EL As CompanyDetails) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.NVarChar, EL.Name.Length)
        arParms(0).Value = EL.Name
        arParms(1) = New SqlParameter("@contactperson", SqlDbType.NVarChar, EL.ContactPerson.Length)
        arParms(1).Value = EL.ContactPerson
        arParms(2) = New SqlParameter("@contactno", SqlDbType.Char, EL.ContactNo.Length)
        arParms(2).Value = EL.ContactNo
        arParms(3) = New SqlParameter("@address", SqlDbType.NVarChar, EL.Address.Length)
        arParms(3).Value = EL.Address
        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")
        arParms(5) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")
        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveCompanyDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As CompanyDetails) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.NVarChar, EL.Name.Length)
        arParms(0).Value = EL.Name
        arParms(1) = New SqlParameter("@contactperson", SqlDbType.NVarChar, EL.ContactPerson.Length)
        arParms(1).Value = EL.ContactPerson
        arParms(2) = New SqlParameter("@contactno", SqlDbType.Char, EL.ContactNo.Length)
        arParms(2).Value = EL.ContactNo
        arParms(3) = New SqlParameter("@address", SqlDbType.NVarChar, EL.Address.Length)
        arParms(3).Value = EL.Address
        arParms(4) = New SqlParameter("@compid", SqlDbType.Int)
        arParms(4).Value = EL.Id
        arParms(5) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")
        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateCompanyDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return rowsAffected
    End Function
    Public Function Delete(ByVal id As Int64) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@compid", SqlDbType.Int)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteCompanyDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function GetDuplicateCertificateMaster(ByVal EL As CompanyDetails) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}
        If EL.Name = "" Then
            para(0) = New SqlParameter("@PCName", SqlDbType.VarChar, 50)
            para(0).Value = ""
            para(1) = New SqlParameter("@PCCntPerson", SqlDbType.VarChar, 50)
            para(1).Value = ""
            para(2) = New SqlParameter("@PCCntNo", SqlDbType.VarChar, 50)
            para(2).Value = ""
            para(3) = New SqlParameter("@PCAdd", SqlDbType.VarChar, 50)
            para(3).Value = ""
            para(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(4).Value = ""
            para(5) = New SqlParameter("@id", SqlDbType.Int)
            para(5).Value = ""
        Else
            para(0) = New SqlParameter("@PCName", SqlDbType.NVarChar, 50)
            para(0).Value = EL.Name
            para(1) = New SqlParameter("@PCCntPerson", SqlDbType.NVarChar, 50)
            para(1).Value = EL.ContactPerson
            para(2) = New SqlParameter("@PCCntNo", SqlDbType.VarChar, 50)
            para(2).Value = EL.ContactNo
            para(3) = New SqlParameter("@PCAdd", SqlDbType.NVarChar, 50)
            para(3).Value = EL.Address
            para(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(4).Value = HttpContext.Current.Session("BranchCode")
            para(5) = New SqlParameter("@id", SqlDbType.Int)
            para(5).Value = EL.Id

        End If
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_CompanydetailsDuplicate", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
