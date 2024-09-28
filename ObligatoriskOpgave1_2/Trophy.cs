namespace ObligatoriskOpgave1_2
{
    public class Trophy
    {
        // Properties
        public int Id { get; set; }
        public string Sport { get; set; } = "Sports";
        public int Year { get; set; }


        // Validate Sport
        public void validateSport()
        {
            if (Sport == null)
            {
                throw new ArgumentNullException("Sport can't be null.");
            }

            if (Sport.Length <= 4)
            {
                throw new ArgumentOutOfRangeException("Sport must be at least 4 characters or longer.");
            }
        }

        // Validate Year
        public void validateYear()
        {
            if (Year < 1970)
            {
                throw new ArgumentOutOfRangeException("Year cannot be lower than 1970");
            }

            if (Year > 2024)
            {
                throw new ArgumentOutOfRangeException("Year cannot go past 2024");
            }
        }

        // Validate All
        public void validate()
        {
            validateSport();
            validateYear();
        }

        // ToString Method
        public override string ToString()
        {
            return Id + " " + Sport + " " + Year;
        }



    }
}
