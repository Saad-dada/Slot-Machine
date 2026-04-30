# 🎰 Unity Slot Machine Game

## 📌 Overview

This project is a **2D Slot Machine Game** built using Unity.
It demonstrates core gameplay mechanics, structured code architecture, and polished user interaction.

The game simulates a classic slot machine experience with spinning reels, randomized outcomes, payout logic, and interactive UI elements.

---

## 🎮 Features

* 🎰 **3-Reel Slot Machine**
* 🎲 **Controlled Randomization (RNG)**
* 🧠 **Win Detection Logic**
* 💰 **Balance & Payout System**
* 🎯 **Adjustable Win Probability (Inspector-based)**
* 🎚️ **Tunable Spin Timing & Delays**
* 🎮 **Interactive Lever & Button Controls**
* 🔊 **Sound Effects (Lever, Reel, Win)**
* ✨ **UI Feedback & Win Animation**

---

## 🧱 Project Structure

```
Assets/
 ├── Scripts/
 │    ├── GameManager.cs
 │    ├── ReelController.cs
 │    ├── LeverController.cs
 │    └── AudioManager.cs
 ├── Prefabs/
 ├── UI/
 ├── Sprites/
 ├── Sounds/
 └── Scenes/
```

---

## ⚙️ How It Works

### 🔄 Spin System

* Player triggers spin via **button or lever**
* All reels spin simultaneously
* Reels stop sequentially with delay
* Final outcome is determined using controlled RNG

---

### 🎲 Randomization Logic

* Win probability is adjustable via Inspector
* Outcome is decided before spin completes
* Ensures both **fairness and controlled gameplay feel**

---

### 💰 Economy System

* Player starts with a fixed balance
* Each spin deducts coins
* Matching symbols reward coins based on type

---

### 🎧 Audio System

* Lever pull sound on interaction
* Tick sound during spinning
* Stop sound per reel
* Win sound on successful match

---

## 🕹️ Controls

| Action     | Input                |
| ---------- | -------------------- |
| Spin       | Button Click / Lever |
| Play Again | Press Spin           |

---

## 🌐 WebGL Build

To run the game:

1. Open the `/Build/WebGL` folder
2. Run the `index.html` file in a browser

---

## 🧠 Design Decisions

* Used **coroutine-based animation** instead of complex physics reels
  → Ensures simplicity, performance, and maintainability

* Implemented **controlled RNG**
  → Provides better gameplay experience compared to pure randomness

* Exposed key variables in Inspector
  → Allows easy tuning without modifying code

---

## 🚀 Possible Improvements

* Add multi-line win conditions
* Add bonus symbols (wild/scatter)
* Add background music + mute toggle
* Improve reel animation using sprite scrolling system
* Add persistent save system

---

## 📦 Requirements

* Unity 6+ (Recommended)
* Supports WebGL build


---

## ✅ Notes

This project was developed as part of a **Unity Game Development Assignment**, focusing on:

* Clean architecture
* Gameplay logic
* UI/UX clarity
* Code quality and maintainability

---
