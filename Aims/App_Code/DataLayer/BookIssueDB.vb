Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class BookIssueDB
    Shared Function GetBookCount(ByVal id As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookCount", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetStdBookIssued(ByVal bookid As Long, ByVal stdno As Long, ByVal brch As Long, ByVal inst As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@bookid", SqlDbType.Int)
        arParms(0).Value = bookid

        arParms(1) = New SqlParameter("@stdno", SqlDbType.Int)
        arParms(1).Value = stdno

        arParms(2) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StdBookIssued", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function GetEmpBookIssued(ByVal bookid As Long, ByVal empno As Long, ByVal brch As Long, ByVal inst As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@bookid", SqlDbType.Int)
        arParms(0).Value = bookid

        arParms(1) = New SqlParameter("@empno", SqlDbType.Int)
        arParms(1).Value = empno

        arParms(2) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EmpBookIssued", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal BLIssue As BookIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Book_IDAuto", SqlDbType.Int)
        arParms(0).Value = BLIssue.BookCode

        arParms(1) = New SqlParameter("@STD_ID", SqlDbType.Int)
        arParms(1).Value = BLIssue.StdCode

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = BLIssue.EmpCode

        arParms(3) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
        arParms(3).Value = BLIssue.Issuedate

        arParms(4) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
        arParms(4).Value = BLIssue.Returndate

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@userCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@Std_Emp", SqlDbType.VarChar, 50)
        arParms(8).Value = BLIssue.Std_Emp

        arParms(9) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(9).Value = BLIssue.Dept

        arParms(10) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(10).Value = BLIssue.Branch
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_NewSaveBookIssueDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal BLIssue As BookIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@Book_IDAuto", SqlDbType.Int)
        arParms(0).Value = BLIssue.BookCode

        arParms(1) = New SqlParameter("@STD_ID", SqlDbType.Int)
        arParms(1).Value = BLIssue.StdCode

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = BLIssue.EmpCode

        arParms(3) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
        arParms(3).Value = BLIssue.Issuedate

        arParms(4) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
        arParms(4).Value = BLIssue.Returndate

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@userCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@Std_Emp", SqlDbType.VarChar, 50)
        arParms(8).Value = BLIssue.Std_Emp

        arParms(9) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(9).Value = BLIssue.id

        arParms(10) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(10).Value = BLIssue.Dept
        arParms(11) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(11).Value = BLIssue.Branch


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_NewUpdateBookIssueDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayGridValue(ByVal ELIssue As BookIssue) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Std_Emp", SqlDbType.VarChar, 50)
        arParms(2).Value = ELIssue.Std_Emp

        arParms(3) = New SqlParameter("@ID ", SqlDbType.Int)
        arParms(3).Value = ELIssue.id

        arParms(4) = New SqlParameter("@StdId", SqlDbType.Int)
        arParms(4).Value = ELIssue.Stdid

        arParms(5) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(5).Value = ELIssue.Empid

        arParms(6) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(6).Value = ELIssue.Dept
        arParms(7) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(7).Value = ELIssue.Branch

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookIssueDetails", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function GetEmpCodeExt(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpCodeAutoExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetBookNameExt(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookNameAutoExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function getStudentIdName(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StdCodeAutoComplete", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Getduplicate(ByVal ELIssue As BookIssue) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
        arParms(0).Value = ELIssue.Issuedate '4/9/2012

        arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
        arParms(1).Value = ELIssue.StdCode

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = ELIssue.EmpCode
        arParms(3) = New SqlParameter("@BookID", SqlDbType.Int)
        arParms(3).Value = ELIssue.BookCode

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateBookIssue", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetBookNameExtN(ByVal prefixText As String, ByVal Dept As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        arParms(3) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(3).Value = Dept
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookNameAutoExtN", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DisplayGridValueByID(ByVal ELIssue As BookIssue) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Std_Emp", SqlDbType.VarChar, 50)
        arParms(2).Value = ELIssue.Std_Emp

        arParms(3) = New SqlParameter("@ID ", SqlDbType.Int)
        arParms(3).Value = ELIssue.id

        arParms(4) = New SqlParameter("@StdId", SqlDbType.Int)
        arParms(4).Value = ELIssue.Stdid

        arParms(5) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(5).Value = ELIssue.Empid


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookIssueDetailsByID", arParms)
        Return ds.Tables(0)
    End Function

End Class
