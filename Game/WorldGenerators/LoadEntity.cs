using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game.WorldGenerators
{
    public class LoadEntity
    {
        List<Monsters.MonsterCreator> mc = new List<Monsters.MonsterCreator>();
        List<Bonuses.BonusCreator> bc = new List<Bonuses.BonusCreator>();
        List<CellCretors.CellCreator> cc = new List<CellCretors.CellCreator>();
        public List<Monsters.MonsterCreator> LoadMonsters()
        {
            mc.Clear();
            Load(CompareMonster);
            return mc;
        }
        public List<Bonuses.BonusCreator> LoadBonuses()
        {
            bc.Clear();
            Load(CompareBonus);
            return bc;
        }
        public List<CellCretors.CellCreator> LoadCells()
        {
            cc.Clear();
            Load(CompareCell);
            return cc;
        }

        private delegate void CompareThis(Type type);

        private void CompareMonster(Type type)
        {
            if (type.IsSubclassOf(typeof(Monsters.MonsterCreator)))
                {
                    mc.Add((Monsters.MonsterCreator)Activator.CreateInstance(type));
                }
        }
        private void CompareBonus(Type type)
        {
            if (type.IsSubclassOf(typeof(Bonuses.BonusCreator)))
            {
                bc.Add((Bonuses.BonusCreator)Activator.CreateInstance(type));
            }
        }
        private void CompareCell(Type type)
        {
            if (type.IsSubclassOf(typeof(CellCretors.CellCreator)))
            {
                cc.Add((CellCretors.CellCreator)Activator.CreateInstance(type));
            }
        }

        private void Load(CompareThis ct) 
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string[] dllFilenames = System.IO.Directory.GetFiles(currentDirectory + "\\Plugins", "*.dll");

            foreach (string filename in dllFilenames)
            {
                try
                {
                    Assembly asm = Assembly.LoadFrom(filename);

                    Type[] typesInAssembly = asm.GetTypes();
                    foreach (Type type in typesInAssembly)
                    {
                        ct(type);
                    }
                }
                catch (BadImageFormatException e)
                {
                    // Неправильная сборка, отбросить
                }
            }

        }


    }
}
