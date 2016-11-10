using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTag
{
    class Account
    {
        public String id;
        public String pw;
        public String name;
        public Account(String id, String pw, String name)
        {
            this.id = id;
            this.pw = pw;
            this.name = name;
        }
    }
}
