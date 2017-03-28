Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
'Namespace GlobalDataSetTableAdapters
'    Partial Public Class AssetDetailsTableAdapter
'        Dim fromid As Int32
'        Dim newid As Integer
'        Dim ref As Int16 = 3
'        Dim PropDublicate As AssetTransfer.AssetTransferP
'        Public Function InsertRecord(ByVal Prop As AssetTransfer.AssetTransferP) As Int64
'            fromid = Prop.AssetDet_Id
'            ref = Prop.Reference
'            PropDublicate = Prop
'            If ref = 0 Or ref = 1 Then
'                Dim assetdetails As New GlobalDataSet.AssetDetailsDataTable()
'                Dim newdetails As GlobalDataSet.AssetDetailsRow = assetdetails.NewAssetDetailsRow()
'                newdetails.Asset_Id = Prop.Asset_Id
'                newdetails.Branch_Id = Prop.Branch_Id
'                newdetails.Institute_Id = Prop.Institute_Id
'                newdetails.Supp_Id = Prop.Supp_Id
'                newdetails.ManuFacturer_Id = Prop.ManuFacturer_Id
'                newdetails.InvoiceNo = Prop.InvoiceNo
'                newdetails.PurchaseDate = Prop.PurchaseDate
'                newdetails.EntryDate = Prop.EntryDate
'                newdetails.TransferDate = Prop.TransferDate
'                newdetails.Quantity = Prop.Quantity
'                newdetails.Transfer_Flag = -1
'                newdetails.Price = Prop.Price
'                newdetails.Remarks = Prop.Remarks
'                newdetails.From1 = Prop.From1
'                newdetails.To1 = Prop.To1
'                'newdetails.Brand = Prop.Brand
'                newdetails.Model_Number = Prop.Model_Number
'                newdetails.Brought_by = Prop.Brought_by
'                newdetails.AssetType = Prop.AssetType
'                assetdetails.AddAssetDetailsRow(newdetails)
'                Me.Adapter.Update(assetdetails)
'                Return newid
'            ElseIf ref = 2 Then
'                Dim sender As Object
'                Dim e As System.Data.OleDb.OleDbRowUpdatedEventArgs
'                _adapter_rowupdated(sender, e)
'            End If
'        End Function

