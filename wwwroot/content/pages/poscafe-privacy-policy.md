---
title: Privacy Policy PosCafe
date: 2026-09-09
description: Privacy policy for PosCafe.
draft: false
---

# Kebijakan Privasi — PosCafe

**Berlaku efektif:** 9 September 2026
**Terakhir diperbarui:** 10 September 2026

**Aplikasi:** PosCafe (Point of Sale untuk café / coffee shop)
**Pengembang:** Novrian

---

## Ringkasan

Semua data usaha yang Anda masukkan dan hasilkan (menu, transaksi, pengaturan toko)
disimpan **secara lokal di perangkat Anda** menggunakan basis data SQLite. Bagian POS
ini **tidak memiliki server**, **tidak memerlukan akun atau login**, dan **tidak
mengirim data usaha Anda ke mana pun**. Data usaha hanya meninggalkan perangkat jika
**Anda sendiri** yang membagikannya lewat fitur *Backup* atau *Ekspor Excel* (mis.
menyimpan file ke Google Drive atau mengirim lewat email).

PosCafe **menampilkan iklan** dari **Google AdMob**. Untuk menayangkan iklan, AdMob
(pihak ketiga) mengakses **advertising ID** perangkat dan data terkait iklan. Anda
dapat menghilangkan seluruh iklan lewat pembelian sekali bayar **"Bebas Iklan"** di
Google Play, atau dengan menukar **kode voucher**. Selain AdMob, PosCafe tidak memakai
analitik, *crash reporting*, atau pelacakan lain.

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

## Iklan (Google AdMob)

PosCafe menampilkan iklan banner dan iklan interstitial melalui **Google AdMob**. SDK
AdMob berjalan di dalam aplikasi dan, untuk memilih serta mengukur iklan, dapat
mengakses dan mengirim ke Google:

- **Advertising ID** perangkat (identitas iklan yang dapat direset pengguna di
  Setelan Android) dan penanda perangkat kasar lainnya.
- Alamat IP, jenis perangkat, sistem operasi, dan interaksi dengan iklan
  (tayang / klik).

Data ini diproses Google sesuai
[Kebijakan Privasi Google](https://policies.google.com/privacy) dan
[cara Google menggunakan data saat Anda memakai situs/aplikasi mitra](https://policies.google.com/technologies/partner-sites).
Untuk pengguna di wilayah yang mewajibkan (mis. EEA/UK), PosCafe menampilkan
formulir persetujuan (consent) Google sebelum iklan personalisasi dimuat.

PosCafe **tidak** membagikan data usaha Anda (menu, transaksi, pengaturan toko) kepada
AdMob atau jaringan iklan mana pun.

## Pembelian dalam aplikasi & voucher

- **Bebas Iklan** adalah produk sekali beli melalui **Google Play Billing**. Seluruh
  proses pembayaran ditangani Google Play; PosCafe tidak melihat atau menyimpan data
  kartu / pembayaran Anda. Yang disimpan aplikasi hanyalah sebuah **penanda lokal**
  bahwa iklan dimatikan.
- **Kode voucher** divalidasi sepenuhnya di perangkat (offline). Kode yang Anda
  masukkan hanya disimpan lokal untuk menandai status Bebas Iklan; tidak dikirim ke
  mana pun.
- **Pulihkan Pembelian** menanyakan ke Google Play apakah akun Google Anda memiliki
  produk "Bebas Iklan", lalu mengaktifkannya kembali di perangkat ini.

---

## Yang TIDAK dilakukan aplikasi

- Tidak ada registrasi, login, atau profil pengguna.
- Tidak mengirim data **usaha** Anda ke server pengembang atau pihak ketiga mana pun.
- Tidak menggunakan SDK analitik atau *crash reporting*.
- Tidak menjual data Anda. Satu-satunya data yang dibagikan adalah penanda perangkat
  untuk iklan, kepada Google AdMob, sebagaimana dijelaskan di atas — dan itu berhenti
  sepenuhnya setelah Anda mengaktifkan Bebas Iklan.

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
| `INTERNET`, `ACCESS_NETWORK_STATE` | Dipakai oleh SDK Google AdMob (memuat iklan) dan Google Play Billing (memproses pembelian & pemulihan). **Tidak** dipakai untuk mengirim data usaha Anda. |
| `com.google.android.gms.permission.AD_ID` | Mengizinkan SDK AdMob membaca advertising ID perangkat untuk penayangan iklan. Setelah Bebas Iklan aktif, iklan tidak lagi dimuat. |
| `com.android.vending.BILLING` | Diperlukan Google Play Billing untuk pembelian "Bebas Iklan" dan "Pulihkan Pembelian". |

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
