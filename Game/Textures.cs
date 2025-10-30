// TODO: replace with a better system (if time permits it)
namespace dotcrawler
{
    public class Textures
    {
        private int textureRows = 6;
        // Each array represents one square on the map grid
        private string[] air = [
            @"            ",
            @"            ",
            @"            ",
            @"            ",
            @"            ",
            @"            "
        ];
        private string[] wallFront = [
            @"------------",
            @"|_|___|____|",
            @"|___|___|__|",
            @"|_|___|____|",
            @"|___|___|__|",
            @"------------"
        ];
        private string[] wallSide = [
            @"------------",
            @"|---|   |--|",
            @"|   |---|  |",
            @"|---|   |--|",
            @"|   |---|  |",
            @"------------"
        ];
        private string[] doorFront = [
            @"------------",
            @"|          |",
            @"|==========|",
            @"|        O |",
            @"|==========|",
            @"-          -"
        ];
        private string[] doorSide = [
            @"------------",
            @"|  ||  ||  |",
            @"|  ||()||  |",
            @"|  ||  ||  |",
            @"|  ||  ||  |",
            @"------------"
        ];
        private string[] exitFront = [
            @"------------",
            @"|          |",
            @"|=E=X=I=T==|",
            @"|        O |",
            @"|=E=X=I=T==|",
            @"-          -"
        ];
        private string[] exitSide = [
            @"------------",
            @"|   E  E   |",
            @"|   X()X   |",
            @"|   I  I   |",
            @"|   T  T   |",
            @"------------"
        ];
        private string[] enemy = [
            @"            ",
            @"     ()     ",
            @"    /[]\    ",
            @"     ][     ",
            @"    /  \    ",
            @"            "
        ];
        private string[] chestClosed = [
            @"            ",
            @"            ",
            @"    ____    ",
            @"   /____\   ",
            @"   |====|   ",
            @"            "
        ];
        private string[] chestOpen = [
            @"            ",
            @"    ____    ",
            @"   /    \   ",
            @"   \____/   ",
            @"   |====|   ",
            @"            "
        ];

        // Get how many rows the textures use
        public int CountRows()
        {
            return textureRows;
        }
        // Get texture from integer
        public string[] GetTexture(string name, bool frontTexture)
        {
            string[] texture;
            switch (name)
            {
                case "air":
                    texture = air;
                    break;
                case "wall":
                    if (frontTexture)
                    {
                        texture = wallFront;
                    }
                    else
                    {
                        texture = wallSide;
                    }
                    break;
                case "door":
                    if (frontTexture)
                    {
                        texture = doorFront;
                    }
                    else
                    {
                        texture = doorSide;
                    }
                    break;
                case "exit":
                    if (frontTexture)
                    {
                        texture = exitFront;
                    }
                    else
                    {
                        texture = exitSide;
                    }
                    break;
                case "chestClosed":
                    texture = chestClosed;
                    break;
                case "chestOpen":
                    texture = chestOpen;
                    break;
                case "enemy":
                    texture = enemy;
                    break;
                default:
                    texture = air;
                    break;
            }
            return texture;
        }
    }
}
