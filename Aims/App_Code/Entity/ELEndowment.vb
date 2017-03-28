Imports Microsoft.VisualBasic

Public Class ELEndowment
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _SponsorID As Integer
    Public Property SponsorID() As Integer
        Get
            Return _SponsorID
        End Get
        Set(ByVal value As Integer)
            _SponsorID = value
        End Set
    End Property
    Private _RcvdDate As Date
    Public Property RcvdDate() As Date
        Get
            Return _RcvdDate
        End Get
        Set(ByVal value As Date)
            _RcvdDate = value
        End Set
    End Property
    Private _Donor_ID As String
    Public Property Donor_ID() As String
        Get
            Return _Donor_ID
        End Get
        Set(ByVal value As String)
            _Donor_ID = value
        End Set
    End Property
    Private _ChqNo As String
    Public Property ChqNo() As String
        Get
            Return _ChqNo
        End Get
        Set(ByVal value As String)
            _ChqNo = value
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
    Private _Bank As Integer
    Public Property Bank() As Integer
        Get
            Return _Bank
        End Get
        Set(ByVal value As Integer)
            _Bank = value
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


    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class
