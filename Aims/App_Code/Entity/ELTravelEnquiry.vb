Imports Microsoft.VisualBasic
Public Class ELTravelEnquiry
    Private _Id As Long
    Public Property Id() As Long
        Get
            Return _Id
        End Get
        Set(ByVal value As Long)
            _Id = value
        End Set
    End Property
    Private _Triptype As String
    Public Property Triptype() As String
        Get
            Return _Triptype
        End Get
        Set(ByVal value As String)
            _Triptype = value
        End Set
    End Property
    Private _Enqdate As DateTime
    Public Property Enquiry_Date() As DateTime
        Get
            Return _Enqdate
        End Get
        Set(ByVal value As DateTime)
            _Enqdate = value
        End Set
    End Property
    Private _Enqno As String
    Public Property Enquiry_No() As String
        Get
            Return _Enqno
        End Get
        Set(ByVal value As String)
            _Enqno = value
        End Set
    End Property
    Private _namepassenger As String
    Public Property Passenger_Name() As String
        Get
            Return _namepassenger
        End Get
        Set(ByVal value As String)
            _namepassenger = value
        End Set
    End Property
    Private _Ref As String
    Public Property Referral() As String
        Get
            Return _Ref
        End Get
        Set(ByVal value As String)
            _Ref = value
        End Set
    End Property
    Private _Adults As Integer
    Public Property No_Of_Adults() As Integer
        Get
            Return _Adults
        End Get
        Set(ByVal value As Integer)
            _Adults = value
        End Set
    End Property
    Private _Chldrn As Integer
    Public Property No_Of_Children() As Integer
        Get
            Return _Chldrn
        End Get
        Set(ByVal value As Integer)
            _Chldrn = value
        End Set
    End Property
    Private _infants As Integer
    Public Property No_Of_Infants() As Integer
        Get
            Return _infants
        End Get
        Set(ByVal value As Integer)
            _infants = value
        End Set
    End Property
    Private _Leave As String

    Public Property Leavingfrom() As String
        Get
            Return _Leave
        End Get
        Set(ByVal value As String)
            _Leave = value
        End Set
    End Property
    Private _Depatdate As DateTime
    Public Property Departure_Date() As DateTime
        Get
            Return _Depatdate
        End Get
        Set(ByVal value As DateTime)
            _Depatdate = value
        End Set
    End Property
    Private _Going As String
    Public Property Goingto() As String
        Get
            Return _Going
        End Get
        Set(ByVal value As String)
            _Going = value
        End Set
    End Property
    Private _Return As DateTime
    Public Property Return_Date() As DateTime
        Get
            Return _Return
        End Get
        Set(ByVal value As DateTime)
            _Return = value
        End Set
    End Property
    Private _Class As String
    Public Property Travelclass() As String
        Get
            Return _Class
        End Get
        Set(ByVal value As String)
            _Class = value
        End Set
    End Property
    Private _Purvisit As String
    Public Property Purpose() As String
        Get
            Return _Purvisit
        End Get
        Set(ByVal value As String)
            _Purvisit = value
        End Set
    End Property

    Private _Typacc As String

    Public Property Accomodation_Type() As String
        Get
            Return _Typacc
        End Get
        Set(ByVal value As String)
            _Typacc = value
        End Set
    End Property
    Private _Contno As String
    Public Property Contact_Number() As String
        Get
            Return _Contno
        End Get
        Set(ByVal value As String)
            _Contno = value
        End Set
    End Property
    Private _Addrs As String
    Public Property Address() As String
        Get
            Return _Addrs
        End Get
        Set(ByVal value As String)
            _Addrs = value
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
    Private _Quote As String
    Public Property Quote() As String
        Get
            Return _Quote
        End Get
        Set(ByVal value As String)
            _Quote = value
        End Set
    End Property
    Private _Fllwup As String
    Public Property Follow_Up() As String
        Get
            Return _Fllwup
        End Get
        Set(ByVal value As String)
            _Fllwup = value
        End Set
    End Property
    Private _Closed As String
    Public Property Closed() As String
        Get
            Return _Closed
        End Get
        Set(ByVal value As String)
            _Closed = value
        End Set
    End Property
    Private _Remks As String
    Public Property Remarks() As String
        Get
            Return _Remks
        End Get
        Set(ByVal value As String)
            _Remks = value
        End Set
    End Property
    Private _Refid As Integer
    Public Property Ref_ID() As Integer
        Get
            Return _Refid
        End Get
        Set(ByVal value As Integer)
            _Refid = value
        End Set
    End Property

    Public Sub New()
    End Sub
End Class
