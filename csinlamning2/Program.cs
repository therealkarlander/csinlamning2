using System;



//TODO
//          *Rita upp hjälten, hen är ett 'A' som ritas upp på ett ställe via SetCursorPos() och Write()
//          *Hjälten kan gå runt med piltangenter via Clear() och ReadKey(true) som returnerar KeyInfo structen
// Antal hjärtan visas uppe i vänstra hörnet (3 st) OBS måste ritas om efter varje Clear()
// Det finns ett hjärta nära hjälten som hen kan plocka upp. Då försvinner hjärtat
// Hjälten har ett int fält, alla hjärtan som hen plockat upp som ökar när hjärtat plockas upp
//          *Det finns mer än ett hjärta att plocka upp
//          * Det finns en massa hjärtan som dyker upp slumpmässigt via Random klassen

namespace Inlamningsuppgift2

{
    public class Program
    {

        public static void Main(string[] args)
        {

            Console.SetBufferSize(125, 150);

            Random random_fabrik = new Random();
            int slumpat_tal = random_fabrik.Next();
            int noll_till_nio = slumpat_tal % 10;
            bool stjärna_eller_prick = noll_till_nio > 3;

            int position_x = slumpat_tal % 21;
            {
                Console.SetCursorPosition(position_x, 3);
                if (stjärna_eller_prick)
                    Console.Write("* * * *");
                else
                    Console.Write("* * *");
            }

            int position_y = slumpat_tal % 21;
            {
                Console.SetCursorPosition(position_y, 3);
                if (stjärna_eller_prick)
                    Console.Write("* * *");
                else
                    Console.Write("* *");
            }



            //Hjärtspridare alternativ 2 (sprider hjärtan random på skärmen)
            /*
            string[] hjärtspridare = { ("*") };
            Random hjärtisar = new Random();
            int överrasknings_stjärnor = hjärtisar.Next();
            Console.SetCursorPosition(position_x, position_y);
            Console.Write("*");
            */

            //Hjärträknare (ska vara längst upp till vänster)
            /* 
            int hjärta_x = 0;
            int hjärta_y = 0;
            string[] hjärträknare = { "*" };
            Console.SetCursorPosition(hjärta_x, hjärta_y);
            Console.WriteLine("*");
            for (int i = 0; i < hjärträknare.Length; i++)
            {
                Console.WriteLine(hjärträknare[i]);
            }
            */

            // Hjältens startposition
            int hjälte_x = 10;
            int hjälte_y = 10;

            Console.SetCursorPosition(hjälte_x, hjälte_y);
            Console.Write('A');

            /*
            while (true)
            */

            int Starcount = 0;

            if (hjälte_x == position_x && hjälte_y == position_y)
            {
                Starcount++;
            }

            while (true)
            {




                // Läser in hjältens nya position
                var key = Console.ReadKey(true);
                int position_hjälte_x = Console.CursorLeft;
                int position_hjälte_y = Console.CursorTop;


                // HANN INTE KLART MED DET HÄR!! 
                
                int Hjälte_x = (position_hjälte_x);
                int Hjälte_y = (position_hjälte_y);

                Console.SetCursorPosition(position_hjälte_x, position_hjälte_y);


                if (key.Key == ConsoleKey.LeftArrow)
                {
                    Console.Clear();
                    Console.WriteLine("Antal Hjärtan");
                    Console.WriteLine(Starcount);
                    Console.WriteLine(stjärna_eller_prick);
                    Console.SetCursorPosition(position_hjälte_x - 2, position_hjälte_y);
                    Console.Write('A');

                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.Clear();
                    Console.WriteLine("Antal Hjärtan");
                    Console.WriteLine(Starcount);
                    Console.WriteLine(stjärna_eller_prick);
                    Console.SetCursorPosition(position_hjälte_x + 1, position_hjälte_y);
                    Console.Write('A');

                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.Clear();
                    Console.WriteLine("Antal Hjärtan");
                    Console.WriteLine(Starcount);
                    Console.WriteLine(stjärna_eller_prick);
                    Console.SetCursorPosition(position_hjälte_x - 1, position_hjälte_y - 1);
                    Console.Write('A');


                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.Clear();
                    Console.WriteLine("Antal Hjärtan");
                    Console.WriteLine(Starcount);
                    Console.WriteLine(stjärna_eller_prick);
                    Console.SetCursorPosition(position_hjälte_x - 1, position_hjälte_y + 1);
                    Console.Write('A');

                }




                try
                {


                }


                catch (ArgumentOutOfRangeException ex)
                {

                    Console.Write("Håll dig på banan!", ex.Message);
                }




                for (int i = 0; i < 20; i++)
                {



                }



            }



        }


















        /*
    public Position Position { get; protected set; }

    public GameUnit(Position position)
    {
        Position = position;
    }
    public void Draw(Surface surface)
    {
        surface.DrawAt(GetImage(), Position);
    }
    protected virtual char GetImage() { return ' '; }
}

struct Position
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Position(int x = 50, int y = 50)
    {
        X = x;
        Y = y;
    }
}

class Surface
{
    private int left;
    private int top;

    public void BeginDraw()
    {
        Console.Clear();
        left = Console.CursorLeft;
        top = Console.CursorTop;
    }

    public void DrawAt(char c, Position position)
    {
        try
        {
            Console.SetCursorPosition(left + position.X,
                                      top + position.Y);
            Console.Write(c);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }
}

class Terrain : GameUnit
{
    public Terrain(Position position) : base(position) { }
}

class Water : Terrain
{
    public Water(Position position) : base(position) { }
    protected override char GetImage() { return ' '; }
}

class Hill : Terrain
{
    public Hill(Position position) : base(position) { }
    protected override char GetImage() { return ' '; }
    /*
    var objects = new List <v1.GameUnit>()
    {
        new v1.Water(new Position(3, 2)),
        new v1.Water(new Position(4, 2)),
        new v1.Water(new Position(5, 2)),
        new v1.Water(new Position(3, 1)),
        new v1.Water(new Position(4, 3)),
    };

    var surface = new v1.Surface();
    Surface.BeginDraw()

        foreach (var unit in objects)
        unit.Draw(surface) ;
    */



    }

}


