Imports Microsoft.VisualBasic

Public Class FeePaymentDetails
    Private _eid As Int64
    Public Property ExpenxeId() As Int64
        Get
            Return _eid
        End Get
        Set(ByVal value As Int64)
            _eid = value
        End Set
    End Property
    Private _intallment_type As Int16
    Public Property Installment_Type() As Int16
        Get
            Return _intallment_type
        End Get
        Set(ByVal value As Int16)
            _intallment_type = value
        End Set
    End Property
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _instituteid As Long
    Public Property InstituteId() As Long
        Get
            Return _instituteid
        End Get
        Set(ByVal value As Long)
            _instituteid = value
        End Set
    End Property
    Private _branchid As Long
    Public Property BranchId() As Long
        Get
            Return _branchid
        End Get
        Set(ByVal value As Long)
            _branchid = value
        End Set
    End Property
    Private _courseid As Long
    Public Property CourseId() As Long
        Get
            Return _courseid
        End Get
        Set(ByVal value As Long)
            _courseid = value
        End Set
    End Property
    Private _courseplannerid As Long
    Public Property CoursePlannerId() As Long
        Get
            Return _courseplannerid
        End Get
        Set(ByVal value As Long)
            _courseplannerid = value
        End Set
    End Property
    Private _stdid As Long
    Public Property StdId() As Long
        Get
            Return _stdid
        End Get
        Set(ByVal value As Long)
            _stdid = value
        End Set
    End Property
    Private _bankid As Long
    Public Property BankId() As Long
        Get
            Return _bankid
        End Get
        Set(ByVal value As Long)
            _bankid = value
        End Set
    End Property
    Private _cbankid As Long
    Public Property CBankId() As Long
        Get
            Return _cbankid
        End Get
        Set(ByVal value As Long)
            _cbankid = value
        End Set
    End Property
    Private _feedate As Date
    Public Property FeeDate() As Date
        Get
            Return _feedate
        End Get
        Set(ByVal value As Date)
            _feedate = value
        End Set
    End Property
    Private _entrydate As Date
    Public Property EntryDate() As Date
        Get
            Return _entrydate
        End Get
        Set(ByVal value As Date)
            _entrydate = value
        End Set
    End Property
    Private _semid As Long
    Public Property SEMID() As Long
        Get
            Return _semid
        End Get
        Set(ByVal value As Long)
            _semid = value
        End Set
    End Property
    Private _chequedate As Date
    Public Property ChequeDate() As Date
        Get
            Return _chequedate
        End Get
        Set(ByVal value As Date)
            _chequedate = value
        End Set
    End Property
    'Private _paymentmethodid As Long
    'Public Property PaymentMethodId() As Long
    '    Get
    '        Return _paymentmethodid
    '    End Get
    '    Set(ByVal value As Long)
    '        _paymentmethodid = value
    '    End Set
    'End Property
    Private _chequeno As Long
    Public Property ChequeNo() As Long
        Get
            Return _chequeno
        End Get
        Set(ByVal value As Long)
            _chequeno = value
        End Set
    End Property
    Private _amount As Long
    Public Property Amount() As Long
        Get
            Return _amount
        End Get
        Set(ByVal value As Long)
            _amount = value
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
    Private _billno As String
    Public Property BillNo() As String
        Get
            Return _billno
        End Get
        Set(ByVal value As String)
            _billno = value
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
    Private _feestructure As Long
    Public Property FeeStructure() As Long
        Get
            Return _feestructure
        End Get
        Set(ByVal value As Long)
            _feestructure = value
        End Set
    End Property

    Public Sub New()
    End Sub
    Public Sub New(ByVal id As Long, ByVal instituteid As Long, ByVal branchid As Long, ByVal courseid As Long, ByVal courseplannerid As Long, ByVal stdid As Long, ByVal feedate As Date, ByVal entrydate As Date, ByVal PaymentMethodID As Long, ByVal chequeno As Long, ByVal amount As Long, ByVal remarks As String, ByVal feestructure As Long, ByVal FCfortheYear As String, ByVal SEMID As Long, ByVal BillNo As String)
        _id = id
        _instituteid = instituteid
        _branchid = branchid
        _courseid = courseid
        _courseplannerid = courseplannerid
        _stdid = stdid
        _feedate = feedate
        _entrydate = entrydate
        _methodId = PaymentMethodID
        _chequeno = chequeno
        _amount = amount
        _remarks = remarks
        _feestructure = feestructure
        _fcfortheyear = FCfortheYear
        _semid = SEMID
        _billno = BillNo
    End Sub
    'Sub New(ByVal id As Int64, ByVal name As String)
    '    Me._id = id
    '    Me._name = name
    'End Sub
    Sub New(ByVal PaymentMethodID As Int64, ByVal Payment_Method As String)
        Me._methodId = PaymentMethodID
        Me._method = Payment_Method
    End Sub
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Sub New(ByVal Name As String)
        _name = Name
    End Sub
    Private _method As String
    Public Property Payment_Method() As String
        Get
            Return _method
        End Get
        Set(ByVal value As String)
            _method = value
        End Set
    End Property
    Private _methodId As Long
    Public Property PaymentMethodID() As Long
        Get
            Return _methodId
        End Get
        Set(ByVal value As Long)
            _methodId = value
        End Set
    End Property
    Private _deleteflag As Int16

    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Private _fcfortheyear As String

    Public Property FCfortheYear() As String
        Get
            Return _fcfortheyear
        End Get
        Set(ByVal value As String)
            _fcfortheyear = value
        End Set
    End Property
End Class

