using CsvHelper.Configuration;
using Generics.Girls.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Generics.Girls.Utils
{
    public class MedicalRecordCsvMap : ClassMap<MedicalRecordDto>
    {
        public MedicalRecordCsvMap()
        {
            Map(x => x.Laboratorio).Name("Laboratorio");
            Map(x => x.Amostra).Name("Amostra");
            Map(x => x.CNES).Name("CNES");
            Map(x => x.CNPJ).Name("CNPJ");
            Map(x => x.CNS).Name("CNS");
            Map(x => x.ConselhoClasseProfissional).Name("ConselhoClasseProfissional");
            Map(x => x.Data).Name("Data");
            Map(x => x.FaixaReferencia).Name("FaixaReferencia");
            Map(x => x.IdentificacaoIndividuo).Name("IdentificacaoIndividuo");
            Map(x => x.Laboratorio).Name("Laboratorio");
            Map(x => x.MetodoAnalise).Name("MetodoAnalise");
            Map(x => x.NomeCompleto).Name("NomeCompleto");
            Map(x => x.NomeCompletoProfissional).Name("NomeCompletoProfissional");
            Map(x => x.NomeLaboratorio).Name("NomeLaboratorio");
            Map(x => x.NumeroRegistro).Name("NumeroRegistro");
            Map(x => x.ResponsavelTecnico).Name("ResponsavelTecnico");
            Map(x => x.ResultadoExameLaboratorio).Name("ResultadoExameLaboratorio");
            Map(x => x.ResultadoQualitativo).Name("ResultadoQualitativo");
            Map(x => x.ResultadoQuantitativo).Name("ResultadoQuantitativo");
            Map(x => x.TipoConselho).Name("TipoConselho");
            Map(x => x.UnidadeFederativa).Name("UnidadeFederativa");

            Map(x => x.Nota).Name("Nota").Convert(args => 
            {
                var noteList = args.Row.GetField<string>("Nota").Trim().Split(',').ToList() ?? new List<string>();
                var result = new List<string>();
                foreach (var item in noteList)
                {
                    result.Add(item.Trim());
                }
                return result;
            });
            Map(x => x.NomeExame).Name("NomeExame").Convert(args =>
            {
                return args.Row.GetField<string>("NomeExame").Trim().Split(',').ToList() ?? new List<string>();
            });
        }
    }
}
