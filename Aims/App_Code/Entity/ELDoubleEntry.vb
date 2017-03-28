Imports Microsoft.VisualBasic

Public Class ELDoubleEntry
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _id1 As Integer
    Public Property id1() As Integer
        Get
            Return _id1
        End Get
        Set(ByVal value As Integer)
            _id1 = value
        End Set
    End Property
    Private _AccountGroup As Integer
    Public Property AccountGroup() As Integer
        Get
            Return _AccountGroup
        End Get
        Set(ByVal value As Integer)
            _AccountGroup = value
        End Set
    End Property
    Private _Account As Integer
    Public Property Account() As Integer
        Get
            Return _Account
        End Get
        Set(ByVal value As Integer)
            _Account = value
        End Set
    End Property
    Private _Item As String
    Public Property Item() As String
        Get
            Return _Item
        End Get
        Set(ByVal value As String)
            _Item = value
        End Set
    End Property
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
    Private _Amount As Double
    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
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
End Class
