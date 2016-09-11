# Unity-Tower-Defense
This project was to test my skills in problems solving and game design. I may further it down the road if I can find a solid direction for it. 

There were multiple problems I encountered in the development of this game that have been extremely useful in other fields of programming. 

One of the best solutions I found for this game is an answer to A* pathfinding in Unity. I took an array of "node" tiles that I had created prior to running the game in the editor. The code ended up becoming very powerful with a high usability. After creating a node list in the editor, the list can then be dropped onto a script on the enemySpawer prefab. When enemies spawn, they are passed the node list and then step through each node using a for loop. When the enemies reach the next node in the list (a determined by enemy.transform = node.transform) they just change direction to head towards the next node, until they reach the final node. When this happens the enemies set themselves inactive to be put back in the pool. 
NOTE: The node system allows for 360 degree movement from node to node. 

This code is being constantly updated as I find time to work on the project.
