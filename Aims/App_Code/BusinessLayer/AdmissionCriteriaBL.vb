Imports Microsoft.VisualBasic

Public Class AdmissionCriteriaBL
    Dim DL As New AdmissionCriteriaDL
    Public Function InsertAdmissionCriteria(ByVal AddCriteria As AdmissionCriteriaEL) As Integer
        Return AdmissionCriteriaDL.InsertAdmissionCriteria(AddCriteria)
    End Function
    Public Function AdmissionCriteriaMasterGridView(ByVal ID As Integer) As DataTable
        Return AdmissionCriteriaDL.AdmissionCriteriaGridView(ID)
    End Function
    Public Function DeleteAdmissionCriteria(ByVal AddCriteria As AdmissionCriteriaEL) As Integer

        Return AdmissionCriteriaDL.DeleteAdmissionCriteriaMaster(AddCriteria)
    End Function
    Public Function UpdateCriteriaStatus(ByVal AddCriteria As AdmissionCriteriaEL) As Integer

        Return AdmissionCriteriaDL.UpdateCriteriaStatusMaster(AddCriteria)
    End Function
    Public Function CheckDuplicate(ByVal AddCriteria As AdmissionCriteriaEL) As System.Data.DataTable
        Return DL.CheckDuplicateAdmissionCriteria(AddCriteria)
    End Function
    Public Function getStatus(ByVal AddCriteria As AdmissionCriteriaEL) As System.Data.DataTable
        Return DL.getAdmissionCriteriaStatus(AddCriteria)
    End Function


End Class
