namespace OlympicGames.Models
{
    public interface ICountrySportService
    {
        List<CountrySport> GetAll();
        List<CountrySport> GetByGame(string game);
        List<CountrySport> GetByType(string type);
    }
}
