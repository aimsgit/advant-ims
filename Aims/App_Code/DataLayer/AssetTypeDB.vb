Imports Microsoft.VisualBasic

Public Class AssetTypeDB
    Shared Function AssetType(ByVal AssetType_ID As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If AssetType_ID = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetTypeDetails")
        Else
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetTypeDetailsByID", New System.Data.SqlClient.SqlParameter("@AssetType_ID", SqlDbType.SmallInt, 10, ParameterDirection.Input, False, 0, 0, "AssetType_ID", DataRowVersion.Current, AssetType_ID))
        End If
        Return ds
    End Function
    Shared Function FillAssetType() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetType")
        Return ds
    End Function
    Shared Function FilltrainingmtrlType() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetType4")
        Return ds
    End Function
End Class
