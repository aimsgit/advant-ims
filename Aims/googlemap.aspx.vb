Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class googlemap
    Inherits System.Web.UI.Page
    Dim Route As String

    Public Function ConvertDataTabletoString() As String
        Route = Request.QueryString.Get("Route")

        Dim dt As New DataTable()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("select lat=Latitude,lng=Longitude,description=(Select RouteName from RouteMaster where RouteNo='" + Route + "' and Branchcode='" + Session("BranchCode") + "') from Gps_data where Route='" + Route + "' and Date=CONVERT(VARCHAR(10),GETDATE(),111) and Branchcode='" + Session("BranchCode") + "'", con)
                'select lat=Latitude,lng=Longitude from Gps_data where Route='" + Route + "' and Date=CONVERT(VARCHAR(10),GETDATE(),111) 
                con.Open()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
                Dim rows As New List(Of Dictionary(Of String, Object))()
                Dim row As Dictionary(Of String, Object)
                For Each dr As DataRow In dt.Rows
                    row = New Dictionary(Of String, Object)()
                    For Each col As DataColumn In dt.Columns
                        row.Add(col.ColumnName, dr(col))
                    Next
                    rows.Add(row)
                Next
                Return serializer.Serialize(rows)
            End Using
        End Using
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
