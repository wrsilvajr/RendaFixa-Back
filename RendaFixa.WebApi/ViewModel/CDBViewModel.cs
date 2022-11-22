using System.ComponentModel.DataAnnotations;

namespace RendaFixa.WebApi.ViewModel
{
    public class CDBViewModel
    {
        [Required(ErrorMessage = "O campo prazo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo prazo precisa ter o valor mínimo de 1")]
        public int Prazo { get; set; }

        [Required(ErrorMessage = "O campo valor inicial é obrigatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo valor inicial precisa ter um valor mínimo de 0.01")]
        public double ValorInicial { get; set; }
        
        public double ValorBruto { get; set; }
        
        public double ValorLiquido { get; set; }
    }
}