Imports Microsoft.VisualBasic

Public Class ClientCotract
    Public _PKID As Integer
    Public Property PKID() As Integer
        Get
            Return _PKID
        End Get
        Set(ByVal value As Integer)
            _PKID = value
        End Set
    End Property
    Public _PKIDAuto As Integer
    Public Property PKIDAuto() As Integer
        Get
            Return _PKIDAuto
        End Get
        Set(ByVal value As Integer)
            _PKIDAuto = value
        End Set
    End Property
    Public _SetupChrge As Double
    Public Property SetupChrge() As Double
        Get
            Return _SetupChrge
        End Get
        Set(ByVal value As Double)
            _SetupChrge = value
        End Set
    End Property

    Public _SmsChrge As Double
    Public Property SmsChrge() As Double
        Get
            Return _SmsChrge
        End Get
        Set(ByVal value As Double)
            _SmsChrge = value
        End Set
    End Property

    Public _EmailChrge As Double
    Public Property EmailChrge() As Double
        Get
            Return _EmailChrge
        End Get
        Set(ByVal value As Double)
            _EmailChrge = value
        End Set
    End Property


    Public _MyCo_Code As String
    Public Property MyCo_Code() As String
        Get
            Return _MyCo_Code
        End Get
        Set(ByVal value As String)
            _MyCo_Code = value
        End Set
    End Property

    Public _BillType As String
    Public Property BillType() As String
        Get
            Return _BillType
        End Get
        Set(ByVal value As String)
            _BillType = value
        End Set
    End Property

    Public _PerStudent As Double
    Public Property PerStudent() As Double
        Get
            Return _PerStudent
        End Get
        Set(ByVal value As Double)
            _PerStudent = value
        End Set
    End Property


    Public _Fixed As Double
    Public Property Fixed() As Double
        Get
            Return _Fixed
        End Get
        Set(ByVal value As Double)
            _Fixed = value
        End Set
    End Property

    Public _StartDate As DateTime
    Public Property StartDate() As DateTime
        Get
            Return _StartDate
        End Get
        Set(ByVal value As DateTime)
            _StartDate = value
        End Set
    End Property

    Public _ExpiryDate As DateTime
    Public Property ExpiryDate() As DateTime
        Get
            Return _ExpiryDate
        End Get
        Set(ByVal value As DateTime)
            _ExpiryDate = value
        End Set
    End Property

    Public _LockStatus As String
    Public Property LockStatus() As String
        Get
            Return _LockStatus
        End Get
        Set(ByVal value As String)
            _LockStatus = value
        End Set
    End Property
    Public _Branch_Code As String
    Public Property Branch_Code() As String
        Get
            Return _Branch_Code
        End Get
        Set(ByVal value As String)
            _Branch_Code = value
        End Set
    End Property
    Public _OtherCharges As Double
    Public Property OtherCharges() As Double
        Get
            Return _OtherCharges
        End Get
        Set(ByVal value As Double)
            _OtherCharges = value
        End Set
    End Property

    Public _Advance As Double
    Public Property Advance() As Double
        Get
            Return _Advance
        End Get
        Set(ByVal value As Double)
            _Advance = value
        End Set
    End Property
    Public _Adjusted As Double
    Public Property Adjusted() As Double
        Get
            Return _Adjusted
        End Get
        Set(ByVal value As Double)
            _Adjusted = value
        End Set
    End Property
    Public _Balance As Double
    Public Property Balance() As Double
        Get
            Return _Balance
        End Get
        Set(ByVal value As Double)
            _Balance = value
        End Set
    End Property
    Public _Discount As Double
    Public Property Discount() As Double
        Get
            Return _Discount
        End Get
        Set(ByVal value As Double)
            _Discount = value
        End Set
    End Property
    Public _OpenStatus As Integer
    Public Property OpenStatus() As Integer
        Get
            Return _OpenStatus
        End Get
        Set(ByVal value As Integer)
            _OpenStatus = value
        End Set
    End Property
    Public _StdCount As Integer
    Public Property StdCount() As Integer
        Get
            Return _StdCount
        End Get
        Set(ByVal value As Integer)
            _StdCount = value
        End Set
    End Property
    Public _EmailCount As Integer
    Public Property EmailCount() As Integer
        Get
            Return _EmailCount
        End Get
        Set(ByVal value As Integer)
            _EmailCount = value
        End Set
    End Property
    Public _SmsCount As Integer
    Public Property SmsCount() As Integer
        Get
            Return _SmsCount
        End Get
        Set(ByVal value As Integer)
            _SmsCount = value
        End Set
    End Property
    Public _SetUpFlag As String
    Public Property SetUpFlag() As String
        Get
            Return _SetUpFlag
        End Get
        Set(ByVal value As String)
            _SetUpFlag = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class
