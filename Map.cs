namespace dotcrawler
{
    public class Map
    {
        private int[] layout = [];
        private int grid = 0;

        // Setup map layout and gridsize
        public void SetMap(int size, int[] newLayout)
        {
            grid = size;
            layout = newLayout;
            // For debugging
            for (int i = 0; i < grid * grid; i++)
            {
                Console.Write($"{layout[i]} ");
                if ((i + 1) % grid == 0)
                {
                    Console.Write("\n");
                }
            }
        }

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
