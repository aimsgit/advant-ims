Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class CompanyDB
    Shared Function GetCompany(ByVal id As Long) As System.Data.DataSet

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

       
        Dim ds As DataSet
        If id = 0 Then
            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCompanyDetails", arParms)
        Else
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCompanyDetailsByCompanyID", New System.Data.SqlClient.SqlParameter("@CompID", SqlDbType.SmallInt, 10, ParameterDirection.Input, False, 0, 0, "CompID", DataRowVersion.Current, id))
        End If
        Return ds


    End Function
    Shared Function Insert(ByVal c As Company) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.VarChar, c.Name.Length)
        arParms(0).Value = c.Name

        arParms(1) = New SqlParameter("@contactperson", SqlDbType.Char, c.ContactPerson.Length)
        arParms(1).Value = c.ContactPerson

        arParms(2) = New SqlParameter("@contactno", SqlDbType.Char, c.ContactNo.Length)
        arParms(2).Value = c.ContactNo

        arParms(3) = New SqlParameter("@address", SqlDbType.Char, c.Address.Length)
        arParms(3).Value = c.Address

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@empid", SqlDbType.Int)
        arParms(5).Value = HttpContext.Current.Session("UserID")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveCompanyDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal c As Company) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.Char, c.Name.Length)
        arParms(0).Value = c.Name

        arParms(1) = New SqlParameter("@contactperson", SqlDbType.Char, c.ContactPerson.Length)
        arParms(1).Value = c.ContactPerson

        arParms(2) = New SqlParameter("@contactno", SqlDbType.Char, c.ContactNo.Length)
        arParms(2).Value = c.ContactNo

        arParms(3) = New SqlParameter("@address", SqlDbType.Char, c.Address.Length)
        arParms(3).Value = c.Address

        arParms(4) = New SqlParameter("@compid", SqlDbType.Int)
        arParms(4).Value = c.Id


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateCompanyDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
       
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@compid", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteCompanyDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DeleteValidation(ByVal id As Int64) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CompDelValidation", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function RptCompany(ByVal inst As Int64, ByVal brn As Int64) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCompanyDetails", arParms)
        Return ds.Tables(0)
    End Function
    'Code for get Company Master Report By Nitin 07/05/2012

    Shared Function RptCompanyMaster(ByVal inst As Int64, ByVal brn As Int64) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptCompanyMaster", arParms)
        Return ds.Tables(0)
    End Function
End Class
