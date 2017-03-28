Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLSalaryScaleGrade
    Public Function InsertSalaryScale(ByVal EL As ELSalaryScaleGrade) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(14) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Empcode")
        arParms(3) = New SqlParameter("@Grade", SqlDbType.NVarChar, 250)
        arParms(3).Value = EL.Grade
        arParms(4) = New SqlParameter("@MinScale", SqlDbType.NVarChar, 250)
        arParms(4).Value = EL.MinScale
        'arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        'arParms(5).Value = EL.id
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@Inc1", SqlDbType.NVarChar, 200)
        arParms(6).Value = EL.Inc1
        arParms(7) = New SqlParameter("@Inc2", SqlDbType.NVarChar, 200)
        arParms(7).Value = EL.Inc2
        arParms(8) = New SqlParameter("@Inc3", SqlDbType.NVarChar, 200)
        arParms(8).Value = EL.Inc3

        'If EL.Step1 = "" Then
        '    arParms(9) = New SqlParameter("@Step1", SqlDbType.Int)
        '    arParms(9).Value = System.DBNull.Value
        'Else
        '    arParms(9) = New SqlParameter("@Step1", SqlDbType.Int)
        '    arParms(9).Value = EL.Step1
        'End If

        arParms(9) = New SqlParameter("@Step1", SqlDbType.Int)
        arParms(9).Value = EL.Step1
        arParms(10) = New SqlParameter("@Step2", SqlDbType.Int)
        arParms(10).Value = EL.Step2
        arParms(11) = New SqlParameter("@Step3", SqlDbType.Int)
        arParms(11).Value = EL.Step3
        arParms(12) = New SqlParameter("@MaxScale", SqlDbType.NVarChar, 250)
        arParms(12).Value = EL.MaxScale
        arParms(13) = New SqlParameter("@SalaryBand", SqlDbType.VarChar, 50)
        arParms(13).Value = EL.SalaryBand

        arParms(14) = New SqlParameter("@EmpType", SqlDbType.VarChar, 100)
        arParms(14).Value = EL.EmpType

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NewInsertSalryGradeMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function DeleteSalryScale(ByVal EL As ELSalaryScaleGrade) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteSalryGraid", arParms)
        Return rowsaffected
    End Function
    Shared Function DisplayGridview(ByVal id As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim rowsAffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(2) {}
        Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(0).Value = id


        Params(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(1).Value = HttpContext.Current.Session("BranchCode")

        Params(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(2).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "NewDisplaySalaryScale", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateSalaryScale(ByVal EL As ELSalaryScaleGrade) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(15) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Grade", SqlDbType.NVarChar, 250)
        arParms(2).Value = EL.Grade
        arParms(3) = New SqlParameter("@MinScale", SqlDbType.NVarChar, 250)
        arParms(3).Value = EL.MinScale
        arParms(4) = New SqlParameter("@id", SqlDbType.Int)
        arParms(4).Value = EL.id
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Empcode")
        arParms(7) = New SqlParameter("@Inc1", SqlDbType.NVarChar, 200)
        arParms(7).Value = EL.Inc1
        arParms(8) = New SqlParameter("@Inc2", SqlDbType.NVarChar, 200)
        arParms(8).Value = EL.Inc2
        arParms(9) = New SqlParameter("@Inc3", SqlDbType.NVarChar, 200)
        arParms(9).Value = EL.Inc3
        'If EL.Step1 = "" Then
        '    arParms(10) = New SqlParameter("@Step1", SqlDbType.Int)
        '    arParms(10).Value = System.DBNull.Value
        'Else
        '    arParms(10) = New SqlParameter("@Step1", SqlDbType.Int)
        '    arParms(10).Value = EL.Step1
        'End If
        arParms(10) = New SqlParameter("@Step1", SqlDbType.Int)
        arParms(10).Value = EL.Step1
        arParms(11) = New SqlParameter("@Step2", SqlDbType.Int)
        arParms(11).Value = EL.Step2
        arParms(12) = New SqlParameter("@Step3", SqlDbType.Int)
        arParms(12).Value = EL.Step3
        arParms(13) = New SqlParameter("@MaxScale", SqlDbType.NVarChar, 250)
        arParms(13).Value = EL.MaxScale
        arParms(14) = New SqlParameter("@SalaryBand", SqlDbType.VarChar, 50)
        arParms(14).Value = EL.SalaryBand
        arParms(15) = New SqlParameter("@EmpType", SqlDbType.VarChar, 100)
        arParms(15).Value = EL.EmpType
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NewUpdateSalryGraid", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CheckDuplicate(ByVal EL As ELSalaryScaleGrade) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Grade", SqlDbType.NVarChar, 250)
        arParms(1).Value = EL.Grade
        'arParms(2) = New SqlParameter("@ScaleRange", SqlDbType.NVarChar, 250)
        'arParms(2).Value = EL.ScaleRange
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = EL.id

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetNewDuplicateScaleSalaryGrade", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function ddlSalryBand() As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")




        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_GetddlsalryBand", arParms)
        Return ds.Tables(0)
    End Function
End Class
