Imports Microsoft.VisualBasic

Public Class Mfg_ELSaleExecutive
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _SEName As String
    Public Property SEName() As String
        Get
            Return _SEName
        End Get
        Set(ByVal value As String)
            _SEName = value
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
    Private _Age As Integer
    Public Property Age() As Integer
        Get
            Return _Age
        End Get
        Set(ByVal value As Integer)
            _Age = value
        End Set
    End Property
    Public _DOJ As DateTime
    Public Property DOJ() As DateTime
        Get
            Return _DOJ
        End Get
        Set(ByVal value As DateTime)
            _DOJ = value
        End Set
    End Property
    Public _DOL As DateTime
    Public Property DOL() As DateTime
        Get
            Return _DOL
        End Get
        Set(ByVal value As DateTime)
            _DOL = value
        End Set
    End Property
    Private _Grade As String
    Public Property Grade() As String
        Get
            Return _Grade
        End Get
        Set(ByVal value As String)
            _Grade = value
        End Set
    End Property
    Private _TargetValue As Double
    Public Property TargetValue() As Double
        Get
            Return _TargetValue
        End Get
        Set(ByVal value As Double)
            _TargetValue = value
        End Set
    End Property
    Private _OpenBal As Double
    Public Property OpenBal() As Double
        Get
            Return _OpenBal
        End Get
        Set(ByVal value As Double)
            _OpenBal = value
        End Set
    End Property
    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Private _State As String
    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            _State = value
        End Set
    End Property
    Private _Country As String
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            _Country = value
        End Set
    End Property
    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Private _Contact As String
    Public Property Contact() As String
        Get
            Return _Contact
        End Get
        Set(ByVal value As String)
            _Contact = value
        End Set
    End Property
End Class
