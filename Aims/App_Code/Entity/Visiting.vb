Imports Microsoft.VisualBasic
Imports System.io
Public Class Visiting
    Private _vid As Long
    Public Property VId() As Long
        Get
            Return _vid
        End Get
        Set(ByVal value As Long)
            _vid = value
        End Set
    End Property
    Private _institute As Long
    Public Property Institute() As Long
        Get
            Return _institute
        End Get
        Set(ByVal value As Long)
            _institute = value
        End Set
    End Property
    Private _branch As Long
    Public Property Branch() As Long
        Get
            Return _branch
        End Get
        Set(ByVal value As Long)
            _branch = value
        End Set
    End Property
    Private _visitingdate As Date
    Public Property VisitingDate() As Date
        Get
            Return _visitingdate
        End Get
        Set(ByVal value As Date)
            _visitingdate = value
        End Set
    End Property
    Private _empid As Int16
    Public Property Empid() As Int16
        Get
            Return _empid
        End Get
        Set(ByVal value As Int16)
            _empid = value
        End Set
    End Property
    Private _fromtime As DateTime
    Public Property Fromtime() As DateTime
        Get
            Return _fromtime
        End Get
        Set(ByVal value As DateTime)
            _fromtime = value
        End Set
    End Property
    Private _totime As DateTime
    Public Property Totime() As DateTime
        Get
            Return _totime
        End Get
        Set(ByVal value As DateTime)
            _totime = value
        End Set
    End Property
    Private _contactdetails As String
    Public Property Contactdetails() As String
        Get
            Return _contactdetails
        End Get
        Set(ByVal value As String)
            _contactdetails = value
        End Set
    End Property
    Private _discussion As String
    Public Property Discussion() As String
        Get
            Return _discussion
        End Get
        Set(ByVal value As String)
            _discussion = value
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
    Public Sub New(ByVal vid As Long, ByVal institute As Long, ByVal branch As Long, ByVal visitingdate As Date, ByVal empid As Int16, ByVal fromtime As DateTime, ByVal totime As DateTime, ByVal Contactdetails As String, ByVal discussion As String, ByVal remarks As String)
        _vid = vid
        _institute = institute
        _branch = branch
        _visitingdate = visitingdate
        _empid = empid
        _fromtime = fromtime
        _totime = totime
        _contactdetails = Contactdetails
        _discussion = discussion
        _remarks = remarks
    End Sub
    Public Sub New()
    End Sub
    Private _deleteflag As Int16

    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
End Class
