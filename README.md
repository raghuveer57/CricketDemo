# CricketDemo

## Basic approach:
Used the Mediator design pattern in solving this problem.
The interaction between the components, UI objects and Game Objects which are in the scene can only happen through the `GameManager` class which acts as the `Mediator`. Also the entire game evaluation logic happens in this class.

Additonally, I have only used the Unity's Event Triggers ( Event Sytem) to handle the interactions.

I could not find any suitable assets that I could use for implementing this. I have implemented this using the bare minimum assets covering all the functionality. Instead of animations I have used custom status messaging mechanism to display the status/progress/state of the game.

Below are the implementation details for each level

## Level 1 : Bowling Mechanism

Instead of the 2D matrix grid, which was suggested in the problem statement, I have used 3d planes to simulate the `Cricket Pitch` and created the required grids on the pitch.
Added Event triggers and associated them with the neccessary functions.

For now the implementation is based on clicking the grids. But this behavior can easily swapped with other behaviors since it is isolated with the rest of the system. ( For example., we could have user throw the ball on the grid and make this partially skill based)

## Level 2: Batting Mechanism

Implemented the functionality which was mentioned in the problem statement. However, there was no clarity on what basis a batsmen is declared `OUT`.

For that I've created another probabilty table and used it for determining the `OUT` scenarios.


| Selected Runs | OutProbabilty|
|----| -----------|
| 0 | 2 percent|
|1| 5 percent|
|2| 7 percent|
|4| 12 perecent|
|5| 15 precent|

After several roungs of testing, I have changed the target score to 30 where we get different outcomes frequently.

## Level 3: Score tracking

Implemented the UI for tracking the scores and overs.

## Level 4: Trajectories for the ball

Couldn't implement them because of the lack of suitable assets. However, I have implemented custom status messaging which should be the placeholders for animations.

## Level 5: Dragging and dropping the ball

This was not feasible with the current design. As mentioned earlier, we could have user throw the ball on the grid and make this partially skill based.

