Nicoe (Nintendont Configuration Editor)
=======================================

A Windows application for editing the nincfg.bin files used by [Nintendont](https://github.com/FIX94/Nintendont).

Serves as a replacement for [NinCFGEditor](https://github.com/libertyernie/NinCFGEditor).

Features:

* Create / open / save nincfg.bin files (version 8, 9, or 10)
* Update nincfg.bin files to version 10
* Read the Game ID directly from a disc image
* Extract the banner (as .png) from a disc image
* Write a meta.xml to autoload a game directly from the Homebrew Channel (not officially supported; requires a custom build of Nintendont that can [accept a base64-encoded command-line parameter](https://github.com/FIX94/Nintendont/pull/532))

Consists of a C++/CLI layer that wraps the native struct and borrows a bit of code to validate and update the file,
C# code (copied from NinCFGEditor) to read the game ID and banner, a VB.NET frontend, and some F# unit tests.
