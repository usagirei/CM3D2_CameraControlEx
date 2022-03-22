### Installing

* Place `COM3D2.CameraControlEx.Plugin.dll` file into your BepinEx plugins folder. This is usually in `BepinEx\plugins`.

### Updating from 1.0.1.1 Sybaris

This version of the plugin uses BepInEx, and use together with the old sybaris versionn is not recommended. It is advised to uninstall the Sybaris plugin to avoid control conflicts with each other.

To migrate to the BepInEx version (1.1+), do the following:

1. Remove the Sybaris version.

If your plugins are managed via CMI, use the CMI installer to uninstall the plugin making sure clean-up actions are selected (the default). A backup of your old plugins and configurations will be made by the installer when you do this.

2. Do the install steps above.

3. Migrate your old settings to the new path (if you have customized keybinds)

The sybaris plugin configuration is usually located at `Sybaris\UnityInjector\Config\CameraControlExPlugin.ini`. Move this file to the `BepinEx\config` folder in the root folder of your game (where COM3D2.exe is). Rename this file into **`CameraControlExPlugin.cfg`**

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
