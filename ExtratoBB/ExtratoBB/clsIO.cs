using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Reflection;

namespace ExtratoBB
{
    internal class clsIO {

        private static IList<Lancamento> _extrato;
        private static DataSet _extratoDS;
        private static string caminho = @"C:\Users\user\source\repos\ExtratoBB";

        public static DataSet ObterDadosSet()
        {
            _extratoDS = new DataSet();
            var dt = _extratoDS.Tables.Add("Extrato");            
            int i = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(caminho);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if (file.Extension == ".csv")
                {
                    using (StreamReader sr = new StreamReader(file.FullName, Encoding.Default))
                    {
                        if (i == 0)
                        {
                            string[] cabecalho = sr.ReadLine().Split(',');
                            foreach (string campo in cabecalho)
                                dt.Columns.Add(campo);
                        }
                        else { sr.ReadLine(); }
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {                            
                            DataRow dr = dt.NewRow();                            
                            var valores = linha.Split(',');
                            for(int k = 0; k < valores.Length; k++)
                                dr[k]=valores[k];                            
                            dt.Rows.Add(dr);
                            i++;
                        }
                    }
                }
            }
            return _extratoDS;
        }

        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static IEnumerable<Lancamento> ObterDados()
        {
            string cabecalho;
            _extrato = new List<Lancamento>();
            try
            {
                int i = 0;
                DirectoryInfo dirInfo = new DirectoryInfo(caminho);
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    if (file.Extension == ".csv")
                    {
                        using (StreamReader sr = new StreamReader(file.FullName, Encoding.Default))
                        {
                            cabecalho = sr.ReadLine();
                            string linha;
                            
                            while ((linha = sr.ReadLine()) != null)
                            {
                                var valores = linha.Split(',');
                                _extrato.Add(new Lancamento(valores, i));
                                i++;
                            }

                        }
                    }
                }
                return _extrato;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return _extrato;
            }
        }
        public static IEnumerable<Lancamento> ObterDados(string ordem, bool asc)
        {   //nao é uma boa opçao para ordenaçao (realiza nova leitura para cada interaçao), para estudo funcionou bem
            switch (ordem)
            {
                case "Data":
                    if (!asc)
                        return ObterDados().OrderByDescending(c => c.Data).ToList();
                    else
                        return ObterDados().OrderBy(c => c.Data).ToList();

                case "Origem":
                    if (!asc)
                        return ObterDados().OrderByDescending(c => c.Origem).ToList();
                    else
                        return ObterDados().OrderBy(c => c.Origem).ToList();

                case "Historico":
                    if (!asc)
                        return ObterDados().OrderByDescending(c => c.Historico).ToList();
                    else
                        return ObterDados().OrderBy(c => c.Historico).ToList();

                case "DataBalancete":
                    if (!asc)
                        return ObterDados().OrderByDescending(c => c.DataBalancete).ToList();
                    else
                        return ObterDados().OrderBy(c => c.DataBalancete).ToList();

                case "NumLancamento":
                    if (!asc)
                        return ObterDados().OrderByDescending(c => c.NumLancamento).ToList();
                    else
                        return ObterDados().OrderBy(c => c.NumLancamento).ToList();

                case "Valor":
                    if (!asc)
                        return ObterDados().OrderByDescending(c => c.Valor).ToList();
                    else
                        return ObterDados().OrderBy(c => c.Valor).ToList();

                case "NumeroDocumento":
                    if (!asc)
                        return ObterDados().OrderByDescending(c => c.NumeroDocumento).ToList();
                    else
                        return ObterDados().OrderBy(c => c.NumeroDocumento).ToList();
                    
                default:
                    return ObterDados();
            }
        }
    }
    internal class Lancamento
    {
        private string _numLanc;
        //Data
        private DateTime _dtData;
        //"Dependencia Origem"
        private string _strOrigem;
        //"Histórico"
        private string _strHistorico;
        //"Data do Balancete"
        private DateTime _dtDataBal;
        //"Número do documento"
        private Int64 _intNumeroDoc;
        //"Valor",
        private double _dblValor;
        //"Saldo no momento da transacao",
        private double _dblSaldo;

        public Lancamento(string[] v, int i)
        {
            try
            {
                
                if (v[0].Replace("\"", "")!="")
                    _dtData = DateTime.ParseExact(v[0].Replace("\"", ""), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                _numLanc = i.ToString("000000");
                _strOrigem = v[1].Replace("\"", "");
                _strHistorico = v[2].Replace("\"", "");
                if (v[3].Contains("0018"))
                {
                    v[3] = v[3].Replace("0018", "2018");
                    //ver uma forma melhor de corrigir essa bosta que mandam
                    v[3] = v[3].Replace("21", "01");
                    v[3] = v[3].Replace("22", "02");
                    v[3] = v[3].Replace("23", "03");
                    v[3] = v[3].Replace("24", "04");
                    v[3] = v[3].Replace("25", "05");
                    v[3] = v[3].Replace("26", "06");
                    v[3] = v[3].Replace("27", "07");
                    v[3] = v[3].Replace("28", "08");
                    v[3] = v[3].Replace("29", "09");
                }
                if (v[3].Replace("\"", "") != "")
                    _dtDataBal = DateTime.ParseExact(v[3].Replace("\"", ""), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                _intNumeroDoc = Int64.Parse(v[4].Replace("\"", ""));
                _dblValor = double.Parse(v[5].Replace("\"", ""), System.Globalization.CultureInfo.InvariantCulture);
                

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(v[0] + " " + v[1] + " " + v[2] + " " + v[3] + " " + v[4] + " " + v[5] + " " + ex.ToString());                
            }
        }
        public string NumLancamento { get { return _numLanc; } }
        public DateTime Data { get { return _dtData; } }
        public string Origem { get { return _strOrigem; } }
        public string Historico { get { return _strHistorico; } }
        public DateTime DataBalancete { get { return _dtDataBal; } }
        public Int64 NumeroDocumento { get { return _intNumeroDoc; } }
        public double Valor { get { return _dblValor; } }
        //public string ValorFormatado { get { return _dblValor.ToString("0.00"); } }
    }
    
}
