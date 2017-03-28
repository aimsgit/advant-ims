Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class BLRolemap
    Public Function Getrolemap(ByVal role As Rolemap) As DataTable
        '15-12-2010 Kusum.C.Akki. Function for getting the data into table'
        Return DLRolemap.GetRolemap(role)
    End Function
    Public Function CheckDuplicate(ByVal role As Rolemap) As DataTable
        '15-12-2010 Kusum.C.Akki. Function for getting the data into table'
        Return DLRolemap.CheckDuplicate(role)
    End Function
    Public Function InsertRecord(ByVal role As Rolemap) As Integer
        '15-12-2010 Kusum.C.Akki. Function for Inserting the data into table'
        Return DLRolemap.InsertRolemap(role)
    End Function
    Public Function UpdateRecord(ByVal role As Rolemap) As Integer
        '15-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Return DLRolemap.UpdateRolemap(role)
    End Function
    Public Function Delete(ByVal id As Long) As Integer
        '15-12-2010 Kusum.C.Akki. Function for Deleting the data into table'
        Return DLRolemap.DeleteRolemap(id)
    End Function
    Public Function Getuserformddl(ByVal role As Rolemap) As DataTable
        '15-12-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Return DLRolemap.Getuserformddl(role)
    End Function
    Public Function Getuserroleddl() As DataTable
        '15-12-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Return DLRolemap.Getuserroleddl()
    End Function
End Class
