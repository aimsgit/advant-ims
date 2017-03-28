Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class TreeViewDB
    Public Shared Function GetTVParentNodes() As DataTable
        Dim ds As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@InstituteID", SqlDbType.VarChar, 5)
        arParms(0).Value = HttpContext.Current.Session("InstituteCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetParentList", arParms)
        Return ds.Tables(0)
    End Function
    'Changes made by Kusum to pass this into session
    '19-Apr-2012
    Public Shared Function GetChildlistForParennode(ByVal parentID As Integer) As DataSet
        Dim ds As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms As SqlParameter
        'arParms = New SqlParameter("@Parent_ID", SqlDbType.Int)
        'arParms.Value = parentID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetChildlistForParentID", arParms)
        Return ds
    End Function
    'Changes made by Kusum to pass this into session
    '20-Apr-2012
    Public Shared Function GetChildlist() As DataTable
        Dim ds As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetChildlist")
        Return ds.Tables(0)
    End Function
    Public Function GetTreeView(ByVal Parent_ID As Int32) As Data.DataTable
        Dim ds As New Data.DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@Parent_ID", SqlDbType.Int)
        arParms.Value = Parent_ID
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString()
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TreeData", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetTreeView1(ByVal Parent_ID As Int32) As Data.DataTable
        Dim ds As New Data.DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@Parent_ID", SqlDbType.Int)
        arParms.Value = Parent_ID
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString()
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TreeTop1", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetMexParent() As Int64
        Dim MaxParent As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString()
        MaxParent = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, "Select MAX(Parent_ID) from TreeView_Data")
        Return MaxParent
    End Function
    Public Function UpdateTreeView(ByVal id As Int32, ByVal parent_id As Int32, ByVal child_id As Int32, ByVal title As String, ByVal parent_name As String, ByVal linkname As String, ByVal form_id As Int32) As Integer
        Dim rowsaffected As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@parent_id", SqlDbType.Int)
        arParms(0).Value = parent_id

        arParms(1) = New SqlParameter("@child_id", SqlDbType.Int)
        arParms(1).Value = child_id

        arParms(2) = New SqlParameter("@title", SqlDbType.VarChar, 50)
        arParms(2).Value = title

        arParms(3) = New SqlParameter("@parentname", SqlDbType.VarChar, 50)
        arParms(3).Value = parent_name

        arParms(4) = New SqlParameter("@linkname", SqlDbType.VarChar, 50)
        arParms(4).Value = linkname

        arParms(5) = New SqlParameter("@form_id", SqlDbType.Int)
        arParms(5).Value = form_id

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(8).Value = id

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateTreeData", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function InsertTreeView(ByVal parent_id As Int32, ByVal child_id As Int32, ByVal title As String, ByVal parent_name As String, ByVal linkname As String, ByVal form_id As Int32) As Integer
        Dim rowsaffected As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@parent_id", SqlDbType.Int)
        arParms(0).Value = parent_id

        arParms(1) = New SqlParameter("@child_id", SqlDbType.Int)
        arParms(1).Value = child_id

        arParms(2) = New SqlParameter("@title", SqlDbType.VarChar, 50)
        arParms(2).Value = title

        arParms(3) = New SqlParameter("@parentname", SqlDbType.VarChar, 50)
        arParms(3).Value = parent_name

        arParms(4) = New SqlParameter("@linkname", SqlDbType.VarChar, 50)
        arParms(4).Value = linkname

        arParms(5) = New SqlParameter("@form_id", SqlDbType.Int)
        arParms(5).Value = form_id

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertTreeData", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    'Public Function ApprovalDetails() As System.Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Try
    '        Dim arParms As SqlParameter = New SqlParameter("@AB_EmpID", SqlDbType.Int)
    '        If HttpContext.Current.Session("EmpID") <> "" Then
    '            arParms.Value = CInt(HttpContext.Current.Session("EmpID"))
    '            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetApprovalRequestDtls", arParms)
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    'Public Function UpdateStatus(ByVal AppID As Int32, ByVal status As String) As Int16
    '    Dim rowsaffected As Integer
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim arParms() As SqlParameter = New SqlParameter(1) {}

    '    arParms(0) = New SqlParameter("@AppID", SqlDbType.Int)
    '    arParms(0).Value = AppID

    '    arParms(1) = New SqlParameter("@Status", SqlDbType.VarChar)
    '    arParms(1).Value = status
    '    Try
    '        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateApprovalDetails", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return rowsaffected
    'End Function
    'Shared Function GetApprovalDetailsByID(ByVal AppId As Int32) As System.Data.DataSet
    '    Try
    '        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '        Dim ds As New DataSet
    '        Dim arParms As SqlParameter

    '        arParms = New SqlParameter("@AppID", SqlDbType.Int)
    '        arParms.Value = AppId
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEditAppDetails", arParms)

    '        Return ds
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return Nothing
    '    End Try
    'End Function
    Public Function UpdateParentTreeView(ByVal parent_id As Int32, ByVal parent_name As String) As Integer
        Dim rowsaffected As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@parent_id", SqlDbType.Int)
        arParms(0).Value = parent_id

        arParms(1) = New SqlParameter("@parentname", SqlDbType.VarChar, 50)
        arParms(1).Value = parent_name

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateParentTreeView", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected

    End Function

    Public Function DeleteChildNode(ByVal Parent_ID As Int32, ByVal Child_Id As Int32) As Int32
        Dim delChild As Int32
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Parent_ID", SqlDbType.Int)
        arParms(0).Value = Parent_ID
        arParms(1) = New SqlParameter("@Child_ID", SqlDbType.Int)
        arParms(1).Value = Child_Id
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString()
        delChild = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteChildNode", arParms)
        Return delChild
    End Function

    Public Function GetParentText(ByVal LinkName As String, ByVal code As Integer) As Data.DataTable
        Dim ds As New Data.DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@LinkName", SqlDbType.NVarChar)
        arParms(0).Value = LinkName

        arParms(1) = New SqlParameter("@code", SqlDbType.Int)
        arParms(1).Value = code

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString()
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentName", arParms)
        Return ds.Tables(0)
    End Function
End Class
Public Class TVParent
    Public ID As String
    Public Title As String
    Public Sub New(ByVal id As String, ByVal link As String)
        Me.Title = Title
        Me.ID = id
    End Sub
End Class

Public Class ParentList
    Inherits ArrayList
    Default Public Shadows Property DefaultProperty(ByVal i As Integer) As TVParent
        Get
            Return CType(MyBase.Item(i), TVParent)
        End Get
        Set(ByVal value As TVParent)
            MyBase.Item(i) = value
        End Set
    End Property

End Class
Public Class TVChildNode
    Public Title As String
    Public Link As String

    Public Sub New(ByVal title As String, ByVal link As String)
        Me.Title = title
        Me.Link = link
    End Sub
End Class
Public Class ChildNodeList
    Inherits ArrayList

    Default Public Shadows Property DefaultProperty(ByVal i As Integer) As TVChildNode
        Get
            Return CType(MyBase.Item(i), TVChildNode)
        End Get
        Set(ByVal value As TVChildNode)
            MyBase.Item(i) = value
        End Set
    End Property
End Class


