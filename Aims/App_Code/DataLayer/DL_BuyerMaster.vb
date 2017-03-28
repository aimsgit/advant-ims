Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DL_BuyerMaster
    Public Shared Function GridviewDetails(ByVal NS As EL_BuyerMaster) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = NS.Id()

        arParms(3) = New SqlParameter("@Company_Name", SqlDbType.NVarChar, 50)
        arParms(3).Value = NS.Fname()

        arParms(4) = New SqlParameter("@Buyer_Code", SqlDbType.VarChar, 50)
        arParms(4).Value = NS.BuyerCode()

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBuyerMaster", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Shared Function Insert(ByVal NS As EL_BuyerMaster) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(31) {}

        arParms(0) = New SqlParameter("@fname", SqlDbType.VarChar, 50)
        arParms(0).Value = NS.Fname


        arParms(1) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        arParms(1).Value = NS.BuyerCode

        If NS.Tin = " " Then
            arParms(2) = New SqlParameter("@Tin", SqlDbType.VarChar, 50)
            arParms(2).Value = DBNull.Value
        Else
            arParms(2) = New SqlParameter("@Tin", SqlDbType.VarChar, 50)
            arParms(2).Value = NS.Tin
        End If

        If NS.CST_NO = " " Then
            arParms(3) = New SqlParameter("@CST_NO", SqlDbType.VarChar, 50)
            arParms(3).Value = DBNull.Value
        Else
            arParms(3) = New SqlParameter("@CST_NO", SqlDbType.VarChar, 50)
            arParms(3).Value = NS.CST_NO
        End If

        arParms(4) = New SqlParameter("@Off_Address", SqlDbType.VarChar, 50)
        arParms(4).Value = NS.Off_Address

        arParms(5) = New SqlParameter("@Off_City", SqlDbType.VarChar, 50)
        arParms(5).Value = NS.Off_City

        arParms(6) = New SqlParameter("@Off_District", SqlDbType.VarChar, 50)
        arParms(6).Value = NS.Off_District

        arParms(7) = New SqlParameter("@Off_State", SqlDbType.Int)
        arParms(7).Value = NS.Off_State

        arParms(8) = New SqlParameter("@Off_Country", SqlDbType.Int)
        arParms(8).Value = NS.Off_Country


        arParms(9) = New SqlParameter("@Contact_Number1", SqlDbType.VarChar, 50)
        arParms(9).Value = NS.Contact_Number1

        If NS.Contact_Number2 = "0" Then
            arParms(10) = New SqlParameter("@Contact_Number2", SqlDbType.VarChar, 50)
            arParms(10).Value = DBNull.Value
        Else
            arParms(10) = New SqlParameter("@Contact_Number2", SqlDbType.VarChar, 50)
            arParms(10).Value = NS.Contact_Number2
        End If

        If NS.Fax_NO = " " Then
            arParms(11) = New SqlParameter("@Fax_No", SqlDbType.VarChar, 50)
            arParms(11).Value = DBNull.Value
        Else
            arParms(11) = New SqlParameter("@Fax_No", SqlDbType.VarChar, 50)
            arParms(11).Value = NS.Fax_NO
        End If


        arParms(12) = New SqlParameter("@Email1", SqlDbType.VarChar, 50)
        arParms(12).Value = NS.Email1

        If NS.Contact_Number2 = " " Then
            arParms(13) = New SqlParameter("@ContactPerson2", SqlDbType.VarChar, 50)
            arParms(13).Value = DBNull.Value
        Else
            arParms(13) = New SqlParameter("@ContactPerson2", SqlDbType.VarChar, 50)
            arParms(13).Value = NS.Introducer
        End If

        If NS.Res_Address = " " Then
            arParms(14) = New SqlParameter("@Res_Address", SqlDbType.VarChar, 50)
            arParms(14).Value = DBNull.Value
        Else
            arParms(14) = New SqlParameter("@Res_Address", SqlDbType.VarChar, 50)
            arParms(14).Value = NS.Res_Address
        End If

        If NS.Res_City = " " Then
            arParms(15) = New SqlParameter("@Res_City", SqlDbType.VarChar, 50)
            arParms(15).Value = DBNull.Value
        Else
            arParms(15) = New SqlParameter("@Res_City", SqlDbType.VarChar, 50)
            arParms(15).Value = NS.Res_City
        End If

        If NS.Res_District = " " Then
            arParms(16) = New SqlParameter("@Res_District", SqlDbType.VarChar, 50)
            arParms(16).Value = DBNull.Value
        Else
            arParms(16) = New SqlParameter("@Res_District", SqlDbType.VarChar, 50)
            arParms(16).Value = NS.Res_District
        End If


        arParms(17) = New SqlParameter("@Res_State", SqlDbType.Int)
        arParms(17).Value = NS.Res_State


        arParms(18) = New SqlParameter("@Res_Country", SqlDbType.Int)
        arParms(18).Value = NS.Res_Country



        If NS.Introducer = " " Then
            arParms(19) = New SqlParameter("@Introducer", SqlDbType.VarChar, 50)
            arParms(19).Value = DBNull.Value
        Else
            arParms(19) = New SqlParameter("@Introducer", SqlDbType.VarChar, 50)
            arParms(19).Value = NS.Contact_Person
        End If

        arParms(20) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("UserCode")

        arParms(21) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(21).Value = HttpContext.Current.Session("EmpCode")

        arParms(22) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("BranchCode")

        If NS.Photo = " " Then
            arParms(23) = New SqlParameter("@Photo", SqlDbType.VarChar, 50)

            arParms(23).Value = DBNull.Value
        Else
            arParms(23) = New SqlParameter("@Photo", SqlDbType.VarChar, 50)
            arParms(23).Value = NS.Photo
        End If

        If NS.PAN_NO = " " Then
            arParms(24) = New SqlParameter("@PAN_NO", SqlDbType.VarChar, 50)
            arParms(24).Value = DBNull.Value
        Else
            arParms(24) = New SqlParameter("@PAN_NO", SqlDbType.VarChar, 50)
            arParms(24).Value = NS.PAN_NO
        End If

        If NS.Email2 = " " Then
            arParms(25) = New SqlParameter("@Email2", SqlDbType.VarChar, 50)
            arParms(25).Value = DBNull.Value
        Else
            arParms(25) = New SqlParameter("@Email2", SqlDbType.VarChar, 50)
            arParms(25).Value = NS.Email2
        End If

        If NS.Bank_Name = " " Then
            arParms(26) = New SqlParameter("@Bank_Name", SqlDbType.VarChar, 50)
            arParms(26).Value = DBNull.Value
        Else
            arParms(26) = New SqlParameter("@Bank_Name", SqlDbType.VarChar, 50)
            arParms(26).Value = NS.Bank_Name
        End If

        If NS.Bank_Branch = "0" Then
            arParms(27) = New SqlParameter("@Bank_Branch", SqlDbType.VarChar, 50)
            arParms(27).Value = DBNull.Value
        Else
            arParms(27) = New SqlParameter("@Bank_Branch", SqlDbType.VarChar, 50)
            arParms(27).Value = NS.Bank_Branch
        End If

        If NS.IFSC_Code = " " Then
            arParms(28) = New SqlParameter("@IFSC_Code", SqlDbType.VarChar, 50)
            arParms(28).Value = DBNull.Value
        Else
            arParms(28) = New SqlParameter("@IFSC_Code", SqlDbType.VarChar, 50)
            arParms(28).Value = NS.IFSC_Code
        End If

        If NS.Account_Number = " " Then
            arParms(29) = New SqlParameter("@Account_Number", SqlDbType.VarChar, 50)
            arParms(29).Value = DBNull.Value
        Else
            arParms(29) = New SqlParameter("@Account_Number", SqlDbType.VarChar, 50)
            arParms(29).Value = NS.Account_Number
        End If


        arParms(30) = New SqlParameter("@Type_Of_Account", SqlDbType.VarChar, 50)
        arParms(30).Value = NS.Type_Of_Account


        arParms(31) = New SqlParameter("@lname", SqlDbType.VarChar, 50)
        arParms(31).Value = NS.Lname


        Dim ds As New DataSet
        Try
            rowAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertBuyerMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowAffected
    End Function
    Public Shared Function Update(ByVal NS As EL_BuyerMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(32) {}

        arParms(0) = New SqlParameter("@fname", SqlDbType.NVarChar, 50)
        arParms(0).Value = NS.FName


        arParms(1) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        arParms(1).Value = NS.BuyerCode

        If NS.Tin = " " Then
            arParms(2) = New SqlParameter("@Tin", SqlDbType.VarChar, 50)
            arParms(2).Value = DBNull.Value
        Else
            arParms(2) = New SqlParameter("@Tin", SqlDbType.VarChar, 50)
            arParms(2).Value = NS.Tin
        End If

        If NS.CST_NO = " " Then
            arParms(3) = New SqlParameter("@CST_NO", SqlDbType.VarChar, 50)
            arParms(3).Value = DBNull.Value
        Else
            arParms(3) = New SqlParameter("@CST_NO", SqlDbType.VarChar, 50)
            arParms(3).Value = NS.CST_NO
        End If

        arParms(4) = New SqlParameter("@Off_Address", SqlDbType.VarChar, 50)
        arParms(4).Value = NS.Off_Address

        arParms(5) = New SqlParameter("@Off_City", SqlDbType.VarChar, 50)
        arParms(5).Value = NS.Off_City

        arParms(6) = New SqlParameter("@Off_District", SqlDbType.VarChar, 50)
        arParms(6).Value = NS.Off_District

        arParms(7) = New SqlParameter("@Off_State", SqlDbType.Int)
        arParms(7).Value = NS.Off_State

        arParms(8) = New SqlParameter("@Off_Country", SqlDbType.Int)
        arParms(8).Value = NS.Off_Country


        arParms(9) = New SqlParameter("@Contact_Number1", SqlDbType.VarChar, 50)
        arParms(9).Value = NS.Contact_Number1

        If NS.Contact_Number2 = " " Then
            arParms(10) = New SqlParameter("@Contact_Number2", SqlDbType.VarChar, 50)
            arParms(10).Value = DBNull.Value
        Else
            arParms(10) = New SqlParameter("@Contact_Number2", SqlDbType.VarChar, 50)
            arParms(10).Value = NS.Contact_Number2
        End If

        If NS.Fax_NO = " " Then
            arParms(11) = New SqlParameter("@Fax_No", SqlDbType.VarChar, 50)
            arParms(11).Value = DBNull.Value
        Else
            arParms(11) = New SqlParameter("@Fax_No", SqlDbType.VarChar, 50)
            arParms(11).Value = NS.Fax_NO
        End If


        arParms(12) = New SqlParameter("@Email1", SqlDbType.VarChar, 50)
        arParms(12).Value = NS.Email1

        If NS.Contact_Number2 = " " Then
            arParms(13) = New SqlParameter("@ContactPerson2", SqlDbType.VarChar, 50)
            arParms(13).Value = DBNull.Value
        Else
            arParms(13) = New SqlParameter("@ContactPerson2", SqlDbType.VarChar, 50)
            arParms(13).Value = NS.Introducer
        End If

        If NS.Res_Address = " " Then
            arParms(14) = New SqlParameter("@Res_Address", SqlDbType.VarChar, 50)
            arParms(14).Value = DBNull.Value
        Else
            arParms(14) = New SqlParameter("@Res_Address", SqlDbType.VarChar, 50)
            arParms(14).Value = NS.Res_Address
        End If

        If NS.Res_City = " " Then
            arParms(15) = New SqlParameter("@Res_City", SqlDbType.VarChar, 50)
            arParms(15).Value = DBNull.Value
        Else
            arParms(15) = New SqlParameter("@Res_City", SqlDbType.VarChar, 50)
            arParms(15).Value = NS.Res_City
        End If

        If NS.Res_District = " " Then
            arParms(16) = New SqlParameter("@Res_District", SqlDbType.VarChar, 50)
            arParms(16).Value = DBNull.Value
        Else
            arParms(16) = New SqlParameter("@Res_District", SqlDbType.VarChar, 50)
            arParms(16).Value = NS.Res_District
        End If


        arParms(17) = New SqlParameter("@Res_State", SqlDbType.Int)
        arParms(17).Value = NS.Res_State


            arParms(18) = New SqlParameter("@Res_Country", SqlDbType.Int)
            arParms(18).Value = NS.Res_Country


        If NS.Introducer = " " Then
            arParms(19) = New SqlParameter("@Introducer", SqlDbType.VarChar, 50)
            arParms(19).Value = DBNull.Value
        Else
            arParms(19) = New SqlParameter("@Introducer", SqlDbType.VarChar, 50)
            arParms(19).Value = NS.Contact_Person
        End If

        arParms(20) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("UserCode")

        arParms(21) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(21).Value = HttpContext.Current.Session("EmpCode")

        arParms(22) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("BranchCode")

        If NS.Photo = " " Then
            arParms(23) = New SqlParameter("@Photo", SqlDbType.VarChar, 50)

            arParms(23).Value = DBNull.Value
        Else
            arParms(23) = New SqlParameter("@Photo", SqlDbType.VarChar, 50)
            arParms(23).Value = NS.Photo
        End If

        If NS.PAN_NO = " " Then
            arParms(24) = New SqlParameter("@PAN_NO", SqlDbType.VarChar, 50)
            arParms(24).Value = DBNull.Value
        Else
            arParms(24) = New SqlParameter("@PAN_NO", SqlDbType.VarChar, 50)
            arParms(24).Value = NS.PAN_NO
        End If

        If NS.Email2 = " " Then
            arParms(25) = New SqlParameter("@Email2", SqlDbType.VarChar, 50)
            arParms(25).Value = DBNull.Value
        Else
            arParms(25) = New SqlParameter("@Email2", SqlDbType.VarChar, 50)
            arParms(25).Value = NS.Email2
        End If

        If NS.Bank_Name = " " Then
            arParms(26) = New SqlParameter("@Bank_Name", SqlDbType.VarChar, 50)
            arParms(26).Value = DBNull.Value
        Else
            arParms(26) = New SqlParameter("@Bank_Name", SqlDbType.VarChar, 50)
            arParms(26).Value = NS.Bank_Name
        End If

        If NS.Bank_Branch = " " Then
            arParms(27) = New SqlParameter("@Bank_Branch", SqlDbType.VarChar, 50)
            arParms(27).Value = DBNull.Value
        Else
            arParms(27) = New SqlParameter("@Bank_Branch", SqlDbType.VarChar, 50)
            arParms(27).Value = NS.Bank_Branch
        End If

        If NS.IFSC_Code = " " Then
            arParms(28) = New SqlParameter("@IFSC_Code", SqlDbType.VarChar, 50)
            arParms(28).Value = DBNull.Value
        Else
            arParms(28) = New SqlParameter("@IFSC_Code", SqlDbType.VarChar, 50)
            arParms(28).Value = NS.IFSC_Code
        End If

        If NS.Account_Number = " " Then
            arParms(29) = New SqlParameter("@Account_Number", SqlDbType.VarChar, 50)
            arParms(29).Value = DBNull.Value
        Else
            arParms(29) = New SqlParameter("@Account_Number", SqlDbType.VarChar, 50)
            arParms(29).Value = NS.Account_Number
        End If



        arParms(30) = New SqlParameter("@Type_Of_Account", SqlDbType.Int)
        arParms(30).Value = NS.Type_Of_Account

        arParms(31) = New SqlParameter("@lname", SqlDbType.VarChar, 50)
        arParms(31).Value = NS.Lname

        arParms(32) = New SqlParameter("@id", SqlDbType.Int)
        arParms(32).Value = NS.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBuyerMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Delete(ByVal id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim SE As New Supplier
        Dim rowsAffected As Integer = 0


        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("Buyer_Id", SqlDbType.Int)
        arParms(0).Value = id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteBuyerDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetStateEmpMaster(ByVal countryId As Integer) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@countryId", SqlDbType.Int)
            arParms(0).Value = countryId
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStateStdMaster", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCountry() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCountryStudent", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetDDlAccountType() As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetAccountTypeCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetDuplicateType(ByVal NS As EL_BuyerMaster) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = NS.ID
        arParms(3) = New SqlParameter("@Code", SqlDbType.VarChar, 50)
        arParms(3).Value = NS.BuyerCode
        Try

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetBuyerMasterDuplicateType", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
