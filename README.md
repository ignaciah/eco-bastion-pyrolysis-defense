The following architectural diagram illustrates the core interaction between the spatial indexing, resource management, and the state-driven processing logic:
       ┌──────────────────┐                                  ┌──────────────────┐
       │  SpatialGridMap  │                                  │  ResourceBank    │
       │  (Vector3 Index) │                                  │  (S / O / C)     │
       └────────┬─────────┘                                  └──────────────────┘
                │
                ▼
       ┌──────────────────┐
       │  ProcessingNode  │ ──(Reads Configuration)──► ┌────────────────────────┐
       │  (State Machine) │                            │ TowerUpgradeMatrix     │
       └──────────────────┘                            │ (Tier 1-4 Performance) │
                                                       └────────────────────────┘

|                                [Node: Cracker Tier 2]                   |

| (o) (o) (o) Range Ring |
| :--- |
| :--- | <br> +-------------------------------------------------------------------------+
| [SYSTEM DETAIL OVERLAY: Thermal Cracker Instance #04] |
| +------------------------------------+ +------------------------------+ |
|  | Core Thermal Mass Load |  | Material Output Split |  |
|  | [██████████████░░░░░░░░░] 52.4°C |  | Oil: 80% | Syngas: 20% |  |
| +------------------------------------+ +------------------------------+ |
|  | [Button: Coolant Flush (-30 Syngas)] | [Button: Upgrade Bio-Oil 600] |  |
| +------------------------------------+ +------------------------------+ | <br> +-------------------------------------------------------------------------+
| [Build Sorting Jaw] | [*Build Cracker*] | [Build Catalytic Converter] |


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

```
 2. Open the **Unity Hub**, click **Add**, and select the cloned root directory folder.
 3. Allow the editor to fully generate the local library dependencies.
 4. Open Assets/Scenes/MainSimulation.unity and click **Play** to test the core mechanics loop inside the sandbox environment.
## 📱 Mobile Layout UI Design
The UI layout is optimized for modern **19.5:9 smartphone screens**. It includes a persistent top-screen resource header, an interactive multi-agent structural build dock, and an adaptive modal lower-third that surfaces critical engine telemetry like live thermal load curves.
```



