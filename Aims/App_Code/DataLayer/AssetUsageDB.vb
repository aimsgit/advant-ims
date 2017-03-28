Imports System.Data
Imports System.Data.SqlClient
Imports AssetUsage
Namespace GlobalDataSetTableAdapters
    Partial Public Class AssetUsageTableAdapter
        Dim ID As Int64
        Public Function AssetUsageInsert(ByVal Prop As AssetUsage.AssetUsage) As Int64
            'Dim AssetusgTb As New GlobalDataSet.AssetUsageDataTable()
            'Dim AssetusgRow As GlobalDataSet.AssetUsageRow = AssetusgTb.NewAssetUsageRow()
            'AssetusgRow.Institute_Id = Prop.Institute
            'AssetusgRow.Branch_Id = Prop.Branch
            'AssetusgRow.Asset_Det_Id = Prop.AssetDet
            'AssetusgRow.Asset_Id = Prop.AssetId
            'AssetusgRow.UsedQuantity = Prop.UsedQty
            'AssetusgRow.Remarks = Prop.Remarks
            'AssetusgRow.UsageDate = Prop.UsageDate
            'AssetusgTb.AddAssetUsageRow(AssetusgRow)
            'Me.Adapter.Update(AssetusgTb)
            'Return ID
            Dim ds As New Data.DataSet
            Dim insertId As Integer
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            ds.Clear()
            Dim arParms() As SqlParameter = New SqlParameter(8) {}
            arParms(0) = New SqlParameter("@assetid", SqlDbType.Int)
            arParms(0).Value = Prop.AssetId

            arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
            arParms(1).Value = Prop.Branch

            arParms(2) = New SqlParameter("@insid", SqlDbType.Int)
            arParms(2).Value = Prop.Institute

            arParms(3) = New SqlParameter("@assetdet", SqlDbType.Int)
            arParms(3).Value = Prop.AssetDet

            arParms(4) = New SqlParameter("@usedqty", SqlDbType.Int)
            arParms(4).Value = Prop.UsedQty

            arParms(5) = New SqlParameter("@remarks", SqlDbType.NVarChar)
            arParms(5).Value = Prop.Remarks

            arParms(6) = New SqlParameter("@useddate", SqlDbType.DateTime)
            arParms(6).Value = Prop.UsageDate

            arParms(7) = New SqlParameter("@Courseid", SqlDbType.Int)
            arParms(7).Value = Prop.Course

            arParms(8) = New SqlParameter("@batchid", SqlDbType.Int)
            arParms(8).Value = Prop.Batch

            
            Try 'To insert in the asset detail table and for fetching the insert id. 
                insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_INSERT_ASSET_USAGE", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return insertId
        End Function
        '    Public Sub _adapter_rowupdated(ByVal sender As Object, ByVal e As System.Data.OleDb.OleDbRowUpdatedEventArgs) Handles _adapter.RowUpdated
        '        Dim idcmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand("select @@identity", _connection)
        '        If e.StatementType = Data.StatementType.Insert Then
        '            ID = CInt(idcmd.ExecuteScalar())
        '        End If
        '        e.Row("Asset_Usage_Id") = ID
        '        e.Row.AcceptChanges()
        '    End Sub
    End Class
