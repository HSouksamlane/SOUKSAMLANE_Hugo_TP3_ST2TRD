using System;
using System.Linq;

namespace SOUKSAMLANE_Hugo_TP3_ST2TRD
{
    public class Queries
    {
        public void run_queries()
        {
            var database_movies = new MovieCollection();

            // Query 1
            Console.WriteLine("Query 1 :");
            var oldest_movie = (from p in database_movies.Movies
                                orderby p.ReleaseDate ascending
                                select p).First();

            Console.WriteLine("The title of the oldest movie is " + oldest_movie.Title);

            // Query 2
            Console.WriteLine("\nQuery 2 :");
            var total_number = (from p in database_movies.Movies
                                select p).Count();

            Console.WriteLine("The total number of movies in the collection is " + total_number);


            // Query 3 
            Console.WriteLine("\nQuery 3 :");
            var movies_e = (from p in database_movies.Movies
                            where p.Title.Contains("e") == true
                            select p).Count();

            Console.WriteLine("The total number of movies with the letter e at least once in their title is " + movies_e);


            // Query 4
            Console.WriteLine("\nQuery 4 :");
            var f_occcurences = (from p in database_movies.Movies

                select p.Title.Count(m => m == 'f')).Sum() ;

 

            Console.WriteLine("The total amount of f letter through all the titles is " + f_occcurences);

            // Query 5
            Console.WriteLine("\nQuery 5 :");
            var higher_budget = (from p in database_movies.Movies
                                 where p.Budget != null
                                 orderby p.Budget descending
                                 select p).First();

            Console.WriteLine("The name of the movie with the highest budget is " + higher_budget.Title);


            // Query 6
            Console.WriteLine("\nQuery 6 :");
            var lowest_box = (from p in database_movies.Movies
                              where p.BoxOffice != null
                              orderby p.BoxOffice ascending
                              select p).First();

            Console.WriteLine("The name of movie with the lowest box office is " + lowest_box.Title);

            // Query 7
            Console.WriteLine("\nQuery 7 :");
            var reversed_alphabetical = (from p in database_movies.Movies
                                         orderby p.Title descending
                                         select p).Take(10);

            Console.WriteLine("Here below the list of the 11 first movies ordered in reversed alphabetical order :\n");
            foreach (var p in reversed_alphabetical)
            {
                Console.WriteLine(p.Title);
            }

            // Query 8
            Console.WriteLine("\nQuery 8 :");
            var before_1980 = (from p in database_movies.Movies

                where p.ReleaseDate < new DateTime(1980,01,01)

                select p).Count();
            
            Console.WriteLine("The amount of movies made before 1980 is " + before_1980);
            
            // Query 9 
            Console.WriteLine("\nQuery 9 :");
            char[] vowels = new[] { 'a','e','i','o','u','y','A','E','I','O','U','Y' };
            
            var average_running = (from p in database_movies.Movies
                                   where vowels.Contains(p.Title[0])
                                   select p.RunningTime).Average(); 

            Console.WriteLine("The average running time of movies having a vowel as the first letter is : " + average_running);

            // Query 10 
            Console.WriteLine("\nQuery 10 :");
            var query_10 = (from p in database_movies.Movies
                            where ((p.Title.ToLower().Contains('i') == false || p.Title.ToLower().Contains('t') == false ) && (p.Title.ToLower().Contains('h') || p.Title.ToLower().Contains('w')))
                            select p);

            Console.WriteLine("Here below is the list of all the movies with the letters H or W in the title, but not the letters I and T :\n");

            foreach (var p in query_10)
            {
                Console.WriteLine(p.Title);
            }
            
            // Query 11
            Console.WriteLine("\nQuery 11 :");
            var mean = (from p in database_movies.Movies
                    where (p.BoxOffice != null && p.Budget != null && (p.Budget / p.BoxOffice) < 50 )
                    select (p.Budget / p.BoxOffice)).Average();

            Console.WriteLine("The mean of all Budgets/Box Office of every movie year is : " + mean);
            
        }
        
    }
}