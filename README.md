### Installing

* Place `COM3D2.CameraControlEx.Plugin.dll` file into your BepinEx plugins folder. This is usually in `BepinEx\plugins`.
* If you have the old Sybaris version `CM3D2.CameraControlEx.Plugin`, remove it (or uninstall it via CMI if it was installed that way)

---
### Building
1. Fetch nuget packages.
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

*Change Keybinds and Rotation/Movement Speed in in the Configuration File `BepinEx\config\org.bepinex.plugins.COM3D2.CameraControlEx.cfg`*
