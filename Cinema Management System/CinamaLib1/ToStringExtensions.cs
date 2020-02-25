namespace CinamaLib1
{

    public partial class Movie
    {
        public override string ToString()
        {
            return $"{Name}";
            //          return $"{Name} - ({Id})";
        }

        public string AsString => ToString();

    }


    public partial class ScheduleItem
    {
        public override string ToString()
        {
            return $"{Time}: {MovieItem} ";
        }
        public string AsString => ToString();

    }

}
