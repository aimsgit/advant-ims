Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class EmployeeDB
    Public Shared Function Getbranch() As DataSet
        Dim ds As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataForBrachCombo")
        Return ds
    End Function
    Public Shared Function Insert(ByVal E As Employee) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(28) {}

        arParms(0) = New SqlParameter("@emp_name", SqlDbType.Char)
        arParms(0).Value = E.Emp_Name

        arParms(1) = New SqlParameter("@emp_code", SqlDbType.Char)
        arParms(1).Value = E.Emp_Code

        arParms(2) = New SqlParameter("@emp_category", SqlDbType.Int)
        arParms(2).Value = E.Emp_Category

        arParms(3) = New SqlParameter("@employmeny_type", SqlDbType.Int)
        arParms(3).Value = E.Employment_Type

        arParms(4) = New SqlParameter("@dob", SqlDbType.DateTime)
        arParms(4).Value = E.DOB

        arParms(5) = New SqlParameter("@doj", SqlDbType.DateTime)
        arParms(5).Value = E.DOJ

        arParms(6) = New SqlParameter("@dol", SqlDbType.DateTime)
        arParms(6).IsNullable = True

        If E.DOL = Nothing Then
            arParms(6).Value = System.Data.SqlTypes.SqlDateTime.Null
        Else

            arParms(6).Value = E.DOL
        End If

        arParms(7) = New SqlParameter("@designation", SqlDbType.VarChar, 100)
        arParms(7).Value = E.Designation

        arParms(8) = New SqlParameter("@branch_ID", SqlDbType.Int, 10)
        arParms(8).Value = E.Branch_ID

        arParms(9) = New SqlParameter("@institute_ID", SqlDbType.Int, 10)
        arParms(9).Value = E.Institute_ID

        arParms(10) = New SqlParameter("@dept_ID", SqlDbType.Int, 10)
        arParms(10).Value = E.Dept_ID

        arParms(11) = New SqlParameter("@salary", SqlDbType.Money, 10)
        arParms(11).Value = E.Salary

        arParms(12) = New SqlParameter("@accountNo", SqlDbType.VarChar, 50)
        arParms(12).Value = E.AccountNo

        arParms(13) = New SqlParameter("@bank_ID", SqlDbType.Int, 10)
        arParms(13).Value = E.Bank_ID

        arParms(14) = New SqlParameter("@emp_Address", SqlDbType.VarChar, 250)
        arParms(14).Value = E.Emp_Address

        arParms(15) = New SqlParameter("@emp_City", SqlDbType.VarChar, 100)
        arParms(15).Value = E.Emp_City

        arParms(16) = New SqlParameter("@zip", SqlDbType.VarChar, 50)
        arParms(16).Value = E.Zip

        arParms(17) = New SqlParameter("@state", SqlDbType.Int)
        arParms(17).Value = E.State

        arParms(18) = New SqlParameter("@country", SqlDbType.VarChar, 100)
        arParms(18).Value = E.Country

        arParms(19) = New SqlParameter("@contact_No1", SqlDbType.VarChar, 50)
        arParms(19).Value = E.Contact_No1

        arParms(20) = New SqlParameter("@email", SqlDbType.VarChar, 50)
        arParms(20).Value = E.Email

        arParms(21) = New SqlParameter("@photo", SqlDbType.VarChar, 250)
        arParms(21).Value = E.Photos

        arParms(22) = New SqlParameter("@itcategory", SqlDbType.VarChar, 50)
        arParms(22).Value = E.ITCategory

        arParms(23) = New SqlParameter("@emp_ID", SqlDbType.Int, 10)
        arParms(23).Value = E.Emp_Id

        arParms(24) = New SqlParameter("@district", SqlDbType.Char, 100)
        arParms(24).Value = E.District

        arParms(25) = New SqlParameter("@contact_No2", SqlDbType.Char, 100)
        arParms(25).Value = E.Contact_No2

        If E.UniqueCode = Nothing Then
            arParms(26) = New SqlParameter("@UniqueCode", SqlDbType.Char, 0)
            arParms(26).Value = ""
        Else
            arParms(26) = New SqlParameter("@UniqueCode", SqlDbType.Char, E.UniqueCode.Length)
            arParms(26).Value = E.UniqueCode
        End If

        If E.TransferTo = Nothing Then
            arParms(27) = New SqlParameter("@TransferTo", SqlDbType.Int)
            arParms(27).Value = 0
        Else
            arParms(27) = New SqlParameter("@TransferTo", SqlDbType.Int)
            arParms(27).Value = E.TransferTo
        End If
        arParms(28) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(28).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveEmpDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected

    End Function

    Shared Function GVDetails(ByVal empId As Integer) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        If empId = 0 Then
            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpDetails", arParms)
        Else
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Emp_ID", SqlDbType.Int)
            arParms(0).Value = empId
            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")
            arParms(2) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpDetailsByEmpID", arParms)
        End If
        Return ds
    End Function
    Shared Function Delete(ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@emp_ID", SqlDbType.Int, 10)
        arParms.Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SP_DeleteEmpDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GVComboUserIB(ByVal Iid As Long, ByVal Bid As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Iid", SqlDbType.Int)
        arParms(0).Value = Iid
        arParms(1) = New SqlParameter("@Bid", SqlDbType.Int)
        arParms(1).Value = Bid
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpComboDetByInsBr", arParms)

        Return ds
    End Function
    Shared Function GVCombo() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dataSet As DataSet = New DataSet
        ' "select Emp_Name,Emp_Id from EmployeeMaster Where Del_Flag=0 ORDER BY Emp_Name"
        Try
            dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getEmployeeName")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dataSet
    End Function

    Shared Function GVComboUser(ByVal id As Long, ByVal Iid As Long, ByVal Bid As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If id = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmployee")
        Else
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@id", SqlDbType.Int)
            arParms(0).Value = id
            arParms(1) = New SqlParameter("@Iid", SqlDbType.Int)
            arParms(1).Value = Iid
            arParms(2) = New SqlParameter("@Bid", SqlDbType.Int)
            arParms(2).Value = Bid
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpComboDetByEmpID", arParms)
        End If
        Return ds
    End Function
    Public Function GetCategory(ByVal dept As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(0).Value = dept
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_getCategory", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpID(ByVal code As String, ByVal inst As Long, ByVal brch As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@code", SqlDbType.Char)
        arParms(0).Value = code

        arParms(1) = New SqlParameter("@inst", SqlDbType.Int)
        arParms(1).Value = inst

        arParms(2) = New SqlParameter("@brch", SqlDbType.Int)
        arParms(2).Value = brch

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpId", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function GetDatEmp(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        arParms(0) = New SqlClient.SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(0).Value = prefixText
        arParms(1) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetEmpExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetDatEmpCode(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@Emp_Code", SqlDbType.VarChar, 50)
        arParms.Value = prefixText
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetEmpCodeExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetDatEmpCodeExt(ByVal prefixText As String, ByVal inst As Long, ByVal brnch As Long) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Institute_Id", SqlDbType.Char)
        arParms(0).Value = inst

        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = brnch

        arParms(2) = New SqlParameter("@Emp_Code", SqlDbType.VarChar, 50)
        arParms(2).Value = prefixText

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetEmpCodeExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpSelExt(ByVal prefixText As String, ByVal DeptId As Int32, ByVal Attendance_ID As Integer) As Data.DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim arParms() As SqlParameter = New SqlParameter(4) {}
            arParms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, prefixText.Length)
            arParms(0).Value = prefixText

            'arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            'arParms(1).Value = EmpCode

            arParms(1) = New SqlParameter("@Deptid", SqlDbType.Int)
            arParms(1).Value = DeptId

            arParms(2) = New SqlParameter("@Attandance_ID", SqlDbType.Int)
            arParms(2).Value = Attendance_ID

            arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("Office")
            
            arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(3).Value = HttpContext.Current.Session("BranchCode")

            arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(4).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetEmpSelExt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpComboDayBook(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If id = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpDetailsComboDB")
        Else
            Dim arParms As SqlParameter = New SqlParameter("@Emp_Id", SqlDbType.Int, 10)
            arParms.Value = id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpDetailsComboDBbyID", arParms)
        End If
        Return ds
    End Function
    Shared Function RptGVDetails(ByVal inst As Int64, ByVal brch As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = inst
        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = brch


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptEmpDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function UpdateTransferTo(ByVal E As Employee) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@transferto", SqlDbType.Int)
        arParms(0).Value = E.TransferTo

        arParms(1) = New SqlParameter("@empid", SqlDbType.Int)
        arParms(1).Value = E.Emp_Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateEmployeeBrch", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function getEmployeeExt(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        arParms(0) = New SqlClient.SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(0).Value = prefixText
        arParms(1) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetEmpExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpidDetails(ByVal empId As Integer, ByVal Inst As Int64, ByVal Brch As Int64) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Emp_ID", SqlDbType.Int)
        arParms(0).Value = empId
        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = Brch
        arParms(2) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(2).Value = Inst
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpDetailsByEmpID", arParms)

        Return ds.Tables(0)
    End Function
    Shared Function GetCategoryDetails(ByVal dept As Integer, ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Dept", SqlDbType.Int, 10)
        arParms(0).Value = dept
        arParms(1) = New SqlParameter("@instituteid", SqlDbType.Int)
        arParms(1).Value = Inst
        arParms(2) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(2).Value = Brch
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_getCategory", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function EmpCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmpComboWorkflow", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function EmpCombo1(ByVal Branchcode As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = Branchcode

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmpCombo1", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function CountryCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCountryEMP", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function NewEmployeeComboforClassDashboard() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewEmployeeComboforClassDashboard", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function RecepitCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlRecepit", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DeptCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlDept", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function ddlEmp() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmpCombo1", arParms)
        Return ds.Tables(0)
    End Function

    Public Function GetEmpAttenRegisterRptWorkingHours(ByVal Dept As Integer, ByVal Emp As Integer, ByVal FrmMonth As Integer, ByVal ToMonth As Integer, ByVal FrmYear As Integer, ByVal ToYear As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(7) {}


        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")

        param(2) = New SqlParameter("@Dept", SqlDbType.Int)
        param(2).Value = Dept

        param(3) = New SqlParameter("@Emp", SqlDbType.Int)
        param(3).Value = Emp

        param(4) = New SqlParameter("@FrmMonth", SqlDbType.Int)
        param(4).Value = FrmMonth

        param(5) = New SqlParameter("@ToMonth", SqlDbType.Int)
        param(5).Value = ToMonth

        param(6) = New SqlParameter("@FrmYear", SqlDbType.Int)
        param(6).Value = FrmYear

        param(7) = New SqlParameter("@ToYear", SqlDbType.Int)
        param(7).Value = ToYear


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_NewEmpAttendanceWorking", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function GetEmpAttenRegisterRpt(ByVal Dept As Integer, ByVal Emp As Integer, ByVal FrmMonth As Integer, ByVal ToMonth As Integer, ByVal FrmYear As Integer, ByVal ToYear As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(7) {}


        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")

        param(2) = New SqlParameter("@Dept", SqlDbType.Int)
        param(2).Value = Dept

        param(3) = New SqlParameter("@Emp", SqlDbType.Int)
        param(3).Value = Emp

        param(4) = New SqlParameter("@FrmMonth", SqlDbType.Int)
        param(4).Value = FrmMonth

        param(5) = New SqlParameter("@ToMonth", SqlDbType.Int)
        param(5).Value = ToMonth

        param(6) = New SqlParameter("@FrmYear", SqlDbType.Int)
        param(6).Value = FrmYear

        param(7) = New SqlParameter("@ToYear", SqlDbType.Int)
        param(7).Value = ToYear


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_NewEmpAttendance", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Shared Function EmpIDCombo(ByVal Branchcode As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = Branchcode

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmpIDCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ddlEmpDeptwise(ByVal DeptID As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlClient.SqlParameter("@Dept", SqlDbType.Int)
        arParms(2).Value = DeptID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmpComboDeptwise", arParms)
        Return ds.Tables(0)
    End Function
End Class
