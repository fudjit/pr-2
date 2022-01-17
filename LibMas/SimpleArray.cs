using Microsoft.Win32;
using System;
using System.Data;
using System.IO;

namespace LibMas
{
    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add($"{(i + 1)}", typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
    }

    public class SimpleArray
    {
        private int[] _array;
        Random _random = new Random();
        public void Initialize(int min = 0, int max = 0)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = _random.Next(min, max);
            }
        }

        public int[] GenerateRandom(int maslength)
        {
            _array = new int[maslength];
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = _random.Next(-100, 101);
            }
            return _array;
        }

        public void Save()
        {
            SaveFileDialog writer = new SaveFileDialog();
            writer.DefaultExt = ".txt";
            writer.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (writer.ShowDialog() == true)
            {
                StreamWriter write = new StreamWriter(writer.FileName);
                write.WriteLine(_array.Length);
                for (int i = 0; i < _array.Length; i++)
                {
                    write.WriteLine(_array[i]);
                }
                write.Close();
            }
        }

        public int[] Open()
        {
            OpenFileDialog reader = new OpenFileDialog();
            reader.DefaultExt = ".txt";
            if (reader.ShowDialog() == true)
            {
                StreamReader read = new StreamReader(reader.FileName);
                _array = new int[Convert.ToInt32(read.ReadLine())];
                for (int i = 0; i < _array.Length; i++)
                {
                    _array[i] = int.Parse(read.ReadLine());
                }
            }
            return _array;
        }
    }
}
