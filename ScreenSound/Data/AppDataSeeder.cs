using ScreenSound.Models;

namespace ScreenSound.Data;

internal class AppDataSeeder
{
    public static Dictionary<string, Band> CreateRegisterBands()
    {
        Dictionary<string, Band> registeredBands = new(StringComparer.OrdinalIgnoreCase);

        var ira = new Band("Ira");
        ira.AddNote(new Evaluation(10));
        ira.AddNote(new Evaluation(9));
        ira.AddNote(new Evaluation(6));
        registeredBands.Add(ira.BandName!, ira);

        var beatles = new Band("The Beatles");
        registeredBands.Add(beatles.BandName!, beatles);

        var theWho = new Band("The Who");
        theWho.AddNote(new Evaluation(7));
        theWho.AddNote(new Evaluation(8));
        theWho.AddNote(new Evaluation(9));
        registeredBands.Add(theWho.BandName!, theWho);

        return registeredBands;
    }
}
