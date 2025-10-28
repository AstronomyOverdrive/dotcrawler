namespace dotcrawler
{
    public class Map
    {
        // Map information
        private string[] layout = [];
        private int grid = 0;

        // Setup map layout and gridsize
        public void SetMap(int size, string[] newLayout)
        {
            grid = size;
            layout = newLayout;
        }

        // Update a block on map layout
        public void UpdateLayout(int index, string block)
        {
            layout[index] = block;
        }

        // Get map information
        public int GetGrid()
        {
            return grid;
        }
        public string[] GetLayout()
        {
            return layout;
        }
    }
}
