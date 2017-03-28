Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.web.UI.WebControls
Public Class IncomeTaxDA
    'Dim str As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    Public Function recovergrid() As Data.DataTable
        'query = "SELECT IT_ID,ITDescription,LowerLimit,UpperLimit,Category,StdDeduction,ITPercent,FinancialYear FROM IncomeTax WHERE Del_Flag='Y'"
        'proc_RecoverIncomeTaxGrid
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_RecoverIncomeTaxGrid")
        Return ds.Tables(0)
    End Function
    Public Function recover(ByVal IT_id As Int64) As Integer
        'proc_RecoverIncomeTaxGridByID
        'Dim query As String = "UPDATE IncomeTax SET Del_Flag='N' WHERE IT_ID=" & IT_id
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@IT_id", SqlDbType.Int)
        arParms.Value = IT_id
        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_RecoverIncomeTaxGridByID", arParms)
        Return rowsAffected
    End Function
    Public Function update(ByVal P As IncomeTaxE) As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'query = "UPDATE IncomeTax SET ITDescription='" & Prop.ITDescription & "',LowerLimit='" & Prop.Lowerlimit & "',UpperLimit='" & Prop.Upperlimit & "',Category='" & Prop.Category & "',StdDeduction='" & Prop.Stddeduction & "',ITPercent='" & Prop.ITPercent & "',FinancialYear='" & Prop.Financialyear & "' WHERE IT_ID=" & Prop.IT_id
        'proc_UpdateIncomeTaxByID
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@ITDescription", SqlDbType.VarChar, P.ITDescription.Length)
        arParms(0).Value = P.ITDescription

        arParms(1) = New SqlParameter("@Lowerlimit", SqlDbType.Money)
        arParms(1).Value = P.Lowerlimit

        arParms(2) = New SqlParameter("@Upperlimit", SqlDbType.Money)
        arParms(2).Value = P.Upperlimit

        arParms(3) = New SqlParameter("@Category", SqlDbType.VarChar, P.Category.Length)
        arParms(3).Value = P.Category

        arParms(4) = New SqlParameter("@Stddeduction", SqlDbType.Money)
        arParms(4).Value = P.Stddeduction

        arParms(5) = New SqlParameter("@ITPercent", SqlDbType.Int)
        arParms(5).Value = P.ITPercent

        arParms(6) = New SqlParameter("@Financialyear", SqlDbType.VarChar, P.Financialyear.Length)
        arParms(6).Value = P.Financialyear


        arParms(7) = New SqlParameter("@empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@usercode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")


        arParms(9) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("BranchCode")

        arParms(10) = New SqlParameter("@IT_id", SqlDbType.Int)
        arParms(10).Value = P.IT_id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateIncomeTaxByID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function delete(ByVal IT_id As Int64) As Integer
        'Dim query As String = "UPDATE IncomeTax SET Del_Flag='-1' WHERE IT_ID=" & IT_id
        'proc_DeleteIncomeTaxByID
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@IT_id", SqlDbType.Int)
        arParms.Value = IT_id
        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteIncomeTaxByID", arParms)
        Return rowsAffected
    End Function
    Public Function grid(ByVal a As Integer) As Data.DataTable
        'query = "SELECT IT_ID,ITDescription,LowerLimit,UpperLimit,Category,StdDeduction,ITPercent,FinancialYear FROM IncomeTax WHERE Del_Flag= 0 "
        'proc_FillGridIncomeTax
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(2).Value = a

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_FillGridIncomeTax", arParms)
            Return ds.Tables(0)
        Catch ex As Exception

        End Try
       
    End Function
    Public Function send(ByVal P As IncomeTaxE) As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'query = "INSERT INTO IncomeTax(ITDescription,LowerLimit,UpperLimit,Category,StdDeduction,ITPercent,FinancialYear) values(@itdescription,@lowerlimit,@upperlimit,@category,@stddeduction,@itpercent,@financialyear)"
        'proc_SaveIncomeTaxData
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@ITDescription", SqlDbType.VarChar, P.ITDescription.Length)
        arParms(0).Value = p.ITDescription

        arParms(1) = New SqlParameter("@Lowerlimit", SqlDbType.Money)
        arParms(1).Value = p.Lowerlimit

        arParms(2) = New SqlParameter("@Upperlimit", SqlDbType.Money)
        arParms(2).Value = P.Upperlimit

        arParms(3) = New SqlParameter("@Category", SqlDbType.VarChar, P.Category.Length)
        arParms(3).Value = P.Category

        arParms(4) = New SqlParameter("@Stddeduction", SqlDbType.Money)
        arParms(4).Value = P.Stddeduction

        arParms(5) = New SqlParameter("@ITPercent", SqlDbType.Int)
        arParms(5).Value = P.ITPercent

        arParms(6) = New SqlParameter("@Financialyear", SqlDbType.VarChar, P.Financialyear.Length)
        arParms(6).Value = P.Financialyear


        arParms(7) = New SqlParameter("@empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@usercode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        
        arParms(9) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_SaveIncomeTaxData", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class

