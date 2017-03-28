Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DayBookDB
    Shared Function GetPartyTypeExt(ByVal prefixText As String, ByVal PartyType As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Prefix", SqlDbType.VarChar, 50)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@PartyType", SqlDbType.Int)
        arParms(1).Value = PartyType

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPartyTypeExt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetReceipt(ByVal id As String) As System.Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@REF_ID", SqlDbType.VarChar, 50)
            arParms(2).Value = id

            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_Receipt", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetCashVoucher(ByVal VType As String, ByVal fromdate As String, ByVal todate As String, ByVal FSerial As String, ByVal TSerial As String) As System.Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(6) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@VType", SqlDbType.Int)
            arParms(2).Value = VType

            arParms(3) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(3).Value = fromdate

            arParms(4) = New SqlParameter("@todate", SqlDbType.DateTime)
            arParms(4).Value = todate

            arParms(5) = New SqlParameter("@FSerial", SqlDbType.VarChar, 50)
            arParms(5).Value = FSerial

            arParms(6) = New SqlParameter("@TSerial", SqlDbType.VarChar, 50)
            arParms(6).Value = TSerial



            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_cashVoucher", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSerial(ByVal AGOne As String) As System.Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@AGOne", SqlDbType.Int)
            arParms(2).Value = AGOne

            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetSerialNo", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetNo(ByVal Type As String) As System.Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@Type", SqlDbType.Int)
            arParms(2).Value = Type

            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetVoucherChequeNo", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetCheckPost(ByVal id As String) As System.Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@REF_ID", SqlDbType.VarChar, 50)
            arParms(2).Value = id

            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_CheckPost", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDayBook() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetExpenses", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function NewDayBookreport(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal ReportType As String, ByVal S1 As String, ByVal S2 As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@ReportType", SqlDbType.VarChar, 50)
        arParms(4).Value = ReportType

        arParms(5) = New SqlParameter("@S1", SqlDbType.VarChar, 50)
        arParms(5).Value = S1

        arParms(6) = New SqlParameter("@S2", SqlDbType.VarChar, 50)
        arParms(6).Value = S2


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_DayBook_Rpt_New", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function DayBookreport(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal ReportType As String, ByVal S1 As String, ByVal S2 As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@ReportType", SqlDbType.VarChar, 50)
        arParms(4).Value = ReportType

        arParms(5) = New SqlParameter("@S1", SqlDbType.VarChar, 50)
        arParms(5).Value = S1

        arParms(6) = New SqlParameter("@S2", SqlDbType.VarChar, 50)
        arParms(6).Value = S2


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_DayBook_Rpt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function ProjectWiseDayBookreport(ByVal PR As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(4).Value = PR


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_DayBook_RptProjectWise", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetDayBook(ByVal Expid As Long) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet


        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Expense_ID", SqlDbType.Int)
        arParms(0).Value = Expid
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetExpensesbyID", arParms)
            Return ds.Tables(0)
        Catch e As Exception
            MsgBox(Expid.ToString)
        End Try
    End Function
    Shared Function GetDayBookGV() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetGvdisExpense", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'Try
        '    'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * FRom DispGV_Expenses where BranchCode=" & HttpContext.Current.Session("BranchCode") & "Branch_ID=" & HttpContext.Current.Session("BranchID"))
        'Catch e As Exception
        '    ds = New DataSet
        'End Try
    End Function
    Shared Function GetCurrency() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCurrency", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCurrencyRate(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@Currency", SqlDbType.Int)
        para(2).Value = db.Currency
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMultiCurrencyRate", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Series(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@ActHead", SqlDbType.Int)
        para(2).Value = db.Account_Head
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Acct", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function Series1(ByVal Acct_Id As Integer, ByVal Acct_Treat As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@Acct_Id", SqlDbType.Int)
        para(2).Value = Acct_Id
        para(3) = New SqlParameter("@Acct_Treat", SqlDbType.Int)
        para(3).Value = Acct_Treat
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetVoucherNo", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetDayBookGV_Daybook(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(9) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = db.Expense_ID
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@Account_Head", SqlDbType.Int)
        para(3).Value = db.Account_Head
        para(4) = New SqlParameter("@Item", SqlDbType.VarChar, db.Item.Length)
        para(4).Value = db.Item
        para(5) = New SqlParameter("@Party_Type", SqlDbType.Int)
        para(5).Value = db.Party_Type
        para(6) = New SqlParameter("@Party_Name", SqlDbType.VarChar, db.Party_Name.Length)
        para(6).Value = db.Party_Name
        para(7) = New SqlParameter("@Bill_No", SqlDbType.VarChar, db.Bill_No.Length)
        para(7).Value = db.Bill_No
        para(8) = New SqlParameter("@ProjectId", SqlDbType.VarChar)
        para(8).Value = db.ProjectName
        para(9) = New SqlParameter("@ChequeNo", SqlDbType.VarChar, 50)
        para(9).Value = db.Cheque_No


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDispGVDayBook", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetTypeAcct(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@AccountId", SqlDbType.Int)
        para(0).Value = db.Account_Head
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAccountType", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBillSerialNoCV(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetserialBillNoCV", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBillSerialNoBV(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetserialBillNoBV", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetChequeNo(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetChequeNo", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBillSerialNoCR(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetserialBillNoCR", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBillSerialNoBR(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetserialBillNoBR", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBillSerialNoJV(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetserialBillNoJV", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetDayBookGV_Daybook1(ByVal db As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(9) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = db.Expense_ID
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@Account_Head", SqlDbType.Int)
        para(3).Value = db.Account_Head
        para(4) = New SqlParameter("@Item", SqlDbType.VarChar, db.Item.Length)
        para(4).Value = db.Item
        para(5) = New SqlParameter("@Party_Type", SqlDbType.Int)
        para(5).Value = db.Party_Type
        para(6) = New SqlParameter("@Party_Name", SqlDbType.VarChar, db.Party_Name.Length)
        para(6).Value = db.Party_Name
        para(7) = New SqlParameter("@Bill_No", SqlDbType.VarChar, db.Bill_No.Length)
        para(7).Value = db.Bill_No
        para(8) = New SqlParameter("@ProjectId", SqlDbType.VarChar)
        para(8).Value = db.ProjectName
        para(9) = New SqlParameter("@ChequeNo", SqlDbType.VarChar, 50)
        para(9).Value = db.Cheque_No


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDispGVDayBookNotPosted", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetPartyType(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        If id = 0 Then
            Dim para() As SqlParameter = New SqlParameter(1) {}
            para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            para(0).Value = HttpContext.Current.Session("Office")
            para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(1).Value = HttpContext.Current.Session("BranchCode")
            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPartyType", para)
                Return ds
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Dim para() As SqlParameter = New SqlParameter(2) {}
            para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            para(0).Value = HttpContext.Current.Session("Office")
            para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(1).Value = HttpContext.Current.Session("BranchCode")
            para(2) = New SqlParameter("@PartyId", SqlDbType.VarChar, 50)
            para(2).Value = HttpContext.Current.Session("PartyId")

            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPartyTypeById", para)
                Return ds
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Function
    Shared Function GetProjectName() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetProjectNameDDL", para)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function Insert(ByVal db As DayBookEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(22) {}

        arParms(0) = New SqlParameter("@Entry_Date", SqlDbType.DateTime)
        arParms(0).Value = db.Entry_Date

        arParms(1) = New SqlParameter("@Account_Head", SqlDbType.Int)
        arParms(1).Value = db.Account_Head

        arParms(2) = New SqlParameter("@Item", SqlDbType.Char, db.Item.Length)
        arParms(2).Value = db.Item

        arParms(3) = New SqlParameter("@Amount", SqlDbType.Float)
        arParms(3).Value = db.Amount

        arParms(4) = New SqlParameter("@Bill_No", SqlDbType.Char, db.Bill_No.Length)
        arParms(4).Value = db.Bill_No

        If db.Bill_Date = "1/1/3000" Then
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.VarChar)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.DateTime)
            arParms(5).Value = db.Bill_Date
        End If

        arParms(6) = New SqlParameter("@Party_Type", SqlDbType.Int)
        arParms(6).Value = db.Party_Type

        arParms(7) = New SqlParameter("@Party_Id_Name", SqlDbType.Int)
        arParms(7).Value = db.Party_Id_Name

        arParms(8) = New SqlParameter("@ChequeNo", SqlDbType.Char, db.Cheque_No.Length)
        arParms(8).Value = db.Cheque_No
        'If db.PaymentMethod_Id = "0" Then
        '    arParms(9) = New SqlParameter("@PaymentMethod_Id", SqlDbType.Int)
        '    arParms(9).Value = db.PaymentMethod_Id
        'Else
        arParms(9) = New SqlParameter("@PaymentMethod_Id", SqlDbType.Int)
        arParms(9).Value = db.PaymentMethod_Id
        'End If

        arParms(10) = New SqlParameter("@Bank_ID", SqlDbType.Int)
        arParms(10).Value = db.Bank_ID

        arParms(11) = New SqlParameter("@Branch", SqlDbType.Char, db.Branch.Length)
        arParms(11).Value = db.Branch

        arParms(12) = New SqlParameter("@Remarks", SqlDbType.Char, db.Remarks.Length)
        arParms(12).Value = db.Remarks

        arParms(13) = New SqlParameter("@Currency_Code", SqlDbType.Int)
        arParms(13).Value = db.Currency_Code

        arParms(14) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        arParms(14).Value = db.ExchangeRate

        If db.ChequeDate = "1/1/3000" Then
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.VarChar)
            arParms(15).Value = DBNull.Value
        Else
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(15).Value = db.ChequeDate
        End If

        arParms(16) = New SqlParameter("@ChequeBank_ID", SqlDbType.Int)
        arParms(16).Value = db.ChequeBank_ID

        'If db.Field1 = "0" Then
        '    arParms(17) = New SqlParameter("@Field1", SqlDbType.Int)
        '    arParms(17).Value = db.Field1
        'Else
        arParms(17) = New SqlParameter("@Field1", SqlDbType.Int)
        arParms(17).Value = db.Field1
        'End If

        arParms(18) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(18).Value = HttpContext.Current.Session("BranchCode")

        arParms(19) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(19).Value = HttpContext.Current.Session("EmpCode")

        arParms(20) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("UserCode")

        arParms(21) = New SqlParameter("@ProjectId", SqlDbType.Int)
        arParms(21).Value = db.ProjectName

        If db.Accounting_Date = "1/1/3000" Then
            arParms(22) = New SqlParameter("@Accounting_Date", SqlDbType.VarChar)
            arParms(22).Value = DBNull.Value
        Else
            arParms(22) = New SqlParameter("@Accounting_Date", SqlDbType.DateTime)
            arParms(22).Value = db.Accounting_Date
        End If

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveExpenses", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal db As DayBookEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(23) {}

        arParms(0) = New SqlParameter("@Entry_Date", SqlDbType.DateTime)
        arParms(0).Value = db.Entry_Date

        arParms(1) = New SqlParameter("@Account_Head", SqlDbType.Int)
        arParms(1).Value = db.Account_Head

        arParms(2) = New SqlParameter("@Item", SqlDbType.Char, db.Item.Length)
        arParms(2).Value = db.Item

        arParms(3) = New SqlParameter("@Amount", SqlDbType.Float)
        arParms(3).Value = db.Amount

        arParms(4) = New SqlParameter("@Bill_No", SqlDbType.Char, db.Bill_No.Length)
        arParms(4).Value = db.Bill_No

        If db.Bill_Date = "1/1/3000" Then
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.VarChar)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Bill_Date", SqlDbType.DateTime)
            arParms(5).Value = db.Bill_Date
        End If

        arParms(6) = New SqlParameter("@Party_Type", SqlDbType.Int)
        arParms(6).Value = db.Party_Type

        arParms(7) = New SqlParameter("@Party_Id_Name", SqlDbType.Int)
        arParms(7).Value = db.Party_Id_Name

        arParms(8) = New SqlParameter("@ChequeNo", SqlDbType.Char, db.Cheque_No.Length)
        arParms(8).Value = db.Cheque_No

        arParms(9) = New SqlParameter("@PaymentMethod_Id", SqlDbType.Int)
        arParms(9).Value = db.PaymentMethod_Id

        arParms(10) = New SqlParameter("@Bank_ID", SqlDbType.Int)
        arParms(10).Value = db.Bank_ID

        arParms(11) = New SqlParameter("@Branch", SqlDbType.Char, db.Branch.Length)
        arParms(11).Value = db.Branch

        arParms(12) = New SqlParameter("@Remarks", SqlDbType.Char, db.Remarks.Length)
        arParms(12).Value = db.Remarks

        arParms(13) = New SqlParameter("@Currency_Code", SqlDbType.Int)
        arParms(13).Value = db.Currency_Code

        arParms(14) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        arParms(14).Value = db.ExchangeRate

        If db.ChequeDate = "1/1/3000" Then
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.VarChar)
            arParms(15).Value = DBNull.Value
        Else
            arParms(15) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(15).Value = db.ChequeDate
        End If

        arParms(16) = New SqlParameter("@ChequeBank_ID", SqlDbType.Int)
        arParms(16).Value = db.ChequeBank_ID

        arParms(17) = New SqlParameter("@Field1", SqlDbType.Int)
        arParms(17).Value = db.Field1

        arParms(18) = New SqlParameter("@Expense_ID", SqlDbType.Int)
        arParms(18).Value = db.Expense_ID

        arParms(19) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(19).Value = HttpContext.Current.Session("BranchCode")

        arParms(20) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("EmpCode")

        arParms(21) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(21).Value = HttpContext.Current.Session("UserCode")

        arParms(22) = New SqlParameter("@ProjectId", SqlDbType.Int)
        arParms(22).Value = db.ProjectName

        If db.Accounting_Date = "1/1/3000" Then
            arParms(23) = New SqlParameter("@Accounting_Date", SqlDbType.VarChar)
            arParms(23).Value = DBNull.Value
        Else
            arParms(23) = New SqlParameter("@Accounting_Date", SqlDbType.DateTime)
            arParms(23).Value = db.Accounting_Date
        End If


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateExpenses", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@Expense_ID", SqlDbType.VarChar, 50)
        arParms.Value = Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteExpenses", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'code for Insert Into DayBook By Nitin 19-03-2012

    Shared Function InsertIntoDayBook(ByVal db As DayBookEL) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As String = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_InsertAcctOneIntoDayBook", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function PostToDayBook(ByVal EL As DayBookEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode ", SqlDbType.NVarChar, 4000)
        arParms(3).Value = EL.ChkID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostDayBook", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function PostCheck(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPostApprovalforDaybook", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetPrintPath() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        Dim ds As New DataSet

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetPrintPath")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
End Class
