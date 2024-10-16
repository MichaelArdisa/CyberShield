# CyberSheild

![CyberSheild_Gameplay](https://github.com/user-attachments/assets/11d0776f-900e-4ef7-9bc2-0186eead96e4)

## 🔴 About This Project
<p align="justify">CyberShield was originally developed as a submission for the Indie Game Ignite (IGI) Showcase and the GameToday Indie Game Competition, but we decided to expand the game even after the competition to further explore its potential. </p>

<br>

## 📋 Project Info

| **Role** | **Team Size** | **Development Time** | **Engine** |
|:-|:-|:-|:-|
| Game Programmer | 3 | 2 months | Unity 2022|

<br>

## 👤 Meet the Team
- Michael Ardisa (Lead Programmer)
- Allan Alexander Matthew (Designer)
- Nicholas Diporedjo (3D Artist)

<br>

## ♦️About Game
<p align="justify">CyberShield is an isometric top-down action RPG where players can battle a variety of cyber threats like malware, trojans, and other digital dangers in the computer world. The game introduces a unique gameplay experience by fusing cybersecurity concepts with fast-paced action mechanics.</p>

<br>

## 🎮 Gameplay
<p align="justify">Players engage in intense combat, dodging and countering threats using weapons like machete, katana, and hammer. As they progress, they will face tougher enemies and adapt to new challenges. The game currently features 2 levels, and we plan to add more in future updates.</p>

<br>

## ⚙️ Game Mechanics I Created
### Dash Mechanic

![dashMechanic (1)](https://github.com/user-attachments/assets/13778158-761b-4779-a85f-76f97022ce22)

<p align="justify">The dash mechanic in this game works by increasing the player's velocity, allowing them to change direction mid-dash rather than being locked into a straight line. The visual impact of the dash is enhanced by a trail effect, created using the Trail Renderer component. To make the dash feel smoother, the trail time is gradually reduced through a coroutine when the dash ends, giving the trail a retracting effect.</p>

```
void Update()
{
    ...        
    // dash
    if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && !CD && activeScene.name != "MainMenu & Shop")
    {
        trail.enabled = true;
        trail.time = 0.5f;

        isDashing = true;
        moveSpeed = moveSpeed * dashSpeed;
        Invoke(nameof(dashReset), 0.2f);

        CD = true;
        Invoke(nameof(coolDown), dashCD + 0.2f);
    }
    ...
}

private void dashReset()
{
    moveSpeed = moveSpeed / dashSpeed;
    isDashing = false;
    StartCoroutine(trailReduce());
}

IEnumerator trailReduce()
{
    while (trail.time > 0)
    {
        trail.time = trail.time - 0.01f;
        yield return new WaitForSeconds(0.01f);
    }

    trail.time = 0f;
}
```

<!-- ### Simple Checkpoint System
<p align="justify">The checkpoint system in PhaseJumper integrates with the saving system, triggering a save each time the player reaches a checkpoint. It uses PlayerPrefs to store the player's updated X and Y coordinates, which are later combined into a Vector2 and saved in the JSON file format.</p>

```

``` -->

<br>

## 📜 Scripts

|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `GameManager.cs` | Manages the game flow, main menu, pause menu, etc. |
| `AudioManager.cs`  | Responsible for all the audio in the game. |
| `PMove.cs`  | Manages all player movements. |
| `SaveManager.cs`  | Manages the logic behind saving the player's data. |
| `CP_Behaviour.cs`  | Manages the behaviour of checkpoints |
| `etc`  |

<br>

## 🕹️ Controls

| **Key Binding** | **Function** |
|:-|:-|
| A, S, D | Basic movement |
| Space | Jump |
| S-MidAir | Fast-Fall |
| Esc | Pause |
| L-Shift or J | Teleport |

<br>

## 💻 Setup

This game is not yet finished, a playable version will be available soon!
