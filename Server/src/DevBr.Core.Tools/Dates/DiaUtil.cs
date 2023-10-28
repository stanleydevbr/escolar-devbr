namespace DevBr.Core.Tools.Dates
{
    public class DiaUtil
    {
        public static DateTime ObterProximoDiaUtil(DateTime dateTime)
        {
            //TODO: Exemplo deve ser movido para uma base de dados de cadastro de feriados;
            var datasComemorativas = new DataComemorativa();
            datasComemorativas.Feriados.Add(new Feriado { Dia = 1, Mes = 1, Descricao = "Ano novo", Tipo = "Nacional" });
            datasComemorativas.Feriados.Add(new Feriado { Dia = 7, Mes = 9, Descricao = "Independência da republica", Tipo = "Nacional" });
            datasComemorativas.Feriados.Add(new Feriado { Dia = 24, Mes = 10, Descricao = "Aniversário de Goiânia", Tipo = "Municipal" });
            datasComemorativas.Feriados.Add(new Feriado { Dia = 26, Mes = 7, Descricao = "Fundação da Cidade de Goiás", Tipo = "Estadual" });

            while (true)
            {
                if (dateTime.DayOfWeek == DayOfWeek.Saturday)
                    dateTime = dateTime.AddDays(2);
                else if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                    dateTime = dateTime.AddDays(1);

                var feriado = datasComemorativas.Feriados.Where(x => x.Mes == dateTime.Month && x.Dia == dateTime.Day).ToList();

                if (feriado.Any())
                    dateTime = dateTime.AddDays(1);
                else
                    return dateTime;
                return dateTime;
            }
        }
    }

    public class DataComemorativa
    {
        public List<Feriado>? Feriados { get; set; }
    }

    public class Feriado
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public string? Descricao { get; set; }
        public string? Tipo { get; set; }
    }
}
