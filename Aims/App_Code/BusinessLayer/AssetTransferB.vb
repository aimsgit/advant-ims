Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Namespace AssetTransfer
    Public Class AssetTransferB
        'Dim DALAD As New GlobalDataSetTableAdapters.AssetDetailsTableAdapter
        'Dim DALAT As New GlobalDataSetTableAdapters.AssetTransferTableAdapter
        'Dim DALBK As New GlobalDataSetTableAdapters.BookMasterTableAdapter
        Dim DAL As New AssetTransferDB
        Dim Prop As New AssetTransferP
        Dim dt As Data.DataTable
        'Public Function AssetDetailsTransfer(ByVal Prop As AssetTransferP) As Int64
        '    Return DALAD.InsertRecord(Prop)
        'End Function
        Public Function BookDetails(ByVal Inst As Int64, ByVal Brch As Int64, ByVal AssetDetailId As Int64) As Data.DataTable
            Return DAL.BookDetails(Inst, Brch, AssetDetailId)
        End Function
        'Public Function Recover(ByVal BookId As Int64, ByVal OBKID As Int64, ByVal Quantity As Int64, ByVal OriginalBookQty As Int64, ByVal BookPrice As Double, ByVal AssetDetail_ID As Int64, ByVal OriginalAssetID As Int64, ByVal AssetQty As Int64, ByVal AssetPrice As Double, ByVal OriginalAssetPrice As Double)
        '    OriginalBookQty = OriginalBookQty - Quantity
        '    BookPrice = BookPrice * Quantity
        '    AssetPrice = AssetPrice + BookPrice
        '    OriginalAssetPrice = OriginalAssetPrice - BookPrice
        '    AssetQty = AssetQty + Quantity
        '    DALBK.UpdateRecover(BookId)
        '    DALBK.UpdateSingleBKQty(OriginalBookQty, OBKID)
        '    DALAD.UpdateQueryBKQtyPrice(AssetQty, AssetPrice, AssetDetail_ID)
        '    DALAD.UpdateQueryAssetPrice(OriginalAssetPrice, OriginalAssetID)
        '    Return DALAT.UpdateBKTrQty(AssetQty, AssetDetail_ID)
        'End Function
        'Public Function RecoverMain(ByVal TargetId As Int64, ByVal SourceId As Int64, ByVal SourcePrice As Double)
        '    DALAD.UpdateRecover(TargetId)
        '    DALAD.UpdateQueryAssetPrice(SourcePrice, SourceId)
        '    DALAT.UpdateRecover(TargetId)
        '    DALBK.UpdateRecoverMain(TargetId)
        '    dt = DALBK.GetDataByNegativeQty(TargetId)
        '    Dim TQty, OID As Int64
        '    For Each dr As Data.DataRow In dt.Rows
        '        TQty = CInt(dr.Item("TQty"))
        '        OID = CInt(dr.Item("TID"))
        '        DALBK.UpdateSingleBKQty(TQty, OID)
        '    Next
        '    Return 0
        'End Function
        'Public Function AssetTransferReport() As Data.DataTable
        '    Dim DAl As New GlobalDataSetTableAdapters.Qry_AssetTransferTableAdapter
        '    Return DAl.GetDataByAssettrReport
        'End Function       
        Public Function AssetTransferReport(ByVal instituteid As Int64, ByVal branchid As Int64, ByVal assettype As Int64, ByVal asset As Int64) As Data.DataTable
            Return AssetTransferDB.GetReport(instituteid, branchid, assettype, asset)
        End Function
        Public Function TrainingMtrlTransferReport(ByVal instituteid As Int64, ByVal branchid As Int64, ByVal assettype As Int64, ByVal asset As Int64) As Data.DataTable
            Return AssetTransferDB.GetTrainingMtrlReport(instituteid, branchid, assettype, asset)
        End Function
        'Public Function SelfDetails() As Data.DataTable
        '    Dim DAl As New GlobalDataSetTableAdapters.SelfDetailsTableAdapter
        '    Return DAl.GetData
        'End Function
        'Public Function AssetBookTransferReport() As Data.DataTable
        '    Dim DAl As New GlobalDataSetTableAdapters.Qry_AssetBookTransferTableAdapter
        '    Return DAl.GetDataByBookTrReport
        'End Function
        Public Function AssetBookTransferReport(ByVal instituteid As Int64, ByVal branchid As Int64, ByVal assettype As Int64, ByVal asset As Int64) As Data.DataTable
            Return AssetTransferDB.GetBKTrReport(instituteid, branchid, assettype, asset)
        End Function
        Public Function GVDISPGRID_Asset(ByVal Institute_Id As Integer, ByVal Branch_Id As Integer, ByVal Asset_Id As Integer, ByVal AssetType As Integer) As Data.DataTable
            Return DAL.GVDISPGRID_Asset(Institute_Id, Branch_Id, Asset_Id, assettype)
        End Function
        Public Function GetAssetbyID(ByVal id As Long) As Data.DataTable
            Return DAL.GetAssetByid(id)
        End Function
        Public Function InsertRecord(ByVal Prop As AssetTransfer.AssetTransferP) As Int64
            Return DAL.InsertRecord(Prop)
        End Function
        Public Function InsertAssetDetailsBookTransfer(ByVal Prop As AssetTransfer.AssetTransferP) As Int64
            Return DAL.InsertAssetDetailsBookTransfer(Prop)
        End Function
        Public Function InsertBookTransfer(ByVal Prop As AssetTransfer.AssetTransferP) As Int16
            Return DAL.InsertBookTransfer(Prop)
        End Function
        Public Function Get_AssettransferDet(ByVal Asset_Id As Int64, ByVal Institute_ID As Int64, ByVal Branch_ID As Int64, ByVal AssetType As Int64) As Data.DataTable
            Return DAL.GetData_AssettransferDet(Asset_Id, Institute_ID, Branch_ID, AssetType)
        End Function
        Public Function UpdateAssettransferDetails(ByVal Branch_Id As Int64, ByVal Institute_Id As Int64, ByVal EntryDate As Date, ByVal Quantity As Int64, ByVal Price As Single, ByVal TransferDate As Date, ByVal Remarks As String, ByVal From1 As String, ByVal To1 As String, ByVal AssetDet_Id As Int64, ByVal AssetTr_Id As Int64) As Int16
            Return DAL.UpdateAssettransferDetails(Branch_Id, Institute_Id, EntryDate, Quantity, Price, TransferDate, Remarks, From1, To1, AssetDet_Id, AssetTr_Id)
        End Function
        Public Function AssetTransferEdit(ByVal Inst As Int64, ByVal Brch As Int64, ByVal AssetDetaislId As Long) As Data.DataTable
            Return DAL.GetDataByBookTransfer(Inst, Brch, AssetDetaislId)
        End Function
        Public Function AssetBookQtyEdit(ByVal Prop As AssetTransferP, ByVal ref As Int16)
            Return DAL.UpdateBookasssettransfer(Prop, ref)
        End Function
        Public Function Del_update(ByVal assetDet_id As Int64, ByVal type As Int16) As Int16
            Return DAL.Del_update(assetDet_id, type)
        End Function
        Public Function Del_Updatebook(ByVal book_id As Int64) As Int16
            Return DAL.Del_updatebook(book_id)
        End Function
    End Class
End Namespace
