@echo off
path %path%;"C:\Program Files\CodeAndWeb\TexturePacker\bin"
for /f "usebackq tokens=*" %%d in (`dir /s /b *.pvr`) do (
TexturePacker.exe --sheet "%%~dpnd.png" "%%d"
)
del out.plist
pause