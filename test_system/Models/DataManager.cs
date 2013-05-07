using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace test_system.Models
{
    public class DataManager
    {
        private DatabaseEntities db;

        public DataManager()
        {
            db = new DatabaseEntities();
        }

        public IQueryable<Stat> GetStatistic()
        {
            return db.Stat;
        }
        public void AddStatistic(string Date, string Time, string Computer, string IP_address, int Balls, int Tasks, int Answers, string Glava)       
        {
            Stat stats = new Stat();
            stats.ID = Guid.NewGuid();
            stats.Data = Date;
            stats.Time = Time;
            stats.Computer = Computer;
            stats.IP_address = IP_address;
            stats.Balls = Balls;
            stats.Tasks = Tasks;
            stats.Answerd = Answers;
            stats.Glava = Glava;
            //throw new NotImplementedException();
            db.Stat.AddObject(stats);
            db.SaveChanges();
        }

        public IQueryable<Glava> GetGlavs()
        {
            return db.Glava;
        }

        public Stat GetStatItem(Guid ID)
        {
            return db.Stat.SingleOrDefault(it => it.ID == ID);
        }

        public Glava GetOneGlav(Guid id)
        {
            return db.Glava.SingleOrDefault(it => it.ID_glav == id);
        }

        public IEnumerable<Vopr> GetVoprForGlav(Guid id)
        {
            var VoprGlav = from EL in db.Vopr where EL.ID_glav == id select EL; 
            return VoprGlav.ToList();
        }

        public IEnumerable<Otv> GetOtvet(Guid id)
        {
            var Otvet = from EL in db.Otv where EL.ID_vopr == id select EL;
            return Otvet;
        }

        public Vopr GetOneVopr(Guid id)
        {
            return db.Vopr.SingleOrDefault(it => it.ID_vopr == id);
        }

        public int CountVorForGlav(Guid id)
        {
            IEnumerable<Vopr> list = GetVoprForGlav(id);
            return list.Count();
        }

        public int GetCountStat()
        {
            return db.Stat.Count();
        }

        public int GetCountGlavs()
        {
            return db.Glava.Count();
        }

        public void DeleteStatistic()
        {
            foreach (var item in db.Stat)
            {
                db.Stat.DeleteObject(item);
            }
            db.SaveChanges();
        }

        public int Parser(Guid id, string str)
        {
            Guid ID = Guid.NewGuid();
            int i = 0;
            int COUNT = str.Length;
            int flag = 1;
            string str1 = "", str2 = "";
            bool flag1 = true;
            List<Otv> otv = new List<Otv>();
            while (true)
            {
                if(i == COUNT) break;                
                if (str[i] == '{')
                {
                    flag = 2;
                    ++i;
                    continue;
                }
                if (str[i] == '[')
                {
                    if (str[i + 1] == '+')
                        flag1 = true;
                    else flag1 = false;
                    flag = 3;
                    ++i;
                    continue;
                }
                if (str[i] == ']')
                {
                    flag = 2;
                    ++i;
                    continue;
                }
                if (str[i] == '}')
                {
                    Otv OTV = new Otv();
                    OTV.ID_otv = Guid.NewGuid();
                    OTV.ID_vopr = ID;
                    OTV.Otv1 = str2;
                    if (flag1 == true) OTV.Bool = 1;
                    else OTV.Bool = 0;
                    otv.Add(OTV);
                    flag = 3;
                    str2 = "";
                    ++i;
                    continue;
                }
                if (str[i] == '/')
                {
                    if(flag == 1)
                        str1 += str[i+1].ToString();
                    if(flag == 2)
                        str2 += str[i+1].ToString();
                    i += 2;
                    continue;
                }
                if (flag == 1) str1 += str[i].ToString();
                if (flag == 2) str2 += str[i].ToString();
                ++i;
            }
            Vopr vopr = new Vopr();
            vopr.ID_glav = id;
            vopr.ID_vopr = ID;
            vopr.Vopr1 = str1;

            if (vopr != null && otv.Count > 1)
            {
                db.Vopr.AddObject(vopr);
                foreach (var item in otv)
                {
                    db.Otv.AddObject(item);
                }
                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public void DeleteVopr(Guid id)
        {
            var OtvVopr = from EL in db.Otv where EL.ID_vopr == id select EL;
            foreach (var list in OtvVopr)
            {
                db.Otv.DeleteObject(list);
            }
            db.SaveChanges();
            Vopr vopr = db.Vopr.SingleOrDefault(it => it.ID_vopr == id);
            db.Vopr.DeleteObject(vopr);
            db.SaveChanges();
        }

        public void DeleteGlava(Guid id)
        {
            IEnumerable<Vopr> list = GetVoprForGlav(id);
            foreach (var LIST in list)
            {
                DeleteVopr(LIST.ID_vopr);
            }
            db.SaveChanges();
            Glava glava = GetOneGlav(id);
            File.Delete(glava.name_file);
            db.Glava.DeleteObject(glava);
            db.SaveChanges();
        }

        public void AddGlav(string Path, string Name)
        {
            Glava item = new Glava();
            item.name_file = Path;
            item.name_glav = Name;
            item.ID_glav = Guid.NewGuid();
            db.AddToGlava(item);
            db.SaveChanges();
        }

        private string translitSymbol(char text)
        {
            string newstring;
            switch (text)
            {
                case 'а':
                    newstring = "a";
                    break;
                case 'А':
                    newstring = "A";
                    break;
                case ' ':
                    newstring = "_";
                    break;
                case 'б':
                    newstring = "b";
                    break;
                case 'Б':
                    newstring = "B";
                    break;
                case 'В':
                    newstring = "W";
                    break;
                case 'в':
                    newstring = "w";
                    break;
                case 'Г':
                    newstring = "G";
                    break;
                case 'г':
                    newstring = "g";
                    break;
                case 'Д':
                    newstring = "D";
                    break;
                case 'д':
                    newstring = "d";
                    break;
                case 'е':
                    newstring = "e";
                    break;
                case 'Е':
                    newstring = "E";
                    break;
                case 'ё':
                    newstring = "e";
                    break;
                case 'Ё':
                    newstring = "E";
                    break;
                case 'ж':
                    newstring = "jh";
                    break;
                case 'Ж':
                    newstring = "Jh";
                    break;
                case 'з':
                    newstring = "th";
                    break;
                case 'З':
                    newstring = "Th";
                    break;
                case 'и':
                    newstring = "i";
                    break;
                case 'И':
                    newstring = "I";
                    break;
                case 'й':
                    newstring = "i";
                    break;
                case 'Й':
                    newstring = "I";
                    break;
                case 'к':
                    newstring = "k";
                    break;
                case 'К':
                    newstring = "K";
                    break;
                case 'л':
                    newstring = "l";
                    break;
                case 'Л':
                    newstring = "L";
                    break;
                case 'М':
                    newstring = "M";
                    break;
                case 'м':
                    newstring = "m";
                    break;
                case 'Н':
                    newstring = "N";
                    break;
                case 'н':
                    newstring = "n";
                    break;
                case 'о':
                    newstring = "o";
                    break;
                case 'О':
                    newstring = "O";
                    break;
                case 'п':
                    newstring = "p";
                    break;
                case 'П':
                    newstring = "P";
                    break;
                case 'р':
                    newstring = "r";
                    break;
                case 'Р':
                    newstring = "R";
                    break;
                case 'с':
                    newstring = "s";
                    break;
                case 'С':
                    newstring = "S";
                    break;
                case 'т':
                    newstring = "t";
                    break;
                case 'Т':
                    newstring = "T";
                    break;
                case 'у':
                    newstring = "u";
                    break;
                case 'У':
                    newstring = "U";
                    break;
                case 'ф':
                    newstring = "f";
                    break;
                case 'Ф':
                    newstring = "F";
                    break;
                case 'х':
                    newstring = "h";
                    break;
                case 'Х':
                    newstring = "H";
                    break;
                case 'ц':
                    newstring = "c";
                    break;
                case 'Ц':
                    newstring = "C";
                    break;
                case 'ч':
                    newstring = "ch";
                    break;
                case 'Ч':
                    newstring = "Ch";
                    break;
                case 'ш':
                    newstring = "sh";
                    break;
                case 'Ш':
                    newstring = "Sh";
                    break;
                case 'щ':
                    newstring = "sh";
                    break;
                case 'Щ':
                    newstring = "Sh";
                    break;
                case 'ъ':
                    newstring = "";
                    break;
                case 'Ъ':
                    newstring = "";
                    break;
                case 'ы':
                    newstring = "i";
                    break;
                case 'Ы':
                    newstring = "I";
                    break;
                case 'ь':
                    newstring = "";
                    break;
                case 'Ь':
                    newstring = "";
                    break;
                case 'э':
                    newstring = "e";
                    break;
                case 'Э':
                    newstring = "E";
                    break;
                case 'ю':
                    newstring = "u";
                    break;
                case 'Ю':
                    newstring = "U";
                    break;
                case 'я':
                    newstring = "ya";
                    break;
                case 'Я':
                    newstring = "Ya";
                    break;
                default:
                    newstring = text.ToString();
                    break;
            }
            return newstring;
        }

        public string Translit(string text)
        {
            string newstring = "";

            for (int i = 0; i < text.Length; ++i)
            {
                newstring += translitSymbol(text[i]);
            }

            return newstring;
        }
    }
}