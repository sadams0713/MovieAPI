using System;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Controllers.Models;

namespace CreatingAMovieAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MovieController
	{
		public List<Movie> Movies = new List<Movie>
		{
			new Movie(){ Title="Forest Gump", Genre = Genre.Comedy, ReleaseYear=1993},
			new Movie(){ Title="Shrek", Genre = Genre.Comedy, ReleaseYear=2001},
			new Movie(){ Title="The Thing", Genre = Genre.Horror, ReleaseYear=1985},
			new Movie(){ Title="Finding Nemo", Genre = Genre.Animated, ReleaseYear=2003},
			new Movie(){ Title="10 Things I Hate About You", Genre = Genre.Romance, ReleaseYear= 2005},
			new Movie(){ Title="28 Days Later", Genre = Genre.Horror, ReleaseYear=1985},
			new Movie(){ Title="Wedding Crashers", Genre = Genre.Comedy, ReleaseYear=1975}
		};

		[HttpGet("FullMovieList")]
		public List<Movie> GetMovies()
		{
			return Movies;
		}

		[HttpGet("SearchByGenre/{genre}")]
		public List<Movie> SearchByGenre(Genre genre)
		{
			List<Movie> result = Movies.Where(x => x.Genre == genre).ToList();
			return result;
		}

		[HttpGet("FindRandomMovie")]
		public Movie FindRandomMovie()
		{
			Random r = new Random();

			return Movies[r.Next(0, Movies.Count)];
		}

		[HttpGet("RandomMovieByGenre/{genre}")]
		public Movie RandomMovieByGenre(Genre genre)
		{
			Random r = new Random();
			List<Movie> result = Movies.Where(x => x.Genre == genre).ToList();

			return result[r.Next(0, result.Count)];
		}

		[HttpGet("RandomListOfMoviesByInt/{number}")]
		public List<Movie> RandomListOfMoviesByInt(int num)
		{
			Random r = new Random();
			List<Movie> result = new List<Movie>();

			for (int i = 0; i < num; i++)
			{
				result.Add(Movies[r.Next(0, Movies.Count)]);
			}
			return result;
		}

		[HttpGet("FindMovieByKeyword/{searchterm}")]
		public Movie FindMovieByKeyword(string input)
		{
			Movie result = (Movie)Movies.Where(x => x.Title.ToLower() == input.ToLower());
			return result;
		}

		[HttpGet("SearchByKeyWord/{searchterm}")]
		public List<Movie> SearchByKeyWord(string input)
		{
			List<Movie> result = Movies.Where(x => x.Title.ToLower().Contains(input.ToLower())).ToList();
			return result;
		}

	}
}