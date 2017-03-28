Imports Microsoft.VisualBasic
Imports System.Data

Public Class BLResetPwd
    Public Function Resetpwd(ByVal r As ResetPwd) As Integer
        Return DLResetPwd.Resetpwd(r)
    End Function
    Public Function getuser(ByVal r As ResetPwd) As DataTable
        Return DLResetPwd.getusername(r)
    End Function

    Public Function ResetParentpwd(ByVal r As ResetPwd) As Integer
        Return DLResetPwd.ResetParentpwd(r)
    End Function
    Public Function ResetSParentpwd(ByVal r As ResetPwd) As Integer
        Return DLResetPwd.ResetSParentpwd(r)
    End Function
    Public Function getParentuser(ByVal r As ResetPwd) As DataTable
        Return DLResetPwd.getParentusername(r)
    End Function
End Class
