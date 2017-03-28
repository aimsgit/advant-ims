Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.Button

Public Class Mfg_DLBuyerDetails
    
    Public Shared Function GridviewDetails(ByVal se As Mfg_ELBuyerDetails) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet


        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("id", SqlDbType.Int)
        arParms(2).Value = se.Buyer_ID
        arParms(3) = New SqlParameter("@Buyer_Name", SqlDbType.VarChar, 50)
        arParms(3).Value = se.Buyer_Name
        arParms(4) = New SqlParameter("@Buyer_Code", SqlDbType.VarChar, 50)
        arParms(4).Value = se.Buyer_Code

        Try

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetBuyerDetails", arParms)


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function GetBuyerNameDetails() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BuyerNameDetails", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetBuyerNameDetails1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BuyerNameDetails1", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function Insert(ByVal SE As Mfg_ELBuyerDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(28) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.VarChar, 50)
        arParms(0).Value = SE.Buyer_Name

        arParms(1) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        arParms(1).Value = SE.Buyer_Code


        arParms(2) = New SqlParameter("@registered", SqlDbType.VarChar, 50)
        arParms(2).Value = SE.Registered

        arParms(3) = New SqlParameter("@tin", SqlDbType.VarChar, 50)
        arParms(3).Value = SE.Tin

        arParms(4) = New SqlParameter("@cstno", SqlDbType.VarChar, 50)
        arParms(4).Value = SE.CSTNo

        arParms(5) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        arParms(5).Value = SE.Buyer_Address

        arParms(6) = New SqlParameter("@city ", SqlDbType.VarChar, 50)
        arParms(6).Value = SE.City

        If SE.PostalCode = "0" Then
            arParms(7) = New SqlParameter("@postalcode", SqlDbType.VarChar, 50)
            arParms(7).Value = DBNull.Value
        Else
            arParms(7) = New SqlParameter("@postalcode", SqlDbType.VarChar, 50)
            arParms(7).Value = SE.PostalCode
        End If

        arParms(8) = New SqlParameter("@State", SqlDbType.Int)
        arParms(8).Value = SE.State

        arParms(9) = New SqlParameter("@dlno ", SqlDbType.VarChar, 50)
        arParms(9).Value = SE.DLNo

        arParms(10) = New SqlParameter("@contact_Person", SqlDbType.VarChar, 50)
        arParms(10).Value = SE.Contact_Person

        arParms(11) = New SqlParameter("@area", SqlDbType.VarChar, 50)
        arParms(11).Value = SE.Area


        arParms(12) = New SqlParameter("@contact_Number", SqlDbType.VarChar, 50)
        arParms(12).Value = SE.Contact_Number1

        arParms(13) = New SqlParameter("@SE", SqlDbType.VarChar, 50)
        arParms(13).Value = SE.SE

        arParms(14) = New SqlParameter("@faxno", SqlDbType.VarChar, 50)
        arParms(14).Value = SE.FaxNO

        arParms(15) = New SqlParameter("@email", SqlDbType.VarChar, 50)
        arParms(15).Value = SE.Email

        arParms(16) = New SqlParameter("@credit_Period", SqlDbType.Int)
        arParms(16).Value = SE.Credit_Period

        arParms(17) = New SqlParameter("@credit_Limit", SqlDbType.Float)
        arParms(17).Value = SE.Credit_Limit

        arParms(18) = New SqlParameter("@buyertorec", SqlDbType.Float)
        arParms(18).Value = SE.Opening_Balance_CR

        arParms(19) = New SqlParameter("@buyertopay", SqlDbType.Float)
        arParms(19).Value = SE.Opening_Balance_DR

        If SE.OpBalanceDate = "01-01-9100" Then
            arParms(20) = New SqlParameter("@ob_date", SqlDbType.DateTime)
            arParms(20).Value = DBNull.Value
        Else
            arParms(20) = New SqlParameter("@ob_date", SqlDbType.DateTime)
            arParms(20).Value = SE.OpBalanceDate
        End If

        arParms(21) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(21).Value = HttpContext.Current.Session("BranchCode")

        arParms(22) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("EmpCode")

        arParms(23) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(23).Value = HttpContext.Current.Session("UserCode")


        arParms(24) = New SqlParameter("@credit_bills", SqlDbType.Int)
        arParms(24).Value = SE.credit_Bills

        arParms(25) = New SqlParameter("@dlock", SqlDbType.VarChar, 2)
        arParms(25).Value = SE.Discountlock

        arParms(26) = New SqlParameter("@discount", SqlDbType.Int)
        arParms(26).Value = SE.Discount

        arParms(27) = New SqlParameter("@Suplier", SqlDbType.VarChar, 4)
        arParms(27).Value = SE.Suplier

        arParms(28) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(28).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertBuyerDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
           
    Public Shared Function Update(ByVal SE As Mfg_ELBuyerDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(27) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.VarChar, 50)
        arParms(0).Value = SE.Buyer_Name

        arParms(1) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        arParms(1).Value = SE.Buyer_Code


        arParms(2) = New SqlParameter("@registered", SqlDbType.VarChar, 50)
        arParms(2).Value = SE.Registered

        arParms(3) = New SqlParameter("@tin", SqlDbType.VarChar, 50)
        arParms(3).Value = SE.Tin

        arParms(4) = New SqlParameter("@cstno", SqlDbType.VarChar, 50)
        arParms(4).Value = SE.CSTNo

        arParms(5) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        arParms(5).Value = SE.Buyer_Address

        arParms(6) = New SqlParameter("@city ", SqlDbType.VarChar, 50)
        arParms(6).Value = SE.City

        If SE.PostalCode = "0" Then
            arParms(7) = New SqlParameter("@postalcode", SqlDbType.VarChar, 50)
            arParms(7).Value = DBNull.Value
        Else
            arParms(7) = New SqlParameter("@postalcode", SqlDbType.VarChar, 50)
            arParms(7).Value = SE.PostalCode
        End If


        arParms(8) = New SqlParameter("@State", SqlDbType.Int)
        arParms(8).Value = SE.State

        arParms(9) = New SqlParameter("@dlno ", SqlDbType.VarChar, 50)
        arParms(9).Value = SE.DLNo

        arParms(10) = New SqlParameter("@contact_Person", SqlDbType.VarChar, 50)
        arParms(10).Value = SE.Contact_Person

        arParms(11) = New SqlParameter("@area", SqlDbType.VarChar, 50)
        arParms(11).Value = SE.Area


        arParms(12) = New SqlParameter("@contact_Number", SqlDbType.VarChar, 50)
        arParms(12).Value = SE.Contact_Number1

        arParms(13) = New SqlParameter("@SE", SqlDbType.VarChar, 50)
        arParms(13).Value = SE.SE

        arParms(14) = New SqlParameter("@faxno", SqlDbType.VarChar, 50)
        arParms(14).Value = SE.FaxNO

        arParms(15) = New SqlParameter("@email", SqlDbType.VarChar, 50)
        arParms(15).Value = SE.Email

        arParms(16) = New SqlParameter("@credit_Period", SqlDbType.Int)
        arParms(16).Value = SE.Credit_Period

        arParms(17) = New SqlParameter("@credit_Limit", SqlDbType.Float)
        arParms(17).Value = SE.Credit_Limit

        arParms(18) = New SqlParameter("@buyertorec", SqlDbType.Float)
        arParms(18).Value = SE.Opening_Balance_CR

        arParms(19) = New SqlParameter("@buyertopay", SqlDbType.Float)
        arParms(19).Value = SE.Opening_Balance_DR

        If SE.OpBalanceDate = "01-01-9100" Then
            arParms(20) = New SqlParameter("@ob_date", SqlDbType.DateTime)
            arParms(20).Value = DBNull.Value
        Else
            arParms(20) = New SqlParameter("@ob_date", SqlDbType.DateTime)
            arParms(20).Value = SE.OpBalanceDate
        End If

        arParms(21) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(21).Value = HttpContext.Current.Session("BranchCode")

        arParms(22) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("EmpCode")

        arParms(23) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(23).Value = HttpContext.Current.Session("UserCode")


        arParms(24) = New SqlParameter("@credit_bills", SqlDbType.Int)
        arParms(24).Value = SE.credit_Bills

        arParms(25) = New SqlParameter("@dlock", SqlDbType.VarChar, 2)
        arParms(25).Value = SE.Discountlock

        arParms(26) = New SqlParameter("@discount", SqlDbType.Int)
        arParms(26).Value = SE.Discount

        arParms(27) = New SqlParameter("@id", SqlDbType.Int)
        arParms(27).Value = SE.Buyer_ID

   

        
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateBuyerDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Delete(ByVal id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim SE As New Supplier
        Dim rowsAffected As Integer = 0


        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_Deletebuyerdetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    

    Shared Function GetSuppDuplicateType(ByVal SE As Mfg_ELBuyerDetails) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = SE.Buyer_ID
        arParms(3) = New SqlParameter("@Buyer_Code", SqlDbType.Char, SE.Buyer_Code.Length)
        arParms(3).Value = SE.Buyer_Code
        Try

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_DuplicateBuyerDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
