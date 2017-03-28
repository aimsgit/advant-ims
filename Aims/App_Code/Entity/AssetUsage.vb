Imports Microsoft.VisualBasic
Namespace AssetUsage
    Public Class AssetUsage
        Private _aseet_Usage_id As Long
        Public Property Asset_Usage_id() As Long
            Get
                Return _aseet_Usage_id
            End Get
            Set(ByVal value As Long)
                _aseet_Usage_id = value
            End Set
        End Property
        Private _id As Long
        Public Property Id() As Long
            Get
                Return _id
            End Get
            Set(ByVal value As Long)
                _id = value
            End Set
        End Property
        Private _branch As Int32
        Public Property Branch() As Int32
            Get
                Return _branch
            End Get
            Set(ByVal value As Int32)
                _branch = value
            End Set
        End Property
        Private _institute As Int32
        Public Property Institute() As Int32
            Get
                Return _institute
            End Get
            Set(ByVal value As Int32)
                _institute = value
            End Set
        End Property
        Private _assetdet As Int32
        Public Property AssetDet() As Int32
            Get
                Return _assetdet
            End Get
            Set(ByVal value As Int32)
                _assetdet = value
            End Set
        End Property
        Private _assetid As Int32
        Public Property AssetId() As Int32
            Get
                Return _assetid
            End Get
            Set(ByVal value As Int32)
                _assetid = value
            End Set
        End Property
        Private _usedqty As Int32
        Public Property UsedQty() As Int32
            Get
                Return _usedqty
            End Get
            Set(ByVal value As Int32)
                _usedqty = value
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
        Private _usagedate As Date
        Public Property UsageDate() As Date
            Get
                Return _usagedate
            End Get
            Set(ByVal value As Date)
                _usagedate = value
            End Set
        End Property

        Public Sub New()
        End Sub
        Public Sub New(ByVal id As Long, ByVal branch As Int32, ByVal institute As Int32, ByVal assetdet As Int32, ByVal assetid As Int32, ByVal usedqty As Int32, ByVal remarks As String, ByVal usagedate As Date)
            _id = id
            _branch = branch
            _institute = institute
            _assetdet = assetdet
            _assetid = assetid
            _usedqty = usedqty
            _remarks = remarks
            _usagedate = usagedate
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
        Private _course As Int32
        Public Property Course() As Int32
            Get
                Return _course
            End Get
            Set(ByVal value As Int32)
                _course = value
            End Set
        End Property
        Private _batch As Int32
        Public Property Batch() As Int32
            Get
                Return _batch
            End Get
            Set(ByVal value As Int32)
                _batch = value
            End Set
        End Property
    End Class
End Namespace

