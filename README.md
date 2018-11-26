# 1o Projeto de LP2 (2018)

## Our solution

### Division of Tasks

Nuno took care of `Game` (represents each object from the .csv file) and `UserInputs` (manage user inputs from all the menus) classes.
Rui created `ReadFromFile` (read from file and turn each object into Game) and `ManageSearchEngine` (sort, filtering, etc).
`Renderer` methods were created by both.

Both worked on all the classes as the project kept improving.

Extras were implemented by both.
**Rui
Show downloaded image to user.

**Nuno
Show help website if user chooses so.

### Architecture

When starting the program, values are read from the specified .csv file and values are put into a `List`.
Then the user can simply search a game by ID, or do an advanced search in which Sort and Filtering can be applied.

For this project we created a `ReadFromFile` class which reads from the specified .csv file and turns each line into a `Game` object.
Each `Game` object was stored into a `HashSet<Game>` (both `Equals()` and `GetHashCode` from `Game` class were overriden to compare `Game` objects by ID, avoiding repeated games).
After that, the `HashSet` values were passed into a `List` so we could sort it later.

For the sort and filtering, we used `lambda` expressions on a new list that receives all the values from the original one.
After each search or if the user goes back to the previous menu, the filtered list receives the original list values again (resets).

### Flowchart

![Flowchart](https://i.imgur.com/qhmfBD6.png)

### UML Diagram

![Diagram(UML)](https://i.imgur.com/iQTKuyt.png)

## Conclusions

This was a simple project, but it expanded our knowledge as we used a new collection (`HashSet`) and learned how useful it can be.
Same goes to `lambda` expressions which made it so much easier to do both Sort and Filtering options.

Overall it was fun to do, and we both worked equally hard which helped a lot to finish everything in time.

## References

* <a name="ref1">\[1\]</a> Whitaker, R. B. (2016). The C# Player's Guide (3rd Edition). Starbound Software

## Metadata

* Authors: Nuno Carriço and Rui Martins
* Collaborators: Ianis Arquissandas