# EU4-Mod-Maker

This is going to be a Mod Editor for Europa Universalis 4.

The first goal is to be able to make random countries in the game (making ideagroups,ideas, government reforms and types, religion, etc.)
, after that i am going to dive in map creating and else.

# Goal
My goal with this mod maker is mostly educational and i want to use it as a reference. Of course I want to
help the modders of Europa Universalis 4, but i don't think anyone will use it in the future. 

# Used Programs and Frameworks
1. WhiteStarUml for making Diagrams
2. Visual Studio for coding and github management
3. .Net Framework and WinForms application for GUI and else.
4. Word for making documentation. (probably will)

# Progress Reports

2021-10-12 report:
Progress:
	The program can read the script files into Expression class objects, making a graph as well as it can write back to the standard output
	in the right format. The plan is to be able to make different classes from the File class and be able to convert back to the File class.
	If the program will be able to do this, then we can just make changes in the classes and then convert to File class and save it.
Next Step:
	I want to be able to make all classes in the country maker Diagram convertable into File class and vice versa.
	The next step is at least making the common class part of the country convertable.
	
2021-10-16 report:
Progress:
	I tested the file reading and writing, but the reading wasn't good, so i tried to make a state machine to read the files bit by bit.
	I made the rough version of the state machince in paint, but continued debugging in code, so i should update the drawing.
	In the final test i read and wrote 6590 files successfully, then compared the input and output to each other without the unnecessary 
	characters like whitespaces and comments. I didn't test all the files from the Europa Universalis 4 game, but i think it will be 
	enough to get started.
Next Step:
	Now i can work on making the classes i wrote convertable back and forth to Expression classes.
	
2021-10-19 report:
Progress:
	Made the state machine in WhiteStarUml program and rewrote the state machine, so the code is more likely readable. My plan for making classes Convertable
	is to make an interface, that have 4 functions. 2 of them is reading files or a file and fill the class/classes. The other 2 is for Converting the class to files or file objects.
Next Step:
	Writing comments on code and implement the interface as well as start country making part of the program.
	

