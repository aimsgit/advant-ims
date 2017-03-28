Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLEnquiryLogin
    Public Function Insert(ByVal s As ELEnquiryLogin) As Int16


        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Count As Int32

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Name", SqlDbType.VarChar, s.Name.Length())
        arParms(0).Value = s.Name

        arParms(1) = New SqlParameter("@EmailID", SqlDbType.VarChar, s.EmailID.Length())
        arParms(1).Value = s.EmailID

        arParms(2) = New SqlParameter("@ContactNo", SqlDbType.VarChar, s.ContactNo.Length())
        arParms(2).Value = s.ContactNo

        arParms(3) = New SqlParameter("@Password", SqlDbType.VarChar, s.Password.Length())
        arParms(3).Value = s.Password

        arParms(4) = New SqlParameter("@Website", SqlDbType.VarChar, s.Website.Length())
        arParms(4).Value = s.Website

        'arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        'arParms(5).Value = HttpContext.Current.Session("EmpCode")

        'arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        'arParms(6).Value = HttpContext.Current.Session("UserCode")

        'arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(7).Value = HttpContext.Current.Session("BranchCode")

        Try
            Count = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertEnquiryLogin", arParms)
            Return Count
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Getdetails(ByVal s As ELEnquiryLogin) As DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Count As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@EmailID", SqlDbType.VarChar, s.EmailID.Length())
        arParms(0).Value = s.EmailID

        arParms(1) = New SqlParameter("@Password", SqlDbType.VarChar, s.Password.Length())
        arParms(1).Value = s.Password

        arParms(2) = New SqlParameter("@PrvsUrl", SqlDbType.VarChar, s.PrvsUrl.Length())
        arParms(2).Value = s.PrvsUrl

        Try
            Count = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetEnquiryLogin", arParms)
            Return Count.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Getduplicate(ByVal s As ELEnquiryLogin) As DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Count As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@EmailID", SqlDbType.VarChar, s.EmailID.Length())
        arParms(0).Value = s.EmailID

        arParms(1) = New SqlParameter("@Password", SqlDbType.VarChar, s.Password.Length())
        arParms(1).Value = s.Password

        Try
            Count = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_DuplicateEnquiryLogin", arParms)
            Return Count.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
