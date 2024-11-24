using Lab4.Objects;

namespace Lab4.Web
{
    public static class ChoreWorkforceExtension
    {
        private static string[] _Names = {"Jem", "Jan", "Jim", "John", "Jill", "Jack", "Jesse", "Jessie", "Jacob", "Jeremy", "Jocelyn"};
        public static void AddLaborer(this ChoreWorkforce workforce, string name, int age, int difficulty)
        {
            workforce.Laborers.Add(new ChoreLaborer{
                Name = name,
                Age = age,
                Difficulty = difficulty
            });
        }
        public static void AddRandomLaborer(this ChoreWorkforce workforce)
        {
            var rand = new Random();
            int difficulty = rand.Next(1, 11);
            if(difficulty == 10)
            {
                workforce.Laborers.Add(null);
            }
            else
            {
                workforce.Laborers.Add(new ChoreLaborer{
                    Name = _Names[rand.Next(11)],
                    Age = rand.Next(3, 18),
                    Difficulty = difficulty
                });
            }
        }
    }
}