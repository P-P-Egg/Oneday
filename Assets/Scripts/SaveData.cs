using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData{
    public static LinkedList<int> Distance = new LinkedList<int>();
    public static int[] data;
    public static int CurrentScore;
    static LinkedListNode<int> parser;

    public static void load()
    {
        BinarySerializationTool.Load(ref data, "AV.mp4");
        Distance = new LinkedList<int>();
        if (data!=null)
        {
            foreach (int item in data)
            {
                Distance.AddLast(item);
            }
        }
    }
    static void save()
    {
        data = new int[Distance.Count];
        int i = 0;
        while (Distance.Count>0)
        {
            data[i] = Distance.First.Value;
            Distance.RemoveFirst();
            i++;
        }
            
        BinarySerializationTool.Save(data, "AV.mp4");
    }
    public static void New()
    {
        
        if (CurrentScore!=0)
        {
            if (Distance.Count>1)
            {
                if (CurrentScore>Distance.First.Value)
                {
                    Distance.AddFirst(CurrentScore);
                }
                else
                {
                    parser = Distance.First;
                    while (parser.Next != null && CurrentScore < parser.Next.Value)
                    {
                        parser = parser.Next;
                    }
                    Distance.AddAfter(parser, CurrentScore);
                }
            }
            else
            {
                Distance.AddFirst(CurrentScore);
            }
        }
        save();
        CurrentScore = 0;
        load();
    }


}
