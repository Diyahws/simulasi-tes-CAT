Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        dataSoal()
        TextBox2.Select()
    End Sub

    Sub dataSoal()
        str = "SELECT no, pertanyaan, pilihan1, pilihan2, pilihan3, pilihan4, pilihan5, jawaban FROM soal"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(str, conn)
        dt = New DataTable
        data = da.Fill(dt)
        If data > 0 Then
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(0).HeaderText = "No"
            DataGridView1.Columns(0).Width = 30
            DataGridView1.Columns(1).HeaderText = "Pertanyaan"
            DataGridView1.Columns(2).HeaderText = "Pilihan 1"
            DataGridView1.Columns(3).HeaderText = "Pilihan 2"
            DataGridView1.Columns(4).HeaderText = "Pilihan 3"
            DataGridView1.Columns(5).HeaderText = "Pilihan 4"
            DataGridView1.Columns(6).HeaderText = "Pilihan 5"
            DataGridView1.Columns(7).HeaderText = "Jawaban"
        End If
    End Sub

    Sub kondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        INSERT INTO soal
        (no, pertanyaan, pilihan1, pilihan2, pilihan3, pilihan4, pilihan5, jawaban)
        VALUES
        (
            '" & TextBox1.Text & "',
            '" & TextBox2.Text & "',
            '" & TextBox3.Text & "',
            '" & TextBox4.Text & "',
            '" & TextBox5.Text & "',
            '" & TextBox6.Text & "',
            '" & TextBox7.Text & "',
            '" & TextBox8.Text & "'
        )
        ", conn)
        cmd.ExecuteNonQuery()
        dataSoal()
        kondisiAwal()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        DELETE FROM soal WHERE no = '" & TextBox1.Text & "'
        ", conn)
        cmd.ExecuteNonQuery()
        dataSoal()
        kondisiAwal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        UPDATE soal SET
            no          = '" & TextBox1.Text & "',
            pertanyaan  = '" & TextBox2.Text & "',
            pilihan1    = '" & TextBox3.Text & "',
            pilihan2    = '" & TextBox4.Text & "',
            pilihan3    = '" & TextBox5.Text & "',
            pilihan4    = '" & TextBox6.Text & "',
            pilihan5    = '" & TextBox7.Text & "',
            jawaban     = '" & TextBox8.Text & "'
        WHERE no        = '" & TextBox1.Text & "'
        ", conn)
        dataSoal()
        kondisiAwal()
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        Dim i As Integer
        Try
            i = DataGridView1.CurrentRow.Index
            With DataGridView1.Rows.Item(i)
                TextBox1.Text = .Cells(0).Value
                TextBox2.Text = .Cells(1).Value
                TextBox3.Text = .Cells(2).Value
                TextBox4.Text = .Cells(3).Value
                TextBox5.Text = .Cells(4).Value
                TextBox6.Text = .Cells(5).Value
                TextBox7.Text = .Cells(6).Value
                TextBox8.Text = .Cells(7).Value
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        kondisiAwal()
    End Sub

    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles Button56.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
