namespace Challenge_1.Movies;

public class Artist
{
    #region CONSTRUCTOR
    public Artist(string? name, int age)
    {
        Name = name;
        Age = age;
        MoviesActed = [];
    }
    #endregion CONSTRUCTOR

    #region PROPERTIES
    public string? Name { get; set; }
    public int Age { get; set; }
    public List<Movie> MoviesActed { get; set; }

    #endregion PROPERTIES

    #region METHODS
    public void AddMovie(Movie movie)
    {
        if (movie == null || MoviesActed.Contains(movie)) 
            return; 

        MoviesActed.Add(movie);
        movie.AddArtistInternal(this);
    }

    public void RemoveMovie(Movie movie)
    {
        if (movie == null || !MoviesActed.Contains(movie))
            return;

        MoviesActed.Remove(movie);
        movie.RemoveArtistInternal(this);
    }

    // Método PRIVADO: apenas adiciona, sem sincronizar de volta
    internal void AddMovieInternal(Movie movie)
    {
        if (movie != null && !MoviesActed.Contains(movie))
            MoviesActed.Add(movie);
    }

    // Método PRIVADO: apenas remove, sem sincronizar de volta
    internal void RemoveMovieInternal(Movie movie)
    {
        if (movie != null)
            MoviesActed.Remove(movie);
    }

    #endregion METHODS
}
