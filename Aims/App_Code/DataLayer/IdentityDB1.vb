Imports Microsoft.VisualBasic
Namespace GlobalDataSetTableAdapters
    Partial Public Class IdentityCardTableAdapter
        'd As Integer
        'Public Sub InsertRecord(ByVal I_No As Long, ByVal Course_Id As Long, ByVal BatchNo As Long, ByVal Institute_Id As Long, ByVal Branch_Id As Long, ByVal ReceiptNo As Long, ByVal IssuedMonth As String, ByVal Amount As Long, ByVal ReceiptDate As Date, ByVal StdId As Long, ByVal Issued As Boolean, ByVal StdName As String, ByVal RegistrationNo As String)
        'Public Function InsertRecord(ByVal Course_Id As Int32, ByVal BatchNo As Int32, ByVal Institute_Id As Int32, ByVal Branch_Id As Int32, ByVal ReceiptNo As Int32, ByVal IssuedMonth As String, ByVal Amount As Int32, ByVal ReceiptDate As Date, ByVal StdId As Int32, ByVal Issued As Boolean, ByVal StdName As String, ByVal RegistrationNo As String, ByVal StdCode As String) As Integer
        'Public Function InsertRecord(ByVal Course_Id As Int32, ByVal BatchNo As Int32, ByVal Institute_Id As Int32, ByVal Branch_Id As Int32, ByVal ReceiptNo As Int32, ByVal IssuedMonth As String, ByVal Amount As Int32, ByVal ReceiptDate As Date, ByVal StdId As Int32, ByVal Issued As Boolean, ByVal StdName As String, ByVal RegistrationNo As String) As Integer
        '    Dim Identitycd As New GlobalDataSet.IdentityCardDataTable
        '    Dim newreg As GlobalDataSet.IdentityCardRow = Identitycd.NewIdentityCardRow
        '    'newreg.I_No = I_No
        '    newreg.Course_Id = Course_Id
        '    newreg.BatchNo = BatchNo
        '    newreg.Institute_Id = Institute_Id
        '    newreg.Branch_Id = Branch_Id
        '    newreg.ReceiptNo = ReceiptNo
        '    newreg.IssuedMonth = IssuedMonth
        '    newreg.Amount = Amount
        '    newreg.ReceiptDate = ReceiptDate
        '    newreg.StdId = StdId
        '    newreg.Issued = Issued
        '    newreg.StdName = StdName
        '    'newreg.StdCode = stdcode
        '    newreg.RegistrationNo = RegistrationNo
        '    Identitycd.AddIdentityCardRow(newreg)
        '    Me.Adapter.Update(Identitycd)
        '    Return 0
        'End Function
        'Public Function UpdateRecord()
        '    Return 0
        'End Function
        'Public Function DeleteRecord()
        '    Return 0
        'End Function
    End Class
End Namespace