'        Public Sub _adapter_rowupdated(ByVal sender As Object, ByVal e As System.Data.OleDb.OleDbRowUpdatedEventArgs) Handles _adapter.RowUpdated
'            If ref <> 3 Then
'                ref = PropDublicate.Reference
'                Dim adapter_transfer As New GlobalDataSetTableAdapters.AssetTransferTableAdapter
'                Dim DALBkMaster As New GlobalDataSetTableAdapters.BookMasterTableAdapter
'                Dim DALAssetMaster As New GlobalDataSetTableAdapters.AssetDetailsTableAdapter
'                If ref = 1 Or ref = 0 Then
'                    Dim idcmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand("select @@identity", _connection)
'                    If e.StatementType = Data.StatementType.Insert Then
'                        newid = CInt(idcmd.ExecuteScalar())
'                    End If
'                    e.Row("assetdet_id") = newid
'                    e.Row.AcceptChanges()
'                    Dim assetdetails As GlobalDataSet.AssetDetailsDataTable = Me.GetDataById(newid)
'                    Dim detailrow As GlobalDataSet.AssetDetailsRow = assetdetails.Rows(0)
'                    adapter_transfer.InsertRecord(fromid, detailrow.AssetDet_Id, detailrow.Quantity, detailrow.TransferDate, detailrow.EntryDate)
'                    PropDublicate.Asset_Id = newid
'                End If
'                If ref = 1 Or ref = 2 Then
'                    DALBkMaster.InsertBKAsset(PropDublicate.BookName, PropDublicate.BookCode, PropDublicate.Author, PropDublicate.BookPublisher, PropDublicate.BookEditionNo, PropDublicate.Subject_ID, PropDublicate.Branch_Id, PropDublicate.Institute_Id, PropDublicate.Asset_Id, PropDublicate.BKQuantity, PropDublicate.Bkprice, PropDublicate.Book_ID)
'                    DALBkMaster.UpdateBKQty(PropDublicate.OBkqty, PropDublicate.Book_ID)
'                    DALAssetMaster.UpdateQueryAssetPrice(PropDublicate.ReducedAssetprice, PropDublicate.AssetDet_Id)
'                    If ref = 2 Then
'                        DALAssetMaster.UpdateQtyPrice(PropDublicate.Quantity, PropDublicate.Price, PropDublicate.Asset_Id)
'                        adapter_transfer.UpdateQty(PropDublicate.Quantity, PropDublicate.Asset_Id)
'                    End If
'                End If
'            Else
'                Dim idcmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand("select @@identity", _connection)
'                If e.StatementType = Data.StatementType.Insert Then
'                    newidd = CInt(idcmd.ExecuteScalar())
'                End If
'            End If
'        End Sub
'    End Class
'    Partial Public Class AssetTransferTableAdapter
'        Public Function InsertRecord(ByVal Source_Id As Int32, ByVal Target_Id As Int32, ByVal Quantity As Int32, ByVal TransferDate As Date, ByVal EntryDate As Date) As Integer
'            Dim assettransfer As New GlobalDataSet.AssetTransferDataTable()
'            Dim newtransfer As GlobalDataSet.AssetTransferRow = assettransfer.NewAssetTransferRow()
'            newtransfer.Source_Id = Source_Id
'            newtransfer.Target_Id = Target_Id
'            newtransfer.Quantity = Quantity
'            newtransfer.TransferDate = TransferDate
'            newtransfer.EntryDate = EntryDate
'            assettransfer.AddAssetTransferRow(newtransfer)
'            Me.Adapter.Update(assettransfer)
'        End Function
Public Class AssetTransferDB
    Dim fromid As Int32
    Dim newid As Integer
    Dim ref As Int16 = 3
    Dim PropDublicate As AssetTransfer.AssetTransferP
    Public Function GVDISPGRID_Asset(ByVal insid As Integer, ByVal branchid As Integer, ByVal assetid As Integer, ByVal assettype As Integer) As Data.DataTable
        Dim ds As New Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        If assettype <> 2 Then
            Dim arParms() As SqlParameter = New SqlParameter(3) {}
            arParms(0) = New SqlParameter("@insid", SqlDbType.Int)
            arParms(0).Value = insid

            arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
            arParms(1).Value = branchid

            arParms(2) = New SqlParameter("@assetid", SqlDbType.Int)
            arParms(2).Value = assetid

            arParms(3) = New SqlParameter("@assettype", SqlDbType.Int)
            arParms(3).Value = assettype

            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GVDISPGRID_Asset", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@insid", SqlDbType.Int)
            arParms(0).Value = insid

            arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
            arParms(1).Value = branchid

            arParms(2) = New SqlParameter("@assettype", SqlDbType.Int)
            arParms(2).Value = assettype

            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GVDISPGRID_BookAsset", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        Return ds.Tables(0)
    End Function
    Public Function GetAssetByid(ByVal id As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Char, 150)
        arParms(0).Value = id
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetByid", arParms)
        Return ds.Tables(0)
    End Function
    Public Function InsertRecord(ByVal Prop As AssetTransfer.AssetTransferP) As Integer
        Dim insertId As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@AssetDetails", SqlDbType.Int)
        arParms(0).Value = Prop.AssetDet_Id

        arParms(1) = New SqlParameter("@branch_Id", SqlDbType.Int)
        arParms(1).Value = Prop.Branch_Id

        arParms(2) = New SqlParameter("@institute_Id", SqlDbType.Int)
        arParms(2).Value = Prop.Institute_Id

        arParms(3) = New SqlParameter("@entry_Date", SqlDbType.DateTime)
        arParms(3).Value = Prop.EntryDate

        arParms(4) = New SqlParameter("@TransferDate", SqlDbType.DateTime)
        arParms(4).Value = Prop.TransferDate

        arParms(5) = New SqlParameter("@Quantity", SqlDbType.Float)
        arParms(5).Value = Prop.Quantity

        arParms(6) = New SqlParameter("@Price", SqlDbType.Float)
        arParms(6).Value = Prop.Price

        arParms(7) = New SqlParameter("@from1", SqlDbType.NVarChar)
        arParms(7).Value = Prop.From1

        arParms(8) = New SqlParameter("@to1", SqlDbType.VarChar)
        arParms(8).Value = Prop.To1

        arParms(9) = New SqlParameter("@Remarks", SqlDbType.VarChar)
        arParms(9).Value = Prop.Remarks

        arParms(10) = New SqlParameter("@Asset_Type", SqlDbType.Int)
        arParms(10).Value = Prop.AssetType

        Try
            insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertAssetTransfer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return insertId
    End Function
    Public Function BookDetails(ByVal Inst As Int64, ByVal Brch As Int64, ByVal AssetDetailId As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@institute_Id", SqlDbType.Int)
        arParms(0).Value = Inst

        arParms(1) = New SqlParameter("@branch_Id", SqlDbType.Int)
        arParms(1).Value = Brch

        arParms(2) = New SqlParameter("@assetid", SqlDbType.Char, 150)
        arParms(2).Value = AssetDetailId

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookAsset", arParms)
        Return ds.Tables(0)
    End Function
    Public Function InsertAssetDetailsBookTransfer(ByVal Prop As AssetTransfer.AssetTransferP) As Int64
        Dim insertId As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(14) {}

        arParms(0) = New SqlParameter("@AssetDetails", SqlDbType.Int)
        arParms(0).Value = Prop.AssetDet_Id

        arParms(1) = New SqlParameter("@branch_Id", SqlDbType.Int)
        arParms(1).Value = Prop.Branch_Id

        arParms(2) = New SqlParameter("@institute_Id", SqlDbType.Int)
        arParms(2).Value = Prop.Institute_Id

        arParms(3) = New SqlParameter("@entry_Date", SqlDbType.DateTime)
        arParms(3).Value = Prop.EntryDate

        arParms(4) = New SqlParameter("@TransferDate", SqlDbType.DateTime)
        arParms(4).Value = Prop.TransferDate

        arParms(5) = New SqlParameter("@Quantity", SqlDbType.Float)
        arParms(5).Value = Prop.Quantity

        arParms(6) = New SqlParameter("@Price", SqlDbType.Float)
        arParms(6).Value = Prop.Price

        arParms(7) = New SqlParameter("@from1", SqlDbType.NVarChar)
        arParms(7).Value = Prop.From1

        arParms(8) = New SqlParameter("@to1", SqlDbType.VarChar)
        arParms(8).Value = Prop.To1

        arParms(9) = New SqlParameter("@Remarks", SqlDbType.VarChar)
        arParms(9).Value = Prop.Remarks

        arParms(10) = New SqlParameter("@Asset_Type", SqlDbType.Int)
        arParms(10).Value = Prop.AssetType

        arParms(11) = New SqlParameter("@BOOK_QTY", SqlDbType.Int)
        arParms(11).Value = Prop.BKQuantity

        arParms(12) = New SqlParameter("@Book_Price", SqlDbType.Money)
        arParms(12).Value = Prop.Bkprice

        arParms(13) = New SqlParameter("@BOOK_ID", SqlDbType.Int)
        arParms(13).Value = Prop.Book_ID

        arParms(14) = New SqlParameter("@NewId", SqlDbType.Int)
        arParms(14).Direction = ParameterDirection.Output

        Try
            insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertAssetTransfer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return arParms(14).Value
    End Function
    Public Function InsertBookTransfer(ByVal Prop As AssetTransfer.AssetTransferP) As Int16
        Dim insertId As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@AssetDetails", SqlDbType.Int)
        arParms(0).Value = Prop.Branch_Id

        arParms(1) = New SqlParameter("@branch_Id", SqlDbType.Int)
        arParms(1).Value = Prop.Branch_Id

        arParms(2) = New SqlParameter("@institute_Id", SqlDbType.Int)
        arParms(2).Value = Prop.Institute_Id

        arParms(3) = New SqlParameter("@BOOK_QTY", SqlDbType.Int)
        arParms(3).Value = Prop.BKQuantity

        arParms(4) = New SqlParameter("@Book_Price", SqlDbType.Money)
        arParms(4).Value = Prop.Bkprice

        arParms(5) = New SqlParameter("@BOOK_ID", SqlDbType.Int)
        arParms(5).Value = Prop.Book_ID

        Try
            insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertAssetBookTrnsfer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return insertId
    End Function
    Public Function GetData_AssettransferDet(ByVal Asset_Id As Int64, ByVal Institute_ID As Int64, ByVal Branch_ID As Int64, ByVal AssetType As Int64) As Data.DataTable

        Dim ds As New Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        If AssetType <> 2 Then
            Dim arParms() As SqlParameter = New SqlParameter(3) {}
            arParms(0) = New SqlParameter("@Asset_Id", SqlDbType.Int)
            arParms(0).Value = Asset_Id

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = Institute_ID

            arParms(2) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(2).Value = Branch_ID

            arParms(3) = New SqlParameter("@AssetType", SqlDbType.Int)
            arParms(3).Value = AssetType

            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetdatabyAssettransferDetails", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(0).Value = Institute_ID

            arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(1).Value = Branch_ID

            arParms(2) = New SqlParameter("@AssetType", SqlDbType.Int)
            arParms(2).Value = AssetType

            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetdatabyAssettransferBookDetails", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

        Return ds.Tables(0)
    End Function
    Public Function UpdateAssettransferDetails(ByVal Branch_Id As Int64, ByVal Institute_Id As Int64, ByVal EntryDate As Date, ByVal Quantity As Int64, ByVal Price As Single, ByVal TransferDate As Date, ByVal Remarks As String, ByVal From1 As String, ByVal To1 As String, ByVal AssetDet_Id As Int64, ByVal AssetTr_Id As Int64) As Int16

        Dim insertId As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Branch_Id", SqlDbType.Int)
        arParms(0).Value = Branch_Id

        arParms(1) = New SqlParameter("@Institute_Id", SqlDbType.Int)
        arParms(1).Value = Institute_Id

        arParms(2) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        arParms(2).Value = EntryDate

        arParms(3) = New SqlParameter("@Quantity", SqlDbType.Int)
        arParms(3).Value = Quantity

        arParms(4) = New SqlParameter("@Price", SqlDbType.Money)
        arParms(4).Value = Price

        arParms(5) = New SqlParameter("@TransferDate", SqlDbType.DateTime)
        arParms(5).Value = TransferDate

        arParms(6) = New SqlParameter("@Remarks", SqlDbType.VarChar)
        arParms(6).Value = Remarks

        arParms(7) = New SqlParameter("@From1", SqlDbType.VarChar)
        arParms(7).Value = From1

        arParms(8) = New SqlParameter("@To1", SqlDbType.VarChar)
        arParms(8).Value = To1

        arParms(9) = New SqlParameter("@AssetDet_Id", SqlDbType.Int)
        arParms(9).Value = AssetDet_Id

        arParms(10) = New SqlParameter("@AssetTr_Id", SqlDbType.Int)
        arParms(10).Value = AssetTr_Id

        Try
            insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateAssettransferDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetDataByBookTransfer(ByVal Inst As Int64, ByVal Brch As Int64, ByVal Asset_Id As Int64) As Data.DataTable
        Dim ds As New Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Institute_Id", SqlDbType.Int)
        arParms(0).Value = Inst

        arParms(1) = New SqlParameter("@Branch_Id", SqlDbType.Int)
        arParms(1).Value = Brch

        arParms(2) = New SqlParameter("@AssetDetail_ID", SqlDbType.Int)
        arParms(2).Value = Asset_Id

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetDataByAssettransferBookDet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function UpdateBookasssettransfer(ByVal prop As AssetTransfer.AssetTransferP, ByVal ref As Int16) As Int16
        Dim insertId As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@Branch_Id", SqlDbType.Int)
        arParms(0).Value = prop.Branch_Id

        arParms(1) = New SqlParameter("@Institute_Id", SqlDbType.Int)
        arParms(1).Value = prop.Institute_Id

        arParms(2) = New SqlParameter("@TransferDate", SqlDbType.DateTime)
        arParms(2).Value = prop.TransferDate

        arParms(3) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        arParms(3).Value = prop.EntryDate

        arParms(4) = New SqlParameter("@Target_Id", SqlDbType.Int)
        arParms(4).Value = prop.Target_Id

        arParms(5) = New SqlParameter("@book_ID", SqlDbType.Int)
        arParms(5).Value = prop.Book_ID

        arParms(6) = New SqlParameter("@quantity", SqlDbType.Int)
        arParms(6).Value = prop.Quantity

        arParms(7) = New SqlParameter("@ref", SqlDbType.Int)
        arParms(7).Value = ref

        Try
            insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateAssetBookTransfer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Del_update(ByVal assetDet_id As Int64, ByVal type As Int16) As Int16
        Dim insertId As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Asset_detail_id", SqlDbType.Int)
        arParms(0).Value = assetDet_id

        arParms(1) = New SqlParameter("@AssetType", SqlDbType.Int)
        arParms(1).Value = type

        Try
            insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteAssetTransfer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Del_updatebook(ByVal book_id As Int64) As Int16
        Dim insertId As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms As SqlParameter = New SqlParameter()

        arParms = New SqlParameter("@BOOK_id", SqlDbType.Int)
        arParms.Value = book_id

        Try
            insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteAssetBookTransfer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetReport(ByVal instituteid As Int64, ByVal branchid As Int64, ByVal assettype As Int64, ByVal asset As Int64) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@instituteid", SqlDbType.Int)
        arParms(0).Value = instituteid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = branchid

        arParms(2) = New SqlParameter("@assettype", SqlDbType.Int)
        arParms(2).Value = assettype

        arParms(3) = New SqlParameter("@asset", SqlDbType.Int)
        arParms(3).Value = asset

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByAssettrReport", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function GetBKTrReport(ByVal instituteid As Int64, ByVal branchid As Int64, ByVal assettype As Int64, ByVal asset As Int64) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@instituteid", SqlDbType.Int)
        arParms(0).Value = instituteid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = branchid

        arParms(2) = New SqlParameter("@assettype", SqlDbType.Int)
        arParms(2).Value = assettype

        arParms(3) = New SqlParameter("@asset", SqlDbType.Int)
        arParms(3).Value = asset

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByBookTrReport", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function GetTrainingMtrlReport(ByVal instituteid As Int64, ByVal branchid As Int64, ByVal assettype As Int64, ByVal asset As Int64) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@instituteid", SqlDbType.Int)
        arParms(0).Value = instituteid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = branchid

        arParms(2) = New SqlParameter("@assettype", SqlDbType.Int)
        arParms(2).Value = assettype

        arParms(3) = New SqlParameter("@asset", SqlDbType.Int)
        arParms(3).Value = asset

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataTraingMtrlTrRpt", arParms)
        Return ds.Tables(0)

    End Function
End Class

