build:
	mcs *.cs -r:"Newtonsoft.json.dll"
run:
	mono --attach="Newtonsoft.json.dll" Game.exe