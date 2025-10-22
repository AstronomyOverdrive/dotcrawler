namespace dotcrawler
{
    public class Map
    {
        // Map information
        private int[] layout = [];
        private int grid = 0;

        // Setup map layout and gridsize
        public void SetMap(int size, int[] newLayout)
        {
            grid = size;
            layout = newLayout;
        }

        // Get map information
        public int GetGrid()
        {
            return grid;
        }
        public int[] GetLayout()
        {
            return layout;
        }
    }
}
