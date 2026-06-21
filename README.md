# Eco-Bastion: Pyrolysis Defense 🚀

A real-time, mobile-first Tower Defense & Strategy simulation game built for the **Meta Horizon Creator Competition**.

## 🌲 The Big Idea

**Eco-Bastion: Pyrolysis Defense** transforms classic defense mechanics into an educational, resource-driven simulation. Instead of neutralizing fantasy enemies, players deploy automated thermal cracking centers and physical sorting nodes to process encroaching streams of industrial waste and marine plastics.

Using real-world **circular-economy mechanics**, towers convert waste into high-value secondary resources (Syngas, Bio-Oil, and Carbon Black) to fund tech upgrades and grid cooling systems.

---

## ⚙️ Core System Architecture

The game's technical foundation is split into highly optimized, decoupled processing layers to ensure a flawless frame rate on mobile viewports:

* **Game Data Layer (`ScriptableObjects`):** Easily balance tower performance variables, processing radii, and heat coefficients directly inside the Unity Inspector.
* **State Machine Engine (`ResourceBank.cs`):** Manages instantaneous resource calculations and economic trades for Syngas ($S$), Bio-Oil ($O$), and Carbon Black ($C$).
* **Thermal Dynamics Processor (`ProcessingNode.cs`):** Simulates real-time heat generation curves, efficiency metrics, and emergency coolant triggers for physical game instances.

---

## 🛠️ Step-by-Step Installation & Local Setup

Follow these instructions to open, inspect, and deploy the project codebase locally:

### Prerequisites
* **Unity Editor:** version `2022.3 LTS` or higher.
* **Pipeline Setup:** Universal Render Pipeline (URP) packaging.
* **Build Targets:** Android SDK Level 33+ or iOS 15+.

### Local Initialization
1. Clone this repository onto your workstation machine:
   ```bash
   git clone [https://github.com/](https://github.com/)<YOUR_USERNAME>/eco-bastion-pyrolysis-defense.git

