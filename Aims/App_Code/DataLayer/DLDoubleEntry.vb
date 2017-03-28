Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class DLDoubleEntry
    Shared Function Insert(ByVal EL As ELDoubleEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(21) {}
       

        arParms(0) = New SqlParameter("@Entry_Date", SqlDbType.DateTime)
        arParms(0).Value = EL.Entry_Date

        arParms(1) = New SqlParameter("@Amount_Out", SqlDbType.Float)
        arParms(1).Value = EL.Amount_Out
        

        arParms(2) = New SqlParameter("@Item", SqlDbType.Char, EL.Item.Length)
        arParms(2).Value = EL.Item

        arParms(3) = New SqlParameter("@Amount", SqlDbType.Float)
        arParms(3).Value = EL.Amount

        arParms(4) = New SqlParameter("@Bill_No", SqlDbType.Char, EL.Bill_No.Length)
        arParms(4).Value = EL.Bill_No

        If EL.Bill_Date = "1/1/3000" Then
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.VarChar)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.DateTime)
            arParms(5).Value = EL.Bill_Date
        End If

        arParms(6) = New SqlParameter("@Party_Type", SqlDbType.Int)
        arParms(6).Value = EL.Party_Type

        arParms(7) = New SqlParameter("@Party_Id_Name", SqlDbType.Int)
        arParms(7).Value = EL.Party_Id_Name

        arParms(8) = New SqlParameter("@ChequeNo", SqlDbType.Char, EL.Cheque_No.Length)
        arParms(8).Value = EL.Cheque_No

        If EL.Accounting_Date = "1/1/3000" Then
            arParms(9) = New SqlParameter("@Accounting_Date", SqlDbType.VarChar)
            arParms(9).Value = DBNull.Value
        Else
            arParms(9) = New SqlParameter("@Accounting_Date", SqlDbType.DateTime)
            arParms(9).Value = EL.Accounting_Date
        End If
        
        arParms(10) = New SqlParameter("@Bank_ID", SqlDbType.Int)
        arParms(10).Value = EL.Bank_ID

        arParms(11) = New SqlParameter("@AccountGroup", SqlDbType.Int)
        arParms(11).Value = EL.AccountGroup


        arParms(12) = New SqlParameter("@Remarks", SqlDbType.Char, EL.Remarks.Length)
        arParms(12).Value = EL.Remarks

        arParms(13) = New SqlParameter("@Currency_Code", SqlDbType.Int)
        arParms(13).Value = EL.Currency

        arParms(14) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        arParms(14).Value = EL.ExchangeRate

        If EL.ChequeDate = "1/1/3000" Then
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.VarChar)
            arParms(15).Value = DBNull.Value
        Else
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(15).Value = EL.ChequeDate
        End If

        arParms(16) = New SqlParameter("@Account", SqlDbType.Int)
        arParms(16).Value = EL.Account
        
        arParms(17) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(17).Value = EL.id

        arParms(18) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(18).Value = HttpContext.Current.Session("BranchCode")

        arParms(19) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(19).Value = HttpContext.Current.Session("EmpCode")

        arParms(20) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("UserCode")

        arParms(21) = New SqlParameter("@ProjectId", SqlDbType.Int)
        arParms(21).Value = EL.ProjectName

        
        

        
        
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertDoubleEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Insert1(ByVal EL As ELDoubleEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(22) {}


        arParms(0) = New SqlParameter("@Entry_Date", SqlDbType.DateTime)
        arParms(0).Value = EL.Entry_Date

        arParms(1) = New SqlParameter("@Amount_Out", SqlDbType.Float)
        arParms(1).Value = EL.Amount_Out


        arParms(2) = New SqlParameter("@Item", SqlDbType.Char, EL.Item.Length)
        arParms(2).Value = EL.Item

        arParms(3) = New SqlParameter("@Amount", SqlDbType.Float)
        arParms(3).Value = EL.Amount

        arParms(4) = New SqlParameter("@Bill_No", SqlDbType.Char, EL.Bill_No.Length)
        arParms(4).Value = EL.Bill_No

        If EL.Bill_Date = "1/1/3000" Then
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.VarChar)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.DateTime)
            arParms(5).Value = EL.Bill_Date
        End If

        arParms(6) = New SqlParameter("@Party_Type", SqlDbType.Int)
        arParms(6).Value = EL.Party_Type

        arParms(7) = New SqlParameter("@Party_Id_Name", SqlDbType.Int)
        arParms(7).Value = EL.Party_Id_Name

        arParms(8) = New SqlParameter("@ChequeNo", SqlDbType.Char, EL.Cheque_No.Length)
        arParms(8).Value = EL.Cheque_No

        If EL.Accounting_Date = "1/1/3000" Then
            arParms(9) = New SqlParameter("@Accounting_Date", SqlDbType.VarChar)
            arParms(9).Value = DBNull.Value
        Else
            arParms(9) = New SqlParameter("@Accounting_Date", SqlDbType.DateTime)
            arParms(9).Value = EL.Accounting_Date
        End If

        arParms(10) = New SqlParameter("@Bank_ID", SqlDbType.Int)
        arParms(10).Value = EL.Bank_ID

        arParms(11) = New SqlParameter("@AccountGroup", SqlDbType.Int)
        arParms(11).Value = EL.AccountGroup


        arParms(12) = New SqlParameter("@Remarks", SqlDbType.Char, EL.Remarks.Length)
        arParms(12).Value = EL.Remarks

        arParms(13) = New SqlParameter("@Currency_Code", SqlDbType.Int)
        arParms(13).Value = EL.Currency

        arParms(14) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        arParms(14).Value = EL.ExchangeRate

        If EL.ChequeDate = "1/1/3000" Then
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.VarChar)
            arParms(15).Value = DBNull.Value
        Else
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(15).Value = EL.ChequeDate
        End If

        arParms(16) = New SqlParameter("@Account", SqlDbType.Int)
        arParms(16).Value = EL.Account

        arParms(17) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(17).Value = EL.id

        arParms(18) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(18).Value = HttpContext.Current.Session("BranchCode")

        arParms(19) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(19).Value = HttpContext.Current.Session("EmpCode")

        arParms(20) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("UserCode")

        arParms(21) = New SqlParameter("@ProjectId", SqlDbType.Int)
        arParms(21).Value = EL.ProjectName

        arParms(22) = New SqlParameter("@id1", SqlDbType.Int)
        arParms(22).Value = EL.id1







        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertDoubleEntry1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetGridData(ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = Id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDoubleEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetGridData1(ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = Id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDoubleEntry1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetNo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ELDoubleEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(21) {}


        arParms(0) = New SqlParameter("@Entry_Date", SqlDbType.DateTime)
        arParms(0).Value = EL.Entry_Date

        arParms(1) = New SqlParameter("@Amount_Out", SqlDbType.Float)
        arParms(1).Value = EL.Amount_Out

        arParms(2) = New SqlParameter("@Item", SqlDbType.Char, EL.Item.Length)
        arParms(2).Value = EL.Item

        arParms(3) = New SqlParameter("@Amount", SqlDbType.Float)
        arParms(3).Value = EL.Amount

        arParms(4) = New SqlParameter("@Bill_No", SqlDbType.Char, EL.Bill_No.Length)
        arParms(4).Value = EL.Bill_No

        If EL.Bill_Date = "1/1/3000" Then
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.VarChar)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.DateTime)
            arParms(5).Value = EL.Bill_Date
        End If

        arParms(6) = New SqlParameter("@Party_Type", SqlDbType.Int)
        arParms(6).Value = EL.Party_Type

        arParms(7) = New SqlParameter("@Party_Id_Name", SqlDbType.Int)
        arParms(7).Value = EL.Party_Id_Name

        arParms(8) = New SqlParameter("@ChequeNo", SqlDbType.Char, EL.Cheque_No.Length)
        arParms(8).Value = EL.Cheque_No

        If EL.Accounting_Date = "1/1/3000" Then
            arParms(9) = New SqlParameter("@Accounting_Date", SqlDbType.VarChar)
            arParms(9).Value = DBNull.Value
        Else
            arParms(9) = New SqlParameter("@Accounting_Date", SqlDbType.DateTime)
            arParms(9).Value = EL.Accounting_Date
        End If

        arParms(10) = New SqlParameter("@Bank_ID", SqlDbType.Int)
        arParms(10).Value = EL.Bank_ID

        arParms(11) = New SqlParameter("@AccountGroup", SqlDbType.Int)
        arParms(11).Value = EL.AccountGroup


        arParms(12) = New SqlParameter("@Remarks", SqlDbType.Char, EL.Remarks.Length)
        arParms(12).Value = EL.Remarks

        arParms(13) = New SqlParameter("@Currency_Code", SqlDbType.Int)
        arParms(13).Value = EL.Currency

        arParms(14) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        arParms(14).Value = EL.ExchangeRate

        If EL.ChequeDate = "1/1/3000" Then
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.VarChar)
            arParms(15).Value = DBNull.Value
        Else
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(15).Value = EL.ChequeDate
        End If

        arParms(16) = New SqlParameter("@Account", SqlDbType.Int)
        arParms(16).Value = EL.Account

        arParms(17) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(17).Value = EL.id

        arParms(18) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(18).Value = HttpContext.Current.Session("BranchCode")

        arParms(19) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(19).Value = HttpContext.Current.Session("EmpCode")

        arParms(20) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("UserCode")

        arParms(21) = New SqlParameter("@ProjectId", SqlDbType.Int)
        arParms(21).Value = EL.ProjectName

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateDoubleEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal EL As ELDoubleEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteDoubleEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function GetDuplicateAcademicYear(ByVal EL As String, ByVal id As Integer) As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@AcademicYear", SqlDbType.NVarChar, 50)
        para(1).Value = EL
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_SelectDuplicateYear", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
