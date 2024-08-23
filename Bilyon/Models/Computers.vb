Imports System.ComponentModel.DataAnnotations

Public Class Computers
    <Key>
    <MaxLength(36)>
    Public Property GUID As String
    <Required>
    <MaxLength(50)>
    Public Property Host_Name As String
    <Required>
    <MaxLength(15)>
    Public Property Local_Ip As String
    <Required>
    <MaxLength(17)>
    Public Property Mac_Adress As String
End Class
