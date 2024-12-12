using System;

namespace ConsoleApp28
{

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Place { get; set; }
        public int Wins { get; set; }
        public int loose { get; set; }
        public int draw { get; set; }
        public int ZabGol { get; set; }
        public int LosGol { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            using (var context = new AppDbContext())
            {
                var team = new Team { Name = "ivanivka", Place = 2, Wins = 6, loose = 2, draw = 3, ZabGol = 27, LosGol = 9 };
                context.Teams.Add(team);
                context.SaveChanges();

            }

            //Show();

            using (var context = new AppDbContext())
            {
                var team = context.Teams.First(x => x.Name == "ivanivka");

                team.Name = "ivanivka";
                team.Place = 999;
                team.Wins = 0;
                team.loose = 100;
                team.draw = 0;
                team.ZabGol = 0;
                team.LosGol = 999999;

                context.SaveChanges();
            }

            //Show();

            using (var context = new AppDbContext())
            {
                var team = context.Teams.Where(x => x.Name == "ivanivka").ToList();

                context.Teams.RemoveRange(team);
                context.SaveChanges();
            }

            Show();
        }

        private static void Show()
        {
            using (var context = new AppDbContext())
            {
                var team = context.Teams.ToList();
                context.SaveChanges();

                team.ForEach(x => Console.WriteLine($"Id - {x.Id} \n Name - {x.Name} \n Place - {x.Place}\n Wins - {x.Wins}\n Looses - {x.loose}\n draw - {x.draw}\n ZabGol - {x.ZabGol}\n LosGol - {x.LosGol}"));

            }
        }
    }
}
