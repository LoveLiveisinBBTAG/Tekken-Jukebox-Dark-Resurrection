# Tekken-Jukebox-Dark-Resurrection

Program to play music while a certain stage is loaded in Tekken 7 by hooking into its memory.



# IMPORTANT! 

* For some reason, chrome has decided to give a warning for this program, saying it's not commonly downloaded. I have no idea how to fix this, and nothing in my program is malicious (although potentially the memory.dll library could be flagged?). Check my crappy source code if you are unsure.





# Requirements


* Windows Media Player

* .NET Framework 4.6.1

* 64 Bit CPU

# Instructions

* Launch Tekken 7, navigate to Options, Sound Options, and turn down the BGM Volume slider all the way down

* Run Tekken Jukebox Dark Resurrection.exe

* Click browse and set the desired .mp3 file for each stage

* Set the desired volume, and use the preview button to ensure it is at the correct volume

* Press Start Jukebox



# Additional Notes 


* This program directly hooks into memory addresses in the Tekken exe file. Therefore, just like TekkenBotPrime, the program will break every time there is a new update. It also means that the program requires administrator permissions, just like Cheat Engine.

* There is a bug I've intentionally left in where the music briefly turns off during the loading screen when the characters appear. I thought it sounded nice to have a brief few seconds of silence between the tracks, but I could fix this if a majority of people request it.
* The program may hang when it's stuck trying to play a file. I haven't tracked down the exact reasons this happens, if this happens to you please tell me how you made it occur (Message me on reddit /u/danhern). Changing to a different stage unhangs the program.
* This program uses the memory.dll library by erfg12, see their github at https://github.com/erfg12/memory.dll 



# Changelog

* Fixed an error where music would not play in ranked matches.

# Currently known bugs

* Not having a main menu song may cause no other songs to play. I reccomend having a main menu song and just turning the volume to 0 if you don't want to hear it. 
* Returning to the main menu after an online match causes the main menu music to not play. I currently don't have a fix for this. Changing to another stage causes the music for that stage to still play.
* Starting the jukebox before the actual game can sometimes cause the program to hang.
