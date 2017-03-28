Imports Microsoft.VisualBasic

Public Class RoleTestingBL
    Public Function View(ByVal EL As RoleTestingEL) As Data.DataTable
        Return RollTestingDL.View(EL)
    End Function
    Public Function View1(ByVal EL As RoleTestingEL) As Data.DataTable
        Return RollTestingDL.View1(EL)
    End Function
End Class
