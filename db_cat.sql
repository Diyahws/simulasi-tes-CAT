-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 27 Bulan Mei 2022 pada 09.09
-- Versi server: 10.4.24-MariaDB
-- Versi PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_cat`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `peserta`
--

CREATE TABLE `peserta` (
  `no_peserta` int(11) NOT NULL,
  `nama` varchar(225) NOT NULL,
  `email` varchar(225) NOT NULL,
  `tanggal` datetime NOT NULL,
  `nilai` int(11) NOT NULL,
  `keterangan` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `peserta`
--

INSERT INTO `peserta` (`no_peserta`, `nama`, `email`, `tanggal`, `nilai`, `keterangan`) VALUES
(1, 'Peserta1', 'peserta1@email.com', '2022-05-27 10:51:31', 0, 'TIDAK LULUS'),
(2, 'Peserta2', 'peserta2@email,com', '2022-05-27 10:52:25', 0, 'TIDAK LULUS'),
(3, 'Peserta3', 'peserta3@email.com', '2022-05-27 10:42:24', 0, 'TIDAK LULUS'),
(4, 'Peserta4', 'peserta4@email.com', '2022-05-27 05:06:48', 10, 'TIDAK LULUS'),
(5, 'Peserta5', 'peserta5@email.com', '2022-05-27 10:37:09', 10, 'TIDAK LULUS');

-- --------------------------------------------------------

--
-- Struktur dari tabel `soal`
--

CREATE TABLE `soal` (
  `no` varchar(11) NOT NULL,
  `pertanyaan` varchar(255) NOT NULL,
  `pilihan1` varchar(255) NOT NULL,
  `pilihan2` varchar(255) NOT NULL,
  `pilihan3` varchar(255) NOT NULL,
  `pilihan4` varchar(255) NOT NULL,
  `pilihan5` varchar(255) NOT NULL,
  `jawaban` varchar(255) NOT NULL,
  `jawaban_peserta` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `soal`
--

INSERT INTO `soal` (`no`, `pertanyaan`, `pilihan1`, `pilihan2`, `pilihan3`, `pilihan4`, `pilihan5`, `jawaban`, `jawaban_peserta`) VALUES
('01', 'Suatu instruksi yang digunakan computer untuk memecahkan masalah atau tugas yang diberikan dari brainware (pengguna) disebut', 'Kegiatan', 'Diskusi', 'Program computer', 'Alur pemrograman', 'Algoritma', 'Program computer', NULL),
('02', 'Sistem operasi merupakan perangkat lunak yang berguna untuk mengaktifkan', 'Seluruh program', 'Sebagian program', 'Sebagian perangkat keras', 'Seluruh perangkat keras', 'Seluruh perangkat keras dan program', 'Seluruh perangkat keras', NULL),
('03', 'Orang yang profesinya membuat program disebut', 'Investor', 'Owner', 'Programmer', 'Staff', 'Entrepreneur', 'Programmer', NULL),
('04', 'Bahasa mesin terdiri dari angka atau nilai', '0 dan 1', '1 dan 2', '0 dan 3', '2 dan 4', '1 dan 3', '0 dan 1', NULL),
('05', 'Type data ini merupakan type variabel istimewa, yang dimaksud type data data tersebut adalah', 'Variant', 'Byte', 'Integer', 'Boolean', 'Single', 'Variant', NULL),
('06', 'Label1.caption = text1.text * text2.text, baris program tersebut', 'Salah, harusnya Label1 dirubah jadi text3', 'Salah, hasilnya error', 'Salah, harusnya Caption diganti text', 'Benar, Caption tidak perlu dirubah', 'Benar, tapi hasilnya error', 'Benar, Caption tidak perlu dirubah', NULL),
('07', 'Secara default saat kita mengambil control text box ke form design, name properties caption-nya adalah', 'Label1', 'Text1', 'Caption', 'Header', 'Textbox', 'Text1', NULL),
('08', 'Untuk menambahkan Form baru pada Visual basic, sebelumnya kita Add Form dari menu', 'File', 'Edit', 'Project', 'Help', 'Insert', 'Project', NULL),
('09', 'Untuk menjalankan Form yang lain pada satu project, dapat juga menggunakan tombol fungsi', 'F1', 'F2', 'F3', 'F4', 'F5', 'F5', NULL),
('10', 'Memilih boleh beberapa pilihan sekaligus adalah fungsi dari control', 'CheckBox', 'TextBox', 'Label', 'Option Button', 'Frame', 'CheckBox', NULL),
('11', 'Pada Ms. Visual Basic, control yang digunakan untuk menampilkan teks yang tidak dapat diperbaiki oleh pemakai adalah', 'CheckBox', 'TextBox', 'Label', 'Option Button', 'Frame', 'Label', NULL),
('12', 'Pada Ms. Visual Basic untuk menempatkan posisi kursor yang diiginkan adalah', 'Pointer', 'Sel', 'DataField', 'SetFocus', 'Jawaban a, b, c dan d salah', 'SetFocus', NULL),
('13', 'Ekstensi file project visual basic adalah', '.FRM', '.DOC', '.XLS', '.VBP', '.VBF', '.VBP', NULL),
('14', 'Baris dari : FORM2.Print \"2\" + \"4\", menghasilkan', '8', '6', '2', '24', '42', '24', NULL),
('15', 'Pada Ms. Basic, dibawah ini semua adalah menu bar, kecuali', 'Debug', 'Insert', 'Window', 'Diagram', 'Query', 'Insert', NULL),
('16', 'Pada Ms. Visual Basic, Type data yang mempunyai ukuran 16 byte adalah', 'Object', 'Variant', 'Boolean', 'Byte', 'Format', 'Variant', NULL),
('17', 'essage yang tampil jika salah dalam pemberian nama suatu control objek adalah', 'Not a legal object name', 'Illegal operation', 'No legal name', 'Not object name', 'Illegal name', 'Not a legal object name', NULL),
('18', 'Tampilan yang berisi gambaran dari semua modul terlihat pada', 'Jendela Project', 'Jendela Form Design', 'Jendela Tool Box', 'Jendela Code', 'Jendela Properties', 'Jendela Project', NULL),
('19', 'Suatu kontrol dapat ditampilkan tapi tidak bisa diakses langsung, maka sebelumnya merubah properties', 'Enabled', 'Visible', 'Value', 'Validate', 'Name', 'Enabled', NULL),
('20', 'Type data Byte yang mempunyai jangkauan nilai', '2 s/d 255', '–1 s/d 255', '1 s/d 265', '0 s/d 255', '1 s/d 255', '1 s/d 255', NULL),
('21', 'Pada Microsoft Visual Basic, yang dimaksud dengan metode dibawah ini adalah', 'Record Source', 'Toolbox', 'MoveNext', 'Adodc', 'dbgrid', 'MoveNext', NULL),
('22', 'Pada ms. Visual basic 6.0, yang dimaksud dengan properties di bawah ini adalah', 'Recordsourcev', 'Toolbox', 'Click', 'MoveNext', 'Adodc', 'Recordsource', NULL),
('23', 'Salah satu kegunaan dari Visual Basic adalah untuk membuat', 'Presentasi', 'Desain Gambar', 'Formulir', 'Surat', 'Dokumen', 'Formulir', NULL),
('24', 'Pada Microsoft Visual Basic 6.0, bila ingin menulis program, maka harus berada di', 'Jendela Code', 'Toolbox', 'Jendela Project', 'Jendela Properties', 'Jendela Windows', 'Jendela Code', NULL),
('25', 'Dalam koding program Visual Basic, perintah untuk langsung keluar dari program pada saat program dijalankan adalah', 'Exit', 'End', 'Close', 'Drop', 'Insert', 'End', NULL),
('26', 'Untuk membuat tulisan biasa digunakan komponen', 'Frame', 'Option Button', 'Label', 'ToolBox', 'ComboBox', 'Label', NULL),
('27', 'Untuk membuat sebuah tombol digunakan komponen', 'Command Botton', 'Label', 'ComboBox', 'ListBox', 'ToolBox', 'Command Botton', NULL),
('28', 'Untuk mengganti warna dari tulisan yang akan ditampilkan dalam Label atau TextBox digunakan property', 'Backcolor', 'Forecolor', 'Stylecolor', 'Fontcolor', 'Imagecolor', 'Fontcolor', NULL),
('29', 'Untuk membuat berbagai macam bentuk (elips, lingkaran, persegi) digunakan komponen yang disebut dengan', 'Image', 'Picture', 'Shape', 'Rectangle Tool', 'Caption', 'Shape', NULL),
('30', 'Pada sebuah ComboBox, untuk menambahkan atau mengentry tulisan atau daftar ke dalamnya kita menggunakan property yang disebut', 'Text', 'List', 'Name', 'Caption', 'Show', 'List', NULL),
('31', 'Dalam koding Visual Basic, perintah untuk menampilkan sebuah pesan adalah', 'MsgBox', 'Msg', 'Show', 'Display', 'List', 'MsgBox', NULL),
('32', 'Variable yang berisi karakter digunakan tipe data', 'Byte', 'Float', 'String', 'Boolean', 'Double', 'String', NULL),
('33', 'Sifat-sifat dari P. Visual Basic yaitu', 'Floating', 'Sizeable', 'Flexible', 'Floating-Sizeable-Dockable', 'Nothing', 'Floating-Sizeable-Dockable', NULL),
('34', 'Untuk menambahkan form yang baru langkah yang harus dilakukan adalah', 'File – New Form', 'Menu Project – Add Form', 'File – New – Form', 'Klik kanan pada jendela properties – Add – MdiForm', 'Menu Project - Properties', 'Menu Project – Add Form', NULL),
('35', 'Komponen dalam Visual Basic yang memberikan gambaran dari semua modul yang terdapat dalam aplikasi Anda yaitu', 'Project Window', 'Form Designer Window', ' Properties Window', 'Toolbox Window', 'Settings', 'Project Window', NULL),
('36', 'Penggantian judul form dapat dilakukan dengan', 'Klik kanan pada form – rename', ' Klik kanan – Edit', 'Menu edit – rename', ' Klik kanan – Delete', 'Jendela properties – caption – ganti namanya sesuai keinginan', 'Jendela properties – caption – ganti namanya sesuai keinginan', NULL),
('37', 'Fungsi kontrol Label adalah untuk', 'Menampilkan gambar yang tidak dapat di ubah oleh pengguna pada saat runtime atau saat dijalankan', 'Menampilkan option/pilihan yang tidak dapat di ubah oleh pengguna pada saat runtime atau saat dijalankan', 'Menampilkan tulisan/teks yang tidak dapat di ubah oleh pengguna pada saat runtime atau saat dijalankan', 'Menampilkan tulisan/teks yang dapat di ubah oleh pengguna pada saat runtime atau saat dijalankan', 'Jawaban a, b, c, dan d Benar', 'Menampilkan tulisan/teks yang tidak dapat di ubah oleh pengguna pada saat runtime atau saat dijalankan', NULL),
('38', 'Untuk menggabungkan 2 buah teks dan ditampilkan di label1, maka pernyataan berikut yang benar adalah', 'label1.caption=text1.caption+text2.caption', 'label1.caption=text1+text2', 'label1.caption=text1.text+text2.text', 'label1.caption=text1.text=text2.text', 'label1.caption=text1.text=text2', 'label1.caption=text1.text+text2.text', NULL),
('39', ' Apa fungsi dari kontrol CommandButton', 'Untuk menyediakan tombol bagi pemakai untuk melakukan fungsi-fungsi tertentu', 'untuk menyediakan tombol bagi pemakai untuk memasukan text', 'untuk menyediakan tombol bagi pemakai untuk menampilkan beberapa pilihan', 'untuk membuat tombol pada form yang dapat di klik', 'untuk menyediakan tombol bagi pemakai untuk memasukkan angka', 'Untuk menyediakan tombol bagi pemakai untuk melakukan fungsi-fungsi tertentu', NULL),
('40', 'Untuk menjumlahkan 2 buah teks dengan data berupa angka, misalkan 1+2 dan hasilnya ditampilkan pada label1 yaitu 3, maka pernyataan berikut yang benar adalah', 'label1.caption=text1.text+text2.text', 'text1.text=text2.text+label1.caption', 'label1.text=Cint(text.1.text)+Cint(text2.text)', 'label1.caption=text1.text=text2', 'label1.caption=Cint(text1.text)+Cint(text2.text)', 'label1.caption=Cint(text1.text)+Cint(text2.text)', NULL),
('41', 'Komponen dalam Visual Basic yang memberikan gambaran dari semua modul yang terdapat dalam aplikasi Anda yaitu', 'Project Window', 'Form Designer Window', 'Toolbox Window', 'Properties Window', 'Settings', 'Project Window', NULL),
('42', 'Untuk mengganti warna latar belakang pada form, yang di ubah pada bagian propertynya adalah', 'Background Color', 'Color Box', 'Caption', 'Back Color', 'Fore Color', 'Back Color', NULL),
('43', 'Dalam form, untuk membuat pilihan Gender (Jenis kelamin) biasanya digunakan komponen', 'TextBox', 'Option Button', 'ComboBox', 'Label', 'DataGridView', 'Option Button', NULL),
('44', 'Untuk mengatur waktu (jam) agar tampilannya menjadi per detik (second), maka ada sebuah property yang harus diubah, yaitu', 'Interval', 'Time', 'Date', 'Second', 'DateTime', 'Interval', NULL),
('45', 'Untuk menampilkan atau memanggil sebuah form digunakan perintah', 'Call', 'New', 'Show', 'Close', 'Form', 'Show', NULL),
('46', 'Untuk mendeklarasikan variable pada VB adalah pengertian dari', 'Dim', 'Float', 'Value', 'MOD', 'Double', 'Dim', NULL),
('47', 'Yang tidak termasuk ke dalam algoritma terstruktur adalah', 'Sequential', 'Integer', 'Selection', 'Iterasi', 'Text', 'Integer', NULL),
('48', 'Dibawah ini yang tidak termasuk ke dalam operator aritmatika adalah', 'MOD', '+', '=', '/', '-', 'MOD', NULL),
('49', 'Lakukan dulu baru cek adalah pengertian dari', 'While do', 'Do while', 'Loop', 'Do', 'Case', 'Do while', NULL),
('50', 'Apakah yang dimaksud dangan while do', 'Cek dulu baru lakukan', 'Lakukan dulu baru cek', 'Tidak mengecek sama sekali', 'Tidak melakukan dan tidak mengecek', 'Tidak mengecek dan lakukan', 'Cek dulu baru lakukan', NULL);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `peserta`
--
ALTER TABLE `peserta`
  ADD PRIMARY KEY (`no_peserta`);

--
-- Indeks untuk tabel `soal`
--
ALTER TABLE `soal`
  ADD PRIMARY KEY (`no`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `peserta`
--
ALTER TABLE `peserta`
  MODIFY `no_peserta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
