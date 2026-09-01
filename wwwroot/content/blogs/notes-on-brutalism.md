---
title: Notes on Brutalist Web Design
date: 2026-08-20
description: A few things I keep coming back to when building raw, high-contrast interfaces.
tags: design, css, brutalism
draft: false
---

# Notes on Brutalist Web Design

Some principles I try to stick to:

- **Structure is the decoration.** Borders, grids and offsets do the work —
  no gradients, no soft shadows.
- **One loud accent.** Everything else is black and paper.
- **Type carries the mood.** A grotesk for size, a mono for labels.
- **Motion is mechanical.** Things snap and shift; they don't ease and float.

## The shadow trick

A hard offset shadow with zero blur reads as a physical stack:

```css
box-shadow: 6px 6px 0 #0a0a0a;
```

On hover, move the element up-left and grow the shadow — it looks like the card
lifts off the page.

Replace this post with your own writing whenever you're ready.
