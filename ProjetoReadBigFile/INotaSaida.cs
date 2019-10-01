using System;

namespace ProjetoReadBigFile
{
    //
    // Resumo:
    //     Representa um documento
    public interface INotaSaida
    {
        
        Guid nGUID { get; }
       
        Int64  ESANUMERO_NFS { get; } 
        DateTime  ESADATA_NFS { get; } 
        string  ESAVALOR_CONTAB_NFS { get; } 
        string ESAALIQ_NFS { get; }
        string ESAALIQINTER_SP_NFS { get; }
        string ESAALIQSAI_NFS { get; }
        string ESABASE_AQUISICAO_SP { get; }
        string ESABASEDIFA_NFS { get; }
        string ESABASEFUNRURAL_NFS { get; }
        string ESABASEICM_NFS { get; }
        string ESABASEIPI_NFS { get; }
        string ESABASERET_NFS { get; }
        string ESACODCLI_NFS { get; }
        string ESACODOBS_NFS { get; }
        string ESACOMPLNAT_NFS { get; }
        string ESADIAEMI_NFS { get; }        
        string ESAVLRAUXIPI_NFS { get; }
        string ESADIFALIQ_NFS { get; }
        string ESADTAEMI_NFS { get; }
        string ESAEMPR_NFS { get; }
        string ESAESPECIE_NFS { get; }
        string ESAEXER_NFS { get; }
        string ESAFUNRURAL_NFS { get; }
        string ESAIMPICM_NFS { get; }
        string ESAIMPIPI_NFS { get; }
        string ESAIMPRET_NFS { get; }
        string ESAISENICM_NFS { get; }
        string ESAISENIPI_NFS { get; }
        string ESALANC_NFS { get; }
        string ESAMES_NFS { get; }
        string ESAMG_VLR_ESTORNO { get; }
        string ESAVLRAUX_NFS { get; }
        string ESAMODELO_NFS { get; }
        string ESANAT_NFS { get; }
        string ESANUMI_NFS { get; }
        string ESANUMF_NFS { get; }
        string ESAOBSEXT_NFS { get; }
        string ESAOUTRICM_NFS { get; }
        string ESAOUTRIPI_NFS { get; }
        string ESASERIE_NFS { get; }
        string ESATIPO_TFIS { get; }
        string ESAVLRCON_NFS { get; }
        string ESACRED_OUTORGADO_GO { get; }
        string ESAVALOR_TOTAL_NFS { get; }
        string ESAEQUIP_MAPA_NFS { get; }
        string ESACODCONT_NFS { get; }
        
    }
}


