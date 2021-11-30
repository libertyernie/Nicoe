Nicoe (Nintendont Configuration Editor)
=======================================

A Windows application for editing the nincfg.bin files used by [Nintendont](https://github.com/FIX94/Nintendont).

Features:

* Open / save nincfg.bin files
* Update nincfg.bin files to version 10 (done automatically upon load - so be sure you're using a recent version of Nintendont)
* Read the Game ID directly from a disc image
* Extract the banner (as .png) from a disc image
* Write a meta.xml to autoload a game directly from the Homebrew Channel (not officially supported; requires a custom build of Nintendont that can [accept a base64-encoded command-line parameter](https://github.com/libertyernie/Nintendont/commit/59ea8fc15cfa52635c89d853f135e28bf5ec3390))

Consists of a C++/CLI layer that wraps the native struct and borrows a bit of code to validate and update the file,
C# code to read a bit of information from a GameCube disc image, a VB.NET frontend, and some F# unit tests.

Serves as a replacement for [NinCFGEditor](https://github.com/libertyernie/NinCFGEditor).
