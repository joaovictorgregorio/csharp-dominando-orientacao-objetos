namespace Challenge_1.Movies;

public class Movie
{
    #region CONSTRUCTOR
    public Movie(string? movieTitle)
    {
        MovieTitle = movieTitle;
        CastMembers = [];
    }
    #endregion CONSTRUCTOR

    #region PROPERTIES
    public string? MovieTitle { get; set; }
    public int DurationInHours { get; set; }
    public string? MovieCast { get; set; }
    public List<Artist> CastMembers { get; set; }

    #endregion PROPERTIES

    #region METHODS
    public void AddArtist(Artist artist)
    {
        if (artist == null || CastMembers.Contains(artist)) 
            return;

        CastMembers.Add(artist);
        artist.AddMovieInternal(this);
    }

    public void RemoveArtist(Artist artist)
    {
        if (artist == null || !CastMembers.Contains(artist)) 
            return;

        CastMembers.Remove(artist);
        artist.RemoveMovieInternal(this);
    }

    // Método PRIVADO: apenas adiciona, sem sincronizar de volta
    internal void AddArtistInternal(Artist artist)
    {
        if (artist != null && !CastMembers.Contains(artist))
            CastMembers.Add(artist);
    }

    // Método PRIVADO: apenas remove, sem sincronizar de volta
    internal void RemoveArtistInternal(Artist artist)
    {
        if (artist != null)
            CastMembers.Remove(artist);
    }

    #endregion METHODS
}
