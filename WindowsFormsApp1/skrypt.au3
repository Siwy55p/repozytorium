#include <GUIConstantsEx.au3>
#include <StaticConstants.au3>

#include <WindowsConstants.au3>

; Whichever method we use, we need to declare the dummy control or the flag as a Global variable
Global $hLeftClick, $fRightClick = False
Global $hGui
Global $aLabel[2]

$hGui = GUICreate("Click me!")

$aLabel[0] = GUICtrlCreateLabel("Labe 1", 10, 10, 80, 20, $SS_SUNKEN)
$aLabel[1] = GUICtrlCreateLabel("Labe 2", 10, 40, 80, 20, $SS_SUNKEN)

; Create a dummy control for the handler to action
$hLeftClick = GUICtrlCreateDummy()

GUISetState(@SW_SHOW, $hGui)

; Register our messages
GUIRegisterMsg($WM_LBUTTONUP, "_WM_LBUTTONUP")
GUIRegisterMsg($WM_RBUTTONUP, "_WM_RBUTTONUP")
GUIRegisterMsg($WM_CONTEXTMENU, "MY_WM_COMMAND")

While 1
    Switch GUIGetMsg()
        Case $GUI_EVENT_CLOSE
            ExitLoop
        Case $hLeftClick
            ; Our dummy control was actioned so run the required code
            ConsoleWrite("Click: LEFT CLICK!" & @LF)
    EndSwitch

    ; Look for the flag
    If $fRightClick = True Then
        ; Run the code
        ConsoleWrite("Click: RIGHT CLICK!" & @LF)
        ; Do not forget to reset the flag!
        $fRightClick = False
    EndIf
WEnd

Func _WM_LBUTTONUP($hWnd, $iMsg, $wParam, $lParam)
    ; Action the dummy control
    GUICtrlSendToDummy($hLeftClick)
EndFunc   ;==>_WM_LBUTTONUP

Func _WM_RBUTTONUP($hWnd, $iMsg, $wParam, $lParam)
    ; Set the flag
    $fRightClick = True
EndFunc   ;==>_WM_RBUTTONUP

Func MY_WM_COMMAND($hWnd, $iMsg, $wParam, $lParam)
    Local $nNotifyCode = BitShift($wParam, 16)
    Local $nID = BitAND($wParam, 0x0000FFFF)
    Local $hCtrl = $lParam

    ConsoleWrite("_WM_RBUTTONUP $nNotifyCode[ " & $nNotifyCode & " ] $nID[ " & $nID & " ] $hCtrl[ " & $hCtrl & " ]" & @LF)

    If $nID <> 2 And $nNotifyCode = 0 Then ; Check for IDCANCEL - 2
        ; Ownerdrawn buttons don't send something by pressing ENTER
        ; So IDOK - 1 comes up, now check for the control that has the current focus
        If $nID = 1 Then
            Local $hFocus = DllCall("user32.dll", "hwnd", "GetFocus")
            Local $nCtrlID = DllCall("user32.dll", "int", "GetDlgCtrlID", "hwnd", $hFocus[0])
;~             PostButtonClick($hWnd, $nCtrlID[0])
        Else
            ConsoleWrite("MY_WM_COMMAND: GUIHWnd" & @TAB & ":" & $hWnd & @CRLF & _
                    "MsgID" & @TAB & ":" & $iMsg & @CRLF & _
                    "wParam" & @TAB & ":" & $wParam & @CRLF & _
                    "lParam" & @TAB & ":" & $lParam & @CRLF & @CRLF & _
                    "WM_COMMAND - Infos:" & @CRLF & _
                    "-----------------------------" & @CRLF & _
                    "Code" & @TAB & ":" & $nNotifyCode & @CRLF & _
                    "CtrlID" & @TAB & ":" & $nID & @CRLF & _
                    "CtrlHWnd" & @TAB & ":" & $hCtrl & @LF)

            ConsoleWrite("$nID[ " & $nID & " ]" & @LF)

        EndIf
        Return 0 ; Only workout clicking on the button
    EndIf
    ; Proceed the default AutoIt3 internal message commands.
    ; You also can complete let the line out.
    ; !!! But only 'Return' (without any value) will not proceed
    ; the default AutoIt3-message in the future !!!
    Return $GUI_RUNDEFMSG
EndFunc   ;==>MY_WM_COMMAND