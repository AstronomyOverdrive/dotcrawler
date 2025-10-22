namespace dotcrawler
{
    // All "textures" used for the first person view
    // Each array represents one square on the map grid
    public class Textures
    {
        public string[] wallFront = [
            @"------------",
            @"|_|___|____|",
            @"|___|___|__|",
            @"|_|___|____|",
            @"|___|___|__|",
            @"------------"
        ];
        public string[] wallSide = [
            @"------------",
            @"|---|   |--|",
            @"|   |---|  |",
            @"|---|   |--|",
            @"|   |---|  |",
            @"------------"
        ];
        public string[] doorFront = [
            @"------------",
            @"|          |",
            @"|==========|",
            @"|        O |",
            @"|==========|",
            @"-          -"
        ];
        public string[] doorSide = [
            @"------------",
            @"|  ||  ||  |",
            @"|  ||()||  |",
            @"|  ||  ||  |",
            @"|  ||  ||  |",
            @"------------"
        ];
        public string[] exitFront = [
            @"------------",
            @"|          |",
            @"|=E=X=I=T==|",
            @"|        O |",
            @"|=E=X=I=T==|",
            @"-          -"
        ];
        public string[] exitSide = [
            @"------------",
            @"|   E  E   |",
            @"|   X()X   |",
            @"|   I  I   |",
            @"|   T  T   |",
            @"------------"
        ];
        public string[] enemy = [
            @"            ",
            @"     ()     ",
            @"    /[]\    ",
            @"     ][     ",
            @"    /  \    ",
            @"            "
        ];
        public string[] chestClosed = [
            @"            ",
            @"            ",
            @"    ____    ",
            @"   /____\   ",
            @"   |====|   ",
            @"            "
        ];
        public string[] chestOpen = [
            @"            ",
            @"    ____    ",
            @"   /    \   ",
            @"   \____/   ",
            @"   |====|   ",
            @"            "
        ];
    }
}
