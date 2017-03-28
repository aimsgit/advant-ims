Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class EmpTransD

    Shared Function GetEmp(ByVal prefix As String) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@prefix", SqlDbType.VarChar, 50)
            arParms(0).Value = prefix

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FillBranchName", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function GetEmpDetails() As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmployeeTransfer", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetEmpDetails(ByVal I As Integer) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@I", SqlDbType.Int)
            arParms(2).Value = I

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmployeeTransferApproval", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function insert(ByVal c As EmpTransE) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@ToBranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = c.TOBRANCH
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = c.EmpID
        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
        arParms(4) = New SqlParameter("@SesEmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")
        arParms(5) = New SqlParameter("@DOL", SqlDbType.DateTime)
        arParms(5).Value = c.DOL
        arParms(6) = New SqlParameter("@DOJ", SqlDbType.DateTime)
        arParms(6).Value = c.DOJ
        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = c.EmpCode
        arParms(8) = New SqlParameter("@TransferRemarks", SqlDbType.VarChar, 255)
        arParms(8).Value = c.TransferRemarks

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateEmployeeBranchCode", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function


    Shared Function GetBranchTypecombo() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BranchComboWithType", arParms)
        Return ds.Tables(0)
    End Function
    'Added Dept and Sort By DDL in Employee Details Report. By: Niraj on 18-May-2013
    Shared Function finalExamRpt(ByVal Desig As Integer, ByVal SalGrade As String, ByVal doj As Integer, ByVal fromdate As Date, ByVal todate As Date, ByVal DeptId As Integer, ByVal SortBy As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@DesigId", SqlDbType.Int)
        arParms(2).Value = Desig

        arParms(3) = New SqlParameter("@SalaryGrade", SqlDbType.VarChar, 50)
        arParms(3).Value = SalGrade

        arParms(4) = New SqlParameter("@DojDol", SqlDbType.Int)
        arParms(4).Value = doj

        If fromdate = "1/1/1900" Then
            arParms(5) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(5).Value = System.DBNull.Value
        Else
            arParms(5) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(5).Value = fromdate
            fromdate = Format(fromdate, "dd-MMM-yyyy")
        End If

        arParms(6) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(6).Value = todate
        todate = Format(todate, "dd-MMM-yyyy")

        arParms(7) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(7).Value = DeptId

        arParms(8) = New SqlParameter("@SortBy", SqlDbType.Int)
        arParms(8).Value = SortBy
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_EmployeeDetails", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function finalEmpRptAICTE(ByVal Id As String, ByVal Desig As Integer, ByVal SalGrade As Integer, ByVal DeptId As Integer, ByVal SortBy As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@DesigId", SqlDbType.Int)
        arParms(2).Value = Desig

        arParms(3) = New SqlParameter("@SalaryGrade", SqlDbType.Int)
        arParms(3).Value = SalGrade

        'arParms(4) = New SqlParameter("@DojDol", SqlDbType.Int)
        'arParms(4).Value = doj

        'If fromdate = "1/1/1900" Then
        '    arParms(5) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        '    arParms(5).Value = System.DBNull.Value
        'Else
        '    arParms(5) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        '    arParms(5).Value = fromdate
        '    fromdate = Format(fromdate, "dd-MMM-yyyy")
        'End If

        'arParms(6) = New SqlParameter("@todate", SqlDbType.DateTime)
        'arParms(6).Value = todate
        'todate = Format(todate, "dd-MMM-yyyy")

        arParms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(4).Value = DeptId

        arParms(5) = New SqlParameter("@SortBy", SqlDbType.Int)
        arParms(5).Value = SortBy
        arParms(6) = New SqlParameter("@ColumnNames", SqlDbType.VarChar)
        arParms(6).Value = Id

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_EmployeeDetailAICTE", arParms)
        Return ds.Tables(0)
    End Function




    Shared Function Designation() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim El As New EmpTransE

        Dim arParms() As SqlParameter = New SqlParameter(2) {}


        arParms(0) = New SqlParameter("@DID", SqlDbType.Int)
        arParms(0).Value = El.DID

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetDesignation", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DesignationNEW(ByVal SalaryCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim El As New EmpTransE

        Dim arParms() As SqlParameter = New SqlParameter(3) {}


        arParms(0) = New SqlParameter("@DID", SqlDbType.Int)
        arParms(0).Value = El.DID

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Grade", SqlDbType.VarChar, 50)
        arParms(3).Value = SalaryCode


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetDesignation", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DesignationAICTE() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim El As New EmpTransE

        Dim arParms() As SqlParameter = New SqlParameter(2) {}


        arParms(0) = New SqlParameter("@DID", SqlDbType.Int)
        arParms(0).Value = El.DID

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetDesignationAICTE", arParms)
        Return ds.Tables(0)
    End Function


    Shared Function GetDeptTypeAll() As System.Data.DataTable
        'Function for Inserting the data into DDL. By: Niraj 18-05-2013 .
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlDepartmentReport", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetBranchTypecombo1() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "NewBranchCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetGrade() As Data.DataTable
        '25-09-2014 - Venkatesh Pasupuleti-Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetSalaryGrade", arParms)

        Return ds.Tables(0)
    End Function
    Shared Function GetGradeNEW(ByVal Designation) As Data.DataTable
        '25-09-2014 - Venkatesh Pasupuleti-Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@offic", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(0) = New SqlParameter("@Designation_Id", SqlDbType.Int)
        arParms(0).Value = Designation()
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetSalaryGrade", arParms)

        Return ds.Tables(0)
    End Function


    Shared Function GetGradeAICTE() As Data.DataTable
        '25-09-2014 - Venkatesh Pasupuleti-Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetSalaryGradeAICTE", arParms)

        Return ds.Tables(0)

    End Function
    Shared Function finalDynEmpRptAICTE() As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewEmployeeDetailGridAICTE")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
End Class

