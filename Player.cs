namespace dotcrawler
{
    public class Player
    {
        // Player information
        private int pos = 40;
        private int hp = 5;
        private int gold = 0;
        private int dmg = 1;
        private string[] directions = ["West", "North", "East", "South"];
        private int dirIndex = 0; // Changing an integer is both easier and require less memory than rotating array items

        // Player position
        public void SetPos(int newPos, Map map)
        {
            if (map.GetLayout()[newPos] == 0) // Collision check
            {
                pos = newPos;
            }
        }
        public int GetPos()
        {
            return pos;
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

        // Player gold
        public void SetGold(int newGold)
        {
            gold = newGold;
        }
        public int GetGold()
        {
            return gold;
        }

        // Player damage output
        public void UpdateDamage(int newDmg)
        {
            dmg = newDmg;
        }
        public int GetDamage()
        {
            return dmg;
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
