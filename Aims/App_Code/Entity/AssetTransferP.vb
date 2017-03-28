Imports Microsoft.VisualBasic
Namespace AssetTransfer
    Public Class AssetTransferP
        Private _AssetDet_Id As Int64
        Public Property AssetDet_Id() As Int64
            Get
                Return _AssetDet_Id
            End Get
            Set(ByVal value As Int64)
                _AssetDet_Id = value
            End Set
        End Property
        Private _Asset_Id As Int64
        Public Property Asset_Id() As Int64
            Get
                Return _Asset_Id
            End Get
            Set(ByVal value As Int64)
                _Asset_Id = value
            End Set
        End Property
        Private _Branch_Id As Int64
        Public Property Branch_Id() As Int64
            Get
                Return _Branch_Id
            End Get
            Set(ByVal value As Int64)
                _Branch_Id = value
            End Set
        End Property
        Private _Institute_Id As Int64
        Public Property Institute_Id() As Int64
            Get
                Return _Institute_Id
            End Get
            Set(ByVal value As Int64)
                _Institute_Id = value
            End Set
        End Property
        Private _Supp_Id As Int64
        Public Property Supp_Id() As Int64
            Get
                Return _Supp_Id
            End Get
            Set(ByVal value As Int64)
                _Supp_Id = value
            End Set
        End Property
        Private _ManuFacturer_Id As Int64
        Public Property ManuFacturer_Id() As Int64
            Get
                Return _ManuFacturer_Id
            End Get
            Set(ByVal value As Int64)
                _ManuFacturer_Id = value
            End Set
        End Property
        Private _InvoiceNo As String
        Public Property InvoiceNo() As String
            Get
                Return _InvoiceNo
            End Get
            Set(ByVal value As String)
                If value = "&nbsp;" Then
                    _InvoiceNo = Nothing
                Else
                    _InvoiceNo = value
                End If
            End Set
        End Property
        Private _PurchaseDate As Date
        Public Property PurchaseDate() As Date
            Get
                Return _PurchaseDate
            End Get
            Set(ByVal value As Date)
                _PurchaseDate = value
            End Set
        End Property
        Private _EntryDate As Date
        Public Property EntryDate() As Date
            Get
                Return _EntryDate
            End Get
            Set(ByVal value As Date)
                _EntryDate = value
            End Set
        End Property
        Private _TransferDate As Date
        Public Property TransferDate() As Date
            Get
                Return _TransferDate
            End Get
            Set(ByVal value As Date)
                _TransferDate = value
            End Set
        End Property
        Private _Quantity As Int32
        Public Property Quantity() As Int32
            Get
                Return _Quantity
            End Get
            Set(ByVal value As Int32)
                _Quantity = value
            End Set
        End Property
        Private _Transfer_Flag As Int16
        Public Property Transfer_Flag() As Int16
            Get
                Return _Transfer_Flag
            End Get
            Set(ByVal value As Int16)
                _Transfer_Flag = value
            End Set
        End Property
        Private _Price As Int64
        Public Property Price() As String
            Get
                Return _Price
            End Get
            Set(ByVal value As String)
                _Price = value
            End Set
        End Property
        Private _Brand As String
        Public Property Brand() As String
            Get
                Return _Brand
            End Get
            Set(ByVal value As String)
                If value = "&nbsp;" Then
                    _Brand = Nothing
                Else
                    _Brand = value
                End If
            End Set
        End Property
        Private _Model_Number As String
        Public Property Model_Number() As String
            Get
                Return _Model_Number
            End Get
            Set(ByVal value As String)
                If value = "&nbsp;" Then
                    _Model_Number = Nothing
                Else
                    _Model_Number = value
                End If
            End Set
        End Property
        Private _Brought_by As String
        Public Property Brought_by() As String
            Get
                Return _Brought_by
            End Get
            Set(ByVal value As String)
                If value = "&nbsp;" Then
                    _Brought_by = Nothing
                Else
                    _Brought_by = value
                End If
            End Set
        End Property
        Private _remarks As String
        Public Property Remarks() As String
            Get
                Return _remarks
            End Get
            Set(ByVal value As String)
                If value = "&nbsp;" Then
                    _remarks = Nothing
                Else
                    _remarks = value
                End If
            End Set
        End Property
        Private _from1 As String
        Public Property From1() As String
            Get
                Return _from1
            End Get
            Set(ByVal value As String)
                If value = "&nbsp;" Then
                    _from1 = Nothing
                Else
                    _from1 = value
                End If
            End Set
        End Property
        Private _To1 As String
        Public Property To1() As String
            Get
                Return _to1
            End Get
            Set(ByVal value As String)
                If value = "&nbsp;" Then
                    _to1 = Nothing
                Else
                    _to1 = value
                End If
            End Set
        End Property
        Private _Del_Flag As Int16
        Public Property Del_Flag() As Int16
            Get
                Return _Del_Flag
            End Get
            Set(ByVal value As Int16)
                _Del_Flag = value
            End Set
        End Property
        Private _AssetType As Int16
        Public Property AssetType() As Int16
            Get
                Return _AssetType
            End Get
            Set(ByVal value As Int16)
                _AssetType = value
            End Set
        End Property
        Private _Trasfer_Id As Int64
        Public Property Trasfer_Id() As Int64
            Get
                Return _Trasfer_Id
            End Get
            Set(ByVal value As Int64)
                _Trasfer_Id = value
            End Set
        End Property
        Private _Source_Id As Int64
        Public Property Source_Id() As Int64
            Get
                Return _Source_Id
            End Get
            Set(ByVal value As Int64)
                _Source_Id = value
            End Set
        End Property
        Private _Target_Id As Int64
        Public Property Target_Id() As Int64
            Get
                Return _Target_Id
            End Get
            Set(ByVal value As Int64)
                _Target_Id = value
            End Set
        End Property
        Private _Book_ID As Int64
        Public Property Book_ID() As Int64
            Get
                Return _Book_ID
            End Get
            Set(ByVal value As Int64)
                _Book_ID = value
            End Set
        End Property
        Private _BookName As String
        Public Property BookName() As String
            Get
                Return _BookName
            End Get
            Set(ByVal value As String)
                _BookName = value
            End Set
        End Property
        Private _BookCode As String
        Public Property BookCode() As String
            Get
                Return _BookCode
            End Get
            Set(ByVal value As String)
                _BookCode = value
            End Set
        End Property
        Private _Author As String
        Public Property Author() As String
            Get
                Return _Author
            End Get
            Set(ByVal value As String)
                _Author = value
            End Set
        End Property
        Private _BookPublisher As String
        Public Property BookPublisher() As String
            Get
                Return _BookPublisher
            End Get
            Set(ByVal value As String)
                _BookPublisher = value
            End Set
        End Property
        Private _BookEditionNo As String
        Public Property BookEditionNo() As String
            Get
                Return _BookEditionNo
            End Get
            Set(ByVal value As String)
                _BookEditionNo = value
            End Set
        End Property
        Private _BKPrice As Int32
        Public Property Bkprice() As Int32
            Get
                Return _BKPrice
            End Get
            Set(ByVal value As Int32)
                _BKPrice = value
            End Set
        End Property
        Private _Subject_ID As Int32
        Public Property Subject_ID() As Int32
            Get
                Return _Subject_ID
            End Get
            Set(ByVal value As Int32)
                _Subject_ID = value
            End Set
        End Property
        Private _BKQuantity As Int64
        Public Property BKQuantity() As Int64
            Get
                Return _BKQuantity
            End Get
            Set(ByVal value As Int64)
                _BKQuantity = value
            End Set
        End Property
        Private _OBqty As Int64
        Public Property OBkqty() As Int64
            Get
                Return _OBqty
            End Get
            Set(ByVal value As Int64)
                _OBqty = value
            End Set
        End Property
        Private _reference As Int16
        Public Property Reference() As Int16
            Get
                Return _reference
            End Get
            Set(ByVal value As Int16)
                _reference = value
            End Set
        End Property
        Private _reducedAssetPrice As Int32
        Public Property ReducedAssetprice() As Int32
            Get
                Return _reducedAssetPrice
            End Get
            Set(ByVal value As Int32)
                _reducedAssetPrice = value
            End Set
        End Property
        Private _BKTransferid As Int64
        Public Property BKTransferID() As Int64
            Get
                Return _BKTransferid
            End Get
            Set(ByVal value As Int64)
                _BKTransferid = value
            End Set
        End Property
        Public Sub New()
        End Sub
        'Public Sub New(ByVal BkId As Int64, ByVal Bkname As String, ByVal BkCode As String, ByVal BkAuthor As String, ByVal BkPublish As String, ByVal BkEdNo As String, ByVal BkSubId As Int64, ByVal BkPrice1 As Int64, ByVal BkQty As Int32, ByVal OBkQty1 As Int64, ByVal AssetId As Int64, ByVal BranchId As Int64, ByVal InsId As Int64, ByVal SuppId As Int64, ByVal ManFactureId As Int64, ByVal PINo As String, ByVal Pdate As Date, ByVal EntryDate1 As Date, ByVal TDate As Date, ByVal Qty As Int64, ByVal Price1 As Int64, ByVal Brand1 As String, ByVal MNo As String, ByVal BrougthBy As String, ByVal AssetType1 As Int16, ByVal AssetDetasilId As Int64, ByVal ref As Int16, ByVal hfreduPri As Int32, ByVal remarks1 As String, ByVal from11 As String, ByVal to11 As String)
        Public Sub New(ByVal BkId As Int64, ByVal BkPrice1 As Int64, ByVal BkQty As Int32, ByVal OBkQty1 As Int64, ByVal BranchId As Int64, ByVal InsId As Int64, ByVal EntryDate1 As Date, ByVal TDate As Date, ByVal Qty As Int64, ByVal Price1 As Int64, ByVal AssetType1 As Int16, ByVal AssetDetasilId As Int64, ByVal ref As Int16, ByVal hfreduPri As Int32, ByVal remarks1 As String, ByVal from11 As String, ByVal to11 As String)
            Book_ID = BkId
            Bkprice = BkPrice1
            BKQuantity = BkQty
            OBkqty = OBkQty1
            Branch_Id = BranchId
            Institute_Id = InsId
            EntryDate = EntryDate1
            TransferDate = TDate
            Quantity = Qty
            Price = Price1
            Remarks = remarks1
            From1 = from11
            To1 = to11
            AssetType = AssetType1
            AssetDet_Id = AssetDetasilId
            Reference = ref
            ReducedAssetprice = hfreduPri
        End Sub
        Public Sub New(ByVal BkId As Int64, ByVal BkPrice1 As Int32, ByVal BkQty As Int32, ByVal OBkQty1 As Int32, ByVal Branch As Int32, ByVal Institute As Int64, ByVal hfNewAssetDetId As Int64, ByVal txtQuantity As Int32, ByVal txtPrice As Int32, ByVal hffromdetail As Int64, ByVal ref As Int16, ByVal redprice As Int32)
            Book_ID = BkId
            Bkprice = BkPrice1
            BKQuantity = BkQty
            OBkqty = OBkQty1
            Branch_Id = Branch
            Institute_Id = Institute
            Asset_Id = hfNewAssetDetId
            Quantity = txtQuantity
            Price = txtPrice
            AssetDet_Id = hffromdetail
            Reference = ref
            ReducedAssetprice = redprice
        End Sub
        'Public Sub New(ByVal AssetId As Int64, ByVal BranchId As Int64, ByVal InsId As Int64, ByVal SuppId As Int64, ByVal ManFactureId As Int64, ByVal PINo As String, ByVal Pdate As Date, ByVal EntryDate1 As Date, ByVal TDate As Date, ByVal Qty As Int64, ByVal Price1 As Int64, ByVal Brand1 As String, ByVal MNo As String, ByVal BrougthBy As String, ByVal AssetType1 As Int16, ByVal AssetDetasilId As Int64, ByVal ref As Int16, ByVal remarks1 As String, ByVal from11 As String, ByVal to11 As String)
        Public Sub New(ByVal BranchId As Int64, ByVal InsId As Int64, ByVal EntryDate1 As Date, ByVal TDate As Date, ByVal Qty As Int64, ByVal Price1 As Int64, ByVal AssetType1 As Int16, ByVal AssetDetasilId As Int64, ByVal ref As Int16, ByVal remarks1 As String, ByVal from11 As String, ByVal to11 As String)
            Branch_Id = BranchId
            Institute_Id = InsId
            EntryDate = EntryDate1
            TransferDate = TDate
            Quantity = Qty
            Price = Price1
            Remarks = remarks1
            From1 = from11
            To1 = to11
            AssetType = AssetType1
            AssetDet_Id = AssetDetasilId
            Reference = ref
        End Sub
    End Class
End Namespace
