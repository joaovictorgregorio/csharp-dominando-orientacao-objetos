using Challenge_1.Movies;

Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("=== TESTE RAPIDO DA APLICACAO ===");
Console.ResetColor();
Console.WriteLine();

var filme = new Movie("Vingadores");
var artista = new Artist("Robert Downey Jr", 58);

Console.WriteLine("1) Estado inicial");
Console.WriteLine($"Filmes do artista: {artista.MoviesActed.Count}");
Console.WriteLine($"Artistas do filme: {filme.CastMembers.Count}");
Console.WriteLine();

Console.WriteLine("2) Usuario adiciona artista ao filme");
filme.AddArtist(artista);
Console.WriteLine($"Filmes do artista: {artista.MoviesActed.Count}");
Console.WriteLine($"Artistas do filme: {filme.CastMembers.Count}");
Console.WriteLine($"OK relacao filme->artista: {filme.CastMembers.Contains(artista)}");
Console.WriteLine($"OK relacao artista->filme: {artista.MoviesActed.Contains(filme)}");
Console.WriteLine();

Console.WriteLine("3) Usuario remove artista do filme");
filme.RemoveArtist(artista);
Console.WriteLine($"Filmes do artista: {artista.MoviesActed.Count}");
Console.WriteLine($"Artistas do filme: {filme.CastMembers.Count}");
Console.WriteLine($"OK removido do filme: {!filme.CastMembers.Contains(artista)}");
Console.WriteLine($"OK removido do artista: {!artista.MoviesActed.Contains(filme)}");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Teste finalizado.");
Console.ResetColor();