using Microsoft.EntityFrameworkCore;

namespace CountriesPractical
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            using (AppConect db = new AppConect())
            {
                Country USA = new Country { Name = "USA", CapitalName = "Washington", Population = 331000000, Area = 9833520, PartOfTheWorld = "North America" };
                Country Russia = new Country { Name = "Russia", CapitalName = "Moscaw", Population = 145000000, Area = 148940000, PartOfTheWorld = "Eurasia" };
                Country Italy = new Country { Name = "Italy", CapitalName = "Rom", Population = 59000000, Area = 301230, PartOfTheWorld = "Europ" };
                Country Mexico = new Country { Name = "Mexico", CapitalName = "MexicoCity", Population = 126000000, Area = 1972550, PartOfTheWorld = "South America" };
                Country Japan = new Country { Name = "Japan", CapitalName = "Tokio", Population = 125000000, Area = 377973, PartOfTheWorld = "Asia" };
                Country SouthAfrica = new Country { Name = "SouthAfrica", CapitalName = "CapeTown", Population = 59000000, Area = 1220000, PartOfTheWorld = "Africa" };

                db.country.Add(USA);
                db.country.Add(Russia);
                db.country.Add(Italy);
                db.country.Add(Mexico);
                db.country.Add(Japan);
                db.country.Add(SouthAfrica);
                db.SaveChanges();
                MessageBox.Show("Объекты успешно сохранены");

                var countries = db.country.ToList();

                foreach (Country c in countries)
                {
                    dataGridView1.DataSource = c;
                }

            }
        }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CapitalName { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }
        public string PartOfTheWorld { get; set; }

    }

    public class AppConect:DbContext
    {
        public DbSet<Country> country => Set<Country>();

        public AppConect() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=countries.db");
        }
    }


}