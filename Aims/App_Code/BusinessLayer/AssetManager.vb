Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class AssetManager
    Public Function GetAssetByID(ByVal ID As Long) As List(Of AssetCombo)
        Dim assetC As New List(Of AssetCombo)
        Dim ds As DataTable = AssetDB.GVAssetComboUser(ID)
        Dim row As DataRow
        For Each row In ds.Rows
            assetC.Add(New AssetCombo(row("Asset_ID"), row("AssetName")))
        Next
        Return assetC
    End Function

    Public Function InsertRecord(ByVal Ast As Asset) As Integer
        Return AssetDB.Insert(Ast)
    End Function
    Public Function UpdateRecord(ByVal Ast As Asset) As Integer
        Return AssetDB.Update(Ast)
    End Function
    Public Function ChangeFlag(ByVal Ast As Integer) As Integer
        Return AssetDB.ChangeFlag(Ast)
    End Function
    Public Function GetCommName(ByVal Ast As Asset) As Data.DataTable
        Return AssetDB.GetCommName(Ast)
    End Function
    Public Function GetDuplicate(ByVal id As Integer, ByVal Ast As Asset) As Data.DataTable
        Return AssetDB.GetDuplicate(id, Ast)
    End Function
End Class
