Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLIdCardIssue

    Shared Function InsertIntoIdCardIssue(ByVal IdCardIssue As IDCardIssue) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim Para() As SqlParameter = New SqlParameter(7) {}
        Dim Rowsaffected As Integer = 0

        Para(0) = New SqlParameter("@BacthID", SqlDbType.Int)
        Para(0).Value = IdCardIssue.BacthID

        Para(1) = New SqlParameter("@StudentID", SqlDbType.Int)
        Para(1).Value = IdCardIssue.StudentID

        If IdCardIssue.CardType = "Select" Then
            Para(2) = New SqlParameter("@CardType", SqlDbType.VarChar, 50)
            Para(2).Value = DBNull.Value
        Else
            Para(2) = New SqlParameter("@CardType", SqlDbType.VarChar, 50)
            Para(2).Value = IdCardIssue.CardType
        End If


        If IdCardIssue.IssueDate = "#1/1/3000#" Then
            Para(3) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
            Para(3).Value = DBNull.Value
        Else
            Para(3) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
            Para(3).Value = IdCardIssue.IssueDate

        End If

        Para(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(4).Value = HttpContext.Current.Session("BranchCode")


        Para(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Para(5).Value = HttpContext.Current.Session("UserCode")

        Para(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Para(6).Value = HttpContext.Current.Session("EmpCode")

        Para(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(7).Value = HttpContext.Current.Session("Office")



        Try
            Rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_InsertIntoIdCardIssue", Para)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return Rowsaffected

    End Function
    Shared Function UpdateIdCardIssue(ByVal IdCardIssue As IDCardIssue) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim Para() As SqlParameter = New SqlParameter(7) {}
        Dim Rowsaffected As Integer = 0

        Para(0) = New SqlParameter("@BacthID", SqlDbType.Int)
        Para(0).Value = IdCardIssue.BacthID

        Para(1) = New SqlParameter("@StudentID", SqlDbType.Int)
        Para(1).Value = IdCardIssue.StudentID

        If IdCardIssue.CardType = "Select" Then
            Para(2) = New SqlParameter("@CardType", SqlDbType.VarChar, 50)
            Para(2).Value = DBNull.Value
        Else
            Para(2) = New SqlParameter("@CardType", SqlDbType.VarChar, 50)
            Para(2).Value = IdCardIssue.CardType
        End If


        If IdCardIssue.IssueDate = "#1/1/3000#" Then
            Para(3) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
            Para(3).Value = DBNull.Value
        Else
            Para(3) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
            Para(3).Value = IdCardIssue.IssueDate

        End If

        Para(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(4).Value = HttpContext.Current.Session("BranchCode")


        Para(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Para(5).Value = HttpContext.Current.Session("UserCode")

        Para(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Para(6).Value = HttpContext.Current.Session("EmpCode")

        Para(7) = New SqlParameter("@Auto_PKID", SqlDbType.Int)
        Para(7).Value = IdCardIssue.PKID


        Try
            Rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_UpdateIDCardIssue", Para)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return Rowsaffected

    End Function


    Shared Function GetIdCardIssue(ByVal IdCardIssue As IDCardIssue) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet

        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")


        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("Office")

        Para(2) = New SqlParameter("@Auto_PKID", SqlDbType.Int)
        Para(2).Value = IdCardIssue.PKID
        Try

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetIdentitycardissue", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function


    Shared Function DeleteIdCardIssue(ByVal PKID As Integer) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Para() As SqlParameter = New SqlParameter(1) {}

        Para(0) = New SqlParameter("@PKID", SqlDbType.Int)
        Para(0).Value = PKID

        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_DeleteIdCardIssue", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function AutoFillStdPhoto(ByVal STD_ID As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet

        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")


        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("Office")

        Para(2) = New SqlParameter("@STD_ID", SqlDbType.Int)
        Para(2).Value = STD_ID
        Try

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_AutoFillStdPhoto]", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Shared Function GetStudentDDL(ByVal Batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(1).Value = Batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectStudent1", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function AutoFillStdPhoto1(ByVal STD_ID As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet

        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")


        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("Office")

        Para(2) = New SqlParameter("@STD_ID", SqlDbType.Int)
        Para(2).Value = STD_ID
        Try

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_AutofillBatchphoto]", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function


    Shared Function GetDuplicate(ByVal IdCardIssue As IDCardIssue) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Para() As SqlParameter = New SqlParameter(3) {}
        Dim ds As New DataSet

        Para(0) = New SqlParameter("@CardType", SqlDbType.VarChar, 50)
        Para(0).Value = IdCardIssue.CardType


        Para(1) = New SqlParameter("@StudentID", SqlDbType.Int)
        Para(1).Value = IdCardIssue.StudentID

        Para(2) = New SqlParameter("@PKID", SqlDbType.Int)
        Para(2).Value = IdCardIssue.PKID


        Para(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(3).Value = HttpContext.Current.Session("BranchCode")

        Try

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetDuplicateIDCardIssue", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function
End Class
