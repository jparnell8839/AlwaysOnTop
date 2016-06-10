#include <AutoItConstants.au3>
#include <TrayConstants.au3>

Opt("TrayOnEventMode", 1)
Opt("TrayMenuMode", 3)
TraySetIcon("icon.ico")
TrayCreateItem("Always On Top")
TrayItemSetOnEvent(-1, "AoT")
TrayCreateItem("Exit")
TrayItemSetOnEvent(-1, "Xit")
While 1
WEnd

Func aot()
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
EndFunc

Func xit()
	Exit
EndFunc
