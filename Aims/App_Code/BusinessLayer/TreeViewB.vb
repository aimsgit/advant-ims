Imports Microsoft.VisualBasic

Public Class TreeViewB
    Dim DAL As New TreeViewDB
    Public Function GetTreeView(ByVal Parent_Id As Int32) As Data.DataTable
        Dim dt As New Data.DataTable
        dt = DAL.GetTreeView(Parent_Id)
        Return dt
    End Function
    Public Function UpdateTreeView(ByVal ID As Int32, ByVal Parent_ID As Int32, ByVal Child_ID As Int32, ByVal Title As String, ByVal Parent_Name As String, ByVal LinkName As String, ByVal Form_Id As Int32) As Int32
        Dim rowsaffected As Int32
        rowsaffected = DAL.UpdateTreeView(ID, Parent_ID, Child_ID, Title, Parent_Name, LinkName, Form_Id)
        Return rowsaffected
    End Function
    Public Function GetMexParent() As Int64
        Return DAL.GetMexParent
    End Function
    Public Function InsertTreeView(ByVal Parent_ID As Int32, ByVal Child_ID As Int32, ByVal Title As String, ByVal Parent_Name As String, ByVal LinkName As String, ByVal Form_Id As Int32) As Int32
        Dim rowsaffected As Int32
        rowsaffected = DAL.InsertTreeView(Parent_ID, Child_ID, Title, Parent_Name, LinkName, Form_Id)
        Return rowsaffected
    End Function
    Public Function GetTreeView1(ByVal Parent_ID As Int32) As Data.DataTable
        Dim dt As New Data.DataTable
        dt = DAL.GetTreeView1(Parent_ID)
        Return dt
    End Function
    Public Function DeleteChildNode(ByVal Parent_ID As Int32, ByVal Child_Id As Int32) As Int32
        Return DAL.DeleteChildNode(Parent_ID, Child_Id)
    End Function
    Public Function UpdateParentTreeView(ByVal parent_id As Int32, ByVal parent_name As String) As Integer
        Return DAL.UpdateParentTreeView(parent_id, parent_name)
    End Function
End Class
