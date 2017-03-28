Imports Microsoft.VisualBasic
Public Class AssetDetails
    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Private _DesType As Integer
    Public Property DesType() As Integer
        Get
            Return _DesType
        End Get
        Set(ByVal value As Integer)
            _DesType = value
        End Set
    End Property
    Private _DepreciationYear As Integer
    Public Property DepreciationYear() As Integer
        Get
            Return _DepreciationYear
        End Get
        Set(ByVal value As Integer)
            _DepreciationYear = value
        End Set
    End Property
    Private _AssetDet_Id As Integer
    Public Property AssetDet_Id() As Integer
        Get
            Return _AssetDet_Id
        End Get
        Set(ByVal value As Integer)
            _AssetDet_Id = value
        End Set
    End Property
    Private _Invvalue As Integer
    Public Property Invvalue() As Integer
        Get
            Return _Invvalue
        End Get
        Set(ByVal value As Integer)
            _Invvalue = value
        End Set
    End Property
    Private _AssetName As String
    Public Property AssetName() As String
        Get
            Return _AssetName
        End Get
        Set(ByVal value As String)
            _AssetName = value
        End Set
    End Property
    Private _RegistrationNo As String
    Public Property RegistrationNo() As String
        Get
            Return _RegistrationNo
        End Get
        Set(ByVal value As String)
            _RegistrationNo = value
        End Set
    End Property
    Private _AssetType As Integer
    Public Property AssetType() As Integer
        Get
            Return _AssetType
        End Get
        Set(ByVal value As Integer)
            _AssetType = value
        End Set
    End Property
    Private _DepreciationType As Integer

    Public Property DepreciationType() As Integer
        Get
            Return _DepreciationType
        End Get
        Set(ByVal value As Integer)
            _DepreciationType = value
        End Set
    End Property
    Private _Bookvalueprice As Double
    Public Property Bookvalueprice() As Double
        Get
            Return _Bookvalueprice
        End Get
        Set(ByVal value As Double)
            _Bookvalueprice = value
        End Set
    End Property
    Private _AssetCode As String
    Public Property AssetCode() As String
        Get
            Return _AssetCode
        End Get
        Set(ByVal value As String)
            _AssetCode = value
        End Set
    End Property
    Private _supplier As Integer
    Public Property supplier() As Integer
        Get
            Return _supplier
        End Get
        Set(ByVal value As Integer)
            _supplier = value
        End Set
    End Property
    Private _Receivedby As Integer
    Public Property Receivedby() As Integer
        Get
            Return _Receivedby
        End Get
        Set(ByVal value As Integer)
            _Receivedby = value
        End Set
    End Property
    Private _Manufacturer As Integer
    Public Property Manufacturer() As Integer
        Get
            Return _Manufacturer
        End Get
        Set(ByVal value As Integer)
            _Manufacturer = value
        End Set
    End Property
    Private _Location As Integer
    Public Property Location() As Integer
        Get
            Return _Location
        End Get
        Set(ByVal value As Integer)
            _Location = value
        End Set
    End Property
    Private _Machineslno As String
    Public Property Machineslno() As String
        Get
            Return _Machineslno
        End Get
        Set(ByVal value As String)
            _Machineslno = value
        End Set
    End Property
    Private _Paymentmethod As Integer
    Public Property Paymentmethod() As Integer
        Get
            Return _Paymentmethod
        End Get
        Set(ByVal value As Integer)
            _Paymentmethod = value
        End Set
    End Property
    Private _Motorslno As String
    Public Property Motorslno() As String
        Get
            Return _Motorslno
        End Get
        Set(ByVal value As String)
            _Motorslno = value
        End Set
    End Property
    Private _purchasedate As Date
    Public Property purchasedate() As Date
        Get
            Return _purchasedate
        End Get
        Set(ByVal value As Date)
            _purchasedate = value
        End Set
    End Property
    Private _Registrationdate As Date
    Public Property Registrationdate() As Date
        Get
            Return _Registrationdate
        End Get
        Set(ByVal value As Date)
            _Registrationdate = value
        End Set
    End Property
    Private _PremiumPaidDate As Date
    Public Property PremiumPaidDate() As Date
        Get
            Return _PremiumPaidDate
        End Get
        Set(ByVal value As Date)
            _PremiumPaidDate = value
        End Set
    End Property
    Private _Modelno As String
    Public Property Modelno() As String
        Get
            Return _Modelno
        End Get
        Set(ByVal value As String)
            _Modelno = value
        End Set
    End Property
    Private _Billtype As String
    Public Property Billtype() As String
        Get
            Return _Billtype
        End Get
        Set(ByVal value As String)
            _Billtype = value
        End Set
    End Property
    Private _invoiceno As String
    Public Property invoiceno() As String
        Get
            Return _invoiceno
        End Get
        Set(ByVal value As String)
            _invoiceno = value
        End Set
    End Property
    Private _broughtby As String
    Public Property broughtby() As String
        Get
            Return _broughtby
        End Get
        Set(ByVal value As String)
            _broughtby = value
        End Set
    End Property
    Private _amountpaid As Double
    Public Property amountpaid() As Double
        Get
            Return _amountpaid
        End Get
        Set(ByVal value As Double)
            _amountpaid = value
        End Set
    End Property
    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Private _Quantity As Double
    Public Property Quantity() As Double
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Double)
            _Quantity = value
        End Set
    End Property
    Private _sentby As String
    Public Property sentby() As String
        Get
            Return _sentby
        End Get
        Set(ByVal value As String)
            _sentby = value
        End Set
    End Property
    Private _InsuredTo As String
    Public Property InsuredTo() As String
        Get
            Return _InsuredTo
        End Get
        Set(ByVal value As String)
            _InsuredTo = value
        End Set
    End Property
    Private _InsuredAmt As Double
    Public Property InsuredAmt() As Double
        Get
            Return _InsuredAmt
        End Get
        Set(ByVal value As Double)
            _InsuredAmt = value
        End Set
    End Property
    Private _PremiumAmt As Double
    Public Property PremiumAmt() As Double
        Get
            Return _PremiumAmt
        End Get
        Set(ByVal value As Double)
            _PremiumAmt = value
        End Set
    End Property
    Private _DueDate As Date
    Public Property DueDate() As Date
        Get
            Return _DueDate
        End Get
        Set(ByVal value As Date)
            _DueDate = value
        End Set
    End Property
    Private _Insuranceamtpaid As Double
    Public Property Insuranceamtpaid() As Double
        Get
            Return _Insuranceamtpaid
        End Get
        Set(ByVal value As Double)
            _Insuranceamtpaid = value
        End Set
    End Property
    Private _Guaranty As String
    Public Property Guaranty() As String
        Get
            Return _Guaranty
        End Get
        Set(ByVal value As String)
            _Guaranty = value
        End Set
    End Property
    Private _Warranty As String
    Public Property Warranty() As String
        Get
            Return _Warranty
        End Get
        Set(ByVal value As String)
            _Warranty = value
        End Set
    End Property
    Private _DType As Integer
    Public Property DType() As Integer
        Get
            Return _DType
        End Get
        Set(ByVal value As Integer)
            _DType = value
        End Set
    End Property
    Private _Guarantyp As Integer
    Public Property Guarantyp() As Integer
        Get
            Return _Guarantyp
        End Get
        Set(ByVal value As Integer)
            _Guarantyp = value
        End Set
    End Property
    Private _Warrantyp As Integer
    Public Property Warrantyp() As Integer
        Get
            Return _Warrantyp
        End Get
        Set(ByVal value As Integer)
            _Warrantyp = value
        End Set
    End Property
    Private _AMC_To As String
    Public Property AMC_To() As String
        Get
            Return _AMC_To
        End Get
        Set(ByVal value As String)
            _AMC_To = value
        End Set
    End Property
    Private _AMC_SDate As DateTime
    Public Property AMC_SDate() As DateTime
        Get
            Return _AMC_SDate
        End Get
        Set(ByVal value As DateTime)
            _AMC_SDate = value
        End Set
    End Property
    Private _AMC_EDate As DateTime
    Public Property AMC_EDate() As DateTime
        Get
            Return _AMC_EDate
        End Get
        Set(ByVal value As DateTime)
            _AMC_EDate = value
        End Set
    End Property
    Private _AMC_Amount As String
    Public Property AMC_Amount() As String
        Get
            Return _AMC_Amount
        End Get
        Set(ByVal value As String)
            _AMC_Amount = value
        End Set
    End Property
    Private _APhoto As String
    Public Property APhoto() As String
        Get
            Return _APhoto
        End Get
        Set(ByVal value As String)
            _APhoto = value
        End Set
    End Property
    Public Sub New()
    End Sub
    'Public Sub New(ByVal AssetDet_Id As Long, ByVal AssetName As Long, ByVal assettype As Long, ByVal DepreciationType As Long, ByVal Bookvalueprice As Long, ByVal AssetCode As String, ByVal supplier As String, ByVal Receivedby As Date, ByVal Manufacturer As Date, ByVal location As Int32, ByVal Machineslno As Double, ByVal Paymentmethod As Long, ByVal Motorslno As String, ByVal purchasedate As String, ByVal Modelno As String, ByVal billtype As String, ByVal invoiceno As String, ByVal broughtby As Integer, ByVal amountpaid As Long, ByVal Description As String, ByVal Quantity As Integer, ByVal sentby As String, ByVal InsuredTo As String, ByVal InsuredAmt As String, ByVal PremiumAmt As String, ByVal DueDate As Single, ByVal Insuranceamtpaid As Single)
    '    _AssetDet_Id = AssetDet_Id
    '    _AssetName = AssetName
    '    _AssetType = assettype
    '    _DepreciationType = DepreciationType
    '    _Bookvalueprice = Bookvalueprice
    '    _AssetCode = AssetCode
    '    _supplier = supplier
    '    _Receivedby = Receivedby
    '    _Manufacturer = Manufacturer
    '    _Location = location
    '    _Machineslno = Machineslno
    '    _Paymentmethod = Paymentmethod
    '    _Motorslno = Motorslno
    '    _purchasedate = purchasedate
    '    _Modelno = Modelno
    '    _Billtype = billtype
    '    _invoiceno = invoiceno
    '    _broughtby = broughtby
    '    _amountpaid = amountpaid
    '    _Description = Description
    '    _Quantity = Quantity
    '    _sentby = sentby
    '    _InsuredTo = InsuredTo
    '    _InsuredAmt = InsuredAmt
    '    _PremiumAmt = PremiumAmt
    '    _DueDate = DueDate
    '    _Insuranceamtpaid = Insuranceamtpaid

    'End Sub
    Private _invoicedate As DateTime
    Public Property invoicedate() As DateTime
        Get
            Return _invoicedate
        End Get
        Set(ByVal value As DateTime)
            _invoicedate = value
        End Set
    End Property
    Private _Grnno As String
    Public Property Grnno() As String
        Get
            Return _Grnno
        End Get
        Set(ByVal value As String)
            _Grnno = value
        End Set
    End Property
    Private _Mrnno As String
    Public Property Mrnno() As String
        Get
            Return _Mrnno
        End Get
        Set(ByVal value As String)
            _Mrnno = value
        End Set
    End Property
    Private _Assetstatus As Integer
    Public Property Assetstatus() As Integer
        Get
            Return _Assetstatus
        End Get
        Set(ByVal value As Integer)
            _Assetstatus = value
        End Set
    End Property
    Private _Po As String
    Public Property Po() As String
        Get
            Return _Po
        End Get
        Set(ByVal value As String)
            _Po = value
        End Set
    End Property
End Class