End Namespace
Public Class AssetUsageDB
    Dim Str As String
    Dim Da As New OleDb.OleDbDataAdapter
    Dim Cmd As New OleDb.OleDbCommand
    Public Function Update(ByVal Prop As AssetUsage.AssetUsage) As Integer
        'Dim dt As New Data.DataTable
        Dim ds As New Data.DataSet
        Dim insertId As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@assetid", SqlDbType.Int)
        arParms(0).Value = Prop.AssetId

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = Prop.Branch

        arParms(2) = New SqlParameter("@insid", SqlDbType.Int)
        arParms(2).Value = Prop.Institute


        arParms(3) = New SqlParameter("@assetdet", SqlDbType.Int)
        arParms(3).Value = Prop.AssetDet

        arParms(4) = New SqlParameter("@usedqty", SqlDbType.Int)
        arParms(4).Value = Prop.UsedQty

        arParms(5) = New SqlParameter("@remarks", SqlDbType.NVarChar, 50)
        arParms(5).Value = Prop.Remarks

        arParms(6) = New SqlParameter("@useddate", SqlDbType.DateTime)
        arParms(6).Value = Prop.UsageDate

        arParms(7) = New SqlParameter("@assetusageid", SqlDbType.Int)
        arParms(7).Value = Prop.Asset_Usage_id

        arParms(8) = New SqlParameter("@Courseid", SqlDbType.Int)
        arParms(8).Value = Prop.Course

        arParms(9) = New SqlParameter("@batchid", SqlDbType.Int)
        arParms(9).Value = Prop.Batch

        Try
            insertId = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Update_ASSET_USAGE", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return insertId

        'Dim DbCommand As Data.IDbCommand = New Data.OleDb.OleDbCommand
        'Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Dim DbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(ConnectionString)
        'Str = "Update AssetUsage set Branch_Id=@branch,Institute_Id=@institute,Asset_Det_Id=@AssetDet,Asset_Id=@AssetId,UsedQuantity=@UsedQty,Remarks=@Remarks,UsageDate=@UsageDate WHERE Asset_Usage_Id=@Asset_Usage_id"

        'Dim dbParam_branch As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_branch.ParameterName = "@branch"
        'dbParam_branch.Value = Prop.Branch
        'dbParam_branch.DbType = System.Data.DbType.Int64
        'DbCommand.Parameters.Add(dbParam_branch)

        'Dim dbParam_institute As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_institute.ParameterName = "@institute"
        'dbParam_institute.Value = Prop.Institute
        'dbParam_institute.DbType = System.Data.DbType.Int64
        'DbCommand.Parameters.Add(dbParam_institute)

        'Dim dbParam_Asset_Det_Id As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_Asset_Det_Id.ParameterName = "@AssetDet"
        'dbParam_Asset_Det_Id.Value = Prop.AssetDet
        'dbParam_Asset_Det_Id.DbType = System.Data.DbType.Int64
        'DbCommand.Parameters.Add(dbParam_Asset_Det_Id)

        'Dim dbParam_Asset_Id As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_Asset_Id.ParameterName = "@AssetId"
        'dbParam_Asset_Id.Value = Prop.AssetId
        'dbParam_Asset_Id.DbType = System.Data.DbType.Int64
        'DbCommand.Parameters.Add(dbParam_Asset_Id)

        'Dim dbParam_UsedQuantity As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_UsedQuantity.ParameterName = "@UsedQty"
        'dbParam_UsedQuantity.Value = Prop.UsedQty
        'dbParam_UsedQuantity.DbType = System.Data.DbType.Int64
        'DbCommand.Parameters.Add(dbParam_UsedQuantity)

        'Dim dbParam_Remarks As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_Remarks.ParameterName = "@Remarks"
        'dbParam_Remarks.Value = Prop.Remarks
        'dbParam_Remarks.DbType = System.Data.DbType.String
        'DbCommand.Parameters.Add(dbParam_Remarks)

        'Dim dbParam_UsageDate As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_UsageDate.ParameterName = "@UsageDate"
        'dbParam_UsageDate.Value = Prop.UsageDate
        'dbParam_UsageDate.DbType = System.Data.DbType.Date
        'DbCommand.Parameters.Add(dbParam_UsageDate)

        'Dim dbParam_Asset_Usage_id As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_Asset_Usage_id.ParameterName = "@Asset_Usage_id"
        'dbParam_Asset_Usage_id.Value = Prop.Asset_Usage_id
        'dbParam_Asset_Usage_id.DbType = System.Data.DbType.Int64
        'DbCommand.Parameters.Add(dbParam_Asset_Usage_id)

        'DbCommand.CommandText = Str
        'DbCommand.Connection = DbConnection
        'DbConnection.Open()
        'DbCommand.ExecuteNonQuery()
        'DbConnection.Close()
        'Return dt
    End Function
    Public Function UpdateDelFlag(ByVal AUID As Integer) As Integer
        'Dim dt As New Data.DataTable
        Dim ds As New Data.DataSet
        Dim rowAffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@assetid", SqlDbType.Int)
        arParms.Value = AUID
        Try
            rowAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Update_Del_Flag", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowAffected
    End Function
    Public Function GetDetails(ByVal AssetUsageid As Long, ByVal institute As Int64, ByVal branch As Int64, ByVal courseid As Integer, ByVal batchid As Integer) As Data.DataTable
        'Dim dt As New Data.DataTable
        Dim ds As New Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParmsId As SqlParameter = New SqlParameter
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        If AssetUsageid <> 0 Then
            arParmsId = New SqlParameter("@assetid", SqlDbType.Int)
            arParmsId.Value = AssetUsageid
        ElseIf AssetUsageid = 0 Then

            arParms(0) = New SqlParameter("@insid", SqlDbType.Int)
            arParms(0).Value = institute

            arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
            arParms(1).Value = branch

            arParms(2) = New SqlParameter("@courseid", SqlDbType.Int)
            arParms(2).Value = courseid

            arParms(3) = New SqlParameter("@batchid", SqlDbType.Int)
            arParms(3).Value = batchid

        End If
        Try
            If AssetUsageid = 0 Then
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AssetUsageGrid", arParms)
            ElseIf (AssetUsageid <> 0) Then
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ASSETUSAGE_by_ID", arParmsId)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
        'Dim dt As New Data.DataTable
        'Dim DbCommand As Data.IDbCommand = New Data.OleDb.OleDbCommand
        'Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Dim DbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(ConnectionString)

        'If AssetUsageid = 0 Then
        '    Str = "SELECT AssetUsage.Asset_Usage_Id, AssetUsage.Branch_Id, AssetUsage.Institute_Id, AssetUsage.Asset_Det_Id, AssetUsage.Asset_Id, AssetUsage.UsedQuantity,AssetUsage.Remarks,AssetUsage.UsageDate FROM(AssetUsage)WHERE (((AssetUsage.Del_flag)=0) AND ((AssetUsage.Institute_Id)=@institute) AND ((AssetUsage.Branch_Id)=@branch)))"
        'ElseIf (AssetUsageid <> 0) Then
        '    Str = "SELECT AssetUsage.Asset_Usage_Id, AssetUsage.Branch_Id, AssetUsage.Institute_Id, AssetUsage.Asset_Det_Id, AssetUsage.Asset_Id, AssetUsage.UsedQuantity,AssetUsage.Remarks,,AssetUsage.UsageDate AssetUsage.Del_flag FROM(AssetUsage)WHERE (((AssetUsage.Asset_Usage_Id)=@Id) AND ((AssetUsage.Del_flag)=0))"
        '    'Else
        '    '    Str = "SELECT AssetUsage.Asset_Usage_Id, AssetUsage.Branch_Id, AssetUsage.Institute_Id, AssetUsage.Asset_Det_Id, AssetUsage.Asset_Id, AssetUsage.UsedQuantity,AssetUsage.Remarks,,AssetUsage.UsageDate FROM(AssetUsage)WHERE (((AssetUsage.Del_flag)=0))"
        'End If
        'DbCommand.CommandText = Str
        'DbCommand.Connection = DbConnection
        'If Not (AssetUsageid <> 0) Then
        '    Dim dbParam_id As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        '    dbParam_id.ParameterName = "@Id"
        '    dbParam_id.Value = AssetUsageid
        '    dbParam_id.DbType = System.Data.DbType.Int64
        '    DbCommand.Parameters.Add(dbParam_id)
        'ElseIf (AssetUsageid = 0) Then
        '    Dim dbParam_institute As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        '    dbParam_institute.ParameterName = "@institute"
        '    dbParam_institute.Value = institute
        '    dbParam_institute.DbType = System.Data.DbType.Int64
        '    DbCommand.Parameters.Add(dbParam_institute)

        '    Dim dbParam_branch As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        '    dbParam_branch.ParameterName = "@branch"
        '    dbParam_branch.Value = branch
        '    dbParam_branch.DbType = System.Data.DbType.Int64
        '    DbCommand.Parameters.Add(dbParam_branch)
        'End If
        'DbConnection.Open()
        'Da = New OleDb.OleDbDataAdapter(DbCommand)
        'Da.Fill(dt)
        'DbConnection.Close()
        'Return dt
    End Function
    Public Function FillQty(ByVal AssetUsageid As Integer) As Data.DataTable
        'Dim dt As New Data.DataTable
        Dim ds As New Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@assetid", SqlDbType.Int)
        arParms.Value = AssetUsageid
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_QTYFILL", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function FillGridDetails(ByVal insid As Integer, ByVal branchid As Integer, ByVal courseid As Integer, ByVal batchid As Integer) As Data.DataTable
        'Dim dt As New Data.DataTable
        Dim ds As New Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int)
        arParms(0).Value = insid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = branchid

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int)
        arParms(2).Value = courseid

        arParms(3) = New SqlParameter("@batchid", SqlDbType.Int)
        arParms(3).Value = batchid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Grid_AssetUsage", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function FillGridOnDetails(ByVal insid As Integer, ByVal branchid As Integer, ByVal courseid As Integer, ByVal batchid As Integer) As Data.DataTable
        'Dim dt As New Data.DataTable
        Dim ds As New Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int)
        arParms(0).Value = insid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = branchid

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int)
        arParms(2).Value = courseid

        arParms(3) = New SqlParameter("@batchid", SqlDbType.Int)
        arParms(3).Value = batchid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FillGridDetailsOnDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptAssetUsage(ByVal insid As Integer, ByVal branchid As Integer, ByVal courseid As Integer, ByVal batchid As Integer) As Data.DataTable
        'Dim dt As New Data.DataTable
        Dim ds As New Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int)
        arParms(0).Value = insid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = branchid

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int)
        arParms(2).Value = courseid

        arParms(3) = New SqlParameter("@batchid", SqlDbType.Int)
        arParms(3).Value = batchid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptAssetUsage", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


End Class

