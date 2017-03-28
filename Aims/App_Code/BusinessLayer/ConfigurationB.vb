Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class ConfigurationB
    Public Function GetConfig() As List(Of EntConfiguration)
        Dim EntConfiguration As New List(Of EntConfiguration)
        Dim ds As DataSet = ConfigurationDB.GetConfig(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            EntConfiguration.Add(New EntConfiguration(row("Config_ID"), row("Config_Name"), row("Date_Value"), row("config_Value")))
        Next
        Return EntConfiguration
    End Function
    Public Function GetConfig(ByVal cid As Long) As List(Of EntConfiguration)
        Dim EntConfiguration As New List(Of EntConfiguration)
        Dim ds As DataSet = ConfigurationDB.GetConfig(cid)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            EntConfiguration.Add(New EntConfiguration(row("Config_ID"), row("Config_Name"), row("Date_Value"), row("config_Value")))
        Next
        Return EntConfiguration
    End Function
    Public Function GetConfigId(ByVal cid As Long) As EntConfiguration
        Dim EntConfiguration As EntConfiguration
        Dim ds As DataSet = ConfigurationDB.GetConfig(cid)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        EntConfiguration = New EntConfiguration(row("Config_ID"), row("Config_Name"), row("Date_Value"), row("config_Value"))
        Return EntConfiguration
    End Function
    Public Function UpdateRecord(ByVal C As EntConfiguration) As Integer
        Return ConfigurationDB.Update(C)
    End Function
End Class
