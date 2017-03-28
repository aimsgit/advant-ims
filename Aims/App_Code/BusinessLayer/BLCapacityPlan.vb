Imports Microsoft.VisualBasic

Public Class BLCapacityPlan
    Dim DL As DLCapacityPlan
    Public Function GetCapacityPlan(ByVal el As ELCapacityPlan) As System.Data.DataTable
        Return DLCapacityPlan.GetCapacityPlan(el)
    End Function
    Public Function Insert(ByVal el As ELCapacityPlan) As Integer

        Return DLCapacityPlan.Insert(el)
    End Function
    Public Function Update(ByVal el As ELCapacityPlan) As Integer
        Return DLCapacityPlan.Update(el)
    End Function
    Public Function ChangeFlag(ByVal el As ELCapacityPlan) As Integer

        Return DLCapacityPlan.ChangeFlag(el)
    End Function
    Public Function CheckDuplicate(ByVal EL As ELCapacityPlan) As System.Data.DataTable
        Return DLCapacityPlan.CheckDuplicate(EL)

    End Function
End Class
