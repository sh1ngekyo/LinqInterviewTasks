using LinqTasks;
using System.Collections;

var data = new List<object>() {
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
//1 Output all elements excepting ArtObjects
Console.WriteLine(string.Join(", ", data
    .Where(x => x is not ArtObject)
    .Select(x => (x as IEnumerable).Cast<object>())
    .Select(x => string.Join("", x))));
Console.WriteLine();

//2 Output all actors names
Console.WriteLine(string.Join(", ", data
    .Where(x => x is Film)
    .SelectMany(x => ((Film)x).Actors.Select(x => x.Name))
    .Distinct()));
Console.WriteLine();

//3 Output number of actors born in august
Console.WriteLine(string.Join(", ", data
   .Where(x => x is Film)
   .SelectMany(x => ((Film)x).Actors.Where(x => x.Birthdate.Month == 8))
   .Count()));
Console.WriteLine();

//4 Output two oldest actors names
Console.WriteLine(string.Join(", ", data
   .Where(x => x is Film)
   .SelectMany(x => ((Film)x).Actors)
   .OrderBy(x => x.Birthdate)
   .Take(2)
   .Select(x => x.Name)));
Console.WriteLine();

//5 Output number of books per authors
Console.WriteLine(string.Join("\n", data
    .OfType<Book>()
    .GroupBy(x => x.Author)
    .Select(x => x.Key + ": " + x.Count())));
Console.WriteLine();

//6 Output number of books per authors and films per director
Console.WriteLine(string.Join(", ", data
    .Where(x => x is ArtObject)
    .GroupBy(x => new
    {
        (x as ArtObject).Author,
        TypeOfArt = x.GetType().Name
    })
    .Select(x => (x.Key.TypeOfArt == nameof(Book) ? "Author: " : "Director: ") + x.Key.Author + "\t" + x.Count())));
Console.WriteLine();

//7 Output how many different letters used in all actors names
Console.WriteLine(string.Join(", ", data
    .Where(x => x is Film)
    .GroupBy(x => (x as Film).Actors)
    .SelectMany(x => x.Key.Select(x => x.Name))
    .Distinct()
    .Select(x => x + ": " + x.Distinct().Count())));
Console.WriteLine();

//8 Output names of all books ordered by names of their authors and number of pages
Console.WriteLine(string.Join(", ", data
    .Where(x => x is Book).OrderBy(x => (x as Book).Author).ThenByDescending(x =>
        (x as Book).Pages).Select(x => (x as Book).Name)));
Console.WriteLine();

//9 Output actor name and all films with this actor
Console.WriteLine(string.Join("\n", data
    .Where(x => x is Film).SelectMany(x => (x as Film).Actors).GroupBy(x => new
    {
        Films = data.Where(y => y is Film && (y as Film).Actors.Any(z => z.Name == x.Name))
    }).Select(x => x.First().Name + ": " + string.Join(", ", x.Key.Films.Select(y => (y as Film).Name))).Distinct()));
Console.WriteLine();

//10 Output sum of total number of pages in all books and all int values inside all sequences in data
Console.WriteLine(string.Join("\n",
    (data.Where(x => x is Book).Sum(x => (x as Book).Pages))
    + data.OfType<IEnumerable<int>>().SelectMany(x => x).Sum()));
Console.WriteLine();

//11 Get the dictionary with the key - book author, value - list of author's books
Console.WriteLine(string.Join("\n", data
    .Where(x => x is Book)
    .GroupBy(x => (x as Book).Author)
    .ToDictionary(x => x.Key, x => x.ToList())
    .Select(x => x.Key + ": " + string.Join(", ", x.Value.Select(y => (y as Book).Name)))));
Console.WriteLine();

//12 Output all films of "Matt Damon" excluding films with actors whose name are presented in data as strings
Console.WriteLine(string.Join(", ", data
    .Where(x => x is Film && (x as Film).Actors.Any(x => x.Name == "Matt Damon"))
    .Except(data.Where(x => x is Film && (x as Film).Actors.Any(x => data.OfType<string>().Contains(x.Name))))
    .Select(x => (x as Film).Name)));
Console.WriteLine();