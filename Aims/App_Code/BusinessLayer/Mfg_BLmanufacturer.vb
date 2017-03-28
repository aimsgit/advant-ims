Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class Mfg_BLmanufacturer
    Dim dill As New Mfg_DLmanufacturer
    Public Function InsertRecord(ByVal i As Mfg_ELmanufacturer) As Integer
        Return dill.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As Mfg_ELmanufacturer) As Integer
        Return dill.Update(i)
    End Function
    Public Function getManufacturer(ByVal id As Mfg_ELmanufacturer) As Data.DataTable
        Return dill.getManufacturer(id)
    End Function
    Public Function DeleteManufacturer(ByVal s As Mfg_ELmanufacturer) As Integer
        Return dill.DeleteManufacturer(s)
    End Function
End Class
