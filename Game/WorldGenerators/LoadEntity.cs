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
        List<Monsters.MonsterCreator> m = new List<Monsters.MonsterCreator>();
        public List<Monsters.MonsterCreator> LoadMonsters()
        {
            m.Clear();
            Load(CompM);
            return m;
        }

        private delegate void CompareThis(Type type);

        private void CompM(Type type)
        {
            if (type.IsSubclassOf(typeof(Monsters.MonsterCreator)))
                        {
 
                            //m.Add((Monsters.MonsterCreator) Activator.CreateInstance(typeof(Monsters.WolfCreator)));
                            m.Add((Monsters.MonsterCreator)Activator.CreateInstance(type));
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
