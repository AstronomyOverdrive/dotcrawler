namespace dotcrawler
{
    public class Map
    {
        private int[]? layout;
        private int? grid;

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
    }
}
