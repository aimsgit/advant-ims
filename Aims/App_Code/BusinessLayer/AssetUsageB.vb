Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
Public Class AssetUsageB
    Dim DAL As New AssetUsageDB
    Public Function Insert(ByVal prop As AssetUsage.AssetUsage) As Int64
        Dim DAL As New GlobalDataSetTableAdapters.AssetUsageTableAdapter
        Return DAL.AssetUsageInsert(prop)
    End Function

    Public Function Update(ByVal Prop As AssetUsage.AssetUsage) As Int64
        DAL.Update(Prop)
    End Function

    Public Function UpdateDelFlag(ByVal AUID As Integer) As Integer
        Return DAL.UpdateDelFlag(AUID)
    End Function
    Public Function QtyFill(ByVal AUID As Integer) As Data.DataTable
        Return DAL.FillQty(AUID)
    End Function
    Public Function GetDetails(ByVal AUID As Integer, ByVal ins As Integer, ByVal branch As Integer, ByVal course As Integer, ByVal batch As Integer) As Data.DataTable
        Return DAL.GetDetails(AUID, ins, branch, course, batch)
    End Function
    Public Function FillGridDetails(ByVal insid As Integer, ByVal branchid As Integer, ByVal course As Integer, ByVal batch As Integer) As Data.DataTable
        Return DAL.FillGridDetails(insid, branchid, course, batch)
    End Function
    Public Function RptAssetUssage(ByVal insid As Integer, ByVal branchid As Integer, ByVal course As Integer, ByVal batch As Integer) As Data.DataTable
        Return DAL.RptAssetUsage(insid, branchid, course, batch)
    End Function
    Public Function FillGridOnDetails(ByVal insid As Integer, ByVal branchid As Integer, ByVal course As Integer, ByVal batch As Integer) As Data.DataTable
        Return DAL.FillGridOnDetails(insid, branchid, course, batch)
    End Function
End Class

