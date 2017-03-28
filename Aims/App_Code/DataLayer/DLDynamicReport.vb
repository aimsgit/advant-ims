Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLDynamicReport
    Shared Function GetColumnNames() As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdMasterColumns")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetRptdata(ByVal id As String) As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim param() As SqlParameter = New SqlParameter(0) {}
            param(0) = New SqlParameter("@ColumnNames", SqlDbType.VarChar)
            param(0).Value = id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_DynamicReport", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function AdmissionRegisterDynamic() As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewAdmissionRegisterDynamicGrid")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function AdmissionRegisterDynamic(ByVal Branch As String, ByVal Course As Integer, ByVal Batch As Integer, ByVal Gender As String, ByVal State As Integer, ByVal Feecollected As String, ByVal id As String, ByVal CountryId As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        If Branch = "0" Then
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode") '003201010102
        Else
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = Branch
        End If

        arParms(1) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(1).Value = Course '0

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = Batch '0

        'arParms(3) = New SqlParameter("@AYear", SqlDbType.Int)
        'arParms(3).Value = AYear '94

        arParms(3) = New SqlParameter("@Gender", SqlDbType.VarChar, 50)
        arParms(3).Value = Gender 'All

        arParms(4) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(4).Value = State '0

        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office") 'i

        arParms(6) = New SqlParameter("@Feecollected", SqlDbType.VarChar, 50)
        arParms(6).Value = Feecollected 'A

        arParms(7) = New SqlParameter("@ColumnNames", SqlDbType.VarChar)
        arParms(7).Value = id
        arParms(8)  =New SqlParameter("@CountryId", SqlDbType.VarChar)
        arParms(8).Value = CountryId
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_NewAdmissionDetailsDynamic", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function AssetDynamicReport() As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AssetReoprtDynamicGrid")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function AssetDetailsDynamicReport(ByVal Type As Integer, ByVal Supplier As Integer, ByVal Manufacturer As Integer, ByVal id As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Type", SqlDbType.Int)
        arParms(0).Value = Type '0

        arParms(1) = New SqlParameter("@Supplier", SqlDbType.Int)
        arParms(1).Value = Supplier '0

        
        arParms(2) = New SqlParameter("@Manufacturer", SqlDbType.Int)
        arParms(2).Value = Manufacturer 'All

        
        arParms(3) = New SqlParameter("@ColumnNames", SqlDbType.VarChar)
        arParms(3).Value = id

        arParms(4) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Rpt_AssetDetailsDynamicReport]", arParms)
        Return ds.Tables(0)
    End Function
End Class