Imports Microsoft.VisualBasic

Public Class Asset
    Private _Asset_ID As Integer
    Private _name As String
    Private _code As String
    Private _remarks As String
    Private _ccr As String
    Private _cr As String
    'Private _assettype As Int32
    Private _depid As Int32
    Private _deleteflag As Int16
    Private _issuedto As String
    Private _issuedate As Date
    Private _returndate As Date

    Public Property IssueDate() As Date
        Get
            Return _issuedate
        End Get
        Set(ByVal value As Date)
            _issuedate = value
        End Set
    End Property
    Public Property ReturnDate() As Date
        Get
            Return _returndate
        End Get
        Set(ByVal value As Date)
            _returndate = value
        End Set
    End Property
    Public Property Asset_ID() As Integer
        Get
            Return _Asset_ID
        End Get
        Set(ByVal value As Integer)
            _Asset_ID = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Public Property ComodityCRate() As String
        Get
            Return _ccr

        End Get
        Set(ByVal value As String)
            _ccr = value
        End Set
    End Property
    Public Property ComodityRate() As String
        Get
            Return _cr
        End Get
        Set(ByVal value As String)
            _cr = value
        End Set
    End Property
    'Public Property AssetType() As Int32
    '    Get
    '        Return _assettype
    '    End Get
    '    Set(ByVal value As Int32)
    '        _assettype = value
    '    End Set
    'End Property
    Public Property depid() As Int32
        Get
            Return _depid
        End Get
        Set(ByVal value As Int32)
            _depid = value
        End Set
    End Property
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Public Property IssuedTo() As String
        Get
            Return _issuedto
        End Get
        Set(ByVal value As String)
            _issuedto = value
        End Set
    End Property
    Public Sub New(ByVal id As Long, ByVal name As String, ByVal code As String, ByVal remarks As String, ByVal assettype As String, ByVal depid As Integer)
        _Asset_ID = Asset_ID
        _name = name
        _code = code
        _remarks = remarks
        '_assettype = assettype
        _depid = depid
    End Sub
    Public Sub New()
    End Sub
End Class
