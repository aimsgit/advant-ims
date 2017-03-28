Imports Microsoft.VisualBasic

Public Class ElectiveMapBL

    Shared Function generate(ByVal EL As ElectiveMapEL) As Integer

        Return ElectiveMapDL.generate(EL)
    End Function
    Shared Function getduplicate(ByVal EL As ElectiveMapEL) As DataTable

        Return ElectiveMapDL.getduplicate(EL)
    End Function
   
    Shared Function clear(ByVal EL As ElectiveMapEL) As Integer

        Return ElectiveMapDL.clear(EL)
    End Function
    Shared Function GetData(ByVal EL As ElectiveMapEL) As DataTable

        Return ElectiveMapDL.GetData(EL)
    End Function
    Shared Function Update(ByVal EL As ElectiveMapEL, ByVal ID As String) As Integer

        Return ElectiveMapDL.Update(EL, ID)
    End Function
    Shared Function Lock(ByVal EL As ElectiveMapEL) As Integer

        Return ElectiveMapDL.Lock(EL)
    End Function
    Shared Function CheckLock(ByVal EL As ElectiveMapEL) As DataTable

        Return ElectiveMapDL.CheckLock(EL)
    End Function
End Class
