Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DLReportsP
    Shared Function SchemeWiseCollAmt(ByVal frmdate As Date, ByVal todte As Date, ByVal dist As String, ByVal scheme As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@frmdate", SqlDbType.DateTime)
        arParms(0).Value = frmdate

        arParms(1) = New SqlParameter("@todte", SqlDbType.DateTime)
        arParms(1).Value = todte

        arParms(2) = New SqlParameter("@dist", SqlDbType.VarChar)
        arParms(2).Value = dist

        arParms(3) = New SqlParameter("@Scheme", SqlDbType.VarChar)
        arParms(3).Value = scheme

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SchemWiseCollectnAmt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SchemeWiseCollAmtyr(ByVal yr As Integer, ByVal dist As String, ByVal Scheme As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@yr", SqlDbType.Int)
        arParms(0).Value = yr

        arParms(1) = New SqlParameter("@dist", SqlDbType.VarChar)
        arParms(1).Value = dist

        arParms(2) = New SqlParameter("@Scheme", SqlDbType.VarChar)
        arParms(2).Value = Scheme

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SchemWiseCollectnAmtyr", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DSDWiseCollAmtyr(ByVal dist As String, ByVal dsd As String, ByVal gsd As String, ByVal frmdt As Date, ByVal todt As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@dist", SqlDbType.VarChar)
        arParms(0).Value = dist

        arParms(1) = New SqlParameter("@dsd", SqlDbType.VarChar)
        arParms(1).Value = dsd

        arParms(2) = New SqlParameter("@gsd", SqlDbType.VarChar)
        arParms(2).Value = gsd

        arParms(3) = New SqlParameter("@frmdt", SqlDbType.DateTime)
        arParms(3).Value = frmdt

        arParms(4) = New SqlParameter("@todt", SqlDbType.DateTime)
        arParms(4).Value = todt

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_DSDWiseCollectnAmtyr", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function DSDwiseGratuityPayments(ByVal dist As String, ByVal dsd As String, ByVal frmdt As Date, ByVal todt As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@distCode", SqlDbType.VarChar)
        arParms(0).Value = dist

        arParms(1) = New SqlParameter("@dsd", SqlDbType.VarChar)
        arParms(1).Value = dsd

        arParms(2) = New SqlParameter("@frmdt", SqlDbType.DateTime)
        arParms(2).Value = frmdt

        arParms(3) = New SqlParameter("@todt", SqlDbType.DateTime)
        arParms(3).Value = todt

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_DSDwiseGratuityPayments", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function YearWiseMaleFemaleEnrollCount(ByVal dist As String, ByVal frmdt As Date, ByVal todt As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@dist", SqlDbType.VarChar)
        arParms(0).Value = dist

        arParms(1) = New SqlParameter("@frmdt", SqlDbType.DateTime)
        arParms(1).Value = frmdt

        arParms(2) = New SqlParameter("@todt", SqlDbType.DateTime)
        arParms(2).Value = todt
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_YearWiseMaleFemaleEnrollCount", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBatchNo(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function MissingCodes(ByVal dist As String, ByVal dsd As String, ByVal batch As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@dist", SqlDbType.VarChar)
        arParms(0).Value = dist

        arParms(1) = New SqlParameter("@dsd", SqlDbType.VarChar)
        arParms(1).Value = dsd

        arParms(2) = New SqlParameter("@batch", SqlDbType.VarChar)
        arParms(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_MisingCodes", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetConfigValue() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetConfigName")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDBVersionNo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetVersionNo]")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetConfigValueEmailSMS() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetConfigNameEmail/SMS")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetConfigValueFrmMail() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetConfigNameFrmMail")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetConfigValueSubject() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetConfigNameSubject")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetConfigValueSMTP() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetConfigNameSMTP")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetConfigValuePassword() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetConfigNamePasswrd")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Public Function DSDwiseGratuityPaymentsAll(ByVal frmdt As Date, ByVal todt As Date) As DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(1) {}

    '    arParms(0) = New SqlParameter("@frmdt", SqlDbType.DateTime)
    '    arParms(0).Value = frmdt

    '    arParms(1) = New SqlParameter("@todt", SqlDbType.DateTime)
    '    arParms(1).Value = todt

    '    Try
    '        'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_DSDwiseGratuityPayments", arParms)
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GratuityPayments(2) Where Paydate>=" & frmdt & " and Paydate<=" & todt)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    'Public Function DSDwiseGratuityPaymentsOnlyDist(ByVal dist As String, ByVal frmdt As Date, ByVal todt As Date) As DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(2) {}

    '    arParms(0) = New SqlParameter("@distCode", SqlDbType.VarChar)
    '    arParms(0).Value = dist

    '    arParms(1) = New SqlParameter("@frmdt", SqlDbType.DateTime)
    '    arParms(1).Value = frmdt

    '    arParms(2) = New SqlParameter("@todt", SqlDbType.DateTime)
    '    arParms(2).Value = todt

    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GratuityPayments(2) Where Paydate>=" & frmdt & " and Paydate<=" & todt & "and DistrictCode=" & dist)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    'Public Function DSDwiseGratuityPaymentsBoth(ByVal dist As String, ByVal dsd As String, ByVal frmdt As Date, ByVal todt As Date) As DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}

    '    arParms(0) = New SqlParameter("@distCode", SqlDbType.VarChar)
    '    arParms(0).Value = dist

    '    arParms(1) = New SqlParameter("@dsd", SqlDbType.VarChar)
    '    arParms(1).Value = dsd

    '    arParms(2) = New SqlParameter("@frmdt", SqlDbType.DateTime)
    '    arParms(2).Value = frmdt

    '    arParms(3) = New SqlParameter("@todt", SqlDbType.DateTime)
    '    arParms(3).Value = todt

    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GratuityPayments(2) Where Paydate>=" & frmdt & " and Paydate<=" & todt & " and DistrictCode=" & dist & " and DSDcode=" & dsd)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
End Class
