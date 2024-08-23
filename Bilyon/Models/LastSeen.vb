Imports System.ComponentModel.DataAnnotations

Public Class LastSeen
    <Key>
    Public Property ID As Integer
    <MaxLength(36)>
    <Required>
    Public Property COMP_GUID As String
    <Required>
    Public Property LastSeenTime As DateTime
End Class
