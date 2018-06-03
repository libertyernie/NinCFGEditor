nincfg.bin editor
-----------------

This is a Windows application that lets you create or edit nincfg.bin files
used by [Nintendont](https://github.com/FIX94/Nintendont). It can be used to
view or edit nincfg.bin files from your computer.

Custom Homebrew Channel entries
-------------------------------

I also compiled my own version of Nintendont which allows the data in
nincfg.bin to be stored in the Homebrew Channel's meta.xml file. This lets me
have a separate entry in the Homebrew Channel for each GameCube game I want to
play. NinCFGEditor can help you make these custom Homebrew Channel entries.

1. Put my custom Nintendont boot.dol https://github.com/libertyernie/Nintendont/raw/custom-build/loader/loader.dol) in the same folder as NinCFGEditor.exe, and name it boot.dol

2. Copy the GameCube game to your SD/USB drive (see other tutorials for how to do this)

3. Open NinCFGEditor

4. Use the "..." button next to the Game Path entry area to find and select
   the game's .iso or .gcm file on your SD/USB; the Game ID will be filled in
   automatically

5. Turn Auto Boot on (and adjust other settings if you want to)

6. Use Tools > Export All Files to save the files to a folder on your SD/USB
   directly underneath /apps - this should save boot.dol (which is just copied
   over), meta.xml, and icon.png

7. Make any custom edits to meta.xml or icon.png (if you want to)
