Imports Microsoft.VisualBasic
Imports System.Data.DataTable
Imports System.Data.SqlClient
Public Class BookSearchD
    Dim Sql As String
    Dim Dt As DataTable
    Dim Da As OleDb.OleDbDataAdapter
    Public Function BookSearch(ByVal prop As BookSearch) As DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@bookname", SqlDbType.VarChar, 50)
        arParms(2).Value = prop.BookName

        arParms(3) = New SqlParameter("@author", SqlDbType.VarChar, 50)
        arParms(3).Value = prop.BookAuthor

        arParms(4) = New SqlParameter("@publisher", SqlDbType.VarChar, 50)
        arParms(4).Value = prop.publisher

        arParms(5) = New SqlParameter("@deptId", SqlDbType.Int)
        arParms(5).Value = prop.Dept

        arParms(6) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(6).Value = prop.Subject

        arParms(7) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(7).Value = prop.Branch

        arParms(8) = New SqlParameter("@Isbnno", SqlDbType.VarChar, 50)
        arParms(8).Value = prop.Isbno
        'arParms(9) = New SqlParameter("@BookId", SqlDbType.VarChar, 50)
        'arParms(9).Value = prop.BookId
        arParms(9) = New SqlParameter("@Classification", SqlDbType.VarChar, 50)
        arParms(9).Value = prop.Classification
        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewQry_BookAvailable", arParms)
            Return ds.Tables(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       

    End Function
End Class
