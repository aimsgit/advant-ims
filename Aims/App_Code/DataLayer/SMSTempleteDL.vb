Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class SMSTempleteDL
    Public Function InsertSMSTemplete(ByVal EL As SMSTempleteEL) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(4) {}
        Parms(0) = New SqlParameter("@TemplateName", SqlDbType.VarChar, 50)
        Parms(0).Value = EL.SMSName
        Parms(1) = New SqlParameter("@Message", SqlDbType.VarChar, 160)
        Parms(1).Value = EL.SMSDescription
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Parms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("empCode")
        Parms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("UserCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertSMSTemplete", Parms)
        Return rowsaffected

    End Function
    Public Function GetSMSTemplete(ByVal EL As SMSTempleteEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = EL.Id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetSMSTemplete", arParms)

        Return ds.Tables(0)

    End Function
    Public Function DeleteSMSTemplete(ByVal id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@id", SqlDbType.Int)
        param(0).Value = id

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteSMSTemplete", param)
        Return rowsaffected
    End Function
    Public Function UpdateSMSTemplete(ByVal EL As SMSTempleteEL) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@TemplateName", SqlDbType.VarChar, 50)
        param(0).Value = EL.SMSName
        param(1) = New SqlParameter("@ID", SqlDbType.Int)
        param(1).Value = EL.Id
        param(2) = New SqlParameter("@Message", SqlDbType.VarChar, 160)
        param(2).Value = EL.SMSDescription
        param(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        param(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("empCode")
        param(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("UserCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateSMSTemplete", param)
        Return rowsaffected
    End Function
    Public Function GetDuplicateSMSTemplete(ByVal EL As SMSTempleteEL) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@SMSName", SqlDbType.VarChar, 50)
        para(0).Value = EL.SMSName
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.Id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateSMSTemplete", para)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
