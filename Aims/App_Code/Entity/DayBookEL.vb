Imports Microsoft.VisualBasic

Public Class DayBookEL
    Private _expense_ID As Integer
    Public Property Expense_ID() As Integer
        Get
            Return _expense_ID
        End Get
        Set(ByVal value As Integer)
            _expense_ID = value
        End Set
    End Property
    Private _AGOne As Integer
    Public Property AGOne() As Integer
        Get
            Return _AGOne
        End Get
        Set(ByVal value As Integer)
            _AGOne = value
        End Set
    End Property
    Private _ATOne As Integer
    Public Property ATOne() As Integer
        Get
            Return _ATOne
        End Get
        Set(ByVal value As Integer)
            _ATOne = value
        End Set
    End Property
    Private _PaymentMethod As Integer
    Public Property PaymentMethod() As Integer
        Get
            Return _PaymentMethod
        End Get
        Set(ByVal value As Integer)
            _PaymentMethod = value
        End Set
    End Property
    Private _Currency As String
    Public Property Currency() As String
        Get
            Return _Currency
        End Get
        Set(ByVal value As String)
            _Currency = value
        End Set
    End Property
    Private _Code As String
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property
    Private _ChkID As String
    Public Property ChkID() As String
        Get
            Return _ChkID
        End Get
        Set(ByVal value As String)
            _ChkID = value
        End Set
    End Property
    Private _entry_Date As Date
    Public Property Entry_Date() As Date
        Get
            Return _entry_Date
        End Get
        Set(ByVal value As Date)
            _entry_Date = value
        End Set
    End Property
    Private _Voucher_Type As String
    Public Property Voucher_Type() As String
        Get
            Return _Voucher_Type
        End Get
        Set(ByVal value As String)
            _Voucher_Type = value
        End Set
    End Property
    Private _Accounting_Date As Date
    Public Property Accounting_Date() As Date
        Get
            Return _Accounting_Date
        End Get
        Set(ByVal value As Date)
            _Accounting_Date = value
        End Set
    End Property
    Private _account_Head As Integer
    Public Property Account_Head() As Integer
        Get
            Return _account_Head
        End Get
        Set(ByVal value As Integer)
            _account_Head = value
        End Set
    End Property
    Private _item As String
    Public Property Item() As String
        Get
            Return _item
        End Get
        Set(ByVal value As String)
            _item = value
        End Set
    End Property
    Private _amount As Double
    Public Property Amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property
    Private _amount_out As Double
    Public Property Amount_Out() As Double
        Get
            Return _amount_out
        End Get
        Set(ByVal value As Double)
            _amount_out = value
        End Set
    End Property
    Private _bill_No As String
    Public Property Bill_No() As String
        Get
            Return _bill_No
        End Get
        Set(ByVal value As String)
            _bill_No = value
        End Set
    End Property

    Private _bill_Date As Date
    Public Property Bill_Date() As Date
        Get
            Return _bill_Date
        End Get
        Set(ByVal value As Date)
            _bill_Date = value
        End Set
    End Property
    Private _party_Type As Integer
    Public Property Party_Type() As Integer
        Get
            Return _party_Type
        End Get
        Set(ByVal value As Integer)
            _party_Type = value
        End Set
    End Property
    Private _ProjectName As Integer
    Public Property ProjectName() As Integer
        Get
            Return _ProjectName
        End Get
        Set(ByVal value As Integer)
            _ProjectName = value
        End Set
    End Property
    Private _party_Id_Name As Integer
    Public Property Party_Id_Name() As Integer
        Get
            Return _party_Id_Name
        End Get
        Set(ByVal value As Integer)
            _party_Id_Name = value
        End Set
    End Property
    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    'Private _appendAcc_One_Flag As Boolean
    'Public Property AppendAcc_One_Flag() As Boolean
    '    Get
    '        Return _appendAcc_One_Flag
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _appendAcc_One_Flag = value
    '    End Set
    'End Property
    'Private _appendAcc_Two_Flag As Boolean
    'Public Property AppendAcc_Two_Flag() As Boolean
    '    Get
    '        Return _appendAcc_Two_Flag
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _appendAcc_Two_Flag = value
    '    End Set
    'End Property
    Private _cheque_No As String
    Public Property Cheque_No() As String
        Get
            Return _cheque_No
        End Get
        Set(ByVal value As String)
            _cheque_No = value
        End Set
    End Property
    Private _bank_ID As Integer
    Public Property Bank_ID() As Integer
        Get
            Return _bank_ID
        End Get
        Set(ByVal value As Integer)
            _bank_ID = value
        End Set
    End Property
    Private _branch As String
    Public Property Branch() As String
        Get
            Return _branch
        End Get
        Set(ByVal value As String)
            _branch = value
        End Set
    End Property
    Private _paymentMethod_Id As Integer
    Public Property PaymentMethod_Id() As Integer
        Get
            Return _paymentMethod_Id
        End Get
        Set(ByVal value As Integer)
            _paymentMethod_Id = value
        End Set
    End Property
    Private _currency_Code As Integer
    Public Property Currency_Code() As Integer
        Get
            Return _currency_Code
        End Get
        Set(ByVal value As Integer)
            _currency_Code = value
        End Set
    End Property

    Private _exchangeRate As Double
    Public Property ExchangeRate() As Double
        Get
            Return _exchangeRate
        End Get
        Set(ByVal value As Double)
            _exchangeRate = value
        End Set
    End Property
    Private _chequeDate As Date
    Public Property ChequeDate() As Date
        Get
            Return _chequeDate
        End Get
        Set(ByVal value As Date)
            'If value = "" Then
            '    _chequeDate = CDate("01/01/2000")
            'Else
            _chequeDate = value
            'End If
        End Set
    End Property
    Private _chequeBank_ID As Integer
    Public Property ChequeBank_ID() As Integer
        Get
            Return _chequeBank_ID
        End Get
        Set(ByVal value As Integer)
            _chequeBank_ID = value
        End Set
    End Property
    Private _Field1 As Integer
    Public Property Field1() As Integer
        Get
            Return _Field1
        End Get
        Set(ByVal value As Integer)
            _Field1 = value
        End Set
    End Property
    Private _currency_Name As String
    Public Property Currency_Name() As String
        Get
            Return _currency_Name
        End Get
        Set(ByVal value As String)
            _currency_Name = value
        End Set
    End Property
    Private _Bank_Name As String
    Public Property Bank_Name() As String
        Get
            Return _Bank_Name
        End Get
        Set(ByVal value As String)
            _Bank_Name = value
        End Set
    End Property
    Private _Party_Name As String
    Public Property Party_Name() As String
        Get
            Return _Party_Name
        End Get
        Set(ByVal value As String)
            _Party_Name = value
        End Set
    End Property

    Private _Head_Type As String
    Public Property Head_Type() As String
        Get
            Return _Head_Type
        End Get
        Set(ByVal value As String)
            _Head_Type = value
        End Set
    End Property
    Private _Party_Type_N As String
    Public Property Party_Type_N() As String
        Get
            Return _Party_Type_N
        End Get
        Set(ByVal value As String)
            _Party_Type_N = value
        End Set
    End Property
    Private _acc_sub_grp As String
    Public Property Acc_Sub_Grp() As String
        Get
            Return _acc_sub_grp
        End Get
        Set(ByVal value As String)
            _acc_sub_grp = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal expense_ID As Int16, ByVal entry_Date As Date, ByVal account_Head As Int16, ByVal item As String, _
                   ByVal amount As Double, ByVal bill_No As String, ByVal bill_Date As Date, ByVal party_Type As Int16, _
                   ByVal party_Id_Name As Int16, ByVal remarks As String, ByVal cheque_No As String, ByVal Bank_ID As Int16, _
                   ByVal branch As String, ByVal paymentMethod_Id As Int16, ByVal currency_Code As Int16, _
                   ByVal exchangeRate As Double, ByVal chequeDate As Date, ByVal chequeBank_ID As Int16, ByVal Field1 As Int16)
        _expense_ID = expense_ID
        _entry_Date = entry_Date
        _account_Head = account_Head
        _item = item
        _amount = amount
        _bill_No = bill_No
        _bill_Date = bill_Date
        _party_Type = party_Type
        _party_Id_Name = party_Id_Name
        _remarks = remarks
        _cheque_No = cheque_No
        _bank_ID = Bank_ID
        _branch = branch
        _paymentMethod_Id = paymentMethod_Id
        _currency_Code = currency_Code
        _exchangeRate = exchangeRate
        _chequeDate = chequeDate
        _chequeBank_ID = chequeBank_ID
        _Field1 = Field1
    End Sub
    Public Sub New(ByVal expense_ID As Int16, ByVal entry_Date As Date, ByVal Head_Type As String, ByVal item As String, _
                   ByVal amount As Double, ByVal bill_No As String, ByVal bill_Date As Date, ByVal Party_Type_N As String, _
                   ByVal Party_Name As String, ByVal remarks As String, ByVal cheque_No As String, ByVal bank_Name As String, _
                   ByVal branch As String, ByVal currency_Code As Int16, ByVal chequeDate As Date, ByVal currency_Name As String)
        _expense_ID = expense_ID
        _entry_Date = entry_Date
        _Head_Type = Head_Type
        _item = item
        _amount = amount
        _bill_No = bill_No
        _bill_Date = bill_Date
        _Party_Type_N = Party_Type_N
        _Party_Name = Party_Name
        _remarks = remarks
        _cheque_No = cheque_No
        _Bank_Name = bank_Name
        _branch = branch
        _currency_Code = currency_Code
        _chequeDate = chequeDate
        _currency_Name = currency_Name
    End Sub
    Public Sub New(ByVal expense_ID As Int16, ByVal entry_Date As Date, ByVal Head_Type As String, ByVal item As String, _
                   ByVal amount As Double, ByVal amount_Out As Double, ByVal bill_No As String, ByVal bill_Date As Date, ByVal acc_sub_grp As String, _
                   ByVal cheque_No As String, ByVal bank_Name As String, _
                   ByVal currency_Code As Int16, ByVal currency_Name As String, ByVal exchangeRate As Double)
        _expense_ID = expense_ID
        _entry_Date = entry_Date
        _Head_Type = Head_Type
        _item = item
        _amount = amount
        _amount_out = amount_Out
        _bill_No = bill_No
        _bill_Date = bill_Date
        _acc_sub_grp = _acc_sub_grp
        _cheque_No = cheque_No
        _Bank_Name = bank_Name
        _currency_Code = currency_Code
        _currency_Name = currency_Name
        _exchangeRate = exchangeRate
    End Sub
End Class
