---
title: Privacy Policy PosCafe English
date: 2026-09-10
description: English version of Privacy policy for PosCafe.
draft: false
---

# Privacy Policy — PosCafe EN

**Effective date:** September 10, 2026
**App:** PosCafe (Point of Sale for cafés / coffee shops)
**Developer:** Novrian

---

## Summary

All business data you enter and generate (menu, transactions, store settings) is
stored **locally on your device** using an SQLite database. The POS part of the app
**has no server**, **requires no account or login**, and **never sends your business
data anywhere**. Business data leaves your device only if **you** share it yourself,
using the *Backup* or *Excel Export* feature (e.g. saving a file to Google Drive or
sending it by email).

PosCafe **shows ads** served by **Google AdMob**. To serve ads, AdMob (a third party)
accesses the device's **advertising ID** and related ad data. You can remove all ads
with a one-time **"Remove Ads"** purchase on Google Play, or by redeeming a **voucher
code**. Other than AdMob, PosCafe does not use analytics, crash reporting, or any
other tracking.

---

## Data we store

All of the following is stored **only in the app's private storage on your device**:

| Category | Example content |
|---|---|
| **Store information** (entered by you) | Store name, address, phone number, currency symbol, tax rate (PB1) & service charge, order number prefix, receipt footer text |
| **Catalog data** | Categories (including emoji icons), menu items, variants, modifiers / add-ons, table list |
| **Transactions** | Orders, order items, notes, payments (method: Cash / QRIS / Transfer / Card / Other, amount, cash tendered, change, optional reference number), order & payment status, transaction timestamps |
| **Menu images (optional)** | Photos you pick from the gallery; **copied** into the app's private folder (`menu-images/`) |
| **Installation ID** | A random value (GUID) generated the first time the app runs, stored in app preferences, and attached to every order/payment for internal audit purposes. This is **not** a hardware device ID, IMEI number, or advertising identifier, and is not linked to any identity outside the device. |

PosCafe does **not** collect: location, contacts, calendar, microphone/camera
recordings, customer identity, biometric data, or account information.

---

## Advertising (Google AdMob)

PosCafe shows banner and interstitial ads via **Google AdMob**. The AdMob SDK runs
inside the app and, to select and measure ads, may access and send to Google:

- The device's **advertising ID** (an ad identifier you can reset in Android
  Settings) and other coarse device identifiers.
- IP address, device type, operating system, and ad interactions (impressions /
  clicks).

This data is processed by Google under
[Google's Privacy Policy](https://policies.google.com/privacy) and
[how Google uses data when you use partner sites/apps](https://policies.google.com/technologies/partner-sites).
For users in regions that require it (e.g. EEA/UK), PosCafe shows Google's consent
form before personalized ads are loaded.

PosCafe does **not** share your business data (menu, transactions, store settings)
with AdMob or any ad network.

## In-app purchases & vouchers

- **Remove Ads** is a one-time product purchased through **Google Play Billing**.
  The entire payment process is handled by Google Play; PosCafe never sees or stores
  your card/payment details. The app only stores a **local flag** indicating ads are
  turned off.
- **Voucher codes** are validated entirely on the device (offline). The code you
  enter is only stored locally to mark the Remove Ads status; it is never sent
  anywhere.
- **Restore Purchase** asks Google Play whether your Google account owns the "Remove
  Ads" product, then re-enables it on this device.

---

## What the app does NOT do

- No registration, login, or user profile.
- Does not send your **business** data to the developer's server or any third
  party.
- Does not use analytics or crash-reporting SDKs.
- Does not sell your data. The only data shared is the device identifier used for
  ads, shared with Google AdMob as described above — and that stops entirely once
  you activate Remove Ads.

---

## Data you choose to share

The app provides features that create a file and then open the operating system's
built-in share sheet:

- **Database Backup** (Settings → *Backup Now*): creates a copy of the `.db` file.
- **Excel Export** (Dashboard, Sales Report, Order History): creates an `.xlsx`
  file.
- **Receipts**: share/save a receipt as text or an image.

These files only leave your device if you choose to share them. Once a file moves
to another service (e.g. Google Drive, Gmail, WhatsApp), it becomes subject to that
service's privacy policy and is your responsibility.

---

## Android permissions

| Permission | Reason |
|---|---|
| `READ_MEDIA_IMAGES` / `READ_EXTERNAL_STORAGE` (up to Android 12) | So you can pick a menu image from the gallery. Images are copied into the app's private storage; the app does not scan or upload your gallery. |
| `INTERNET`, `ACCESS_NETWORK_STATE` | Used by the Google AdMob SDK (loading ads) and Google Play Billing (processing purchases & restores). **Not** used to send your business data. |
| `com.google.android.gms.permission.AD_ID` | Lets the AdMob SDK read the device's advertising ID to serve ads. Once Remove Ads is active, ads no longer load. |
| `com.android.vending.BILLING` | Required by Google Play Billing for the "Remove Ads" purchase and "Restore Purchase". |

---

## Storage, security, and retention

- Data lives in the app's private directory (`AppDataDirectory`), protected by the
  Android app sandbox and inaccessible to other apps on a non-rooted device.
- The app does not add its own encryption on top of system storage. For extra
  security, enable a screen lock and device encryption.
- Data is kept for as long as you keep it. You can delete individual items from
  within the app. Uninstalling the app or running *Clear data* removes the entire
  local database, copied menu images, and any backup files still inside the app's
  folder. Files you have already shared externally are not deleted.

---

## Children

PosCafe is a business operations tool and is not directed at children.

---

## Changes to this policy

This policy may be updated as the app evolves. Changes will be reflected in this
file along with an updated "Effective date".

---

## Contact

Questions, suggestions, or complaints about privacy:

- Email: **novrian.fh@live.com**
- Instagram: **@nvrnfjr**
