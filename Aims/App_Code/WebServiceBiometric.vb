Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebServiceBiometric
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function BiometricData(ByVal UserID As String, ByVal LogDate As DateTime, ByVal minLogTime As DateTime, ByVal maxLogTime As DateTime, ByVal Branchcode As String, ByVal DeviceNo As String) As String
        DLBiometric.WebBiometricData(UserID, LogDate, minLogTime, maxLogTime, Branchcode, DeviceNo)
        Return 0
    End Function

End Class
