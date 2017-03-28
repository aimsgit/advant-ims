Imports Microsoft.VisualBasic
Imports System.io
Public Class LetterPad
    Private _refid As Long
    Public Property Ref_ID() As Long
        Get
            Return _refid
        End Get
        Set(ByVal value As Long)
            _refid = value
        End Set
    End Property
    Private _Ref_ID_Auto As Long
    Public Property Ref_ID_Auto() As Long
        Get
            Return _Ref_ID_Auto
        End Get
        Set(ByVal value As Long)
            _Ref_ID_Auto = value
        End Set
    End Property
    Private _refno As String
    Public Property Ref_No() As String
        Get
            Return _refno
        End Get
        Set(ByVal value As String)
            _refno = value
        End Set
    End Property
    Private _From As String
    Public Property From() As String
        Get
            Return _From
        End Get
        Set(ByVal value As String)
            _From = value
        End Set
    End Property
    Private _Salutation As String
    Public Property Salutation() As String
        Get
            Return _Salutation
        End Get
        Set(ByVal value As String)
            _Salutation = value
        End Set
    End Property
    Private _Signature As String
    Public Property Signature() As String
        Get
            Return _Signature
        End Get
        Set(ByVal value As String)
            _Signature = value
        End Set
    End Property
    Private _refperson As String
    Public Property Ref_Person() As String
        Get
            Return _refperson
        End Get
        Set(ByVal value As String)
            _refperson = value
        End Set
    End Property
    Private _refdate As Date
    Public Property Ref_Date() As Date
        Get
            Return _refdate
        End Get
        Set(ByVal value As Date)
            _refdate = value
        End Set
    End Property
    Private _subject As String
    Public Property Subject() As String
        Get
            Return _subject
        End Get
        Set(ByVal value As String)
            _subject = value
        End Set
    End Property
    Private _contentLP As String
    Public Property ContentLP() As String
        Get
            Return _contentLP
        End Get
        Set(ByVal value As String)
            _contentLP = value
        End Set
    End Property

    Public Sub New()
    End Sub
    Public Sub New(ByVal rid As Long, ByVal refno As String, ByVal refperson As String, ByVal refdate As Date, ByVal subject As String, ByVal contentLP As String)
        _refid = rid
        _refno = refno
        _refperson = refperson
        _refdate = refdate
        _subject = Subject
        _contentLP = ContentLP
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
