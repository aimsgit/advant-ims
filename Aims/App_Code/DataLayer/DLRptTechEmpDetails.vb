Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLRptTechEmpDetails
    Shared Function finalEmpRptAICTE(ByVal Id As String, ByVal Desig As Integer, ByVal SalGrade As Integer, ByVal DeptId As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

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

        'arParms(5) = New SqlParameter("@SortBy", SqlDbType.Int)
        'arParms(5).Value = SortBy
        arParms(5) = New SqlParameter("@ColumnNames", SqlDbType.VarChar)
        arParms(5).Value = Id

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_TechEmployeeDetailAICTE", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function finalDynEmpRptAICTE() As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TechEmployeeAICTE")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetDeptType() As System.Data.DataTable
        'Function for Inserting the data into DDL. By: Niraj 26-03-2013 .
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLDeptTypeTech", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetGrade() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetSalaryGradeTech", arParms)

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


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetDesignationTech", arParms)
        Return ds.Tables(0)
    End Function
End Class
