namespace ConsoleApp2
{
    internal class MountainBike: Bicycle
    {
        private int seatHeight;
        public MountainBike(int height, int startCadence, int startSpeed, int startGear)
            : base(startCadence, startSpeed, startGear)
        {
            seatHeight = height;
        }
        public void setHeight(int newValue)
        {
            seatHeight = newValue;
        }
        public string getInfo()
        {
            return getBikeInfo() + "\nSeat Height: " + seatHeight;
        }
        public string getHeight()
        {
            return seatHeight.ToString();
            
        }
    }
}