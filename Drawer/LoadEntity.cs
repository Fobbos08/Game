using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class LoadEntity
    {
        List<BonusDrawer.BonusDrawer> bd = new List<BonusDrawer.BonusDrawer>();
        List<MonsterDrawer.MonsterDrawer> md = new List<MonsterDrawer.MonsterDrawer>();
        List<CellDrawer.CellDrawer> cd = new List<CellDrawer.CellDrawer>();

        public List<MonsterDrawer.MonsterDrawer> LoadMonsters()
        {
            md.Clear();
            Load(CompareMonster);
            return md;
        }
        public List<BonusDrawer.BonusDrawer> LoadBonuses()
        {
            bd.Clear();
            Load(CompareBonus);
            return bd;
        }
        public List<CellDrawer.CellDrawer> LoadCells()
        {
            cd.Clear();
            Load(CompareCell);
            return cd;
        }

        private delegate void CompareThis(Type type);

        private void CompareMonster(Type type)
        {
            if (type.IsSubclassOf(typeof(MonsterDrawer.MonsterDrawer)))
                {
                    md.Add((MonsterDrawer.MonsterDrawer)Activator.CreateInstance(type));
                }
        }
        private void CompareBonus(Type type)
        {
            if (type.IsSubclassOf(typeof(BonusDrawer.BonusDrawer)))
            {
                bd.Add((BonusDrawer.BonusDrawer)Activator.CreateInstance(type));
            }
        }
        private void CompareCell(Type type)
        {
            if (type.IsSubclassOf(typeof(CellDrawer.CellDrawer)))
            {
                cd.Add((CellDrawer.CellDrawer)Activator.CreateInstance(type));
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
