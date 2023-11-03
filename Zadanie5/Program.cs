
internal class Program
{
    public struct Record
    {
        public int ClientID;
        public int Year;
        public int Month;
        public int Duration;

        public Record(int clientID, int year, int month, int duration) : this()
        {
            ClientID = clientID;
            Year = year;
            Month = month;
            Duration = duration;
        }
    }

    private static void Main()
    {

        string[] text = { "В начале июля, в чрезвычайно жаркое время, под вечер, один молодой человек вышел из своей каморки, которую нанимал от жильцов в С — м переулке, на улицу и медленно, как бы в нерешимости, отправился к К — ну мосту.", "Он благополучно избегнул встречи с своею хозяйкой на лестнице.", "Каморка его приходилась под самою кровлей высокого пятиэтажного дома и походила более на шкаф, чем на квартиру." };

        static List<string> GetWords(string[] textArray, int n) => textArray.SelectMany(text => text.Split(new[] { ' ', '.', ',', '!', '?', ':', ';', '-', '(', ')' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(word => word.Length >= n)
                .Select(word => word.ToLower())
                .Distinct()
                .OrderBy(word => word)
                .ToList();

        foreach (string word in GetWords(text, 8))
            Console.WriteLine(word);

        static void GetMaxDurationYear(List<Record> clients)
        {
            var maxDurationYear = clients.GroupBy(client => client.Year)
                .Select(group => new { Year = group.Key, TotalDuration = group.Sum(client => client.Duration) })
                .OrderByDescending(group => group.TotalDuration)
                .ThenBy(group => group.Year)
                .First();

            Console.WriteLine($"Год: {maxDurationYear.Year}, продолжительность: {maxDurationYear.TotalDuration}");
        }

        var John = new Record(1, 2022, 4, 20);
        var Jane = new Record(1, 2022, 5, 20);
        var Johnson = new Record(2, 2021, 8, 50);
        var Jill = new Record(3, 2022, 6, 30);
        var Alex = new Record(3, 2021, 1, 10);
        var clients_test1 = new List<Record>() { John, Jane, Johnson, Jill, Alex };
        GetMaxDurationYear(clients_test1);

        Alex.Duration = 20;
        var clients_test2 = new List<Record>() { John, Jane, Johnson, Jill, Alex };
        GetMaxDurationYear(clients_test2);
    }
}