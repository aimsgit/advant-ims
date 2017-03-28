Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class AssetTypeB
    Public Function GetAssetTypeById(ByVal id As Long) As AssetType
        Dim asset As AssetType
        Dim ds As DataSet = AssetTypeDB.AssetType(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        asset = New AssetType(row("AssetType_ID"), row("AssetType_Name"))
        Return asset
    End Function
    Public Function GetAssetType() As List(Of AssetType)
        Dim assettype As New List(Of AssetType)
        Dim ds As DataSet = AssetTypeDB.AssetType(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            assettype.Add(New AssetType(row("AssetType_ID"), row("AssetType_Name")))
        Next
        Return assettype
    End Function
    Public Function FillAssetType() As List(Of AssetType)
        Dim assettype As New List(Of AssetType)
        Dim ds As DataSet = AssetTypeDB.FillAssetType
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            assettype.Add(New AssetType(row("AssetType_ID"), row("AssetType_Name")))
        Next
        Return assettype
    End Function
    Public Function FilltrainingmtrlType() As List(Of AssetType)
        Dim assettype As New List(Of AssetType)
        Dim ds As DataSet = AssetTypeDB.FilltrainingmtrlType
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            assettype.Add(New AssetType(row("AssetType_ID"), row("AssetType_Name")))
        Next
        Return assettype
    End Function
End Class
