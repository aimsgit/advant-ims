Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class Mfg_DLSaleExecutive
    Public Function Insert(ByVal i As Mfg_ELSaleExecutive) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(16) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@MR_Name", SqlDbType.VarChar, 50)
        arParms(0).Value = i.SEName

        arParms(1) = New SqlParameter("@MR_Code", SqlDbType.VarChar, 50)
        arParms(1).Value = i.Code

        arParms(2) = New SqlParameter("@Age", SqlDbType.Int)
        arParms(2).Value = i.Age

        arParms(3) = New SqlParameter("@DOJ", SqlDbType.DateTime)
        arParms(3).Value = i.DOJ

        arParms(4) = New SqlParameter("@Grade", SqlDbType.VarChar, 50)
        arParms(4).Value = i.Grade

        arParms(5) = New SqlParameter("@Target_Value", SqlDbType.Money)
        arParms(5).Value = i.TargetValue

        arParms(6) = New SqlParameter("@OpeningBalance", SqlDbType.Money)
        arParms(6).Value = i.OpenBal

        arParms(7) = New SqlParameter("@MR_Address", SqlDbType.VarChar, 250)
        arParms(7).Value = i.Address

        arParms(8) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(8).Value = i.State

        arParms(9) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        arParms(9).Value = i.Country

        arParms(10) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(10).Value = i.Email

        arParms(11) = New SqlParameter("@Phone", SqlDbType.VarChar, 50)
        arParms(11).Value = i.Contact

        arParms(12) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("UserCode")

        arParms(13) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("EmpCode")

        arParms(14) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("BranchCode")

        arParms(15) = New SqlParameter("@DOL", SqlDbType.DateTime)
        arParms(15).Value = i.DOL
        arParms(16) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertMR_DeatailMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELSaleExecutive) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = s.id
        para(1) = New SqlParameter("@MR_Code", SqlDbType.VarChar, 50)
        para(1).Value = s.Code

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Mfg_GetDuplicateMR_Detail_Master", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function Update(ByVal i As Mfg_ELSaleExecutive) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(16) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@MR_Name", SqlDbType.VarChar, 50)
        arParms(0).Value = i.SEName

        arParms(1) = New SqlParameter("@MR_Code", SqlDbType.VarChar, 50)
        arParms(1).Value = i.Code

        arParms(2) = New SqlParameter("@Age", SqlDbType.Int)
        arParms(2).Value = i.Age

        arParms(3) = New SqlParameter("@DOJ", SqlDbType.DateTime)
        arParms(3).Value = i.DOJ

        arParms(4) = New SqlParameter("@Grade", SqlDbType.VarChar, 50)
        arParms(4).Value = i.Grade

        arParms(5) = New SqlParameter("@Target_Value", SqlDbType.Money)
        arParms(5).Value = i.TargetValue

        arParms(6) = New SqlParameter("@OpeningBalance", SqlDbType.Money)
        arParms(6).Value = i.OpenBal

        arParms(7) = New SqlParameter("@MR_Address", SqlDbType.VarChar, 250)
        arParms(7).Value = i.Address

        arParms(8) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(8).Value = i.State

        arParms(9) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        arParms(9).Value = i.Country

        arParms(10) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(10).Value = i.Email

        arParms(11) = New SqlParameter("@Phone", SqlDbType.VarChar, 50)
        arParms(11).Value = i.Contact

        arParms(12) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("UserCode")

        arParms(13) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("EmpCode")

        arParms(14) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("BranchCode")

        arParms(15) = New SqlParameter("@DOL", SqlDbType.DateTime)
        arParms(15).Value = i.DOL

        arParms(16) = New SqlParameter("@MRAutoNo", SqlDbType.Int)
        arParms(16).Value = i.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_updateMR_DeatailMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function getSales(ByVal s As Mfg_ELSaleExecutive) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = s.id

        arParms(3) = New SqlParameter("@MR_Name", SqlDbType.VarChar, 50)
        arParms(3).Value = s.SEName
        arParms(4) = New SqlParameter("@MR_Code", SqlDbType.VarChar, 50)
        arParms(4).Value = s.Code
        arParms(5) = New SqlParameter("@DOJ", SqlDbType.DateTime)
        arParms(5).Value = s.DOJ
        arParms(6) = New SqlParameter("@DOL", SqlDbType.DateTime)
        arParms(6).Value = s.DOL
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetMR_DetailMaster", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteSales(ByVal s As Mfg_ELSaleExecutive) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@MRAutoNo", SqlDbType.Int)
        arParms.Value = s.id
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_deleteMR_Detail_Master", arParms)
        Return rowsaffected
    End Function
End Class
