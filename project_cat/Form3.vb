Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        dataPeserta()
        pemberitahuan()
        DateTimePicker1.Value = DateTime.Now
        Label8.Visible = False
        TextBox1.Select()
    End Sub

    Sub setNull()
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        UPDATE soal SET jawaban_peserta = NULL WHERE jawaban_peserta IS NOT NULL
        ", conn)
        cmd.ExecuteNonQuery()
    End Sub

    Sub dataPeserta()
        da = New MySql.Data.MySqlClient.MySqlDataAdapter("
        SELECT * FROM peserta
        ", conn)
        dt = New DataTable
        data = da.Fill(dt)

        If data > 0 Then
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(0).HeaderText = "No."
            DataGridView1.Columns(0).Width = 30
            DataGridView1.Columns(1).HeaderText = "Nama"
            DataGridView1.Columns(2).HeaderText = "E-mail"
            DataGridView1.Columns(3).HeaderText = "Tanggal"
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).HeaderText = "Nilai"
            DataGridView1.Columns(4).Width = 40
            DataGridView1.Columns(5).HeaderText = "Keterangan"
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If TextBox1.Text = "" Or TextBox1.Text = "" Then
            MessageBox.Show("Silahkan isi Nama dan E-mail Anda terlebih dahulu", "Informasi")
        Else
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If TextBox1.Text = DataGridView1.Rows(i).Cells(1).Value Or
                    TextBox1.Text = DataGridView1.Rows(i).Cells(2).Value Then
                    cmd = New MySql.Data.MySqlClient.MySqlCommand("
                    UPDATE peserta SET
                        nama        = '" & TextBox1.Text & "',
                        email       = '" & TextBox2.Text & "',
                        tanggal     = '" & DateTimePicker1.Value.ToString("yyyy-MM-dd hh-mm-ss") & "',
                        nilai       = '" & Label7.Text & "',
                        keterangan  = '" & Label8.Text & "'
                    WHERE nama = '" & TextBox1.Text & "' Or email = '" & TextBox2.Text & "'
                    ", conn)
                    cmd.ExecuteNonQuery()
                    dataPeserta()
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox1.ReadOnly = True
                    TextBox2.ReadOnly = True
                    btnSend.Enabled = False
                    btnRep.Select()
                    Return
                End If
            Next

            cmd = New MySql.Data.MySqlClient.MySqlCommand("
            INSERT INTO peserta VALUES
            (
                NULL,
                '" & TextBox1.Text & "',
                '" & TextBox2.Text & "',
                '" & DateTimePicker1.Value.ToString("yyyy-MM-dd hh-mm-ss") & "',
                '" & Label7.Text & "',
                '" & Label8.Text & "'
            )
            ", conn)
            cmd.ExecuteNonQuery()
            dataPeserta()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.ReadOnly = True
            TextBox2.ReadOnly = True
            btnSend.Enabled = False
            btnRep.Select()
        End If
    End Sub

    Sub pemberitahuan()
        If Label7.Text >= 70 Then
            Label8.Text = "LULUS"
            Label9.Text = "SELAMAT ANDA LULUS TES"
            Label9.ForeColor = Color.Green
        Else
            Label8.Text = "TIDAK LULUS"
            Label9.Text = "MAAF ANDA TIDAK LULUS TES"
            Label9.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 1000
        lblWaktu.Text = Format(jj, "00:") & Format(mm, "00:") & Format(dd, "00")
        dd = dd + 1
        If dd > 59 Then
            dd = 0
            mm = mm + 1
        ElseIf mm > 59 Then
            mm = 0
            dd = 0
            jj = jj + 1
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        setNull()
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnRep_Click(sender As Object, e As EventArgs) Handles btnRep.Click
        FormHome.Show()
        Me.Close()
        setNull()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        da = New MySql.Data.MySqlClient.MySqlDataAdapter("
        SELECT * FROM peserta WHERE
            no_peserta  LIKE '%" & TextBox3.Text & "%' OR
            nama        LIKE '%" & TextBox3.Text & "%' OR
            email       LIKE '%" & TextBox3.Text & "%' OR
            tanggal     LIKE '%" & TextBox3.Text & "%' OR
            nilai       LIKE '%" & TextBox3.Text & "%' OR
            keterangan  LIKE '%" & TextBox3.Text & "%'
        ORDER BY no_peserta ASC
        ", conn)
        dt = New DataTable
        data = da.Fill(dt)
        If data > 0 Then
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(0).HeaderText = "No."
            DataGridView1.Columns(0).Width = 30
            DataGridView1.Columns(1).HeaderText = "Nama"
            DataGridView1.Columns(2).HeaderText = "E-mail"
            DataGridView1.Columns(3).HeaderText = "Tanggal"
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).HeaderText = "Nilai"
            DataGridView1.Columns(4).Width = 40
            DataGridView1.Columns(5).HeaderText = "Keterangan"
        End If
    End Sub
End Class