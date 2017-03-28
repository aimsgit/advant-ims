Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class TransportWeb

    Inherits System.Web.Services.WebService
    Dim t As New TransportAndroid
    Dim s As New StudentAndroid
    Dim D As New ELDocUpload
    Dim dt As DataTable
    <WebMethod()> _
    Public Function GPS(ByVal Route As String, ByVal Latitude As String, ByVal Longitude As String, ByVal gpsDate As String, ByVal Time As String, ByVal Branchcode As String, ByVal IMEINO As String) As String
        t.Route = Route
        t.Latitude = Latitude
        t.Longitude = Longitude
        t.gpsDate = gpsDate
        t.Time = Time
        t.IMEINO = IMEINO
        t.Branchcode = Branchcode
        DLTransportAndroid.Gps_Data(t)
        Return Nothing
    End Function

    <WebMethod()>
    Public Function Student(ByVal Route As String, ByVal BatchID As String, ByVal StudentID As String, ByVal StudentCode As String, ByVal Name As String, ByVal Time As String, ByVal Branchcode As String, ByVal IMEINO As String, ByVal Status As String, ByVal AtTime As String, ByVal Flag As String) As String
        s.BatchID = BatchID
        s.StudentID = StudentID
        s.Name = Name
        s.Time = Time
        s.IMEINO = IMEINO
        s.Branchcode = Branchcode
        s.StudentCode = StudentCode
        s.Route = Route
        s.Status = Status
        s.AtTime = AtTime
        s.Flag = Flag
        DLTransportAndroid.SendSMS(s)
        DLTransportAndroid.Student_Data(s)
        Return Nothing
    End Function
    <WebMethod()>
    Public Function DocumentUpload(ByVal docbinaryarray As Byte(), ByVal Link As String, ByVal Description As String, ByVal RevNo As String, ByVal RevDate As Date, ByVal Remarks As String) As String

        D.Link = Link
        D.Desc = Description
        D.RevNo = RevNo
        D.RevDate = RevDate
        D.Remarks = Remarks
        DLDocUpload.Insert(D)


        Return "Document Uploaded Successfully"
    End Function

End Class
