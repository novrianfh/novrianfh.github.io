# Kebijakan Privasi — PosCafe

**Berlaku sejak:** 9 September 2026
**Aplikasi:** PosCafe (Point of Sale untuk café / coffee shop)
**Pengembang:** Novrian

---

## Ringkasan

PosCafe adalah aplikasi **offline penuh**. Semua data yang Anda masukkan dan hasilkan
disimpan **secara lokal di perangkat Anda** menggunakan basis data SQLite. Aplikasi ini
**tidak memiliki server**, **tidak memerlukan akun atau login**, dan **tidak mengirim data
Anda ke mana pun**. Tidak ada iklan, analitik, atau pelacakan.

Data hanya bisa meninggalkan perangkat jika **Anda sendiri** yang membagikannya melalui
fitur *Backup* atau *Ekspor Excel* (mis. menyimpan file ke Google Drive atau mengirim
lewat email).

---

## Data yang disimpan

Seluruh data berikut disimpan **hanya di penyimpanan privat aplikasi pada perangkat**:

| Kategori | Contoh isi |
|---|---|
| **Informasi toko** (Anda yang mengisi) | Nama toko, alamat, nomor telepon, simbol mata uang, tarif pajak (PB1) & service charge, prefix nomor order, teks footer struk |
| **Data katalog** | Kategori (termasuk ikon emoji), menu, varian, modifier / add-on, daftar meja |
| **Transaksi** | Pesanan, item pesanan, catatan, pembayaran (metode: Cash / QRIS / Transfer / Card / Other, jumlah, uang diterima, kembalian, nomor referensi opsional), status order & pembayaran, waktu transaksi |
| **Gambar menu (opsional)** | Foto yang Anda pilih dari galeri; **disalin** ke folder privat aplikasi (`menu-images/`) |
| **ID instalasi** | Sebuah nilai acak (GUID) yang dibuat saat aplikasi pertama dijalankan, disimpan di penyimpanan preferensi aplikasi, dan dilekatkan pada setiap pesanan/pembayaran untuk keperluan audit internal. **Bukan** ID perangkat keras, nomor IMEI, atau identitas iklan, dan tidak terhubung ke identitas apa pun di luar perangkat. |

PosCafe **tidak** mengumpulkan: lokasi, kontak, kalender, mikrofon/kamera untuk perekaman,
identitas pelanggan, data biometrik, atau informasi akun.

---

## Yang TIDAK dilakukan aplikasi

- Tidak ada registrasi, login, atau profil pengguna.
- Tidak mengirim data ke server pengembang atau pihak ketiga mana pun.
- Tidak menampilkan iklan.
- Tidak menggunakan SDK analitik, *crash reporting*, atau pelacakan.
- Tidak menjual atau membagikan data ke siapa pun.

---

## Berbagi data oleh Anda

Aplikasi menyediakan dua fitur yang membuat berkas dan kemudian membuka *share sheet*
bawaan sistem operasi:

- **Backup Database** (Pengaturan → *Backup Sekarang*): membuat salinan berkas `.db`.
- **Ekspor Excel** (Dashboard, Laporan Penjualan, Riwayat Order): membuat berkas `.xlsx`.
- **Struk**: membagikan/menyimpan struk sebagai teks atau gambar.

Berkas-berkas ini hanya keluar dari perangkat jika Anda memilih membagikannya. Setelah
berkas berpindah ke layanan lain (mis. Google Drive, Gmail, WhatsApp), berkas tersebut
tunduk pada kebijakan privasi layanan tersebut dan menjadi tanggung jawab Anda.

---

## Izin Android

| Izin | Alasan |
|---|---|
| `READ_MEDIA_IMAGES` / `READ_EXTERNAL_STORAGE` (hingga Android 12) | Agar Anda dapat memilih gambar menu dari galeri. Gambar disalin ke penyimpanan privat aplikasi; aplikasi tidak memindai atau mengunggah galeri Anda. |
| `INTERNET`, `ACCESS_NETWORK_STATE` | Dideklarasikan sebagai bawaan kerangka kerja .NET MAUI. PosCafe **tidak menggunakannya untuk mengirim data Anda**. |

---

## Penyimpanan, keamanan, dan retensi

- Data berada di direktori privat aplikasi (`AppDataDirectory`), yang dilindungi oleh
  *sandbox* aplikasi Android dan tidak dapat diakses aplikasi lain pada perangkat yang
  tidak di-*root*.
- Aplikasi tidak menambahkan enkripsi tersendiri di atas penyimpanan sistem. Untuk
  keamanan tambahan, aktifkan kunci layar dan enkripsi perangkat.
- Data disimpan selama Anda menyimpannya. Anda dapat menghapus item satu per satu dari
  dalam aplikasi. Menghapus aplikasi (*uninstall*) atau menjalankan *Clear data* akan
  menghapus seluruh basis data lokal, gambar menu yang disalin, dan berkas backup yang
  masih berada di dalam folder aplikasi. Berkas yang sudah Anda bagikan ke luar tidak
  ikut terhapus.

---

## Anak-anak

PosCafe adalah alat bantu operasional usaha dan tidak ditujukan untuk anak-anak.

---

## Perubahan kebijakan

Kebijakan ini dapat diperbarui seiring perkembangan aplikasi. Perubahan akan tercermin
pada berkas ini beserta tanggal "Berlaku sejak" yang diperbarui.

---

## Kontak

Pertanyaan, saran, atau kritik terkait privasi:

- Email: **thenovrianmail@gmail.com**
- Instagram: **@nvrnfjr**
