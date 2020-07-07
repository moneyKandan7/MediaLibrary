using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MLBStorage
{
    public class Class1
    {
        public static string filepath = "C:\\Users\\ELCOT\\Documents\\OutputTSV.tsv";
        public static string InfoWriter(MediaClass media)
        {
            string msg = "";
            if (media == null) return "Enter Invalid Details...";
            StringBuilder sb = new StringBuilder();
            if (!File.Exists(filepath))
            {
                filepath = "C:\\Users\\ELCOT\\Documents\\OutputTSV.tsv";
                sb.Append("Tile\tFilePath\tThumbPath\tFormat\tGenre\tLanguages\tSubitle\n");
                File.AppendAllText(filepath, sb.ToString());
                sb.Clear();
            }
            string con = File.ReadAllText(filepath);
            string[] oldLine;
            oldLine = con.Split('\n');
            List<MediaClass> check = InfoReader();
            if (check.Where(f => f.Title == media.Title && f.Format == media.Format).Count() > 0) return "Record already present";
            try
            {
                string content = (media.Title ?? "") + "\t" + (media.FilePath ?? "") + "\t" + (media.ThumbPath ?? "") + "\t" + (media.Format ?? "") + "\t" + (media.Genre ?? "") + "\t" + (media.Languages ?? "") + "\t" + (media.Subtitle) + "\n";
                sb.Append(content);
                File.AppendAllText(filepath, sb.ToString());
                con = File.ReadAllText(filepath);
                string[] newLine = con.Split('\n');
                if (newLine.Count() > oldLine.Count()) msg = "New Record Added SuccessFully...";
                else msg = "Record Couldn't Added...";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return msg;
        }
        public static List<MediaClass> InfoReader()
        {
            List<MediaClass> media = new List<MediaClass>();
            string content;
            if (!(File.Exists(filepath)))
                return null;
            content = File.ReadAllText(filepath);
            string[] contentLines = content.Split('\n');
            for (int i = 1; i < contentLines.Count() - 1; i++)
            {
                string[] data = contentLines[i].Split('\t');
                MediaClass m = new MediaClass()
                {
                    Title = data[0],
                    FilePath = data[1],
                    ThumbPath = data[2],
                    Format = data[3],
                    Genre = data[4],
                    Languages = data[5],
                    Subtitle = data[6] == "true" ? true : false
                };
                media.Add(m);
            }
            return media;
        }
    }

}