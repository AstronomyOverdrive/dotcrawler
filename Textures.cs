namespace dotcrawler
{
    public class Textures
    {
        private int textureRows = 6;
        // All "textures" used for the first person view
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
        public string[] GetTexture(int id, bool frontTexture)
        {
            string[] texture;
            switch (id)
            {
                case 0:
                    texture = air;
                    break;
                case 1:
                    if (frontTexture)
                    {
                        texture = wallFront;
                    }
                    else
                    {
                        texture = wallSide;
                    }
                    break;
                case 2:
                    if (frontTexture)
                    {
                        texture = doorFront;
                    }
                    else
                    {
                        texture = doorSide;
                    }
                    break;
                case 3:
                    if (frontTexture)
                    {
                        texture = exitFront;
                    }
                    else
                    {
                        texture = exitSide;
                    }
                    break;
                case 4:
                    texture = chestClosed;
                    break;
                case 5:
                    texture = chestOpen;
                    break;
                case 6:
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
