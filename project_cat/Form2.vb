Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        kondisiAwal()
        Button1.Select()
        btnPrev.Visible = False
        Timer1.Interval = 1000
        waktu = DateTime.Now.Add(mundur)
        Form3.Timer1.Enabled = True
    End Sub

    Sub data()
        da = New MySql.Data.MySqlClient.MySqlDataAdapter("
        SELECT * FROM soal
        ", conn)
        ds = New DataSet
        da.Fill(ds, "soal")
    End Sub

    Sub kondisiAwal()
        RadioButton1.Visible = False
        RadioButton2.Visible = False
        RadioButton3.Visible = False
        RadioButton4.Visible = False
        RadioButton5.Visible = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        btnNext.Visible = False
        btnEnd.Visible = False
        lblNotice.Visible = False
        lblHook.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label8.Visible = False
        Label9.Visible = False
    End Sub

    Sub kondisiMulai()
        btnPrev.Visible = True
        btnEnd.Visible = False
        btnEnd2.Visible = True
        btnMark.Visible = True
        GroupBox2.Visible = True
        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = True
        RadioButton4.Visible = True
        RadioButton5.Visible = True
        lblNotice.Visible = False
    End Sub

    Sub resetJawaban()
        RadioButton1.Checked = CheckState.Unchecked
        RadioButton2.Checked = CheckState.Unchecked
        RadioButton3.Checked = CheckState.Unchecked
        RadioButton4.Checked = CheckState.Unchecked
        RadioButton5.Checked = CheckState.Unchecked
    End Sub

    Sub kondisiAkhir()
        lblPkey.Text = "00"
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        Button15.Enabled = False
        Button16.Enabled = False
        Button17.Enabled = False
        Button18.Enabled = False
        Button19.Enabled = False
        Button20.Enabled = False
        Button21.Enabled = False
        Button22.Enabled = False
        Button23.Enabled = False
        Button24.Enabled = False
        Button25.Enabled = False
        Button26.Enabled = False
        Button27.Enabled = False
        Button28.Enabled = False
        Button29.Enabled = False
        Button30.Enabled = False
        Button31.Enabled = False
        Button32.Enabled = False
        Button33.Enabled = False
        Button34.Enabled = False
        Button35.Enabled = False
        Button36.Enabled = False
        Button37.Enabled = False
        Button38.Enabled = False
        Button39.Enabled = False
        Button40.Enabled = False
        Button41.Enabled = False
        Button42.Enabled = False
        Button43.Enabled = False
        Button44.Enabled = False
        Button45.Enabled = False
        Button46.Enabled = False
        Button47.Enabled = False
        Button48.Enabled = False
        Button49.Enabled = False
        Button50.Enabled = False
        btnPrev.Enabled = False
        btnNext.Visible = False
        btnEnd.Visible = False
        btnMark.Visible = False
        RadioButton1.Visible = False
        RadioButton2.Visible = False
        RadioButton3.Visible = False
        RadioButton4.Visible = False
        RadioButton5.Visible = False
    End Sub

    Sub pilihan()
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            lblPkey.Text = dr.Item("no").ToString
            TextBox1.Text = dr.Item("pertanyaan").ToString
            RadioButton1.Text = dr.Item("pilihan1").ToString
            RadioButton2.Text = dr.Item("pilihan2").ToString
            RadioButton3.Text = dr.Item("pilihan3").ToString
            RadioButton4.Text = dr.Item("pilihan4").ToString
            RadioButton5.Text = dr.Item("pilihan5").ToString
        End If
        cmd.Dispose()
        dr.Close()
    End Sub

    Sub validasiJawaban(jawaban As RadioButton)
        If jawaban.Checked = True Then
            cmd = New MySql.Data.MySqlClient.MySqlCommand("
            ALTER TABLE `soal` CHANGE `jawaban_peserta` `jawaban_peserta` VARCHAR(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
            ", conn)

            cmd = New MySql.Data.MySqlClient.MySqlCommand("
            UPDATE soal SET
                jawaban_peserta = '" & jawaban.Text & "'
            WHERE no = '" & lblPkey.Text & "'
            ", conn)
            cmd.ExecuteNonQuery()
            data()
        End If
    End Sub

    Sub lacakJawaban()
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
            SELECT jawaban_peserta FROM soal WHERE no = '" & lblPkey.Text & "'
            ", conn)
        lblHook.Text = cmd.ExecuteScalar().ToString

        If RadioButton1.Text = lblHook.Text Then
            RadioButton1.Checked = True
        ElseIf RadioButton2.Text = lblHook.Text Then
            RadioButton2.Checked = True
        ElseIf RadioButton3.Text = lblHook.Text Then
            RadioButton3.Checked = True
        ElseIf RadioButton4.Text = lblHook.Text Then
            RadioButton4.Checked = True
        ElseIf RadioButton5.Text = lblHook.Text Then
            RadioButton5.Checked = True
        End If
    End Sub

    Sub validasiNilai()
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT COUNT(jawaban_peserta) FROM soal WHERE jawaban = Jawaban_peserta
        ", conn)
        Label5.Text = cmd.ExecuteScalar().ToString
        Dim jawabanBenar As Integer = Label5.Text
        Dim nilai As Integer
        nilai = jawabanBenar * 2
        Label9.Text = nilai

        Form3.Label1.Text = Label5.Text
        Form3.Label7.Text = Label9.Text

        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        ALTER TABLE `soal` CHANGE `jawaban_peserta` `jawaban_peserta` VARCHAR(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL
        ", conn)
        cmd.ExecuteNonQuery()
    End Sub

    Sub validasiTerjawab()
        If RadioButton1.Checked Or RadioButton2.Checked Or RadioButton3.Checked Or RadioButton4.Checked Or RadioButton5.Checked Then
            If Button1.Text = lblPkey.Text Then
                Button1.BackColor = Color.Lime
                Button1.Select()
            ElseIf Button2.Text = lblPkey.Text Then
                Button2.BackColor = Color.Lime
                Button2.Select()
            End If

            If Button3.Text = lblPkey.Text Then
                Button3.BackColor = Color.Lime
                Button3.Select()
            End If

            If Button4.Text = lblPkey.Text Then
                Button4.BackColor = Color.Lime
                Button4.Select()
            End If

            If Button5.Text = lblPkey.Text Then
                Button5.BackColor = Color.Lime
                Button5.Select()
            End If

            If Button6.Text = lblPkey.Text Then
                Button6.BackColor = Color.Lime
                Button6.Select()
            End If

            If Button7.Text = lblPkey.Text Then
                Button7.BackColor = Color.Lime
                Button7.Select()
            End If

            If Button8.Text = lblPkey.Text Then
                Button8.BackColor = Color.Lime
                Button8.Select()
            End If

            If Button9.Text = lblPkey.Text Then
                Button9.BackColor = Color.Lime
                Button9.Select()
            End If

            If Button10.Text = lblPkey.Text Then
                Button10.BackColor = Color.Lime
                Button10.Select()
            End If

            If Button11.Text = lblPkey.Text Then
                Button11.BackColor = Color.Lime
                Button11.Select()
            End If

            If Button12.Text = lblPkey.Text Then
                Button12.BackColor = Color.Lime
                Button12.Select()
            End If

            If Button13.Text = lblPkey.Text Then
                Button13.BackColor = Color.Lime
                Button13.Select()
            End If

            If Button14.Text = lblPkey.Text Then
                Button14.BackColor = Color.Lime
                Button14.Select()
            End If

            If Button15.Text = lblPkey.Text Then
                Button15.BackColor = Color.Lime
                Button15.Select()
            End If

            If Button16.Text = lblPkey.Text Then
                Button16.BackColor = Color.Lime
                Button16.Select()
            End If

            If Button17.Text = lblPkey.Text Then
                Button17.BackColor = Color.Lime
                Button17.Select()
            End If

            If Button18.Text = lblPkey.Text Then
                Button18.BackColor = Color.Lime
                Button18.Select()
            End If

            If Button19.Text = lblPkey.Text Then
                Button19.BackColor = Color.Lime
                Button19.Select()
            End If

            If Button20.Text = lblPkey.Text Then
                Button20.BackColor = Color.Lime
                Button20.Select()
            End If

            If Button21.Text = lblPkey.Text Then
                Button21.BackColor = Color.Lime
                Button21.Select()
            End If

            If Button22.Text = lblPkey.Text Then
                Button22.BackColor = Color.Lime
                Button22.Select()
            End If

            If Button23.Text = lblPkey.Text Then
                Button23.BackColor = Color.Lime
                Button23.Select()
            End If

            If Button24.Text = lblPkey.Text Then
                Button24.BackColor = Color.Lime
                Button24.Select()
            End If

            If Button25.Text = lblPkey.Text Then
                Button25.BackColor = Color.Lime
                Button25.Select()
            End If

            If Button26.Text = lblPkey.Text Then
                Button26.BackColor = Color.Lime
                Button26.Select()
            End If

            If Button27.Text = lblPkey.Text Then
                Button27.BackColor = Color.Lime
                Button27.Select()
            End If

            If Button28.Text = lblPkey.Text Then
                Button28.BackColor = Color.Lime
                Button28.Select()
            End If

            If Button29.Text = lblPkey.Text Then
                Button29.BackColor = Color.Lime
                Button29.Select()
            End If

            If Button30.Text = lblPkey.Text Then
                Button30.BackColor = Color.Lime
                Button30.Select()
            End If

            If Button31.Text = lblPkey.Text Then
                Button31.BackColor = Color.Lime
                Button31.Select()
            End If

            If Button32.Text = lblPkey.Text Then
                Button32.BackColor = Color.Lime
                Button32.Select()
            End If

            If Button33.Text = lblPkey.Text Then
                Button33.BackColor = Color.Lime
                Button33.Select()
            End If

            If Button34.Text = lblPkey.Text Then
                Button34.BackColor = Color.Lime
                Button34.Select()
            End If

            If Button35.Text = lblPkey.Text Then
                Button35.BackColor = Color.Lime
                Button35.Select()
            End If

            If Button36.Text = lblPkey.Text Then
                Button36.BackColor = Color.Lime
                Button36.Select()
            End If

            If Button37.Text = lblPkey.Text Then
                Button37.BackColor = Color.Lime
                Button37.Select()
            End If

            If Button38.Text = lblPkey.Text Then
                Button38.BackColor = Color.Lime
                Button38.Select()
            End If

            If Button39.Text = lblPkey.Text Then
                Button39.BackColor = Color.Lime
                Button39.Select()
            End If

            If Button40.Text = lblPkey.Text Then
                Button40.BackColor = Color.Lime
                Button40.Select()
            End If

            If Button41.Text = lblPkey.Text Then
                Button41.BackColor = Color.Lime
                Button41.Select()
            End If

            If Button42.Text = lblPkey.Text Then
                Button42.BackColor = Color.Lime
                Button42.Select()
            End If

            If Button43.Text = lblPkey.Text Then
                Button43.BackColor = Color.Lime
                Button43.Select()
            End If

            If Button44.Text = lblPkey.Text Then
                Button44.BackColor = Color.Lime
                Button44.Select()
            End If

            If Button45.Text = lblPkey.Text Then
                Button45.BackColor = Color.Lime
                Button45.Select()
            End If

            If Button46.Text = lblPkey.Text Then
                Button46.BackColor = Color.Lime
                Button46.Select()
            End If

            If Button47.Text = lblPkey.Text Then
                Button47.BackColor = Color.Lime
                Button47.Select()
            End If

            If Button48.Text = lblPkey.Text Then
                Button48.BackColor = Color.Lime
                Button48.Select()
            End If

            If Button49.Text = lblPkey.Text Then
                Button49.BackColor = Color.Lime
                Button49.Select()
            End If

            If Button50.Text = lblPkey.Text Then
                Button50.BackColor = Color.Lime
                Button50.Select()
            End If
        End If
    End Sub

    Sub fokusHalaman()
        If Button1.Text = lblPkey.Text Then
            Button1.Select()
        End If

        If Button2.Text = lblPkey.Text Then
            Button2.Select()
        End If

        If Button3.Text = lblPkey.Text Then
            Button3.Select()
        End If

        If Button4.Text = lblPkey.Text Then
            Button4.Select()
        End If

        If Button5.Text = lblPkey.Text Then
            Button5.Select()
        End If

        If Button6.Text = lblPkey.Text Then
            Button6.Select()
        End If

        If Button7.Text = lblPkey.Text Then
            Button7.Select()
        End If

        If Button8.Text = lblPkey.Text Then
            Button8.Select()
        End If

        If Button9.Text = lblPkey.Text Then
            Button9.Select()
        End If

        If Button10.Text = lblPkey.Text Then
            Button10.Select()
        End If

        If Button11.Text = lblPkey.Text Then
            Button11.Select()
        End If

        If Button12.Text = lblPkey.Text Then
            Button12.Select()
        End If

        If Button13.Text = lblPkey.Text Then
            Button13.Select()
        End If

        If Button14.Text = lblPkey.Text Then
            Button14.Select()
        End If

        If Button15.Text = lblPkey.Text Then
            Button15.Select()
        End If

        If Button16.Text = lblPkey.Text Then
            Button16.Select()
        End If

        If Button17.Text = lblPkey.Text Then
            Button17.Select()
        End If

        If Button18.Text = lblPkey.Text Then
            Button18.Select()
        End If

        If Button19.Text = lblPkey.Text Then
            Button19.Select()
        End If

        If Button20.Text = lblPkey.Text Then
            Button20.Select()
        End If

        If Button21.Text = lblPkey.Text Then
            Button21.Select()
        End If

        If Button22.Text = lblPkey.Text Then
            Button22.Select()
        End If

        If Button23.Text = lblPkey.Text Then
            Button23.Select()
        End If

        If Button24.Text = lblPkey.Text Then
            Button24.Select()
        End If

        If Button25.Text = lblPkey.Text Then
            Button25.Select()
        End If

        If Button26.Text = lblPkey.Text Then
            Button26.Select()
        End If

        If Button27.Text = lblPkey.Text Then
            Button27.Select()
        End If

        If Button28.Text = lblPkey.Text Then
            Button28.Select()
        End If

        If Button29.Text = lblPkey.Text Then
            Button29.Select()
        End If

        If Button30.Text = lblPkey.Text Then
            Button30.Select()
        End If

        If Button31.Text = lblPkey.Text Then
            Button31.Select()
        End If

        If Button32.Text = lblPkey.Text Then
            Button32.Select()
        End If

        If Button33.Text = lblPkey.Text Then
            Button33.Select()
        End If

        If Button34.Text = lblPkey.Text Then
            Button34.Select()
        End If

        If Button35.Text = lblPkey.Text Then
            Button35.Select()
        End If

        If Button36.Text = lblPkey.Text Then
            Button36.Select()
        End If

        If Button37.Text = lblPkey.Text Then
            Button37.Select()
        End If

        If Button38.Text = lblPkey.Text Then
            Button38.Select()
        End If

        If Button39.Text = lblPkey.Text Then
            Button39.Select()
        End If

        If Button40.Text = lblPkey.Text Then
            Button40.Select()
        End If

        If Button41.Text = lblPkey.Text Then
            Button41.Select()
        End If

        If Button42.Text = lblPkey.Text Then
            Button42.Select()
        End If

        If Button43.Text = lblPkey.Text Then
            Button43.Select()
        End If

        If Button44.Text = lblPkey.Text Then
            Button44.Select()
        End If

        If Button45.Text = lblPkey.Text Then
            Button45.Select()
        End If

        If Button46.Text = lblPkey.Text Then
            Button46.Select()
        End If

        If Button47.Text = lblPkey.Text Then
            Button47.Select()
        End If

        If Button48.Text = lblPkey.Text Then
            Button48.Select()
        End If

        If Button49.Text = lblPkey.Text Then
            Button49.Select()
        End If

        If Button50.Text = lblPkey.Text Then
            Button50.Select()
        End If
    End Sub

    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles btnMark.Click
        If Button1.Text = lblPkey.Text Then
            Button1.BackColor = Color.Yellow
            Button1.Select()
        End If

        If Button2.Text = lblPkey.Text Then
            Button2.BackColor = Color.Yellow
            Button2.Select()
        End If

        If Button3.Text = lblPkey.Text Then
            Button3.BackColor = Color.Yellow
            Button3.Select()
        End If

        If Button4.Text = lblPkey.Text Then
            Button4.BackColor = Color.Yellow
            Button4.Select()
        End If

        If Button5.Text = lblPkey.Text Then
            Button5.BackColor = Color.Yellow
            Button5.Select()
        End If

        If Button6.Text = lblPkey.Text Then
            Button6.BackColor = Color.Yellow
            Button6.Select()
        End If

        If Button7.Text = lblPkey.Text Then
            Button7.BackColor = Color.Yellow
            Button7.Select()
        End If

        If Button8.Text = lblPkey.Text Then
            Button8.BackColor = Color.Yellow
            Button8.Select()
        End If

        If Button9.Text = lblPkey.Text Then
            Button9.BackColor = Color.Yellow
            Button9.Select()
        End If

        If Button10.Text = lblPkey.Text Then
            Button10.BackColor = Color.Yellow
            Button10.Select()
        End If

        If Button11.Text = lblPkey.Text Then
            Button11.BackColor = Color.Yellow
            Button11.Select()
        End If

        If Button12.Text = lblPkey.Text Then
            Button12.BackColor = Color.Yellow
            Button12.Select()
        End If

        If Button13.Text = lblPkey.Text Then
            Button13.BackColor = Color.Yellow
            Button13.Select()
        End If

        If Button14.Text = lblPkey.Text Then
            Button14.BackColor = Color.Yellow
            Button14.Select()
        End If

        If Button15.Text = lblPkey.Text Then
            Button15.BackColor = Color.Yellow
            Button15.Select()
        End If

        If Button16.Text = lblPkey.Text Then
            Button16.BackColor = Color.Yellow
            Button16.Select()
        End If

        If Button17.Text = lblPkey.Text Then
            Button17.BackColor = Color.Yellow
            Button17.Select()
        End If

        If Button18.Text = lblPkey.Text Then
            Button18.BackColor = Color.Yellow
            Button18.Select()
        End If

        If Button19.Text = lblPkey.Text Then
            Button19.BackColor = Color.Yellow
            Button19.Select()
        End If

        If Button20.Text = lblPkey.Text Then
            Button20.BackColor = Color.Yellow
            Button20.Select()
        End If

        If Button21.Text = lblPkey.Text Then
            Button21.BackColor = Color.Yellow
            Button21.Select()
        End If

        If Button22.Text = lblPkey.Text Then
            Button22.BackColor = Color.Yellow
            Button22.Select()
        End If

        If Button23.Text = lblPkey.Text Then
            Button23.BackColor = Color.Yellow
            Button23.Select()
        End If

        If Button24.Text = lblPkey.Text Then
            Button24.BackColor = Color.Yellow
            Button24.Select()
        End If

        If Button25.Text = lblPkey.Text Then
            Button25.BackColor = Color.Yellow
            Button25.Select()
        End If

        If Button26.Text = lblPkey.Text Then
            Button26.BackColor = Color.Yellow
            Button26.Select()
        End If

        If Button27.Text = lblPkey.Text Then
            Button27.BackColor = Color.Yellow
            Button27.Select()
        End If

        If Button28.Text = lblPkey.Text Then
            Button28.BackColor = Color.Yellow
            Button28.Select()
        End If

        If Button29.Text = lblPkey.Text Then
            Button29.BackColor = Color.Yellow
            Button29.Select()
        End If

        If Button30.Text = lblPkey.Text Then
            Button30.BackColor = Color.Yellow
            Button30.Select()
        End If

        If Button31.Text = lblPkey.Text Then
            Button31.BackColor = Color.Yellow
            Button31.Select()
        End If

        If Button32.Text = lblPkey.Text Then
            Button32.BackColor = Color.Yellow
            Button32.Select()
        End If

        If Button33.Text = lblPkey.Text Then
            Button33.BackColor = Color.Yellow
            Button33.Select()
        End If

        If Button34.Text = lblPkey.Text Then
            Button34.BackColor = Color.Yellow
            Button34.Select()
        End If

        If Button35.Text = lblPkey.Text Then
            Button35.BackColor = Color.Yellow
            Button35.Select()
        End If

        If Button36.Text = lblPkey.Text Then
            Button36.BackColor = Color.Yellow
            Button36.Select()
        End If

        If Button37.Text = lblPkey.Text Then
            Button37.BackColor = Color.Yellow
            Button37.Select()
        End If

        If Button38.Text = lblPkey.Text Then
            Button38.BackColor = Color.Yellow
            Button38.Select()
        End If

        If Button39.Text = lblPkey.Text Then
            Button39.BackColor = Color.Yellow
            Button39.Select()
        End If

        If Button40.Text = lblPkey.Text Then
            Button40.BackColor = Color.Yellow
            Button40.Select()
        End If

        If Button41.Text = lblPkey.Text Then
            Button41.BackColor = Color.Yellow
            Button41.Select()
        End If

        If Button42.Text = lblPkey.Text Then
            Button42.BackColor = Color.Yellow
            Button42.Select()
        End If

        If Button43.Text = lblPkey.Text Then
            Button43.BackColor = Color.Yellow
            Button43.Select()
        End If

        If Button44.Text = lblPkey.Text Then
            Button44.BackColor = Color.Yellow
            Button44.Select()
        End If

        If Button45.Text = lblPkey.Text Then
            Button45.BackColor = Color.Yellow
            Button45.Select()
        End If

        If Button46.Text = lblPkey.Text Then
            Button46.BackColor = Color.Yellow
            Button46.Select()
        End If

        If Button47.Text = lblPkey.Text Then
            Button47.BackColor = Color.Yellow
            Button47.Select()
        End If

        If Button48.Text = lblPkey.Text Then
            Button48.BackColor = Color.Yellow
            Button48.Select()
        End If

        If Button49.Text = lblPkey.Text Then
            Button49.BackColor = Color.Yellow
            Button49.Select()
        End If

        If Button50.Text = lblPkey.Text Then
            Button50.BackColor = Color.Yellow
            Button50.Select()
        End If
    End Sub

    Private Sub Button51_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        resetJawaban()
        If lblPkey.Text = 2 Then
            btnPrev.Visible = False
        ElseIf lblPkey.Text = 50 Then
            btnNext.Visible = True
        End If
        data()
        For i = 0 To ds.Tables("soal").Rows.Count - 1
            If lblPkey.Text = ds.Tables("soal").Rows(i)(0) Then
                lblPkey.Text = ds.Tables("soal").Rows(i - 1)(0)
                TextBox1.Text = ds.Tables("soal").Rows(i - 1)(1)
                RadioButton1.Text = ds.Tables("soal").Rows(i - 1)(2)
                RadioButton2.Text = ds.Tables("soal").Rows(i - 1)(3)
                RadioButton3.Text = ds.Tables("soal").Rows(i - 1)(4)
                RadioButton4.Text = ds.Tables("soal").Rows(i - 1)(5)
                RadioButton5.Text = ds.Tables("soal").Rows(i - 1)(6)
                Exit For
            End If
        Next
        da.Dispose()
        lacakJawaban()
        fokusHalaman()
    End Sub

    Private Sub Button52_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        kondisiMulai()
        resetJawaban()
        If lblPkey.Text = 49 Then
            btnNext.Visible = False
        End If
        data()
        For i = 0 To ds.Tables("soal").Rows.Count - 1
            If lblPkey.Text = ds.Tables("soal").Rows(i)(0) Then
                lblPkey.Text = ds.Tables("soal").Rows(i + 1)(0)
                TextBox1.Text = ds.Tables("soal").Rows(i + 1)(1)
                RadioButton1.Text = ds.Tables("soal").Rows(i + 1)(2)
                RadioButton2.Text = ds.Tables("soal").Rows(i + 1)(3)
                RadioButton3.Text = ds.Tables("soal").Rows(i + 1)(4)
                RadioButton4.Text = ds.Tables("soal").Rows(i + 1)(5)
                RadioButton5.Text = ds.Tables("soal").Rows(i + 1)(6)
                Exit For
            End If
        Next
        da.Dispose()
        lacakJawaban()
        fokusHalaman()
    End Sub

    Sub waktuHabis()
        kondisiAkhir()
        TextBox1.Text = ""
        btnPrev.Visible = False
        btnNext.Visible = False
        btnEnd.Select()
        btnEnd.Visible = True
        btnEnd2.Visible = False
        lblNotice.Visible = True
        lblNotice.Text = "Terima Kasih telah mengerjakan Tes ini. Dari Tim kami pengembang dan pembuat (Aji, Diyah, dan Safar). Silahkan tekan tombol >> Akhiri Tes << untuk melihat hasil Tes Anda."
        validasiNilai()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim wkt As TimeSpan = waktu.Subtract(DateTime.Now)
        If wkt.TotalSeconds > 0 Then
            lblTime.Text = wkt.ToString("hh\:mm\:ss")
        Else
            lblTime.Text = "00:00:00"
            Timer1.Stop()
            MessageBox.Show("Waktu Anda Habis", "Informasi")
            waktuHabis()
        End If
    End Sub

    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        validasiNilai()
        Timer1.Stop()
        Form3.Timer1.Stop()
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Button54_Click(sender As Object, e As EventArgs) Handles btnEnd2.Click
        btnPrev.Visible = False
        btnNext.Visible = False
        btnEnd.Visible = True
        btnEnd.Select()
        btnEnd2.Visible = False
        btnMark.Visible = False
        RadioButton1.Visible = False
        RadioButton2.Visible = False
        RadioButton3.Visible = False
        RadioButton4.Visible = False
        RadioButton5.Visible = False
        TextBox1.Text = ""
        lblPkey.Text = "00"
        lblNotice.Visible = True
    End Sub

    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Form3.setNull()
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        validasiJawaban(RadioButton1)
        validasiTerjawab()
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        validasiJawaban(RadioButton2)
        validasiTerjawab()
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        validasiJawaban(RadioButton3)
        validasiTerjawab()
    End Sub

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        validasiJawaban(RadioButton4)
        validasiTerjawab()
    End Sub

    Private Sub RadioButton5_Click(sender As Object, e As EventArgs) Handles RadioButton5.Click
        validasiJawaban(RadioButton5)
        validasiTerjawab()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        resetJawaban()
        btnPrev.Visible = False
        btnNext.Visible = True
        btnEnd.Visible = False
        btnEnd2.Visible = True
        btnMark.Visible = True
        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = True
        RadioButton4.Visible = True
        RadioButton5.Visible = True
        lblNotice.Visible = False
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button1.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button2.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button3.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button4.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button5.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button6.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button7.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button8.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button9.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button10.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button11.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button12.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button13.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button14.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button15.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button16.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button17.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button18.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button19.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button20.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub
    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button21.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button22.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button23.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button24.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button25.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button26.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button27.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button28.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button29.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button30.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button31.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button32.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button33.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button34.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button35.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button36.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button37.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button38.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button39.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button40.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button41.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button42.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button43.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button44.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button45.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button46.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button47.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button48.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = True
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button49.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        resetJawaban()
        kondisiMulai()
        btnPrev.Visible = True
        btnNext.Visible = False
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM soal WHERE no = '" & Button50.Text & "'
        ", conn)
        pilihan()
        lacakJawaban()
    End Sub

End Class