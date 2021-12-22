using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LotTrackerApp.Data.Entities
{
    public class Produto

    {
        [Key]
        public string CodProduto { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public string Descricao { get; set; }
        public Familia Familia { get; set; }

    }

    public class ProdutoLote
    {
        public string Produto { get; set; }
        public string Lote { get; set; }
        public string Marca { get; set; }
        public string Fabricante { get; set; }

        public DateTime DtFabrico { get; set; }
        public DateTime DtValidade { get; set; }
    }

    public class ProdutoFabricante
    {
        public string Produto { get; set; }
        public string Fabricante { get; set; }
        public string Marca { get; set; }
        public Pais Pais { get; set; }

    }

    public class Pais
    {
        [Key]
        public string CodPais { get; set; }
        public string Descricao { get; set; }
    }
    public enum Familia
    {
     Perfume,
     Maquilhagem,
     Champo
    }

    public enum TipoProduto
    {
        ProdutoAcabdo,
        MateriaPrima,
        Serviço
    }


}
