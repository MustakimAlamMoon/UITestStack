; Relative path to the image file
$relativePath = "New Year.jpg"

; Get the full path
$fullPath = @ScriptDir & "\" & $relativePath

; Script to upload the image
Sleep(1000)
ControlFocus("Open", "", "Edit1")
Sleep(1000)
ControlSetText("Open", "", "Edit1", $fullPath)
Sleep(1000)
ControlClick("Open", "", "Button1")
Sleep(1000)
