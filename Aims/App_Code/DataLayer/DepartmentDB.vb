Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DepartmentDB
    'Shared Function getDepartment() As System.Data.DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    Dim id As Integer
    '    'If id = 0 Then
    '    '    Dim arParms() As SqlParameter = New SqlParameter(1) {}
    '    '    arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    '    arParms(0).Value = HttpContext.Current.Session("Office")
    '    '    arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    '    arParms(1).Value = HttpContext.Current.Session("BranchCode")
    '    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDeptDetails", arParms)
    '    'Else
    '    Dim arParms() As SqlParameter = New SqlParameter(2) {}
    '    arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    arParms(0).Value = HttpContext.Current.Session("Office")
    '    arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    arParms(1).Value = HttpContext.Current.Session("BranchCode")
    '    arParms(2) = New SqlParameter("@DeptID", SqlDbType.Int)
    '    arParms(2).Value = id
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDeptDetailsByID", arParms)
    '    'End If
    '    Return ds


    'End Function

    Shared Function getDepartmentDtls(ByVal Department As Department) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = Department.Id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDeptDetails", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function Insert(ByVal c As Department) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

       
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@empid", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@DeptName", SqlDbType.NVarChar, 150)
        arParms(2).Value = c.Name

        arParms(3) = New SqlParameter("@DeptCode", SqlDbType.NVarChar, 50)
        arParms(3).Value = c.Code
       

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveDepartmentDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal s As Department) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        'arParms(1) = New SqlParameter("@DeptName", SqlDbType.VarChar, 50)
        'arParms(1).Value = s.Name
        arParms(1) = New SqlParameter("@DeptCode", SqlDbType.NVarChar, 50)
        arParms(1).Value = s.Code
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = s.Id

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "GetDuplicatedeptMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function


    Shared Function Update(ByVal c As Department) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@DeptName", SqlDbType.NVarChar, 150)
        arParms(0).Value = c.Name

        arParms(1) = New SqlParameter("@DeptCode", SqlDbType.NVarChar, 50)
        arParms(1).Value = c.Code
        arParms(2) = New SqlParameter("@Dept_ID", SqlDbType.Int)
        arParms(2).Value = c.Id
        arParms(3) = New SqlParameter("@empid", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateDepartment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Dept_ID", SqlDbType.Int)
        arParms(0).Value = Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteDepartment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Shared Function getDept(ByVal Inst As Int64, ByVal Brch As Int64) As System.Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet

    '    Dim arParms() As SqlParameter = New SqlParameter(1) {}
    '    arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    arParms(0).Value = htt
    '    arParms(1) = New SqlParameter("@branchid", SqlDbType.)
    '    arParms(1).Value = Brch
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDeptDetails", arParms)
    '    Return ds.Tables(0)
    'End Function
    'Public Function GetDuplicateName(ByVal DesignationP As DesignationP) As Data.DataTable
    '    Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim para() As SqlParameter = New SqlParameter(2) {}
    '    para(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
    '    para(0).Value = HttpContext.Current.Session("office")
    '    para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    para(1).Value = HttpContext.Current.Session("BranchCode")
    '    para(2) = New SqlParameter("@Designation", SqlDbType.VarChar, 50)
    '    para(2).Value = DesignationP.Designation
    '    Try
    '        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateNameType", para)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function


End Class
