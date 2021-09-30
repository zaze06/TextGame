![travis](https://app.travis-ci.com/zaze06/TextGame.svg?branch=master)
# TextGame
This is a game thats you run in terminal.
downloadible from [itch.io](https://alienomdia.itch.io/textgame)

pictures of the game 

![icon](https://github.com/zaze06/TextGame/blob/master/resorces/icon.gif)
![gamePlay](https://github.com/zaze06/TextGame/blob/master/resorces/gamePlay.gif)

# Sublit new maps as issues
- Folow the template maps

# Run releases
1. Download the Game
    - OPS if you whant to build from the latest commitment you need to folow the build instructions below
    1. Click on Releases
    2. Download the zip called "Game.zip"
    3. unzip the zip file
2. Download Mono
    1. Go to https://www.mono-project.com/download/stable/
        1. Mac Os
            1. Make sure that the macOS tab is selected
            2. Click on download mono [Version] (Stable channel)
        2. Windows
            - (skip to step 2.i.b.f if you know if you'r os is 64 or 32 bit)
            1. Open setting
            2. Click on System
            3. Click on Abot
            4. Make sure that the Windows tab is selected
            5. under Device specifications read the System type and the first part id ether 64-bit or 32-bit
            6. now you know if your system is 64 or 32 bit now click the download for your system
        3. Linux
            1. Make sure that the Linux tab is selected
            2. Make sure that the coresponding Linux version is selected
            3. follow the install instructions
    2. For macOs and Windows you need to run the downloaded file
3. Start a command promt or Terminal dependin on os
    1. Windows
        1. press "Win key"
        2. start typing "cmd"
        3. press enter
    2. Mac OS
        1. press "cmd (win key if you have windows keyboard) + space"
    3. Linux
        - You probobly alrady have a terminal open and you probobly knwo how to open it if its not open so im not guna tell you becus i cant fide a standerd on how you do it ¯\\_(ツ)_/¯
4. Start the game
    1. use cd to go to the location of the game (where you have out the unziped folder from step 1)
    2. run run.bat
        - Windows
            1. Just run `run`
        - Mac OS
            1. run `chmod +x`
            2. run `./run.bat`
        - Linux
            1. Add executible flag to `run.bat`. You probobly know how. I dont ¯\\_(ツ)_/¯
            2. Run `./run.bat`
    3. ENJOY \\^o^/

# Build the game
1. Make sure mono is instaled
    1. Go to https://www.mono-project.com/download/stable/
        1. Mac Os
            1. Make sure that the macOS tab is selected
            2. Click on download mono [Version] (Stable channel)
        2. Windows
            - (skip to step 1.1.2.6 if you know if you'r os is 64 or 32 bit)
            1. Open setting
            2. Click on System
            3. Click on Abot
            4. Make sure that the Windows tab is selected
            5. under Device specifications read the System type and the first part id ether 64-bit or 32-bit
            6. now you know if your system is 64 or 32 bit now click the download for your system
        3. Linux
            1. Make sure that the Linux tab is selected
            2. Make sure that the coresponding Linux version is selected
            3. follow the install instructions
    2. For macOs and Windows you need to run the downloaded file
2. open a command peomt or Terminal
    1. Windows
        1. press "Win key"
        2. start typing "cmd"
        3. press enter
    2. Mac OS
        1. press "cmd (win key if you have windows keyboard) + space"
    3. Linux
        - You probobly alrady have a terminal open and you probobly knwo how to open it if its not open so im not guna tell you becus i cant fide a standerd on how you do it ¯\\_(ツ)_/¯
3. run make build
    - Make sure you can run makefile
    1. run `make build`
4. run the game
    1. run `make run`
    2. ENJOY \\^o^/
