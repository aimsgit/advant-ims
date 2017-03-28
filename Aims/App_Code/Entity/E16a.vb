Imports Microsoft.VisualBasic

Public Class E16a
    Private _ID As Int32
    Private _Emp_name As String
    Private _empId As Int64
    Private _Formid As Int64
    Private _For_the_period As String
    Private _Nature_of_payment As String
    Private _Duration As String
    Private _Taxable_amt As Int64
    Private _deduction_date As Date
    Private _TDS As Int64
    Private _Surcharges As Int64
    Private _Education_cess As Int64
    Private _Tax_amt As Int64
    Private _Payment_details As String
    Private _BSR As String
    Private _Payment_date As Date
    Private _Payment_identification_no As String
    Public Property ID() As Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As Int32)
            _ID = value
        End Set
    End Property
    Public Property Emp_name() As String
        Get
            Return _Emp_name
        End Get
        Set(ByVal value As String)
            _Emp_name = value
        End Set
    End Property
    Public Property Formid() As Int64
        Get
            Return _Formid
        End Get
        Set(ByVal value As Int64)
            _Formid = value
        End Set
    End Property
    Public Property Empid() As Int64
        Get
            Return _empId
        End Get
        Set(ByVal value As Int64)
            _empId = value
        End Set
    End Property
    Public Property For_the_period() As String
        Get
            Return _For_the_period
        End Get
        Set(ByVal value As String)
            _For_the_period = value
        End Set
    End Property
    Public Property Nature_of_payment() As String
        Get
            Return _Nature_of_payment
        End Get
        Set(ByVal value As String)
            _Nature_of_payment = value
        End Set
    End Property
    Public Property Duration() As String
        Get
            Return _Duration
        End Get
        Set(ByVal value As String)
            _Duration = value
        End Set
    End Property
    Public Property Taxable_amt() As Int64
        Get
            Return _Taxable_amt
        End Get
        Set(ByVal value As Int64)
            _Taxable_amt = value
        End Set
    End Property
    Public Property deduction_date() As Date
        Get
            Return _deduction_date
        End Get
        Set(ByVal value As Date)
            _deduction_date = value
        End Set
    End Property
    Public Property TDS() As Int64
        Get
            Return _TDS
        End Get
        Set(ByVal value As Int64)
            _TDS = value
        End Set
    End Property
    Public Property Surcharges() As Int64
        Get
            Return _Surcharges
        End Get
        Set(ByVal value As Int64)
            _Surcharges = value
        End Set
    End Property
    Public Property Education_cess() As Int64
        Get
            Return _Education_cess
        End Get
        Set(ByVal value As Int64)
            _Education_cess = value
        End Set
    End Property
    Public Property Tax_amt() As Int64
        Get
            Return _Tax_amt
        End Get
        Set(ByVal value As Int64)
            _Tax_amt = value
        End Set
    End Property
    Public Property Payment_details() As String
        Get
            Return _Payment_details
        End Get
        Set(ByVal value As String)
            _Payment_details = value
        End Set
    End Property
    Public Property BSR() As String
        Get
            Return _BSR
        End Get
        Set(ByVal value As String)
            _BSR = value
        End Set
    End Property
    Public Property Payment_date() As Date
        Get
            Return _Payment_date
        End Get
        Set(ByVal value As Date)
            _Payment_date = value
        End Set
    End Property
    Public Property Payment_identification_no() As String
        Get
            Return _Payment_identification_no
        End Get
        Set(ByVal value As String)
            _Payment_identification_no = value
        End Set
    End Property
End Class
