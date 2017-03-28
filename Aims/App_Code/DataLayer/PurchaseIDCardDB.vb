Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class PurchaseIDCardDB
    Shared Function GetPurchaseIDCard(ByVal el As PurchaseIDCard) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Char, 100)
        arParms(0).Value = el.Id
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DGPurchaseIdCard", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Shared Function Insert(ByVal el As PurchaseIDCard) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        
        arParms(1) = New SqlParameter("@Entry_Date", SqlDbType.DateTime, 15)
        arParms(1).Value = el.Entrydate

        arParms(2) = New SqlParameter("@PReceipt_No", SqlDbType.Char, el.PreceiptNO.Length)
        arParms(2).Value = el.PreceiptNO

        arParms(3) = New SqlParameter("@IdentCrd_Quantity", SqlDbType.BigInt, 15)
        arParms(3).Value = el.Quantity

        arParms(4) = New SqlParameter("@IdentCrd_Price", SqlDbType.Decimal, 15)
        arParms(4).Value = el.Price

        arParms(5) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(5).Value = el.Remarks

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_SavePurchaseIdCard", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal el As PurchaseIDCard) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Entry_Date", SqlDbType.DateTime, 15)
        arParms(1).Value = el.Entrydate

        arParms(2) = New SqlParameter("@PReceipt_No", SqlDbType.Char, 15)
        arParms(2).Value = el.PreceiptNO

        arParms(3) = New SqlParameter("@IdentCrd_Quantity", SqlDbType.BigInt, 15)
        arParms(3).Value = el.Quantity

        arParms(4) = New SqlParameter("@IdentCrd_Price", SqlDbType.Decimal, 15)
        arParms(4).Value = el.Price

        arParms(5) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(5).Value = el.Remarks

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@Id", SqlDbType.BigInt, 100)
        arParms(8).Value = el.Id
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePurchaseIdCard", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int, 100)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeletePurchaseIDCard", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function CheckDuplicate(ByVal el As PurchaseIDCard) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Entry_Date", SqlDbType.DateTime, 15)
        arParms(1).Value = el.Entrydate

        arParms(2) = New SqlParameter("@PReceipt_No", SqlDbType.Char, 15)
        arParms(2).Value = el.PreceiptNO

        arParms(3) = New SqlParameter("@IdentCrd_Quantity", SqlDbType.BigInt, 15)
        arParms(3).Value = el.Quantity

        arParms(4) = New SqlParameter("@IdentCrd_Price", SqlDbType.Decimal, 15)
        arParms(4).Value = el.Price

        arParms(5) = New SqlParameter("@Remarks", SqlDbType.Char, 50)
        arParms(5).Value = el.Remarks

        arParms(6) = New SqlParameter("@id", SqlDbType.Int)
        arParms(6).Value = el.Id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicatePurchaseIdCard", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class