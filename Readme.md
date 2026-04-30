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

## ▶️ How to Run

### 🔹 Option 1: Play via WebGL (Recommended)

1. Navigate to:

   ```
   Build/WebGL/
   ```
2. Open `index.html` in a browser

> ⚠️ If it doesn’t run due to browser restrictions, use a local server:

```bash
python -m http.server
```

Then open:

```
http://localhost:8000
```

---

### 🔹 Option 2: Run in Unity Editor

1. Open project in Unity (version 6+ recommended)
2. Open `MainScene` from `Assets/Scenes/`
3. Click **Play**

---

## 🌐 Play Online (Itch.io)

👉 **Play the game [here](https://saadnotsad.itch.io/slot-machine)**

---

## 🧠 Design Decisions

* Used **coroutine-based animation** instead of complex physics reels
  → Ensures simplicity, performance, and maintainability

* Implemented **controlled RNG**
  → Provides better gameplay experience compared to pure randomness

* Exposed key variables in Inspector
  → Allows easy tuning without modifying code

---

## 📦 Requirements

* Unity 6+ (Recommended)
* Supports WebGL build

