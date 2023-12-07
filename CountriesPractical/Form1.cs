using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using SQLitePCL;
using CountriesPractical;

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
            //using (AppConect db = new AppConect())
            //{

            //    Country USA = new Country { Name = "USA", CapitalName = "Washington", Population = 331000000, Area = 9833520, PartOfTheWorld = "North America" };
            //    Country Russia = new Country { Name = "Russia", CapitalName = "Moscaw", Population = 145000000, Area = 148940000, PartOfTheWorld = "Eurasia" };
            //    Country Italy = new Country { Name = "Italy", CapitalName = "Rom", Population = 59000000, Area = 301230, PartOfTheWorld = "Europ" };
            //    Country Mexico = new Country { Name = "Mexico", CapitalName = "MexicoCity", Population = 126000000, Area = 1972550, PartOfTheWorld = "South America" };
            //    Country Japan = new Country { Name = "Japan", CapitalName = "Tokio", Population = 125000000, Area = 377973, PartOfTheWorld = "Asia" };
            //    Country SouthAfrica = new Country { Name = "SouthAfrica", CapitalName = "CapeTown", Population = 59000000, Area = 1220000, PartOfTheWorld = "Africa" };

            //    db.country.Add(USA);
            //    db.country.Add(Russia);
            //    db.country.Add(Italy);
            //    db.country.Add(Mexico);
            //    db.country.Add(Japan);
            //    db.country.Add(SouthAfrica);
            //    db.SaveChanges();
            //    MessageBox.Show("Объекты успешно сохранены");

            //}
        }


        public void ShowAllCointries()
        {
            using (AppConect db = new AppConect())
            {
                var countries = db.country.ToList();
                listBox1.Items.AddRange(countries.ToArray());
            }
        }

        public void ShowAllCointriesName()
        {
            using (AppConect db = new AppConect())
            {
                var countries = db.country.ToList();
                listBox1.DisplayMember = "Name";
                listBox1.Items.AddRange(countries.ToArray());
            }
        }

        public void ShowAllCointriesCapitalName()
        {
            using (AppConect db = new AppConect())
            {
                var countries = db.country.ToList();
                listBox1.DisplayMember = "CapitalName";
                listBox1.Items.AddRange(countries.ToArray());
            }
        }

        public void ShowAllCointriesInEurop()
        {
            using (AppConect db = new AppConect())
            {
                var europeanCountries = db.country.Where(c => c.PartOfTheWorld == "Europ").ToList();

                listBox1.DisplayMember = "Name";
                listBox1.Items.AddRange(europeanCountries.ToArray());
            }
        }

        public void ShowAllCointriesWhreAreaMoreOneMilloin()
        {
            using (AppConect db = new AppConect())
            {
                var Countries = db.country.Where(c => c.Area >= 1000000).ToList();


                var countries = db.country.ToList();
                listBox1.Items.AddRange(countries.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ShowAllCointries();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ShowAllCointriesName();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ShowAllCointriesCapitalName();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ShowAllCointriesInEurop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ShowAllCointriesWhreAreaMoreOneMilloin();
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

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Capital: {CapitalName}, Population: {Population}, Area: {Area}, Part of the World: {PartOfTheWorld}";
        }
    }

    public class AppConect : DbContext
    {
        public DbSet<Country> country => Set<Country>();

        public AppConect() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=countries.db");
        }
    }

}

