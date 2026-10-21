# Restore Femur Breaker
 EXILED plugin for SCP:SL that brings the femur breaker back as an option to recontain SCP-106.

# How It Works
 This version of the femur breaker works differently from the original to fit within the current game balance, and the current layout of SCP-106's room. Two conditions need to be met for the femur breaker to be activated:
 - A player must sacrifice themselves by jumping into the pit below SCP-106's chamber.
 - At least 2 generators need to be fully activated. This number can be configured.

 When one condition is met, the lights in 106's room will turn red. Once both conditions are met, the lights will turn green. The femur breaker can then be activated by opening one of the doors on either side of 106's chamber with an O5 keycard. The sound will play for SCP-106, any players in heavy containment, and all spectators.

# Installing & Configuring
 1. Install [AudioPlayerApi](https://github.com/Killers0992/AudioPlayerApi) and its dependencies to your EXILED dependencies folder.
 2. Download [RestoreFemurBreaker.dll](https://github.com/LambdaGaming/RestoreFemurBreaker/releases/latest) and put it in your EXILED plugins folder.
 3. Download [femur_breaker.ogg](https://github.com/LambdaGaming/RestoreFemurBreaker/raw/refs/heads/master/femur_breaker.ogg) and put it in a folder of your choice.
 4. Run the server to generate the plugin config.
 5. Open the plugin config file and add the path for the .ogg file.

# Building
 The project files are intended to be built using either the command line or VSCode with the C# Dev Tools extension, but Visual Studio should work too. You will need to have the SCP:SL dedicated server and .NET SDK 8 or above installed. You will also need to change the reference paths in the .csproj file to the location of your dedicated server.

# Contributing
 Contributions are welcome! Please read through the [guidelines](https://lambdagaming.github.io/guides/contributing) before submitting an issue or pull request.
