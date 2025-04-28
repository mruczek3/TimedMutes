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
  ![Discord Log](https://media.discordapp.net/attachments/1203686323802873866/1366503559582974032/image.png?ex=68112f1d&is=680fdd9d&hm=a12aa2116ef2b452e9ba93ab2f11670dd01b0572c663d50f2dd2f2f5a4540d79&=&format=webp&quality=lossless&width=539&height=321)  

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
