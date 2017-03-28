Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.IO

Public Class SelfDetailsB
    Public Function GetDetails(ByVal id As Long) As List(Of SelfDetails)
        Dim selfdetails As New List(Of SelfDetails)
        Dim ds As DataSet = selfdetailsDB.GetDeatils(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            selfdetails.Add((New SelfDetails(row("MyCo_Id"), row("MyCo_Name"), row("Company_Address"), row("Registration_No"), row("City"), row("State"), row("Postal_Code"), row("Country"), row("Contact_Person"), row("Contact_Number1"), row("Contact_Number2"), row("Fax_Number"), row("Email"), row("Website"))))
        Next
        Return selfdetails
    End Function
    Public Function GetDetails() As List(Of SelfDetails)
        Dim selfdetails As New List(Of SelfDetails)
        Dim ds As DataSet = selfdetailsDB.GetDeatils(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            selfdetails.Add((New SelfDetails(row("MyCo_Id"), row("MyCo_Name"), row("Company_Address"), row("Registration_No"), row("City"), row("State"), row("Postal_Code"), row("Country"), row("Contact_Person"), row("Contact_Number1"), row("Contact_Number2"), row("Fax_Number"), row("Email"), row("Website"))))
        Next
        Return selfdetails
    End Function
    Public Function UpdateRecord(ByVal s As SelfDetails) As Integer
        If s.CoId = Nothing Then
            s.CoId = "0"
        End If
        If s.City = Nothing Then
            s.City = ""
        End If
        If s.Address = Nothing Then
            s.Address = ""
        End If
        If s.Code = Nothing Then
            s.Code = ""
        End If
        If s.Country = Nothing Then
            s.Country = ""
        End If
        If s.Contactperson = Nothing Then
            s.Contactperson = ""
        End If
        If s.Contactno1 = Nothing Then
            s.Contactno1 = ""
        End If
        If s.Contactno2 = Nothing Then
            s.Contactno2 = ""
        End If
        If s.Email = Nothing Then
            s.Email = ""
        End If
        If s.State = Nothing Then
            s.State = "0"
        End If
        If s.Website = Nothing Then
            s.Website = ""
        End If
        If s.Fax = Nothing Then
            s.Fax = ""
        End If
        Return selfdetailsDB.Update(s)
    End Function
    Public Function RPT_GetSelfDeatilsByBranch(ByVal UID As String) As DataTable
        Dim dt As DataTable
        dt = selfdetailsDB.RPT_GetDeatilsByBranch(UID).Tables(0)
        For i As Int16 = 0 To i < dt.Rows.Count - 1
            If dt.Rows(i)("Logo").ToString <> "" Then
                Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Logo").ToString)
                If File.Exists(s) Then
                    LoadImage(dt.Rows(i), "image_stream", s)
                Else
                    LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
                End If
            Else
                LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
            End If
        Next
        Return dt
    End Function
    Protected Sub LoadImage(ByVal objDataRow As DataRow, ByVal strImageField As String, ByVal FilePath As String)
        Try
            Dim fs As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Dim Image(fs.Length) As Byte
            fs.Read(Image, 0, CInt(fs.Length))
            fs.Close()
            objDataRow(strImageField) = Image
        Catch ex As Exception
            'Response.Write("<font color=red>" + ex.Message + "</font>")
        End Try
    End Sub
    Public Function FillGrid() As DataTable
        Dim dt As New Data.DataTable
        Try
            If selfdetailsDB.GetDeatils(0).Tables.Count > 0 Then
                dt = selfdetailsDB.GetDeatils(0).Tables(0)
            End If
        Catch ex As Exception
        End Try
        Return dt
    End Function
    Public Function Insert(ByVal s As SelfDetails) As Integer
        If s.CoId = Nothing Then
            s.CoId = "0"
        End If
        If s.City = Nothing Then
            s.City = ""
        End If
        If s.Address = Nothing Then
            s.Address = ""
        End If
        If s.Code = Nothing Then
            s.Code = ""
        End If
        If s.Country = Nothing Then
            s.Country = ""
        End If
        If s.Contactperson = Nothing Then
            s.Contactperson = ""
        End If
        If s.Contactno1 = Nothing Then
            s.Contactno1 = ""
        End If
        If s.Contactno2 = Nothing Then
            s.Contactno2 = ""
        End If
        If s.Email = Nothing Then
            s.Email = ""
        End If
        If s.State = Nothing Then
            s.State = "0"
        End If
        If s.Website = Nothing Then
            s.Website = ""
        End If
        If s.Fax = Nothing Then
            s.Fax = ""
        End If
        Return selfdetailsDB.Insert(s)
    End Function
    Public Function Update(ByVal s As SelfDetails) As Integer
        If s.CoId = Nothing Then
            s.CoId = "0"
        End If
        If s.City = Nothing Then
            s.City = ""
        End If
        If s.Address = Nothing Then
            s.Address = ""
        End If
        If s.Code = Nothing Then
            s.Code = ""
        End If
        If s.Country = Nothing Then
            s.Country = ""
        End If
        If s.Contactperson = Nothing Then
            s.Contactperson = ""
        End If
        If s.Contactno1 = Nothing Then
            s.Contactno1 = ""
        End If
        If s.Contactno2 = Nothing Then
            s.Contactno2 = ""
        End If
        If s.Email = Nothing Then
            s.Email = ""
        End If
        If s.State = Nothing Then
            s.State = "0"
        End If

        If s.Website = Nothing Then
            s.Website = ""
        End If
        If s.Fax = Nothing Then
            s.Fax = ""
        End If
        Return selfdetailsDB.Update(s)
    End Function
    Public Function UpdateAdvant(ByVal s As SelfDetails) As Integer
        If s.CoId = Nothing Then
            s.CoId = "0"
        End If
        If s.City = Nothing Then
            s.City = ""
        End If
        If s.Address = Nothing Then
            s.Address = ""
        End If
        If s.Code = Nothing Then
            s.Code = ""
        End If
        If s.Country = Nothing Then
            s.Country = ""
        End If
        If s.Contactperson = Nothing Then
            s.Contactperson = ""
        End If
        If s.Contactno1 = Nothing Then
            s.Contactno1 = ""
        End If
        If s.Contactno2 = Nothing Then
            s.Contactno2 = ""
        End If
        If s.Email = Nothing Then
            s.Email = ""
        End If
        If s.State = Nothing Then
            s.State = ""
        End If
        If s.Website = Nothing Then
            s.Website = ""
        End If
        If s.Fax = Nothing Then
            s.Fax = ""
        End If
        Return selfdetailsDB.UpdateAdvant(s)
    End Function
    Public Function PathUpdate(ByVal i As Int64, ByVal path As String) As Int16
        Return selfdetailsDB.PhotoPathUpdate(i, path)
    End Function
    Public Function CheckPrefixDupli(ByVal Prefix As String, ByVal id As Integer) As Data.DataTable
        Return selfdetailsDB.CheckPrefixDupli(Prefix, id)
    End Function
    Public Function CheckDuplicate(ByVal rnd As String) As Data.DataTable
        Return selfdetailsDB.CheckDupli(rnd)
    End Function
    Public Function GetTenantModuleList(ByVal InstituteCode As String) As Data.DataTable
        Return selfdetailsDB.GetTenantModuleList(InstituteCode)
    End Function
    'Nethra 20-Apr-2012
    Public Function UpdateTenantRoles(ByVal Names As String, ByVal InstID As String, ByVal id1 As String) As Integer
        Return selfdetailsDB.UpdateTenantRoles(Names, InstID, id1)
    End Function
    'Nethra 20-Apr-2012
    Public Function DeleteJunkData() As Data.DataTable
        Return selfdetailsDB.DeleteJunkData()
    End Function
    'Nethra 20-Apr-2012
    Public Function DeleteInstData(ByVal InstCode As String) As Data.DataTable
        Return selfdetailsDB.DeleteInstData(InstCode)
    End Function
    'Kusum 02-02-2013
    Public Function DeleteBranchData(ByVal InstCode As String) As Data.DataTable
        Return selfdetailsDB.DeleteBranchData(InstCode)
    End Function
End Class
