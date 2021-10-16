rmdir /S /Q .\files
mkdir .\files

copy ..\WindowMeter\WindowMeter\bin\Release\WindowMeter.exe .\files\

call subscribe "files\WindowMeter.exe"

iscc /q install.iss

call subscribe "output\install-windowmeter.exe"

sha256sum "output\install-windowmeter.exe" > "output\signature.txt"

pause
