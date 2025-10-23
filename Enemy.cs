namespace dotcrawler
{
    public class Enemy
    {
        private int pos = 0;
        private int hp = 3;

        // Damage health points
        public void Damage(int amount, Map map)
        {
            hp -= amount;
            // Check if dead, if so then clean up self
            if (hp <= 0)
            {
                map.UpdateLayout(pos, 0);
                // TODO: remove from list
            }
        }

        // Take action
        public void Action(Player player, Map map)
        {
            Random dieRoll = new Random();
            int[] blocksAround = [pos + 1, pos - 1, pos + map.GetGrid(), pos - map.GetGrid()];
            // Decide action based on player position
            if (blocksAround[0] == player.GetPos() || blocksAround[1] == player.GetPos() || blocksAround[2] == player.GetPos() || blocksAround[3] == player.GetPos())
            { // Attack player
                if (dieRoll.Next(10) > 4) // Roll for hit chance
                {
                    player.UpdateHp(player.GetHp() - 1);
                }
            }
            else
            { // Move position
                int oldPos = pos;
                int newPos = blocksAround[dieRoll.Next(4)];
                // Check if chosen position is clear
                if (map.GetLayout()[newPos] == 0)
                {
                    map.UpdateLayout(newPos, 6);
                    map.UpdateLayout(oldPos, 0);
                }
            }
        }
    }
}
