Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters

Public Class BLTransportReg
    Dim DLTransportReg As New DLTransportReg
    Function GetRouteNamecombo() As Data.DataTable
        Return DLTransportReg.GetRouteNamecombo()
    End Function
    Public Function ChangeFlag(ByVal TRNO As Long) As Integer
        Return DLTransportReg.ChangeFlag(TRNO)
    End Function
    Function GetPickuppointcombo(ByVal RouteIDAuto As Integer) As Data.DataTable
        Return DLTransportReg.GetPickuppointcombo(RouteIDAuto)
    End Function
    Function AutofillName(ByVal EnL As TransportReg) As Data.DataTable
        Return DLTransportReg.AutofillName(EnL)
    End Function
    Function AutoFilForRutNo(ByVal RouteIDAuto As TransportReg) As Data.DataTable
        Return DLTransportReg.AutoFilForRutNo(RouteIDAuto)
    End Function
    Function InsertIntoReg(ByVal m As TransportReg) As Integer
        Return DLTransportReg.InsertIntoReg(m)
    End Function
    Function Update(ByVal m As TransportReg) As Integer
        Return DLTransportReg.Update(m)
    End Function
    Function GetTransportReg(ByVal m As TransportReg) As Data.DataTable
        Return DLTransportReg.GetTransportReg(m)
    End Function
    Public Function CheckDuplicate(ByVal TransportReg As TransportReg) As System.Data.DataTable
        Return DLTransportReg.CheckDuplicate(TransportReg)
    End Function
    Public Function CheckDuplicateEmp(ByVal TransportReg As TransportReg) As System.Data.DataTable
        Return DLTransportReg.CheckDuplicateEmp(TransportReg)
    End Function
End Class
