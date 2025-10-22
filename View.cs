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
            // Get blocks for each depth of viewDist + players current position
            for (int i = 0; i < viewDist + 1; i++)
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
                // Stop early if player is facing a wall(1) or door(2 or 3)
                if (viewList.Count() == 6 && viewList[4] > 0 && viewList[4] < 4)
                {
                    i = viewDist;
                }
                else if (viewList.Count() == 9 && viewList[7] > 0 && viewList[7] < 4)
                {
                    i = viewDist;
                }
            }
            DrawView(viewList);
        }

        // Draw view from items in a list
        private void DrawView(List<int> view)
        {
            for (int i = view.Count() - 1; i > 1; i -= 3) // 3 is the FOV
            {
                // Position furthest from the player
                bool frontTexture = false;
                if (i == view.Count() - 1)
                {
                    frontTexture = true;
                }
                // Only show 2 rows of players current position, otherwise show entire texture
                int drawRows;
                if (i < 3)
                {
                    drawRows = 2;
                }
                else
                {
                    drawRows = textures.CountRows();
                }
                // Draw textures from top to bottom
                for (int j = 0; j < drawRows; j++)
                {
                    Console.Write(textures.GetTexture(view[i - 2], frontTexture)[j]);
                    Console.Write(textures.GetTexture(view[i - 1], frontTexture)[j]);
                    Console.Write(textures.GetTexture(view[i], frontTexture)[j]);
                    Console.Write("\n");
                }
            }
        }
    }
}
