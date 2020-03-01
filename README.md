
# Text Game

Creative title for creative project.

## Frames

Frames are the most basic unit in the game scaffold.  A `Frame` is a way to subdivide the game into discrete scenes and interactions. The most basic form of a `Frame` is a message and nothing else, the death frame is a good example.

```
-------------------------------------------------
Rock falls, you die.
-------------------------------------------------
```

Frames may also provide a link to the next `Frame` in the sequence. If you only provide a message and a link to the following `Frame`, you have a `Cutscene`.

```
-------------------------------------------------
You have a new debuff: head wound.
You are now in a new location: a small cell.
Your head aches. Your head feels wet and sticky.
You're sitting on a hard stone floor in a small room. A door with bars at face height dominates one wall. One other person is lies in a heap in the corner.
Your name is Jeff... you don't remember how you got here.
-------------------------------------------------
```

Notice the user isn't prompted for any input. If you require input use `Question` or implement the`ITakeInput` interface.

```
-------------------------------------------------
What now?
 > 
-------------------------------------------------
 ```

If you wish to provide a hint implement `IHaveAHint`. The player can then use the command `hint?` if they're lost.

```
-------------------------------------------------
What now?
 > hint?
It doesn't look good around here.
What now?
 > don't die
-------------------------------------------------
```
