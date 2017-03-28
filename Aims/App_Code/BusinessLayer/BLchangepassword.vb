Imports Microsoft.VisualBasic
Imports System.Data

Public Class BLchangepassword
    Public Function UpdateRecord(ByVal c As changepassword) As Integer
        '20-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Return DLchangepassword.Updatechangepassword(c)
    End Function
    Public Function getRecord(ByVal c As changepassword) As DataTable
        '20-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Return DLchangepassword.getpassword(c)
    End Function

    Public Function UpdateParentRecord(ByVal c As changepassword) As Integer
        '20-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Return DLchangepassword.UpdateParentchangepassword(c)
    End Function
    Public Function getParentRecord(ByVal c As changepassword) As DataTable
        '20-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Return DLchangepassword.getParentpassword(c)
    End Function
End Class
