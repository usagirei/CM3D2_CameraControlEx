### Installing

* Place the Contents of the 'Managed' Directory into the Game 'CM3D2(x86|x64)_Data\Managed' Directory
* Place the Contents of the 'ReiPatcher' Directory into the ReiPatcher 'Patches' Directory
  Not the Root Directory! The Patches Directory!
* Place the Contents of the 'UnityInjector' Directory into the 'UnityInjector' Directory at the **root** of the Game Directory, alongside the Game Exe and Data Directory

---
### Building
1. Add the Reference Assemblies to the "References" Directory (using symbolic links, or by copying the files):
* UnityEngine.dll (From Either Unity or CM3D2)
* Assembly-CSharp.dll (From CM3D2)
* UnityInjector.dll
* ExIni.dll
2. If Changes were made to the Plugin Configuration T4 Template, Save it so your IDE Regenerates it.
3. Compile via your IDE or by executing "Build.bat" in the project root

---
### Usage:
**Default Keybinds:**

| Key            | Function A                | Function B              |
|----------------|---------------------------|-------------------------|
| LeftAlt        | Modifier                  |                         |
| KeypadDivide   | Toggle Fine Tune          |                         |
| KeyPadPeriod   | Cycle Eye to Camera Modes |                         |
| Numpad4        | Move Left                 | Orbit Left              |
| Numpad6        | Move Right                | Orbit Right             |
| Numpad8        | Move Forward              | Orbit Up                |
| Numpad2        | Move Backward             | Orbit Down              |
| Numpad1        | Move Down                 | Roll Left               |
| Numpad3        | Move Up                   | Roll Right              |
| NumpadPlus     | Fov Decrease (Zoom In)    | Orbit Distance Increase |
| NumpadMinus    | Fov Increase (Zoom Out)   | Orbit Distance Decrease |
| Numpad5        | Reset Translation         | Reset Rotation          |
| NumpadMultiply | Reset FOV                 |                         |
| Keypad0        | ScreenShot                | ScreenShot (No UI)      |

*Change Keybinds and Rotation/Movement Speed in in the Configuration File "UnityInjector\Config\CameraControlExPlugin.ini"*
