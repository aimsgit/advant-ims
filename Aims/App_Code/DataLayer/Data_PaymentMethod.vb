Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Data_PaymentMethod
    Public Function GetPaymentType(ByVal PE As Entity_PaymentMethod) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'ds.Clear()
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")
            arParms(2) = New SqlParameter("@PaymentMethodID", SqlDbType.Int)
            arParms(2).Value = PE.PaymentMethodID
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPaymentType", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Public Function Insert(ByVal m As Entity_PaymentMethod) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@paymentmethod", SqlDbType.VarChar, 100)
        Parms(0).Value = m.Payment_Method

        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Parms(2) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")
        

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertPaymentMethod", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function Update(ByVal m As Entity_PaymentMethod) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@paymentmethodtype", SqlDbType.VarChar, 250)
        arParms(0).Value = m.Payment_Method

        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = m.PaymentMethodID

        arParms(2) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePaymentMethod", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetPayDuplicate(ByVal PE As Entity_PaymentMethod) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@Payment_Method", SqlDbType.VarChar, PE.Payment_Method.Length)
        arParms(0).Value = PE.Payment_Method

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = PE.PaymentMethodID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetPayDuplicate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Public Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@id", SqlDbType.Int)
        arParms.Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ChangePaymentMethodFlag", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function GetPaymentType(ByVal supp_id As Integer) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim PE As New Entity_PaymentMethod
        Try
            If supp_id = 0 Then
                Dim arParms() As SqlParameter = New SqlParameter(1) {}
                arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(0).Value = HttpContext.Current.Session("Office")
                arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(1).Value = HttpContext.Current.Session("BranchCode")
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPaymentType", arParms)
            Else
                Dim arParms As SqlParameter = New SqlParameter
                arParms = New SqlParameter("@PaymentMethodID", SqlDbType.Int)
                arParms.Value = PE.PaymentMethodID
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPaymentType", arParms)
            End If
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
End Class
