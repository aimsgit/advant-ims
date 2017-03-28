Imports Microsoft.VisualBasic

Public Class ICardE
    Private _studentcode As String
    Private _stdid As Int64
    Private _instituteid As Int64
    Private _coursename As String
    Private _receiptno As String
    Private _receiptdate As Date
    Private _batchno As Int64
    Private _amount As Int64
    Private _issuedmonth As String
    Private _branchid As Int64
    Private _courseid As Int64
    Private _deleteflag As Boolean
    Private _issued As Boolean
    'Private _startdate As Date
    'Private _hold As Boolean
    Private _id As Int64
    Public Property Studentcode() As String
        Get
            Return _studentcode
        End Get
        Set(ByVal value As String)
            _studentcode = value
        End Set
    End Property

    Public Property Instituteid() As Int64
        Get
            Return _instituteid
        End Get
        Set(ByVal value As Int64)
            _instituteid = value
        End Set
    End Property
    Public Property Stdid() As Int64
        Get
            Return _stdid
        End Get
        Set(ByVal value As Int64)
            _stdid = value
        End Set
    End Property
    Public Property coursename() As String
        Get
            Return _coursename
        End Get
        Set(ByVal value As String)
            _coursename = value
        End Set
    End Property
    Public Property Receiptno() As String
        Get
            Return _receiptno
        End Get
        Set(ByVal value As String)
            _receiptno = value
        End Set
    End Property
    Public Property Receiptdate() As Date
        Get
            Return _receiptdate
        End Get
        Set(ByVal value As Date)
            _receiptdate = value
        End Set
    End Property

    Public Property Batchno() As Int64
        Get
            Return _batchno
        End Get
        Set(ByVal value As Int64)
            _batchno = value
        End Set
    End Property
    Public Property amount() As Int64
        Get
            Return _amount
        End Get
        Set(ByVal value As Int64)
            _amount = value
        End Set
    End Property
    Public Property issuedmonth() As String
        Get
            Return _issuedmonth
        End Get
        Set(ByVal value As String)
            _issuedmonth = value
        End Set
    End Property
    Public Property Branchid() As Int64
        Get
            Return _branchid
        End Get
        Set(ByVal value As Int64)
            _branchid = value
        End Set
    End Property
    Public Property Courseid() As Int64
        Get
            Return _courseid
        End Get
        Set(ByVal value As Int64)
            _courseid = value
        End Set
    End Property
    Public Property Deleteflag() As String
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As String)
            _deleteflag = value
        End Set
    End Property
    'Public Property Hold() As Boolean
    '    Get
    '        Return _hold
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _hold = value
    '    End Set
    'End Property
    Public Property id() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
        End Set
    End Property
    'Public Property Startdate() As Date
    '    Get
    '        Return _startdate
    '    End Get
    '    Set(ByVal value As Date)
    '        _startdate = value
    '    End Set
    'End Property
    Public Property Issued() As String
        Get
            Return _issued
        End Get
        Set(ByVal value As String)
            _issued = value
        End Set
    End Property
End Class

