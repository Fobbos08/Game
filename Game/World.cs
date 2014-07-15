using Game.Bonuses;
using Game.Monsters;
using Game.WorldGenerators;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game
{
    public class World
    {
        public Random RND {get; private set;}
        private WorldGenerators.WorldGenerator generator;
        public Timer WorldTimer {get; private set;}
        public Cell[,] map {get; set;}
        public int PixelsWidth { get; private set; }
        public int PixelsHeight { get; private set; }
        public int CellWidth { get; private set; }
        public int CellHeight {get; private set;}
        public int SideSizeW {get; private set;}
        public int SideSizeH {get; private set;}
        public Player OnePlayer {get; private set;}
        public List<Monster> monsters;
        public bool Generated = false;
        public int Score {get; private set;}

        public delegate void UpdateScoreHandler(World s);
        public event UpdateScoreHandler UpdateScoreEvent;

        private void FuncUpdateScoreEvent()
        {
            UpdateScoreHandler handler = UpdateScoreEvent;
            if (UpdateScoreEvent != null) handler(this);
        }


        //private List<Bonus> bonuses;

        public World(int width, int height, int cWidth, int cHeight)
        {
            RND = new Random();
            CellWidth = cWidth;
            CellHeight = cHeight;

            var conteiner = new UnityContainer();
            conteiner.RegisterType<IGenerator<Cell[,]>, MapGenerator>(new InjectionConstructor(
               CellWidth, CellHeight));
            conteiner.RegisterType<IGenerator<Bonus>, BonusGenerator>();
            conteiner.RegisterType<IGenerator<List<Monster>>, MonsterGenerator>();
            conteiner.RegisterType<IGenerator<World>, WorldGenerator>(new InjectionConstructor(
                new ResolvedParameter<IGenerator<Cell[,]>>(),
                new ResolvedParameter<IGenerator<Bonus>>(), new ResolvedParameter<IGenerator<List<Monster>>>()));
            //generator = conteiner.Resolve<RecordGenerator>();
            generator = conteiner.Resolve<WorldGenerator>();


            


           
            PixelsHeight = height;
            PixelsWidth = width;
            WorldTimer = new Timer();
            WorldTimer.Interval = 30;
            OnePlayer = new Player(this) { MovedLevel = 2, MyPosition = new Position() { X = 20, Y = 20 }, MyVector = new Vector() { X = 1 }, Speed = 2 };
            OnePlayer.EatBonusEvent += EatBonus;

            monsters = new List<Monster>();
            
            SideSizeW = PixelsWidth / CellWidth;
            SideSizeH = PixelsHeight / CellHeight;

            WorldTimer.Start();

            //monsters.Add(new Wolf(this) { MovedLevel = 1, MyPosition = new Position() { X = 100, Y = 100 }, MyVector = new Vector() { X = 1 }, Speed = 1 });
        }

        public void DeleteThisBonus(Bonus bonus)
        {
            map[bonus.MyPosition.X, bonus.MyPosition.Y].bonus = null;
            bool g = false;
            foreach (var a in map)
                if (a.bonus!=null) g = true;
            //count--;
            if (g == false) {
                Generate(); }
        }

        public Cell GetCell(Position pos)
        {
            int x = pos.X / SideSizeW;
            int y = pos.Y / SideSizeH;
            if (x < 0 || x >= CellWidth) return null;
            if (y < 0 || y >= CellHeight) return null;
            return map[x, y];
        }

        private void EatPlayer(Monster m, Player p)
        {
            Score = 0;
            FuncUpdateScoreEvent();
            Generate();
        }

        private void EatBonus(Bonus b, Player p)
        {
            Score++;
            FuncUpdateScoreEvent();
        }

        public void Generate()
        {
            Generated = true;
            WorldTimer.Stop();
            OnePlayer.Speed = 1;
            OnePlayer.MyVector.X = 0;
            OnePlayer.MyVector.Y = 0;
            OnePlayer.MyPosition.X = 20;
            OnePlayer.MyPosition.Y = 20;
            generator.Generate(this);
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].EatPlayerEvent += EatPlayer;
                //WorldTimer.Elapsed += monsters[i].TimerTick;
            }


            WorldTimer.Start();
            Generated = false;
        }

        public Bonus GetBonus(Unit unit)
        {
            return map[unit.MyPosition.X / SideSizeW, unit.MyPosition.Y / SideSizeH].bonus;
        }

        public Cell[,] GetMap()
        {
            return map;
        }

        public List<Monster> GetMonsters()
        {
            return monsters;
        }

        public Player GetPlayer()
        {
            return OnePlayer;
        }
    }
}
