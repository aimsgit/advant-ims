Imports Microsoft.VisualBasic
Imports System
Imports System.Data.SqlClient
'Namespace GlobalDataSetTableAdapters
Public Class BookReturnD
    'Shared Function Insert(ByVal ELBookREturn As BookReturnP) As Integer
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim rowsAffected As Integer = 0

    '    Dim arParms() As SqlParameter = New SqlParameter(5) {}

    '    'arParms(0) = New SqlParameter("@name", SqlDbType.Char, c.Name.Length)
    '    'arParms(0).Value = c.Name

    '    'arParms(1) = New SqlParameter("@code", SqlDbType.Char, c.Code.Length)
    '    'arParms(1).Value = c.Code

    '    'arParms(2) = New SqlParameter("@CourseType", SqlDbType.Int)
    '    'arParms(2).Value = c.CourseType

    '    'arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    'arParms(3).Value = HttpContext.Current.Session("BranchCode")

    '    'arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
    '    'arParms(4).Value = HttpContext.Current.Session("UserCode")

    '    'arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
    '    'arParms(5).Value = HttpContext.Current.Session("EmpCode")
    '    Try
    '        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    '    Return rowsAffected
    'End Function
    Shared Function Update(ByVal ELBookREturn As BookReturnP) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@BookID", SqlDbType.Int)
        arParms(0).Value = ELBookREturn.BookCode

        arParms(1) = New SqlParameter("@StdID", SqlDbType.Int)
        arParms(1).Value = ELBookREturn.STD_ID


        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = ELBookREturn.EmpID

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@ActualReturnDate", SqlDbType.DateTime)
        arParms(6).Value = ELBookREturn.ReturnDate

        arParms(7) = New SqlParameter("@fine", SqlDbType.Money)
        arParms(7).Value = ELBookREturn.Fine

        arParms(8) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(8).Value = ELBookREturn.DeptId
        arParms(9) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(9).Value = ELBookREturn.Branch
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_NewUpdateBookReturn", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Shared Function ChangeFlag(ByVal ELBookREturn As BookReturnP) As Integer
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim rowsAffected As Integer = 0
    '    Dim arParms As SqlParameter = New SqlParameter

    '    arParms = New SqlParameter("", SqlDbType.BigInt)
    '    arParms.Value = ELBookREturn.id
    '    Try
    '        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return rowsAffected
    'End Function
    Shared Function GetBookCodecombo(ByVal ELBookREturn As BookReturnP) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(5) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")

        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")


        Para(2) = New SqlParameter("@StdId", SqlDbType.Int)
        Para(2).Value = ELBookREturn.STD_ID

        Para(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        Para(3).Value = ELBookREturn.EmpID

        Para(4) = New SqlParameter("@DeptId", SqlDbType.Int)
        Para(4).Value = ELBookREturn.DeptId
        Para(5) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        Para(5).Value = ELBookREturn.Branch

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "New_getSelectBook", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBookReturn(ByVal ELBookREturn As BookReturnP) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@StdId", SqlDbType.Int)
        arParms(2).Value = ELBookREturn.STD_ID

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(3).Value = ELBookREturn.EmpID


        arParms(4) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(4).Value = ELBookREturn.id


        arParms(5) = New SqlParameter("@Std_Emp", SqlDbType.VarChar, 50)
        arParms(5).Value = ELBookREturn.Std_Emp

        arParms(6) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(6).Value = ELBookREturn.DeptId
        arParms(7) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(7).Value = ELBookREturn.Branch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewGetBookReturn", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getStudentIdName2(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefixText", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StdCodeAutoComplete", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetBookName(ByVal ELBookREturn As BookReturnP) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(6) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")

        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")

        Para(2) = New SqlParameter("@BookId", SqlDbType.Int)
        Para(2).Value = ELBookREturn.BookID

        Para(3) = New SqlParameter("@StdId", SqlDbType.Int)
        Para(3).Value = ELBookREturn.STD_ID

        Para(4) = New SqlParameter("@EmpID", SqlDbType.Int)
        Para(4).Value = ELBookREturn.EmpID

        Para(5) = New SqlParameter("@DeptId", SqlDbType.Int)
        Para(5).Value = ELBookREturn.DeptId
        Para(6) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        Para(6).Value = ELBookREturn.Branch

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "New_getSelectBookName", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Shared Function CheckDuplicate(ByVal ELBookREturn As BookReturnP) As Data.DataTable
    '    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet

    '    Dim Para() As SqlParameter = New SqlParameter(1) {}
    '    Para(0) = New SqlParameter("", SqlDbType.VarChar, 50)
    '    Para(0).Value = 
    '    Para(1) = New SqlParameter("", SqlDbType.VarChar, 50)
    '    Para(1).Value = HttpContext.Current.Session("BranchCode")


    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "", Para)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
End Class
'End Namespace

