# EU4-Mod-Maker

This is going to be a Mod Editor for Europa Universalis 4.

The first goal is to be able to make random countries in the game (making ideagroups,ideas, government reforms and types, religion, etc.)
, after that i am going to dive in map creating and else.

I want to make a program, where you can learn scripting as well, so i am planning to create a GUI, where you can switch between
code view and "making" view so you can see every code change, while you are editing the mod.

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
	
	

