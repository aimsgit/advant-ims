Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class EmailSMSRateDL
    Shared Function InsertEmailSMSRate(ByVal ESMS As EmailSMSRate) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@InstituteId", SqlDbType.VarChar)
        arParms(1).Value = ESMS.InstituteId

        arParms(2) = New SqlParameter("@BranchId", SqlDbType.VarChar)
        arParms(2).Value = ESMS.BranchId

        arParms(3) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(3).Value = ESMS.FromDate

        If ESMS.ToDate = "1/1/1900" Then
            arParms(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            arParms(4).Value = ESMS.ToDate
        End If
        
        arParms(5) = New SqlParameter("@EmailRate", SqlDbType.Money)
        arParms(5).Value = ESMS.EmailRate

        arParms(6) = New SqlParameter("@SMSRate", SqlDbType.Money)
        arParms(6).Value = ESMS.SMSRate

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertEmailSMSRate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateEmailSMSRate(ByVal ESMS As EmailSMSRate) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@InstituteId", SqlDbType.VarChar)
        arParms(1).Value = ESMS.InstituteId

        arParms(2) = New SqlParameter("@BranchId", SqlDbType.VarChar)
        arParms(2).Value = ESMS.BranchId

        arParms(3) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(3).Value = ESMS.FromDate

        If ESMS.ToDate = "1/1/1900" Then
            arParms(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            arParms(4).Value = ESMS.ToDate
        End If

        arParms(5) = New SqlParameter("@EmailRate", SqlDbType.Money)
        arParms(5).Value = ESMS.EmailRate

        arParms(6) = New SqlParameter("@SMSRate", SqlDbType.Money)
        arParms(6).Value = ESMS.SMSRate

        arParms(7) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(7).Value = ESMS.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateEmailSMSRate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DeleteEmailSMSRate(ByVal ESMS As EmailSMSRate) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = ESMS.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteEmailSMSRate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function EmailSMSRateGridview(ByVal ESMS As EmailSMSRate) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@InstituteId", SqlDbType.VarChar)
            Parms(0).Value = ESMS.InstituteId

            Parms(1) = New SqlParameter("@BranchId", SqlDbType.VarChar)
            Parms(1).Value = ESMS.BranchId

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = ESMS.FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ESMS.ToDate

            Parms(4) = New SqlParameter("@Branch", SqlDbType.VarChar)
            Parms(4).Value = HttpContext.Current.Session("BranchCode")

            Parms(5) = New SqlParameter("@Office", SqlDbType.VarChar)
            Parms(5).Value = HttpContext.Current.Session("Office")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SearchEmailSMSRate", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetClientCombo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Ds As New DataSet

        Try
            Ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetClientNameDDL")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Ds.Tables(0)
    End Function
    Shared Function GetBranchCombo(ByVal Mycode As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Ds As New DataSet

        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@MyCo_Code", SqlDbType.VarChar)
        arParms.Value = Mycode
        Try
            Ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranchNameDDL", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Ds.Tables(0)
    End Function
    Shared Function GetSMSRateGridview(ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            Ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EmailSMSRateGridView", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Ds.Tables(0)
    End Function
    Shared Function GetData(ByVal ESMS As EmailSMSRate) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@InstituteId", SqlDbType.VarChar)
            Parms(0).Value = ESMS.InstituteId

            Parms(1) = New SqlParameter("@BranchId", SqlDbType.VarChar)
            Parms(1).Value = ESMS.BranchId

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = ESMS.FromDate

            'Parms(3) = New SqlParameter("@ValId", SqlDbType.Int)
            'Parms(3).Value = ESMS.ValId


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EmailSMSRateValidation", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
