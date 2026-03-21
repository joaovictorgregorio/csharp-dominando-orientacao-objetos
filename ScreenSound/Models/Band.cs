namespace ScreenSound.Models;

class Band
{
    private List<Album> _albums = [];
    private List<int> _notes = [];

    #region CONSTRUCTOR
    public Band(string bandName) => BandName = bandName;

    #endregion CONSTRUCTOR

    public string? BandName { get; }
    public double Average => _notes.Average();

    #region ADD ALBUM
    public void AddAlbum(Album album) => _albums.Add(album);

    #endregion ADD ALBUM

    #region ADD NOTE
    public void AddNote(int note) => _notes.Add(note);

    #endregion ADD NOTE

    #region VIEW DISCOGRAPHY
    public void ViewDiscography()
    {
        Console.WriteLine($"Discografia da banda {BandName}", ConsoleColor.Green);

        foreach (Album album in _albums)
        {
            Console.WriteLine($" Álbum: {album.AlbumName} com duração total de ({album.TotalDuration}) segundos");
        }
    }
    #endregion VIEW DISCOGRAPHY
}
