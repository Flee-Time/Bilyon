Imports Microsoft.EntityFrameworkCore

Public Class AppDbContext
    Inherits DbContext

    Public Property Settings As DbSet(Of Settings)
    Public Property Computers As DbSet(Of Computers)
    Public Property CompDetail As DbSet(Of CompDetail)
    Public Property LastSeen As DbSet(Of LastSeen)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlite("Data Source=localdb.db")
    End Sub
End Class
