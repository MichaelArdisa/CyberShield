# CyberShield

<p align="center">
  <img src="https://github.com/user-attachments/assets/11d0776f-900e-4ef7-9bc2-0186eead96e4" alt="CyberShield Gameplay">
</p>

## 🔴 About This Project
<p align="justify">CyberShield was originally developed as a submission for the Indie Game Ignite (IGI) Showcase and the GameToday Indie Game Competition, but we decided to expand the game even after the competition to further explore its potential. </p>

<br>

## 📋 Project Info

<b> Developed with Unity 2022 </b>

| **Role** | **Name** | **Development Time** 
| - | - | - |
| Game Programmer | Michael Ardisa | 2 weeks |
| Game Designer | Allan Alexander Matthew | 2 weeks |
| 3D Artist | Nicholas Diporedjo | 2 weeks |

<details>
  <summary> <b>My Contribution (Game programmer)</b> </summary>
  
  - Core mechanics
  - UI Navigation
  - Bug Fixing
  
</details>


<br>

## ♦️About Game
<p align="justify">CyberShield is an isometric top-down action where players can battle a variety of cyber threats like malware, trojans, and other digital dangers in the computer world. The game introduces a unique gameplay experience by fusing cybersecurity concepts with fast-paced action mechanics.</p>

<br>

## 🎮 Gameplay
<p align="justify">Players engage in intense combat, dodging and countering threats using weapons like machete, katana, and hammer. As they progress, they will face tougher enemies and adapt to new challenges. The game currently features 2 levels, and we plan to add more in future updates.</p>

<br>

## ⚙️ Game Mechanics I Created
### Dash Mechanic

![dashMechanic (1)](https://github.com/user-attachments/assets/13778158-761b-4779-a85f-76f97022ce22)

- Logic is located within the `PMove.cs` script
- The dash works by increasing player velocity and allows direction change mid-dash.
- Trail Renderer component is used for visual impact.
- Trail time is gradually reduced via coroutine at the end of the dash.
- Retracting effect is applied to the trail for a smoother dash experience.

### Scriptable Objects Utilization for Weapon Data

<p align="justify">
  <img src="https://github.com/user-attachments/assets/645bd655-bc99-433d-ad02-e5bec9d51125" style="width: 40%;">
  <img src="https://github.com/user-attachments/assets/bfc19472-e461-4053-bf48-082c41f49d29" style="width: 54%;">
</p>

- Located within the `Weapon.cs` script
- Scriptable objects are used to store key weapon data in the 'Resources' folder.
- Flexible method for managing and modifying weapon attributes.
- Adding new weapons is efficient: create a new weapon asset file and adjust it's data.

<br>

## 📜 Scripts

|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| <a href="https://github.com/MichaelArdisa/CyberShield/blob/main/Assets/Scripts/Weapon.cs">`Weapon.cs`</th> | Scriptable object class used to determine which data needs to be stored. |
| `EBehaviour.cs`  | Responsible for how the enemies behave around the player. |
| `PMove.cs`  | Manages all isometric (skewed) player movements. |
| `ECombat.cs`  | Manages the logic behind the enemies' combat. |
| `PCombat.cs`  | Manages the logic behind the player's combat. |
| `etc`  |

<br>

## 🕹️ Controls

| **Key Binding** | **Function** |
| - | - |
| W, A, S, D | Basic movement |
| Left-Click | Attack |
| L-Shift | Dash |

<br>

## 💻 Setup

This game is still in beta, a playable version will be available soon!

<br>
