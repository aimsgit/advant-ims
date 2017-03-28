Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class BLslssbhierarchytreeview
    Public Function GetDCO(ByVal HO As String) As DataTable
        Return DLslssbhierarchytreeview.GetDCO(HO)
    End Function
    Public Function FillListView(ByVal HO As String) As DataTable
        Return DLslssbhierarchytreeview.FillListView(HO)
    End Function
    Public Function GetDCOreverse(ByVal DCODDL1 As String) As Data.DataTable
        Dim DCO1 As New List(Of slssbhierarchytreeview)
        Return DLslssbhierarchytreeview.GetDCOreverse(DCODDL1)
    End Function
    Public Function GetDSD(ByVal DSDDDL As String) As Data.DataTable
        Dim DSD As New List(Of slssbhierarchytreeview)
        Return DLslssbhierarchytreeview.GetDSD(DSDDDL)
    End Function
    Public Function GetDSDreverse(ByVal DSDDDL1 As String) As Data.DataTable
        Dim DSD1 As New List(Of slssbhierarchytreeview)
        Return DLslssbhierarchytreeview.GetDSDreverse(DSDDDL1)
    End Function
    Public Function GetGSDreverse(ByVal GSDDDL1 As String) As Data.DataTable
        Dim DSD1 As New List(Of slssbhierarchytreeview)
        Return DLslssbhierarchytreeview.GetGSDreverse(GSDDDL1)
    End Function
    Public Function GetGSD(ByVal GSDDDL As String) As Data.DataTable
        Dim GSD As New List(Of slssbhierarchytreeview)
        Return DLslssbhierarchytreeview.GetGSD(GSDDDL)
    End Function
    Public Function GetCenter(ByVal CenterDDL As String) As Data.DataTable
        Return DLslssbhierarchytreeview.GetCenter(CenterDDL)
    End Function
    Public Function GetHO() As Data.DataTable
        Return DLslssbhierarchytreeview.GetHO()
    End Function
End Class
