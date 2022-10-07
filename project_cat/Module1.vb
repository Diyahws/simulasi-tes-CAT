Imports MySql.Data.MySqlClient
Module Module1
    Public conn As MySqlConnection
    Public da As MySqlDataAdapter
    Public dr As MySqlDataReader
    Public cmd As MySqlCommand
    Public ds As DataSet
    Public dt As DataTable
    Public str As String
    Public data As Integer
    Public waktu As DateTime
    Public mundur As TimeSpan = TimeSpan.FromMinutes(60)
    Public jj, mm, dd As Integer
    Public hasil As Integer

    Sub koneksi()
        Try
            str = "server=localhost;userid=root;password=;database=db_cat;convert zero datetime = true"
            conn = New MySqlConnection(str)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
