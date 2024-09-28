namespace ObligatoriskOpgave1_2
{ 
    public class TrophiesRepository
    {
    // Properties
    public int nextId = 1;
    private List<Trophy> trophies = new List<Trophy>();

    public TrophiesRepository()
    {

        Trophy trophy1 = new Trophy { Year = 1987, Sport = "Table Tennis" };
        Trophy trophy2 = new Trophy { Year = 1991, Sport = "Breakdancing" };
        Trophy trophy3 = new Trophy { Year = 1994, Sport = "Surfing" };
        Trophy trophy4 = new Trophy { Year = 2001, Sport = "Basketball" };
        Trophy trophy5 = new Trophy { Year = 2017, Sport = "Archery" };

        Add(trophy1);
        Add(trophy2);
        Add(trophy3);
        Add(trophy4);
        Add(trophy5);
    }



    public List<Trophy> Get(int? Year = null, string? sortBy = null)
    {
        List<Trophy> list = new List<Trophy>(trophies);

        // filter by Year
        if (Year != null)
        {
            list = list.Where(item => item.Year == Year).ToList();
        }

        // Sort by Sport or year
        if (sortBy != null)
        {
            if (sortBy == "Sport")
            {
                list = list.OrderBy(item => item.Sport).ToList();
            }

            if (sortBy == "year")
            {
                list = list.OrderByDescending(item => item.Year).ToList();
            }
        }

        // Return List
        return list;
    }

    public Trophy? GetById(int id)
    {
        return trophies.FirstOrDefault(t => t.Id == id);
    }

    public Trophy? Add(Trophy trophy)
    {
        trophy.validate();
        trophy.Id = nextId++;
        trophies.Add(trophy);

        return trophy;
    }

    public Trophy? Remove(int id)
    {
        Trophy? trophy = GetById(id);

        if (trophy == null)
        {
            return null;
        }

        trophies.Remove(trophy);

        return trophy;
    }

    public Trophy? Update(int id, Trophy values)
    {
        values.validate();

        Trophy? targetTrophy = GetById(id);

        if (targetTrophy == null)
        {
            return null;
        }

        targetTrophy.Sport = values.Sport;
        targetTrophy.Year = values.Year;

            return targetTrophy;
    }
}
}
