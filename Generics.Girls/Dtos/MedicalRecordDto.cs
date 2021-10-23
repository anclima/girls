using System.Collections.Generic;

using CsvHelper.Configuration.Attributes;

namespace Generics.Girls.Dtos
{
    public class MedicalRecordDto
    {
		[Name("Laboratorio")]
		public string Laboratorio { get; set; }

		[Name("NomeLaboratorio")]
		public string NomeLaboratorio { get; set; }

		[Name("CNES")]
		public string CNES { get; set; }

		[Name("CNPJ")]
		[Optional]
		public string CNPJ { get; set; }

		[Name("ResponsavelTecnico")]
		[Optional]
		public string ResponsavelTecnico { get; set; }

		[Name("NomeCompletoProfissional")]
		public string NomeCompletoProfissional { get; set; }

		[Name("ConselhoClasseProfissional")]
		public string ConselhoClasseProfissional { get; set; }

		[Name("TipoConselho")]
		public string TipoConselho { get; set; }

		[Name("UnidadeFederativa")]
		public string UnidadeFederativa { get; set; }

		[Name("NumeroRegistro")]
		public string NumeroRegistro { get; set; }

		[Name("IdentificacaoIndividuo")]
		public string IdentificacaoIndividuo { get; set; }

		[Name("NomeCompleto")]
		public string NomeCompleto { get; set; }

		[Name("CNS")]
		public string CNS { get; set; }

		[Name("ResultadoExameLaboratorio")]
		public string ResultadoExameLaboratorio { get; set; }

		[Name("NomeExame")]
		public List<string> NomeExame { get; set; }

		[Name("ResultadoQualitativo")]
		[Optional]
		public string ResultadoQualitativo { get; set; }

		[Name("ResultadoQuantitativo")]
		[Optional]
		public string ResultadoQuantitativo { get; set; }

		[Name("Amostra")]
		public string Amostra { get; set; }

		[Name("MetodoAnalise")]
		public string MetodoAnalise { get; set; }

		[Name("FaixaReferencia")]
		public string FaixaReferencia { get; set; }

		[Name("Data")]
		public string Data { get; set; }

		[Name("Nota")]
		[Optional]
		public List<string> Nota { get; set; }
	}
}
