Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLRemainder
    Shared Function GVDetails() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        'Dim arParms As SqlParameter

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetLoadRemainder]")

        Return ds.Tables(0)
    End Function
    Shared Function GetEMAILSMSDetails(ByVal ChkID As String, ByVal ContactNo As String, ByVal Mode As String, ByVal EmailID As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@ChkID", SqlDbType.VarChar, 8000)
        arParms(0).Value = ChkID

        arParms(1) = New SqlParameter("@ContactNo", SqlDbType.VarChar, 50)
        arParms(1).Value = ContactNo

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")


        arParms(3) = New SqlParameter("@Mode", SqlDbType.VarChar, 8000)
        arParms(3).Value = Mode

        arParms(4) = New SqlParameter("@EmailID", SqlDbType.VarChar, 50)
        arParms(4).Value = EmailID

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[RptSendEmailSMSforRemainder]", arParms)

        Return ds.Tables(0)
    End Function
    Shared Function InsertReminder(ByVal id2 As String, ByVal Mode As String, ByVal InvoiceNo As String, ByVal InvoiceDate As Date, ByVal Amount As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(4) {}
        'Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'Parms(0).Value = "000000000000"
        'Parms(1) = New SqlParameter("@Name", SqlDbType.VarChar, 50)
        'Parms(1).Value = Name
        'Parms(2) = New SqlParameter("@UserName", SqlDbType.VarChar, 50)
        'Parms(2).Value = UserName
        Parms(0) = New SqlParameter("@id2", SqlDbType.VarChar, 8000)
        Parms(0).Value = id2
        Parms(1) = New SqlParameter("@Mode", SqlDbType.VarChar, 20)
        Parms(1).Value = Mode
        Parms(2) = New SqlParameter("@InvoiceNo", SqlDbType.VarChar, 50)
        Parms(2).Value = InvoiceNo
        Parms(3) = New SqlParameter("@InvoiceDate", SqlDbType.Date)
        Parms(3).Value = InvoiceDate
        Parms(4) = New SqlParameter("@Amount", SqlDbType.VarChar, 50)
        Parms(4).Value = Amount

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_InsertReminder]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    Public Function GetInvoiceData1(ByVal Branch_Code As String, ByVal InvoiceNo As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = Branch_Code

            arParms(1) = New SqlParameter("@InvoiceNo", SqlDbType.VarChar, 50)
            arParms(1).Value = InvoiceNo

           

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[RPT_GetinvoiceData2]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
