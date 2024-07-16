using System;
using System.Collections.Generic;

namespace JogoDaForca
{
    public class RepositorioPalavras
    {
        private List<PalavraComDica> _palavras;

        public RepositorioPalavras()
        {
            _palavras = new List<PalavraComDica>();
            _palavras.Add(new PalavraComDica("Fruta ácida", "ABACAXI"));
            _palavras.Add(new PalavraComDica("Fruta amarela", "BANANA"));
            _palavras.Add(new PalavraComDica("Fruta vermelha", "MORANGO"));
            _palavras.Add(new PalavraComDica("Fruta verde", "KIWI"));
            _palavras.Add(new PalavraComDica("Fruta cítrica", "LARANJA"));
            _palavras.Add(new PalavraComDica("Fruta roxa", "UVA"));
            _palavras.Add(new PalavraComDica("Fruta exótica", "MANGOSTÃO"));
            _palavras.Add(new PalavraComDica("Fruta tropical", "MANGA"));
            _palavras.Add(new PalavraComDica("Fruta do cerrado", "CAJU"));
            _palavras.Add(new PalavraComDica("Fruta nordestina", "UMBU"));
            _palavras.Add(new PalavraComDica("Fruta de casca dura", "COCO"));
            _palavras.Add(new PalavraComDica("Fruta de polpa branca", "PITAYA"));
            _palavras.Add(new PalavraComDica("Fruta pequena", "JABUTICABA"));
            _palavras.Add(new PalavraComDica("Fruta silvestre", "AMORA"));
            _palavras.Add(new PalavraComDica("Fruta redonda", "MAÇÃ"));
            _palavras.Add(new PalavraComDica("Fruta com caroço", "PÊSSEGO"));
            _palavras.Add(new PalavraComDica("Fruta suculenta", "MELANCIA"));
            _palavras.Add(new PalavraComDica("Fruta vermelha pequena", "CEREJA"));
            _palavras.Add(new PalavraComDica("Fruta asiática", "LICHIA"));
            _palavras.Add(new PalavraComDica("Fruta brasileira", "GRAVIOLA"));
            _palavras.Add(new PalavraComDica("Fruta com espinhos", "FRUTA-DO-CONDE"));
            _palavras.Add(new PalavraComDica("Fruta doce", "FIGO"));
            _palavras.Add(new PalavraComDica("Fruta exótica verde", "KIWI"));
            _palavras.Add(new PalavraComDica("Fruta de Natal", "ROMÃ"));
            _palavras.Add(new PalavraComDica("Fruta com casca verde", "PÊRA"));
            _palavras.Add(new PalavraComDica("Fruta saborosa", "PAPAYA"));
            _palavras.Add(new PalavraComDica("Fruta de climas frios", "CAQUI"));
            _palavras.Add(new PalavraComDica("Fruta de cor roxa", "AMEIXA"));
            _palavras.Add(new PalavraComDica("Fruta do deserto", "TÂMARA"));
            _palavras.Add(new PalavraComDica("Fruta de aroma forte", "JACA"));
            _palavras.Add(new PalavraComDica("Fruta redonda amarela", "MARACUJÁ"));
            _palavras.Add(new PalavraComDica("Fruta sabor agridoce", "TANGERINA"));
            _palavras.Add(new PalavraComDica("Fruta utilizada em sucos", "LIMÃO"));
            _palavras.Add(new PalavraComDica("Fruta para compotas", "MANGA"));
            _palavras.Add(new PalavraComDica("Fruta com muitas sementes", "ROMÃ"));
            _palavras.Add(new PalavraComDica("Fruta para doces", "GOIABA"));
            _palavras.Add(new PalavraComDica("Fruta pequena vermelha", "FRAMBOESA"));
            _palavras.Add(new PalavraComDica("Fruta seca", "UVAS-PASSAS"));
            _palavras.Add(new PalavraComDica("Fruta grande verde", "MELÃO"));
            _palavras.Add(new PalavraComDica("Fruta com nome de país", "KUMQUAT"));
            _palavras.Add(new PalavraComDica("Fruta africana", "SERIGUELA"));
            _palavras.Add(new PalavraComDica("Fruta com miolo doce", "CARAMBOLA"));
            _palavras.Add(new PalavraComDica("Fruta do outono", "NÊSPERA"));
            _palavras.Add(new PalavraComDica("Fruta de climas temperados", "PERA"));
            _palavras.Add(new PalavraComDica("Fruta com casca grossa", "ABACATE"));
            _palavras.Add(new PalavraComDica("Fruta de origem asiática", "PITAYA"));
            _palavras.Add(new PalavraComDica("Fruta com casca peluda", "PESSEGO"));
            _palavras.Add(new PalavraComDica("Fruta com polpa vermelha", "FRUTA-DO-DRAGÃO"));
            _palavras.Add(new PalavraComDica("Fruta para saladas", "TOMATE"));
        }

        public PalavraComDica Sorteia()
        {
            Random rand = new Random();
            var numero = rand.Next(0, _palavras.Count);
            return _palavras[numero];
        }
    }
}
