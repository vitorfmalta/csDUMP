using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoReadBigFile
{
    class CEFIOSA
    {
        static IList<INotaSaida> _doc;

        public static IEnumerable<INotaSaida> ObterDados(string caminho)
        {
            try
            {
                using (StreamReader sr = new StreamReader(caminho, true))
                {
                    string linha;
                    int i = 0;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (i > 0)
                        { 
                            var valores = linha.Split(',');
                            _doc.Add(new NotaSaida(valores));
                        }
                        i++;
                    }
                }
                return _doc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }


        internal class NotaSaida : INotaSaida
        {
            private Guid _nGUID;
            private Int64 _ESANUMERO_NFS;
            private DateTime _ESADATA_NFS;
            private string _ESAVALOR_CONTAB_NFS;
            private string _ESAALIQ_NFS;
            private string _ESAALIQINTER_SP_NFS;
            private string _ESAALIQSAI_NFS;
            private string _ESABASE_AQUISICAO_SP;
            private string _ESABASEDIFA_NFS;
            private string _ESABASEFUNRURAL_NFS;
            private string _ESABASEICM_NFS;
            private string _ESABASEIPI_NFS;
            private string _ESABASERET_NFS;
            private string _ESACODCLI_NFS;
            private string _ESACODOBS_NFS;
            private string _ESACOMPLNAT_NFS;
            private string _ESADIAEMI_NFS;
            private string _ESAVLRAUXIPI_NFS;
            private string _ESADIFALIQ_NFS;
            private string _ESADTAEMI_NFS;
            private string _ESAEMPR_NFS;
            private string _ESAESPECIE_NFS;
            private string _ESAEXER_NFS;
            private string _ESAFUNRURAL_NFS;
            private string _ESAIMPICM_NFS;
            private string _ESAIMPIPI_NFS;
            private string _ESAIMPRET_NFS;
            private string _ESAISENICM_NFS;
            private string _ESAISENIPI_NFS;
            private string _ESALANC_NFS;
            private string _ESAMES_NFS;
            private string _ESAMG_VLR_ESTORNO;
            private string _ESAVLRAUX_NFS;
            private string _ESAMODELO_NFS;
            private string _ESANAT_NFS;
            private string _ESANUMI_NFS;
            private string _ESANUMF_NFS;
            private string _ESAOBSEXT_NFS;
            private string _ESAOUTRICM_NFS;
            private string _ESAOUTRIPI_NFS;
            private string _ESASERIE_NFS;
            private string _ESATIPO_TFIS;
            private string _ESAVLRCON_NFS;
            private string _ESACRED_OUTORGADO_GO;
            private string _ESAVALOR_TOTAL_NFS;
            private string _ESAEQUIP_MAPA_NFS;
            private string _ESACODCONT_NFS;

            public NotaSaida(string[] valores)
            {
                _nGUID = new Guid(Guid.Parse(valores[0]).ToByteArray());
            }
            public Guid nGUID
            {
                get
                {
                    return _nGUID;
                }
            }
            public Int64 ESANUMERO_NFS { get { return _ESANUMERO_NFS; } }
            public DateTime ESADATA_NFS { get { return _ESADATA_NFS; } }
            public string ESAVALOR_CONTAB_NFS { get { return _ESAVALOR_CONTAB_NFS; } }
            public string ESAALIQ_NFS { get { return _ESAALIQ_NFS; } }
            public string ESAALIQINTER_SP_NFS { get { return _ESAALIQINTER_SP_NFS; } }
            public string ESAALIQSAI_NFS { get { return _ESAALIQSAI_NFS; } }
            public string ESABASE_AQUISICAO_SP { get { return _ESABASE_AQUISICAO_SP; } }
            public string ESABASEDIFA_NFS { get { return _ESABASEDIFA_NFS; } }
            public string ESABASEFUNRURAL_NFS { get { return _ESABASEFUNRURAL_NFS; } }
            public string ESABASEICM_NFS { get { return _ESABASEICM_NFS; } }
            public string ESABASEIPI_NFS { get { return _ESABASEIPI_NFS; } }
            public string ESABASERET_NFS { get { return _ESABASERET_NFS; } }
            public string ESACODCLI_NFS { get { return _ESACODCLI_NFS; } }
            public string ESACODOBS_NFS { get { return _ESACODOBS_NFS; } }
            public string ESACOMPLNAT_NFS { get { return _ESACOMPLNAT_NFS; } }
            public string ESADIAEMI_NFS { get { return _ESADIAEMI_NFS; } }
            public string ESAVLRAUXIPI_NFS { get { return _ESAVLRAUXIPI_NFS; } }
            public string ESADIFALIQ_NFS { get { return _ESADIFALIQ_NFS; } }
            public string ESADTAEMI_NFS { get { return _ESADTAEMI_NFS; } }
            public string ESAEMPR_NFS { get { return _ESAEMPR_NFS; } }
            public string ESAESPECIE_NFS { get { return _ESAESPECIE_NFS; } }
            public string ESAEXER_NFS { get { return _ESAEXER_NFS; } }
            public string ESAFUNRURAL_NFS { get { return _ESAFUNRURAL_NFS; } }
            public string ESAIMPICM_NFS { get { return _ESAIMPICM_NFS; } }
            public string ESAIMPIPI_NFS { get { return _ESAIMPIPI_NFS; } }
            public string ESAIMPRET_NFS { get { return _ESAIMPRET_NFS; } }
            public string ESAISENICM_NFS { get { return _ESAISENICM_NFS; } }
            public string ESAISENIPI_NFS { get { return _ESAISENIPI_NFS; } }
            public string ESALANC_NFS { get { return _ESALANC_NFS; } }
            public string ESAMES_NFS { get { return _ESAMES_NFS; } }
            public string ESAMG_VLR_ESTORNO { get { return _ESAMG_VLR_ESTORNO; } }
            public string ESAVLRAUX_NFS { get { return _ESAVLRAUX_NFS; } }
            public string ESAMODELO_NFS { get { return _ESAMODELO_NFS; } }
            public string ESANAT_NFS { get { return _ESANAT_NFS; } }
            public string ESANUMI_NFS { get { return _ESANUMI_NFS; } }
            public string ESANUMF_NFS { get { return _ESANUMF_NFS; } }
            public string ESAOBSEXT_NFS { get { return _ESAOBSEXT_NFS; } }
            public string ESAOUTRICM_NFS { get { return _ESAOUTRICM_NFS; } }
            public string ESAOUTRIPI_NFS { get { return _ESAOUTRIPI_NFS; } }
            public string ESASERIE_NFS { get { return _ESASERIE_NFS; } }
            public string ESATIPO_TFIS { get { return _ESATIPO_TFIS; } }
            public string ESAVLRCON_NFS { get { return _ESAVLRCON_NFS; } }
            public string ESACRED_OUTORGADO_GO { get { return _ESACRED_OUTORGADO_GO; } }
            public string ESAVALOR_TOTAL_NFS { get { return _ESAVALOR_TOTAL_NFS; } }
            public string ESAEQUIP_MAPA_NFS { get { return _ESAEQUIP_MAPA_NFS; } }
            public string ESACODCONT_NFS { get { return _ESACODCONT_NFS; } }

        }
    }
}
        