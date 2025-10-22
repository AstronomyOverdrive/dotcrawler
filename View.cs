namespace dotcrawler
{
    public class View
    {
        // Load textures
        private Textures textures = new Textures();
        // Depth to draw
        private int viewDist = 3;

        // Prepare list with what the player can see
        public void GetView(int pos, string direction, Map map)
        {
            // Needed for calculations
            int[] layout = map.GetLayout();
            int grid = map.GetGrid();

            List<int> viewList = [];
            for (int i = 1; i <= viewDist; i++) // For each level of depth get blocks within a 3 block FOV
            {
                if (direction == "West")
                {
                    viewList.Add(layout[(pos + (grid * 1)) - i]);
                    viewList.Add(layout[pos - i]);
                    viewList.Add(layout[(pos - (grid * 1)) - i]);
                }
                else if (direction == "North")
                {
                    viewList.Add(layout[(pos - (grid * i)) - 1]);
                    viewList.Add(layout[pos - (grid * i)]);
                    viewList.Add(layout[(pos - (grid * i)) + 1]);
                }
                else if (direction == "East")
                {
                    viewList.Add(layout[(pos - (grid * 1)) + i]);
                    viewList.Add(layout[pos + i]);
                    viewList.Add(layout[(pos + (grid * 1)) + i]);
                }
                else if (direction == "South")
                {
                    viewList.Add(layout[(pos + (grid * i)) + 1]);
                    viewList.Add(layout[pos + (grid * i)]);
                    viewList.Add(layout[(pos + (grid * i)) - 1]);
                }
                // Stop early if player is facing a door or wall
                if (viewList.Count() == 3 && viewList[1] > 0 && viewList[1] < 7)
                {
                    i = viewDist;
                }
                else if (viewList.Count() == 6 && viewList[4] > 0 && viewList[4] < 7)
                {
                    i = viewDist;
                }
            }
            // Draw to screen
        }
    }
}
