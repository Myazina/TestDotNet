
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetAllChildren
{
    class Program
    {
      private static void Main(string[] args)
      {
        var list = new List<TreeLevel>()
            {
                new TreeLevel  { Id=1, Name ="Pickard", ParentId=null },
                new TreeLevel{ Id=2, Name ="Riker", ParentId=1 },
                new TreeLevel{ Id=3, Name ="Troi", ParentId=1 },
                new TreeLevel{ Id=4, Name ="Forge", ParentId=1 },
                new TreeLevel{ Id=5,Name ="Mog", ParentId=2 },
                new TreeLevel{ Id=6,Name ="Guinan", ParentId=2 },
                new TreeLevel{ Id=7, Name ="Crusher", ParentId=2 },
                new TreeLevel{ Id=8,Name ="LTroi", ParentId=3 },
                new TreeLevel{ Id=9, Name ="Barkley", ParentId=3 },
                new TreeLevel{ Id=10, Name ="Data",ParentId=4 },
                 new TreeLevel{ Id=11,Name ="Brien", ParentId=4 },
                new TreeLevel{ Id=12, Name = "Yar", ParentId=5 },
                new TreeLevel{ Id=13,Name ="Kehleyr", ParentId=5 },
                new TreeLevel{ Id=14, Name ="WCrusher", ParentId=7 },
                new TreeLevel{ Id=15, Name ="Ogawa",ParentId=7 },
                new TreeLevel{ Id=16, Name ="Rozhenko", ParentId=13 },
                new TreeLevel{ Id=17, Name ="Bashir",ParentId=15 }
            };

        var result = TraverseTree(list, 3).ToList();
        for (int i = 0; i < result.Count(); i++)
        {
            Console.WriteLine($"{result[i].ParentId} - {result[i].Name}  {result[i].Id}");            
        }     
        Console.WriteLine($"------------------");           
                    
        // vytvořime slovník pro lookParents
        var lookParents = list.ToDictionary(g => g.Id, g => g);
        var lookFor = new TreeLevel(){Id = 6, Name = "Guinan", ParentId = 2 };
        
        // získat všechny rodiče
         GetParents(lookParents, lookFor);
         Console.ReadKey();
        
    }
        private static IEnumerable<TreeLevel> TraverseTree(List<TreeLevel> list,long id)
        {
            return list
                .Where(child => child.ParentId == id)
                .Union(list.Where(child => child.ParentId == id)
                .SelectMany(parent => TraverseTree(list, parent.Id))
            );
        }
        private static void GetParents(Dictionary<long, TreeLevel> lookParents, TreeLevel lookFor)
        {
           while (lookFor != null)
           {
              Console.WriteLine($"{lookFor.Id} {lookFor.Name} {lookFor.ParentId}");
              if (lookFor.ParentId == null || lookFor.ParentId == 1)
              break;

             // přenést ParentId na odpovídající dataTyp nebo long
              lookParents.TryGetValue((long)lookFor.ParentId, out var parentNode);
              lookFor = parentNode;
            }

        }
    }
class TreeLevel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        
    }
}
