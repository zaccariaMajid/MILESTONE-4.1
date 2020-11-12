using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace majid
{
    class richiesta
    {

        private static List<string> _elencocodici = new List<string>();
        private string _codice;
        public string codice
        {
            get
            {
                return _codice;
            }
        }

        private DateTime _dataR;
        public DateTime dataR
        {
            get
            {
                return _dataR;
            }
            set
            {

                if (value > DateTime.Now)
                    throw new Exception("Data nel futuro!");
                _dataR = value;
            }
        }

        private string _nome;
        public string nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new Exception("Nome richiedente: CAMPO OBBLIGATORIO");
                _nome = value;
            }
        }

        private string _rep;
        public string rep
        {
            get
            {
                return _rep;
            }
            set
            {
                _rep = value;
            }
        }

        private string _desc;
        public string desc
        {
            get
            {
                return _desc;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new Exception("Descrione: CAMPO OBBLIGATORIO");
                _desc = value;
            }
        }
        
        private int _lvl;
        public int lvl
        {
            get
            {
                return _lvl;
            }
            set
            {
                if(value<1 || value > 100)
                {
                    throw new Exception("Errore livello");
                }
                _lvl = value;
            }
        }

        private DateTime _dataRis;
        public DateTime dataRis
        {
            get
            {
                return _dataRis;
            }
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("Data nel futuro!");
                _dataRis = value;
            }
        }

        public richiesta(string codice, DateTime dataR, string nome, string rep, string desc, int lvl, DateTime dataRis = default)
        {
            if (string.IsNullOrEmpty(codice) == true)
            {
                throw new Exception("Errore codice");
            }
            if (_elencocodici.Contains(codice) == true)
            {
                throw new Exception("Codice già utilizzato");
            }
            

            this._codice = codice;
            this.dataR = dataR;
            this.nome = nome;
            this.rep = rep;
            this.desc = desc;
            this.lvl = lvl;
            this.dataRis = dataRis;

            _elencocodici.Add(codice);
        }

    }
}
