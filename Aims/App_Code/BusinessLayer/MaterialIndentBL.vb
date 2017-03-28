Imports Microsoft.VisualBasic
Public Class MaterialIndentBL
    Dim DL As New MaterialIndentDL
    Public Function InsertMaterialIndentMain(ByVal AddMaterial As MaterialIndentEL) As Integer
        Return MaterialIndentDL.InsertMaterialIndent(AddMaterial)
    End Function
    Public Function MaterialIndentMainGridView(ByVal AddMaterial As MaterialIndentEL) As DataTable
        Return MaterialIndentDL.MaterialMaineGridView(AddMaterial)
    End Function
    Public Function CheckDuplicate(ByVal AddMaterial As MaterialIndentEL) As System.Data.DataTable
        Return DL.CheckDuplicateMaterialIndent(AddMaterial)
    End Function
    Public Function CheckStatus(ByVal AddMaterial As MaterialIndentEL) As System.Data.DataTable
        Return DL.CheckStatus(AddMaterial)
    End Function
    Public Function CheckStatus1(ByVal AddMaterial As MaterialIndentEL) As System.Data.DataTable
        Return DL.CheckStatus1(AddMaterial)
    End Function
    Public Function DeleteMaterialIndentMain(ByVal AddMaterial As MaterialIndentEL) As Integer
        Return MaterialIndentDL.DeleteMaterialIndent(AddMaterial)
    End Function
    Public Function InsertMaterialIndentDetails(ByVal AddMaterial As MaterialIndentEL) As Integer
        Return MaterialIndentDL.InsertMaterialIndentDetails(AddMaterial)
    End Function
    Public Function MaterialIndentDetailsGridView(ByVal AddMaterial As MaterialIndentEL) As DataTable
        Return MaterialIndentDL.MaterialIndentDetailsGridView(AddMaterial)
    End Function
    Public Function GetUnit(ByVal AddMaterial As MaterialIndentEL) As DataTable
        Return MaterialIndentDL.GetUnit(AddMaterial)
    End Function
    Public Function DeleteMaterialIndentDetails(ByVal AddMaterial As MaterialIndentEL) As Integer
        Return MaterialIndentDL.DeleteMaterialIndentDetails(AddMaterial)
    End Function
    Public Function CheckMIndentNo(ByVal AddMaterial As MaterialIndentEL) As System.Data.DataTable
        Return DL.CheckMaterialIndentNo(AddMaterial)
    End Function
    Public Function Approve(ByVal AddMaterial As MaterialIndentEL) As Integer
        Return DL.Approve(AddMaterial)
    End Function
End Class
