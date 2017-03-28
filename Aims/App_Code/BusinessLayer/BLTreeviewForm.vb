
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
'--Author: Kusum.C.Akki
'--Date: 02.01.2013
'--Description: Treeview form to configure the module and its respective child.
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
Imports Microsoft.VisualBasic

Public Class BLTreeviewForm
    Public Function Insert(ByVal ELT As ELTreeviewForm) As Integer
        Return DLTreeviewForm.Insert(ELT)
    End Function
    Public Function GetDuplicateModule(ByVal ELT As ELTreeviewForm) As DataTable
        Return DLTreeviewForm.GetDuplicateModule(ELT)
    End Function
    Public Function GetModule(ByVal ELT As ELTreeviewForm) As DataTable
        Return DLTreeviewForm.GetModule(ELT)
    End Function
    Public Function GetModuleDdl() As DataTable
        Return DLTreeviewForm.GetModuleDdl()
    End Function
    Public Function Delete(ByVal ELT As ELTreeviewForm) As Integer
        Return DLTreeviewForm.Delete(ELT)
    End Function
    Public Function DeleteChild(ByVal ELTC As ELTreeviewChildForm) As Integer
        Return DLTreeviewForm.DeleteChild(ELTC)
    End Function
    Public Function InsertChild(ByVal ELT As ELTreeviewChildForm) As Integer
        Return DLTreeviewForm.InsertChild(ELT)
    End Function
    Public Function GetDuplicateChild(ByVal ELTC As ELTreeviewChildForm) As DataTable
        Return DLTreeviewForm.GetDuplicateChild(ELTC)
    End Function
    Public Function GetChild(ByVal ELTC As ELTreeviewChildForm) As DataTable
        Return DLTreeviewForm.GetChild(ELTC)
    End Function
    Public Function InsertCustomizeTreeview(ByVal ELTC As ELTreeviewChildForm) As Integer
        Return DLTreeviewForm.InsertTanentChild(ELTC)
    End Function

    Public Function GetCustTreeviewDetails(ByVal ELTC As ELTreeviewChildForm, ByVal formname As Integer) As DataTable
        Return DLTreeviewForm.GetCustTreeviewDetails(ELTC, formname)
    End Function
    Public Function GetTanentCustomizeTreeview(ByVal ELTC As ELTreeviewChildForm) As DataTable
        Return DLTreeviewForm.GetCustomizeChild(ELTC)
    End Function

    Public Function DeleteCustomizeChild(ByVal ELTC As ELTreeviewChildForm) As Integer
        Return DLTreeviewForm.DeleteCustomizeChild(ELTC)
    End Function

    Public Function CustomizeDuplicate(ByVal ELTC As ELTreeviewChildForm) As DataTable
        Return DLTreeviewForm.CustomizeDuplicate(ELTC)
    End Function
End Class
