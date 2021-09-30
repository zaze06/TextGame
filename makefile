build:
	mcs *.cs -r:"Newtonsoft.json.dll" -out:"out/Game.exe"
run:
	mono --attach="Newtonsoft.json.dll" "out/Game.exe"
#export:
#	cd MacOs
#	mkbundle -o Game --
