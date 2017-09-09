using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_201504381
{
    class Errores
    {
        int line;
        int column;
        string type;
        string desc;

        public Errores(int _f, int _c, string _t, string _d)
        {
            this.line = _f + 1;
            this.column = _c;
            this.type = _t;
            this.desc = _d;
        }

        public int _line
        {
            get { return line; }
        }

        public int _col
        {
            get { return column; }
        }
        public string _type
        {
            get { return type; }
        }
        public string _desc
        {
            get { return desc; }
        }

    }
}
