namespace dotcrawler
{
    public class Player
    {
        // Player information
        private int x = 1;
        private int y = 1;
        private int hp = 5;
        private string[] directions = ["West", "North", "East", "South"];
        private int dirIndex = 0; // Changing an integer is both easier and require less memory than rotating array items

        // Player position
        public void SetPos(int newX, int newY, Map map)
        {
            int tryPos = newX * map.GetGrid() + newY;
            if (map.GetLayout()[tryPos] == 0)
            {
                x = newX;
                y = newY;
            }
        }
        public int[] GetPos()
        {
            return [x, y];
        }

        // Player health points
        public void UpdateHp(int newHp)
        {
            hp = newHp;
        }
        public int GetHp()
        {
            return hp;
        }

        // Player rotation
        public void Turn(bool right)
        {
            if (right)
            {
                dirIndex += 1;
            }
            else
            {
                dirIndex -= 1;
            }
            // Keep index within array range
            if (dirIndex < 0)
            {
                dirIndex = 3;
            }
            if (dirIndex > 3)
            {
                dirIndex = 0;
            }
        }
        public string GetDir()
        {
            return directions[dirIndex];
        }
    }
}
