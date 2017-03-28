Imports Microsoft.VisualBasic

Public Class BLDynamicReport
    Public Function GetColumnNames() As System.Data.DataTable
        Return DLDynamicReport.GetColumnNames()
    End Function
    Public Function AdmissionRegisterDynamic() As System.Data.DataTable
        Return DLDynamicReport.AdmissionRegisterDynamic()
    End Function
    Public Function GetRptdata(ByVal id As String) As System.Data.DataTable
        Return DLDynamicReport.GetRptdata(id)
    End Function
    Public Function AdmissionRegisterDynamic(ByVal Branch As String, ByVal Course As Integer, ByVal Batch As Integer, ByVal Gender As String, ByVal State As Integer, ByVal Feecollected As String, ByVal id As String, ByVal CountryId As Integer) As System.Data.DataTable
        Return DLDynamicReport.AdmissionRegisterDynamic(Branch, Course, Batch, Gender, State, Feecollected, id, CountryId)
    End Function
    Public Function AssetDetailsDynamicReport() As System.Data.DataTable
        Return DLDynamicReport.AssetDynamicReport()
    End Function
    Public Function AssetDetailsDynamicReport(ByVal Type As Integer, ByVal Supplier As Integer, ByVal Manufacturer As Integer, ByVal id As String) As System.Data.DataTable
        Return DLDynamicReport.AssetDetailsDynamicReport(Type, Supplier, Manufacturer, id)
    End Function
End Class
