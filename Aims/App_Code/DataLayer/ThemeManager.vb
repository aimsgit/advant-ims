Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Namespace nsThemeManager

    Public Class ThemeManager
        Public Function GetThemes() As List(Of Theme)
            Dim dInfo As New DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/App_Themes"))
            Dim dArrInfo() As DirectoryInfo = dInfo.GetDirectories
            Dim lstth As New List(Of Theme)
            Dim sDirectory As DirectoryInfo
            For Each sDirectory In dArrInfo
                Dim temp As New Theme(sDirectory.Name)
                lstth.Add(temp)
            Next
            Return lstth
        End Function
    End Class
End Namespace



'    Public Class ThemeManager
'{
'    #region Theme-Related Method
'    public static List<Theme> GetThemes()
'    {
'        DirectoryInfo dInfo = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("App_Themes"));
'        DirectoryInfo[] dArrInfo = dInfo.GetDirectories();
'        List<Theme> list = new List<Theme>();
'        foreach (DirectoryInfo sDirectory in dArrInfo)
'        {
'            Theme temp = new Theme(sDirectory.Name);
'            list.Add(temp);
'        }
'        return list;
'    }
'    #endregion
'}

