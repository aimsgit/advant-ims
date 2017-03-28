Imports Microsoft.VisualBasic

Public Class Depreciation_Rates
    Public Function GetDepreciation_Rates(ByVal c As DepreiciationRate) As DataSet
        Dim dataSet As New DataSet
        dataSet = DepreciationRateDB.GetDepreciationRate(c)
        Return dataSet
    End Function
    Public Function GetDepreciationCompRpt() As DataTable
        Dim DataTable As New DataTable
        DataTable = DepreciationRateDB.GetDepreciationCmpRpt
        Return DataTable
    End Function
    Public Function UpdateRecord(ByVal i As DepreiciationRate) As Integer
        Return DepreciationRateDB.Update(i)
    End Function
    Public Function InsertRecord(ByVal i As DepreiciationRate) As Integer
        Return DepreciationRateDB.Insert(i)
    End Function
    Public Function CheckDuplicate(ByVal i As DepreiciationRate) As System.Data.DataTable
        Return DepreciationRateDB.CheckDuplicate(i)
    End Function
    Public Function ChangeFlag(ByVal id As Long) As Integer
        Return DepreciationRateDB.ChangeFlag(id)
    End Function
    Public Function RptDepreciationCompRpt(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
        Return DepreciationRateDB.RptDepreciationRate(Inst, Brch)
    End Function
    Public Function GetAssetTypecombo() As Data.DataTable
        Return DepreciationRateDB.GetAssetTypecombo()
    End Function
End Class
