using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CollectionConstructorSample
{
    class Program
    {
        static void Main()
        {
            // もとになるコレクション
            IEnumerable<char> chars = "Hello World!".OrderBy(c => c);

            // そのまま表示するよ
            Console.WriteLine("そのまま表示するよ");
            Console.WriteLine(new string(chars.ToArray()));

            // 配列としてCollectionに入れて扱うよ
            Console.WriteLine("配列としてCollectionに入れて扱うよ");
            try
            {
                char[] array = chars.ToArray();
                Collection<char> collectionFromArray = new Collection<char>(array);
                collectionFromArray.Add('Z'); // 中身が配列のままだからここでエラーが起きるよ
                Console.WriteLine(new string(collectionFromArray.ToArray()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // ListとしてCollectionに入れて扱うよ
            Console.WriteLine("ListとしてCollectionに入れて扱うよ");
            try
            {
                List<char> list = chars.ToList();
                Collection<char> collectionFromList = new Collection<char>(list);
                collectionFromList.Add('Z'); // 中身はList<char>だから普通に追加できるよ
                Console.WriteLine(new string(collectionFromList.ToArray()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
