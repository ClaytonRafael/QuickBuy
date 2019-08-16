using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public IFormatProvider FormaPagamento { get; set; }

        //Deve ter pelo menos um item de pedido
        //ou muitos itens de pedidos
        public ICollection<ItemPedido> ItensPedido { get; set; }
        
        public override void Validate()
        {
            LimparMensagensValidacao();
            if (!ItensPedido.Any())
                AdicionarCritica("Crítica - Pedido não pode ficar sem item de pedido");
            if(string.IsNullOrEmpty(CEP))
                AdicionarCritica("O CEP deve está preenchido.");
        }
    }
}
