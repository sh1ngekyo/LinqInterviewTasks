# Linq Interview Tasks
All tasks should be done as a single line of code like: Console.WriteLine(YOUR CODE HERE);
## Level 1
- ### Methods to use:
  - String: 
    - string.Join, string.Concat, new string
    - string.Split, 
    - Contains, StartsWith, EndsWith
  - Linq: 
    - Select, Where, Skip[While], Take[While],
    - Min, Max, Sum, Average, Count,
    - Reverse,
    - All, Any, Contains
    - First[OrDefault], Last[OrDefault], Single[OrDefault],
    - Range, Repeat,
    - ToArray, ToList
- ### Tasks:
1. Print all numbers from 10 to 50 separated by commas
2. Print only that numbers from 10 to 50 that can be divided by 3
3. Output word "Linq" 10 times
4. Output all words with letter 'a' in string "aaa;abb;ccc;dap"
5. Output number of letters 'a' in the words with this letter in string "aaa;abb;ccc;dap" separated by comma
6. Output true if word "abb" exists in line  "aaa;xabbx;abb;ccc;dap", otherwise false
7. Get the longest word in string "aaa;xabbx;abb;ccc;dap"
8. Calculate average length of word in string "aaa;xabbx;abb;ccc;dap"
9. Print the shortest word reversed in string "aaa;xabbx;abb;ccc;dap;zh"
10. Print true if in the first word that starts from "aa" all letters are 'b' otherwise false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"

## Level 2
  - ### Methods to use:
    - All Level 1 methods
    - GroupBy, OrderBy, ThenBy, Distinct,
    - Concat
    - SelectMany,
    - Except, Intersect, Union,
    - SequenceEquals,
    - Cast, OfType, ToDictionary
  - ### Prepare:
```csharp
class Actor
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
}
abstract class ArtObject
{
    public string Author { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
}
class Film : ArtObject
{
    public int Length { get; set; }
    public IEnumerable<Actor> Actors { get; set; }
}
class Book : ArtObject
{
    public int Pages { get; set; }
}
var data = new List<object>() 
{
    "Hello",
    new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
    new List<int>() {4, 6, 8, 2},
    new string[] {"Hello inside array"},
    new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
        new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
        new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
        new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
    }},
    new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
        new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
        new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
    }},
    new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
    new Book() { Author = "Terry Pratchett", Name = "Test", Pages = 555 },
    "Leonardo DiCaprio"
};
```

  - ### Tasks:
  1. Output all elements excepting ArtObjects
  2. Output all actors names
  3. Output number of actors born in august
  4. Output two oldest actors names
  5. Output number of books per authors
  6. Output number of books per authors and films per director
  7. Output how many different letters used in all actors names
  8. Output names of all books ordered by names of their authors and number of pages
  9. Output actor name and all films with this actor
  10. Output sum of total number of pages in all books and all int values inside all sequences in data
  11. Get the dictionary with the key - book author, value - list of author's books
  12. Output all films of "Matt Damon" excluding films with actors whose name are presented in data as strings
