Imports Microsoft.VisualBasic

Public Class BookMaster
    Private _id As Int64
    Public Property Id() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
        End Set
    End Property
    Private _DeptId As Integer
    Public Property DeptId() As Integer
        Get
            Return _DeptId
        End Get
        Set(ByVal value As Integer)
            _DeptId = value
        End Set
    End Property
    Private _branchname As String
    Public Property branchname() As String
        Get
            Return _branchname
        End Get
        Set(ByVal value As String)
            _branchname = value
        End Set
    End Property
    Private _RackNo As String
    Public Property RackNo() As String
        Get
            Return _RackNo
        End Get
        Set(ByVal value As String)
            _RackNo = value
        End Set
    End Property
    Private _ShelfNo As String
    Public Property ShelfNo() As String
        Get
            Return _ShelfNo
        End Get
        Set(ByVal value As String)
            _ShelfNo = value
        End Set
    End Property
    Private _institutename As String
    Public Property institutename() As String
        Get
            Return _institutename
        End Get
        Set(ByVal value As String)
            _institutename = value
        End Set
    End Property
    Private _ISBN As String
    Public Property ISBN() As String
        Get
            Return _ISBN
        End Get
        Set(ByVal value As String)
            _ISBN = value
        End Set
    End Property
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _classno As String
    Public Property classno() As String
        Get
            Return _classno
        End Get
        Set(ByVal value As String)
            _classno = value
        End Set
    End Property
    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    Private _ReceiveDate As DateTime

    Public Property ReceiveDate() As DateTime

        Get
            Return _ReceiveDate
        End Get
        Set(ByVal value As DateTime)

            _ReceiveDate = value
        End Set
    End Property
    Private _author As String
    Public Property Author() As String
        Get
            Return _author
        End Get
        Set(ByVal value As String)
            _author = value
        End Set
    End Property
    Private _publisher As String
    Public Property Publisher() As String
        Get
            Return _publisher
        End Get
        Set(ByVal value As String)
            _publisher = value
        End Set
    End Property
    Private _edition As String
    Public Property Edition() As String
        Get
            Return _edition
        End Get
        Set(ByVal value As String)
            _edition = value
        End Set
    End Property
    Private _pages As Integer
    Public Property Pages() As Integer
        Get
            Return _pages
        End Get
        Set(ByVal value As Integer)
            _pages = value
        End Set
    End Property
    Private _IssueRef As String
    Public Property IssueRef() As String
        Get
            Return _IssueRef
        End Get
        Set(ByVal value As String)
            _IssueRef = value
        End Set
    End Property
    Private _subject As Integer
    Public Property Subject() As Integer
        Get
            Return _subject
        End Get
        Set(ByVal value As Integer)
            _subject = value
        End Set
    End Property
    Private _branch As Integer
    Public Property Branch() As Integer
        Get
            Return _branch
        End Get
        Set(ByVal value As Integer)
            _branch = value
        End Set
    End Property
    Private _institute As Integer
    Public Property Institute() As Integer
        Get
            Return _institute
        End Get
        Set(ByVal value As Integer)
            _institute = value
        End Set
    End Property
    Private _assetdet As Integer
    Public Property AssetDet() As Integer
        Get
            Return _assetdet
        End Get
        Set(ByVal value As Integer)
            _assetdet = value
        End Set
    End Property
    Private _quantity As Integer
    Public Property Quantity() As Integer
        Get
            Return _quantity
        End Get
        Set(ByVal value As Integer)
            _quantity = value
        End Set
    End Property
    Private _price As Integer
    Public Property Price() As Integer
        Get
            Return _price
        End Get
        Set(ByVal value As Integer)
            _price = value
        End Set
    End Property
    Private _transferid As Integer
    Public Property Transferid() As Integer
        Get
            Return _transferid
        End Get
        Set(ByVal value As Integer)
            _transferid = value
        End Set
    End Property
    Private _deleteflag As Integer
    Public Property DeleteFlag() As Integer
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Integer)
            _deleteflag = value
        End Set
    End Property
    Public Sub New()
        
    End Sub
    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal code As String, ByVal receivedate As DateTime, ByVal author As String, ByVal publisher As String, ByVal edition As String, ByVal pages As Integer, ByVal subject As Integer, ByVal branch As Integer, ByVal institute As Integer, ByVal assetdet As Integer, ByVal quantity As Integer, ByVal price As Integer, ByVal transferid As Integer)
        _id = id
        _name = name
        _code = code
        _ReceiveDate = receivedate
        _author = Author
        _publisher = publisher
        _edition = edition
        _pages = pages
        _subject = subject
        _branch = branch
        _institute = institute
        _assetdet = assetdet
        _quantity = quantity
        _price = price
        _transferid = transferid
    End Sub
    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal code As String, ByVal receivedate As DateTime, ByVal author As String, ByVal publisher As String, ByVal edition As String, ByVal pages As Integer, ByVal subject As Integer, ByVal branch As Integer, ByVal institute As Integer, ByVal quantity As Integer, ByVal price As Integer, ByVal transferid As Integer, ByVal branchname As String, ByVal institutename As String)
        _id = id
        _name = name
        _code = code
        _ReceiveDate = receivedate
        _author = author
        _publisher = publisher
        _edition = edition
        _pages = pages
        _subject = subject
        _branch = branch
        _institute = institute
        _quantity = quantity
        _price = price
        _transferid = transferid
        _branchname = branchname
        _institutename = institutename
    End Sub
End Class
