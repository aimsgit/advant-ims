Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLRptEmpMedicalDetails
    Shared Function GetEmpcombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EmpCombowithCode", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptGetEmpMedicalDetails(ByVal EmpId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(2).Value = EmpId

        arParms(3) = New SqlParameter("@LoginType", SqlDbType.VarChar, 500)
        arParms(3).Value = HttpContext.Current.Session("LoginType")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_EmpMedicalDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function insertBranchCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_SelectBranchComboEOD", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetEmpDDL(ByVal Branch As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
            Parms(2).Value = Branch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLEmpOtherDet", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Public Function RptGetEmpDetails(ByVal EmpId As Integer, ByVal Branch As String) As DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}
    '    arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    arParms(0).Value = HttpContext.Current.Session("BranchCode")

    '    arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
    '    arParms(1).Value = HttpContext.Current.Session("Office")

    '    arParms(2) = New SqlParameter("@EmpId", SqlDbType.Int)
    '    arParms(2).Value = EmpId

    '    arParms(3) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
    '    arParms(3).Value = Branch

    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptEmpQualificationDetails", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    Public Function RptGetEmpQualification(ByVal BranchName As String, ByVal Department As String, ByVal EmpType As String, ByVal EmpCat As String, ByVal EmpName As String, ByVal Designation As String, ByVal Qualification As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchName

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchName", SqlDbType.VarChar, 50)
        arParms(2).Value = BranchName

        arParms(3) = New SqlParameter("@Department", SqlDbType.VarChar, 50)
        arParms(3).Value = Department

        arParms(4) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        arParms(4).Value = EmpType

        arParms(5) = New SqlParameter("@EmpCat", SqlDbType.VarChar, 50)
        arParms(5).Value = EmpCat

        arParms(6) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(6).Value = EmpName

        arParms(7) = New SqlParameter("@Designation", SqlDbType.VarChar, 150)
        arParms(7).Value = Designation


        arParms(8) = New SqlParameter("@Qualification", SqlDbType.VarChar, 150)
        arParms(8).Value = Qualification

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptEmpQualificationDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptGetEmpResearch(ByVal BranchName As String, ByVal Department As String, ByVal EmpType As String, ByVal EmpCat As String, ByVal EmpName As String, ByVal Designation As String, ByVal Qualification As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchName

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchName", SqlDbType.VarChar, 50)
        arParms(2).Value = BranchName

        arParms(3) = New SqlParameter("@Department", SqlDbType.VarChar, 50)
        arParms(3).Value = Department

        arParms(4) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        arParms(4).Value = EmpType

        arParms(5) = New SqlParameter("@EmpCat", SqlDbType.VarChar, 50)
        arParms(5).Value = EmpCat

        arParms(6) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(6).Value = EmpName

        arParms(7) = New SqlParameter("@Designation", SqlDbType.VarChar, 150)
        arParms(7).Value = Designation


        arParms(8) = New SqlParameter("@Qualification", SqlDbType.VarChar, 150)
        arParms(8).Value = Qualification

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptEmpPublication", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptGetEmpExperience(ByVal BranchName As String, ByVal Department As String, ByVal EmpType As String, ByVal EmpCat As String, ByVal EmpName As String, ByVal Designation As String, ByVal Qualification As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchName

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchName", SqlDbType.VarChar, 50)
        arParms(2).Value = BranchName

        arParms(3) = New SqlParameter("@Department", SqlDbType.VarChar, 50)
        arParms(3).Value = Department

        arParms(4) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        arParms(4).Value = EmpType

        arParms(5) = New SqlParameter("@EmpCat", SqlDbType.VarChar, 50)
        arParms(5).Value = EmpCat

        arParms(6) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(6).Value = EmpName

        arParms(7) = New SqlParameter("@Designation", SqlDbType.VarChar, 150)
        arParms(7).Value = Designation


        arParms(8) = New SqlParameter("@Qualification", SqlDbType.VarChar, 150)
        arParms(8).Value = Qualification

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptExpDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptGetEmpMedical(ByVal BranchName As String, ByVal Department As String, ByVal EmpType As String, ByVal EmpCat As String, ByVal EmpName As String, ByVal Designation As String, ByVal Qualification As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchName

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchName", SqlDbType.VarChar, 50)
        arParms(2).Value = BranchName

        arParms(3) = New SqlParameter("@Department", SqlDbType.VarChar, 50)
        arParms(3).Value = Department

        arParms(4) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        arParms(4).Value = EmpType

        arParms(5) = New SqlParameter("@EmpCat", SqlDbType.VarChar, 50)
        arParms(5).Value = EmpCat

        arParms(6) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(6).Value = EmpName

        arParms(7) = New SqlParameter("@Designation", SqlDbType.VarChar, 150)
        arParms(7).Value = Designation


        arParms(8) = New SqlParameter("@Qualification", SqlDbType.VarChar, 150)
        arParms(8).Value = Qualification

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetEmpMedical", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
