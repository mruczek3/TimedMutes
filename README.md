# **TimedMutes**  

Welcome to the **TimedMutes** plugin! 🎉  

<div align="center">
<a href="https://github.com/mruczek3/TimedMutes/releases"><img src="https://img.shields.io/github/downloads/mruczek3/TimedMutes/total?style=for-the-badge&logo=githubactions&label=Downloads" alt="GitHub Release Download"></a> 
<a href="https://github.com/mruczek3/TimedMutes/releases"><img src="https://img.shields.io/badge/Version-1.0.0-brightgreen?style=for-the-badge&logo=gitbook" alt="GitHub Releases"></a>
</div>

## **About TimedMutes**  
**TimedMutes** is a exiled plugin for SCP:SL servers. It empowers administrators with the ability to temporarily mute disruptive players for a specified duration. With built-in Discord logging and seamless server integration, this plugin ensures smooth moderation and enhanced gameplay experiences.

---

## **Features**  
- 🕒 **Custom Mute Durations:** Mute players for precise time periods like `1d`, `2h`, or `30m`.  
- 📣 **Reason Display:** Broadcast mute reasons and durations directly to the muted player.  
- 💾 **Persistent Storage:** Mutes are stored and persist even after server restarts.  
- 📜 **Discord Logs:** Automatic logging of mute actions to Discord with clear and professional embeds.  

  Example of a Discord log:  
  ![Discord Log](https://media.discordapp.net/attachments/1203686323802873866/1324402934972416140/image.png?ex=677805d9&is=6776b459&hm=e706dfe0a115daead63f5c50bc64dace6d5e59e6da5827a0f24910188d2956b9&=&format=webp&quality=lossless&width=400&height=271)  

---

## **Command Overview**  
| Command | Arguments | Permission | Description |  
|---------|-----------|------------|-------------|  
| `tmute` | `<player> <duration> <reason>` | `timedmutes.mute` | Temporarily mute a player. Example: `tmute player1 1h being toxic`.  

### **Command Breakdown**  
- **`<player>`**: Name or SteamId of the target player.  
- **`<duration>`**: Mute duration (e.g., `2h`, `15m`).  
- **`<reason>`**: Brief explanation for the mute (e.g., toxic behavior).  

---

## **Installation Instructions**  

1. Download the latest version of **TMutes.dll** from the [Releases](https://github.com/mruczek3/TimedMutes/releases).  
2. Place the file in your `Exiled/Plugins` folder.  
3. Restart your server to load the plugin.  

### **Dependencies**  
- **Exiled Framework**: [Download here](https://github.com/ExMod-Team/EXILED/releases)  
- **Newtonsoft.Json**: [Download here](https://github.com/JamesNK/Newtonsoft.Json/releases)  

---

Thank you for using **TimedMutes**— <3
