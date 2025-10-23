namespace dotcrawler
{
    public class Enemies
    {
        private List<Enemy> enemyList = [];

        // Attach AI to all enemies on map layout
        public void AttachAI(Map map)
        {
            for (int i = 0; i < map.GetGrid() * map.GetGrid(); i++)
            {
                if (map.GetLayout()[i] == 6) // Check if current block represents an enemy
                {
                    Enemy newEnemy = new Enemy();
                    newEnemy.StartPos(i); // Set starting position
                    enemyList.Add(newEnemy);
                }
            }
        }

        // Have every enemy take an action
        public void RunLogic(Map map, Player player)
        {
            foreach (Enemy enemy in enemyList)
            {
                enemy.Action(player, map);
            }
        }

        // Player attack enemy
        public void AttackEnemy(int pos, Player player, Map map)
        {
            List<Enemy> toRemove = [];
            foreach (Enemy enemy in enemyList)
            {
                if (enemy.GetPos() == pos) // Found enemy
                {
                    if (enemy.Damage(player.GetDamage(), map) <= 0) // Check if enemy is dead
                    {
                        toRemove.Add(enemy);
                    }
                }
            }
            foreach (Enemy enemy in toRemove)
            {
                enemyList.Remove(enemy);
                // Reward player
                player.UpdateHp(player.GetHp() + 2);
            }
        }
    }
}
