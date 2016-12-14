;###################################################
;# 		AlwaysOnTop
;# Author	:	Joshua Parnell
;# Web		:	http://joshua.parnell.co
;# Version	:	0.2.0
;# Date		:	2016-12-14
;# Credits	:	AutoIt Team
;#					https://www.autoitscript.com
;#				John Parnell for assistance with aot() logic
;#				@MrCreatoR for GUIHyperLink library
;#					https://www.autoitscript.com/forum/topic/126934-guihyperlink-create-hyperlink-controls/
;###################################################

#include <AutoItConstants.au3>
#include <TrayConstants.au3>
#include <GUIConstantsEx.au3>
#include <WinAPIRes.au3>
#include "GUIHyperLink.au3"
Global $aboutgui
Global $helpgui

If StringInStr($cmdlineRaw, "/Extract") Then
   FileInstall("C:AoT.au3", @ScriptDir & "AoT.au3", 1)
   MsgBox(0,"",@ScriptDir & "AoT.au3")
   Exit
EndIf

Opt("TrayOnEventMode", 1)
Opt("TrayMenuMode", 3)
TraySetIcon("icon.ico")
TrayCreateItem("Always On Top")
TrayItemSetOnEvent(-1, "aot")
TrayCreateItem("About")
TrayItemSetOnEvent(-1,"about")
TrayCreateItem("Help")
TrayItemSetOnEvent(-1,"help")
TrayCreateItem("Exit")
TrayItemSetOnEvent(-1, "xit")

While 1
WEnd

Func aot()
   Local $hPrev = _WinAPI_CopyCursor(_WinAPI_LoadCursor(0, 32512))
   Local $iPrev = _WinAPI_CopyCursor(_WinAPI_LoadCursor(0, 32513))
   _WinAPI_SetSystemCursor(_WinAPI_LoadCursorFromFile(@ScriptDir & "\cross.cur"),32512)
   _WinAPI_SetSystemCursor(_WinAPI_LoadCursorFromFile(@ScriptDir & "\cross.cur"),32513)
   While 1
	  WinWaitNotActive("AutoIt v3")
	  WinWaitNotActive("Program Manager")
	  If WinGetTitle("") <> "" Then ExitLoop
   WEnd
   $txt = WinGetTitle("")
   If StringRight($txt, 16) = " - Always on Top" Then
	  WinSetOnTop($txt, "", 0)
	  WinSetTitle($txt, "", StringTrimRight($txt, 16))
   Else
	  WinSetOnTop($txt, "", 1)
	  WinSetTitle($txt, "", $txt & " - Always on Top")
   EndIf
   _WinAPI_SetSystemCursor($hPrev,32512)
   _WinAPI_SetSystemCursor($iPrev,32513)
EndFunc

Func about()
   $aboutgui = GUICreate("About AlwaysOnTop",400,250)
   GUISetIcon("icon.ico")
   GUISetFont(13, 800)
   GUICtrlCreateLabel("AlwaysOnTop",150,10)
   GUISetFont(10, 800)
   GUICtrlCreateLabel("Version 0.2.0",160,40)
   GUICtrlCreateLabel("Created using AutoIt v3",120,60)
   GUICtrlCreateLabel("Designed and developed by Joshua Parnell.",40,100)
   GUICtrlCreateLabel("Website:",175,130)
   _GUICtrlHyperLink_Create("https://github.com/jparnell8839/AlwaysOnTop",45,150,-1,-1,0x0000FF,0x551A8B,-1,"https://github.com/jparnell8839/AlwaysOnTop",'Visit: github.com/jparnell8839/AlwaysOnTop',$aboutgui)
   GUISetFont(7, 400)
   GUICtrlCreateLabel("Copyright " & Chr(169) & " 2013-2016 Joshua Parnell. All Rights Reserved",65,200)

   GUISetState()

   While 1
	  $msg = GUIGetMsg()
	  Switch $msg
		 Case $GUI_EVENT_CLOSE
			closeGUI($aboutgui)
			ExitLoop
	  EndSwitch
   WEnd

EndFunc

Func help()
   $helpgui = GUICreate("Help",400,250)
   GUISetIcon("icon.ico")
   GUISetFont(13, 800)
   GUICtrlCreateLabel("How to Use:",150,10)
   GUISetFont(10, 800)
   GUICtrlCreateLabel('1. Click the Always on Top icon in the System Tray',20,40)
   GUICtrlCreateLabel('2. Click "Always on Top"',20,60)
   GUICtrlCreateLabel('3. Click the window of the program you want to',20,80)
   GUICtrlCreateLabel('   remain on top',20,100)
   GUICtrlCreateLabel('4. The titlebar will change to include',20,120)
   GUICtrlCreateLabel('    " - Always on Top"',20,140)
   GUICtrlCreateLabel('To disable that window, repeat the steps',20,180)

   GUISetFont(7, 400)
   GUICtrlCreateLabel("Copyright " & Chr(169) & " 2013-2016 Joshua Parnell. All Rights Reserved",65,225)

   GUISetState()

   While 1
	  $msg = GUIGetMsg()
	  Switch $msg
		 Case $GUI_EVENT_CLOSE
			closeGUI($helpgui)
			ExitLoop
	  EndSwitch
   WEnd

EndFunc

Func closeGUI($selection)
	  GUIDelete($selection)
EndFunc

Func xit()
   $allWindows = WinList()
   For $i = 1 to $allWindows[0][0]
	  If StringRight($allWindows[$i][0], 16) = " - Always on Top" Then
		 WinSetOnTop($allWindows[$i][0], "", 0)
		 WinSetTitle($allWindows[$i][0], "", StringTrimRight($allWindows[$i][0], 16))
	  EndIf
   Next
   Exit
EndFunc