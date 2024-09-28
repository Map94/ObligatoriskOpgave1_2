using ObligatoriskOpgave1_2;


namespace ObligatoriskOpgave1_2Test
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {
        private TrophiesRepository repository;

        public TrophiesRepositoryTests()
        {
            repository = new TrophiesRepository();
        }

        // Method 1: GetById
        [TestMethod()]
        // ID found
        public void Get_TrophyById_ReturnTrophyObject()
        {
            Trophy trophy = repository.GetById(1); 

            Assert.AreEqual(1, trophy.Id);
        }

        [TestMethod()]
        // No ID found
        public void Get_TrophyById_ReturnNull()
        {
            Trophy trophy = repository.GetById(99); 

            Assert.IsNull(trophy, "No trophy found with id " + 99);
        }


        // Method 2: Add       
        [TestMethod()]
        public void Add_Trophy_ReturnTrophyObject()
        {
            Trophy trophy = repository.Add(new Trophy() { Sport = "Football", Year = 2016 });

            Assert.AreEqual(6, trophy.Id);
        }


        // Method 3: Remove
        [TestMethod()]
        public void Remove_Trophy_ReturnTrophyObject()
        {
            Trophy trophy = repository.Add(new Trophy() { Sport = "Breakdancing", Year = 1991 });

            Assert.IsNotNull(repository.Remove(trophy.Id));

        }

        [TestMethod()]
        public void Remove_Trophy_ReturnNull()
        {
            Trophy trophy = repository.Add(new Trophy() { Sport = "Breakdancing", Year = 1991 });

            Assert.IsNull(repository.Remove(trophy.Id++), "No trophy found with id " + trophy.Id);
        }


        // Method 4: Get (Filter and Sort)
        [TestMethod()]
        public void Get_FilteredByYearTrophyList_ReturnFilteredList()
        {
            List<Trophy> filteredTrophy = repository.Get(1994);

            Assert.AreEqual(1994, filteredTrophy[0].Year);
            Assert.AreEqual(1, filteredTrophy.Count());
        }

        [TestMethod()]
        public void Get_SortByYearTrophyList_ReturnSortedList()
        {
            int[] expectedYearOrder = { 2017, 2001, 1994, 1991, 1987 };
            List<Trophy> orderedTrophy = repository.Get(sortBy: "year");

            for (int i = 0; i < expectedYearOrder.Length; i++)
            {
                Assert.AreEqual(expectedYearOrder[i], orderedTrophy[i].Year);
            }
        }
    }
}