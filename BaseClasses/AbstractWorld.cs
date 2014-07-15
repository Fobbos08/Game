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

namespace Entity
{
    public abstract class AbstractWorld
    {
        public Random rnd = new Random();
        //private WorldGenerators.WorldGenerator generator;
        public Timer timer;
        public Cell[,] map {get; set;}
        public int PixelsWidth { get; private set; }
        public int PixelsHeight { get; private set; }
        public int CellWidth { get; private set; }
        public int CellHeight {get; private set;}
        public int sideSizeW;
        public int sideSizeH;
        public Player player;
        public List<Monster> monsters;
        public bool flag = false;
        public int score = 0;

        public delegate void UpdateScoreHandler(World s);
        public event UpdateScoreHandler UpdateScoreEvent;

        protected abstract void FuncUpdateScoreEvent;


        //private List<Bonus> bonuses;

        public World(int width, int height, int cWidth, int cHeight)
        {
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


            


            timer = new Timer();
            timer.Interval = 30;
            timer.Start();
            PixelsHeight = height;
            PixelsWidth = width;
            monsters = new List<Monster>();
            player = new Player(this) { MovedLevel = 2, MyPosition = new Position() { X = 20, Y = 20 }, MyVector = new Vector() { X = 1 }, Speed = 2 };
            player.EatBonusEvent += EatBonus;
            sideSizeW = PixelsWidth / CellWidth;
            sideSizeH = PixelsHeight / CellHeight;
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
            int x = pos.X / sideSizeW;
            int y = pos.Y / sideSizeH;
            if (x < 0 || x >= CellWidth) return null;
            if (y < 0 || y >= CellHeight) return null;
            return map[x, y];
        }

        private void EatPlayer(Monster m, Player p)
        {
            score = 0;
            Generate();
        }

        private void EatBonus(Bonus b, Player p)
        {
            score++;
            FuncUpdateScoreEvent();
        }

        public void Generate()
        {
            flag = true;
            timer.Stop();
            player.Speed = 1;
            player.MyVector.X = 0;
            player.MyVector.Y = 0;
            player.MyPosition.X = 20;
            player.MyPosition.Y = 20;
            generator.Generate(this);
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].EatPlayerEvent += EatPlayer;
            }
            timer.Start();
            flag = false;
        }

        public Bonus GetBonus(Unit unit)
        {
            return map[unit.MyPosition.X / sideSizeW, unit.MyPosition.Y / sideSizeH].bonus;
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
            return player;
        }
    }
}
