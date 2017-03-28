Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class DayBookManager
    Dim daybook As New DayBookDB
    Public Function GetDayBook() As Data.DataTable
        Return DayBookDB.GetDayBook()
        'Dim daybook As New List(Of DayBookEL)
        'Dim ds As DataSet = DayBookDB.GetDayBook()
        'Dim row As DataRow
        'For Each row In ds.Tables(0).Rows
        '    daybook.Add(New DayBookEL(row("Expense_ID"), row("Entry_Date"), row("Account_Head"), row("Item"), row("Amount"), row("Bill_No"), row("Bill_Date"), row("Party_Type"), row("Party_Id_Name"), row("Remarks"), row("ChequeNo"), row("Bank_ID"), row("Branch"), row("PaymentMethod_Id"), row("Currency_Code"), row("ExchangeRate"), row("ChequeDate"), row("ChequeBank_ID"), row("Field1")))
        'Next

    End Function
    Public Function GetDayBook(ByVal Expenses_ID As Long) As Data.DataTable
        Return DayBookDB.GetDayBook(Expenses_ID)
        'Dim ds As DataSet = DayBookDB.GetDayBook(Expenses_ID)
        'Dim row As DataRow = ds.Tables(0).Rows(0)
        'daybook = New DayBookEL(row("Expense_ID"), row("Entry_Date"), row("Account_Head"), row("Item"), row("Amount"), row("Bill_No"), row("Bill_Date"), row("Party_Type"), row("Party_Id_Name"), row("Remarks"), row("ChequeNo"), row("Bank_ID"), row("Branch"), row("PaymentMethod_Id"), row("Currency_Code"), row("ExchangeRate"), row("ChequeDate"), row("ChequeBank_ID"), row("Field1"))

    End Function
    Public Function GetDayBookGV() As System.Data.DataTable
        Return DayBookDB.GetDayBookGV()

    End Function
    Public Function GetCurrency() As System.Data.DataTable
        Return DayBookDB.GetCurrency()

    End Function
    Public Function GetCurrencyRate(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetCurrencyRate(db)

    End Function
    Public Function Series(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.Series(db)
    End Function
    Public Function Series1(ByVal Acct_Id As Integer, ByVal Acct_Treat As Integer) As System.Data.DataTable
        Return DayBookDB.Series1(Acct_Id, Acct_Treat)
    End Function
    Public Function GetDayBookGVDaybook(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetDayBookGV_Daybook(db)
    End Function
    Public Function GetTypeAcct(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetTypeAcct(db)
    End Function
    Public Function GetBillSerialNoCV(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetBillSerialNoCV(db)
    End Function
    Public Function GetChequeNo(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetChequeNo(db)
    End Function
    Public Function GetBillSerialNoBV(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetBillSerialNoBV(db)
    End Function
    Public Function GetBillSerialNoCR(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetBillSerialNoCR(db)
    End Function
    Public Function GetBillSerialNoBR(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetBillSerialNoBR(db)
    End Function
    Public Function GetBillSerialNoJV(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetBillSerialNoJV(db)
    End Function
    Public Function GetDayBookGVDaybook1(ByVal db As DayBookEL) As System.Data.DataTable
        Return DayBookDB.GetDayBookGV_Daybook1(db)
    End Function
    Public Function GetPartyType() As System.Data.DataSet
        Return DayBookDB.GetPartyType(0)
        'Dim PType As New List(Of DayBookPartyName)
        'Dim ds As DataSet = DayBookDB.GetPartyType(0)
        'Dim row As DataRow
        'For Each row In ds.Tables(0).Rows
        '    PType.Add(New DayBookPartyName(row("Name"), row("Id")))
        'Next

    End Function
    Public Function GetProjectName() As System.Data.DataSet
        Return DayBookDB.GetProjectName()
    End Function
    Public Function GetPartyType1(ByVal id As Long) As DataSet
        Return DayBookDB.GetPartyType(id)
    End Function
    Public Function GetPartyType(ByVal Id As Long) As DayBookPartyName
        Dim PType As DayBookPartyName
        Dim ds As DataSet = DayBookDB.GetPartyType(Id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        PType = New DayBookPartyName(row("Name"), row("Id"))
        Return PType
    End Function
    Public Function InsertRecord(ByVal db As DayBookEL) As Integer
        Return DayBookDB.Insert(db)
    End Function
    'code for Insert Into DayBook By Nitin 19-03-2012
    Public Function InsertIntoDayBook(ByVal db As DayBookEL) As String
        Return DayBookDB.InsertIntoDayBook(db)
    End Function
    Public Function UpdateRecord(ByVal db As DayBookEL) As Integer
        Return DayBookDB.Update(db)
    End Function
  
    Public Function ChangeFlag(ByVal ID As Long) As Integer
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(db.Expense_ID, "Expenses")
        'If (Status) = True Then
        '    Exit Function
        'End If
        Return DayBookDB.ChangeFlag(ID)
    End Function
    Public Function PostToDayBook(ByVal EL As DayBookEL) As Integer
        Return daybook.PostToDayBook(EL)
    End Function
End Class
